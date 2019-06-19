Public Module Extensions
    <System.Runtime.CompilerServices.Extension>
    Public Function IsComboBoxCell(ByVal sender As DataGridViewCell) As Boolean
        Dim result As Boolean = False

        If sender.EditType IsNot Nothing Then
            If sender.EditType Is GetType(DataGridViewComboBoxEditingControl) Then
                result = True
            End If
        End If
        Return result

    End Function
End Module