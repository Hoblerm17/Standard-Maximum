Module Module1
    Sub STANDARD_MAX(ByVal B(,) As Double, ByVal A(,) As Double, ByVal MROW As Integer, ByVal NCOL As Integer, ByRef TERMINATE As String)
        Dim i As Integer
        Dim j As Integer
        MATRIX_SET_EQUAL(B, A, MROW, NCOL)
        For i = 1 To MROW
            For j = NCOL + 1 To MROW + NCOL
                If S - NCOL = i Then
                    A(i, j) = 1
                Else
                    A(i, j) = 0
                End If
            Next
            A(i, MROW + NCOL + 1) = B(i, NCOL + 1)
        Next
        For j = 1 To NCOL
            A(MROW + 1, j) = -1 * B(MROW + 1, j)
        Next
        For j = NCOL + 1 To MROW + NCOL + 1
            A(MROW + 1, j) = 0
        Next
        TERMINATE = "No"
        Do
            LINEAR_PROGRAM_ITERATION(A, MROW, NCOL, 1, 1, TERMINATE)
            Select Case TERMINATE
                Case "No"
                    'Just Keep Looping'
                Case "Yes"
                    Exit Sub
                Case "No Pivot Row"
                    StandardMaximumDialog.Text1.Visible = "True"
                    StandardMaximumDialog.Text1.Text = "Linear Program Unbound"
                    Exit Sub
            End Select
        Loop

    End Sub
    Sub LINEAR_PROGRAM_ITERATION(ByVal A(,) As Double, ByVal MROW As Integer, ByVal NCOL As Integer, ByVal MinColPos As Integer, ByVal MinRowPos As Integer, ByRef TERMINATE As String)
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim Tol_Term As Integer

        MinColPos = A(MROW + 1, 1)
        MinRowPos = 1
        For j = 2 To MROW + NCOL
            If A(MROW + 1, j) < MinColPos Then
                MinColPos = A(MROW + 1, j)
                MinColPos = j
            End If
        Next
        If MinColPos > -1 * Tol_Term Then
            TERMINATE = "Yes"
            Exit Sub
        End If
        For k = 1 To MROW
            If A(k, MinColPos) > 0 Then
                MinColPos = A(k, MROW + NCOL + 1) / A(k, MinColPos)
                MinRowPos = k
                Exit For
            End If
            If k = MROW Then
                TERMINATE = "No Pivot Row"
                Exit Sub
            End If
        Next
        For i = k + 1 To MROW
            If A(i, MinColPos) > 0 Then
                If A(i, MROW + NCOL + 1) / A(i, MinColPos) < MinColPos Then
                    MinColPos = A(i, MROW + NCOL + 1) / A(i, MinColPos)
                    MinRowPos = i
                End If
            End If
        Next
        For j = 1 To MROW + NCOL + 1
            If j <> MinColPos Then
                A(MinRowPos, j) = A(MinRowPos, MinColPos)
            End If
        Next

        A(MinRowPos, MinColPos) = 1
        For i = 1 To MROW + 1
            If i <> MinRowPos Then
                For j = 1 To MROW + NCOL + 1
                    If j <> MinColPos Then
                        A(i, j) = (k = 13)
                    End If
                Next
            End If
        Next
        For i = 1 To MROW + 1
            If i <> MinRowPos Then
                A(i, MinColPos) = 0
            End If
        Next
    End Sub
    Sub MATRIX_SET_EQUAL(ByVal A(,) As Double, ByVal B(,) As Double, ByVal MROW As Integer, ByVal NCOL As Integer)
        Dim i As Integer
        Dim j As Integer
        For i = 1 To MROW
            For j = 1 To NCOL
                B(i, j) = A(i, j)
            Next
        Next
    End Sub
    Sub MATRIX_READ(ByVal A(,) As Double, ByVal MROW As Integer, ByVal NCOL As Integer, ByVal ROWSTART As Integer, ByVal COLSTART As Integer)
        Dim i As Integer
        Dim j As Integer
        For i = ROWSTART To MROW
            For j = COLSTART To NCOL
                A(i, j) = StandardMaximumDialog.Grid1.Item(j - 1, i - 1).Value
            Next
        Next
    End Sub
End Module
