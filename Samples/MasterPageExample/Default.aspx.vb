Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
' Use FusionCharts.Charts name space
Imports FusionCharts.Charts

''' <summary>
''' FusionCharts in Master Page
''' </summary>
Partial Class Samples_MasterPageExample_Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'For a head start we have kept the example simple
        'You can use complex code to render chart taking data streaming from 
        'database etc.

        ' Initialize chart - Radar Chart with the JSON string
        Dim sales As New Chart("candlestick", "myChart", "700", "350", "jsonurl", "../../Data/MasterPageData.json")
        ' Render the chart
        Literal1.Text = sales.Render()
    End Sub
End Class
