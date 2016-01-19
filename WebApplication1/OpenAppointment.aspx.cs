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

    public class appInfo
    {
        public string time;
        public int id;
        public string patientName;

        public appInfo(string Time, int ID,string name)
        {
            this.id = ID;
            this.time = Time;
            this.patientName = name;
        }
    }

    public partial class OpenAppointment : System.Web.UI.Page
    {
        MySqlConnection connection;
        string[] cookieValues;
        string doctorName;
        int currentRow = 0;
        int rowCount;
        DataTable appData = new DataTable();
        DataSet appds = new DataSet();
        List<appInfo> appIDs = new List<appInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User"];
            if (cookie == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                cookieValues = cookie.Value.Split(':');
                if (cookieValues[0] != "Doctor")
                {
                    Response.Redirect("Login.aspx", true);
                }
                else
                {
                    Session["DoctorName"] = cookieValues[1];
                }
            }
            HyperLink1.NavigateUrl = "DoctorCentral.aspx";

            if (!IsPostBack)
            {
                try
                {
                    connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                    connection.Open();
                    string query_d = "SELECT * FROM employee WHERE EmployeeName='" + cookieValues[1] + "';";
                    doctorName = cookieValues[1];
                    MySqlDataAdapter command = new MySqlDataAdapter(query_d, connection);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    command.Fill(ds, "employee");

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        dt = ds.Tables["employee"];
                        int doctorID = int.Parse(dt.Rows[0]["EmpID"].ToString());

                        //connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                        //connection.Open();

                        string selectPatientCommand = "SELECT PatientName FROM patient WHERE doctor_id = " + doctorID + ";";
                        MySqlDataAdapter command2 = new MySqlDataAdapter(selectPatientCommand, connection);
                        DataSet ds2 = new DataSet();
                        command2.Fill(ds2, "PatientName");

                        DropDownList1.DataSource = ds2;
                        DropDownList1.DataValueField = "PatientName";
                        DropDownList1.DataBind();
                        DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                        DropDownList1.SelectedIndex = 0;
                    }
                    string selectDrugCommand = "SELECT * FROM drug_type;";
                    MySqlDataAdapter command3 = new MySqlDataAdapter(selectDrugCommand, connection);
                    DataSet ds3 = new DataSet();
                    command3.Fill(ds3, "DrugName");

                    DropDownList3.DataSource = ds3;
                    DropDownList3.DataValueField = "DrugName";
                    DropDownList3.DataBind();
                    DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    DropDownList3.SelectedIndex = 0;

                    string selectTreatmentCommand = "SELECT * FROM treatment_type;";
                    MySqlDataAdapter command4 = new MySqlDataAdapter(selectTreatmentCommand, connection);
                    DataSet ds4 = new DataSet();
                    command4.Fill(ds4, "TreatmentName");

                    DropDownList2.DataSource = ds4;
                    DropDownList2.DataValueField = "TreatmentName";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    DropDownList2.SelectedIndex = 0;
                    Session["currentRow"] = currentRow;
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
            
            currentRow = 0;
            bool where = false;
            string query_d = "SELECT * FROM appointment";
            if (Calendar1.SelectedDate.Date != DateTime.MinValue)
            {
                if(where){
                    query_d += " Appdate='" + Calendar1.SelectedDate.Year + "-" +
                    Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day + "'";
                }
                else{
                    query_d += " WHERE Appdate='" + Calendar1.SelectedDate.Year + "-" +
                    Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day + "'";
                    where = true;
                }
            }
            if (DropDownList1.SelectedValue != string.Empty)
            {
                if (where)
                {
                    query_d += " AND PatientName='" + DropDownList1.SelectedValue.ToString() + "'";
                }
                else
                {
                    query_d += " WHERE PatientName='" + DropDownList1.SelectedValue.ToString() + "'";
                    where = true;
                }
            }
            query_d += " AND isEdited IS null;";

            Session["recordQuery"] = query_d;

            updateRecords();

            //string selectCommand = "SELECT AppDate,Diagnosis,DruggID,TreatmenttID FROM appointment WHERE PatientName='" + DropDownList1.SelectedItem.Value.ToString() + "' AND isEdited=0;";
            //SqlDataSource dataSource = new SqlDataSource("MySql.Data.MySqlClient",ConfigurationManager.ConnectionStrings["MySQLDataStr"].ConnectionString, selectCommand);
        }

        public void showUpdateElements()
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;

            TextBox1.Visible = true;

            DropDownList2.Visible = true;
            DropDownList3.Visible = true;

            Button2.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
            Button4.Enabled = false;
        }

        public void hideUpdateElements()
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;

            TextBox1.Visible = false;

            DropDownList2.Visible = false;
            DropDownList3.Visible = false;

            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Button4.Enabled = false;
        }

        public void updateRecords()
        {
            string query = (string)Session["recordQuery"];
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
            connection.Open();
            MySqlDataAdapter command = new MySqlDataAdapter(query, connection);
            int row = (int)Session["currentRow"];
            appds.Clear();
            command.Fill(appds, "appointment");

            if (appds.Tables[0].Rows.Count != 0)
            {
                appIDs.Clear();
                appData = appds.Tables["appointment"];
                rowCount = appData.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    appIDs.Add(new appInfo(appData.Rows[i]["Apptime"].ToString(), int.Parse(appData.Rows[i]["AppID"].ToString()), appData.Rows[i]["PatientName"].ToString()));
                }
                Session["appIDS"] = appIDs;
                Session["rowCount"] = rowCount;
                showUpdateElements();
                Label5.Visible = true;
                Label5.ForeColor = System.Drawing.Color.Black;
                Label5.Text = appData.Rows[row]["Apptime"].ToString();
                Label7.Text = appData.Rows[row]["PatientName"].ToString();
                if (row == (rowCount - 1))
                {
                    Button3.Enabled = false;
                }
            }
            else
            {
                hideUpdateElements();
                Label5.Text = "Unable to locate any unopened Appointment Records";
                Label5.Visible = true;
                Label5.ForeColor = System.Drawing.Color.Red;
            }

            connection.Close();

        }

        public void clearContents()
        {
            TextBox1.Text = string.Empty;
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<appInfo> appids = (List<appInfo>)Session["appIDS"];
            int row = (int)Session["currentRow"];
            if (appids.Count != 0)
            {
                int appid = appids[row].id;
                string query = "UPDATE appointment SET Diagnosis = '" + TextBox1.Text.ToString() + "'";

                if (DropDownList3.SelectedValue != string.Empty)
                {
                    query += ", DruggID=" + "(SELECT DrugID FROM hospitaldb.drug_type WHERE DrugName='" + DropDownList3.SelectedValue.ToString() + "')";
                }

                if (DropDownList2.SelectedValue != string.Empty)
                {

                    query += ",TreatmenttID=" + "(SELECT TreatmentID FROM hospitaldb.treatment_type WHERE TreatmentName='" + DropDownList2.SelectedValue.ToString() + "')";
                }

                query += ", isEdited='" + (string)Session["DoctorName"] + "' WHERE AppID=" + appid + ";";

                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteReader();

                connection.Close();
                clearContents();
                updateRecords();
                row -= 1;
                Session["currentRow"] = row;
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //next appointment
            List<appInfo> appids = (List<appInfo>)Session["appIDS"];
            int row = (int)Session["currentRow"];
            int count = (int)Session["rowCount"];
            row += 1;
            Label5.Text = appids[row].time;
            Label7.Text = appids[row].patientName;
            Button4.Enabled = true;
            if (row == (count - 1))
            {
                Button3.Enabled = false;
            }
            Session["currentRow"] = row;
            clearContents();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //previous appointment
            List<appInfo> appids = (List<appInfo>)Session["appIDS"];
            int row = (int)Session["currentRow"];
            row -= 1;
            Label5.Text = appids[row].time;
            Label7.Text = appids[row].patientName;
            Button3.Enabled = true;
            if (currentRow == 0)
            {
                Button4.Enabled = false;
            }
            Session["currentRow"] = row;
            clearContents();
        }



    }
}