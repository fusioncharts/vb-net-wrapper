Imports System.Web.UI.WebControls
Imports FusionCharts.Charts
Partial Class Samples_NewChartsSample_gauge
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim jsonData As [String]
        jsonData = "{      'chart': {        'caption': 'Customer Satisfaction Score',        'subcaption': 'Los Angeles Topanga',        'lowerlimit': '0',        'upperlimit': '100',        'lowerlimitdisplay': 'Bad',        'upperlimitdisplay': 'Good',        'numbersuffix': '%',        'tickvaluedistance': '10',        'gaugeinnerradius': '0',        'bgcolor': 'FFFFFF',        'pivotfillcolor': '333333',        'pivotradius': '8',        'pivotfillmix': '333333, 333333',        'pivotfilltype': 'radial',        'pivotfillratio': '0,100',        'showtickvalues': '1',        'majorTMThickness': '2',        'majorTMHeight': '15',        'minorTMHeight': '3',        'showborder': '0',        'plottooltext': '<div>Average Score : <b>$value%</b></div>',      },      'colorrange': {        'color': [{          'minvalue': '0',          'maxvalue': '50',          'code': 'e44a00'        }, {          'minvalue': '50',          'maxvalue': '75',          'code': 'f8bd19'        }, {          'minvalue': '75',          'maxvalue': '100',          'code': '6baa01'        }]      },      'dials': {        'dial': [{          'value': '84',          'rearextension': '15',          'radius': '100',          'bgcolor': '333333',          'bordercolor': '333333',          'basewidth': '8'        }]      }    }"
        ' Initialize chart
        Dim chart As New Chart("angulargauge", "myChart", "600", "350", "json", jsonData)
        ' Render the chart
        Literal1.Text = chart.Render()
    End Sub

End Class
