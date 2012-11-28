Public Class myBilling

    Private Sub myBilling_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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