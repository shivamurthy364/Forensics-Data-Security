using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureForensicData
{
    public partial class AddArea : System.Web.UI.Page
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
            objDTO.AreaName = txtAreaName.Text;
            string result = objBLL.CreateArea(objDTO);
            if (result == "1")
            {
                txtAreaName.Text = "";
                lblMsg.Text = "Area Created Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                txtAreaName.Text = "";
                lblMsg.Text = "Area Created Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (result == "0")
            {
                txtAreaName.Text = "";
                lblMsg.Text = "Area Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}