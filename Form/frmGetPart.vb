﻿Imports System.Windows.Forms
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor

Public Class frmGetPart

    '添加
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Try
        SetStatusBarText()

        If IsInventorOpenDoc() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information, "统计质量面积")
            Exit Sub
        End If

        Dim oSelectSet As Inventor.SelectSet
        oSelectSet = oInventorDocument.SelectSet

        If oSelectSet.Count = 0 Then
            MsgBox("请先选择零部件", MsgBoxStyle.OkOnly, "统计质量面积")
            Exit Sub
        End If

        For Each oSelect As Object In oInventorDocument.SelectSet
            'Dim
            'If (oSelect.GetType Is ) = True Then
            'Dim FullFileName As String
            'Dim FNI As FileNameInfo

            'FullFileName = oSelect.name

            'FNI = GetFileNameInfo(FullFileName)

            Dim LVI As ListViewItem
            'LVI = ListView1.Items.Add(FNI.ONlyName)
            LVI = lvwFileList.Items.Add(oSelect.name)

            Dim 数量 As Integer = 1
            '数量 = InputBox("输入数量", "数量", "1")
            LVI.SubItems.Add(数量)

            'Dim InventorDoc2 As Inventor.Document
            'InventorDoc2 = ThisApplication.Documents.Open(FullFileName, False)
            'LVI.SubItems.Add(GetMass(InventorDoc2) * 数量)
            'LVI.SubItems.Add(GetArea(InventorDoc2) * 数量)

            Dim valMass As Double
            valMass = oSelect.MassProperties.mass
            valMass = valMass + 0.00000001

            Dim Val_Mass_Accuracy As Integer
            Val_Mass_Accuracy = Val(Mass_Accuracy)
            valMass = Math.Round(valMass, Val_Mass_Accuracy)

            Dim valArea As Double
            valArea = oSelect.MassProperties.area / 10000
            valArea = valArea + 0.00000001

            Dim Val_Area_Accuracy As Integer
            Val_Area_Accuracy = Val(Area_Accuracy)
            valArea = Math.Round(valArea, Val_Area_Accuracy)

            LVI.SubItems.Add(valMass * 数量)
            LVI.SubItems.Add(valArea * 数量)
            'End If
        Next

        Dim SumMass As Double = 0
        Dim SumArea As Double = 0

        For Each LVI As ListViewItem In lvwFileList.Items
            SumMass = SumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
            SumArea = SumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
        Next

        txtWeight.Text = SumMass
        txtArea.Text = SumArea

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    '移出
    Private Sub btnMoveOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveOut.Click
        ListViewDel(lvwFileList)
        Dim SumMass As Double = 0
        Dim SumArea As Double = 0

        For Each LVI As ListViewItem In lvwFileList.Items
            SumMass = SumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
            SumArea = SumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
        Next

        txtWeight.Text = SumMass
        txtArea.Text = SumArea
    End Sub

    '退出
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        lvwFileList.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '移出项
    Private Sub ListViewDel(ByVal ListView As ListView)
        For i As Integer = ListView.SelectedIndices.Count - 1 To 0 Step -1
            ListView.Items.RemoveAt(ListView.SelectedIndices(i))
        Next
    End Sub

    '清空
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lvwFileList.Items.Clear()
        txtWeight.Clear()
        txtArea.Clear()
    End Sub

    '复制总质量到剪贴板
    Private Sub btnCopyG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyG.Click
        My.Computer.Clipboard.SetText(txtWeight.Text)
    End Sub

    '复制总面积到剪贴板
    Private Sub btnCopyA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyA.Click
        My.Computer.Clipboard.SetText(txtArea.Text)
    End Sub

End Class