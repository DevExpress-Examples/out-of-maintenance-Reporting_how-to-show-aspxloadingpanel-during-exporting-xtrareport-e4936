<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E4936.Default" %>

<%@ Register Assembly="DevExpress.XtraReports.v13.1.Web, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function btSave_Click(s, e) {
            loadingPanel.Show();
            callbackExport.PerformCallback(comboBoxExportFormat.GetValue());
        }

        function callbackExport_EndCallback(s, e) {
            loadingPanel.Hide();
            btSaveToResponse.DoClick();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr style="background-color: #F0F0F0; border-collapse: collapse">
                <td>
                    <dx:ReportToolbar ID="ReportToolbarOrders" runat='server' ShowDefaultButtons='False'
                        ReportViewerID="ReportViewerOrders" Width="100%">
                        <Items>
                            <dx:ReportToolbarButton ItemKind='Search' />
                            <dx:ReportToolbarSeparator />
                            <dx:ReportToolbarButton ItemKind='PrintReport' />
                            <dx:ReportToolbarButton ItemKind='PrintPage' />
                            <dx:ReportToolbarSeparator />
                            <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
                            <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
                            <dx:ReportToolbarLabel ItemKind='PageLabel' />
                            <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'>
                            </dx:ReportToolbarComboBox>
                            <dx:ReportToolbarLabel ItemKind='OfLabel' />
                            <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
                            <dx:ReportToolbarButton ItemKind='NextPage' />
                            <dx:ReportToolbarButton ItemKind='LastPage' />
                            <dx:ReportToolbarSeparator />
                        </Items>
                        <Border BorderStyle="None" />
                    </dx:ReportToolbar>
                </td>
                <td>
                    <dx:ASPxButton ID="btSave" runat="server" Text="Save" AutoPostBack="false">
                        <ClientSideEvents Click="btSave_Click" />
                    </dx:ASPxButton>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cbExportFormat" runat="server" ClientInstanceName="comboBoxExportFormat"
                        ValueType="System.String" Width="70px" SelectedIndex="0">
                        <Items>
                            <dx:ListEditItem Value='pdf' />
                            <dx:ListEditItem Value='xls' />
                            <dx:ListEditItem Value='xlsx' />
                            <dx:ListEditItem Value='rtf' />
                            <dx:ListEditItem Value='mht' />
                            <dx:ListEditItem Value='html' />
                            <dx:ListEditItem Value='txt' />
                            <dx:ListEditItem Value='csv' />
                            <dx:ListEditItem Value='png' />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <dx:ReportViewer ID="ReportViewerOrders" runat="server" Report="<%# new E4936.Reports.OrdersReport() %>"
                        ReportName="E4936.Reports.OrdersReport">
                    </dx:ReportViewer>
                </td>
            </tr>
        </table>
        <dx:ASPxLoadingPanel ID="lpExporting" runat="server" ClientInstanceName="loadingPanel"
            HorizontalAlign="Center" Modal="True" VerticalAlign="Middle" Text="Exporting&amp;hellip;">
        </dx:ASPxLoadingPanel>
        <dx:ASPxCallback ID="cbExport" runat="server" ClientInstanceName="callbackExport"
            OnCallback="cbExport_Callback">
            <ClientSideEvents EndCallback="callbackExport_EndCallback" />
        </dx:ASPxCallback>
        <dx:ASPxButton ID="btSaveToResponse" runat="server" ClientInstanceName="btSaveToResponse"
            ClientVisible="false" OnClick="btSaveToResponse_Click">
        </dx:ASPxButton>
    </div>
    </form>
</body>
</html>
