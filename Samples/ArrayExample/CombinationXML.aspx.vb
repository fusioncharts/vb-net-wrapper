Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
' Use FusionCharts.Charts name space
Imports FusionCharts.Charts
Partial Class Samples_ArrayExample_CombinationXML
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'In this example, we plot a Combination chart from data contained
        'in an array. The array will have three columns - first one for Quarter Name
        'second one for sales figure and third one for quantity. 

        Dim arrData As Object(,) = New Object(3, 2) {}
        'Store Quarter Name
        arrData(0, 0) = "Quarter 1"
        arrData(1, 0) = "Quarter 2"
        arrData(2, 0) = "Quarter 3"
        arrData(3, 0) = "Quarter 4"
        'Store revenue data
        arrData(0, 1) = 576000
        arrData(1, 1) = 448000
        arrData(2, 1) = 956000
        arrData(3, 1) = 734000
        'Store Quantity
        arrData(0, 2) = 576
        arrData(1, 2) = 448
        arrData(2, 2) = 956
        arrData(3, 2) = 734

        'Now, we need to convert this data into combination XML. 
        'We convert using string concatenation.
        'strXML - Stores the entire XML
        'strCategories - Stores XML for the <categories> and child <category> elements
        'strDataRev - Stores XML for current year's sales
        'strDataQty - Stores XML for previous year's sales

        Dim strXML As New StringBuilder()
        Dim strCategories As New StringBuilder()
        Dim strDataRev As New StringBuilder()
        Dim strDataQty As New StringBuilder()

        'Initialize <chart> element
        strXML.Append("<chart palette='4' caption='Product A - Sales Details' PYAxisName='Revenue' SYAxisName='Quantity (in Units)' numberPrefix='$' formatNumberScale='0' showValues='0' decimals='0' >")

        'Initialize <categories> element - necessary to generate a multi-series chart
        strCategories.Append("<categories>")

        'Initiate <dataset> elements
        strDataRev.Append("<dataset seriesName='Revenue'>")
        strDataQty.Append("<dataset seriesName='Quantity' parentYAxis='S'>")

        'Iterate through the data	
        For i As Integer = 0 To arrData.GetLength(0) - 1
            'Append <category name='...' /> to strCategories
            strCategories.AppendFormat("<category name='{0}' />", arrData(i, 0))
            'Add <set value='...' /> to both the datasets
            strDataRev.AppendFormat("<set value='{0}' />", arrData(i, 1))
            strDataQty.AppendFormat("<set value='{0}' />", arrData(i, 2))
        Next

        'Close <categories> element
        strCategories.Append("</categories>")

        'Close <dataset> elements
        strDataRev.Append("</dataset>")
        strDataQty.Append("</dataset>")

        'Assemble the entire XML now
        strXML.Append(strCategories.ToString())
        strXML.Append(strDataRev.ToString())
        strXML.Append(strDataQty.ToString())
        strXML.Append("</chart>")

        ' Initialize chart - Multi-series 2D Dual Y Combination Chart with data from Data/Data.json
        Dim sales As New Chart("mscombidy2d", "myChart", "600", "350", "xml", strXML.ToString())
        ' Render the chart
        Literal1.Text = sales.Render()
    End Sub
End Class