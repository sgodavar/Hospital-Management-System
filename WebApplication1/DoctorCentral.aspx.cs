using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DoctorCentral : System.Web.UI.Page
    {
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
                if (cookieValues[0] != "Doctor")
                {
                    Response.Redirect("Login.aspx", true);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}