using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


namespace WebApplication1
{
    public partial class ViewAppointment : System.Web.UI.Page
    {
        HttpCookie cookie;
        List<String> roles = new List<string>();
        string cookieValue1;
        string cookieValue2;
        string cookieValue3;
        string[] cookieValues;
        string[] PatientName;
        string pat_q;
        string pat_q1;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            GridView1.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;

            HttpCookie cookie = Request.Cookies["User"];
            
            if (cookie == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                
                cookieValue1 = cookie.Value.Substring(0, cookie.Value.IndexOf(':'));
                //Response.Write(cookieValue1);
                cookieValue2 = cookie.Value.Substring(cookie.Value.IndexOf(':') + 1, cookie.Value.Length - cookie.Value.IndexOf(':') - 1);
                //Response.Write(cookieValue2);
                cookieValue3 = cookieValue2.Substring(0, cookie.Value.IndexOf(':'));
                
                cookieValues = cookie.Value.Split(':');
                switch (cookieValues[0])
                {
                    case "IT":
                        HyperLink1.NavigateUrl = "ITCentral.aspx";
                        break;
                    case "Nurse":
                        HyperLink1.NavigateUrl = "NurseCentral.aspx";
                        break;
                    case "Doctor":
                        HyperLink1.NavigateUrl = "DoctorCentral.aspx";
                        break;
                    case "Billing":
                        HyperLink1.NavigateUrl = "BillingCentral.aspx";
                        break;
                    case "Legal":
                        HyperLink1.NavigateUrl = "LegalCentral.aspx";
                        break;
                    case "Patient":
                        HyperLink1.NavigateUrl = "PatientCentral.aspx";
                        break;
                    default:
                        HyperLink1.NavigateUrl = "Login.aspx";
                        break;
                }
                
                
                
                    if (!IsPostBack)
                    {
                        Calendar3.Visible = false;
                        Calendar4.Visible = false;
                       
                        switch (cookieValues[0])
                        {

                            case "Nurse":

                                pat_q = "SELECT PatientID, CONCAT(PatientName,'-',Username) AS PatientName FROM PATIENT WHERE doctor_id = (SELECT doctor_id FROM doctor_nurse WHERE nurse_id = (SELECT EmpID FROM EMPLOYEE WHERE EmployeeName = '" + cookieValues[1] + "'));";
                                //pat_q1 = "SELECT Username FROM PATIENT WHERE doctor_id = (SELECT doctor_id FROM doctor_nurse WHERE nurse_id = (SELECT EmpID FROM EMPLOYEE WHERE EmployeeName = '" + cookieValues[1] + "'));";
                                break;
                            case "Patient":

                                pat_q = "SELECT PatientID, CONCAT(PatientName,'-',Username) AS PatientName FROM patient WHERE Username='" + cookieValues[2] + "';";
                                break;
                            case "Doctor":

                                pat_q = "SELECT PatientID, CONCAT(PatientName,'-',Username) AS PatientName FROM patient WHERE doctor_id=(SELECT EmpID FROM employee WHERE Username='" + cookieValues[2] + "');";
                                break;
                            default:

                                pat_q = "SELECT PatientID, CONCAT(PatientName,'-',Username) AS PatientName FROM patient;";
                                break;
                        }

                        string CS = ConfigurationManager.ConnectionStrings["MySQLConnstr"].ConnectionString;
                        using (MySqlConnection conn = new MySqlConnection(CS))
                        {
                            MySqlCommand cmd = new MySqlCommand(pat_q, conn);
                            conn.Open();
                            DropDownList1.DataSource = cmd.ExecuteReader();

                            DropDownList1.DataTextField = "PatientName";
                            DropDownList1.DataValueField = "PatientID";
                            DropDownList1.DataBind();

                        }
                    }
               
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar3.Visible)
            {
                Calendar3.Visible = false;

            }
            else
            {
                Calendar3.Visible = true;
            }


        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar4.Visible)
            {
                Calendar4.Visible = false;

            }
            else
            {
                Calendar4.Visible = true;
            }
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar3.SelectedDate.Year + "-" + Calendar3.SelectedDate.Month + "-" + Calendar3.SelectedDate.Day;
           


            Calendar3.Visible = false;

        }

        protected void Calendar4_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar4.SelectedDate.Year + "-" + Calendar4.SelectedDate.Month + "-" + Calendar4.SelectedDate.Day;

            Calendar4.Visible = false;
          


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool correct = true;
            resetForm(false);
            if (TextBox1.Text.ToString() == string.Empty)
            {
                Label2.Visible = true;
                Label3.Visible = false;
            }
            if (TextBox2.Text.ToString() == string.Empty)
            {
                Label2.Visible = false;
                Label3.Visible = true;
            }
            if (TextBox1.Text.ToString() == string.Empty && TextBox2.Text.ToString() == string.Empty)
            {
                Label2.Visible = true;
                Label3.Visible = true;

            }

            if (TextBox1.Text.ToString() != string.Empty && TextBox2.Text.ToString() != string.Empty)
            {
               // try
                //{
                    string CSS = ConfigurationManager.ConnectionStrings["MySQLConnstr"].ConnectionString;
                    MySqlConnection conn = new MySqlConnection(CSS);
                    PatientName = DropDownList1.SelectedItem.Text.Split('-');
                    if (cookieValue1 == "Doctor")
                    {

                        
                            string query = "SELECT A.PatientName, CONCAT('Dr. ',A.DoctorName) as FullName, A.NurseName, A.Appdate, T.TreatmentName, D.DrugName, A.Diagnosis FROM APPOINTMENT AS A INNER JOIN DRUG_TYPE AS D ON A.DruggID=D.DrugID INNER JOIN TREATMENT_TYPE AS T ON A.TreatmenttID=T.TreatmentID INNER JOIN PATIENT AS P ON A.patient_id=P.PatientID WHERE A.Appdate BETWEEN '" + TextBox1.Text + "' AND '" + TextBox2.Text + "' AND A.PatientName= '" + PatientName[0] + "';";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            MySqlDataReader rdr = cmd.ExecuteReader();
                            //string patient = (string)rdr["PatientName"];
                            if (rdr.Read() == false)
                            {
                                Label7.Visible = true;
                            }
                                
                            GridView1.DataSource = rdr;
                            GridView1.DataBind();
                            GridView1.Visible = true;
                            
                            conn.Close();
                            resetForm(true);

                        
                       
                    }
               // }
                //catch (Exception exp)
                //{
                //    Console.WriteLine(exp.Message.ToString());
                //}
            }
            if (cookieValues[0] == "Billing")
            {
                //try
                //{
                string CSS = ConfigurationManager.ConnectionStrings["MySQLConnstr"].ConnectionString;
                MySqlConnection conn = new MySqlConnection(CSS);
                string query1 = "SELECT A.PatientName, CONCAT('Dr. ',A.DoctorName) as FullName, T.TreatmentName, T.TreatmentCost FROM APPOINTMENT AS A INNER JOIN DRUG_TYPE AS D ON A.DruggID=D.DrugID INNER JOIN TREATMENT_TYPE AS T ON A.TreatmenttID=T.TreatmentID WHERE A.Appdate BETWEEN '" + TextBox1.Text + "' AND '" + TextBox2.Text + "' AND PatientName= '" + PatientName[0] + "';";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                conn.Open();
                MySqlDataReader rdr1 = cmd1.ExecuteReader();
                if (rdr1.Read() == false)
                {
                    Label7.Visible = true;
                }
                GridView1.DataSource = rdr1;
                GridView1.DataBind();
                GridView1.Visible = true;
                conn.Close();
                string query7 = "SELECT SUM(T.TreatmentCost) AS TOTAL FROM APPOINTMENT AS A INNER JOIN TREATMENT_TYPE AS T ON A.TreatmenttID=T.TreatmentID WHERE A.Appdate BETWEEN '" + TextBox1.Text + "' AND '" + TextBox2.Text + "' AND PatientName= '" + PatientName[0] + "';";
                MySqlCommand cmd7 = new MySqlCommand(query7, conn);
                conn.Open();
                int rdr3 = Convert.ToInt32(cmd7.ExecuteScalar());
                string total = "Total Treatment Cost: " + rdr3.ToString();
                Label6.Text = total;
                Label6.Visible = true;
                conn.Close();
                resetForm(true);
                // }
                //catch (Exception exp)
                //{
                //    Console.WriteLine(exp.Message.ToString());
                //}

            }

            if (cookieValues[0] == "Legal")
            {
                try
                {
                    string CSS = ConfigurationManager.ConnectionStrings["MySQLConnstr"].ConnectionString;
                    MySqlConnection conn = new MySqlConnection(CSS);
                    string query2 = "SELECT A.PatientName AS Patient, CONCAT('Dr. ',A.DoctorName) as Doctor, A.Appdate, T.TreatmentName, D.DrugName, A.Diagnosis FROM APPOINTMENT AS A INNER JOIN DRUG_TYPE AS D ON A.DruggID=D.DrugID INNER JOIN TREATMENT_TYPE AS T ON A.TreatmenttID=T.TreatmentID WHERE PatientName= '" + PatientName[0] + "';";
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                    conn.Open();
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    if (rdr2.Read() == false)
                    {
                        Label7.Visible = true;
                    }
                    GridView1.DataSource = rdr2;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    conn.Close();
                    resetForm(true);
                }

                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message.ToString());
                }

            }

            if (cookieValues[0] == "Nurse")
            {
                try
                {
                    string CSS = ConfigurationManager.ConnectionStrings["MySQLConnstr"].ConnectionString;
                    MySqlConnection conn = new MySqlConnection(CSS);
                    string query3 = "SELECT doctor_id FROM PATIENT WHERE PatientName = '" + PatientName[0] + "';";
                    string query4 = "SELECT doctor_id FROM doctor_nurse WHERE nurse_id = (SELECT EmpID from EMPLOYEE WHERE EmployeeName = '" + cookieValues[1] + "')";
                    MySqlCommand cmd3 = new MySqlCommand(query3, conn);
                    MySqlCommand cmd4 = new MySqlCommand(query4, conn);
                    conn.Open();
                    int rdr1 = Convert.ToInt32(cmd3.ExecuteScalar());
                    int rdr2 = Convert.ToInt32(cmd4.ExecuteScalar());
                    conn.Close();
                    if (rdr1 == rdr2)
                    {
                        string query5 = "SELECT A.PatientName, CONCAT('Dr. ',A.DoctorName) as FullName, A.Appdate, T.TreatmentName, D.DrugName, A.Diagnosis FROM APPOINTMENT AS A INNER JOIN DRUG_TYPE AS D ON A.DruggID=D.DrugID INNER JOIN TREATMENT_TYPE AS T ON A.TreatmenttID=T.TreatmentID WHERE PatientName= '" + PatientName[0] + "';";
                        MySqlCommand cmd5 = new MySqlCommand(query5, conn);
                        conn.Open();
                        MySqlDataReader rdr3 = cmd5.ExecuteReader();
                        if (rdr3.Read() == false)
                        {
                            Label7.Visible = true;
                        }
                        GridView1.DataSource = rdr3;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        conn.Close();
                        resetForm(true);

                    }
                    else
                    {
                        Label4.Visible = true;
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message.ToString());
                }



            }
            if (cookieValues[0] == "Patient")
            {
                if (DropDownList1.SelectedItem.Text == cookieValues[1])
                {
                    
                    //try
                    //{
                    string CSS = ConfigurationManager.ConnectionStrings["MySQLConnstr"].ConnectionString;
                    MySqlConnection conn = new MySqlConnection(CSS);
                    string query1 = "SELECT A.PatientName, CONCAT('Dr. ',A.Doctorname) as FullName, A.Appdate, T.TreatmentName, T.TreatmentCost, D.DrugID, D.DrugName FROM APPOINTMENT AS A INNER JOIN DRUG_TYPE AS D ON A.DruggID=D.DrugID INNER JOIN TREATMENT_TYPE AS T ON A.TreatmenttID=T.TreatmentID WHERE A.Appdate BETWEEN '" + TextBox1.Text + "' AND '" + TextBox2.Text + "' AND PatientName= '" + cookieValues[1] + "';";
                    MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                    conn.Open();
                    MySqlDataReader rdr11 = cmd1.ExecuteReader();
                    if (rdr11.Read() == false)
                    {
                        Label7.Visible = true;
                    }
                    GridView1.DataSource = rdr11;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    conn.Close();
                    resetForm(true);
                    // }
                    //catch (Exception exp)
                    //{
                    //    Console.WriteLine(exp.Message.ToString());
                    //}
                }
                else 
                {
                    Label4.Visible = true;
                }

            }
            if (cookieValues[0] == "IT")
            {
                
                    string CSS = ConfigurationManager.ConnectionStrings["MySQLConnstr"].ConnectionString;
                    MySqlConnection conn = new MySqlConnection(CSS);
                    string query1 = "SELECT A.PatientName, CONCAT('Dr. ',A.DoctorName) as FullName, A.Appdate, T.TreatmentName, T.TreatmentCost, D.DrugName FROM APPOINTMENT AS A INNER JOIN DRUG_TYPE AS D ON A.DruggID=D.DrugID INNER JOIN TREATMENT_TYPE AS T ON A.TreatmenttID=T.TreatmentID WHERE A.Appdate BETWEEN '" + TextBox1.Text + "' AND '" + TextBox2.Text + "' AND PatientName= '" + PatientName[0] + "';";
                    MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                    conn.Open();
                    MySqlDataReader rdr12 = cmd1.ExecuteReader();
                    if (rdr12.Read() == false)
                    {
                        Label7.Visible = true;
                    }
                    GridView1.DataSource = rdr12;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    conn.Close();
                    resetForm(true);
                    // }
                    //catch (Exception exp)
                    //{
                    //    Console.WriteLine(exp.Message.ToString());
                    //}
               
            }
        }
            

        
        public void resetForm(bool full)
        {

            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            if (full)
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
            }
        }
    }
}