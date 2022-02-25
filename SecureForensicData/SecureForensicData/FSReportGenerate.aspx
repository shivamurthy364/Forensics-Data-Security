<%@ Page Title="" Language="C#" MasterPageFile="~/Forensic.Master" AutoEventWireup="true" CodeBehind="FSReportGenerate.aspx.cs" Inherits="SecureForensicData.FSReportGenerate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Forensic Report Generate</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form id="Form1" role="form" runat="server">
                               
                               <div class="form-group">
                                     <label>
                                         Select Police Station Name</label>
                                    <asp:DropDownList ID="ddlPoliceStation" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPoliceStation_SelectedIndexChanged"></asp:DropDownList>
                                        
                                </div>
                                <div class="form-group">
                                     <label>
                                         Select Crime</label>
                                    <asp:DropDownList ID="ddlCrime" runat="server" class="form-control"></asp:DropDownList>
                                        
                                </div>
                               <div class="form-group">
                                   <label>
                                            Enter Report Details</label>
                                        <asp:TextBox ID="txtDescription" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Report Details" ForeColor="Red" ValidationGroup="A" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                                        
                                </div>
                                 
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                <div class="pull-right">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="A"
                                            class="btn btn-primary btn-sm pull-right" style="padding:10px 20px;" 
                                            onclick="btnSave_Click" />
                                </div>
                                </form>
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
