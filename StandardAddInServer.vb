'设置为一个动作，可一次撤销
'Dim transientGeometry As TransientGeometry
'                transientGeometry = ThisApplication.TransientGeometry
''start a transaction so the slot will be within a single undo step
'Dim createSlotTransaction As Transaction
'                createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "重新设置序号")

'

''end the transactio
'createSlotTransaction.End()

Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Drawing
Imports System.IO
Imports Inventor
Imports Inventor.SelectionFilterEnum
Imports Inventor.DocumentTypeEnum
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

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
        Private WithEvents m_生成图号_Buttondef As Inventor.ButtonDefinition

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
        'Private WithEvents m_保存关闭所有零件_Buttondef As ButtonDefinition

        ''28
        'Private WithEvents m_保存关闭所有工程图_Buttondef As ButtonDefinition

        '29
        'Private WithEvents m_绘制槽孔_Buttondef As ButtonDefinition

        '30
        Private WithEvents m_设置描述_Buttondef As ButtonDefinition

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
        Private WithEvents m_调整IPro顺序_Buttondef As ButtonDefinition

        '46
        Private WithEvents m_插入序号_Buttondef As Inventor.ButtonDefinition

        '47
        Private WithEvents m_尺寸圆整_Buttondef As Inventor.ButtonDefinition

        '48
        Private WithEvents m_导入存货编码_Buttondef As Inventor.ButtonDefinition

        '49
        Private WithEvents m_ERP材料编码_Buttondef As ButtonDefinition

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

        ''27
        'Private WithEvents m_关闭所有零件_Buttondef As ButtonDefinition

        ''28
        'Private WithEvents m_关闭所有工程图_Buttondef As ButtonDefinition





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
            'AddHandler ThisApplicationEvents.OnOpenDocument, AddressOf ThisApplicationEvents_OnOpenDocument
            AddHandler ThisApplicationEvents.OnActivateDocument, AddressOf ThisApplicationEvents_OnActivateDocument
            'AddHandler ThisApplicationEvents.OnSaveDocument, AddressOf ThisApplicationEvents_OnOnSaveDocument

            ' TODO:  Add ApplicationAddInServer.Activate implementation.
            ' e.g. event initialization, command creation etc.

            ContentCenterFiles = ThisApplication.FileOptions.ContentCenterPath  '初始化零件库
            'MsgBox(ContentCenterFiles)

            '初始化图号文件名映射
            Map_StochNum = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapStochNum", "库存编号")
            If Map_StochNum Is Nothing Then
                Map_StochNum = "库存编号"
            End If

            Map_PartName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPartName", "零件代号")
            If Map_PartName Is Nothing Then
                Map_PartName = "零件代号"
            End If

            Map_PartNum = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPartNum", "成本中心")
            If Map_PartNum Is Nothing Then
                Map_PartNum = "成本中心"
            End If

            '初始化对称件图号文件名映射
            Map_Mir_StochNum = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMirStochNum", "对称件图号")
            If Map_Mir_StochNum Is Nothing Then
                Map_Mir_StochNum = "对称件图号"
            End If

            Map_Mir_PartName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMirPartName", "对称件名称")
            If Map_Mir_PartName Is Nothing Then
                Map_Mir_PartName = "对称件名称"
            End If

            '初始化比例映射
            Map_DrawingScale = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapDrawingScale", "比例")
            If Map_DrawingScale Is Nothing Then
                Map_DrawingScale = "比例"
            End If

            IsSetDrawingScale = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsSetDrawingScale", "-1")

            '初始化质量映射
            Map_Mass = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMass", "质量")
            If Map_Mass Is Nothing Then
                Map_Mass = "质量"
            End If

            IsSetMass = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsSetMass", "-1")
            If IsSetMass Is Nothing Then
                IsSetMass = -1
            End If

            '初始化打印时间映射
            Map_PrintDay = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPrintDay", "打印日期")
            If Map_PrintDay Is Nothing Then
                Map_PrintDay = "打印日期"
            End If

            IsOpenPrint = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsOpenPrint", "-1")
            If IsOpenPrint Is Nothing Then
                IsOpenPrint = -1
            End If

            IsDayAndName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsDayAndName", "-1")
            If IsDayAndName Is Nothing Then
                IsDayAndName = -1
            End If

            '工程师
            EngineerName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "EngineerName", "")

            'BOM导出表头
            BOMTiTle = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "BOMTiTle", "库存编号|空格|零件代号|材料|质量|所属装配代号|数量|总数量|描述")
            If BOMTiTle Is Nothing Then
                BOMTiTle = "库存编号|空格|零件代号|材料|质量|所属装配代号|数量|总数量|描述"
            End If

            '质量精度
            Mass_Accuracy = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Mass_Accuracy", "2")
            If Mass_Accuracy Is Nothing Then
                Mass_Accuracy = "2"
            End If

            '面积精度
            Area_Accuracy = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Area_Accuracy", "4")
            If Area_Accuracy Is Nothing Then
                Area_Accuracy = "4"
            End If

            'excel文件名
            Excel_File_Name = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Excel_File_Name", "")

            If Excel_File_Name = "" Then
                Excel_File_Name = My.Application.Info.DirectoryPath & "\最新物料编码.xlsx"
                'MsgBox(Excel_File_Name)
            End If

            'excel文件不存在，到服务器下载
            If IsFileExsts(Excel_File_Name) = False Then
                Dim documentURL As String
                documentURL = "\\Likai-pc\发行版\2011\最新物料编码.xlsx"

                If IsFileExsts(documentURL) = True Then

                    Dim wc As New System.Net.WebClient
                    wc.DownloadFile(documentURL, Excel_File_Name)
                End If
            End If

            '搜索的表
            Sheet_Name = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Sheet_Name", "物料")
            If Sheet_Name Is Nothing Then
                Sheet_Name = "物料"
            End If

            '搜索的范围
            Table_Arrays = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Table_Array", "A,B,C,D,E")
            If Table_Arrays Is Nothing Then
                Table_Arrays = "A,B,C,D,E"
            End If

            '搜索列
            Col_Index_Num = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Col_Index_Num", "B")
            If Col_Index_Num Is Nothing Then
                Col_Index_Num = "B"
            End If

            '检查更新
            CheckUpdate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "CheckUpdate", "1")
            If CheckUpdate Is Nothing Then
                CheckUpdate = "1"
            End If

            '创建按钮
            CreatUI(firstTime)

            '检查更新
            If CheckUpdate = "1" Then
                'NewUpdater.UpDater2(False)

                IsShowUpdateMsg = False
                Dim frmupdate As New frmUpdate
                frmupdate.Visible = False
                frmupdate.ShowDialog()
            End If

            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)

            'End Try

        End Sub

        Public Sub CreatUI(ByVal bfirstTime As Boolean)

            Dim oCommandManager As CommandManager
            Dim oUserInterfaceManager As UserInterfaceManager
            'Dim oIPictureDisp32 As Object  '大图标
            'Dim oIPictureDisp8 As Object   '小图标

            Dim smallPicture As stdole.IPictureDisp
            Dim largePicture As stdole.IPictureDisp

            Try
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

                m_修改文件iProperty_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("修改文件iProperty", "InName修改文件iProperty", _
                                      CommandTypesEnum.kShapeEditCmdType, ClientID, , "以第一个汉字为标识，提取文件名中的图号和名称，根据【iProperty映射】的设置，写入【iProperty】【项目】中的字段。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '2
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.修改部件iProperty161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.修改部件iProperty323224.ToBitmap)
                m_修改部件iProperty_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("修改部件iProperty", "InName修改部件iProperty", _
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
                m_生成图号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("生成图号", "InName生成图号", _
                      CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据第一级部件的图号，设置子级部件或零件的图号变化规则，重命名其文件名。对于新设计先命名后图号特别有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '6
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.更改镜像文件名161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.更改镜像文件名323224.ToBitmap)
                m_更改镜像文件名_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("更改镜像文件名", "InName更改镜像文件名", _
                      CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件中选择一个是镜像生成的文件，修改其文件名，将原基础文件改为临时文件，重新手动指定其基础文件，后还原基础文件。对于基础文件和镜像文件都需修改的文件很有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '7
                'oIPictureDisp32 = GetIcon("InventorAddIn.打开文件夹323224.ico")
                ''oIPictureDisp8 = GetIcon("InventorAddIn.打开文件夹8824.ico")
                'm_打开文件夹_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开文件夹", "InName打开文件夹", _
                '               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开当前文件所在的文件夹。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

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
                m_设置BOM结构_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置BOM结构", "InName设置BOM结构", _
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
                'smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.保存关闭零件161624.ToBitmap)
                'largePicture = PictureConverter.ImageToPictureDisp(My.Resources.保存关闭零件323224.ToBitmap)
                'm_保存关闭所有零件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("保存关闭所有零件", "InName保存关闭所有零件", _
                '    CommandTypesEnum.kShapeEditCmdType, ClientID, "", "保存并关闭打开的所有零件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                ''28
                'smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.保存关闭工程图161624.ToBitmap)
                'largePicture = PictureConverter.ImageToPictureDisp(My.Resources.保存关闭工程图323224.ToBitmap)
                'm_保存关闭所有工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("保存关闭所有工程图", "InName保存关闭所有工程图", _
                '    CommandTypesEnum.kShapeEditCmdType, ClientID, "", "保存并关闭打开的所有工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '29
                'oIPictureDisp32 = GetIcon("InventorAddIn.绘制槽孔323224.ico")
                'm_绘制槽孔_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("绘制槽孔", "InName绘制槽孔", _
                '                    CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在二维草图中绘制槽孔，鼠标选择一个点，为第一个圆中心，输入槽孔的高度（圆直径）和宽度（两圆中心距），单位毫米（mm）。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '30
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置描述161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置描述323224.ToBitmap)
                m_设置描述_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置描述", "InName设置描述", _
                    CommandTypesEnum.kShapeEditCmdType, ClientID, "", "输入文字，设置到 【Iproperty】【项目】【描述的值】", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

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
                    CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在工程图选择一个尺寸，在尺寸前添加 Φ。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '34
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.全部另存为161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.全部另存为323224.ToBitmap)
                m_全部另存为_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("全部另存为", "InName全部另存为", _
                    CommandTypesEnum.kShapeEditCmdType, ClientID, "", "保存打开的全部工程图为 Pdf 或 Dwg 格式。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

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
                m_调整IPro顺序_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("调整IPro顺序", "InName调整IPro顺序", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "交换IProperty中零件代号、库存编号、描述三者的数据。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '44
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.插入序号161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.插入序号323224.ToBitmap)
                m_插入序号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("插入序号", "InName插入序号", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "插入一个序号。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '47
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.尺寸圆整161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.尺寸圆整323224.ToBitmap)
                m_尺寸圆整_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("尺寸圆整", "InName尺寸圆整", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "尺寸圆整，四舍五入尺寸小数位到个位。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '48
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置材料编码161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置材料编码323224.ToBitmap)
                m_导入存货编码_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("导入存货编码", "InName导入存货编码", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "导入存货编码。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '49
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.设置材料编码161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.设置材料编码323224.ToBitmap)
                m_ERP材料编码_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置材料编码", "InName设置材料编码", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "设置ERP编码。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '50
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.工程图161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.工程图323224.ToBitmap)
                m_打开工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开工程图", "InName打开工程图", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开当前文件或部件中选择的文件对应的工程图。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                '51
                smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.打印161624.ToBitmap)
                largePicture = PictureConverter.ImageToPictureDisp(My.Resources.打印323224.ToBitmap)
                m_批量打印_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("批量打印工程图", "InName批量打印", _
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

                ''56
                'smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.关闭零件161624.ToBitmap)
                'largePicture = PictureConverter.ImageToPictureDisp(My.Resources.关闭零件323224.ToBitmap)
                'm_关闭所有零件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("关闭所有零件", "InName关闭所有零件", _
                '    CommandTypesEnum.kShapeEditCmdType, ClientID, "", "关闭打开的所有零件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

                ''57
                'smallPicture = PictureConverter.ImageToPictureDisp(My.Resources.关闭工程图161624.ToBitmap)
                'largePicture = PictureConverter.ImageToPictureDisp(My.Resources.关闭工程图323224.ToBitmap)
                'm_关闭所有工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("关闭所有工程图", "InName关闭所有工程图", _
                '    CommandTypesEnum.kShapeEditCmdType, ClientID, "", "关闭打开的所有工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)



                '  Dim oUserInterfaceManager As Inventor.UserInterfaceManager = ThisApplication.UserInterfaceManager

                If bfirstTime Then

                    '==========================================
                    'oButtonDefinitions.Clear()
                    'oButtonDefinitions.Add()
                    'oButtonDefinitions.Add()
                    'oButtonDefinitions.Add()
                    'panel.CommandControls.AddPopup(, oButtonDefinitions, False)
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
                        oRibbonTab = oRibbon.RibbonTabs.Item("id_GetStarted")
                        oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaAssemblyPanel", ClientID)

                        oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)
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

                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        '部件环境
                        oRibbon = oUserInterfaceManager.Ribbons.Item("Assembly")

                        '工具选项卡
                        oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")
                        '装配选项卡
                        oRibbonTab = oRibbon.RibbonTabs.Item("id_TabAssemble")

                        ' Create a new panel on the Assemble tab.

                        oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaAssemblyPanel", ClientID)
                        ' Add the buttons to the tab, with the first and last ones being large and the other two small.
                        oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)
                        oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                        oRibbonPanel.CommandControls.AddButton(m_打开工程图_Buttondef, True)

                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                        oButtonDefinitions.Add(m_修改部件iProperty_Buttondef)
                        oButtonDefinitions.Add(m_设置描述_Buttondef)
                       
                        oButtonDefinitions.Add(m_调整IPro顺序_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)

                        '==========================================

                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_更改文件名_Buttondef)
                        oButtonDefinitions.Add(m_更改镜像文件名_Buttondef)
                        oButtonDefinitions.Add(m_提取iPro修改文件名_Buttondef)
                        oButtonDefinitions.Add(m_部件替换文件名_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_更改文件名_Buttondef, oButtonDefinitions, False)
                        '==========================================

                        '==========================================
                        oRibbonPanel.CommandControls.AddButton(m_保存关闭所有部件_Buttondef, False)
                        'oButtonDefinitions.Clear()
                        'oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)
                        'oButtonDefinitions.Add(m_保存关闭所有零件_Buttondef)
                        'oButtonDefinitions.Add(m_保存关闭所有工程图_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有部件_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有零件_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有工程图_Buttondef)
                        'oRibbonPanel.CommandControls.AddPopup(m_保存关闭所有部件_Buttondef, oButtonDefinitions, False)
                        '==========================================

                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_检查是否有工程图_Buttondef)
                        'oButtonDefinitions.Add(m_打开全部工程图_Buttondef)
                        oButtonDefinitions.Add(m_打开指定工程图_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_检查是否有工程图_Buttondef, oButtonDefinitions, False)
                        '==========================================

                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_ERP材料编码_Buttondef)
                        oButtonDefinitions.Add(m_查询ERP编码_Buttondef)
                        oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)
                        oButtonDefinitions.Add(m_导入存货编码_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_ERP材料编码_Buttondef, oButtonDefinitions, False)


                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                        'oButtonDefinitions.Add(m_查找部件_Buttondef)
                        oButtonDefinitions.Add(m_对齐原始坐标面_Buttondef)

                        oButtonDefinitions.Add(m_另存为Pdf_Buttondef)
                        oButtonDefinitions.Add(m_生成图号_Buttondef)
                        oButtonDefinitions.Add(m_设置BOM结构_Buttondef)
                        oButtonDefinitions.Add(m_导出平面BOM_Buttondef)
                        oButtonDefinitions.Add(m_刷新引用_Buttondef)
                        oButtonDefinitions.Add(m_移动指定文件_Buttondef)
                        oButtonDefinitions.Add(m_查找缺失文件的部件_Buttondef)
                        oButtonDefinitions.Add(m_统计质量面积_Buttondef)

                        oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)

                        '==========================================

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

                        '+++++++++++.+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        '零件环境
                        oRibbon = oUserInterfaceManager.Ribbons.Item("Part")

                        '工具选项卡
                        'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")

                        '模型选项卡
                        oRibbonTab = oRibbon.RibbonTabs.Item("id_TabModel")

                        oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaPartPanel", ClientID)

                        oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)
                        oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                        oRibbonPanel.CommandControls.AddButton(m_打开工程图_Buttondef, True)

                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                        oButtonDefinitions.Add(m_设置描述_Buttondef)
                        'oButtonDefinitions.Add(m_设置材料编码_Buttondef)
                        'oButtonDefinitions.Add(m_查询ERP编码_Buttondef)
                        'oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)
                        oButtonDefinitions.Add(m_调整IPro顺序_Buttondef)

                        oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)
                        '==========================================

                        '==========================================
                        oRibbonPanel.CommandControls.AddButton(m_保存关闭所有部件_Buttondef, False)
                        'oButtonDefinitions.Clear()
                        'oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)
                        'oButtonDefinitions.Add(m_保存关闭所有零件_Buttondef)
                        'oButtonDefinitions.Add(m_保存关闭所有工程图_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有部件_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有零件_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有工程图_Buttondef)
                        'oRibbonPanel.CommandControls.AddPopup(m_保存关闭所有部件_Buttondef, oButtonDefinitions, False)
                        '==========================================

                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_ERP材料编码_Buttondef)
                        oButtonDefinitions.Add(m_查询ERP编码_Buttondef)
                        oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)
                        oButtonDefinitions.Add(m_导入存货编码_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_ERP材料编码_Buttondef, oButtonDefinitions, False)


                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                        oButtonDefinitions.Add(m_另存为Pdf_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)
                        '==========================================

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

                        '钣金选项卡
                        oRibbonTab = oRibbon.RibbonTabs.Item("id_TabSheetMetal")

                        oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaPartPanel", ClientID)

                        oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                        oRibbonPanel.CommandControls.AddButton(m_打开工程图_Buttondef, True)

                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                        oButtonDefinitions.Add(m_设置描述_Buttondef)
                        'oButtonDefinitions.Add(m_设置材料编码_Buttondef)
                        'oButtonDefinitions.Add(m_查询ERP编码_Buttondef)
                        'oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)
                        oButtonDefinitions.Add(m_调整IPro顺序_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)

                        '==========================================

                        '==========================================
                        oRibbonPanel.CommandControls.AddButton(m_保存关闭所有部件_Buttondef, False)
                        'oButtonDefinitions.Clear()
                        'oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)
                        'oButtonDefinitions.Add(m_保存关闭所有零件_Buttondef)
                        'oButtonDefinitions.Add(m_保存关闭所有工程图_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有部件_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有零件_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有工程图_Buttondef)
                        'oRibbonPanel.CommandControls.AddPopup(m_保存关闭所有部件_Buttondef, oButtonDefinitions, False)
                        '==========================================


                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_ERP材料编码_Buttondef)
                        oButtonDefinitions.Add(m_查询ERP编码_Buttondef)
                        oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)
                        oButtonDefinitions.Add(m_导入存货编码_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_ERP材料编码_Buttondef, oButtonDefinitions, False)



                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                        oButtonDefinitions.Add(m_另存为Pdf_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)
                        '==========================================

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

                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        '工程图环境
                        oRibbon = oUserInterfaceManager.Ribbons.Item("Drawing")
                        'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabPlaceViews")

                        '在放置视图选项卡中添加

                        oRibbonTab = oRibbon.RibbonTabs.Item("id_TabPlaceViews")
                        oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaDrawingPanel", ClientID)

                        oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)
                        oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                        oRibbonPanel.CommandControls.AddButton(m_打开文件夹_Buttondef, True)

                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_另存为Dwg_Buttondef)
                        oButtonDefinitions.Add(m_另存为Pdf_Buttondef)
                        oButtonDefinitions.Add(m_全部另存为_Buttondef)
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

                        '在工具选项卡中添加
                        oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")
                        oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaDrawingPanel", ClientID)

                        oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)

                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                        oButtonDefinitions.Add(m_设置描述_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)
                        '==========================================

                        oRibbonPanel.CommandControls.AddButton(m_打开文件夹_Buttondef)

                        '==========================================
                        oRibbonPanel.CommandControls.AddButton(m_保存关闭所有部件_Buttondef, False)
                        'oButtonDefinitions.Clear()
                        'oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)
                        'oButtonDefinitions.Add(m_保存关闭所有零件_Buttondef)
                        'oButtonDefinitions.Add(m_保存关闭所有工程图_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有部件_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有零件_Buttondef)
                        'oButtonDefinitions.Add(m_关闭所有工程图_Buttondef)
                        'oRibbonPanel.CommandControls.AddPopup(m_保存关闭所有部件_Buttondef, oButtonDefinitions, False)
                        '==========================================

                        '==========================================
                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_另存为Dwg_Buttondef)
                        oButtonDefinitions.Add(m_另存为Pdf_Buttondef)
                        oButtonDefinitions.Add(m_全部另存为_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_另存为Dwg_Buttondef, oButtonDefinitions, False)
                        '==========================================

                        '==========================================
                        'oButtonDefinitions.Clear()
                        'oButtonDefinitions.Add(m_对称件iProperty_Buttondef)
                        ''oButtonDefinitions.Add(m_设置比例_Buttondef)
                        'panel.CommandControls.AddPopup(m_对称件iProperty_Buttondef, oButtonDefinitions, False)
                        ''==========================================

                        ''----------------------------------------------------------------------------------
                        'oButtonDefinitions.Clear()
                        'oButtonDefinitions.Add(m_检查序号完整性_Buttondef)
                        'oButtonDefinitions.Add(m_新建序号_Buttondef)
                        'panel.CommandControls.AddPopup(m_检查序号完整性_Buttondef, oButtonDefinitions, False)

                        '----------------------------------------------------------------------------------
                        '日期popup  '签字popup
                        oButtonDefinitions.Clear()

                        oButtonDefinitions.Add(m_设置签字_Buttondef)
                        oButtonDefinitions.Add(m_清除签字_Buttondef)
                        oButtonDefinitions.Add(m_自定义签字_Buttondef)

                        'oButtonDefinitions.Add(m_设置日期_Buttondef)
                        'oButtonDefinitions.Add(m_清除日期_Buttondef)
                        'oButtonDefinitions.Add(m_自定义日期_Buttondef)

                        'panel.CommandControls.AddPopup(m_设置日期_Buttondef, oButtonDefinitions, False)

                        oRibbonPanel.CommandControls.AddPopup(m_设置签字_Buttondef, oButtonDefinitions, False)

                        '----------------------------------------------------------------------------------

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

                        '在标注选项卡中添加
                        oRibbonTab = oRibbon.RibbonTabs.Item("id_TabAnnotate")
                        '在尺寸栏添加
                        oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelD_AnnotateDimension")

                        oRibbonPanel.CommandControls.AddButton(m_添加直径_Buttondef)
                        oRibbonPanel.CommandControls.AddButton(m_尺寸圆整_Buttondef)

                        '在表格栏添加
                        oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelD_AnnotateTable")
                        oRibbonPanel.CommandControls.AddButton(m_设置对称件iProperty_Buttondef)
                        'panel.CommandControls.AddButton(m_检查序号完整性_Buttondef)
                        'panel.CommandControls.AddButton(m_新建序号_Buttondef)

                        oButtonDefinitions.Clear()
                        oButtonDefinitions.Add(m_检查序号完整性_Buttondef)
                        oButtonDefinitions.Add(m_新建序号_Buttondef)
                        oButtonDefinitions.Add(m_插入序号_Buttondef)
                        oButtonDefinitions.Add(m_重写BOM序号_Buttondef)
                        oRibbonPanel.CommandControls.AddPopup(m_检查序号完整性_Buttondef, oButtonDefinitions, False)

                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        '二维草图

                        oRibbon = oUserInterfaceManager.Ribbons.Item("Part")

                        oRibbonTab = oRibbon.RibbonTabs.Item("id_TabSketch")

                        oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaSketchPanel", ClientID)

                        'panel.CommandControls.AddButton(m_绘制横直线_Buttondef)
                        'panel.CommandControls.AddButton(m_绘制竖直线_Buttondef)
                        'panel.CommandControls.AddButton(m_绘制圆_Buttondef)
                        'panel.CommandControls.AddButton(m_绘制槽孔_Buttondef)

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

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        '------------------------------------------------------------
        '定义图标
        Private Function GetIcon(ByVal IconName As String) As Object
            Dim oStream As System.IO.Stream = Me.GetType().Assembly.GetManifestResourceStream(IconName)
            If oStream Is Nothing Then
                Return Nothing
            End If

            Dim oIcon As Icon = New Icon(oStream)
            Dim oIPictureDisp32 As Object = Microsoft.VisualBasic.Compatibility.VB6.Support.IconToIPicture(oIcon)
            Return oIPictureDisp32

        End Function

        '以下按钮事件
        '------------------------------------------------------
        Private Sub m_修改文件iProperty_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_修改文件iProperty_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDocument As Inventor.Document      '当前文件
                InventorDocument = ThisApplication.ActiveEditDocument

                If SetDocumentIpropertyFromFileName(InventorDocument, False) Then
                    SetStatusBarText("获取编辑中的文件名修改iProperty完成")
                    'MsgBox("获取编辑中的文件名修改iProperty完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    MsgBox("错误", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_修改部件iProperty_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_修改部件iProperty_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDocument As Inventor.Document     '当前文件
                InventorDocument = ThisApplication.ActiveDocument

                If InventorDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                    Exit Sub
                End If

                If SetDocumentsInAssIpropertyFromFileName(InventorDocument, False) Then
                    SetStatusBarText("获取当前部件中的子集文件名修改iProperty完成")
                    'MsgBox("获取当前部件中的文件名修改iProperty完成", MsgBoxStyle.Information)

                Else
                    SetStatusBarText("错误")
                    MsgBox("错误", MsgBoxStyle.Exclamation)

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_设置描述_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置描述_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDocument As Inventor.Document     '当前编辑文件
                InventorDocument = ThisApplication.ActiveEditDocument

                Dim frmInputBox As New frmInputBox
                With frmInputBox
                    .Text = "设置描述"
                    .lblDescribe.Text = "输入描述，写到【iProperty】【项目】【描述】"
                    .txtInPut.Text = GetPropitem(InventorDocument, "描述")
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With

                If frmInputBox.DialogResult = Windows.Forms.DialogResult.OK Then

                    If SetPropitem(InventorDocument, "描述", frmInputBox.txtInPut.Text) Then
                        SetStatusBarText("设置描述完成。")
                    Else
                        SetStatusBarText("错误")
                        MsgBox("错误", MsgBoxStyle.Exclamation)

                    End If
                Else
                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_ERP材料编码_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_ERP材料编码_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDocument As Inventor.Document     '当前编辑文件
                InventorDocument = ThisApplication.ActiveEditDocument

                Dim frmInputBox As New frmInputBox
                With frmInputBox
                    .Text = "设置材料编码"
                    .lblDescribe.Text = "输入材料编码，写到【iProperty】【项目】【" & Map_PartNum & "】"
                    .txtInPut.Text = GetPropitem(InventorDocument, Map_PartNum)
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With

                If frmInputBox.DialogResult = Windows.Forms.DialogResult.OK Then

                    If SetPropitem(InventorDocument, Map_PartNum, frmInputBox.txtInPut.Text) Then
                        SetStatusBarText("设置材料编码完成。")
                    Else
                        SetStatusBarText("错误")
                        MsgBox("错误", MsgBoxStyle.Exclamation)

                    End If
                Else
                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_更改文件名_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_更改文件名_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDocument As Inventor.Document
                InventorDocument = ThisApplication.ActiveDocument

                If InventorDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information, "修改文件名")
                    Exit Sub
                End If

                Dim OldComponentOccurrence As ComponentOccurrence   '选择的部件或零件

                If InventorDocument.SelectSet.Count <> 0 Then
                    'For Each oSelect As Object In InventorDoc.SelectSet
                    OldComponentOccurrence = InventorDocument.SelectSet(1)
                    'Next
                Else
                    OldComponentOccurrence = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要更改文件名的零件或部件")
                End If

                If OldComponentOccurrence Is Nothing Then       '取消选择
                    Exit Sub
                End If

                Select Case OldComponentOccurrence.DefinitionDocumentType
                    Case kAssemblyDocumentObject, kPartDocumentObject

                        Dim NewFileName As String   '新文件仅文件名

                        Dim OldFullFileName As String   '被替换的旧文件全名
                        Dim OldFileName As String   '被替换的旧文件仅文件名
                        OldFullFileName = OldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
                        OldFileName = GetFileNameInfo(OldFullFileName).ONlyName

                        NewFileName = InputBox("重命名 " & OldFullFileName, "重命名", OldFileName)  '输入新文件名

                        If RenameAssPartDocumentName(InventorDocument, OldComponentOccurrence, NewFileName) Then
                            SetStatusBarText("更改零件/部件文件名完成")
                            'MsgBox("更改零件/部件文件名完成", MsgBoxStyle.Information)

                        Else
                            SetStatusBarText("错误")
                            MsgBox("错误", MsgBoxStyle.Exclamation)

                        End If
                    Case Else

                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_提取iPro修改文件名_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_提取iPro修改文件名_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                '判断是否为 assdoc
                Dim InventorDocument As Inventor.Document

                InventorDocument = ThisApplication.ActiveDocument

                If InventorDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim OldComponentOccurrence As ComponentOccurrence   '选择的部件或零件

                If InventorDocument.SelectSet.Count <> 0 Then
                    'For Each oSelect As Object In InventorDoc.SelectSet
                    OldComponentOccurrence = InventorDocument.SelectSet(1)
                    'Next
                Else
                    OldComponentOccurrence = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要更改文件名的的零件或部件")
                End If

                If OldComponentOccurrence Is Nothing Then       '取消选择
                    Exit Sub
                End If

                If GetIpropertyToRename(InventorDocument, OldComponentOccurrence) Then
                    SetStatusBarText("提取iproperty更改文件名完成")
                    'MsgBox("提取iproperty更改文件名完成", MsgBoxStyle.Information)

                Else
                    SetStatusBarText("错误")
                    MsgBox("错误", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_生成图号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_生成图号_Buttondef.OnExecute
            Dim AutoPartNumber As New frmAutoPartNumber
            AutoPartNumber.Show()
        End Sub

        Private Sub m_更改镜像文件名_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_更改镜像文件名_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDocument As Inventor.Document
                InventorDocument = ThisApplication.ActiveDocument

                If InventorDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim OldComponentOccurrence As ComponentOccurrence   '选择的部件或零件

                If InventorDocument.SelectSet.Count <> 0 Then
                    'For Each oSelect As Object In InventorDoc.SelectSet
                    OldComponentOccurrence = InventorDocument.SelectSet(1)
                    'Next
                Else
                    OldComponentOccurrence = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要更改文件名的的零件或部件")
                End If

                If OldComponentOccurrence Is Nothing Then       '取消选择
                    Exit Sub
                End If

                Select Case OldComponentOccurrence.DefinitionDocumentType
                    Case kPartDocumentObject, kAssemblyDocumentObject      '选择的是部件或零件

                        Dim OldFullFileName As String   '被替换的旧文件全名
                        Dim OldFileName As String   '被替换的旧文件仅文件名
                        OldFullFileName = OldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
                        OldFileName = GetFileNameInfo(OldFullFileName).ONlyName

                        Dim NewFileName As String   '新文件仅文件名
                        NewFileName = InputBox("重命名 " & OldFullFileName, "镜像重命名", OldFileName)  '输入新文件名

                        '取消输入
                        If NewFileName = "" Then
                            Exit Sub
                        End If

                        If RenameMirrorAssPartDocumentName(InventorDocument, OldComponentOccurrence, NewFileName) Then
                            SetStatusBarText("更改镜像零件/部件文件名完成")
                            'MsgBox("更改零件/部件文件名完成", MsgBoxStyle.Information)

                        Else
                            SetStatusBarText("错误")
                            MsgBox("错误", MsgBoxStyle.Exclamation)

                        End If
                    Case MsgBox("选择的文件不是零件或部件", MsgBoxStyle.Information)

                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_打开文件夹_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_打开文件夹_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDocument As Inventor.Document
                Dim InventorDocumentFileNameInfo As FileNameInfo
                InventorDocument = ThisApplication.ActiveEditDocument
                InventorDocumentFileNameInfo = GetFileNameInfo(InventorDocument.FullDocumentName)
                Process.Start(InventorDocumentFileNameInfo.Folder)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_保存关闭_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_保存关闭_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                With ThisApplication.ActiveDocument
                    If IsFileExsts(.FullDocumentName) = True Then
                        .Save2(True)
                        .Close()
                    Else
                        .Save()
                        .Close()
                    End If
                End With

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_另存为Pdf_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_另存为Pdf_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDocument As Inventor.Document
                InventorDocument = ThisApplication.ActiveDocument

                Dim PdfFullFileName As String

                PdfFullFileName = SaveAsPdf(InventorDocument)

                If PdfFullFileName = "取消" Then
                    SetStatusBarText("另存为PDF完成")
                    Exit Sub
                End If

                If IsFileExsts(PdfFullFileName) Then
                    SetStatusBarText("另存为PDF完成")
                    If MsgBox("是否打开文件： " & PdfFullFileName, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        System.Diagnostics.Process.Start(PdfFullFileName)
                    End If
                Else
                    SetStatusBarText("错误")
                    MsgBox("错误", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_另存为Dwg_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_另存为Dwg_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                    MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorDrawingDocument As Inventor.DrawingDocument
                InventorDrawingDocument = ThisApplication.ActiveDocument

                Dim DwgFullFileName As String

                DwgFullFileName = SaveAsDwg(InventorDrawingDocument)

                Select Case DwgFullFileName
                    Case "非工程图"
                        SetStatusBarText("该文件非工程图。")
                        Exit Sub
                    Case "取消"
                        SetStatusBarText("取消。")
                        Exit Sub
                End Select

                If IsFileExsts(DwgFullFileName) Then
                    SetStatusBarText("另存为CAD-DWG完成")
                    If MsgBox("是否打开文件： " & DwgFullFileName, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        System.Diagnostics.Process.Start(DwgFullFileName)
                    End If
                Else
                    SetStatusBarText("错误")
                    MsgBox("错误", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_设置BOM结构_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置BOM结构_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorAssemblyDocument As Inventor.AssemblyDocument
                InventorAssemblyDocument = ThisApplication.ActiveDocument

                If SetBOMStructuret(InventorAssemblyDocument) Then
                    SetStatusBarText(" 设置BOM结构完成")
                    'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    'MsgBox("错误", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_设置比例_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置比例_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                    MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorDrawingDocument As Inventor.DrawingDocument
                InventorDrawingDocument = ThisApplication.ActiveDocument

                If SetDrawingScale(InventorDrawingDocument) Then
                    SetStatusBarText("设置工程图自定义属性：比例完成")
                    'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    MsgBox("错误", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_设置对称件iProperty_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置对称件iProperty_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDrawingDocument As Inventor.DrawingDocument
                InventorDrawingDocument = ThisApplication.ActiveDocument

                If SetDrawingMirPartIPro(InventorDrawingDocument) Then
                    SetStatusBarText("设置工程图自定义属性：对称件IPro")
                    'MsgBox("设置工程图自定义属性：对称件IPro", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    MsgBox("错误", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_序号完整性_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_检查序号完整性_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                    MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorDrawingDocument As Inventor.DrawingDocument
                InventorDrawingDocument = ThisApplication.ActiveDocument

                If CheckSerialNumber(InventorDrawingDocument) Then
                    SetStatusBarText("检查序号完整性完成")
                    MsgBox("检查序号完整性完成", MsgBoxStyle.Information)
                Else

                    'SetStatusBarText("错误")
                    'MsgBox("错误", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_新建序号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_新建序号_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                    MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorDrawingDocument As Inventor.DrawingDocument
                InventorDrawingDocument = ThisApplication.ActiveDocument

                '设置为一个动作，可一次撤销
                Dim oTransientGeometry As TransientGeometry
                oTransientGeometry = ThisApplication.TransientGeometry
                'start a transaction so the slot will be within a single undo step
                Dim createSlotTransaction As Transaction
                createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "重新设置序号")

                If SetSerialNumber(InventorDrawingDocument) Then
                    SetStatusBarText("重新设置序号完成")
                    'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    'MsgBox("错误", MsgBoxStyle.Exclamation)

                End If

                'end the transactio
                createSlotTransaction.End()

            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_插入序号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_插入序号_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                    MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorDrawingDocument As Inventor.DrawingDocument
                InventorDrawingDocument = ThisApplication.ActiveDocument

                '设置为一个动作，可一次撤销
                Dim oTransientGeometry As TransientGeometry
                oTransientGeometry = ThisApplication.TransientGeometry
                'start a transaction so the slot will be within a single undo step

                Dim createSlotTransaction As Transaction
                createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "插入序号")

                If InsertSerialNumber(InventorDrawingDocument) Then
                    SetStatusBarText("插入序号完成")
                    'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    'MsgBox("错误", MsgBoxStyle.Exclamation)

                End If

                'end the transactio
                createSlotTransaction.End()

            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_设置签字_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置签字_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                    MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorDrawingDocument As Inventor.DrawingDocument
                InventorDrawingDocument = ThisApplication.ActiveDocument

                Dim Print_Day As String

                Print_Day = Today.Year & "." & Today.Month & "." & Today.Day

                If SetSign(InventorDrawingDocument, EngineerName, Print_Day, True) Then
                    SetStatusBarText("设置工程图属性：签字完成")
                Else
                    SetStatusBarText("错误")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_清除签字_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_清除签字_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                    MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorDrawingDocument As Inventor.DrawingDocument
                InventorDrawingDocument = ThisApplication.ActiveDocument

                If SetSign(InventorDrawingDocument, "", "", False) Then
                    SetStatusBarText("清除工程图属性，签字完成")
                Else
                    SetStatusBarText("错误")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_自定义签字_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_自定义签字_Buttondef.OnExecute
            Dim frmSign As New frmSign
            frmSign.ShowDialog()
        End Sub

        Private Sub m_设置_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置_Buttondef.OnExecute
            Dim frmOption As New frmOption
            frmOption.ShowDialog()
        End Sub

        Private Sub m_量产iPropertys_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_量产iPropertys_Buttondef.OnExecute
            Dim frmiPoperties As New frmiPoperties
            frmiPoperties.ShowDialog()
        End Sub

        Private Sub m_批量打印_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_批量打印_Buttondef.OnExecute
            Dim frmPrint As New frmPrint
            frmPrint.ShowDialog()
        End Sub

        Private Sub m_工程图批量另存为_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_工程图批量另存为_Buttondef.OnExecute
            Dim SaveAsDialog As New frmSaveAs
            SaveAsDialog.ShowDialog()
        End Sub

        Private Sub m_全部另存为_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_全部另存为_Buttondef.OnExecute
            Dim frmAllSaveAs As New frmAllSaveAs
            frmAllSaveAs.ShowDialog()
        End Sub

        'Public oclsMousePosition As clsDrawSlot
        ' Private oMousePosition As Point2d

        Private Sub m_还原旧图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_还原旧图_Buttondef.OnExecute
            '打开文件
            Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

            With oOpenFileDialog
                .Title = "打开"
                .Filter = "AutoDesk Inventor 旧文件(*.old)|*.old" '添加过滤文件
                .Multiselect = True '多开文件打开
                If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                    If .FileName <> "" Then '如果有选中文件
                        Dim OldFullFileName As String
                        Dim NewFullFileName As String
                        For Each OldFullFileName In .FileNames
                            NewFullFileName = Left(OldFullFileName, Strings.Len(OldFullFileName) - 4)
                            Rename(OldFullFileName, NewFullFileName)
                        Next
                    End If
                    MsgBox("更改旧文件名完成。")
                End If
            End With

        End Sub

        Private Sub m_关于_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_关于_Buttondef.OnExecute
            'Dim HelpMessage As String = "当前版本：" & My.Application.Info.Version.ToString & GetBiaoQing()

            'MsgBox(HelpMessage, MsgBoxStyle.Information)

            Dim frmAbout As New frmAbout
            frmAbout.ShowDialog()

            '============================================================
            '测试代码

            '============================================================
        End Sub

        Private Sub m_帮助_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_帮助_Buttondef.OnExecute
            Dim HelpFullFileName As String
            HelpFullFileName = My.Application.Info.DirectoryPath & "\帮助.pdf"

            Process.Start(HelpFullFileName)

        End Sub

        Private Sub m_保存关闭所有部件_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_保存关闭所有部件_Buttondef.OnExecute

            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim frmSaveAll As New frmSaveAll
                frmSaveAll.ShowDialog()

                'For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
                '    If oInventorDocument.DocumentType = kAssemblyDocumentObject Then
                '        With oInventorDocument
                '            If IsFileExsts(.FullDocumentName) = True Then
                '                .Save2(True)
                '                .Close()
                '            End If
                '        End With
                '    End If
                'Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        'Private Sub m_保存关闭所有零件_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_保存关闭所有零件_Buttondef.OnExecute

        '    Try
        '        SetStatusBarText()

        '        If IsInventorOpenDoc() = False Then
        '            Exit Sub
        '        End If

        '        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
        '            If oInventorDocument.DocumentType = kPartDocumentObject Then
        '                With oInventorDocument
        '                    If IsFileExsts(.FullDocumentName) = True Then
        '                        .Save2(True)
        '                        .Close()
        '                    End If
        '                End With
        '            End If
        '        Next

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End Sub

        'Private Sub m_保存关闭所有工程图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_保存关闭所有工程图_Buttondef.OnExecute

        '    Try
        '        SetStatusBarText()

        '        If IsInventorOpenDoc() = False Then
        '            Exit Sub
        '        End If

        '        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
        '            If oInventorDocument.DocumentType = kDrawingDocumentObject Then
        '                With oInventorDocument
        '                    If IsFileExsts(.FullDocumentName) = True Then
        '                        .Save2(True)
        '                        .Close()
        '                    End If
        '                End With
        '            End If
        '        Next

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End Sub


        'Private Sub m_关闭所有部件_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_关闭所有部件_Buttondef.OnExecute

        '    Try
        '        SetStatusBarText()

        '        If IsInventorOpenDoc() = False Then
        '            Exit Sub
        '        End If

        '        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
        '            If oInventorDocument.DocumentType = kAssemblyDocumentObject Then
        '                With oInventorDocument
        '                    If IsFileExsts(.FullDocumentName) = True Then
        '                        .Close(True)
        '                    End If
        '                End With
        '            End If
        '        Next

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End Sub

        'Private Sub m_关闭所有零件_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_关闭所有零件_Buttondef.OnExecute

        '    Try
        '        SetStatusBarText()

        '        If IsInventorOpenDoc() = False Then
        '            Exit Sub
        '        End If

        '        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
        '            If oInventorDocument.DocumentType = kPartDocumentObject Then
        '                With oInventorDocument
        '                    If IsFileExsts(.FullDocumentName) = True Then
        '                        .Close(True)
        '                    End If
        '                End With
        '            End If
        '        Next

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End Sub

        'Private Sub m_关闭所有工程图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_关闭所有工程图_Buttondef.OnExecute

        '    Try
        '        SetStatusBarText()

        '        If IsInventorOpenDoc() = False Then
        '            Exit Sub
        '        End If

        '        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
        '            If oInventorDocument.DocumentType = kDrawingDocumentObject Then
        '                With oInventorDocument
        '                    If IsFileExsts(.FullDocumentName) = True Then
        '                        .Close(True)
        '                    End If
        '                End With
        '            End If
        '        Next

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End Sub
        'Private Sub m_绘制横直线_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_绘制横直线_Buttondef.OnExecute
        '    Dim oclsDrawLine As clsDrawHLine
        '    oclsDrawLine = New clsDrawHLine(ThisApplication)

        'End Sub

        'Private Sub m_绘制竖直线_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_绘制竖直线_Buttondef.OnExecute
        '    Dim oclsDrawVLine As clsDrawVLine
        '    oclsDrawVLine = New clsDrawVLine(ThisApplication)

        'End Sub

        'Private Sub m_绘制圆_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_绘制圆_Buttondef.OnExecute
        '    Dim oclsDrwCircle As clsDrawCircle
        '    oclsDrwCircle = New clsDrawCircle(ThisApplication)

        'End Sub

        'Private Sub m_绘制槽孔_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_绘制槽孔_Buttondef.OnExecute
        '    Dim DrawSlotDialog As New DrawSlotDialog
        '    DrawSlotDialog.Show()

        'End Sub

        Private Sub m_添加直径_Buttondef_OnExecute() Handles m_添加直径_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                '判断是否为 assdoc
                Dim InventorDocument As Inventor.Document

                InventorDocument = ThisApplication.ActiveDocument

                If InventorDocument.DocumentType <> kDrawingDocumentObject Then
                    MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information, "添加Φ")
                    Exit Sub
                End If

                If ADDFai(InventorDocument) Then
                    SetStatusBarText("添加直径符号Φ完成")
                    'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    'MsgBox("错误", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_检查是否有工程图_Buttondef_OnExecute() Handles m_检查是否有工程图_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                    'Return False
                    Exit Sub
                End If

                Dim InventorAssemblyDocument As Inventor.AssemblyDocument
                InventorAssemblyDocument = ThisApplication.ActiveDocument

                Dim frmInputBox As New frmInputBox
999:
                With frmInputBox
                    .txtInPut.Text = GetPropitem(InventorAssemblyDocument, Map_StochNum)
                    .Text = "检查包号指定字符的工程图"
                    .lblDescribe.Text = "输入要检查的部分图号的。" & vbCrLf & "如要检查全部GT100下的零件是否有工程图，输入GT100即可。"
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With

                If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txtInPut.Text <> "") Then
                    If CheckIsInvHaveIdw(InventorAssemblyDocument, frmInputBox.txtInPut.Text) Then
                        MsgBox("检查是否有工程图完成，打开了未找到工程图对应的模型文件。", MsgBoxStyle.Information)
                    Else
                        SetStatusBarText("错误")
                        'MsgBox("错误", MsgBoxStyle.Exclamation)
                    End If
                ElseIf frmInputBox.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                Else
                    MsgBox("请输入部分图号！", MsgBoxStyle.Information)
                    SetStatusBarText("错误")
                    GoTo 999
                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        'Private Sub m_打开全部工程图_Buttondef_OnExecute() Handles m_打开全部工程图_Buttondef.OnExecute
        '    Try
        '        SetStatusBarText()

        '        If IsInventorOpenDoc() = False Then
        '            Exit Sub
        '        End If

        '        If ThisApplication.ActiveDocument.DocumentType <> kAssemblyDocumentObject Then
        '            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
        '            Exit Sub
        '        End If

        '        Dim AssDoc As AssemblyDocument
        '        AssDoc = ThisApplication.ActiveDocument

        '        If OpenAllDrwInAsm(AssDoc, "") Then
        '            MsgBox("打开了部件所有子集对应的工程图。", MsgBoxStyle.Information)
        '        Else
        '            SetStatusBarText("错误")
        '            'MsgBox("错误", MsgBoxStyle.Exclamation)

        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End Sub

        Private Sub m_打开指定工程图_Buttondef_OnExecute() Handles m_打开指定工程图_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorAssemblyDocument As Inventor.AssemblyDocument
                InventorAssemblyDocument = ThisApplication.ActiveDocument
999:
                Dim frmInputBox As New frmInputBox
                With frmInputBox
                    .txtInPut.Text = GetPropitem(InventorAssemblyDocument, Map_StochNum)
                    .Text = "打开指定工程图"
                    .lblDescribe.Text = "输入包含指定的字段的图号。" & vbCrLf & "如要打开 5183-9000000.aim 下的工程图，输入5183-9即可。"
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With

                If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txtInPut.Text <> "") Then
                    If OpenAllDrwInAsm(InventorAssemblyDocument, frmInputBox.txtInPut.Text) Then
                        MsgBox("打开了部件所有子集对应的工程图。", MsgBoxStyle.Information)
                    Else
                        SetStatusBarText("错误")
                    End If
                ElseIf frmInputBox.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                Else
                    MsgBox("请输入部分图号！", MsgBoxStyle.Information)
                    SetStatusBarText("错误")
                    GoTo 999
                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_部件替换文件名_Buttondef_OnExecute() Handles m_部件替换文件名_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                    'Return False
                    Exit Sub
                End If

                Dim OldName As String
                Dim NewName As String

                OldName = InputBox("输入：查找的内容")
                If OldName = "" Then
                    Exit Sub
                End If

                NewName = InputBox("输入：替换为")
                If NewName = "" Then
                    Exit Sub
                End If

                'OldName = "GT140"
                'NewName = "GT240"

                Dim InventorAssemblyDocument As Inventor.AssemblyDocument
                InventorAssemblyDocument = ThisApplication.ActiveDocument

                Dim IsSaveAsOld As MsgBoxResult
                IsSaveAsOld = MsgBox("是否更改原文件为备份文件，扩展名增加 .old ？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "备份文件")

                ReplaceNameInAsm(InventorAssemblyDocument, OldName, NewName, IsSaveAsOld)

                MsgBox("部件替换文件名完成。", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        ' 导出BOM平面性
        Private Sub m_导出平面BOM_Buttondef_OnExecute() Handles m_导出平面BOM_Buttondef.OnExecute

            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorAssemblyDocument As Inventor.AssemblyDocument

                InventorAssemblyDocument = ThisApplication.ActiveDocument

                If InventorAssemblyDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件")
                    Exit Sub
                End If

                Dim ExcelFullFileName As String

                ExcelFullFileName = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & GetFileNameInfo(InventorAssemblyDocument.FullFileName).ONlyName & "导出BOM.csv"

                If IsFileExsts(ExcelFullFileName) = True Then
                    DelFile(ExcelFullFileName, FileIO.RecycleOption.SendToRecycleBin)
                End If

                'If ExportBOMAsFlat(AssDoc, ExcelFullFileName) Then
                '    SetStatusBarText(" 导出BOM平面性完成")

                '    'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)

                'Else
                '    SetStatusBarText("错误")
                '    'MsgBox("错误", MsgBoxStyle.Exclamation)

                'End If

                ExportBOMAsFlat(InventorAssemblyDocument, ExcelFullFileName)
                SetStatusBarText(" 导出BOM平面性完成")
                Process.Start(ExcelFullFileName)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        ' 刷新引用名称
        Private Sub m_刷新引用_Buttondef_OnExecute() Handles m_刷新引用_Buttondef.OnExecute

            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorAssemblyDocument As Inventor.AssemblyDocument

                InventorAssemblyDocument = ThisApplication.ActiveDocument

                If InventorAssemblyDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件")
                    Exit Sub
                End If

                If RefreshShowName(InventorAssemblyDocument) Then
                    SetStatusBarText("刷新引用完成")
                    MsgBox("刷新引用完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_清理旧版文件_Buttondef_OnExecute() Handles m_清理旧版文件_Buttondef.OnExecute
            Try

                Dim DestinationDirectory As String = Nothing
                Dim inf As FileAttributes
                Dim Present_Folder As String = Nothing

                Dim FolderBrowserDialog As New FolderBrowserDialog

                With FolderBrowserDialog
                    .ShowNewFolderButton = False
                    .Description = "选择文件夹"
                    .RootFolder = System.Environment.SpecialFolder.Desktop
                    If .ShowDialog = DialogResult.OK Then
                        DestinationDirectory = .SelectedPath
                    Else
                        Exit Sub
                    End If
                End With

                'If DestinationDirectory = "" Then
                '    Exit Sub
                'End If

                Dim DeleteRecycleOption As Integer
                Select Case MsgBox("是否永久删除旧文件，而不是移动到回收站？", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question + MsgBoxStyle.YesNo, "删除文件")
                    Case MsgBoxResult.Yes
                        DeleteRecycleOption = FileIO.RecycleOption.DeletePermanently
                    Case MsgBoxResult.No
                        DeleteRecycleOption = FileIO.RecycleOption.SendToRecycleBin
                End Select

                '是否为文件夹，在其后添加 \
                inf = VisualBasic.FileSystem.GetAttr(DestinationDirectory)

                If inf = FileAttributes.Directory Then
                    DestinationDirectory = DestinationDirectory + "\"
                End If

                DelOldDirectory(DestinationDirectory, DeleteRecycleOption)

                SetStatusBarText("就绪")
                MsgBox("清理旧版本文件完成！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "清理旧文件")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_移动指定文件_Buttondef_OnExecute() Handles m_移动指定文件_Buttondef.OnExecute
            Try

                ' 获取激活文档
                Dim InventorAssemblyDocument As Inventor.AssemblyDocument
                InventorAssemblyDocument = ThisApplication.ActiveDocument

999:
                Dim frmInputBox As New frmInputBox

                With frmInputBox
                    .txtInPut.Text = GetPropitem(InventorAssemblyDocument, Map_StochNum)
                    .Text = "移动文件"
                    .lblDescribe.Text = "将保存并关闭当前文档，移动指定的文件到当前部件文件夹。" & vbCrLf & "输入从第一个图号开始的筛选字段。"
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With

                Dim sFilter As String
                If frmInputBox.DialogResult = Windows.Forms.DialogResult.OK And frmInputBox.txtInPut.Text <> "" Then
                    sFilter = frmInputBox.txtInPut.Text
                ElseIf frmInputBox.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                Else
                    MsgBox("请输入部分图号！", MsgBoxStyle.Information)
                    SetStatusBarText("错误")
                    GoTo 999
                    Exit Sub
                End If

                ' 获取所有引用文档
                Dim InventorDocumentsEnumerator As Inventor.DocumentsEnumerator
                InventorDocumentsEnumerator = InventorAssemblyDocument.AllReferencedDocuments

                ' 遍历这些文档

                Dim InvDocList(2000) As String

                ReDim InvDocList(InventorDocumentsEnumerator.Count - 1)

                Dim i As Integer = 0

                For Each oReferencedDocument As Inventor.Document In InventorDocumentsEnumerator
                    Debug.Print(oReferencedDocument.FullFileName)
                    InvDocList(i) = oReferencedDocument.FullFileName
                    i = i + 1
                Next

                Dim oInventorAssemblyDocumentFullDocumentName As String
                oInventorAssemblyDocumentFullDocumentName = InventorAssemblyDocument.FullDocumentName

                '组件所在文件夹
                Dim oAsmDocFolder As String
                oAsmDocFolder = GetFileNameInfo(oInventorAssemblyDocumentFullDocumentName).Folder



                '保存关闭组件
                InventorAssemblyDocument.Close()

                Dim FileNameInfo As FileNameInfo

                For Each InvDoc As String In InvDocList
                    ThisApplication.StatusBarText = InvDoc
                    FileNameInfo = GetFileNameInfo(InvDoc)
                    If InStr(FileNameInfo.ONlyName, sFilter) = 1 Then
                        ReMoveFileToFolder(InvDoc, oAsmDocFolder)
                        Dim IdwDoc As String
                        IdwDoc = GetNewExtensionFileName(InvDoc, ".idw")
                        If IsFileExsts(IdwDoc) = True Then
                            ReMoveFileToFolder(IdwDoc, oAsmDocFolder)
                        End If

                    End If
                Next


                If MsgBox("移动指定文件完成，是否重新打开" & oInventorAssemblyDocumentFullDocumentName, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "移动文件") = MsgBoxResult.Yes Then
                    ThisApplication.Documents.Open(oInventorAssemblyDocumentFullDocumentName)
                End If



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_对齐原始坐标面_Buttondef_OnExecute() Handles m_对齐原始坐标面_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                '判断是否为 assdoc
                Dim InventorDocument As Inventor.Document

                InventorDocument = ThisApplication.ActiveDocument

                If InventorDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information, "对齐原始坐标面")
                    Exit Sub
                End If

                '设置为一个动作, 可一次撤销
                Dim transientGeometry As TransientGeometry
                transientGeometry = ThisApplication.TransientGeometry
                'start a transaction so the slot will be within a single undo step
                Dim createSlotTransaction As Transaction
                createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "重新设置序号")

                If FlushXYZPlane() Then
                    SetStatusBarText("对齐原始坐标面")
                    'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    'MsgBox("错误", MsgBoxStyle.Exclamation)

                End If

                'end the transactio
                createSlotTransaction.End()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_查找缺失文件的部件_Buttondef_OnExecute() Handles m_查找缺失文件的部件_Buttondef.OnExecute
            Try
                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                SetStatusBarText()

                Dim InventorDocument As Inventor.Document     '当前文件
                InventorDocument = ThisApplication.ActiveDocument

                If InventorDocument.DocumentType <> kAssemblyDocumentObject Then
                    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                    Exit Sub
                End If

                If GetUnkonwDocumentWithBOM(InventorDocument, False) Then
                    SetStatusBarText("查找缺失文件的部件完成")
                    MsgBox("查找缺失文件的部件完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    MsgBox("错误", MsgBoxStyle.Exclamation)

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_统计质量面积_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_统计质量面积_Buttondef.OnExecute
            Dim frmGetPart As New frmGetPart
            frmGetPart.Show()
        End Sub

        Private Sub m_调整IPro顺序_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_调整IPro顺序_Buttondef.OnExecute
            Dim frmChangeIpro As New frmChangeIpro
            frmChangeIpro.ShowDialog()
        End Sub

        Private Sub m_尺寸圆整_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_尺寸圆整_Buttondef.OnExecute
            SetDrawingDimPrecision()
        End Sub

        Private Sub m_导入存货编码_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_导入存货编码_Buttondef.OnExecute
            Dim frmInventoryCoding As New frmInventoryCoding
            frmInventoryCoding.Show()
        End Sub


        Private Sub m_打开工程图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_打开工程图_Buttondef.OnExecute
            Try

                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                Dim InventorDocument As Inventor.Document
                InventorDocument = ThisApplication.ActiveDocument


                If InventorDocument.SelectSet.Count <> 0 Then
                    'For Each oSelect As Object In InventorDoc.SelectSet
                    For Each ComponentOccurrence As ComponentOccurrence In InventorDocument.SelectSet()
                        'Next
                        'MsgBox(OldOcc.ReferencedDocumentDescriptor.FullDocumentName)
                        InventorDocument = ThisApplication.Documents.ItemByName(ComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName)
                        OpenDrawingDocument(InventorDocument)
                    Next
                Else
                    InventorDocument = ThisApplication.ActiveEditDocument
                    OpenDrawingDocument(InventorDocument)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        'BOM表保存新的替换项和按序号排序

        Private Sub m_重写BOM序号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_重写BOM序号_Buttondef.OnExecute
            Try
                SetStatusBarText()

                If IsInventorOpenDoc() = False Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                    MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim InventorDrawingDocument As Inventor.DrawingDocument
                Dim ActiveSheet As Sheet

                InventorDrawingDocument = ThisApplication.ActiveDocument
                ActiveSheet = InventorDrawingDocument.ActiveSheet

                If ActiveSheet.PartsLists.Count = 0 Then
                    MsgBox("该工程图无明细表", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                For Each InventorPartsListRow As Inventor.PartsListRow In ActiveSheet.PartsLists.Item(1).PartsListRows
                    InventorPartsListRow.SaveItemOverridesToBOM()
                Next

                ActiveSheet.PartsLists(1).Sort("序号", True)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub m_打开ERP数据文件_Buttondef_OnExecute() Handles m_打开ERP数据文件_Buttondef.OnExecute
            Try
                If IsFileExsts(Excel_File_Name) Then
                    Process.Start(Excel_File_Name)
                Else
                    Process.Start(My.Application.Info.DirectoryPath)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub m_查询ERP编码_Buttondef_OnExecute() Handles m_查询ERP编码_Buttondef.OnExecute
            'Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If


            Dim InventorDocument As Inventor.Document      '当前文件
            InventorDocument = ThisApplication.ActiveEditDocument

            Dim oPropSets As PropertySets
            Dim oPropSet As PropertySet
            Dim propitem As [Property]

            oPropSets = InventorDocument.PropertySets
            oPropSet = oPropSets.Item(3)

            '获取iproperty
            Dim StockNumPartName As StockNumPartName = Nothing
            For Each propitem In oPropSet
                Select Case propitem.DisplayName
                    Case Map_StochNum
                        Dim StochNum As String
                        StochNum = propitem.Value

                        Dim PartNum As String = Nothing

                        'Public Excel_File_Name As String       'excel文件名
                        'Public Sheet_Name As String          '搜索的表
                        'Public Table_Array As String            '搜索的范围
                        'Public Col_Index_Num As String        '搜索列

                        'PartNum = VLookUpValue(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)

                        PartNum = FindSrtingInSheet(Excel_File_Name, StochNum, Sheet_Name, Table_Arrays, Col_Index_Num, 0)

                        If PartNum <> 0 Then
                            MsgBox("查询到ERP编码：" & PartNum, MsgBoxStyle.OkOnly, "查询ERP编码")
                            SetPropitem(InventorDocument, Map_PartNum, PartNum)
                        Else
                            MsgBox("未查询到ERP编码。", MsgBoxStyle.OkOnly, "查询ERP编码")
                        End If
                End Select
            Next

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
        End Sub


        Private Sub m_快速打开_Buttondef_OnExecute() Handles m_快速打开_Buttondef.OnExecute
            Try
                SetStatusBarText()

                Dim WorkSpaceFloder As String
                WorkSpaceFloder = ThisApplication.FileLocations.Workspace & "\"

                Dim FileName As String
                FileName = InputBox("查询文件夹：" & WorkSpaceFloder & vbCrLf & vbCrLf & "输入文件名，包含扩展名", "快速打开")

                If FileName = "" Then
                    Exit Sub
                End If

                Dim files As ReadOnlyCollection(Of String)

                files = My.Computer.FileSystem.GetFiles(WorkSpaceFloder, FileIO.SearchOption.SearchAllSubDirectories, FileName)

                If files.Count <> 0 Then

                    If files.Count = 1 Then
                        For Each FullFileName As String In files
                            ThisApplication.Documents.Open(FullFileName)
                        Next
                    Else
                        Dim frmQuitOpen As New frmQuitOpen
                        For Each FullFileName As String In files
                            frmQuitOpen.lvwFileListView.Items.Add(FullFileName)
                        Next
                        frmQuitOpen.ShowDialog()
                    End If


                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub



        '--------------------------------------------------------------

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