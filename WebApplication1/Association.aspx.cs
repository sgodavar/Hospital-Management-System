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
    public partial class Association : System.Web.UI.Page
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
                if (cookieValues[0] != "IT")
                {
                    Response.Redirect("Login.aspx", true);
                }
            }

            if (!IsPostBack)
            {
                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();

                MySqlDataAdapter command = new MySqlDataAdapter("SELECT EmployeeName as FullName FROM employee WHERE Role = 'Doctor';", connection);
                DataSet ds = new DataSet();
                command.Fill(ds, "FullName");

                DropDownList1.DataSource = ds;
                DropDownList1.DataValueField = "FullName";
                DropDownList1.DataBind();

                DropDownList3.DataSource = ds;
                DropDownList3.DataValueField = "FullName";
                DropDownList3.DataBind();

                MySqlDataAdapter command2 = new MySqlDataAdapter("SELECT EmployeeName FROM employee WHERE Role = 'Nurse';", connection);
                DataSet ds2 = new DataSet();
                command2.Fill(ds2, "EmployeeName");

                DropDownList2.DataSource = ds2;
                DropDownList2.DataValueField = "EmployeeName";
                DropDownList2.DataBind();

                connection.Close();

                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();

                MySqlDataAdapter command6 = new MySqlDataAdapter("SELECT PatientName FROM Patient;", connection);
                DataSet ds3 = new DataSet();
                command6.Fill(ds3, "PatientName");

                DropDownList4.DataSource = ds3;
                DropDownList4.DataValueField = "PatientName";
                DropDownList4.DataBind();

                connection.Close();
            }
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();
            String query1 = "SELECT EmpID FROM Employee WHERE EmployeeName = '" + DropDownList1.SelectedValue.ToString() + "';";
            MySqlCommand SQLCommand1 = new MySqlCommand(query1, connection);
            object EmpID = SQLCommand1.ExecuteScalar();
            int doctorID = Int32.Parse(EmpID.ToString());
            connection.Close();

            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();
            String query2 = "SELECT EmpID as NurseID FROM Employee WHERE EmployeeName = '" + DropDownList2.SelectedValue.ToString() + "';";
            MySqlCommand SQLCommand2 = new MySqlCommand(query2, connection);
            object EmpID4= SQLCommand2.ExecuteScalar();
            int NurseID = Int32.Parse(EmpID4.ToString());
            connection.Close();

            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();

            String query3 = "DELETE FROM doctor_nurse WHERE doctor_id = (" + doctorID + ") OR (nurse_id = " + NurseID + ");";

            MySqlCommand SQLCommand3 = new MySqlCommand(query3, connection);
            SQLCommand3.ExecuteReader();

            connection.Close();


            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();

            String query4 = "INSERT INTO doctor_nurse(Doctor_id,Nurse_id) VALUES(" + doctorID + "," + NurseID + ");";

            MySqlCommand SQLCommand4 = new MySqlCommand(query4, connection);
            SQLCommand4.ExecuteReader();

            connection.Close();
        }

        public string ds { get; set; }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();
            String query5 = "SELECT EmpID FROM Employee WHERE EmployeeName = '" + DropDownList3.SelectedValue.ToString() + "';";
            MySqlCommand SQLCommand5 = new MySqlCommand(query5, connection);
            object EmpID = SQLCommand5.ExecuteScalar();
            int doctorID = Int32.Parse(EmpID.ToString());
            connection.Close();

            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();
            String query6 = "SELECT PatientID FROM Patient WHERE PatientName = '" + DropDownList4.SelectedValue.ToString() + "';";
            MySqlCommand SQLCommand6 = new MySqlCommand(query6, connection);
            object EmpID4 = SQLCommand6.ExecuteScalar();
            int PatientID = Int32.Parse(EmpID4.ToString());
            connection.Close();

            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();

            String query7 = "DELETE FROM doctor_Patient WHERE (Patient_id = " + PatientID + ");";

            MySqlCommand SQLCommand7 = new MySqlCommand(query7, connection);
            SQLCommand7.ExecuteReader();

            connection.Close();


            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();

            String query8 = "INSERT INTO doctor_Patient(Doctor_id,Patient_id) VALUES(" + doctorID + "," + PatientID + ");";

            MySqlCommand SQLCommand8 = new MySqlCommand(query8, connection);
            SQLCommand8.ExecuteReader();

            connection.Close();

            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();

            string query9 = "UPDATE patient SET doctor_id = '" + doctorID + "' WHERE PatientName = '" + DropDownList4.SelectedValue.ToString() + "';";

            MySqlCommand command9 = new MySqlCommand(query9, connection);
            command9.ExecuteReader();
            connection.Close();
        }  
        public string ds2 { get; set; }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}