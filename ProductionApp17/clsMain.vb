Imports System.Net
Imports System.Web.Http
Imports System.Data
Imports System.Web
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Public Class clsMain

    '*********************************************************************
    '* Function to encript a string. Very basic.
    '*********************************************************************
    Public Function EncryptStr(ByVal sString)

        Dim x

        For x = 1 To Len(sString)
            If (Asc(Mid(sString, x, 1)) / 2) = Int(Asc(Mid(sString, x, 1)) / 2) Then
                sString = Left(sString, x - 1) + Chr(Asc(Mid(sString, x, 1)) + 4) + Mid(sString, x + 1)
            Else
                sString = Left(sString, x - 1) + Chr(Asc(Mid(sString, x, 1)) - 4) + Mid(sString, x + 1)
            End If
        Next

        EncryptStr = sString

    End Function

    '*********************************************************************
    '* Function to decrypt a string
    '*********************************************************************
    Public Function DecryptStr(ByVal sString)

        Dim x

        For x = 1 To Len(sString)
            If (Asc(Mid(sString, x, 1)) / 2) = Int(Asc(Mid(sString, x, 1)) / 2) Then
                sString = Left(sString, x - 1) + Chr(Asc(Mid(sString, x, 1)) - 4) + Mid(sString, x + 1)
            Else
                sString = Left(sString, x - 1) + Chr(Asc(Mid(sString, x, 1)) + 4) + Mid(sString, x + 1)
            End If
        Next

        DecryptStr = sString

    End Function

    Public Function ConvertNullInteger(DataValue) As Integer

        Try
            If IsDBNull(DataValue) Then
                ConvertNullInteger = 0
            Else
                If IsNumeric(DataValue) Then
                    ConvertNullInteger = CInt(DataValue)
                Else
                    ConvertNullInteger = 0
                End If
            End If

        Catch
            'Error has occured
            'Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            'If mpLabel IsNot Nothing Then
            'mpLabel.Text = Err.Description
            'End If

        End Try
    End Function

    Public Function ConvertNullDouble(DataValue) As Double

        Try
            If IsDBNull(DataValue) Then
                ConvertNullDouble = 0
            Else
                If IsNumeric(DataValue) Then
                    ConvertNullDouble = CDbl(DataValue)
                Else
                    ConvertNullDouble = 0
                End If
            End If

        Catch
            'Error has occured
            'Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            'If mpLabel IsNot Nothing Then
            'mpLabel.Text = Err.Description
            'End If

        End Try

    End Function
End Class
