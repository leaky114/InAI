﻿Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports System.Windows.Forms

Public Class frmStatisticalWeight

    Private dblSumMass As Double = 0
    Private dblSumArea As Double = 0

    '添加
    Private Sub btn添加_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn选择零件.Click

        Try
            Dim oPart As ComponentOccurrence

            Do
                oPart = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAssemblyOccurrenceFilter, "选择一个零件，ESC键取消")


                Dim oListViewItem As ListViewItem
                'LVI = ListView1.Items.Add(FNI.ONlyName)
                oListViewItem = lvw文件列表.Items.Add(oPart.Name)

                Dim intQuantity As Integer = 1
                '数量 = InputBox("输入数量", "数量", "1")
                oListViewItem.SubItems.Add(intQuantity)

                'Dim InventorDoc2 As Inventor.Document
                'InventorDoc2 = ThisApplication.Documents.Open(FullFileName, False)
                'LVI.SubItems.Add(GetMass(InventorDoc2) * 数量)
                'LVI.SubItems.Add(GetArea(InventorDoc2) * 数量)

                Dim dblMass As Double
                dblMass = oPart.MassProperties.Mass
                dblMass = dblMass + 0.00000001

                Dim intMassAccuracy As Integer
                intMassAccuracy = Val(Mass_Accuracy)
                dblMass = Math.Round(dblMass, intMassAccuracy)

                Dim dblArea As Double
                dblArea = oPart.MassProperties.Area / 10000
                dblArea = dblArea + 0.00000001

                Dim Val_Area_Accuracy As Integer
                Val_Area_Accuracy = Val(Area_Accuracy)
                dblArea = Math.Round(dblArea, Val_Area_Accuracy)

                oListViewItem.SubItems.Add(dblMass * intQuantity)
                oListViewItem.SubItems.Add(dblArea * intQuantity)

                For Each LVI As ListViewItem In lvw文件列表.Items
                    dblSumMass = dblSumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
                    dblSumArea = dblSumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
                Next

                txt质量.Text = dblSumMass.ToString
                txt面积.Text = dblSumArea.ToString


            Loop While True



        Catch ex As Exception


        End Try


        ''Try
        'SetStatusBarText()

        'If IsInventorOpenDocument() = False Then
        '    Exit Sub
        'End If

        'Dim oInventorDocument As Inventor.Document
        'oInventorDocument = ThisApplication.ActiveDocument

        'If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
        '    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information, "统计质量面积")
        '    Exit Sub
        'End If

        'Dim oSelectSet As Inventor.SelectSet
        'oSelectSet = oInventorDocument.SelectSet

        'If oSelectSet.Count = 0 Then
        '    MsgBox("请先选择零部件", MsgBoxStyle.OkOnly, "统计质量面积")
        '    Exit Sub
        'End If


        ''Dim Types As ObjectTypeEnum() = [Enum].GetValues(GetType(ObjectTypeEnum))

        'Dim oPart As ComponentOccurrence

        'For Each oSelect As Object In oSelectSet
        '    'For Each Type As ObjectTypeEnum In Types
        '    If oSelect.Type = Inventor.ObjectTypeEnum.kComponentOccurrenceObject Then
        '        oPart = oSelect


        '        Dim oListViewItem As ListViewItem
        '        'LVI = ListView1.Items.Add(FNI.ONlyName)
        '        oListViewItem = lvw文件列表.Items.Add(oSelect.name)

        '        Dim intQuantity As Integer = 1
        '        '数量 = InputBox("输入数量", "数量", "1")
        '        oListViewItem.SubItems.Add(intQuantity)

        '        'Dim InventorDoc2 As Inventor.Document
        '        'InventorDoc2 = ThisApplication.Documents.Open(FullFileName, False)
        '        'LVI.SubItems.Add(GetMass(InventorDoc2) * 数量)
        '        'LVI.SubItems.Add(GetArea(InventorDoc2) * 数量)

        '        Dim dblMass As Double
        '        dblMass = oSelect.MassProperties.mass
        '        dblMass = dblMass + 0.00000001

        '        Dim intMassAccuracy As Integer
        '        intMassAccuracy = Val(Mass_Accuracy)
        '        dblMass = Math.Round(dblMass, intMassAccuracy)

        '        Dim dblArea As Double
        '        dblArea = oSelect.MassProperties.area / 10000
        '        dblArea = dblArea + 0.00000001

        '        Dim Val_Area_Accuracy As Integer
        '        Val_Area_Accuracy = Val(Area_Accuracy)
        '        dblArea = Math.Round(dblArea, Val_Area_Accuracy)

        '        oListViewItem.SubItems.Add(dblMass * intQuantity)
        '        oListViewItem.SubItems.Add(dblArea * intQuantity)

        '        'Exit For
        '    End If
        '    'Next
        'Next


        'Dim dblSumMass As Double = 0
        'Dim dblSumArea As Double = 0

        'For Each LVI As ListViewItem In lvw文件列表.Items
        '    dblSumMass = dblSumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
        '    dblSumArea = dblSumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
        'Next

        'txt质量.Text = dblSumMass.ToString
        'txt面积.Text = dblSumArea.ToString

        ''Catch ex As Exception
        ''    MsgBox(ex.Message)
        ''End Try
    End Sub

    '移出
    Private Sub btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click
        ListViewDel(lvw文件列表)
        Dim dblSumMass As Double = 0
        Dim dblSumArea As Double = 0

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            dblSumMass = dblSumMass + oListViewItem.SubItems(1).Text * oListViewItem.SubItems(2).Text
            dblSumArea = dblSumArea + oListViewItem.SubItems(1).Text * oListViewItem.SubItems(3).Text
        Next

        txt质量.Text = dblSumMass
        txt面积.Text = dblSumArea
    End Sub

    '退出
    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        lvw文件列表.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '清空
    Private Sub btn清空_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空.Click
        lvw文件列表.Items.Clear()
        txt质量.Text = 0
        txt面积.Text = 0
    End Sub

    '复制总质量到剪贴板
    Private Sub btn复制质量_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制质量.Click
        My.Computer.Clipboard.SetText(txt质量.Text)
    End Sub

    '复制总面积到剪贴板
    Private Sub btn复制面积_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制面积.Click
        My.Computer.Clipboard.SetText(txt面积.Text)
    End Sub

    Private Sub frmStatisticalWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(btn选择零件, "选择一个零件")
        toolTip.SetToolTip(btn复制质量, "复制质量")
        toolTip.SetToolTip(btn复制面积, "复制面积")

        btn选择零件.Image = My.Resources.选择面和边32.ToBitmap
        btn复制面积.Image = My.Resources.复制16.ToBitmap
        btn复制质量.Image = My.Resources.复制16.ToBitmap

        txt质量.Text = "0"
        txt面积.Text = "0"

    End Sub
End Class