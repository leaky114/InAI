﻿Imports System.Windows.Forms
'Imports FSLib.App.SimpleUpdater
Imports System.IO

Public Class frmUpdate

    Const InNewVison As String = "\\Likai-pc\发行版\2011\NewVersion.txt"
    Const ChangeLog As String = "\\Likai-pc\发行版\2011\CHANGELOG"

    Const GitWeb As String = "https://gitcode.net/leaky114/inventoraddin"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
       
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub frmUpdate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Select Case CheckUpdate
                Case "-1"
                    chk检查更新.Checked = False
                Case "1"
                    chk检查更新.Checked = True
            End Select


            Dim MyVersion As String = _
            My.Application.Info.Version.Major & "." & _
            My.Application.Info.Version.Minor & "." & _
            Format(My.Application.Info.Version.Build, "00") & "." & _
           Format(My.Application.Info.Version.Revision, "00")



            'MsgBox(MyVersion)

            If NewVersion Is Nothing Then
                'MsgBox("未链接到服务器。", MsgBoxStyle.OkOnly, "检查更新")
                Me.Close()
            Else
                Dim shortMyversion As Long
                Dim shortNewVersion As Long

                shortMyversion = ShortVersion(MyVersion)
                shortNewVersion = ShortVersion(NewVersion)

                If shortNewVersion > shortMyversion Then
                    'MsgBox("InventorAddIn插件" & vbCrLf & "当前版本：" & MyVersion & vbCrLf & "检查到 新版本：" & NewVersion, MsgBoxStyle.OkOnly, " 检查更新")
                    lblLocalVersion.Text = "当前版本：" & MyVersion
                    lblNewVersion.Text = "可更新版：" & NewVersion

                    '读取更新日志
                    Dim readText As String = File.ReadAllText(ChangeLog)
                    txtWhatNew.Text = readText
                    'Me.ShowDialog()
                Else
                    If IsShowUpdateMsg = True Then
                        MsgBox("当前为最新版。", MsgBoxStyle.OkOnly, "检查更新")
                    End If
                    Me.Close()
                End If

            End If
        Catch ex As Exception

            'MsgBox(ex.Message)
            'MsgBox("未链接到服务器。", MsgBoxStyle.OkOnly, "检查更新")
            Me.Close()
        End Try
    End Sub

End Class
