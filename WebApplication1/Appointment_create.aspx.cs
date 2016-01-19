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
    public partial class Appointment : System.Web.UI.Page
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
                if (cookieValues[0] != "Nurse" && cookieValues[0] != "Patient" && cookieValues[0] != "IT" && cookieValues[0] != "Doctor")
                {
                    Response.Redirect("Login.aspx", true);
                }
            }

            if (!IsPostBack)
            {
                cookieValues = cookie.Value.Split(':');
                string doc_q, pat_q;
                switch (cookieValues[0])
                {
                    case "Nurse":
                        doc_q = "SELECT CONCAT('Dr. ',EmployeeName) as FullName FROM employee WHERE EmpID=(SELECT doctor_id FROM doctor_nurse WHERE nurse_id=(SELECT EmpID FROM employee WHERE " +
                                "Username='" + cookieValues[2] + "'));";
                        pat_q = "SELECT PatientName FROM patient WHERE doctor_id=(SELECT doctor_id FROM doctor_nurse WHERE nurse_id=" +
                                "(SELECT EmpID FROM employee WHERE " + "Username='" + cookieValues[2] + "'));";
                        break;
                    case "Patient":
                        doc_q = "SELECT CONCAT('Dr. ',EmployeeName) as FullName FROM employee WHERE EmpID=(SELECT doctor_id FROM patient WHERE Username='" + cookieValues[2] + "');";
                        pat_q = "SELECT PatientName FROM patient WHERE Username='" + cookieValues[2] + "';";
                        break;
                    case "Doctor":
                        doc_q = "SELECT CONCAT('Dr. ',EmployeeName) as FullName FROM employee WHERE Username='" + cookieValues[2] + "';";
                        pat_q = "SELECT PatientName FROM patient WHERE doctor_id=(SELECT EmpID FROM employee WHERE Username='" + cookieValues[2] + "');";
                        break;
                    default:
                        doc_q = "SELECT CONCAT('Dr. ',EmployeeName) as FullName FROM employee WHERE Role = 'Doctor';";
                        pat_q = "SELECT PatientName FROM patient;";
                        break;

                }
                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();

                MySqlDataAdapter command = new MySqlDataAdapter(doc_q, connection);
                DataSet ds = new DataSet();
                command.Fill(ds, "FullName");

                DropDownList2.DataSource = ds;
                DropDownList2.DataValueField = "FullName";
                DropDownList2.DataBind();

                command = new MySqlDataAdapter(pat_q, connection);
                DataSet ds2 = new DataSet();
                command.Fill(ds2, "FullName");

                DropDownList1.DataSource = ds2;
                DropDownList1.DataValueField = "PatientName";
                DropDownList1.DataBind();
                connection.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool correct = true;
            resetForm(false);

            if (TextBox4.Text.ToString() == string.Empty)
            {
                Label4.Visible = true;
                correct = false;
            }
            if (TextBox5.Text.ToString() == string.Empty)
            {
                Label5.Visible = true;
                correct = false;
            }
            if (correct)
            {

                Label6.Text = "Appointment Created Successfully!";
                Label6.ForeColor = System.Drawing.Color.Green;
                Label6.Visible = true;

                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();

                String DoctorName = DropDownList2.SelectedItem.ToString();
                DoctorName = DoctorName.Replace("Dr. ", "");

                string query = "INSERT INTO appointment(Diagnosis,Apptime,DoctorName,NurseName,PatientName,AppDate) VALUES ('"
                    + TextBox5.Text.ToString() + "','"
                    + Calendar1.SelectedDate.Year + "-" + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day + " " + TextBox4.Text.ToString() + "','"
                    + DoctorName + "',"
                    + "(select EmployeeName from employee where EmpID = (select nurse_id from doctor_nurse where doctor_id = (select EmpID from employee where EmployeeName = '" + DoctorName + "'))),'"
                    + DropDownList1.SelectedItem.ToString() + "','"
                    + Calendar1.SelectedDate.Year + "-" + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day
                    + "');";

                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteReader();
                }
                catch (Exception exp)
                {
                    if (exp.Message.Contains("Username"))
                    {
                        Label6.Text = "Error creating Employee. Please fix all Errors!";
                        Label6.ForeColor = System.Drawing.Color.Red;
                        Label6.Visible = true;
                    }
                }
                connection.Close();

                resetForm(true);
            }
            else
            {
                Label6.Text = "Error creating Employee. Please fix all Errors!";
                Label6.ForeColor = System.Drawing.Color.Red;
                Label6.Visible = true;
            }
        }
        public void resetForm(bool full)
        {

            Label4.Visible = false;
            Label5.Visible = false;

            if (full)
            {
                TextBox4.Text = string.Empty;
                TextBox5.Text = string.Empty;
            }
        }
    }
}