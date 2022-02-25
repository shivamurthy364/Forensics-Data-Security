using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureForensicData
{
    public partial class AMHome : System.Web.UI.Page
    {
        SecureForensicData.BLL.SFDBLL objBLL = null;
        SecureForensicData.DTO.SFDDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objBLL = new BLL.SFDBLL();
            objDTO = new DTO.SFDDTO();
            if (txtOldPassword.Text == Session["Password"].ToString())
            {

                objDTO.Id = Session["UserId"].ToString();
                objDTO.Password = txtNewPassword.Text;
                objDTO.UserType = Session["UserType"].ToString();
                int Result = objBLL.ChangePassword(objDTO);
                if (Result == 1)
                {
                    Session["Password"] = txtNewPassword.Text;
                    txtNewPassword.Text = txtConfirmPassword.Text = txtOldPassword.Text = "";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Password Reset Successfully";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Password Reset Error";
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Invalid Old Password";
            }
        }
    }
}