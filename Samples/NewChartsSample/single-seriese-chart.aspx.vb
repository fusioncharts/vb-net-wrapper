Imports System.Web.UI.WebControls
Imports FusionCharts.Charts
Partial Class Samples_NewChartsSample_single_seriese_chart
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim jsonData As [String]
        jsonData = "{      'chart': {        'caption': 'Harry""s SuperMart - Top 5 Stores"" Revenue',        'subCaption': 'Last Quarter',        'numberPrefix': '$',        'rotatevalues': '0',        'plotToolText': '<div><b>$label</b><br/>Sales : <b>$$value</b></div>',        'theme': 'fint'      },      'data': [{        'label': 'Bakersfield Central',        'value': '880000'      }, {        'label': 'Garden Groove harbour',        'value': '730000'      }, {        'label': 'Los Angeles Topanga',        'value': '590000'      }, {        'label': 'Compton-Rancho Dom',        'value': '520000'      }, {        'label': 'Daly City Serramonte',        'value': '330000'      }]    }"
        ' Initialize chart
        Dim chart As New Chart("column2d", "myChart", "600", "350", "json", jsonData)
        ' Render the chart
        Literal1.Text = chart.Render()
    End Sub

End Class
