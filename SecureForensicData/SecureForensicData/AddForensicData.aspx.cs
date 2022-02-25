using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SecureForensicData
{
    public partial class AddForensicData : System.Web.UI.Page
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
                tab = objBLL.GetPoliceStation();
                ddlPoliceStation.DataSource = tab;
                ddlPoliceStation.DataTextField = "Name";
                ddlPoliceStation.DataValueField = "PoliceStationId";
                ddlPoliceStation.DataBind();
                ddlPoliceStation.Items.Insert(0, "--Select--");
            }
        }

        protected void ddlPoliceStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objBLL = new BLL.SFDBLL();
                objDTO = new DTO.SFDDTO();
                objDTO.PoliceStationId = int.Parse(ddlPoliceStation.SelectedItem.Value);
                DataTable tab = new DataTable();
                tab = objBLL.GetCrime(objDTO);
                ddlCrime.DataSource = tab;
                ddlCrime.DataTextField = "CrimeName";
                ddlCrime.DataValueField = "CrimeId";
                ddlCrime.DataBind();
                ddlCrime.Items.Insert(0, "--Select--");
            }
            catch
            {
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objBLL = new BLL.SFDBLL();
            objDTO = new DTO.SFDDTO();
            objDTO.FSId = int.Parse(Session["UserId"].ToString());
            objDTO.CrimeId = int.Parse(ddlCrime.SelectedItem.Value);
            objDTO.Description = txtDescription.Text;
            string result = objBLL.AddForensicDC(objDTO);
            if (result == "1")
            {
                ddlPoliceStation.SelectedIndex = 0;
                ddlCrime.SelectedIndex = 0;
                txtDescription.Text = "";
                lblMsg.Text = "Crime Forensics Data Collected Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }

            else if (result == "0")
            {
                ddlPoliceStation.SelectedIndex = 0;
                ddlCrime.SelectedIndex = 0;
                txtDescription.Text = "";
                lblMsg.Text = "Crime Forensics Data Collect Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}