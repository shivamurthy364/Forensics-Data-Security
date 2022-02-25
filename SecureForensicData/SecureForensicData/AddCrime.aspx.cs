using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureForensicData
{
    public partial class AddCrime : System.Web.UI.Page
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
            objDTO.PoliceStationId = int.Parse(Session["UserId"].ToString());
            objDTO.CrimeName = txtName.Text;
            objDTO.CrimePlace = txtCrimePlace.Text;
            objDTO.Description = txtDescription.Text;
            string result = objBLL.AddCrime(objDTO);
            if (result == "1")
            {

                txtName.Text = txtCrimePlace.Text = txtDescription.Text = "";
                lblMsg.Text = "Police Station Crime Case Registered Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }

            else if (result == "0")
            {
                txtName.Text = txtCrimePlace.Text = txtDescription.Text = "";
                lblMsg.Text = "Police Station Crime Case Registration Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}