<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Settings
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Settings))
        Me.cb_Assign_Axis1_DOF1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis1_DOF2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis1_DOF3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis2_DOF1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis2_DOF2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis2_DOF3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis3_DOF1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis3_DOF2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis3_DOF3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis4_DOF1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis4_DOF2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis4_DOF3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis5_DOF1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis5_DOF2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis6_PER3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis6_PER2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis5_DOF3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis6_PER1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis5_PER3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis6_DOF1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis5_PER2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis6_DOF2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis5_PER1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis4_PER3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis4_PER2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis6_DOF3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis4_PER1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis3_PER3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis3_PER2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis3_PER1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis2_PER3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis2_PER2 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis2_PER1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis1_PER1 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis1_PER3 = New System.Windows.Forms.ComboBox()
        Me.cb_Assign_Axis1_PER2 = New System.Windows.Forms.ComboBox()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_Axis6_B3 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis5_B3 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis4_B3 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis3_B3 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis2_B3 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis1_B3 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis6_B2 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis5_B2 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis4_B2 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis3_B2 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis2_B2 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis1_B2 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis6_B1 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis5_B1 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis4_B1 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis3_B1 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis2_B1 = New System.Windows.Forms.CheckBox()
        Me.btn_Axis1_B1 = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cb_Assign_Axis1_DOF1
        '
        Me.cb_Assign_Axis1_DOF1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis1_DOF1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis1_DOF1.FormattingEnabled = True
        Me.cb_Assign_Axis1_DOF1.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis1_DOF1.Location = New System.Drawing.Point(132, 82)
        Me.cb_Assign_Axis1_DOF1.MaxDropDownItems = 25
        Me.cb_Assign_Axis1_DOF1.Name = "cb_Assign_Axis1_DOF1"
        Me.cb_Assign_Axis1_DOF1.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis1_DOF1.TabIndex = 245
        '
        'cb_Assign_Axis1_DOF2
        '
        Me.cb_Assign_Axis1_DOF2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis1_DOF2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis1_DOF2.FormattingEnabled = True
        Me.cb_Assign_Axis1_DOF2.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis1_DOF2.Location = New System.Drawing.Point(288, 82)
        Me.cb_Assign_Axis1_DOF2.MaxDropDownItems = 25
        Me.cb_Assign_Axis1_DOF2.Name = "cb_Assign_Axis1_DOF2"
        Me.cb_Assign_Axis1_DOF2.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis1_DOF2.TabIndex = 247
        '
        'cb_Assign_Axis1_DOF3
        '
        Me.cb_Assign_Axis1_DOF3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis1_DOF3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis1_DOF3.FormattingEnabled = True
        Me.cb_Assign_Axis1_DOF3.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis1_DOF3.Location = New System.Drawing.Point(444, 82)
        Me.cb_Assign_Axis1_DOF3.MaxDropDownItems = 25
        Me.cb_Assign_Axis1_DOF3.Name = "cb_Assign_Axis1_DOF3"
        Me.cb_Assign_Axis1_DOF3.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis1_DOF3.TabIndex = 253
        '
        'cb_Assign_Axis2_DOF1
        '
        Me.cb_Assign_Axis2_DOF1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis2_DOF1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis2_DOF1.FormattingEnabled = True
        Me.cb_Assign_Axis2_DOF1.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis2_DOF1.Location = New System.Drawing.Point(132, 114)
        Me.cb_Assign_Axis2_DOF1.MaxDropDownItems = 25
        Me.cb_Assign_Axis2_DOF1.Name = "cb_Assign_Axis2_DOF1"
        Me.cb_Assign_Axis2_DOF1.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis2_DOF1.TabIndex = 376
        '
        'cb_Assign_Axis2_DOF2
        '
        Me.cb_Assign_Axis2_DOF2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis2_DOF2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis2_DOF2.FormattingEnabled = True
        Me.cb_Assign_Axis2_DOF2.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis2_DOF2.Location = New System.Drawing.Point(288, 114)
        Me.cb_Assign_Axis2_DOF2.MaxDropDownItems = 25
        Me.cb_Assign_Axis2_DOF2.Name = "cb_Assign_Axis2_DOF2"
        Me.cb_Assign_Axis2_DOF2.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis2_DOF2.TabIndex = 377
        '
        'cb_Assign_Axis2_DOF3
        '
        Me.cb_Assign_Axis2_DOF3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis2_DOF3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis2_DOF3.FormattingEnabled = True
        Me.cb_Assign_Axis2_DOF3.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis2_DOF3.Location = New System.Drawing.Point(444, 114)
        Me.cb_Assign_Axis2_DOF3.MaxDropDownItems = 25
        Me.cb_Assign_Axis2_DOF3.Name = "cb_Assign_Axis2_DOF3"
        Me.cb_Assign_Axis2_DOF3.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis2_DOF3.TabIndex = 380
        '
        'cb_Assign_Axis3_DOF1
        '
        Me.cb_Assign_Axis3_DOF1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis3_DOF1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis3_DOF1.FormattingEnabled = True
        Me.cb_Assign_Axis3_DOF1.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis3_DOF1.Location = New System.Drawing.Point(132, 146)
        Me.cb_Assign_Axis3_DOF1.MaxDropDownItems = 25
        Me.cb_Assign_Axis3_DOF1.Name = "cb_Assign_Axis3_DOF1"
        Me.cb_Assign_Axis3_DOF1.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis3_DOF1.TabIndex = 383
        '
        'cb_Assign_Axis3_DOF2
        '
        Me.cb_Assign_Axis3_DOF2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis3_DOF2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis3_DOF2.FormattingEnabled = True
        Me.cb_Assign_Axis3_DOF2.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis3_DOF2.Location = New System.Drawing.Point(288, 146)
        Me.cb_Assign_Axis3_DOF2.MaxDropDownItems = 25
        Me.cb_Assign_Axis3_DOF2.Name = "cb_Assign_Axis3_DOF2"
        Me.cb_Assign_Axis3_DOF2.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis3_DOF2.TabIndex = 384
        '
        'cb_Assign_Axis3_DOF3
        '
        Me.cb_Assign_Axis3_DOF3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis3_DOF3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis3_DOF3.FormattingEnabled = True
        Me.cb_Assign_Axis3_DOF3.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis3_DOF3.Location = New System.Drawing.Point(444, 146)
        Me.cb_Assign_Axis3_DOF3.MaxDropDownItems = 25
        Me.cb_Assign_Axis3_DOF3.Name = "cb_Assign_Axis3_DOF3"
        Me.cb_Assign_Axis3_DOF3.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis3_DOF3.TabIndex = 387
        '
        'cb_Assign_Axis4_DOF1
        '
        Me.cb_Assign_Axis4_DOF1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis4_DOF1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis4_DOF1.FormattingEnabled = True
        Me.cb_Assign_Axis4_DOF1.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis4_DOF1.Location = New System.Drawing.Point(132, 178)
        Me.cb_Assign_Axis4_DOF1.MaxDropDownItems = 25
        Me.cb_Assign_Axis4_DOF1.Name = "cb_Assign_Axis4_DOF1"
        Me.cb_Assign_Axis4_DOF1.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis4_DOF1.TabIndex = 390
        '
        'cb_Assign_Axis4_DOF2
        '
        Me.cb_Assign_Axis4_DOF2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis4_DOF2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis4_DOF2.FormattingEnabled = True
        Me.cb_Assign_Axis4_DOF2.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis4_DOF2.Location = New System.Drawing.Point(288, 178)
        Me.cb_Assign_Axis4_DOF2.MaxDropDownItems = 25
        Me.cb_Assign_Axis4_DOF2.Name = "cb_Assign_Axis4_DOF2"
        Me.cb_Assign_Axis4_DOF2.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis4_DOF2.TabIndex = 391
        '
        'cb_Assign_Axis4_DOF3
        '
        Me.cb_Assign_Axis4_DOF3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis4_DOF3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis4_DOF3.FormattingEnabled = True
        Me.cb_Assign_Axis4_DOF3.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis4_DOF3.Location = New System.Drawing.Point(444, 178)
        Me.cb_Assign_Axis4_DOF3.MaxDropDownItems = 25
        Me.cb_Assign_Axis4_DOF3.Name = "cb_Assign_Axis4_DOF3"
        Me.cb_Assign_Axis4_DOF3.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis4_DOF3.TabIndex = 394
        '
        'cb_Assign_Axis5_DOF1
        '
        Me.cb_Assign_Axis5_DOF1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis5_DOF1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis5_DOF1.FormattingEnabled = True
        Me.cb_Assign_Axis5_DOF1.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis5_DOF1.Location = New System.Drawing.Point(132, 210)
        Me.cb_Assign_Axis5_DOF1.MaxDropDownItems = 25
        Me.cb_Assign_Axis5_DOF1.Name = "cb_Assign_Axis5_DOF1"
        Me.cb_Assign_Axis5_DOF1.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis5_DOF1.TabIndex = 397
        '
        'cb_Assign_Axis5_DOF2
        '
        Me.cb_Assign_Axis5_DOF2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis5_DOF2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis5_DOF2.FormattingEnabled = True
        Me.cb_Assign_Axis5_DOF2.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis5_DOF2.Location = New System.Drawing.Point(288, 210)
        Me.cb_Assign_Axis5_DOF2.MaxDropDownItems = 25
        Me.cb_Assign_Axis5_DOF2.Name = "cb_Assign_Axis5_DOF2"
        Me.cb_Assign_Axis5_DOF2.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis5_DOF2.TabIndex = 398
        '
        'cb_Assign_Axis6_PER3
        '
        Me.cb_Assign_Axis6_PER3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis6_PER3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis6_PER3.FormattingEnabled = True
        Me.cb_Assign_Axis6_PER3.IntegralHeight = False
        Me.cb_Assign_Axis6_PER3.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis6_PER3.Location = New System.Drawing.Point(514, 242)
        Me.cb_Assign_Axis6_PER3.MaxDropDownItems = 15
        Me.cb_Assign_Axis6_PER3.Name = "cb_Assign_Axis6_PER3"
        Me.cb_Assign_Axis6_PER3.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis6_PER3.TabIndex = 462
        '
        'cb_Assign_Axis6_PER2
        '
        Me.cb_Assign_Axis6_PER2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis6_PER2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis6_PER2.FormattingEnabled = True
        Me.cb_Assign_Axis6_PER2.IntegralHeight = False
        Me.cb_Assign_Axis6_PER2.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis6_PER2.Location = New System.Drawing.Point(358, 242)
        Me.cb_Assign_Axis6_PER2.MaxDropDownItems = 15
        Me.cb_Assign_Axis6_PER2.Name = "cb_Assign_Axis6_PER2"
        Me.cb_Assign_Axis6_PER2.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis6_PER2.TabIndex = 461
        '
        'cb_Assign_Axis5_DOF3
        '
        Me.cb_Assign_Axis5_DOF3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis5_DOF3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis5_DOF3.FormattingEnabled = True
        Me.cb_Assign_Axis5_DOF3.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis5_DOF3.Location = New System.Drawing.Point(444, 210)
        Me.cb_Assign_Axis5_DOF3.MaxDropDownItems = 25
        Me.cb_Assign_Axis5_DOF3.Name = "cb_Assign_Axis5_DOF3"
        Me.cb_Assign_Axis5_DOF3.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis5_DOF3.TabIndex = 401
        '
        'cb_Assign_Axis6_PER1
        '
        Me.cb_Assign_Axis6_PER1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis6_PER1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis6_PER1.FormattingEnabled = True
        Me.cb_Assign_Axis6_PER1.IntegralHeight = False
        Me.cb_Assign_Axis6_PER1.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis6_PER1.Location = New System.Drawing.Point(202, 242)
        Me.cb_Assign_Axis6_PER1.MaxDropDownItems = 15
        Me.cb_Assign_Axis6_PER1.Name = "cb_Assign_Axis6_PER1"
        Me.cb_Assign_Axis6_PER1.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis6_PER1.TabIndex = 460
        '
        'cb_Assign_Axis5_PER3
        '
        Me.cb_Assign_Axis5_PER3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis5_PER3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis5_PER3.FormattingEnabled = True
        Me.cb_Assign_Axis5_PER3.IntegralHeight = False
        Me.cb_Assign_Axis5_PER3.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis5_PER3.Location = New System.Drawing.Point(514, 210)
        Me.cb_Assign_Axis5_PER3.MaxDropDownItems = 15
        Me.cb_Assign_Axis5_PER3.Name = "cb_Assign_Axis5_PER3"
        Me.cb_Assign_Axis5_PER3.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis5_PER3.TabIndex = 459
        '
        'cb_Assign_Axis6_DOF1
        '
        Me.cb_Assign_Axis6_DOF1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis6_DOF1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis6_DOF1.FormattingEnabled = True
        Me.cb_Assign_Axis6_DOF1.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis6_DOF1.Location = New System.Drawing.Point(132, 242)
        Me.cb_Assign_Axis6_DOF1.MaxDropDownItems = 25
        Me.cb_Assign_Axis6_DOF1.Name = "cb_Assign_Axis6_DOF1"
        Me.cb_Assign_Axis6_DOF1.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis6_DOF1.TabIndex = 404
        '
        'cb_Assign_Axis5_PER2
        '
        Me.cb_Assign_Axis5_PER2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis5_PER2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis5_PER2.FormattingEnabled = True
        Me.cb_Assign_Axis5_PER2.IntegralHeight = False
        Me.cb_Assign_Axis5_PER2.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis5_PER2.Location = New System.Drawing.Point(358, 210)
        Me.cb_Assign_Axis5_PER2.MaxDropDownItems = 15
        Me.cb_Assign_Axis5_PER2.Name = "cb_Assign_Axis5_PER2"
        Me.cb_Assign_Axis5_PER2.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis5_PER2.TabIndex = 458
        '
        'cb_Assign_Axis6_DOF2
        '
        Me.cb_Assign_Axis6_DOF2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis6_DOF2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis6_DOF2.FormattingEnabled = True
        Me.cb_Assign_Axis6_DOF2.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis6_DOF2.Location = New System.Drawing.Point(288, 242)
        Me.cb_Assign_Axis6_DOF2.MaxDropDownItems = 25
        Me.cb_Assign_Axis6_DOF2.Name = "cb_Assign_Axis6_DOF2"
        Me.cb_Assign_Axis6_DOF2.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis6_DOF2.TabIndex = 405
        '
        'cb_Assign_Axis5_PER1
        '
        Me.cb_Assign_Axis5_PER1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis5_PER1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis5_PER1.FormattingEnabled = True
        Me.cb_Assign_Axis5_PER1.IntegralHeight = False
        Me.cb_Assign_Axis5_PER1.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis5_PER1.Location = New System.Drawing.Point(202, 210)
        Me.cb_Assign_Axis5_PER1.MaxDropDownItems = 15
        Me.cb_Assign_Axis5_PER1.Name = "cb_Assign_Axis5_PER1"
        Me.cb_Assign_Axis5_PER1.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis5_PER1.TabIndex = 457
        '
        'cb_Assign_Axis4_PER3
        '
        Me.cb_Assign_Axis4_PER3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis4_PER3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis4_PER3.FormattingEnabled = True
        Me.cb_Assign_Axis4_PER3.IntegralHeight = False
        Me.cb_Assign_Axis4_PER3.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis4_PER3.Location = New System.Drawing.Point(514, 178)
        Me.cb_Assign_Axis4_PER3.MaxDropDownItems = 15
        Me.cb_Assign_Axis4_PER3.Name = "cb_Assign_Axis4_PER3"
        Me.cb_Assign_Axis4_PER3.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis4_PER3.TabIndex = 456
        '
        'cb_Assign_Axis4_PER2
        '
        Me.cb_Assign_Axis4_PER2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis4_PER2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis4_PER2.FormattingEnabled = True
        Me.cb_Assign_Axis4_PER2.IntegralHeight = False
        Me.cb_Assign_Axis4_PER2.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis4_PER2.Location = New System.Drawing.Point(358, 178)
        Me.cb_Assign_Axis4_PER2.MaxDropDownItems = 15
        Me.cb_Assign_Axis4_PER2.Name = "cb_Assign_Axis4_PER2"
        Me.cb_Assign_Axis4_PER2.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis4_PER2.TabIndex = 455
        '
        'cb_Assign_Axis6_DOF3
        '
        Me.cb_Assign_Axis6_DOF3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis6_DOF3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis6_DOF3.FormattingEnabled = True
        Me.cb_Assign_Axis6_DOF3.Items.AddRange(New Object() {"-", "Roll", "Pitch", "Heave", "Yaw", "Sway", "Surge", "Extra1", "Extra2", "Extra3"})
        Me.cb_Assign_Axis6_DOF3.Location = New System.Drawing.Point(444, 242)
        Me.cb_Assign_Axis6_DOF3.MaxDropDownItems = 25
        Me.cb_Assign_Axis6_DOF3.Name = "cb_Assign_Axis6_DOF3"
        Me.cb_Assign_Axis6_DOF3.Size = New System.Drawing.Size(67, 21)
        Me.cb_Assign_Axis6_DOF3.TabIndex = 408
        '
        'cb_Assign_Axis4_PER1
        '
        Me.cb_Assign_Axis4_PER1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis4_PER1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis4_PER1.FormattingEnabled = True
        Me.cb_Assign_Axis4_PER1.IntegralHeight = False
        Me.cb_Assign_Axis4_PER1.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis4_PER1.Location = New System.Drawing.Point(202, 178)
        Me.cb_Assign_Axis4_PER1.MaxDropDownItems = 15
        Me.cb_Assign_Axis4_PER1.Name = "cb_Assign_Axis4_PER1"
        Me.cb_Assign_Axis4_PER1.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis4_PER1.TabIndex = 454
        '
        'cb_Assign_Axis3_PER3
        '
        Me.cb_Assign_Axis3_PER3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis3_PER3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis3_PER3.FormattingEnabled = True
        Me.cb_Assign_Axis3_PER3.IntegralHeight = False
        Me.cb_Assign_Axis3_PER3.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis3_PER3.Location = New System.Drawing.Point(514, 146)
        Me.cb_Assign_Axis3_PER3.MaxDropDownItems = 15
        Me.cb_Assign_Axis3_PER3.Name = "cb_Assign_Axis3_PER3"
        Me.cb_Assign_Axis3_PER3.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis3_PER3.TabIndex = 453
        '
        'cb_Assign_Axis3_PER2
        '
        Me.cb_Assign_Axis3_PER2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis3_PER2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis3_PER2.FormattingEnabled = True
        Me.cb_Assign_Axis3_PER2.IntegralHeight = False
        Me.cb_Assign_Axis3_PER2.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis3_PER2.Location = New System.Drawing.Point(358, 146)
        Me.cb_Assign_Axis3_PER2.MaxDropDownItems = 15
        Me.cb_Assign_Axis3_PER2.Name = "cb_Assign_Axis3_PER2"
        Me.cb_Assign_Axis3_PER2.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis3_PER2.TabIndex = 452
        '
        'cb_Assign_Axis3_PER1
        '
        Me.cb_Assign_Axis3_PER1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis3_PER1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis3_PER1.FormattingEnabled = True
        Me.cb_Assign_Axis3_PER1.IntegralHeight = False
        Me.cb_Assign_Axis3_PER1.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis3_PER1.Location = New System.Drawing.Point(202, 146)
        Me.cb_Assign_Axis3_PER1.MaxDropDownItems = 15
        Me.cb_Assign_Axis3_PER1.Name = "cb_Assign_Axis3_PER1"
        Me.cb_Assign_Axis3_PER1.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis3_PER1.TabIndex = 451
        '
        'cb_Assign_Axis2_PER3
        '
        Me.cb_Assign_Axis2_PER3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis2_PER3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis2_PER3.FormattingEnabled = True
        Me.cb_Assign_Axis2_PER3.IntegralHeight = False
        Me.cb_Assign_Axis2_PER3.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis2_PER3.Location = New System.Drawing.Point(514, 114)
        Me.cb_Assign_Axis2_PER3.MaxDropDownItems = 15
        Me.cb_Assign_Axis2_PER3.Name = "cb_Assign_Axis2_PER3"
        Me.cb_Assign_Axis2_PER3.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis2_PER3.TabIndex = 450
        '
        'cb_Assign_Axis2_PER2
        '
        Me.cb_Assign_Axis2_PER2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis2_PER2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis2_PER2.FormattingEnabled = True
        Me.cb_Assign_Axis2_PER2.IntegralHeight = False
        Me.cb_Assign_Axis2_PER2.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis2_PER2.Location = New System.Drawing.Point(358, 114)
        Me.cb_Assign_Axis2_PER2.MaxDropDownItems = 15
        Me.cb_Assign_Axis2_PER2.Name = "cb_Assign_Axis2_PER2"
        Me.cb_Assign_Axis2_PER2.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis2_PER2.TabIndex = 449
        '
        'cb_Assign_Axis2_PER1
        '
        Me.cb_Assign_Axis2_PER1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis2_PER1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis2_PER1.FormattingEnabled = True
        Me.cb_Assign_Axis2_PER1.IntegralHeight = False
        Me.cb_Assign_Axis2_PER1.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis2_PER1.Location = New System.Drawing.Point(202, 114)
        Me.cb_Assign_Axis2_PER1.MaxDropDownItems = 15
        Me.cb_Assign_Axis2_PER1.Name = "cb_Assign_Axis2_PER1"
        Me.cb_Assign_Axis2_PER1.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis2_PER1.TabIndex = 448
        '
        'cb_Assign_Axis1_PER1
        '
        Me.cb_Assign_Axis1_PER1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis1_PER1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis1_PER1.FormattingEnabled = True
        Me.cb_Assign_Axis1_PER1.IntegralHeight = False
        Me.cb_Assign_Axis1_PER1.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis1_PER1.Location = New System.Drawing.Point(202, 82)
        Me.cb_Assign_Axis1_PER1.MaxDropDownItems = 15
        Me.cb_Assign_Axis1_PER1.Name = "cb_Assign_Axis1_PER1"
        Me.cb_Assign_Axis1_PER1.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis1_PER1.TabIndex = 445
        '
        'cb_Assign_Axis1_PER3
        '
        Me.cb_Assign_Axis1_PER3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis1_PER3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis1_PER3.FormattingEnabled = True
        Me.cb_Assign_Axis1_PER3.IntegralHeight = False
        Me.cb_Assign_Axis1_PER3.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis1_PER3.Location = New System.Drawing.Point(514, 82)
        Me.cb_Assign_Axis1_PER3.MaxDropDownItems = 15
        Me.cb_Assign_Axis1_PER3.Name = "cb_Assign_Axis1_PER3"
        Me.cb_Assign_Axis1_PER3.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis1_PER3.TabIndex = 447
        '
        'cb_Assign_Axis1_PER2
        '
        Me.cb_Assign_Axis1_PER2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Assign_Axis1_PER2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb_Assign_Axis1_PER2.FormattingEnabled = True
        Me.cb_Assign_Axis1_PER2.IntegralHeight = False
        Me.cb_Assign_Axis1_PER2.Items.AddRange(New Object() {"-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cb_Assign_Axis1_PER2.Location = New System.Drawing.Point(358, 82)
        Me.cb_Assign_Axis1_PER2.MaxDropDownItems = 15
        Me.cb_Assign_Axis1_PER2.Name = "cb_Assign_Axis1_PER2"
        Me.cb_Assign_Axis1_PER2.Size = New System.Drawing.Size(51, 21)
        Me.cb_Assign_Axis1_PER2.TabIndex = 446
        '
        'btn_Save
        '
        Me.btn_Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Save.Location = New System.Drawing.Point(17, 6)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(60, 35)
        Me.btn_Save.TabIndex = 3
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Axis6_B3)
        Me.Panel1.Controls.Add(Me.btn_Axis5_B3)
        Me.Panel1.Controls.Add(Me.btn_Axis4_B3)
        Me.Panel1.Controls.Add(Me.btn_Axis3_B3)
        Me.Panel1.Controls.Add(Me.btn_Axis2_B3)
        Me.Panel1.Controls.Add(Me.btn_Axis1_B3)
        Me.Panel1.Controls.Add(Me.btn_Axis6_B2)
        Me.Panel1.Controls.Add(Me.btn_Axis5_B2)
        Me.Panel1.Controls.Add(Me.btn_Axis4_B2)
        Me.Panel1.Controls.Add(Me.btn_Axis3_B2)
        Me.Panel1.Controls.Add(Me.btn_Axis2_B2)
        Me.Panel1.Controls.Add(Me.btn_Axis1_B2)
        Me.Panel1.Controls.Add(Me.btn_Axis6_B1)
        Me.Panel1.Controls.Add(Me.btn_Axis5_B1)
        Me.Panel1.Controls.Add(Me.btn_Axis4_B1)
        Me.Panel1.Controls.Add(Me.btn_Axis3_B1)
        Me.Panel1.Controls.Add(Me.btn_Axis2_B1)
        Me.Panel1.Controls.Add(Me.btn_Axis1_B1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis1_DOF1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis1_DOF2)
        Me.Panel1.Controls.Add(Me.btn_Save)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis1_DOF3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis2_DOF1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis1_PER2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis2_DOF2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis1_PER3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis1_PER1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis2_PER1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis2_DOF3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis2_PER2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis2_PER3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis3_PER1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis3_PER2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis3_DOF1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis3_PER3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis4_PER1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis3_DOF2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis6_DOF3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis4_PER2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis4_PER3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis5_PER1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis6_DOF2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis5_PER2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis6_DOF1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis3_DOF3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis5_PER3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis6_PER1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis5_DOF3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis6_PER2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis4_DOF1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis6_PER3)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis4_DOF2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis5_DOF2)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis5_DOF1)
        Me.Panel1.Controls.Add(Me.cb_Assign_Axis4_DOF3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(590, 280)
        Me.Panel1.TabIndex = 562
        '
        'btn_Axis6_B3
        '
        Me.btn_Axis6_B3.Location = New System.Drawing.Point(425, 245)
        Me.btn_Axis6_B3.Name = "btn_Axis6_B3"
        Me.btn_Axis6_B3.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis6_B3.TabIndex = 580
        Me.btn_Axis6_B3.UseVisualStyleBackColor = True
        '
        'btn_Axis5_B3
        '
        Me.btn_Axis5_B3.Location = New System.Drawing.Point(425, 213)
        Me.btn_Axis5_B3.Name = "btn_Axis5_B3"
        Me.btn_Axis5_B3.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis5_B3.TabIndex = 579
        Me.btn_Axis5_B3.UseVisualStyleBackColor = True
        '
        'btn_Axis4_B3
        '
        Me.btn_Axis4_B3.Location = New System.Drawing.Point(425, 181)
        Me.btn_Axis4_B3.Name = "btn_Axis4_B3"
        Me.btn_Axis4_B3.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis4_B3.TabIndex = 578
        Me.btn_Axis4_B3.UseVisualStyleBackColor = True
        '
        'btn_Axis3_B3
        '
        Me.btn_Axis3_B3.Location = New System.Drawing.Point(425, 149)
        Me.btn_Axis3_B3.Name = "btn_Axis3_B3"
        Me.btn_Axis3_B3.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis3_B3.TabIndex = 577
        Me.btn_Axis3_B3.UseVisualStyleBackColor = True
        '
        'btn_Axis2_B3
        '
        Me.btn_Axis2_B3.Location = New System.Drawing.Point(425, 117)
        Me.btn_Axis2_B3.Name = "btn_Axis2_B3"
        Me.btn_Axis2_B3.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis2_B3.TabIndex = 576
        Me.btn_Axis2_B3.UseVisualStyleBackColor = True
        '
        'btn_Axis1_B3
        '
        Me.btn_Axis1_B3.Location = New System.Drawing.Point(425, 85)
        Me.btn_Axis1_B3.Name = "btn_Axis1_B3"
        Me.btn_Axis1_B3.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis1_B3.TabIndex = 575
        Me.btn_Axis1_B3.UseVisualStyleBackColor = True
        '
        'btn_Axis6_B2
        '
        Me.btn_Axis6_B2.Location = New System.Drawing.Point(269, 245)
        Me.btn_Axis6_B2.Name = "btn_Axis6_B2"
        Me.btn_Axis6_B2.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis6_B2.TabIndex = 574
        Me.btn_Axis6_B2.UseVisualStyleBackColor = True
        '
        'btn_Axis5_B2
        '
        Me.btn_Axis5_B2.Location = New System.Drawing.Point(269, 213)
        Me.btn_Axis5_B2.Name = "btn_Axis5_B2"
        Me.btn_Axis5_B2.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis5_B2.TabIndex = 573
        Me.btn_Axis5_B2.UseVisualStyleBackColor = True
        '
        'btn_Axis4_B2
        '
        Me.btn_Axis4_B2.Location = New System.Drawing.Point(269, 181)
        Me.btn_Axis4_B2.Name = "btn_Axis4_B2"
        Me.btn_Axis4_B2.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis4_B2.TabIndex = 572
        Me.btn_Axis4_B2.UseVisualStyleBackColor = True
        '
        'btn_Axis3_B2
        '
        Me.btn_Axis3_B2.Location = New System.Drawing.Point(269, 149)
        Me.btn_Axis3_B2.Name = "btn_Axis3_B2"
        Me.btn_Axis3_B2.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis3_B2.TabIndex = 571
        Me.btn_Axis3_B2.UseVisualStyleBackColor = True
        '
        'btn_Axis2_B2
        '
        Me.btn_Axis2_B2.Location = New System.Drawing.Point(269, 117)
        Me.btn_Axis2_B2.Name = "btn_Axis2_B2"
        Me.btn_Axis2_B2.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis2_B2.TabIndex = 570
        Me.btn_Axis2_B2.UseVisualStyleBackColor = True
        '
        'btn_Axis1_B2
        '
        Me.btn_Axis1_B2.Location = New System.Drawing.Point(269, 85)
        Me.btn_Axis1_B2.Name = "btn_Axis1_B2"
        Me.btn_Axis1_B2.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis1_B2.TabIndex = 569
        Me.btn_Axis1_B2.UseVisualStyleBackColor = True
        '
        'btn_Axis6_B1
        '
        Me.btn_Axis6_B1.Location = New System.Drawing.Point(113, 245)
        Me.btn_Axis6_B1.Name = "btn_Axis6_B1"
        Me.btn_Axis6_B1.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis6_B1.TabIndex = 568
        Me.btn_Axis6_B1.UseVisualStyleBackColor = True
        '
        'btn_Axis5_B1
        '
        Me.btn_Axis5_B1.Location = New System.Drawing.Point(113, 213)
        Me.btn_Axis5_B1.Name = "btn_Axis5_B1"
        Me.btn_Axis5_B1.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis5_B1.TabIndex = 567
        Me.btn_Axis5_B1.UseVisualStyleBackColor = True
        '
        'btn_Axis4_B1
        '
        Me.btn_Axis4_B1.Location = New System.Drawing.Point(113, 181)
        Me.btn_Axis4_B1.Name = "btn_Axis4_B1"
        Me.btn_Axis4_B1.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis4_B1.TabIndex = 566
        Me.btn_Axis4_B1.UseVisualStyleBackColor = True
        '
        'btn_Axis3_B1
        '
        Me.btn_Axis3_B1.Location = New System.Drawing.Point(113, 149)
        Me.btn_Axis3_B1.Name = "btn_Axis3_B1"
        Me.btn_Axis3_B1.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis3_B1.TabIndex = 565
        Me.btn_Axis3_B1.UseVisualStyleBackColor = True
        '
        'btn_Axis2_B1
        '
        Me.btn_Axis2_B1.Location = New System.Drawing.Point(113, 117)
        Me.btn_Axis2_B1.Name = "btn_Axis2_B1"
        Me.btn_Axis2_B1.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis2_B1.TabIndex = 564
        Me.btn_Axis2_B1.UseVisualStyleBackColor = True
        '
        'btn_Axis1_B1
        '
        Me.btn_Axis1_B1.Location = New System.Drawing.Point(113, 85)
        Me.btn_Axis1_B1.Name = "btn_Axis1_B1"
        Me.btn_Axis1_B1.Size = New System.Drawing.Size(14, 14)
        Me.btn_Axis1_B1.TabIndex = 563
        Me.btn_Axis1_B1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(590, 280)
        Me.PictureBox1.TabIndex = 562
        Me.PictureBox1.TabStop = False
        '
        'UserControl_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UserControl_Settings"
        Me.Size = New System.Drawing.Size(590, 280)
        Me.Panel1.ResumeLayout(false)
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents cb_Assign_Axis1_DOF1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis1_DOF2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis1_DOF3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis2_DOF1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis2_DOF2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis2_DOF3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis3_DOF1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis3_DOF2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis3_DOF3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis4_DOF1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis4_DOF2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis4_DOF3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis5_DOF1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis5_DOF2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis6_PER3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis6_PER2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis5_DOF3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis6_PER1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis5_PER3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis6_DOF1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis5_PER2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis6_DOF2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis5_PER1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis4_PER3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis4_PER2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis6_DOF3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis4_PER1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis3_PER3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis3_PER2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis3_PER1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis2_PER3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis2_PER2 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis2_PER1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis1_PER1 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis1_PER3 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Assign_Axis1_PER2 As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Axis1_B1 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis6_B3 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis5_B3 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis4_B3 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis3_B3 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis2_B3 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis1_B3 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis6_B2 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis5_B2 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis4_B2 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis3_B2 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis2_B2 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis1_B2 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis6_B1 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis5_B1 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis4_B1 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis3_B1 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Axis2_B1 As System.Windows.Forms.CheckBox

End Class
