Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports DataConnection
Imports InfoSoftGlobal
Imports FusionCharts.Charts

''' <summary>
''' FusionCharts and ASP.NET.AJAX Update Panel 
''' </summary>
Partial Class Samples_UpdatePanelExample_Sample1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'This will execute first time the page loads and not on ajax post back calls
        If Not IsPostBack Then
            'Generate Radio button from the available Factory names in Database
            'Get Factory names from Factory_Master
            Dim strSQL As String = "select FactoryId,FactoryName from Factory_Master"

            'Open datareader using DBConn object
            Dim rs1 As New DbConn(strSQL)
            'Fetch all record 
            While rs1.ReadData.Read()
                'Creating Radio Button List 
                RadioButtonList1.Items.Add(New ListItem(rs1.ReadData("FactoryName").ToString(), rs1.ReadData("FactoryId").ToString()))
            End While
            ' close datareader 
            rs1.ReadData.Close()


            'Select First radio button as dafult value
            RadioButtonList1.Items(0).Selected = True

            'Show chart as per selected radio button.
            updateChart()
        End If
    End Sub

    'When radio button selection changes i.e. selected factory changes
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Update FusionCharts and gridview with as per selected factory
        updateChart()
    End Sub

    ''' <summary>
    ''' update FusionCharts and gridview with as per selected factory name
    ''' </summary>
    Private Sub updateChart()
        'Get factory details depending on FactoryID from selected Radio Button
        Dim strSQL As String = "select DatePro, Quantity from Factory_Output where FactoryId=" + RadioButtonList1.SelectedValue.ToString() + " order by DatePro"

        'Create data reader to bind data with GridView 
        Dim rs As New DbConn(strSQL)
        'Fillup gridview with data from datareader
        GridView1.DataSource = rs.ReadData
        ' binding the data
        GridView1.DataBind()

        'Create database connection to get data for chart 
        Dim oRs As New DbConn(strSQL)

        'Create FusionCharts XML
        Dim strXML As New StringBuilder()

        'Create chart element
        strXML.AppendFormat("<chart caption='Factory {0}' showborder='0' bgcolor='FFFFFF' bgalpha='100' subcaption='Daily Production' xAxisName='Day' yAxisName='Units' rotateLabels='1'  placeValuesInside='1' rotateValues='1' >", RadioButtonList1.SelectedValue.ToString())

        'Iterate through database
        While oRs.ReadData.Read()
            'Create set element
            'Also set date into d/M format
            strXML.AppendFormat("<set label='{0}' value='{1}' />", Convert.ToDateTime(oRs.ReadData("DatePro")).ToString("d/M"), oRs.ReadData("Quantity").ToString())
        End While

        'Close chart element
        strXML.Append("</chart>")


        'outPut will store the HTML of the chart rendered as string 
        Dim outPut As String = ""

        'When the page is loaded for the first time, we call RenderChart() method to avoid IE's 'Click here to Acrtivate...' message
        Dim sales As New Chart("column2d", "myChart", "440", "350", "xml", strXML.ToString())
        outPut = sales.Render()

        'Clear panel which will contain the chart
        Panel1.Controls.Clear()

        'Add Litaral control to Panel which adds the chart from outPut string
        Panel1.Controls.Add(New LiteralControl(outPut))

        ' close Data Reader
        oRs.ReadData.Close()
    End Sub
End Class
