
Imports System.Collections
Imports System.Configuration
Imports System.Data

Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
' Use FusionCharts.Charts name space
Imports FusionCharts.Charts
Partial Class Samples_BasicExamples_XML_URL
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This page demonstrates the ease of generating charts using FusionCharts.
        ' For this chart, we've used a pre-defined Data.xml (contained in /Data/ folder)
        ' Ideally, you would NOT use a physical data file. Instead you'll have 
        ' your own ASP.NET scripts virtually relay the JSON / XML data document.
        ' For a head-start, we've kept this example very simple.

        ' Initialize chart - Real-time Angular Chart with data from Data/Data.json
        Dim sales As New Chart("angulargauge", "myChart", "600", "350", "xmlurl", "../../Data/Data.xml")
        ' Render the chart
        Literal1.Text = sales.Render()
    End Sub
End Class
