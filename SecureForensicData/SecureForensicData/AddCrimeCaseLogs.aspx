<%@ Page Title="" Language="C#" MasterPageFile="~/Police.Master" AutoEventWireup="true" CodeBehind="AddCrimeCaseLogs.aspx.cs" Inherits="SecureForensicData.AddCrimeCaseLogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Crime Case Log Information</h3>
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
                                         Select Crime Name</label>
                                    <asp:DropDownList ID="ddlCrime" runat="server" class="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select Crime" ForeColor="Red" ValidationGroup="A" ControlToValidate="ddlCrime" InitialValue="--Select--"></asp:RequiredFieldValidator>
                                </div>
                                 <div class="form-group">
                                   <label>
                                            Enter Crime Case Summary</label>
                                        <asp:TextBox ID="txtCaseSummary" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Crime Case Summary" ForeColor="Red" ValidationGroup="A" ControlToValidate="txtCaseSummary"></asp:RequiredFieldValidator>
                                        
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
