using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    public partial class AddPatient : System.Web.UI.Page
    {
        MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User"];
            string[] cookieValues;
            if (cookie == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                cookieValues = cookie.Value.Split(':');
                if (cookieValues[0] != "Nurse" && cookieValues[0] != "IT")
                {
                    Response.Redirect("Login.aspx", true);
                }
                else
                {
                    switch (cookieValues[0])
                    {
                        case "IT":
                            HyperLink1.NavigateUrl = "ITCentral.aspx";
                            break;
                        case "Nurse":
                            HyperLink1.NavigateUrl = "NurseCentral.aspx";
                            break;
                        default:
                            HyperLink1.NavigateUrl = "Login.aspx";
                            break;
                    }

                }
            }
            if (!IsPostBack)
            {
                try
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();

                    MySqlDataAdapter command = new MySqlDataAdapter("SELECT CONCAT('Dr.',EmployeeName) as FullName FROM employee WHERE Role = 'Doctor';", connection);
                    DataSet ds = new DataSet();
                    command.Fill(ds, "FullName");

                    DropDownList1.DataSource = ds;
                    DropDownList1.DataValueField = "FullName";
                    DropDownList1.DataBind();
                    connection.Close();
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message.ToString());
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool correct = true;
            resetForm(false);
            if (TextBox1.Text.ToString() == string.Empty)
            {
                Label1.Visible = true;
                correct = false;
            }
            if (TextBox2.Text.ToString() == string.Empty)
            {
                Label3.Visible = true;
                correct = false;
            }
            if (TextBox3.Text.ToString() == string.Empty)
            {
                Label4.Visible = true;
                correct = false;
            }
            if (TextBox6.Text.ToString() == string.Empty)
            {
                Label7.Visible = true;
                correct = false;
            }
            if (TextBox7.Text.ToString() == string.Empty)
            {
                Label8.Visible = true;
                correct = false;
            }
            if (TextBox8.Text.ToString() == string.Empty)
            {
                Label5.Visible = true;
                correct = false;
            }
            if (TextBox9.Text.ToString() == string.Empty)
            {
                Label6.Visible = true;
                correct = false;
            }
            if (TextBox10.Text.ToString() == string.Empty || TextBox11.Text.ToString() == string.Empty || TextBox12.Text.ToString() == string.Empty ||
                Int32.Parse(TextBox10.Text.ToString()) > 31 || Int32.Parse(TextBox10.Text.ToString()) < 0 || Int32.Parse(TextBox11.Text.ToString()) > 12 || Int32.Parse(TextBox11.Text.ToString()) < 0 || Int32.Parse(TextBox12.Text.ToString()) < 1800
                || Int32.Parse(TextBox12.Text.ToString()) > DateTime.Now.Date.Year)
            {
                Label2.Visible = true;
                correct = false;
            }

            if (correct)
            {

                Label9.Text = "Patient Created Successfully!";
                Label9.ForeColor = System.Drawing.Color.Green;
                Label9.Visible = true;


                String GovermentInsurance = "NULL";
                if (TextBox4.Text.ToString() != String.Empty)
                {
                    GovermentInsurance = TextBox4.Text.ToString();
                }

                String PrivateInsurance = "NULL";
                if (TextBox5.Text.ToString() != String.Empty)
                {
                    PrivateInsurance = TextBox5.Text.ToString();
                }

                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();

                String DrName = DropDownList1.SelectedItem.ToString();
                String[] name;
                name = DrName.Split('.');
                String SQLQuery = "SELECT EmpID FROM employee WHERE Role = 'Doctor' AND EmployeeName ='" + name[1] + "';";
                MySqlCommand SQLCommand = new MySqlCommand(SQLQuery, connection);
                object dr = SQLCommand.ExecuteScalar();
                int drID = Int32.Parse(dr.ToString());


                string query1 = "INSERT INTO patient(PatientName,Username,Address,Phone_number,Patientpassword,GHIN,PHIN,DOB,doctor_id,EmergencyContactName,EmergencyContactNumber) VALUES ('"
                    + TextBox1.Text.ToString() + "','"
                    + TextBox6.Text.ToString() + "','"
                    + TextBox2.Text.ToString() + "','"
                    + TextBox3.Text.ToString() + "','"
                    + TextBox7.Text.ToString() + "','"
                    + GovermentInsurance + "','"
                    + PrivateInsurance + "','"
                    + TextBox12.Text.ToString() + "-" + TextBox11.Text.ToString() + "-" + TextBox10.Text.ToString() + "',"
                    + drID +",'"
                    + TextBox8.Text.ToString() + "','"
                    + TextBox9.Text.ToString() + "');";

                try
                {
                    MySqlCommand command = new MySqlCommand(query1, connection);
                    command.ExecuteReader();
                }
                catch (Exception exp)
                {
                    if (exp.Message.Contains("Username"))
                    {
                        Label7.Visible = true;
                        Label9.Text = "Error creating Patient. Please fix all Errors! (pick another Username)";
                        Label9.ForeColor = System.Drawing.Color.Red;
                        Label9.Visible = true;
                    }
                }
                connection.Close();

                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();
                String query3 = "SELECT PatientID FROM patient WHERE Username ='" + TextBox6.Text.ToString() + "';";
                MySqlCommand SQLCommand1 = new MySqlCommand(query3, connection);
                object patientID = SQLCommand1.ExecuteScalar();
                int pID = Int32.Parse(patientID.ToString());
                connection.Close();

                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();

                String query2 = "INSERT INTO doctor_patient(Doctor_id,Patient_id) VALUES("
                    + drID + ","
                    + pID + ");";

                MySqlCommand SQLCommand2 = new MySqlCommand(query2, connection);
                SQLCommand2.ExecuteReader();

                connection.Close();

                resetForm(true);

            }
            else
            {
                Label9.Text = "Error creating Patient. Please fix all Errors!";
                Label9.ForeColor = System.Drawing.Color.Red;
                Label9.Visible = true;
            }
        }

        public void resetForm(bool full)
        {

            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;


            if (full)
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
                TextBox4.Text = string.Empty;
                TextBox5.Text = string.Empty;
                TextBox6.Text = string.Empty;
                TextBox7.Text = string.Empty;
                TextBox8.Text = string.Empty;
                TextBox9.Text = string.Empty;
                TextBox10.Text = string.Empty;
                TextBox11.Text = string.Empty;
                TextBox12.Text = string.Empty;
            }
        }

    }
}
