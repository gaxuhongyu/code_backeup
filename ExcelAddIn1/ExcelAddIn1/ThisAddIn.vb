Public Class ThisAddIn

    Private Sub ThisAddIn_Startup() Handles Me.Startup

    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub
    Public Function fFindNumber(strPutString As String) As String
        Dim strOut As String     '输出字符串变量
        Dim I

        For I = 1 To Len(strPutString)
            If Mid(strPutString, I, 1) Like "[0-9]" Then
                strOut = strOut & Mid(strPutString, I, 1)
            End If
        Next I
        fFindNumber = strOut
    End Function
End Class
