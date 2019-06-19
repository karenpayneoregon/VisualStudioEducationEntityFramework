Public Class Form1
    Private _comboColumnName As String = "C1"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim source = {"Add", "Subtract", "Divide", "Multiply"}

        Dim dataGridViewCellStyle1 = New DataGridViewCellStyle With
                {
                    .Alignment = DataGridViewContentAlignment.MiddleLeft
                }

        Dim column1 = New DataGridViewComboBoxColumn With
                {
                    .DataSource = source,
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                    .DefaultCellStyle = dataGridViewCellStyle1,
                    .Name = _comboColumnName, .HeaderText = "Demo",
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                }

        Dim column2 = New DataGridViewCheckBoxColumn With {.Name = "C2", .HeaderText = "Col 2"}

        Dim column3 = New DataGridViewTextBoxColumn With {.Name = "C3", .HeaderText = "Col 3"}

        DataGridView1.Columns.AddRange(column1, column2, column3)

        DataGridView1.Rows.Add("Divide", True, "Karen")
        DataGridView1.Rows.Add("Add", False, "Kevin")
        DataGridView1.Rows.Add("Subtract", True, "Anne")
        DataGridView1.Rows.Add("Add", True, "Joe")
        DataGridView1.Rows.Add("Multiply", True, "Jean")
    End Sub
End Class