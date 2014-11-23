Public Class frmMain
    Private percentOfLoad As Integer = 0
    Private cores As Integer = 1
    Private random As New Random
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.AboveNormal
        For i = 1 To 4
            Dim thread As New Threading.Thread(AddressOf Loader)
            thread.Priority = Threading.ThreadPriority.BelowNormal
            thread.Start(i)
        Next
    End Sub

    Private Sub Loader(ByVal coreNum As Integer)
        Dim a, b, c, d As Integer
        Dim e, f, g, h As Double
        Do
            If coreNum > cores Then
                Threading.Thread.Sleep(500)
            Else
                Dim t = Now
                a = random.Next >> 16
                b = random.Next >> 16
                c = a + b + a + b
                d = a + c + b
                a = b + c
                e = random.NextDouble
                f = random.NextDouble
                g = e * f
                h = g + e + f
                Do While (Now - t).TotalMilliseconds < percentOfLoad
                Loop
                Threading.Thread.Sleep(100 - percentOfLoad)
            End If
        Loop
    End Sub

    Private Sub tbCores_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCores.Scroll
        cores = tbCores.Value
    End Sub

    Private Sub tbLoad_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbLoad.Scroll
        percentOfLoad = tbLoad.Value
    End Sub
End Class
