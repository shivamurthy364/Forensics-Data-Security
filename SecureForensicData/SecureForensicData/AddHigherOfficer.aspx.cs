using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureForensicData
{
    public partial class AddHigherOfficer : System.Web.UI.Page
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
            Random rnd = new Random();
            objDTO.HOId = (rnd.Next(100000, 999999) + DateTime.Now.Second);
            objDTO.Password = (rnd.Next(1000, 9999) + DateTime.Now.Second).ToString();
            objDTO.Name = txtName.Text;
            objDTO.Role = ddlRole.SelectedItem.Text;
            objDTO.MobileNo = txtMobileNo.Text;
            objDTO.EmailId = txtEmailId.Text;
            objDTO.Address = txtAddress.Text;
            string result = objBLL.CreateHigherOfficer(objDTO);
            if (result == "1")
            {
                ddlRole.SelectedIndex = 0;
                string Message = "Login Credentials Higher Officer Id:" + objDTO.HOId + " & Password:" + objDTO.Password;
                SendEmail.Send(txtEmailId.Text, Message);
                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Higher Officer Created Successfully  & Credentials Mailed";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                ddlRole.SelectedIndex = 0;
                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Higher Officer Creation Already,Selected Role";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (result == "0")
            {
                ddlRole.SelectedIndex = 0;
                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Higher Officer Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}