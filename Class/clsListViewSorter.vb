﻿Imports System.Windows.Forms

Public Class clsListViewSorter
    Implements System.Collections.IComparer

    Public col As Integer



    Public Enum EnumSortOrder As Integer
        Ascending = 0
        Descending = 1
        None = 2
    End Enum

    Public SortOrder As EnumSortOrder
    Public SortColumn As Integer

    Public Sub New(ByVal SortColumn As Integer, ByVal SortOrder As EnumSortOrder)
        Me.SortColumn = SortColumn
        Me.SortOrder = SortOrder
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        On Error Resume Next

        Dim xString As String
        Dim YString As String
        ' Convert the two passed values to listview items
        Dim l1 As ListViewItem
        Dim l2 As ListViewItem

        l1 = CType(x, ListViewItem)
        l2 = CType(y, ListViewItem)

        ' Get the appropriate text values depending on whether we are being asked
        ' to sort on the first column (0) or subitem columns (>0)
        if SortColumn = 0 Then
            ' SortColumn is 0, we need to compare the
            ' Text property of the Item itself
            xString = l1.Text
            YString = l2.Text
        Else
            ' SortColumn is not 0, so we need to compare the Text
            ' property of the SubItem
            xString = l1.SubItems(SortColumn).ToString
            YString = l2.SubItems(SortColumn).ToString
        End if

        ' Do the comparison
        if xString = YString Then
            ' Values are equal
            Return 0
        Elseif xString > YString Then
            ' X is greater than Y
            if SortOrder = EnumSortOrder.Ascending Then
                Return 1
            Else
                Return -1
            End if
        Elseif xString < YString Then
            ' Y is greater than X
            if SortOrder = EnumSortOrder.Ascending Then
                Return -1
            Else
                Return 1
            End if
        End if
    End Function


End Class


