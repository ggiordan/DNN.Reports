﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Visualizer.ascx.vb" Inherits="DotNetNuke.Modules.Reports.Visualizers.Excel.Visualizer" %>
<asp:GridView ID="grdResults" runat="server" Width="100%"
              EnableTheming="True" AutoGenerateColumns="false">
    <HeaderStyle CssClass="Subhead DNN_Reports_Grid_Header" HorizontalAlign="Left" />
    <RowStyle CssClass="Normal DNN_Reports_Grid_Row" HorizontalAlign="Left" />
    <AlternatingRowStyle CssClass="Normal DNN_Reports_Grid_AlternatingRow" />
    <PagerStyle CssClass="Normal DNN_Reports_Grid_Pager" HorizontalAlign="Center" />
    <FooterStyle CssClass="Normal" />
</asp:GridView>
<asp:linkButton ID="cmdExportToExcel" runat="server">
    <asp:Image ID="imgExcelGraphic" runat="server" ImageUrl="images/Excel-icon.png" AlternateText="Excel File" /><span style="text-decoration:none">&nbsp;&nbsp;</span>
    <asp:Label ID="lblExportToExcel" runat="server" resourcekey="lblExportToExcel" Text="Export To Excel"></asp:Label>
</asp:linkButton>
