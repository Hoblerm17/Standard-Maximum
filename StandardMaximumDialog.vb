Public Class StandardMaximumDialog
    Dim MROW As Integer
    Dim N As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        STANDARD_MAX(B(1, 1), A(1, 1), MROW, 1, "")
    End Sub

    Private Function B(v1 As Integer, v2 As Integer) As Double(,)
        Throw New NotImplementedException()
    End Function

    Private Function A(v1 As Integer, v2 As Integer) As Double(,)
        Throw New NotImplementedException()
    End Function

    Private Sub StandardMaximumDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Req As String
        Dim Title As String
        Req = "Enter number of variables in your system"
        Title = "Number of Variables Request"
        N = InputBox(Req, Title, Str(2))
        Req = "Enter number of constraints in your system"
        Title = "Number of Constraints Request"
        MROW = InputBox(Req, Title, Str(2))

        Dim i As Integer
        For i = 1 To N
            Grid1.Columns.Add("Column" + Str(i - 1), "X" + Str(i))
        Next
        Grid1.Columns.Add("Column" + Str(N), "B")
        Grid1.Rows.Add(MROW + 1)
        Grid1.AllowUserToAddRows = False
        Grid1.RowHeadersWidth = 125
        Grid1.Columns.Item(N).Width = 150
        For i = 1 To MROW
            Grid1.Rows.Item(i - 1).HeaderCell.Value = "Constraint" + Str(i)
        Next
        Grid1.Rows.Item(MROW).HeaderCell.Value = "Objective Fct"
        Grid1.BackgroundColor = Color.White

        Grid2.Columns.Add("Column1", "Solution")
        Grid2.Rows.Add(N + 1)
        Grid2.AllowUserToAddRows = False
        Grid2.RowHeadersWidth = 100
        For i = 1 To N
            Grid2.Rows.Item(i - 1).HeaderCell.Value = "X" + Str(i)
        Next
        Grid2.Rows.Item(N).HeaderCell.Value = "Maximum"
        Grid2.Columns.Item(0).Width = 375
        Grid2.BackgroundColor = Color.White

        Button2.Text = "Solve Standard Maximum Linear Program"
        Text1.Visible = False
        Me.Text = "Solution of a Linear Program"
    End Sub
End Class
