Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Text
' Use FusionCharts.Charts name space
Imports FusionCharts.Charts
Partial Class Samples_ExportExample_Export
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This page demonstrates the ease of generating charts with exporting feature.
        ' To enable export feature just set "exportEnabled" attrubute as "1"
        ' Now from the webpage click on the export button of the the chart to get the exported image of the chart.
        ' For more export related attributes refer to FusionCharts docs
        'jsonData - Stores the entire JSON string
        Dim jsonData As New StringBuilder()

        ' Add export enabling attribute
        jsonData.Append("{" + "    'chart': {" + "        'caption': 'Radar Chart'," + "        'ExportEnabled': '1'" + "    }," + "    'categories': [" + "        {" + "            'category': [" + "                {" + "                    'label': 'Index 1'" + "                }," + "                {" + "                    'label': 'Index 2'" + "                }," + "                {" + "                    'label': 'Index 3'" + "                }," + "                {" + "                    'label': 'Index 4'" + "                }," + "                {" + "                    'label': 'Index 5'" + "                }," + "                {" + "                    'label': 'Index 6'" + "                }," + "                {" + "                    'label': 'Index 7'" + "                }," + "                {" + "                    'label': 'Index 8'" + "                }," + "                {" + "                    'label': 'Index 9'" + "                }," + "                {" + "                    'label': 'Index 10'" + "                }," + "                {" + "                    'label': 'Index 11'" + "                }" + "            ]" + "        }" + "    ]," + "    'dataset': [" + "        {" + "            'seriesname': 'Series 1'," + "            'data': [" + "                {" + "                    'value': '9'" + "                }," + "                {" + "                    'value': '9'" + "                }," + "                {" + "                    'value': '9'" + "                }," + "                {" + "                    'value': '7'" + "                }," + "                {" + "                    'value': '8'" + "                }," + "                {" + "                    'value': '8'" + "                }," + "                {" + "                    'value': '9'" + "                }," + "                {" + "                    'value': '9'" + "                }," + "                {" + "                    'value': '9'" + "                }," + "                {" + "                    'value': '7'" + "                }," + "                {" + "                    'value': '8'" + "                }" + "            ]" + "        }," + "        {" + "            'seriesname': 'Series 2'," + "            'data': [" + "                {" + "                    'value': '5'" + "                }," + "                {" + "                    'value': '3'" + "                }," + "                {" + "                    'value': '2'" + "                }," + "                {" + "                    'value': '4'" + "                }," + "                {" + "                    'value': '5'" + "                }," + "                {" + "                    'value': '9'" + "                }," + "                {" + "                    'value': '5'" + "                }," + "                {" + "                    'value': '3'" + "                }," + "                {" + "                    'value': '2'" + "                }," + "                {" + "                    'value': '4'" + "                }," + "                {" + "                    'value': '5'" + "                }" + "            ]" + "        }" + "    ]" + "}")

        ' Initialize chart - Radar Chart with the JSON string
        Dim sales As New Chart("radar", "myChart", "600", "350", "json", jsonData.ToString())
        ' Render the chart
        Literal1.Text = sales.Render()
    End Sub
End Class
