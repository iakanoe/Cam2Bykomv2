Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports emailvb
Imports System.Threading
Imports System.Data.OleDb
Public Class Form1
    Dim mailmail As New Class1
    Dim conteo As Integer = 0
    Dim looop As Thread = Nothing
    Dim workm, refreshh, timear, refreshh2 As Thread
    Dim working As Boolean = False
    Dim conexion As New OleDbConnection
    Dim data1, data2 As New DataSet
    Private _WaitHandle_FirstThreadDone As New AutoResetEvent(False)
    Dim numeroscode As String() = {"4", "8", "1", "2", "7", "0", "5", "6", "9", "3", "B", "F", "D", "E", "A", "C"}
    Dim configs As String()
    Dim caracteres As String = "1234567890ABCDEF"
    Sub loooop()
        Try
            Do
                last.Text = "Ultimo chequeo: " & Now.ToString("dd/MM/yyyy HH:mm:ss")
                Dim mailsrecibidos As Object(,)
                Dim mail1(2) As String
                mailsrecibidos = mailmail.email_recieve("mail.monitoreomayorista.com", "camcontrolram@monitoreomayorista.com", "camaracamara", 110, True)
                If mailsrecibidos IsNot Nothing Then
                    For i = 0 To UBound(mailsrecibidos, 2)
                        If mailsrecibidos(0, i) IsNot Nothing Then mail1(0) = mailsrecibidos(0, i)
                        If mailsrecibidos(1, i) IsNot Nothing Then mail1(1) = mailsrecibidos(1, i)
                        If mailsrecibidos(2, i) IsNot Nothing Then mail1(2) = mailsrecibidos(2, i)
                        workm1(mail1)
                        _WaitHandle_FirstThreadDone.WaitOne()
                        _WaitHandle_FirstThreadDone = New AutoResetEvent(False)
                    Next
                End If
                If conteo = 4 Then
                    'TODO manda heartbit -- despues ver
                    'mandar("000000", 8001, "192.168.5.100")
                    'escribirenlog("Heartbit enviado")
                    conteo = 0
                Else
                    conteo = conteo + 1
                End If
                Thread.Sleep(30000)
            Loop
        Catch ex As ThreadAbortException
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub workm1(mm As Object())
        workm = New Thread(AddressOf workmail)
        workm.Start(mm)
    End Sub
    Sub lop()
        looop = New Thread(AddressOf loooop)
        looop.Start()
        configs = Nothing
        configs = {enviardatos.Checked.ToString, iptxt.Text, puertotxt.Text, heartbittiempo.Text, heartbitenviar.Checked.ToString}
    End Sub
    Private Function DecodeBase64(ByVal strBody As String)

        Try
            Dim encode As New System.Text.UTF8Encoding
            Dim Buffer As Byte() = Convert.FromBase64String(strBody)
            Return encode.GetString(Buffer)
        Catch ex As Exception
            MsgBox("A problem occured while decoding a base64 title", MsgBoxStyle.Critical)
            DecodeBase64 = "ERROR"
            Exit Function
        End Try

    End Function
    Sub workmail(mail1 As Object())
        Dim mail As String() = CType(mail1, String())
        Dim from As String = mail(0)
        Dim asunto As String = mail(1)
        Dim cuerpo As String = mail(2)
        Dim d1, d2, d3, d4, cuentahex, paqueteudp, eventomail As String
        Dim eventohex As String = Nothing
        Dim abonado As String = Nothing
        Dim evento As Integer
        Dim nombredealarma As String
        If Strings.Left(asunto, 2) = " =" Then
            asunto = Mid(asunto, 12, InStr(asunto, "?=") - 12)
            asunto = DecodeBase64(asunto)
        End If
        Dim lineas As String() = cuerpo.Split(vbLf)
        nombredealarma = Mid$(lineas(2), 34)
        If InStr(asunto, "-") Then asunto = Mid(asunto, 3, asunto.Length - 3)
        If asunto = "Mail_deprueba" Or asunto = "Prueba de funcionamiento" Then
            abonado = nombredealarma
        Else
            For i = 1 To asunto.Length
                Dim tmp As Integer = Convert.ToInt32((Mid(asunto, i, 1)), 16)
                If tmp >= 10 Then
                    abonado &= Conversion.Hex(tmp)
                Else
                    abonado &= CStr(tmp)
                End If
            Next
        End If
        Dim tmp2 As String = Nothing
        For i = 1 To abonado.Length
            Dim char2 As String = Mid(abonado, i, 1)
            Dim final As Integer
            Try
                If Not IsNumeric(char2) Then final = Convert.ToInt32(char2, 16) Else final = CInt(char2)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            tmp2 &= numeroscode(final)
        Next
        abonado = tmp2
        eventomail = Mid$(lineas(0), 19, lineas(0).Length)
        Select Case eventomail
            Case "Movimiento"
                eventohex = "080603"
                evento = 863
            Case "Enmascaramiento"
                eventohex = "080602"
                evento = 862
            Case "Mail_deprueba"
                eventohex = "080601"
                evento = 861
            Case "Prueba de funcionamiento" ' heartbit TODO
                eventomail = "Heartbit"
                If heartbitenviar.Checked Then
                    eventohex = "080600"
                    evento = 860
                End If
            Case "MovimientoParar" ' TODO
                eventohex = "080604"
                evento = 864
            Case "EnmascaramientoParar"
                eventohex = "080605"
                evento = 865
            Case Else
                looop.Abort()
        End Select
        subiradb(abonado, evento, eventomail, nombredealarma)
        If eventohex IsNot Nothing And enviardatos.Checked And abonado IsNot "desconocido" Then
            d1 = Strings.Left$(abonado, 1)
            d2 = Mid$(abonado, 2, 1)
            d3 = Mid$(abonado, 3, 1)
            d4 = Strings.Right$(abonado, 1)
            cuentahex = "0" & d1 & "0" & d2 & "0" & d3 & "0" & d4
            paqueteudp = "40d769920490" & cuentahex & "010801" & eventohex & "0a010a0a0a0e3e040081"
            mandar(paqueteudp, puertotxt.Text, iptxt.Text)
        End If
        refreshtablas()
        _WaitHandle_FirstThreadDone.Set()
    End Sub
    Public Sub escribirenlog(linesinCrLf As String)
        File.AppendAllText("log" & Now.ToString("yyyyMMdd") & ".txt", "[" & Now.ToString("HH:mm:ss") & "]:" & linesinCrLf & vbCrLf)
    End Sub
    Private Sub mandar(paquete As String, puerto As Integer, ip As String)
        Dim adr As IPAddress = Dns.GetHostAddresses(ip).First
        Dim uc As New UdpClient
        uc = New UdpClient
        uc.Connect(adr.ToString, puerto)
        Dim senddata As Byte()
        senddata = hex2byte(paquete)
        uc.Send(senddata, senddata.Length)
    End Sub
    Function hex2byte(string_ As String) As Byte()
        string_ = string_.Replace(" "c, "")
        Dim nBytes = string_.Length \ 2
        Dim a(nBytes - 1) As Byte
        For i As Integer = 0 To nBytes - 1
            Try
                a(i) = Convert.ToByte(string_.Substring(i * 2, 2), 16)
            Catch ex As Exception
            End Try
        Next
        Return a
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not working Then
            If iptxt.Text = Nothing And iptxt.Enabled Then
                MsgBox("Debe especificar Dirección IP.", vbExclamation)
            ElseIf puertotxt.Text = Nothing And iptxt.Enabled Then
                MsgBox("Debe especificar Puerto.", vbExclamation)
            ElseIf heartbittiempo.Text = Nothing Then
                MsgBox("Debe especificar Máximo tiempo sin recepción.", vbExclamation)
            ElseIf IsNumeric(heartbittiempo.Text) = False And CInt(heartbittiempo.Text) > 1 Then
                MsgBox("Valor de Máximo tiempo sin recepción no válido.")
            Else
                status.Text = "Encendido"
                escribirenlog("ENCENDIDO")
                Button1.Text = "Apagar"
                iptxt.Enabled = False
                puertotxt.Enabled = False
                heartbitenviar.Enabled = False
                heartbittiempo.Enabled = False
                Label2.Enabled = False
                Label3.Enabled = False
                enviardatos.Enabled = False
                lop()
                TabControl1.SelectedIndex = 0
                working = Not working
            End If
        Else
            looop.Abort()
            If timear IsNot Nothing Then timear.Abort()
            enviardatos.Enabled = True
            iptxt.Enabled = enviardatos.Checked
            puertotxt.Enabled = enviardatos.Checked
            heartbitenviar.Enabled = enviardatos.Checked
            Label2.Enabled = enviardatos.Checked
            Label3.Enabled = enviardatos.Checked
            heartbittiempo.Enabled = True
            Button1.Text = "Encender"
            status.Text = "Apagado"
            escribirenlog("APAGADO")
            working = Not working
        End If
    End Sub
    Private Sub enviardatos_CheckedChanged(sender As Object, e As EventArgs) Handles enviardatos.CheckedChanged
        iptxt.Enabled = enviardatos.Checked
        puertotxt.Enabled = enviardatos.Checked
        heartbitenviar.Enabled = enviardatos.Checked
        Label2.Enabled = enviardatos.Checked
        Label3.Enabled = enviardatos.Checked
    End Sub
    Sub subiradb(cu As String, evt As Integer, desc As String, nombre As String)
        Dim conexion3 As New OleDbConnection(conexion.ConnectionString)
        Dim comando As New OleDbCommand
        Try
            conexion3.Open()
            comando.CommandText = "INSERT INTO datos (FECHAHORA, CUENTA, EVENTO, DESCRIPCION, NOMBREALARMA) VALUES (#" & Now.ToString("dd/MM/yyyy HH:mm:ss") & "#, '" & cu & "', " & evt.ToString & ", '" & desc & "', '" & nombre & "')"
            comando.Connection = conexion3
            comando.ExecuteNonQuery()
            Dim consulta As String
            If IfExists(cu, False) Then
                consulta = "UPDATE cuentas SET [LAST] = #" & Now.ToString("dd/MM/yyyy HH:mm:ss") & "#, EVENTO = " & evt & ", DESCRIPCION = '" & desc & "'"
            Else
                consulta = "INSERT INTO cuentas (CUENTA, [LAST], EVENTO, DESCRIPCION) VALUES ('" & cu & "', #" & Now.ToString("dd/MM/yyyy HH:mm:ss") & "#, " & evt.ToString & ", '" & desc & "')"
            End If
            comando = New OleDbCommand(consulta, conexion3)
            comando.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            If conexion3.State = ConnectionState.Open Then conexion3.Close()
            refreshtablas()
        End Try
    End Sub
    Function IfExists(cuenta_ As String, closeconn As Boolean) As Boolean
        Dim returneo As Boolean = False
        Try
            If conexion.State <> ConnectionState.Open Then conexion.Open()
            Dim adaptador As New OleDbDataAdapter("Select * FROM cuentas WHERE CUENTA='" & cuenta_ & "'", conexion)
            Dim datoss As New DataSet
            adaptador.Fill(datoss, "cuentas")
            If datoss.Tables.Count = 0 Or datoss.Tables(0).Rows.Count = 0 Then
                returneo = False
            Else
                returneo = True
            End If
        Catch ex As Exception
        Finally
            If closeconn Then conexion.Close()
        End Try
        Return returneo
    End Function
    Sub refreshtablas()
        refreshh = New Thread(AddressOf refreshtablas1)
        refreshh.Start()
    End Sub
    Sub refreshtablas1()
        Dim adaptador As New OleDbDataAdapter
        Dim conexion2 As New OleDbConnection(conexion.ConnectionString)
        'Try
        If conexion2.State = ConnectionState.Closed Then conexion2.Open()
        While conexion2.State <> ConnectionState.Open
        End While
        Dim consulta As String
        consulta = "SELECT FECHAHORA, CUENTA, EVENTO, DESCRIPCION, NOMBREALARMA FROM datos"
        adaptador = New OleDbDataAdapter(consulta, conexion2)
        data1 = New DataSet
        Dim int As Integer
        Try
            int = adaptador.Fill(data1, "datos")
        Catch ex As Exception
            int = 1
        End Try
        Dim i As Integer = 1
        While int = 0 And i < 15
            i += 1
        End While
        If data1.Tables.Count <> 0 Then
            Try
                data1.Tables(0).Columns(0).ColumnName = "Fecha y hora"
                data1.Tables(0).Columns(1).ColumnName = "Cuenta"
                data1.Tables(0).Columns(2).ColumnName = "Evento"
                data1.Tables(0).Columns(3).ColumnName = "Descripción"
                data1.Tables(0).Columns(4).ColumnName = "Nombre de alarma"
            Catch ex As Exception
            End Try
        End If
        consulta = "SELECT CUENTA, LAST, EVENTO, DESCRIPCION FROM cuentas"
        adaptador = New OleDbDataAdapter(consulta, conexion2)
        data2 = New DataSet
        int = adaptador.Fill(data2, "cuentas")
        i = 1
        While int = 0 And i < 15
            i += 1
        End While
        If data2.Tables.Count <> 0 Then
            Try
                data2.Tables(0).Columns(0).ColumnName = "Cuenta"
                data2.Tables(0).Columns(1).ColumnName = "Última transmisión"
                data2.Tables(0).Columns(2).ColumnName = "Evento"
                data2.Tables(0).Columns(3).ColumnName = "Descripción"
            Catch ex As Exception
            End Try
        End If
        'Catch ex As Exception
        '    MsgBox("Ha ocurrido un error al intentar refrescar las tablas. Por favor avise al administrador del sistema.", vbExclamation, "Error")
        '    End
        'Finally
        If conexion2.State <> ConnectionState.Closed Then conexion2.Close()
        'End Try
        BeginInvoke(New delegado(AddressOf refreshtablas2))
    End Sub
    Delegate Sub delegado()
    Sub refreshtablas2()
        If data1.Tables.Count > 0 Then todos.DataSource = data1.Tables(0)
        If data2.Tables.Count > 0 Then cuentas.DataSource = data2.Tables(0)
        todos.FirstDisplayedScrollingRowIndex = todos.RowCount - 1
    End Sub
    Sub timearr()
        timear = New Thread(AddressOf checktime)
        timear.Start()
    End Sub
    Private Sub TextChangedd1(sender As Object, e As EventArgs) Handles realtxt.TextChanged
        Dim SelectionIndex As Integer = realtxt.SelectionStart
        realtxt.Text = realtxt.Text.ToUpper
        realtxt.Select(SelectionIndex, 0)
        reemplazar(realtxt)
        Dim textotemp As String = Nothing
        codedtxt.Text = Nothing
        For i As Integer = 1 To realtxt.Text.Length
            Dim s As Integer = findbystr(Mid(realtxt.Text, i, 1), numeroscode)
            If s >= 10 Then
                textotemp &= Conversion.Hex(s)
            Else
                textotemp &= CStr(s)
            End If
        Next
        codedtxt.Text = textotemp
    End Sub
    Function findbystr(str As String, arr As String()) As Integer
        For i As Integer = 0 To UBound(arr)
            If arr(i) = str Then Return i
        Next
        Return Nothing
    End Function
    Sub reemplazar(con As TextBox)
        Dim theText As String = con.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = con.SelectionStart
        Dim Change As Boolean = False
        For x As Integer = 1 To con.Text.Length
            Letter = Mid(con.Text, x, 1)
            If caracteres.Contains(Letter) = False Then
                theText = theText.Replace(Letter, "")
                Change = True
            End If
        Next
        con.Text = theText
        If Change Then
            con.Select(SelectionIndex, 0)
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists("db.conf") = False Then
            Dim formm2 As New Form2
            formm2.ShowDialog()
        ElseIf File.Exists(File.ReadAllLines("db.conf")(0)) = False Then
            File.Delete("db.conf")
            Dim formm2 As New Form2
            formm2.ShowDialog()
        End If
        If File.Exists("configs.conf") Then
            configs = File.ReadAllLines("configs.conf")
            If configs(0) = "True" Then enviardatos.Checked = True
            iptxt.Text = configs(1)
            puertotxt.Text = configs(2)
            heartbittiempo.Text = configs(3)
            If configs(4) = "True" Then heartbitenviar.Checked = True
        End If
        Dim lines As String() = File.ReadAllLines("db.conf")
        conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & lines(0)
        TabControl1.SelectedIndex = 2
        refreshtablas1()
        iptxt.Enabled = enviardatos.Checked
        puertotxt.Enabled = enviardatos.Checked
        heartbitenviar.Enabled = enviardatos.Checked
        Label2.Enabled = enviardatos.Checked
        Label3.Enabled = enviardatos.Checked
        heartbittiempo.Enabled = True
    End Sub
    Sub checktime()
        Do
            Dim conexioncomoestaba As ConnectionState = conexion.State
            Try
                If conexion.State <> ConnectionState.Open Then conexion.Open()
                Dim adaptador As New OleDbDataAdapter("SELECT CUENTA, LAST FROM cuentas", conexion)
                Dim datoss As New DataSet
                adaptador.Fill(datoss)
                If datoss.Tables.Count <> 0 Or datoss.Tables(0).Rows.Count <> 0 Then
                    For Each fila As DataRow In datoss.Tables(0).Rows
                        Dim tiempo As Date = fila.Item(1)
                        If Date.Compare(tiempo, Now) > 0 Then
                            Dim a As Integer = getrowindex(fila.Item(0))
                            For j = 0 To cuentas.Rows.Count - 1
                                cuentas.Rows(a).DefaultCellStyle.BackColor = Color.Red
                            Next
                        End If
                    Next
                End If
            Catch ex As Exception
            Finally
                If conexioncomoestaba <> ConnectionState.Open Then conexion.Close()
            End Try
        Loop
    End Sub
    Function getrowindex(cuenta__ As String) As Integer
        For i = 0 To cuentas.Rows.Count - 1
            If cuentas.Rows(i).Cells(0).Value = cuenta__ Then Return i
        Next
        Return Nothing
    End Function
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.Closing
        If looop IsNot Nothing Then
            If looop.IsAlive Then looop.Abort()
        End If
        If File.Exists("configs.conf") Then File.Delete("configs.conf")
        File.WriteAllLines("configs.conf", configs)
    End Sub
End Class
Public Class POP3
    Dim TCP As TcpClient
    Dim POP3Stream As Stream
    Dim inStream As StreamReader
    Dim strDataIn, strNumMains(2) As String
    Dim intNoEmails As Integer

    'Class to connect to the passed mail server on port 110
    Function POPConnect(ByVal strServer As String, ByVal strUserName As String, ByVal strPassword As String, port As Integer) As Boolean

        'connect to the pop3 server over port 110
        Try
            TCP = New TcpClient
            TCP.Connect(strServer, port)

            'create stream into the ip
            POP3Stream = TCP.GetStream
            inStream = New System.IO.StreamReader(POP3Stream)

            'Make sure we get the ok back from the server
            If WaitFor("+OK") = False Then Return False

            'send the email down 
            SendData("USER " & strUserName)
            If WaitFor("+OK") = False Then Return False

            SendData("PASS " & strPassword)
            If WaitFor("+OK") = False Then Return False
            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function

    'Function to get the number of mail messages waiting on the server
    Function GetMailStat() As Integer

        'send the stat command and make sure it returns as expected
        ' Try
        SendData("STAT")
        If WaitFor("+OK") = False Then
            Return 0
        Else
            'split up the response. It should be +OK Num of emails size of emails
            strNumMains = Split(strDataIn, " ")
            Return strNumMains(1)
            intNoEmails = strNumMains(1)
        End If
        'Catch ex As Exception
        Return 0
        intNoEmails = 0
        ' End Try
    End Function
    'function to take in what we expect and compare to what we actually get back
    Public Function WaitFor(ByVal strTarget As String) As Boolean
        strDataIn = inStream.ReadLine
        If strDataIn.Contains(strTarget) = True Then
            Return True
        Else
            Return False
        End If

    End Function

    'This function will get the email message of the pop3 server, based on the message number passed
    Public Function GetMailMessage(ByVal intNum As Integer) As String

        Dim strTemp As String
        Dim strEmailMess As String = ""
        Try
            'send the command to the server to return that email back. Command is RETR and the email no ie RETR 1
            SendData("RETR " & Str(intNum))
            'make sure we get a proper response back
            If WaitFor("+OK") = False Then

                Return "No Email was Retrived"
            End If

            'Should be ok at this point to read in the tcp stream. We read it in until the end of the email
            'whitch is signified by a line containing only a fullpoint(chr46)
            strTemp = inStream.ReadLine

            While (strTemp <> ".")
                strEmailMess = strEmailMess & strTemp & vbCrLf
                strTemp = inStream.ReadLine
            End While

            Return strEmailMess

        Catch ex As Exception
            'just return an error message if we fell over
            Return "No Email was Retrived"
        End Try

    End Function

    'function that will mark an email for deletion. Delete does not occur until the QUIT is issued to the server
    Function MarkForDelete(ByVal intMailItem As Integer) As Boolean
        Return True
    End Function

    'Function that will quit the connection to the server (deleting marked mail) and close open readers etc
    Sub CloseConn()

        Try
            SendData("QUIT")
            inStream.Close()
            POP3Stream.Close()
        Catch ex As Exception
            Form1.escribirenlog(ex.ToString)
        End Try

    End Sub

    'function to send data down the tcp pipe
    Public Sub SendData(ByVal strCommand As String)

        Dim outBuff As Byte()

        outBuff = ConvertStringToByteArray(strCommand & vbCrLf)
        POP3Stream.Write(outBuff, 0, strCommand.Length + 2)

    End Sub

    Public Shared Function ConvertStringToByteArray(ByVal stringToConvert As String) As Byte()
        Return (New System.Text.ASCIIEncoding).GetBytes(stringToConvert)
    End Function

End Class
Public Class EmailMessage

    Private m_MessageSource As String

    'function that will call the main proc with what to bring back for everything but the body text
    Public Function ParseEmail(ByVal strMessage As String, ByVal strType As String) As String

        m_MessageSource = strMessage

        'call the parse routine with the pass filed we want
        ParseEmail = ParseHeader(strType)

    End Function

    'Function to parse each of the header parts out of the email
    Private Function ParseHeader(ByVal strHeader As String) As String

        Dim intLenToStart As Integer
        Dim intLenToLineEnd As Integer
        Dim strTmp As String

        intLenToStart = (InStr(m_MessageSource, strHeader) - 1)
        intLenToLineEnd = InStr(Mid(m_MessageSource, intLenToStart), vbCrLf)
        strTmp = m_MessageSource.Substring(intLenToStart, intLenToLineEnd)

        ParseHeader = Replace(strTmp, vbCrLf, "")

    End Function

    'Funtion to parse out the email body 
    Public Function ParseBody() As String

        'To get the body, everything after the first null line of the message is it (rfc822)
        Dim strTmp As String

        'set the temp var to the message body by getting everything after the null line
        strTmp = m_MessageSource.Substring(m_MessageSource.IndexOf(vbCrLf + vbCrLf))

        'get the encoding of the message out, that way we know if we have to run it through the base64 decode
        'routine or not
        If InStr(m_MessageSource, "Content-Transfer-Encoding: base64") Then
            'call the decode routine
            strTmp = DecodeBase64(strTmp)
        End If

        'if the jobs got html content, remove that from the body
        If InStr(strTmp, "------_=_NextPart_") Then
            strTmp = strTmp.Substring(1, strTmp.IndexOf(vbCrLf & vbCrLf & vbCrLf & "------_=_NextPart_"))
        End If


        'Strip out the odd hex that apears at the start and the end
        strTmp = Replace(strTmp, Chr(10) & Chr(9), "")
        strTmp = Replace(strTmp, Chr(13), "")

        ParseBody = Trim(strTmp)

    End Function

    'Function that will decode base64 encoded email body
    Private Function DecodeBase64(ByVal strBody As String)

        Try
            Dim encoding As New System.Text.UTF8Encoding
            Dim Buffer As Byte() = Convert.FromBase64String(strBody)
            DecodeBase64 = encoding.GetString(Buffer)
            encoding = Nothing
            Buffer = Nothing
        Catch ex As Exception
            MsgBox("A problem occured while decoding a base64 email", MsgBoxStyle.Critical)
            DecodeBase64 = "ERROR"
            Exit Function
        End Try

    End Function


End Class