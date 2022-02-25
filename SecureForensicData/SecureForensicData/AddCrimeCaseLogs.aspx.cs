using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SecureForensicData
{
    public partial class AddCrimeCaseLogs : System.Web.UI.Page
    {
        SecureForensicData.BLL.SFDBLL objBLL = null;
        SecureForensicData.DTO.SFDDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBLL = new BLL.SFDBLL();
                objDTO = new DTO.SFDDTO();
                objDTO.PoliceStationId = int.Parse(Session["UserId"].ToString());
                DataTable tab = new DataTable();
                tab = objBLL.GetCrime(objDTO);
                ddlCrime.DataSource = tab;
                ddlCrime.DataTextField = "CrimeName";
                ddlCrime.DataValueField = "CrimeId";
                ddlCrime.DataBind();
                ddlCrime.Items.Insert(0, "--Select--");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objBLL = new BLL.SFDBLL();
            objDTO = new DTO.SFDDTO();
            objDTO.TableName = Session["UserId"].ToString() + "_" + ddlCrime.SelectedItem.Value;
            objDTO.CaseSummary = txtCaseSummary.Text;
            objDTO.CrimeId = int.Parse(ddlCrime.SelectedItem.Value);
            string result = objBLL.CreateTable_CSL(objDTO);
            if (result == "1")
            {

                ddlCrime.SelectedIndex = 0;
                txtCaseSummary.Text = "";
                lblMsg.Text = "Crime Log Table Created Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }

            else if (result == "0")
            {
                // txtName.Text = txtCrimePlace.Text = "";
                lblMsg.Text = "Crime Table Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}