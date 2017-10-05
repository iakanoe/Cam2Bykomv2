Public Class Form2
    Public db As String
    Private Sub nobtn_Click(sender As Object, e As EventArgs) Handles nobtn.Click
        End
    End Sub
    Private Sub sibtn_Click(sender As Object, e As EventArgs) Handles sibtn.Click
        SaveFileDialog1.ShowDialog()
    End Sub
    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        IO.File.WriteAllLines("db.conf", {SaveFileDialog1.FileName})
        IO.File.Copy("db.byte", SaveFileDialog1.FileName)
        Close()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaveFileDialog1.Filter = "Archivo de base de datos|*.accdb"
    End Sub

End Class