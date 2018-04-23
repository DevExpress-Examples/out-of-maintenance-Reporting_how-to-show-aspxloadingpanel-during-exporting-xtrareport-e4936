using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.UI;
using DevExpress.Web.ASPxCallback;
using System.Threading;
using System.IO;
using E4936.Reports;

namespace E4936 {
    public partial class Default : System.Web.UI.Page {
        protected void cbExport_Callback(object source, CallbackEventArgs e) {
            XtraReport report = new OrdersReport();
            MemoryStream stream = new MemoryStream();
            switch (e.Parameter) {
                case "pdf":
                    report.ExportToPdf(stream);
                    break;
                case "xls":
                    report.ExportToXls(stream);
                    break;
                case "xlsx":
                    report.ExportToXlsx(stream);
                    break;
                case "rtf":
                    report.ExportToRtf(stream);
                    break;
                case "mht":
                    report.ExportToMht(stream);
                    break;
                case "html":
                    report.ExportToHtml(stream);
                    break;
                case "txt":
                    report.ExportToText(stream);
                    break;
                case "csv":
                    report.ExportToCsv(stream);
                    break;
                case "png":
                    report.ExportToImage(stream);
                    break;
                default:
                    return;
            }

            //Delay to emulate long exporting
            Thread.Sleep(2000);

            Session["ExportedData"] = stream;
            Session["ExportedDataType"] = e.Parameter;
        }

        protected void btSaveToResponse_Click(object sender, EventArgs e) {
            MemoryStream stream = Session["ExportedData"] as MemoryStream;
            string type = Session["ExportedDataType"].ToString();
            WriteToResponse("ExportResult", true, type, stream);

            Session["ExportedData"] = null;
        }

        protected void WriteToResponse(string fileName, bool saveAsFile, string fileFormat, MemoryStream stream) {
            if (Page == null || Page.Response == null)
                return;
            string disposition = saveAsFile ? "attachment" : "inline";
            Page.Response.Clear();
            Page.Response.Buffer = false;
            Page.Response.AppendHeader("Content-Type", string.Format("application/{0}", fileFormat));
            Page.Response.AppendHeader("Content-Transfer-Encoding", "binary");
            Page.Response.AppendHeader("Content-Disposition", string.Format("{0}; filename={1}.{2}", disposition, HttpUtility.UrlEncode(fileName).Replace("+", "%20"), fileFormat));
            Page.Response.BinaryWrite(stream.ToArray());
            Page.Response.End();
        }
    }
}