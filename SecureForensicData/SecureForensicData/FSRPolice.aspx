﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Police.Master" AutoEventWireup="true" CodeBehind="FSRPolice.aspx.cs" Inherits="SecureForensicData.FSRPolice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
           Forensic Report</h3>
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
                                         Enter Access key</label>
                                        <asp:TextBox ID="txtAccessKey" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Access key" ForeColor="Red" ValidationGroup="B" ControlToValidate="txtAccessKey"></asp:RequiredFieldValidator>
                                </div>
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                     <div class="pull-right">
                                    <asp:Button ID="btn" runat="server" Text="Verify" ValidationGroup="B"
                                            class="btn btn-primary btn-sm pull-right" style="padding:10px 20px;" OnClick="btn_Click" />
                                </div>
                                    <br /> <br />
                                    <asp:Panel ID="Panel1" runat="server">
                                    <div class="form-group">
                                     <label>
                                            Forensic Report</label>
                                        <asp:TextBox ID="txtFSReport" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                     </div>
                                        </asp:Panel>
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
