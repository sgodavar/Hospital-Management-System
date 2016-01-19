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
    public partial class AddEmployee : System.Web.UI.Page
    {

        List<String> roles = new List<string>();
        HttpCookie cookie;
        MySqlConnection connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            roles.Add("Billing");
            roles.Add("Doctor");
            roles.Add("IT");
            roles.Add("Legal");
            roles.Add("Nurse");

            cookie = Request.Cookies["User"];

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
                    Server.Transfer("Login.aspx", true);
                }
                else
                {
                    HyperLink1.NavigateUrl = "ITCentral.aspx";
                }
            }

            if (!IsPostBack)
            {
                DropDownList1.DataSource = roles;
                DropDownList1.DataBind();
                
            }
            Label9.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            bool correct = true;
            resetForm(false);
            if(TextBox1.Text.ToString() == string.Empty){
                Label1.Visible = true;
                correct = false;
            }
            if(TextBox2.Text.ToString() == string.Empty){
                Label3.Visible = true;
                correct = false;
            } 
            if(TextBox3.Text.ToString() == string.Empty){
                Label4.Visible = true;
                correct = false;
            }
            if(TextBox4.Text.ToString() == string.Empty){
                Label5.Visible = true;
                correct = false;
            }
            if (TextBox5.Text.ToString() == string.Empty && (DropDownList1.SelectedItem.ToString() == "Doctor" || DropDownList1.SelectedItem.ToString() == "Nurse"))
            {
                Label6.Visible = true;
                correct = false;
            }
            if(TextBox6.Text.ToString() == string.Empty){
                Label7.Visible = true;
                correct = false;
            }
            if(TextBox7.Text.ToString() == string.Empty){
                Label8.Visible = true;
                correct = false;
            }
            if (TextBox8.Text.ToString() == string.Empty || TextBox9.Text.ToString() == string.Empty || TextBox10.Text.ToString() == string.Empty ||
                Int32.Parse(TextBox8.Text.ToString()) > 31 || Int32.Parse(TextBox8.Text.ToString()) < 0 || Int32.Parse(TextBox9.Text.ToString()) > 12 || Int32.Parse(TextBox9.Text.ToString()) < 0 || Int32.Parse(TextBox10.Text.ToString()) < 1800
                || Int32.Parse(TextBox10.Text.ToString()) > DateTime.Now.Date.Year)
            {
                Label2.Visible = true;
                correct = false;
            }

            if(correct){
                
                Label9.Text = "Employee Created Successfully!";
                Label9.ForeColor = System.Drawing.Color.Green;
                Label9.Visible = true;

                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();

                String MINC = "NULL";
                if (TextBox5.Text.ToString() != String.Empty)
                {
                    MINC = TextBox5.Text.ToString();
                }

                string query = "INSERT INTO employee(EmployeeName,Username,Address,Phone_number,Emppassword,SIN,MINC,DOB,Role) VALUES ('"
                    + TextBox1.Text.ToString() + "','"
                    + TextBox6.Text.ToString() + "','"
                    + TextBox2.Text.ToString() + "','"
                    + TextBox3.Text.ToString() + "','"
                    + TextBox7.Text.ToString() + "',"
                    + TextBox4.Text.ToString() + ","
                    + MINC + ",'"
                    + TextBox10.Text.ToString() + "-" + TextBox9.Text.ToString() + "-" + TextBox8.Text.ToString() + "','"
                    + DropDownList1.SelectedItem.ToString() + "');";

                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteReader();
                }
                catch (Exception exp)
                {
                    if (exp.Message.Contains("Username"))
                    {
                        Label7.Visible = true;
                        Label9.Text = "Error creating Employee. Please fix all Errors! (pick another Username)";
                        Label9.ForeColor = System.Drawing.Color.Red;
                        Label9.Visible = true;
                    }
                }
                connection.Close();
                
                resetForm(true);

            }
            else{
                Label9.Text = "Error creating Employee. Please fix all Errors!";
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
            }
        }
    }
}