using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureForensicData
{
    public partial class Login : System.Web.UI.Page
    {
        SecureForensicData.BLL.SFDBLL objBLL = null;
        SecureForensicData.DTO.SFDDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            objBLL = new BLL.SFDBLL();
            objDTO = new DTO.SFDDTO();

            objDTO.Id = txtUserId.Text;
            objDTO.Password = txtPassword.Text;
            objDTO.UserType = ddlUserType.SelectedItem.Text;
            int result = objBLL.LoginVerify(objDTO);
            if (result == 1)
            {
                Session["UserId"] = txtUserId.Text;
                Session["Password"] = txtPassword.Text;
                Session["UserType"] = ddlUserType.SelectedItem.Text;
                switch (ddlUserType.SelectedItem.Text)
                {
                    case "ApplicationManager":
                        Response.Redirect("AMHome.aspx");
                        break;
                    case "Police":
                        Response.Redirect("PoliceStationHome.aspx");
                        break;
                    case "HigherOfficer":
                        Response.Redirect("HOHome.aspx");
                        break;
                    case "ForensicStaff":
                        Response.Redirect("ForensicHome.aspx");
                        break;
                    case "Doctor":
                        Response.Redirect("DoctorHome.aspx");
                        break;
                }

            }
            else
            {
                lblMsg.Text = "Invalid User Id/Password";
                lblMsg.ForeColor = System.Drawing.Color.White;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx"); 
        }
    }
}