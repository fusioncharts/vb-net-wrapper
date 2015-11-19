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
Imports System.Data.Odbc
Imports DataConnection
Imports System.Data.OleDb
' Use the `FusionCharts.Charts` namespace to be able to use classes and methods required to create charts.
Imports FusionCharts.Charts
Partial Class Samples_DBExample_index
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create the `jsonData` StringBuilder object to store the data fetched 
        'from the database as a string.
        Dim jsonData As New StringBuilder()

        Dim ReqDatasetComma As Boolean = False, ReqComma As Boolean = False

        ' Initialize the chart-level attributes and append them to the 
        '`jsonData` StringBuilder object.
        ' add chart level attrubutes
        jsonData.Append("{" + "'chart': {" + "'caption': 'Factory Output report'," + "'subCaption': 'By Quantity'," + "'formatNumberScale': '0'," + "'rotatelabels': '1'," + "'showvalues': '0'," + "'showBorder': '1'" + "},")

        ' Initialize the Categories object.
        jsonData.Append("'categories': [" + "{" + "'category': [")

        ' Every date between January 01, 2003 and January 20, 2003 is entered thrice 
        ' in the datepro field in the FactoryDB database. 
        ' The dates will be shown as category labels on the x-axis of the chart. 
        ' Because we need to show each date only once, use the `select` query 
        ' with the `distinct` keyword to fetch only one instance of each date from the database. 
        ' Store the output of the `select` query in the `factoryQuery` string variable.
        Dim factoryQuery As String = "select distinct format(datepro,'dd/mm/yyyy') as dd from factory_output"

        ' Establish the database connection.
        Dim oRs As New DbConn(factoryQuery)

        ' Iterate through the data in the `factoryQuery` variable and add the dates as 
        ' labels to the category object.
        ' Append this data to the `jsonData` object.
        While oRs.ReadData.Read()
            If ReqComma Then
                jsonData.Append(",")
            Else
                ReqComma = True
            End If

            ' category level attributes
            jsonData.AppendFormat("{{" + "'label': '{0}'" + "}}", oRs.ReadData("dd").ToString())
        End While

        'Closing the database connection.
        oRs.ReadData.Close()

        'Closing the catgories object.
        jsonData.Append("]" + "}" + "],")

        ' Initialize the Dataset object.
        jsonData.Append("'dataset': [")


        'Fetch all details for the three factories from the Factory_Master table
        ' and store the result in the `factoryquery2` variable.
        Dim factoryquery2 As String = "select * from factory_master"

        'Establish the database connection.
        Dim oRs1 As New DbConn(factoryquery2)



        ' Iterate through the results in the `factoryquery2` variable to fetch the 
        ' factory name and factory id.
        While oRs1.ReadData.Read()
            If ReqDatasetComma Then
                jsonData.Append(",")
            Else
                ReqDatasetComma = True
            End If
            ' Append the factory name as the value for the `seriesName` attribute.
            ' dataset level attributes
            jsonData.AppendFormat("{{" + "'seriesname': '{0}'," + "'data': [", oRs1.ReadData("factoryname").ToString())

            ' Based on the factory id, fetch the quantity produced by each factory on each day 
            ' from the factory_output table.
            ' Store the results in the `factoryquery3` string object.
            Dim factoryquery3 As String = "select quantity from factory_output where factoryid=" + oRs1.ReadData("factoryid").ToString()

            'Establish the database connection.
            Dim oRs2 As New DbConn(factoryquery3)

            ReqComma = False

            ' Iterate through the results in the `factoryquery3` object and fetch the quantity details 
            ' for each factory.
            ' Append the quantity details as the the value for the `<set>` element.
            While oRs2.ReadData.Read()
                If ReqComma Then
                    jsonData.Append(",")
                Else
                    ReqComma = True
                End If

                ' data set attributes
                jsonData.AppendFormat("{{" + "'value': '{0}'" + "}}", oRs2.ReadData(0).ToString())
            End While

            ' Close the database connection.
            oRs2.ReadData.Close()

            ' Close individual dataset object.
            jsonData.Append("]" + "}")
        End While

        ' Close the database connection.
        oRs1.ReadData.Close()

        ' Close the JSON object.
        jsonData.Append("]" + "}")

        ' Initialize chart - Multi-series Line 2D Chart data pulling from database
        Dim factoryOutput As New Chart("msline", "myChart", "600", "350", "json", jsonData.ToString())
        ' Render the chart
        Literal1.Text = factoryOutput.Render()

    End Sub
End Class
