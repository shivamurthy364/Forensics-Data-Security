<%@ Page Title="" Language="C#" MasterPageFile="~/HO.Master" AutoEventWireup="true" CodeBehind="HOVFSR.aspx.cs" Inherits="SecureForensicData.HOVFSR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Forensics Report</h3>
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
                                    <asp:DropDownList ID="ddlCrime" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCrime_SelectedIndexChanged"></asp:DropDownList>
                                        
                                </div>
                                <br />
                                    <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                                            </asp:Table>
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
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
