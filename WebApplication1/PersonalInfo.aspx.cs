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
    public partial class PersonalInfo : System.Web.UI.Page
    {
        MySqlConnection connection;
        string Username;
        List<String> Days = new List<string>();
        List<String> Months = new List<string>();
        List<String> Years = new List<string>();

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
                if (cookieValues[0] == "Patient")
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
                        case "Billing":
                            HyperLink1.NavigateUrl = "BillingCentral.aspx";
                            break;
                        case "Legal":
                            HyperLink1.NavigateUrl = "LegalCentral.aspx";
                            break;
                        case "Doctor":
                            HyperLink1.NavigateUrl = "DoctorCentral.aspx";
                            break;
                        default:
                            HyperLink1.NavigateUrl = "Login.aspx";
                            break;
                    }

                    if (!IsPostBack)
                    {
                        Days.Add(string.Empty);
                        for (int i = 1; i < 32; i++)
                        {
                            string day = i.ToString();
                            Days.Add(day);
                        }
                        Months.Add(string.Empty);
                        Months.Add("01");
                        Months.Add("02");
                        Months.Add("03");
                        Months.Add("04");
                        Months.Add("05");
                        Months.Add("06");
                        Months.Add("07");
                        Months.Add("08");
                        Months.Add("09");
                        Months.Add("10");
                        Months.Add("11");
                        Months.Add("12");
                        Years.Add(string.Empty);
                        for (int i = 1940; i < 2001; i++)
                        {
                            string year = i.ToString();
                            Years.Add(year);
                        }
                        DropDownList1.DataSource = Days;
                        DropDownList1.DataBind();
                        DropDownList2.DataSource = Months;
                        DropDownList2.DataBind();
                        DropDownList3.DataSource = Years;
                        DropDownList3.DataBind();
                    }
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool correct = true;
            resetForm(false);

            HttpCookie cookie = Request.Cookies["User"];
            string[] cookieValues;
            
            if (cookie == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                cookieValues = cookie.Value.Split(':');
                Username = cookieValues[2];
            }

            if (TextBox1.Text.ToString() == string.Empty && DropDownList1.SelectedItem.ToString() == string.Empty && DropDownList2.SelectedItem.ToString() == string.Empty && DropDownList3.SelectedItem.ToString() == string.Empty && TextBox2.Text.ToString() == string.Empty && TextBox3.Text.ToString() == string.Empty && TextBox4.Text.ToString() == string.Empty && TextBox5.Text.ToString() == string.Empty)
            {
                Label1.Text = "Error: Enter field for updating.";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Visible = true;
                correct = false;
            }

            if(correct)
            {
                bool success = false;

                if (DropDownList1.SelectedItem.ToString() != string.Empty && DropDownList2.SelectedItem.ToString() != string.Empty && DropDownList3.SelectedItem.ToString() != string.Empty)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();

                    string query = "UPDATE employee SET DOB ='"
                        + DropDownList3.SelectedItem.ToString() + "-" + DropDownList2.SelectedItem.ToString() + "-" + DropDownList1.SelectedItem.ToString()
                        + "' WHERE Username = '" + Username + "';";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteReader();
                        success = true;
                        connection.Close();
                }
                if (TextBox2.Text.ToString() != string.Empty)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();

                    string query = "UPDATE employee SET Address ='"
                        + TextBox2.Text.ToString()
                        + "' WHERE Username = '" + Username + "';";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteReader();
                        success = true;
                        connection.Close();
                }
                if (TextBox3.Text.ToString() != string.Empty)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();

                    string query = "UPDATE employee SET Phone_number ='"
                        + TextBox3.Text.ToString()
                        + "' WHERE Username = '" + Username + "';";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteReader();
                        success = true;
                        connection.Close();
                }
                if (TextBox4.Text.ToString() != string.Empty)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();

                    string query = "UPDATE employee SET SIN ='"
                        + TextBox4.Text.ToString()
                        + "' WHERE Username = '" + Username + "';";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteReader();
                        success = true;
                        connection.Close();
                }
                if (TextBox5.Text.ToString() != string.Empty)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();

                    string query = "UPDATE employee SET MINC ='"
                        + TextBox5.Text.ToString()
                        + "' WHERE Username = '" + Username + "';";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteReader();
                        success = true;
                        connection.Close();
                }
                if (TextBox1.Text.ToString() != string.Empty)
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();

                    string query = "UPDATE employee SET EmployeeName = '"
                        + TextBox1.Text.ToString()
                        + "' WHERE Username = '" + Username + "';";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteReader();
                        success = true;
                        connection.Close();
                }
                if (success)
                {
                    Label2.Text = "Personal information updated successfully.";
                    Label2.ForeColor = System.Drawing.Color.Green;
                    Label2.Visible = true;
                }
                resetForm(true);
            }

        }
        protected void resetForm(bool full)
        {
            if (full)
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
                TextBox4.Text = string.Empty;
                TextBox5.Text = string.Empty;
            }

        }
    }
}