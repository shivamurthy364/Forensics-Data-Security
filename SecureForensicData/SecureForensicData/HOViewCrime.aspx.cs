using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SecureForensicData
{
    public partial class HOViewCrime : System.Web.UI.Page
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
            LoadData();
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

        protected void ddlCrime_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch
            {
            }
        }
        private void LoadData()
        {
            try
            {
                objBLL = new BLL.SFDBLL();
                objDTO = new DTO.SFDDTO();
                objDTO.CrimeId = int.Parse(ddlCrime.SelectedItem.Value);
                DataTable tab = new DataTable();
                objDTO.TableName = ddlPoliceStation.SelectedItem.Value + "_" + ddlCrime.SelectedItem.Value;
                tab = objBLL.GetFSReport(objDTO);
                Table1.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();
                    TableHeaderCell hc5 = new TableHeaderCell();

                    hc1.Text = "Sl No";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Log Date";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Status";
                    hr.Cells.Add(hc3);
                    hc4.Text = "";
                    hr.Cells.Add(hc4);
                    hc5.Text = "";
                    hr.Cells.Add(hc5);

                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblSlNo = new Label();
                        lblSlNo.Text = (i + 1).ToString();
                        TableCell SlNo = new TableCell();
                        SlNo.Controls.Add(lblSlNo);


                        Label lbllogDate = new Label();
                        lbllogDate.Text = tab.Rows[i]["LogDate"].ToString();
                        TableCell logDate = new TableCell();
                        logDate.Controls.Add(lbllogDate);

                        LinkButton View = new LinkButton();
                        View.Text = "View Report";
                        View.ID = "lnkView" + i.ToString();
                        View.CommandArgument = tab.Rows[i]["SlNo"].ToString();
                        View.Click += new EventHandler(View_Click);

                        TableCell ViewCell = new TableCell();
                        ViewCell.Controls.Add(View);

                        LinkButton Recover = new LinkButton();
                        Recover.Text = "Report Recover";
                        Recover.ID = "lnkRecover" + i.ToString();
                        Recover.CommandArgument = tab.Rows[i]["SlNo"].ToString();
                        Recover.Click += new EventHandler(Recover_Click);

                        TableCell RecoverCell = new TableCell();
                        RecoverCell.Controls.Add(Recover);

                        objDTO.SlNo = int.Parse(tab.Rows[i]["SlNo"].ToString());
                        string res = objBLL.ChkCCaseTamper(objDTO);
                        string imgpath = "";

                        if (res == "1")
                        {
                            imgpath = "~/images/Correct.jpg";
                            Recover.Enabled = false;
                        }
                        else
                        {
                            lbllogDate.ForeColor = System.Drawing.Color.Red;
                            imgpath = "~/images/Tamper.jpg";
                            View.Enabled = false;
                        }
                        Image img = new Image();
                        img.ImageUrl = imgpath;
                        TableCell imgcell = new TableCell();
                        imgcell.Controls.Add(img);


                        row.Controls.Add(SlNo);
                        row.Controls.Add(logDate);
                        row.Controls.Add(imgcell);
                        row.Controls.Add(ViewCell);
                        row.Controls.Add(RecoverCell);
                        Table1.Controls.Add(row);

                    }
                }
                else
                {
                    //lblMsg.Text = "No Record Found";
                }
            }
            catch
            {

            }
        }

        void Recover_Click(object sender, EventArgs e)
        {
            objBLL = new BLL.SFDBLL();
            objDTO = new DTO.SFDDTO();
            DataTable tab = new DataTable();
            objDTO.TableName = ddlPoliceStation.SelectedItem.Value + "_" + ddlCrime.SelectedItem.Value;
            LinkButton lnk = (LinkButton)sender;
            objDTO.SlNo = int.Parse(lnk.CommandArgument);
            string result = objBLL.CCaseRecover(objDTO);
            if (result == "1")
            {
                LoadData();
                lblMsg.Text = "Recover Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }

        void View_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Random rnd = new Random();
            objBLL = new BLL.SFDBLL();
            objDTO = new DTO.SFDDTO();
            objDTO.SlNo = int.Parse(lnk.CommandArgument);
            Session["SlNo"] = objDTO.SlNo;
            objDTO.AccessKey = rnd.Next(1000, 9999);
            Session["AccessKey"] = objDTO.AccessKey;
            objDTO.PoliceStationId = int.Parse(ddlPoliceStation.SelectedItem.Value);
            objDTO.TableName = objDTO.PoliceStationId + "_" + ddlCrime.SelectedItem.Value;
            Session["TableName"] = objDTO.TableName;
            objDTO.Id = Session["UserId"].ToString();
            objDTO.CrimeId = int.Parse(ddlCrime.SelectedItem.Value);
            objDTO.UserType = "HO";
            string result = objBLL.FSRequest(objDTO);
            if (result.Split('&')[0] == "1")
            {
                string Message = "Access Key:" + objDTO.AccessKey;
                SendEmail.Send(result.Split('&')[1], Message);
                Response.Redirect("HOViewCaseSummary.aspx");
            }
        }
    }
}