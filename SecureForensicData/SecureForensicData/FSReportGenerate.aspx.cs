using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace SecureForensicData
{
    public partial class FSReportGenerate : System.Web.UI.Page
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
            byte[] passBytes = Encoding.UTF8.GetBytes("FR");
            string keyvalue = string.Join("", passBytes);
            objDTO.TableName = ddlPoliceStation.SelectedItem.Value + "_" + ddlCrime.SelectedItem.Value + "_" + keyvalue;
            objDTO.Description = txtDescription.Text;
            objDTO.CrimeId = int.Parse(ddlCrime.SelectedItem.Value);
            objDTO.PoliceStationId = int.Parse(ddlPoliceStation.SelectedItem.Value);
            objDTO.FSId = int.Parse(Session["UserId"].ToString());
            string result = objBLL.CreateTable_FSRG(objDTO);
            if (result == "1")
            {
                ddlCrime.SelectedIndex = 0;
                ddlPoliceStation.SelectedIndex = 0;
                txtDescription.Text = "";
                lblMsg.Text = "Forensic Report Generated Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }

            else if (result == "0")
            {
                // txtName.Text = txtCrimePlace.Text = "";
                lblMsg.Text = "Forensic Report Generate Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}