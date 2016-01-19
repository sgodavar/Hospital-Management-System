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
    public partial class Login : System.Web.UI.Page
    {
        MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox2.TextMode = TextBoxMode.Password;
            HttpCookie cookie = Request.Cookies["User"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();

                string query_e = "SELECT * FROM employee WHERE Username='" + TextBox1.Text.ToString() + "' AND Emppassword='" + TextBox2.Text.ToString() + "';";
                string query_p = "SELECT * FROM patient WHERE Username='" + TextBox1.Text.ToString() + "' AND Patientpassword='" + TextBox2.Text.ToString() + "';";


                MySqlDataAdapter command = new MySqlDataAdapter(query_e, connection);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                command.Fill(ds, "employee");

                MySqlDataAdapter commandp = new MySqlDataAdapter(query_p, connection);
                DataSet dsp = new DataSet();
                DataTable dtp = new DataTable();
                commandp.Fill(dsp, "patient");

                if (ds.Tables[0].Rows.Count == 0 && dsp.Tables[0].Rows.Count == 0)
                {
                    Label1.Text = "Error! Incorrect Username or Password";
                    Label1.Visible = true;
                }
                else
                {
                    dt = ds.Tables["employee"];
                    dtp = dsp.Tables["patient"];
                    HttpCookie userCookie = new HttpCookie("User");
                    if (dt.Rows.Count != 0)
                    {
                        switch (dt.Rows[0]["Role"].ToString())
                        {
                            case "Nurse":
                                userCookie.Value = "Nurse:" + dt.Rows[0]["EmployeeName"].ToString() + ":" + TextBox1.Text.ToString();
                                Response.Cookies.Add(userCookie);
                                Response.Redirect("NurseCentral.aspx", true);
                                break;
                            /*case "Patient":
                                userCookie.Value = "Patient:" + dt.Rows[0]["EmployeeName"].ToString();
                                Response.Cookies.Add(userCookie);
                                Response.Redirect("PatientCentral.aspx", true);
                                break;*/
                            case "Doctor":
                                userCookie.Value = "Doctor:" + dt.Rows[0]["EmployeeName"].ToString() + ":" + TextBox1.Text.ToString();
                                Response.Cookies.Add(userCookie);
                                Response.Redirect("DoctorCentral.aspx", true);
                                break;
                            case "IT":
                                userCookie.Value = "IT:" + dt.Rows[0]["EmployeeName"].ToString() + ":" + TextBox1.Text.ToString();
                                Response.Cookies.Add(userCookie);
                                Response.Redirect("ITCentral.aspx", true);
                                break;
                            case "Billing":
                                userCookie.Value = "Billing:" + dt.Rows[0]["EmployeeName"].ToString() + ":" + TextBox1.Text.ToString();
                                Response.Cookies.Add(userCookie);
                                Response.Redirect("BillingCentral.aspx", true);
                                break;
                            case "Legal":
                                userCookie.Value = "Legal:" + dt.Rows[0]["EmployeeName"].ToString() + ":" + TextBox1.Text.ToString();
                                Response.Cookies.Add(userCookie);
                                Response.Redirect("LegalCentral.aspx", true);
                                break;
                        }
                    }

                    else if (dtp.Rows.Count != 0)
                    {
                        userCookie.Value = "Patient:" + dtp.Rows[0]["PatientName"].ToString() + ":" + TextBox1.Text.ToString();
                        Response.Cookies.Add(userCookie);
                        Response.Redirect("PatientCentral.aspx", true);
                    }
                }
            }
            catch (Exception exp)
            {
                Label1.Text = "Error connecting to Database!";
                Label1.Visible = true;
            }

        }
    }
}