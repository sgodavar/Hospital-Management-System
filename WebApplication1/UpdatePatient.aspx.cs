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
    public partial class UpdatePatient : System.Web.UI.Page
    {
        MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User"];
            string[] cookieValues;
            String userName = null;
            String role = null;
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
                            role = "IT";
                            HyperLink1.NavigateUrl = "ITCentral.aspx";
                            break;
                        case "Nurse":
                            role = "Nurse";
                            userName = cookieValues[2];
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

                     if(role == "IT")
                    {
                        connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                        connection.Open();
                        MySqlDataAdapter command = new MySqlDataAdapter("SELECT Username as FullName FROM patient;", connection);
                        DataSet ds = new DataSet();
                        command.Fill(ds, "FullName");

                        DropDownList1.DataSource = ds;
                        DropDownList1.DataValueField = "FullName";
                        DropDownList1.DataBind();
                        connection.Close();
                    
                     }
                     else if (role == "Nurse")
                     {
                        connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                        connection.Open();
                        String query1 = "SELECT EmpID FROM employee WHERE Username = '" + userName + "';";
                        MySqlCommand command1 = new MySqlCommand(query1, connection);
                        object nrID = command1.ExecuteScalar();
                        int nID = Int32.Parse(nrID.ToString());
                        connection.Close();

                        connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                        connection.Open();
                        String query2 = "SELECT doctor_id FROM doctor_nurse WHERE nurse_id = " + nID + ";";
                        MySqlCommand command2 = new MySqlCommand(query2, connection);
                        object drID = command2.ExecuteScalar();
                        int dID = Int32.Parse(drID.ToString());
                        connection.Close();

                        connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                        connection.Open();
                        MySqlDataAdapter SQLCommand = new MySqlDataAdapter("SELECT Username as FullName FROM patient WHERE doctor_id=" + dID + ";", connection);
                        DataSet ds1 = new DataSet();
                        SQLCommand.Fill(ds1, "FullName");

                        DropDownList1.DataSource = ds1;
                        DropDownList1.DataValueField = "FullName";
                        DropDownList1.DataBind();
                        connection.Close();
                    }
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

            if (TextBox1.Text.ToString() == string.Empty && TextBox2.Text.ToString() == string.Empty && TextBox3.Text.ToString() == string.Empty && TextBox4.Text.ToString() == string.Empty && TextBox5.Text.ToString() == string.Empty && TextBox8.Text.ToString() == string.Empty && TextBox9.Text.ToString() == string.Empty && TextBox10.Text.ToString() == string.Empty && TextBox11.Text.ToString() == string.Empty && TextBox12.Text.ToString() == string.Empty)
            {
                Label2.Text = "Error updating Patient. No information is entered!";
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Visible = true;
            }

            else
            {

                if (TextBox10.Text.ToString() != string.Empty || TextBox11.Text.ToString() != string.Empty || TextBox12.Text.ToString() != string.Empty)
                {
                    if (TextBox10.Text.ToString() == string.Empty || TextBox11.Text.ToString() == string.Empty || TextBox12.Text.ToString() == string.Empty
                    || Int32.Parse(TextBox10.Text.ToString()) > 31 || Int32.Parse(TextBox10.Text.ToString()) < 0 || Int32.Parse(TextBox11.Text.ToString()) > 12 || Int32.Parse(TextBox11.Text.ToString()) < 0 || Int32.Parse(TextBox12.Text.ToString()) < 1800
                    || Int32.Parse(TextBox12.Text.ToString()) > DateTime.Now.Date.Year)
                    {
                        Label3.Visible = true;
                        correct = false;
                    }
                    else
                    {
                        connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                        connection.Open();
                        String query = "UPDATE patient SET DOB = '" + TextBox12.Text.ToString() + "-" + TextBox11.Text.ToString() + "-" + TextBox10.Text.ToString() + "'WHERE Username= '" + DropDownList1.SelectedItem.ToString() + "';";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteReader();
                        connection.Close();


                    }
                }
                if (TextBox1.Text.ToString() != string.Empty && correct == true)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();
                    String query = "UPDATE patient SET PatientName = '" + TextBox1.Text.ToString() + "'WHERE Username= '" + DropDownList1.SelectedItem.ToString() + "';";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteReader();
                    connection.Close();
                }
                if (TextBox2.Text.ToString() != string.Empty && correct == true)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();
                    String query = "UPDATE patient SET Address = '" + TextBox2.Text.ToString() + "'WHERE Username= '" + DropDownList1.SelectedItem.ToString() + "';";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteReader();
                    connection.Close();
                }
                if (TextBox3.Text.ToString() != string.Empty && correct == true)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();
                    String query = "UPDATE patient SET Phone_number = '" + TextBox3.Text.ToString() + "'WHERE Username= '" + DropDownList1.SelectedItem.ToString() + "';";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteReader();
                    connection.Close();
                }
                if (TextBox4.Text.ToString() != string.Empty && correct == true)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();
                    String query = "UPDATE patient SET GHIN = '" + TextBox4.Text.ToString() + "'WHERE Username= '" + DropDownList1.SelectedItem.ToString() + "';";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteReader();
                    connection.Close();
                }
                if (TextBox5.Text.ToString() != string.Empty && correct == true)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();
                    String query = "UPDATE patient SET PHIN = '" + TextBox5.Text.ToString() + "'WHERE Username= '" + DropDownList1.SelectedItem.ToString() + "';";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteReader();
                    connection.Close();
                }
                if (TextBox8.Text.ToString() != string.Empty && correct == true)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();
                    String query = "UPDATE patient SET EmergencyContactName = '" + TextBox8.Text.ToString() + "'WHERE Username= '" + DropDownList1.SelectedItem.ToString() + "';";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteReader();
                    connection.Close();
                }
                if (TextBox9.Text.ToString() != string.Empty && correct == true)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();
                    String query = "UPDATE patient SET EmergencyContactNumber = '" + TextBox9.Text.ToString() + "'WHERE Username= '" + DropDownList1.SelectedItem.ToString() + "';";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteReader();
                    connection.Close();
                }


                if (correct)
                {

                    Label2.Text = "Patient Updated Successfully!";
                    Label2.ForeColor = System.Drawing.Color.Green;
                    Label2.Visible = true;

                    resetForm(true);

                }
                else
                {
                    Label2.Text = "Error updating Patient. Please fix the Error!";
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Visible = true;
                }
            }
        }

        public void resetForm(bool full)
        {

            Label3.Visible = false;


            if (full)
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
                TextBox4.Text = string.Empty;
                TextBox5.Text = string.Empty;
                TextBox8.Text = string.Empty;
                TextBox9.Text = string.Empty;
                TextBox10.Text = string.Empty;
                TextBox11.Text = string.Empty;
                TextBox12.Text = string.Empty;
            }
        }
    }
}