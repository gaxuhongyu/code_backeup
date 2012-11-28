Module CCMStart
    Public myCCMS As Object
    Public myccmsID As String
    Public myccmsPassword As String

    Function StartSession() As Boolean
        On Error Resume Next
        StartSession = True
        myCCMS = GetObject(, "ReflectionIBM.Session")
        myCCMS.SwitchToWindow(1)
        If Err.Number = 429 Or Err.Number = 91 Or Err.Number = 462 Then
            Err.Clear()
            myCCMS = GetObject("", "ReflectionIBM.Session")
            With myCCMS
                .Visible = True
                .Hostname = "dalcip"
                .Connect()
                Do
                    .WaitForEvent(rcEvConnected, "", "0", 1, 1)
                    DoEvents()
                Loop While .Connected = False
                Do
                    .WaitForEvent(rcKbdEnabled, "", "0", 1, 1)
                    DoEvents()
                    If .GetFieldText(1, 2, 7) = "CLM095I" Or .GetFieldText(5, 1, 20) = "        To swap from" Then Exit Do
                    If .GetFieldText(1, 30, 21) = "A P C A   S I G N O N" Then Exit Do
                Loop While .ToolBarVisible = True
            End With
        End If
    End Function
    Function LogonACS()
        'MyACSID = "aacsnzt"
        'MyACSPassword = "tsling01"
        'MyACSID = InputBox("put ACS ID:")
        'MyACSPassword = InputBox("put ACS Password:")
        MyACSID = myBilling.ACSID
        MyACSPassword = myBilling.ACSPassword
        With myCCMS
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .TransmitTerminalKey(rcIBMPf9Key)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 5, 13)
            .WaitForDisplayString("==>", "30", 5, 9)
            .TransmitANSI("1")
            .TransmitTerminalKey(rcIBMEnterKey)
            .TransmitANSI(MyACSID)
            .TransmitTerminalKey(rcIBMTabKey)
            .TransmitANSI(MyACSPassword)
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
        End With
    End Function

    Function APLLHKBillingPrint(DraftorFinal As String)
        With myCCMS
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 23, 15)
            .TransmitANSI("123.8.11")
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 3, 76)
            .TransmitANSI("rc7")
            .TransmitTerminalKey(rcIBMNewLineKey)
            .TransmitANSI("099")
            .TransmitANSI(myBilling.ACSCode.Text)
            .SetMousePos(8, 32)
            .TerminalMouse(rcLeftClick, rcMouseRow, rcMouseCol)
            .GraphicsMouse(rcLeftClick, rcCurrentGraphicsCursorX, rcCurrentGraphicsCursorY)
            .TransmitANSI(myBilling.SailCutOffDate.Text)
            .SetMousePos(9, 32)
            .TerminalMouse(rcLeftClick, rcMouseRow, rcMouseCol)
            .GraphicsMouse(rcLeftClick, rcCurrentGraphicsCursorX, rcCurrentGraphicsCursorY)
            .TransmitANSI(myBilling.Frequency.Text)
            .TransmitANSI(myBilling.LoadPort.Text)
            .SetMousePos(13, 32)
            .TerminalMouse(rcLeftClick, rcMouseRow, rcMouseCol)
            .GraphicsMouse(rcLeftClick, rcCurrentGraphicsCursorX, rcCurrentGraphicsCursorY)
            .TransmitANSI(myBilling.ContinentCD.Text)
            .SetMousePos(18, 32)
            .TerminalMouse(rcLeftClick, rcMouseRow, rcMouseCol)
            .GraphicsMouse(rcLeftClick, rcCurrentGraphicsCursorX, rcCurrentGraphicsCursorY)
            .TransmitANSI(DraftorFinal)
            .SetMousePos(21, 32)
            .TerminalMouse(rcLeftClick, rcMouseRow, rcMouseCol)
            .GraphicsMouse(rcLeftClick, rcCurrentGraphicsCursorX, rcCurrentGraphicsCursorY)
            .TransmitANSI("P02X")
            .TransmitTerminalKey(rcIBMEnterKey)
            .TransmitTerminalKey(rcIBMEnterKey)
            .Disconnect()
            .Connect()
        End With
    End Function

    Function APLLHKBillingDownload()
        MyACSID = myBilling.ACSID
        MyACSPassword = myBilling.ACSPassword
        'MyACSID = "aacsnzt"
        'MyACSPassword = "tsling01"
        'MyACSID = InputBox("put ACS ID:")
        'MyACSPassword = InputBox("put ACS Password:")
        With myCCMS
            Do
                .WaitForEvent(rcEvConnected, "", "0", 1, 1)
                DoEvents()
            Loop While .Connected = False
            Do
                .WaitForEvent(rcKbdEnabled, "", "0", 1, 1)
                DoEvents()
                If .GetFieldText(1, 2, 7) = "CLM095I" Or .GetFieldText(5, 1, 20) = "        To swap from" Then Exit Do
                If .GetFieldText(1, 30, 21) = "A P C A   S I G N O N" Then Exit Do
            Loop While .ToolBarVisible = True
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .TransmitTerminalKey(rcIBMPf9Key)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 5, 13)
            .TransmitANSI("p")
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcEnterPos, "30", "0", 1, 36)
            .TransmitANSI(MyACSID)
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcEnterPos, "30", "0", 2, 36)
            .TransmitANSI(MyACSPassword)
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 3, 7)
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 4, 1)
            .TransmitANSI("ISPF")
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 4, 14)
            .TransmitANSI("IOF .")
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 2, 15)
            .TransmitTerminalKey(rcIBMNewLineKey)
            .TransmitANSI("A#123PST")
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 2, 15)
            Dim i As Integer
            If Trim(.GetDisplayText(3, 36, 11)) = "Output Jobs" Then
                i = InputBox("the line number is:")
                .SetMousePos(i, 2)
                .TerminalMouse(rcLeftClick, rcMouseRow, rcMouseCol)
                .GraphicsMouse(rcLeftClick, rcCurrentGraphicsCursorX, rcCurrentGraphicsCursorY)
                .TransmitANSI("s")
                .TransmitTerminalKey(rcIBMEnterKey)
            End If
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 2, 15)
            .SetMousePos(22, 2)
            .TerminalMouse(rcLeftClick, rcMouseRow, rcMouseCol)
            .GraphicsMouse(rcLeftClick, rcCurrentGraphicsCursorX, rcCurrentGraphicsCursorY)
            .TransmitANSI("s")
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 2, 15)
            .TransmitANSI("SD")
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 2, 15)
            .TransmitTerminalKey(rcIBMNewLineKey)
            .TransmitANSI(myBilling.DocName.Text)
            .TransmitTerminalKey(rcIBMEraseEOFKey)
            .TransmitTerminalKey(rcIBMNewLineKey)
            .TransmitANSI("FB")
            .TransmitTerminalKey(rcIBMEraseEOFKey)
            .TransmitTerminalKey(rcIBMNewLineKey)
            .TransmitANSI("133")
            .TransmitTerminalKey(rcIBMEnterKey)
            .TransmitTerminalKey(rcIBMPf3Key)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 2, 15)
            .SetMousePos(22, 2)
            .TerminalMouse(rcLeftClick, rcMouseRow, rcMouseCol)
            .GraphicsMouse(rcLeftClick, rcCurrentGraphicsCursorX, rcCurrentGraphicsCursorY)
            .TransmitANSI("N")
            .TransmitTerminalKey(rcIBMEnterKey)
            .TransmitTerminalKey(rcIBMEnterKey)
            .TransmitTerminalKey(rcIBMPf3Key)
            .TransmitTerminalKey(rcIBMPf3Key)
            .TransmitTerminalKey(rcIBMPf3Key)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 4, 14)
            .TransmitANSI("=3.4")
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 4, 14)
            .SetMousePos(10, 24)
            .TerminalMouse(rcLeftClick, rcMouseRow, rcMouseCol)
            .GraphicsMouse(rcLeftClick, rcCurrentGraphicsCursorX, rcCurrentGraphicsCursorY)
            .TransmitANSI("AACSNZT." & myBilling.DocName.Text)
            .TransmitTerminalKey(rcIBMEraseEOFKey)
            .TransmitTerminalKey(rcIBMEnterKey)
            .TransmitTerminalKey(rcIBMEnterKey)
            .TransmitTerminalKey(rcIBMPf3Key)
            .TransmitTerminalKey(rcIBMPf3Key)
            .TransmitTerminalKey(rcIBMPf3Key)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .WaitForEvent(rcEnterPos, "30", "0", 2, 1)
            .TransmitANSI("LOGOFF")
            .TransmitTerminalKey(rcIBMEnterKey)
            .WaitForEvent(rcKbdEnabled, "30", "0", 1, 1)
            .Disconnect()
            .Connect()
        End With
    End Function

End Module
