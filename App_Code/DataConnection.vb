Imports Microsoft.VisualBasic

Imports System.Data
Imports System.Data.Odbc
Imports System.Web
Imports System.Configuration

Namespace DataConnection
    ''' <summary>
    ''' DataBase Connection Class.
    ''' </summary>
    Public Class DbConn

        ' Create a database Connection. using here Access Database
        ' Return type object of OdbcConnection

        Public connection As OdbcConnection
        Public ReadData As OdbcDataReader
        Public aCommand As OdbcCommand
        ''' <summary>
        ''' Data Connection and get Data Reader
        ''' </summary>
        ''' <param name="strQuery">SQL Query</param>
        Public Sub New(strQuery As String)
            ' MS Access DataBase Connection - Defined in Web.Config
            Dim connectionName As String = "MSAccessConnection"

            ' SQL Server DataBase Connection - Defined in Web.Config
            'string connectionName = "SQLServerConnection";

            ' Creating Connection string using web.config connection string
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings(connectionName).ConnectionString
            Try
                ' create connection object
                connection = New OdbcConnection()
                ' set connection string
                connection.ConnectionString = ConnectionString
                ' open connection
                connection.Open()
                ' get reader
                GetReader(strQuery)
            Catch e As Exception
                HttpContext.Current.Response.Write(e.Message.ToString())

            End Try
        End Sub

        ' Create an instance dataReader
        ' Return type object of OdbcDataReader
        ''' <summary>
        ''' Get Data Reader
        ''' </summary>
        ''' <param name="strQuery">SQL Query</param>
        Public Sub GetReader(strQuery As String)
            ' Create a Command object
            aCommand = New OdbcCommand(strQuery, connection)

            ' Create data reader object using strQuery string
            ' Auto close connection
            ReadData = aCommand.ExecuteReader(CommandBehavior.CloseConnection)

        End Sub

    End Class
End Namespace