using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SecureForensicData
{
    public partial class AddPoliceStation : System.Web.UI.Page
    {
        SecureForensicData.BLL.SFDBLL objBLL = null;
        SecureForensicData.DTO.SFDDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBLL = new BLL.SFDBLL();
                objDTO = new DTO.SFDDTO();
                DataTable tab = new DataTable();
                tab = objBLL.GetArea();
                ddlAreaName.DataSource = tab;
                ddlAreaName.DataTextField = "AreaName";
                ddlAreaName.DataValueField = "AreaId";
                ddlAreaName.DataBind();
                ddlAreaName.Items.Insert(0, "--Select--");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objBLL = new BLL.SFDBLL();
            objDTO = new DTO.SFDDTO();

            objDTO.AreaId = int.Parse(ddlAreaName.SelectedItem.Value);
            Random rnd = new Random();
            objDTO.PoliceStationId = (rnd.Next(100000, 999999) + DateTime.Now.Second);
            objDTO.Password = (rnd.Next(1000, 9999) + DateTime.Now.Second).ToString();
            objDTO.Name = txtName.Text;
            objDTO.MobileNo = txtMobileNo.Text;
            objDTO.EmailId = txtEmailId.Text;
            objDTO.Address = txtAddress.Text;
            string result = objBLL.CreatePoliceStation(objDTO);
            if (result == "1")
            {
                ddlAreaName.SelectedIndex = 0;
                string Message = "Login Credentials Police Station Id:" + objDTO.PoliceStationId + " & Password:" + objDTO.Password;
                SendEmail.Send(txtEmailId.Text, Message);
                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Police Station Created Successfully & Credentials Mailed";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                ddlAreaName.SelectedIndex = 0;
                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Police Station Creation Already,Selected Area";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (result == "0")
            {
                ddlAreaName.SelectedIndex = 0;
                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "Police Station Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}