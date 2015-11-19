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
Partial Class Samples_ArrayExample_MultiSeriesJSON
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'In this example, we plot a multi series chart from data contained
        'in an array. The array will have three columns - first one for data label (product)
        'and the next two for data values. The first data value column would store sales information
        'for current year and the second one for previous year.

        'Let//s store the sales data for 6 products in our array. We also store
        'the name of products. 
        Dim arrData As Object(,) = New Object(5, 2) {}
        'Store Name of Products
        arrData(0, 0) = "Product A"
        arrData(1, 0) = "Product B"
        arrData(2, 0) = "Product C"
        arrData(3, 0) = "Product D"
        arrData(4, 0) = "Product E"
        arrData(5, 0) = "Product F"
        'Store sales data for current year
        arrData(0, 1) = 567500
        arrData(1, 1) = 815300
        arrData(2, 1) = 556800
        arrData(3, 1) = 734500
        arrData(4, 1) = 676800
        arrData(5, 1) = 648500
        'Store sales data for previous year
        arrData(0, 2) = 367300
        arrData(1, 2) = 584500
        arrData(2, 2) = 754000
        arrData(3, 2) = 456300
        arrData(4, 2) = 754500
        arrData(5, 2) = 437600

        'Now, we need to convert this data into multi-series JSON. 
        'We convert using string concatenation.
        'jsonData - Stores the entire JSON string
        'categories - Stores pertial  for the <categories> and child <category> elements
        'currentYear - Stores XML for current year's sales
        'previousYear - Stores XML for previous year's sales
        Dim jsonData As New StringBuilder()
        Dim categories As New StringBuilder()
        Dim currentYear As New StringBuilder()
        Dim previousYear As New StringBuilder()

        'Initialize chart object of the JSON
        ' add chart level attrubutes
        jsonData.Append("{" + "'chart': {" + "'caption': 'Sales by Product'," + "'numberPrefix': '$'," + "'formatNumberScale': '1'," + "'placeValuesInside': '1'," + "'decimals': '0'" + "},")

        'Initial string part of categories element - necessary to generate a multi-series chart
        categories.Append("'categories': [" + "{" + "'category': [")

        'Initial string part of dataset elements
        ' dataset level attributes
        currentYear.Append("{" + "'seriesname': 'Current Year'," + "'data': [")
        ' dataset level attributes
        previousYear.Append("{" + "'seriesname': 'Previous Year'," + "'data': [")

        'Iterate through the data	
        For i As Integer = 0 To arrData.GetLength(0) - 1
            If i > 0 Then
                categories.Append(",")
                currentYear.Append(",")
                previousYear.Append(",")
            End If
            'Append individual category to strCategories
            ' category level attributes
            categories.AppendFormat("{{" + "'label': '{0}'" + "}}", arrData(i, 0))
            'Add individual data to both the datasets
            ' data level attributes
            currentYear.AppendFormat("{{" + "'value': '{0}'" + "}}", arrData(i, 1))
            ' data level attributes
            previousYear.AppendFormat("{{" + "'value': '{0}'" + "}}", arrData(i, 2))
        Next

        'Closing part of the categories object
        categories.Append("]" + "}" + "],")

        '''/Closing part of individual dataset object
        currentYear.Append("]" + "},")
        previousYear.Append("]" + "}")

        'Assemble the entire XML now
        jsonData.Append(categories.ToString())
        jsonData.Append("'dataset': [")
        jsonData.Append(currentYear.ToString())
        jsonData.Append(previousYear.ToString())
        jsonData.Append("]" + "}")

        ' Initialize chart - Multi-series Line 2D Chart with data from Data/Data.json
        Dim sales As New Chart("msline", "myChart", "600", "350", "json", jsonData.ToString())
        ' Render the chart
        Literal1.Text = sales.Render()
    End Sub
End Class
