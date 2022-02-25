<%@ Page Title="" Language="C#" MasterPageFile="~/ApplicationManager.Master" AutoEventWireup="true" CodeBehind="AddPoliceStation.aspx.cs" Inherits="SecureForensicData.AddPoliceStation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Police Station Information</h3>
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
                                            Select Area Name</label>
                                        <asp:DropDownList ID="ddlAreaName" runat="server" class="form-control">
                                        </asp:DropDownList>
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Area Name" InitialValue="--Select--" ForeColor="Red" ValidationGroup="A" ControlToValidate="ddlAreaName"></asp:RequiredFieldValidator>
                                </div>
                               
                                <div class="form-group">
                                     <label>
                                         Enter Police Station Name</label>
                                        <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter Name" ForeColor="Red" ValidationGroup="A" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                </div>
                                 <div class="form-group">
                                   <label>
                                            Enter Mobile No</label>
                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter MobileNo" ForeColor="Red" ValidationGroup="A" ControlToValidate="txtMobileNo"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                             ErrorMessage="Only 10 Digits" ValidationGroup="A" ForeColor="Red" ControlToValidate="txtMobileNo" 
                                             ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                   <label>
                                            Enter Email Id</label>
                                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Email Id" ForeColor="Red" ValidationGroup="A" ControlToValidate="txtEmailId"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmailId"
                                            ErrorMessage="Invalid Email Id" ValidationGroup="A" ForeColor="Red" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                   <label>
                                            Enter Address</label>
                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Address" ForeColor="Red" ValidationGroup="A" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
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
