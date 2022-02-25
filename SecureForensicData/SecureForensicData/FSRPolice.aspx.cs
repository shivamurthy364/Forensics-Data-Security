using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureForensicData
{
    public partial class FSRPolice : System.Web.UI.Page
    {
        SecureForensicData.BLL.SFDBLL objBLL = null;
        SecureForensicData.DTO.SFDDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel1.Visible = false;
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            objBLL = new BLL.SFDBLL();
            objDTO = new DTO.SFDDTO();
            if (txtAccessKey.Text == Session["AccessKey"].ToString())
            {
                lblMsg.Text = "";
                Panel1.Visible = true;
                objDTO.SlNo = int.Parse(Session["SlNo"].ToString());
                objDTO.TableName = Session["TableName"].ToString();
                string result = objBLL.GetFSReportData(objDTO);
                if (result.Split('$')[0] == "1")
                {
                    lblMsg.Text = "";
                    txtFSReport.Text = result.Split('$')[1];
                }
                else if (result.Split('$')[0] == "0")
                {
                    lblMsg.Text = "Invalid Crime Details";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "Invalid Access Key";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}