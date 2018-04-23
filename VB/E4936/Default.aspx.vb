Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.XtraReports.UI
Imports DevExpress.Web.ASPxCallback
Imports System.Threading
Imports System.IO
Imports E4936.Reports

Namespace E4936
	Partial Public Class [Default]
		Inherits System.Web.UI.Page
		Protected Sub cbExport_Callback(ByVal source As Object, ByVal e As CallbackEventArgs)
			Dim report As XtraReport = New OrdersReport()
			Dim stream As New MemoryStream()
			Select Case e.Parameter
				Case "pdf"
					report.ExportToPdf(stream)
				Case "xls"
					report.ExportToXls(stream)
				Case "xlsx"
					report.ExportToXlsx(stream)
				Case "rtf"
					report.ExportToRtf(stream)
				Case "mht"
					report.ExportToMht(stream)
				Case "html"
					report.ExportToHtml(stream)
				Case "txt"
					report.ExportToText(stream)
				Case "csv"
					report.ExportToCsv(stream)
				Case "png"
					report.ExportToImage(stream)
				Case Else
					Return
			End Select

			'Delay to emulate long exporting
			Thread.Sleep(2000)

			Session("ExportedData") = stream
			Session("ExportedDataType") = e.Parameter
		End Sub

		Protected Sub btSaveToResponse_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim stream As MemoryStream = TryCast(Session("ExportedData"), MemoryStream)
			Dim type As String = Session("ExportedDataType").ToString()
			WriteToResponse("ExportResult", True, type, stream)

			Session("ExportedData") = Nothing
		End Sub

		Protected Sub WriteToResponse(ByVal fileName As String, ByVal saveAsFile As Boolean, ByVal fileFormat As String, ByVal stream As MemoryStream)
			If Page Is Nothing OrElse Page.Response Is Nothing Then
				Return
			End If
			Dim disposition As String = If(saveAsFile, "attachment", "inline")
			Page.Response.Clear()
			Page.Response.Buffer = False
			Page.Response.AppendHeader("Content-Type", String.Format("application/{0}", fileFormat))
			Page.Response.AppendHeader("Content-Transfer-Encoding", "binary")
			Page.Response.AppendHeader("Content-Disposition", String.Format("{0}; filename={1}.{2}", disposition, HttpUtility.UrlEncode(fileName).Replace("+", "%20"), fileFormat))
			Page.Response.BinaryWrite(stream.ToArray())
			Page.Response.End()
		End Sub
	End Class
End Namespace