''撤销功能
'Dim oTransaction As Transaction
'oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")
'==========================
'If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
'MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
'Exit Sub
'End If

'Dim oInventorDrawingDocument As Inventor.DrawingDocument
'oInventorDrawingDocument = ThisApplication.ActiveDocument

'=======================
'If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
'MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
'Exit Sub
'End If

'Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
'oInventorAssemblyDocument = ThisApplication.ActiveDocument
'===========================
' If IsInventorOpenDocument() = False Then
'            Exit Sub
'        End If

'        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject And ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
'            MsgBox("该功能仅适用于零部件。", MsgBoxStyle.Information)
'            Exit Sub
'        End If

'Dim oInventorDocument As Inventor.Document
'        oInventorDocument = ThisApplication.ActiveDocument
'        ======================================================

'Dim oInventorDocument As Inventor.Document
'            oInventorDocument = ThisApplication.ActiveDocument

'            ================================
Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Microsoft
Imports Microsoft.VisualBasic
Imports Microsoft.Win32
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace InventorAddIn

    <ProgIdAttribute("InventorAddIn.StandardAddInServer"), _
    GuidAttribute("0a8e6d1d-68ec-48be-9e61-32779d2aae77")> _
    Public Class StandardAddInServer
        Implements Inventor.ApplicationAddInServer

#Region "Data Member"

        '============================================================
        '定义 按钮
        '
        '获取文件名修改iProperty           1
        Private WithEvents m_修改文件iProperty_Buttondef As Inventor.ButtonDefinition

        '获取部件子集修改iProperty           2
        Private WithEvents m_修改部件iProperty_Buttondef As Inventor.ButtonDefinition

        '更改文件名     3
        Private WithEvents m_更改文件名_Buttondef As Inventor.ButtonDefinition

        '提取iProperty更改文件名        4
        Private WithEvents m_提取iPro修改文件名_Buttondef As Inventor.ButtonDefinition

        '自动生成零件图号       5
        Private WithEvents m_自动生成图号_Buttondef As Inventor.ButtonDefinition

        '更改镜像零件文件名          6
        Private WithEvents m_更改镜像文件名_Buttondef As Inventor.ButtonDefinition

        '打开文件所在文件夹           7
        Private WithEvents m_打开文件夹_Buttondef As Inventor.ButtonDefinition

        '保存并关闭         8
        Private WithEvents m_保存关闭_Buttondef As Inventor.ButtonDefinition

        '另存为pdf                9
        Private WithEvents m_另存为Pdf_Buttondef As Inventor.ButtonDefinition

        '另存为dwg    10
        Private WithEvents m_另存为Dwg_Buttondef As Inventor.ButtonDefinition

        '设置bom结构    11
        Private WithEvents m_设置BOM结构_Buttondef As Inventor.ButtonDefinition

        '比例   12
        Private WithEvents m_设置比例_Buttondef As Inventor.ButtonDefinition

        '对称件iProperty      13
        Private WithEvents m_设置对称件iProperty_Buttondef As Inventor.ButtonDefinition

        '检查序号完整性     14
        Private WithEvents m_检查序号完整性_Buttondef As Inventor.ButtonDefinition

        '新建序号       15
        Private WithEvents m_新建序号_Buttondef As Inventor.ButtonDefinition

        '设置日期       16
        Private WithEvents m_设置日期_Buttondef As Inventor.ButtonDefinition

        '清除日期       17
        Private WithEvents m_清除日期_Buttondef As Inventor.ButtonDefinition

        '自定义日期     18
        Private WithEvents m_自定义日期_Buttondef As Inventor.ButtonDefinition

        '签字       19
        Private WithEvents m_设置签字_Buttondef As Inventor.ButtonDefinition

        '清除签字     20
        Private WithEvents m_清除签字_Buttondef As Inventor.ButtonDefinition

        '自定义签字     21
        Private WithEvents m_自定义签字_Buttondef As Inventor.ButtonDefinition

        '设置       22
        Private WithEvents m_设置_Buttondef As Inventor.ButtonDefinition

        '量产iPropertys       23
        Private WithEvents m_量产iPropertys_Buttondef As Inventor.ButtonDefinition

        '批量另存为     24
        Private WithEvents m_工程图批量另存为_Buttondef As Inventor.ButtonDefinition

        '关于   25
        Private WithEvents m_关于_Buttondef As Inventor.ButtonDefinition

        '26
        Private WithEvents m_保存关闭所有部件_Buttondef As ButtonDefinition

        ''27
        Private WithEvents m_输入查询ERP编码_Buttondef As ButtonDefinition

        '28
        Private WithEvents m_替换图框标题栏_Buttondef As ButtonDefinition

        '29
        Private WithEvents m_更改材料_Buttondef As ButtonDefinition

        '30
        Private WithEvents m_自动重建序号_Buttondef As ButtonDefinition

        '31
        Private WithEvents m_刷新引用_Buttondef As ButtonDefinition

        '32
        Private WithEvents m_清理旧版文件_Buttondef As ButtonDefinition

        ''33
        Private WithEvents m_添加直径_Buttondef As ButtonDefinition

        '34
        Private WithEvents m_全部另存为_Buttondef As ButtonDefinition

        '35
        Private WithEvents m_检查是否有工程图_Buttondef As ButtonDefinition

        '36
        Private WithEvents m_打开全部工程图_Buttondef As ButtonDefinition

        Private WithEvents m_打开指定工程图_Buttondef As ButtonDefinition

        '37
        Private WithEvents m_部件替换文件名_Buttondef As ButtonDefinition

        '38
        Private WithEvents m_导出平面BOM_Buttondef As ButtonDefinition

        '39
        Private WithEvents m_还原旧图_Buttondef As ButtonDefinition

        '40
        Private WithEvents m_帮助_Buttondef As ButtonDefinition

        '41
        Private WithEvents m_移动指定文件_Buttondef As ButtonDefinition

        '42
        Private WithEvents m_对齐原始坐标面_Buttondef As ButtonDefinition

        '43
        Private WithEvents m_查找缺失文件的部件_Buttondef As ButtonDefinition

        '44
        Private WithEvents m_统计质量面积_Buttondef As ButtonDefinition

        '45
        Private WithEvents m_自定义IPro_Buttondef As ButtonDefinition

        '46
        Private WithEvents m_插入序号_Buttondef As Inventor.ButtonDefinition

        '47
        Private WithEvents m_尺寸圆整_Buttondef As Inventor.ButtonDefinition

        '48
        Private WithEvents m_导入ERP编码_Buttondef As Inventor.ButtonDefinition

        '49
        Private WithEvents m_关闭文档_Buttondef As ButtonDefinition

        '50
        Private WithEvents m_打开工程图_Buttondef As ButtonDefinition

        '51
        Private WithEvents m_批量打印_Buttondef As ButtonDefinition

        '52
        Private WithEvents m_重写BOM序号_Buttondef As ButtonDefinition

        '53
        Private WithEvents m_查询ERP编码_Buttondef As ButtonDefinition

        '54
        Private WithEvents m_打开ERP数据文件_Buttondef As ButtonDefinition

        '55
        Private WithEvents m_快速打开_Buttondef As ButtonDefinition

        '27
        Private WithEvents m_ERP反查_Buttondef As ButtonDefinition

        '28
        Private WithEvents m_导入ERP到BOM_Buttondef As ButtonDefinition

        '29
        Private WithEvents m_快速打印_Buttondef As ButtonDefinition

        '30
        Private WithEvents m_设值随机颜色_Buttondef As ButtonDefinition

        '31
        Private WithEvents m_清除随机颜色_Buttondef As ButtonDefinition

        Private WithEvents m_技术要求_Buttondef As ButtonDefinition

        Private WithEvents m_居中对齐_Buttondef As ButtonDefinition

        Private WithEvents m_尺寸居中_Buttondef As ButtonDefinition

        Private WithEvents m_全部尺寸居中_Buttondef As ButtonDefinition

        Private WithEvents m_全部可见_Buttondef As ButtonDefinition

        Private WithEvents m_设置文件属性_Buttondef As ButtonDefinition

        Private WithEvents m_只读属性_Buttondef As ButtonDefinition

        Private WithEvents m_标准件可见性_Buttondef As ButtonDefinition

        Private WithEvents m_替换为库文件_Buttondef As ButtonDefinition

        Private WithEvents m_编辑尺寸_Buttondef As ButtonDefinition

        Private WithEvents m_创建展开图_Buttondef As ButtonDefinition
        '================================================================================

#End Region

        ' Inventor application object.
        'Private   ThisApplication As Inventor.Application

#Region "ApplicationAddInServer Members"

        Public Sub Activate(ByVal addInSiteObject As Inventor.ApplicationAddInSite, ByVal firstTime As Boolean) Implements Inventor.ApplicationAddInServer.Activate

            ' This method is called by Inventor when it loads the AddIn.
            ' The AddInSiteObject provides access to the Inventor Application object.
            ' The FirstTime flag indicates if the AddIn is loaded for the first time.
            On Error Resume Next

            ' Initialize AddIn members.
            ThisApplication = addInSiteObject.Application

            '打开文件时事件
            ThisApplicationEvents = ThisApplication.ApplicationEvents
            AddHandler ThisApplicationEvents.OnOpenDocument, AddressOf ThisApplicationEvents_OnOpenDocument
            AddHandler ThisApplicationEvents.OnActivateDocument, AddressOf ThisApplicationEvents_OnActivateDocument
            'AddHandler ThisApplicationEvents.OnSaveDocument, AddressOf ThisApplicationEvents_OnOnSaveDocument

            ' TODO:  Add ApplicationAddInServer.Activate implementation.
            ' e.g. event initialization, command creation etc.

            '当前inventor 版本
            DisplayVersion = ThisApplication.SoftwareVersion.DisplayVersion

            '初始化零件库
            ContentCenterFiles = ThisApplication.FileOptions.ContentCenterPath
            'MsgBox(ContentCenterFiles)

            '初始化默认值
            WrXml.InAISettingDefaultValue()

            '获取自定义值
            WrXml.InAISettingXmlReadSetting()

            '检查更新
            If CheckUpdate = "1" Then
                'NewUpdater.UpDater2(False)

                'IsShowUpdateMsg = False
                'Dim frmupdate As New frmUpdate
                'frmupdate.Visible = False
                'frmupdate.ShowDialog()

                'If NewUpdater.CreateUpdate() = True Then

                If NewUpdater.GetGitVersion = "New" Then
                    If MsgBox("检查到InAI新版：" & NewVersion & "，是否下载？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "更新") = MsgBoxResult.Yes Then
                        Process.Start("https://github.com/leaky114/InAI/tree/master/Release")
                        Process.Start("https://www.aliyundrive.com/s/C3CerE58Fkn")
                    End If
                End If

                If NewUpdater.CheckNewVesion = "New" Then

                    '释放更新程序
                    'NewUpdater.CreateUpdateExe()

                    NewUpdater.UpDate3()

                End If
            End If

            '更新数据库文件
            If BasicExcelFullFileName = "" Then
                BasicExcelFullFileName = My.Application.Info.DirectoryPath & "\" & ServerExcelFileName
                'MsgBox(Excel_File_Name)
            End If

            Dim documentURL As String
            documentURL = Server & ServerExcelFileName

            If IsFileExsts(documentURL) = True Then
                Dim wc As New System.Net.WebClient
                wc.DownloadFile(documentURL, BasicExcelFullFileName)
            End If
            'End If

            '下载帮助文件
            documentURL = Server & "帮助.pdf"

            Dim strHelpFullFileName As String
            strHelpFullFileName = My.Application.Info.DirectoryPath & "\帮助.pdf"

            If IsFileExsts(documentURL) = True Then
                Dim wc As New System.Net.WebClient
                wc.DownloadFile(documentURL, strHelpFullFileName)
            End If

            '创建按钮
            CreatUI(firstTime)

            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)

            'End Try

        End Sub

        Public Sub CreatUI(ByVal bfirstTime As Boolean)
            On Error Resume Next
            Dim oCommandManager As CommandManager
            Dim oUserInterfaceManager As UserInterfaceManager
            'Dim oIPictureDisp32 As Object  '大图标
            'Dim oIPictureDisp8 As Object   '小图标

            Dim smallPicture As stdole.IPictureDisp
            Dim largePicture As stdole.IPictureDisp

            'Try
            oCommandManager = ThisApplication.CommandManager
            oUserInterfaceManager = ThisApplication.UserInterfaceManager

            'clientId = Me.GetType().GUID.ToString("B")
            ClientID = AddInGuid(GetType(StandardAddInServer))
            '---------------------------------------------------------------------------------------
            'create button's definition here
            'm_修改文件iProperty_Buttondef = New 修改文件iProperty_Button("修改文件iProperty", "InName修改文件iProperty", _
            '                       CommandTypesEnum.kShapeEditCmdType, clientId, , , , , )
            '1
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.修改文件iProperty161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.修改文件iProperty323224.ToBitmap)

            m_修改文件iProperty_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("提取iProperty", "InName修改文件iProperty", _
                                  CommandTypesEnum.kShapeEditCmdType, ClientID, , "以第一个汉字为标识，提取文件名中的图号和名称，根据【iProperty映射】的设置，写入【iProperty】【项目】中的字段。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '2
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.修改部件iProperty161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.修改部件iProperty323224.ToBitmap)
            m_修改部件iProperty_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("提取部件iProperty", "InName修改部件iProperty", _
                                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据【BOM表】【结构化】的数据，设置下一级或所有级文件的iProperty。注意：将忽略零件库和参考文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '3
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.更改文件名161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.更改文件名323224.ToBitmap)
            m_更改文件名_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("更改文件名", "InName更改文件名", _
                                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件文件中选择一个文件，修改其文件名，将替换选中的文件或全部文件。若在与文件同一文件夹中存在其同名工程图，将生成新的工程图。注意：将忽略零件库。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '4
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.提取iPro修改文件名161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.提取iPro修改文件名323224.ToBitmap)
            m_提取iPro修改文件名_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("提取iPro修改文件名", "InName提取iPro修改文件名", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件文件中选择一个文件，根据【iProperty映射】设置，提取【iProperty】【项目】中的字段，修改选取文件的文件名。与【修改部件iProperty】反向。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '5
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.生成图号161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.生成图号323224.ToBitmap)
            m_自动生成图号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("自动生成图号", "InName自动生成图号", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据第一级部件的图号，设置子级部件或零件的图号变化规则，重命名其文件名。对于新设计先命名后图号特别有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '6
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.更改镜像文件名161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.更改镜像文件名323224.ToBitmap)
            m_更改镜像文件名_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("更改镜像文件名", "InName更改镜像文件名", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件中选择一个是镜像生成的文件，修改其文件名，将原基础文件改为临时文件，重新手动指定其基础文件，后还原基础文件。对于基础文件和镜像文件都需修改的文件很有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '7
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.关闭文档161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.关闭文档323224.ToBitmap)
            m_关闭文档_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("关闭", "InName关闭当前文档", _
                                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "关闭当前文档。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.打开文件夹161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.打开文件夹323224.ToBitmap)
            ' Create the button definition.
            m_打开文件夹_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开文件夹", "InName打开文件夹", _
                           CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开当前文件所在的文件夹。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '8
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.保存关闭161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.保存关闭323224.ToBitmap)
            m_保存关闭_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("保存关闭", "InName保存关闭", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "保存并关闭当前打开的文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '9
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.另存为Pdf161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.另存为Pdf323224.ToBitmap)
            m_另存为Pdf_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("另存为Pdf", "InName另存为Pdf", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将当前文件另存为Pdf格式。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '10
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.另存为Dwg161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.另存为Dwg323224.ToBitmap)
            m_另存为Dwg_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("另存为Dwg", "InName另存为Dwg", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将当前文件另存为Dwg格式。可能 因为设置的不同而是 Zip 格式的，也将其打开。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '11
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置BOM结构161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置BOM结构323224.ToBitmap)
            m_设置BOM结构_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置虚拟件", "InName设置BOM结构", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件中使用，输入序号，将部件的所有子级设置为对应的BOM结构。对与液压管等特别有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '12
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置比例161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置比例323224.ToBitmap)
            m_设置比例_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置比例", "InName设置比例", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "获取工程图主视图的比例，根据【比例映射】的设置，写入【iProperty】【自定义】字段。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '13
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.对称件iProperty161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.对称件iProperty323224.ToBitmap)
            m_设置对称件iProperty_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("对称件iProperty", "InName对称件iProperty", _
                                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "选择一个文件，根据【对称件iProperty映射】的设置，将其iProperty写入【iProperty】【自定义】字段。对于对称件的工程图很有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '14
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.检查序号完整性161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.检查序号完整性323224.ToBitmap)
            m_检查序号完整性_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("检查序号完整性", "InName检查序号完整性", _
                           CommandTypesEnum.kShapeEditCmdType, ClientID, "", "检查工程图的序号是否标注完整。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '15
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.新建序号161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.新建序号323224.ToBitmap)
            m_新建序号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("新建序号", "InName新建序号", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "重新对工程图的序号进行变化，使寻找序号更简便。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '16
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置日期161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置日期323224.ToBitmap)
            m_设置日期_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置日期", "InName设置日期", _
                                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据【签字】【打印日期】的设置，将当前日期写入【iProperty】【自定义】字段。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '17
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.清除日期161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.清除日期323224.ToBitmap)
            m_清除日期_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("清除日期", "InName清除日期", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '18
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.自定义日期161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.自定义日期323224.ToBitmap)
            m_自定义日期_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("自定义日期", "InName自定义日期", _
           CommandTypesEnum.kShapeEditCmdType, ClientID, "", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '19
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置签字161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置签字323224.ToBitmap)
            m_设置签字_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置签字", "InName设置签字", _
                     CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据【签字】【工程师】的设置，将当前日期写入【iProperty】【自定义】字段。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '20
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.清除签字161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.清除签字323224.ToBitmap)
            m_清除签字_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("清除签字", "InName清除签字", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '21
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.自定义签字161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.自定义签字323224.ToBitmap)
            m_自定义签字_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("自定义签字", "InName自定义签字", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '22
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置323224.ToBitmap)
            m_设置_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置", "InName设置", _
                     CommandTypesEnum.kShapeEditCmdType, ClientID, "打开【设置】窗口，对配置进行设置。", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '23
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.量产iPropertys161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.量产iPropertys323224.ToBitmap)
            m_量产iPropertys_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("量产iProperty", "InName量产iProperty", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开【量产iProperty】窗口，对多个文件设置【iProperty】。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '24
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.批量另存为161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.批量另存为323224.ToBitmap)
            m_工程图批量另存为_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("工程图批量另存为", "InName工程图批量另存为", _
                 CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开【批量另存为】窗口，将添加的工程图另存为Paf或Dwg文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '25
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.关于161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.关于323224.ToBitmap)
            m_关于_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("关于", "InName关于", _
                 CommandTypesEnum.kShapeEditCmdType, ClientID, "", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '26
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.保存全部161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.保存全部323224.ToBitmap)
            m_保存关闭所有部件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("保存关闭所有部件", "InName保存关闭所有部件", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "保存并关闭打开的所有部件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '27
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.查询材料编码161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.查询材料编码323224.ToBitmap)
            m_输入查询ERP编码_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("查询ERP编码", "InName输入查询ERP编码", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "输入图号或名称查询ERP编码。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '28
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.替换图框标题栏161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.替换图框标题栏323224.ToBitmap)
            m_替换图框标题栏_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("替换图框标题栏", "InName替换图框标题栏", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "以Inventor安装文件夹下的 模板.idw 文件为基础，替换图框标题栏。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '29
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.自动重建序号161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.自动重建序号323224.ToBitmap)
            m_自动重建序号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("自动重建序号", "InName自动重建序号", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "按极角排序（环形）自动重建序号。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '30
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.创建展开161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.创建展开161624.ToBitmap)
            m_创建展开图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("创建展开图", "InName创建展开图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件中批量或在零件中创建钣金零件展开图，保存到子目录《钣金展开》。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '31
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.刷新引用161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.刷新引用323224.ToBitmap)
            m_刷新引用_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("刷新引用", "InName刷新引用", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "刷新浏览器中的引用名称。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '32
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.清理旧版文件161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.清理旧版文件323224.ToBitmap)
            m_清理旧版文件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("清理旧版文件", "InName清理旧版文件", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "扫描指定路径下的旧版文件，删除之。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '33
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.添加直径161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.添加直径323224.ToBitmap)
            m_添加直径_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("添加直径", "InName添加直径", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在尺寸前添加 Φ。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '35
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.检查是否有工程图161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.检查是否有工程图323224.ToBitmap)
            m_检查是否有工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("检查是否有工程图", "InName检查是否有工程图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "检查部件中指定图号的文件是否有对应的工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '36
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.打开全部工程图161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.打开全部工程图323224.ToBitmap)
            m_打开全部工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开全部工程图", "InName打开全部工程图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开部件中所有子级对应的工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '37
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.部件替换文件名161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.部件替换文件名323224.ToBitmap)
            m_部件替换文件名_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("批量替换文件名", "InName部件替换文件名", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "批量替换部件中子集文件的文件名。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '38
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.导出平面BOM161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.导出平面BOM323224.ToBitmap)
            m_导出平面BOM_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("导出平面BOM", "InName导出平面BOM", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据BOM导出项目，导出平面性的BOM为Excel文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '39
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.还原旧图161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.还原旧图323224.ToBitmap)
            m_还原旧图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("还原旧图", "InName还原旧图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "还原更改文件名后的 .old 文件为原始文件名。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '40
            'oIPictureDisp32 = GetIcon("InventorAddIn.帮助323224.ico")
            'm_帮助_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("帮助", "InName帮助", _
            '                    CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开帮助文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.帮助161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.帮助323224.ToBitmap)
            m_帮助_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("帮助", "InName帮助", _
                                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开帮助文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '36
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.打开全部工程图161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.打开全部工程图161624.ToBitmap)
            m_打开指定工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开指定工程图", "InName打开指定工程图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开部件中所有包含指定图号子级的对应的工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '41
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.移动指定文件161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.移动指定文件323224.ToBitmap)
            m_移动指定文件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("移动指定文件", "InName移动指定文件", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "移到组件中指定前缀的零件和组件到当前组件所在文件夹。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '42
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.对齐原始坐标面161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.对齐原始坐标面323224.ToBitmap)
            m_对齐原始坐标面_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("对齐原始坐标面", "InName对齐原始坐标面", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "选择部件中的两个部件或零件，使其原始坐标面对齐。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '43
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.查找缺失文件的部件161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.查找缺失文件的部件323224.ToBitmap)
            m_查找缺失文件的部件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("查找缺失文件的部件", "InName查找缺失文件的部件", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "查找当前部件中缺失的文件，并打开缺失文件的父级部件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '44
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.统计161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.统计323224.ToBitmap)
            m_统计质量面积_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("统计质量面积", "InName统计质量面积", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "选择部件中的部件或零件，统计总质量和面积。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '45
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.调整IPro顺序161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.调整IPro顺序323224.ToBitmap)
            m_自定义IPro_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("iProperty", "InName自定义IPro", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "自定义设置iProperty。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '44
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.插入序号161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.插入序号323224.ToBitmap)
            m_插入序号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("插入序号", "InName插入序号", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "插入一个序号。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '47
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.尺寸圆整161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.尺寸圆整323224.ToBitmap)
            m_尺寸圆整_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("尺寸圆整", "InName尺寸圆整", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "四舍五入尺寸小数位到个位。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '48
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.导入材料编码161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.导入材料编码323224.ToBitmap)
            m_导入ERP编码_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("导入ERP编码到模型", "InName导入存货编码", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "导入ERP编码。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '49
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置材料编码161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置材料编码323224.ToBitmap)
            m_ERP反查_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("ERP编码反查", "InNameERP反查", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "输入ERP编码，查询数据。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '50
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.工程图161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.工程图323224.ToBitmap)
            m_打开工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开工程图", "InName打开工程图", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开当前文件或部件中选择的文件对应的工程图。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '51
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.批量打印161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.批量打印323224.ToBitmap)
            m_批量打印_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("批量打印", "InName批量打印", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "批量打印工程图。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '52
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.重写BOM161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.重写BOM323224.ToBitmap)
            m_重写BOM序号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("重写BOM序号", "InName重写BOM序号", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "重写BOM序号并按序号升序排序。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '53
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.查询材料编码161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.查询材料编码323224.ToBitmap)
            m_查询ERP编码_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("查询ERP编码", "InName查询ERP编码", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在Excel数据表中查询ERP编码。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '54
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.打开ERP数据文件161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.打开ERP数据文件323224.ToBitmap)
            m_打开ERP数据文件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开ERP数据文件", "InName打开ERP数据文件", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开ERP数据文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '55
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.快速打开161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.快速打开323224.ToBitmap)
            m_快速打开_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("快速打开", "InName快速打开", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在当前项目中快速打开指定文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '56
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.导入ERP到BOM161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.导入ERP到BOM323224.ToBitmap)
            m_导入ERP到BOM_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("导入ERP编码到BOM", "InName导入ERP到BOM", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "导入ERP编码到Excel格式BOM文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '57
            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.快速打印161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.快速打印323224.ToBitmap)
            m_快速打印_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("快速打印", "InName快速打印", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "按默认设值立即打印本工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设值随机颜色161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设值随机颜色323224.ToBitmap)
            m_设值随机颜色_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设值随机颜色", "InName设值随机颜色", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "设值部件中零件为随机颜色。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.清除随机颜色161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.清除随机颜色323224.ToBitmap)
            m_清除随机颜色_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("清除随机颜色", "InName清除随机颜色", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "清除部件中零件的随机颜色。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.技术要求161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.技术要求323224.ToBitmap)
            m_技术要求_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("技术要求", "InName技术要求", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开技术要求。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.居中对齐161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.居中对齐323224.ToBitmap)
            m_居中对齐_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("距离对齐", "InName距离对齐", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "已两个零件的两组平行边的距离为偏移量，添加平齐约束。", _
                smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.尺寸居中161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.尺寸居中323224.ToBitmap)
            m_尺寸居中_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("尺寸居中", "InName尺寸居中", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将选择的尺寸文本居中。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.全部尺寸居中161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.全部尺寸居中323224.ToBitmap)
            m_全部尺寸居中_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("全部居中", "InName全部尺寸居中", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将全部尺寸文本居中。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.全部可见161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.全部可见323224.ToBitmap)
            m_全部可见_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("全部可见", "InName全部可见", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "一键显示所有零部件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置属性161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置属性323224.ToBitmap)
            m_设置文件属性_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置文件属性", "InName设置文件属性", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开设置文件属性。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)


            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置属性161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置属性323224.ToBitmap)
            m_只读属性_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("文件只读", "InName文件只读", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "单击设置当前编辑文件属性，被按下时为文件只读。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.标准件可见性161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.标准件可见性323224.ToBitmap)
            m_标准件可见性_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("标准件可见性", "InName标准件可见性", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "一键显示隐藏所有标准件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.替换为库文件161624.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.替换为库文件323224.ToBitmap)
            m_替换为库文件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("替换为库文件", "InName替换为库文件", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将组件中的自定义标准件替换为库文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)


            smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.编辑尺寸161632.ToBitmap)
            largePicture = PictureConverter.ImageToPictureDisp(My.Resources.编辑尺寸323232.ToBitmap)
            m_编辑尺寸_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("编辑尺寸", "InName编辑尺寸", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "编辑草图尺寸。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)



            '  Dim oUserInterfaceManager As Inventor.UserInterfaceManager = ThisApplication.UserInterfaceManager

            If bfirstTime Then

                '==========================================

                If oUserInterfaceManager.InterfaceStyle = InterfaceStyleEnum.kRibbonInterface Then
                    Dim oRibbon As Inventor.Ribbon
                    Dim oRibbonTab As Inventor.RibbonTab
                    Dim oRibbonPanel As Inventor.RibbonPanel

                    Dim oButtonDefinitions As Inventor.ObjectCollection
                    oButtonDefinitions = ThisApplication.TransientObjects.CreateObjectCollection
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    '启动环境
                    oRibbon = oUserInterfaceManager.Ribbons.Item("ZeroDoc")
                    '快速入门
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_GetStarted")       '
                    oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaAssemblyPanel", ClientID)

                    oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_输入查询ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_ERP反查_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_输入查询ERP编码_Buttondef, oButtonDefinitions, False)

                    oRibbonPanel.CommandControls.AddButton(m_技术要求_Buttondef, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)

                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '工具
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")
                    oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaAssemblyPanel", ClientID)

                    oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)

                    oRibbonPanel.CommandControls.AddButton(m_输入查询ERP编码_Buttondef, False)
                    oRibbonPanel.CommandControls.AddButton(m_ERP反查_Buttondef, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '部件环境
                    oRibbon = oUserInterfaceManager.Ribbons.Item("Assembly")

                    '工具选项卡
                    'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")

                    '装配选项卡
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabAssemble")


                    '在关系栏添加
                    oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelA_AssembleRelationships")

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_对齐原始坐标面_Buttondef)
                    oButtonDefinitions.Add(m_居中对齐_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_对齐原始坐标面_Buttondef, oButtonDefinitions, False)

                    ' Create a new panel on the Assemble tab.

                    oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaAssemblyPanel", ClientID)
                    ' Add the buttons to the tab, with the first and last ones being large and the other two small.
                    oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_打开工程图_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    oButtonDefinitions.Add(m_修改部件iProperty_Buttondef)
                    'oButtonDefinitions.Add(m_设置描述_Buttondef)
                    'oButtonDefinitions.Add(m_设置采购来源_Buttondef)
                    oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)

                    '==========================================

                    oRibbonPanel.CommandControls.AddButton(m_只读属性_Buttondef, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_检查是否有工程图_Buttondef)
                    'oButtonDefinitions.Add(m_打开全部工程图_Buttondef)
                    oButtonDefinitions.Add(m_打开指定工程图_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_检查是否有工程图_Buttondef, oButtonDefinitions, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_更改文件名_Buttondef)
                    oButtonDefinitions.Add(m_更改镜像文件名_Buttondef)
                    oButtonDefinitions.Add(m_提取iPro修改文件名_Buttondef)
                    oButtonDefinitions.Add(m_部件替换文件名_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_更改文件名_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    'oRibbonPanel.CommandControls.AddButton(m_编辑尺寸_Buttondef, False)

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_输入查询ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_ERP反查_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_导出平面BOM_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_输入查询ERP编码_Buttondef, oButtonDefinitions, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)

                    oButtonDefinitions.Add(ThisApplication.CommandManager.ControlDefinitions.Item("Seperator"))

                    oButtonDefinitions.Add(m_移动指定文件_Buttondef)
                    oButtonDefinitions.Add(m_查找缺失文件的部件_Buttondef)

                    oButtonDefinitions.Add(m_设置文件属性_Buttondef)

                    oButtonDefinitions.Add(m_全部可见_Buttondef)
                    oButtonDefinitions.Add(m_标准件可见性_Buttondef)

                    oButtonDefinitions.Add(m_创建展开图_Buttondef)

                    oButtonDefinitions.Add(m_设值随机颜色_Buttondef)
                    oButtonDefinitions.Add(m_清除随机颜色_Buttondef)

                    oButtonDefinitions.Add(m_自动生成图号_Buttondef)
                    oButtonDefinitions.Add(m_设置BOM结构_Buttondef)

                    oButtonDefinitions.Add(m_替换为库文件_Buttondef)

                    oButtonDefinitions.Add(m_刷新引用_Buttondef)

                    oButtonDefinitions.Add(m_统计质量面积_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)


                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_量产iPropertys_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    '零件环境
                    oRibbon = oUserInterfaceManager.Ribbons.Item("Part")

                    '工具选项卡
                    'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")

                    '模型选项卡
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabModel")

                    oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaPartPanel", ClientID)

                    oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_打开工程图_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)

                    '=======================================================
                    oRibbonPanel.CommandControls.AddButton(m_只读属性_Buttondef, False)
                    oRibbonPanel.CommandControls.AddButton(m_编辑尺寸_Buttondef, False)

                    '===================================================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_输入查询ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_ERP反查_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_输入查询ERP编码_Buttondef, oButtonDefinitions, False)

                    '===================================================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)
                    oButtonDefinitions.Add(m_创建展开图_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)

                    '========================================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_量产iPropertys_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '=============================================================

                    '钣金选项卡+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabSheetMetal")

                    oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaPartPanel", ClientID)
                    oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_打开工程图_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)

                    '==========================================
                    oRibbonPanel.CommandControls.AddButton(m_只读属性_Buttondef, False)

                    oRibbonPanel.CommandControls.AddButton(m_编辑尺寸_Buttondef, False)

                    '===================================================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_输入查询ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_ERP反查_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_输入查询ERP编码_Buttondef, oButtonDefinitions, False)


                    '===================================================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)
                    oButtonDefinitions.Add(m_创建展开图_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)

                    '========================================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_量产iPropertys_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '=============================================================
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '工程图环境
                    oRibbon = oUserInterfaceManager.Ribbons.Item("Drawing")
                    'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabPlaceViews")

                    '在放置视图选项卡中添加

                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabPlaceViews")
                    oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaDrawingPanel", ClientID)

                    oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_打开文件夹_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)
                    '==========================================

                    oRibbonPanel.CommandControls.AddButton(m_只读属性_Buttondef, False)
                    '==========================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_另存为Dwg_Buttondef)
                    oButtonDefinitions.Add(m_另存为Pdf_Buttondef)
                    'oButtonDefinitions.Add(m_全部另存为_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_另存为Dwg_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '==========================================
                    '日期popup  '签字popup
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置签字_Buttondef)
                    oButtonDefinitions.Add(m_清除签字_Buttondef)
                    oButtonDefinitions.Add(m_自定义签字_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_设置签字_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '==========================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_快速打印_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_快速打印_Buttondef, oButtonDefinitions, False)

                    '==========================================

                    ''在工具选项卡中添加
                    'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")
                    'oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaDrawingPanel", ClientID)

                    '==========================================
                    'oButtonDefinitions.Clear()
                    'oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    'oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    'oRibbonPanel.CommandControls.AddButton(m_打开文件夹_Buttondef, True)
                    '==========================================

                    '==========================================
                    'oButtonDefinitions.Clear()
                    'oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    'oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    'oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)
                    '==========================================



                    '==========================================
                    'oButtonDefinitions.Clear()
                    'oButtonDefinitions.Add(m_另存为Dwg_Buttondef)
                    'oButtonDefinitions.Add(m_另存为Pdf_Buttondef)
                    ''oButtonDefinitions.Add(m_全部另存为_Buttondef)
                    'oRibbonPanel.CommandControls.AddPopup(m_另存为Dwg_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '==========================================

                    '----------------------------------------------------------------------------------
                    ''日期popup  '签字popup
                    'oButtonDefinitions.Clear()

                    'oButtonDefinitions.Add(m_设置签字_Buttondef)
                    'oButtonDefinitions.Add(m_清除签字_Buttondef)
                    'oButtonDefinitions.Add(m_自定义签字_Buttondef)

                    'oRibbonPanel.CommandControls.AddPopup(m_设置签字_Buttondef, oButtonDefinitions, False)

                    '----------------------------------------------------------------------------------
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)
                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)
                    oButtonDefinitions.Add(m_量产iPropertys_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    'oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '在标注选项卡中添加
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabAnnotate")
                    '在尺寸栏添加
                    oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelD_AnnotateDimension")

                    oRibbonPanel.CommandControls.AddButton(m_添加直径_Buttondef)
                    oRibbonPanel.CommandControls.AddButton(m_尺寸圆整_Buttondef)

                    oRibbonPanel.CommandControls.AddButton(m_尺寸居中_Buttondef)
                    oRibbonPanel.CommandControls.AddButton(m_全部尺寸居中_Buttondef)

                    '在表格栏添加
                    oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelD_AnnotateTable")
                    oRibbonPanel.CommandControls.AddButton(m_设置对称件iProperty_Buttondef)

                    oRibbonPanel.CommandControls.AddButton(m_替换图框标题栏_Buttondef, False)
                    oRibbonPanel.CommandControls.AddButton(m_技术要求_Buttondef, False)

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_检查序号完整性_Buttondef)
                    oButtonDefinitions.Add(m_新建序号_Buttondef)
                    oButtonDefinitions.Add(m_自动重建序号_Buttondef)
                    oButtonDefinitions.Add(m_重写BOM序号_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_检查序号完整性_Buttondef, oButtonDefinitions, False)

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    '二维草图

                    oRibbon = oUserInterfaceManager.Ribbons.Item("Part")

                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabSketch")

                    oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaSketchPanel", ClientID)



                ElseIf oUserInterfaceManager.InterfaceStyle = InterfaceStyleEnum.kClassicInterface Then

                End If
            End If

            'If bfirstTime Then ' Get the part features command bar.
            '    Dim CommandBar As Inventor.CommandBar

            '    ' Add a button to the command bar, defaulting to the end position.
            '    '部件环境
            '    CommandBar = ThisApplication.UserInterfaceManager.CommandBars.Item("AMxAssemblyPanelCmdBar")

            '    CommandBar.Controls.AddButton(m_修改文件iProperty_Buttondef)
            '    ''零件环境
            '    CommandBar = ThisApplication.UserInterfaceManager.CommandBars.Item("PMxPartFeatureCmdBar")
            '    ''工程图环境
            '    CommandBar = ThisApplication.UserInterfaceManager.CommandBars.Item("DLxDrawingAnnotationPanelCmdBar")

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
        End Sub

        '以下按钮事件
        '------------------------------------------------------
        Private Sub m_修改文件iProperty_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_修改文件iProperty_Buttondef.OnExecute
            SetDocumentIpropertyFromFileName()
        End Sub

        Private Sub m_修改部件iProperty_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_修改部件iProperty_Buttondef.OnExecute
            SetDocumentsInAssIpropertyFromFileName()
        End Sub

        Private Sub m_更改文件名_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_更改文件名_Buttondef.OnExecute
            RenameAssPartDocumentName()
        End Sub

        Private Sub m_提取iPro修改文件名_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_提取iPro修改文件名_Buttondef.OnExecute
            GetIpropertyToRename()

        End Sub

        Private Sub m_自动生成图号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_自动生成图号_Buttondef.OnExecute
            FrmAutoPartNumberShow()
        End Sub

        Private Sub m_更改镜像文件名_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_更改镜像文件名_Buttondef.OnExecute
            RenameMirrorAssPartDocumentName()
        End Sub

        Private Sub m_打开文件夹_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_打开文件夹_Buttondef.OnExecute
            OpenFolderwithDocument()
        End Sub

        Private Sub m_保存关闭_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_保存关闭_Buttondef.OnExecute
            SaveClose()
        End Sub

        Private Sub m_另存为Pdf_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_另存为Pdf_Buttondef.OnExecute
            IdwSaveAsPdf()
        End Sub

        Private Sub m_另存为Dwg_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_另存为Dwg_Buttondef.OnExecute
            IdwSaveAsDwg()
        End Sub

        Private Sub m_设置BOM结构_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置BOM结构_Buttondef.OnExecute
            SetBOMStructuret()
        End Sub

        Private Sub m_设置对称件iProperty_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置对称件iProperty_Buttondef.OnExecute
            SetDrawingMirPartIPro()
        End Sub

        Private Sub m_序号完整性_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_检查序号完整性_Buttondef.OnExecute
            CheckSerialNumber()
        End Sub

        Private Sub m_新建序号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_新建序号_Buttondef.OnExecute
            CreateNewSequenceNumber()
        End Sub

        Private Sub m_设置签字_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置签字_Buttondef.OnExecute
            SetUpSigning()
        End Sub

        Private Sub m_清除签字_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_清除签字_Buttondef.OnExecute
            ClearSignature()
        End Sub

        Private Sub m_自定义签字_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_自定义签字_Buttondef.OnExecute
            FrmCustomSignatureShow()
        End Sub

        Private Sub m_设置_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置_Buttondef.OnExecute
            FrmOptionshow()
        End Sub

        Private Sub m_量产iPropertys_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_量产iPropertys_Buttondef.OnExecute
            frmMassiPopertiesshow()
        End Sub

        Private Sub m_批量打印_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_批量打印_Buttondef.OnExecute
            FrmBulkPrintShow()
        End Sub

        Private Sub m_工程图批量另存为_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_工程图批量另存为_Buttondef.OnExecute
            FrmAllSaveAsShow()
        End Sub

        Private Sub m_还原旧图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_还原旧图_Buttondef.OnExecute
            RestoreOldVersion()
        End Sub

        Private Sub m_关于_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_关于_Buttondef.OnExecute
            Dim frmAbout As New frmAbout
            frmAbout.ShowDialog()
        End Sub

        Private Sub m_帮助_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_帮助_Buttondef.OnExecute
            Dim strHelpFullFileName As String
            strHelpFullFileName = My.Application.Info.DirectoryPath & "\帮助.pdf"
            Process.Start(strHelpFullFileName)
        End Sub

        Private Sub m_保存关闭所有部件_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_保存关闭所有部件_Buttondef.OnExecute
            FrmSaveCloseAllDocumentShow()
        End Sub

        Private Sub m_关闭文档_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_关闭文档_Buttondef.OnExecute
            CloseDocument()
        End Sub

        Private Sub m_添加直径_Buttondef_OnExecute() Handles m_添加直径_Buttondef.OnExecute
            AddDiameter()
        End Sub

        Private Sub m_检查是否有工程图_Buttondef_OnExecute() Handles m_检查是否有工程图_Buttondef.OnExecute
            CheckIsInvHaveIdw()
        End Sub

        Private Sub m_打开指定工程图_Buttondef_OnExecute() Handles m_打开指定工程图_Buttondef.OnExecute
            OpenAllDrwInAsm()
        End Sub

        Private Sub m_部件替换文件名_Buttondef_OnExecute() Handles m_部件替换文件名_Buttondef.OnExecute
            ReplaceNameInAsm()
        End Sub

        ' 导出BOM平面性
        Private Sub m_导出平面BOM_Buttondef_OnExecute() Handles m_导出平面BOM_Buttondef.OnExecute
            ExportBOMAsFlat()
        End Sub

        ' 刷新引用名称
        Private Sub m_刷新引用_Buttondef_OnExecute() Handles m_刷新引用_Buttondef.OnExecute
            RefreshShowName()
        End Sub

        Private Sub m_清理旧版文件_Buttondef_OnExecute() Handles m_清理旧版文件_Buttondef.OnExecute
            CleanUpLegacyFiles()
        End Sub

        Private Sub m_移动指定文件_Buttondef_OnExecute() Handles m_移动指定文件_Buttondef.OnExecute
            MovesSpecifiedFile()

        End Sub

        Private Sub m_对齐原始坐标面_Buttondef_OnExecute() Handles m_对齐原始坐标面_Buttondef.OnExecute
            FlushXYZPlane()
        End Sub

        Private Sub m_查找缺失文件的部件_Buttondef_OnExecute() Handles m_查找缺失文件的部件_Buttondef.OnExecute
            GetAsmMissDocument()
        End Sub

        Private Sub m_统计质量面积_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_统计质量面积_Buttondef.OnExecute
            frmGetPartshow()
        End Sub

        Private Sub m_自定义IPro_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_自定义IPro_Buttondef.OnExecute
            FrmChangeIproShow()
        End Sub

        Private Sub m_尺寸圆整_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_尺寸圆整_Buttondef.OnExecute
            DimensionRounding()
        End Sub

        Private Sub m_导入ERP编码_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_导入ERP编码_Buttondef.OnExecute
            FrmImportCodeToIamShow()
        End Sub

        Private Sub m_打开工程图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_打开工程图_Buttondef.OnExecute
            OpenIdwFile()
        End Sub

        'BOM表保存新的替换项和按序号排序
        Private Sub m_重写BOM序号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_重写BOM序号_Buttondef.OnExecute
            ReWriteBOM()
        End Sub

        Private Sub m_打开ERP数据文件_Buttondef_OnExecute() Handles m_打开ERP数据文件_Buttondef.OnExecute
            OpenBasicExcel()
        End Sub

        Private Sub m_输入查询ERP编码_Buttondef_OnExecute() Handles m_输入查询ERP编码_Buttondef.OnExecute
            FrmSearchERPCodeShow()
        End Sub

        Private Sub m_导入ERP到BOM_Buttondef_OnExecute() Handles m_导入ERP到BOM_Buttondef.OnExecute
            FrmImportERPCodeToExcelshow()
        End Sub

        Private Sub m_快速打开_Buttondef_OnExecute() Handles m_快速打开_Buttondef.OnExecute
            QuitOpen()
        End Sub

        Private Sub m_自动重建序号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_自动重建序号_Buttondef.OnExecute
            RebuildRingSerialNumber()
        End Sub

        Private Sub m_替换图框标题栏_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_替换图框标题栏_Buttondef.OnExecute
            ReplaceBorderTitleBlock()
        End Sub

        Private Sub m_快速打印_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_快速打印_Buttondef.OnExecute
            QuitPrint()
        End Sub

        Private Sub m_ERP反查_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_ERP反查_Buttondef.OnExecute
            FrmReverseCheckERPCodesShow()
        End Sub

        Private Sub m_设值随机颜色_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设值随机颜色_Buttondef.OnExecute
            SetRandomColor()
        End Sub

        Private Sub m_清除随机颜色_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_清除随机颜色_Buttondef.OnExecute
            ClearRandomColor()
        End Sub

        Private Sub m_技术要求_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_技术要求_Buttondef.OnExecute
            FrmSpecificationShow()
        End Sub

        Private Sub m_居中对齐_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_居中对齐_Buttondef.OnExecute
            AlignComponentsInTheCenter()
        End Sub

        Private Sub m_全部尺寸居中_ButtondefOnExecute(ByVal Context As Inventor.NameValueMap) Handles m_全部尺寸居中_Buttondef.OnExecute
            CenterAllDimensions()
        End Sub

        Private Sub m_尺寸居中_ButtondefOnExecute(ByVal Context As Inventor.NameValueMap) Handles m_尺寸居中_Buttondef.OnExecute
            CenterDimensions()
        End Sub

        Private Sub m_全部可见_ButtondefOnExecute(ByVal Context As Inventor.NameValueMap) Handles m_全部可见_Buttondef.OnExecute
            OneKeyShowAll()
        End Sub

        Private Sub m_设置文件属性_ButtondefOnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置文件属性_Buttondef.OnExecute
            FrmSetWriteOnlyShow()
        End Sub

        Private Sub m_只读属性_ButtondefOnExecute(ByVal Context As Inventor.NameValueMap) Handles m_只读属性_Buttondef.OnExecute
            SetWriteOnly()
        End Sub

        Private Sub m_标准件可见性_ButtondefOnExecute(ByVal Context As Inventor.NameValueMap) Handles m_标准件可见性_Buttondef.OnExecute
            SetStandIptVisible()
        End Sub

        Private Sub m_替换为库文件_ButtondefOnExecute(ByVal Context As Inventor.NameValueMap) Handles m_替换为库文件_Buttondef.OnExecute
            ReplaceWithContentCenterFile()
        End Sub


        Private Sub m_编辑尺寸_ButtondefOnExecute(ByVal Context As Inventor.NameValueMap) Handles m_编辑尺寸_Buttondef.OnExecute
            FrmEditDimensionShow()
        End Sub

        Private Sub m_创建展开图_ButtondefOnExecute(ByVal Context As Inventor.NameValueMap) Handles m_创建展开图_Buttondef.OnExecute
            CreateFlat()
        End Sub

        '==================================================================================
        ''
        '
        '===============================================

        Public Sub Deactivate() Implements Inventor.ApplicationAddInServer.Deactivate

            ' This method is called by Inventor when the AddIn is unloaded.
            ' The AddIn will be unloaded either manually by the user or
            ' when the Inventor session is terminated.

            ' TODO:  Add ApplicationAddInServer.Deactivate implementation

            ' Release objects.
            Marshal.ReleaseComObject(ThisApplication)
            ThisApplication = Nothing

            System.GC.WaitForPendingFinalizers()
            System.GC.Collect()

        End Sub

        Public ReadOnly Property Automation() As Object Implements Inventor.ApplicationAddInServer.Automation

            ' This property is provided to allow the AddIn to expose an API
            ' of its own to other programs. Typically, this  would be done by
            ' implementing the AddIn's API interface in a class and returning
            ' that class object through this property.

            Get
                Return Nothing
            End Get

        End Property

        Public Sub ExecuteCommand(ByVal commandID As Integer) Implements Inventor.ApplicationAddInServer.ExecuteCommand

            ' Note:this method is now obsolete, you should use the
            ' ControlDefinition functionality for implementing commands.

        End Sub

#End Region

#Region "COM Registration"

        ' Registers this class as an AddIn for Inventor.
        ' This function is called when the assembly is registered for COM.
        <ComRegisterFunctionAttribute()> _
        Public Shared Sub Register(ByVal t As Type)

            Dim clssRoot As RegistryKey = Registry.ClassesRoot
            Dim clsid As RegistryKey = Nothing
            Dim subKey As RegistryKey = Nothing

            Try
                clsid = clssRoot.CreateSubKey("CLSID\" + AddInGuid(t))
                clsid.SetValue(Nothing, "InventorAddIn")
                subKey = clsid.CreateSubKey("Implemented Categories\{39AD2B5C-7A29-11D6-8E0A-0010B541CAA8}")
                subKey.Close()

                subKey = clsid.CreateSubKey("Settings")
                subKey.SetValue("AddInType", "Standard")
                subKey.SetValue("LoadOnStartUp", "1")

                'subKey.SetValue("SupportedSoftwareVersionLessThan", "")
                subKey.SetValue("SupportedSoftwareVersionGreaterThan", "14..")
                'subKey.SetValue("SupportedSoftwareVersionEqualTo", "")
                'subKey.SetValue("SupportedSoftwareVersionNotEqualTo", "")
                'subKey.SetValue("Hidden", "0")
                'subKey.SetValue("UserUnloadable", "1")
                subKey.SetValue("Version", 0)
                subKey.Close()

                subKey = clsid.CreateSubKey("Description")
                subKey.SetValue(Nothing, "InventorAddIn")
            Catch ex As Exception
                System.Diagnostics.Trace.Assert(False)
            Finally
                If Not subKey Is Nothing Then subKey.Close()
                If Not clsid Is Nothing Then clsid.Close()
                If Not clssRoot Is Nothing Then clssRoot.Close()
            End Try

        End Sub

        ' Unregisters this class as an AddIn for Inventor.
        ' This function is called when the assembly is unregistered.
        <ComUnregisterFunctionAttribute()> _
        Public Shared Sub Unregister(ByVal t As Type)

            Dim clssRoot As RegistryKey = Registry.ClassesRoot
            Dim clsid As RegistryKey = Nothing

            Try
                clssRoot = Microsoft.Win32.Registry.ClassesRoot
                clsid = clssRoot.OpenSubKey("CLSID\" + AddInGuid(t), True)
                clsid.SetValue(Nothing, "")
                clsid.DeleteSubKeyTree("Implemented Categories\{39AD2B5C-7A29-11D6-8E0A-0010B541CAA8}")
                clsid.DeleteSubKeyTree("Settings")
                clsid.DeleteSubKeyTree("Description")
            Catch
            Finally
                If Not clsid Is Nothing Then clsid.Close()
                If Not clssRoot Is Nothing Then clssRoot.Close()
            End Try

        End Sub

        ' This property uses reflection to get the value for the GuidAttribute attached to the class.
        Public Shared ReadOnly Property AddInGuid(ByVal t As Type) As String

            Get
                Dim guid As String = ""
                Try
                    Dim customAttributes() As Object = t.GetCustomAttributes(GetType(GuidAttribute), False)
                    Dim guidAttribute As GuidAttribute = CType(customAttributes(0), GuidAttribute)
                    guid = "{" + guidAttribute.Value.ToString() + "}"
                Finally
                    AddInGuid = guid
                End Try
            End Get

        End Property

#End Region

    End Class

End Namespace