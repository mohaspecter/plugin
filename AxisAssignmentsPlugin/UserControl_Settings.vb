Option Strict On
Option Explicit On

Imports System.IO
Imports System.Xml.Serialization

Public Class UserControl_Settings
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '///                      Edit the Subroutines below to provide support for your math plugin!                          ///
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Game Engine uses this to (Load the Form from the Structure)
    Private Sub LoadFormFromStructure()
        'Load Form from Structure

        'Axis 1
        btn_Axis1_B1.Checked = _AxisAssignments._Axis1DIR1
        btn_Axis1_B2.Checked = _AxisAssignments._Axis1DIR2
        btn_Axis1_B3.Checked = _AxisAssignments._Axis1DIR3
        cb_Assign_Axis1_DOF1.SelectedItem = _AxisAssignments._Axis1DOF1
        cb_Assign_Axis1_DOF2.SelectedItem = _AxisAssignments._Axis1DOF2
        cb_Assign_Axis1_DOF3.SelectedItem = _AxisAssignments._Axis1DOF3
        If _AxisAssignments._Axis1PER1 = 0 Then
            cb_Assign_Axis1_PER1.SelectedItem = "-"
        Else
            cb_Assign_Axis1_PER1.SelectedItem = _AxisAssignments._Axis1PER1.ToString
        End If
        If _AxisAssignments._Axis1PER2 = 0 Then
            cb_Assign_Axis1_PER2.SelectedItem = "-"
        Else
            cb_Assign_Axis1_PER2.SelectedItem = _AxisAssignments._Axis1PER2.ToString
        End If
        If _AxisAssignments._Axis1PER3 = 0 Then
            cb_Assign_Axis1_PER3.SelectedItem = "-"
        Else
            cb_Assign_Axis1_PER3.SelectedItem = _AxisAssignments._Axis1PER3.ToString
        End If

        'Axis 2
        btn_Axis2_B1.Checked = _AxisAssignments._Axis2DIR1
        btn_Axis2_B2.Checked = _AxisAssignments._Axis2DIR2
        btn_Axis2_B3.Checked = _AxisAssignments._Axis2DIR3
        cb_Assign_Axis2_DOF1.SelectedItem = _AxisAssignments._Axis2DOF1
        cb_Assign_Axis2_DOF2.SelectedItem = _AxisAssignments._Axis2DOF2
        cb_Assign_Axis2_DOF3.SelectedItem = _AxisAssignments._Axis2DOF3
        If _AxisAssignments._Axis2PER1 = 0 Then
            cb_Assign_Axis2_PER1.SelectedItem = "-"
        Else
            cb_Assign_Axis2_PER1.SelectedItem = _AxisAssignments._Axis2PER1.ToString
        End If
        If _AxisAssignments._Axis2PER2 = 0 Then
            cb_Assign_Axis2_PER2.SelectedItem = "-"
        Else
            cb_Assign_Axis2_PER2.SelectedItem = _AxisAssignments._Axis2PER2.ToString
        End If
        If _AxisAssignments._Axis2PER3 = 0 Then
            cb_Assign_Axis2_PER3.SelectedItem = "-"
        Else
            cb_Assign_Axis2_PER3.SelectedItem = _AxisAssignments._Axis2PER3.ToString
        End If

        'Axis 3
        btn_Axis3_B1.Checked = _AxisAssignments._Axis3DIR1
        btn_Axis3_B2.Checked = _AxisAssignments._Axis3DIR2
        btn_Axis3_B3.Checked = _AxisAssignments._Axis3DIR3
        cb_Assign_Axis3_DOF1.SelectedItem = _AxisAssignments._Axis3DOF1
        cb_Assign_Axis3_DOF2.SelectedItem = _AxisAssignments._Axis3DOF2
        cb_Assign_Axis3_DOF3.SelectedItem = _AxisAssignments._Axis3DOF3
        If _AxisAssignments._Axis3PER1 = 0 Then
            cb_Assign_Axis3_PER1.SelectedItem = "-"
        Else
            cb_Assign_Axis3_PER1.SelectedItem = _AxisAssignments._Axis3PER1.ToString
        End If
        If _AxisAssignments._Axis3PER2 = 0 Then
            cb_Assign_Axis3_PER2.SelectedItem = "-"
        Else
            cb_Assign_Axis3_PER2.SelectedItem = _AxisAssignments._Axis3PER2.ToString
        End If
        If _AxisAssignments._Axis3PER3 = 0 Then
            cb_Assign_Axis3_PER3.SelectedItem = "-"
        Else
            cb_Assign_Axis3_PER3.SelectedItem = _AxisAssignments._Axis3PER3.ToString
        End If

        'Axis 4
        btn_Axis4_B1.Checked = _AxisAssignments._Axis4DIR1
        btn_Axis4_B2.Checked = _AxisAssignments._Axis4DIR2
        btn_Axis4_B3.Checked = _AxisAssignments._Axis4DIR3
        cb_Assign_Axis4_DOF1.SelectedItem = _AxisAssignments._Axis4DOF1
        cb_Assign_Axis4_DOF2.SelectedItem = _AxisAssignments._Axis4DOF2
        cb_Assign_Axis4_DOF3.SelectedItem = _AxisAssignments._Axis4DOF3
        If _AxisAssignments._Axis4PER1 = 0 Then
            cb_Assign_Axis4_PER1.SelectedItem = "-"
        Else
            cb_Assign_Axis4_PER1.SelectedItem = _AxisAssignments._Axis4PER1.ToString
        End If
        If _AxisAssignments._Axis4PER2 = 0 Then
            cb_Assign_Axis4_PER2.SelectedItem = "-"
        Else
            cb_Assign_Axis4_PER2.SelectedItem = _AxisAssignments._Axis4PER2.ToString
        End If
        If _AxisAssignments._Axis4PER3 = 0 Then
            cb_Assign_Axis4_PER3.SelectedItem = "-"
        Else
            cb_Assign_Axis4_PER3.SelectedItem = _AxisAssignments._Axis4PER3.ToString
        End If

        'Axis 5
        btn_Axis5_B1.Checked = _AxisAssignments._Axis5DIR1
        btn_Axis5_B2.Checked = _AxisAssignments._Axis5DIR2
        btn_Axis5_B3.Checked = _AxisAssignments._Axis5DIR3
        cb_Assign_Axis5_DOF1.SelectedItem = _AxisAssignments._Axis5DOF1
        cb_Assign_Axis5_DOF2.SelectedItem = _AxisAssignments._Axis5DOF2
        cb_Assign_Axis5_DOF3.SelectedItem = _AxisAssignments._Axis5DOF3
        If _AxisAssignments._Axis5PER1 = 0 Then
            cb_Assign_Axis5_PER1.SelectedItem = "-"
        Else
            cb_Assign_Axis5_PER1.SelectedItem = _AxisAssignments._Axis5PER1.ToString
        End If
        If _AxisAssignments._Axis5PER2 = 0 Then
            cb_Assign_Axis5_PER2.SelectedItem = "-"
        Else
            cb_Assign_Axis5_PER2.SelectedItem = _AxisAssignments._Axis5PER2.ToString
        End If
        If _AxisAssignments._Axis5PER3 = 0 Then
            cb_Assign_Axis5_PER3.SelectedItem = "-"
        Else
            cb_Assign_Axis5_PER3.SelectedItem = _AxisAssignments._Axis5PER3.ToString
        End If

        'Axis 6
        btn_Axis6_B1.Checked = _AxisAssignments._Axis6DIR1
        btn_Axis6_B2.Checked = _AxisAssignments._Axis6DIR2
        btn_Axis6_B3.Checked = _AxisAssignments._Axis6DIR3
        cb_Assign_Axis6_DOF1.SelectedItem = _AxisAssignments._Axis6DOF1
        cb_Assign_Axis6_DOF2.SelectedItem = _AxisAssignments._Axis6DOF2
        cb_Assign_Axis6_DOF3.SelectedItem = _AxisAssignments._Axis6DOF3
        If _AxisAssignments._Axis6PER1 = 0 Then
            cb_Assign_Axis6_PER1.SelectedItem = "-"
        Else
            cb_Assign_Axis6_PER1.SelectedItem = _AxisAssignments._Axis6PER1.ToString
        End If
        If _AxisAssignments._Axis6PER2 = 0 Then
            cb_Assign_Axis6_PER2.SelectedItem = "-"
        Else
            cb_Assign_Axis6_PER2.SelectedItem = _AxisAssignments._Axis6PER2.ToString
        End If
        If _AxisAssignments._Axis6PER3 = 0 Then
            cb_Assign_Axis6_PER3.SelectedItem = "-"
        Else
            cb_Assign_Axis6_PER3.SelectedItem = _AxisAssignments._Axis6PER3.ToString
        End If
    End Sub

    'Game Engine uses this to (Load the Structure from the Form)
    Public Sub LoadStrutureFromForm()
        'Load Structure from Form

        'Axis1
        _AxisAssignments._Axis1DIR1 = btn_Axis1_B1.Checked
        _AxisAssignments._Axis1DIR2 = btn_Axis1_B2.Checked
        _AxisAssignments._Axis1DIR3 = btn_Axis1_B3.Checked
        _AxisAssignments._Axis1DOF1 = cb_Assign_Axis1_DOF1.SelectedItem.ToString
        _AxisAssignments._Axis1DOF2 = cb_Assign_Axis1_DOF2.SelectedItem.ToString
        _AxisAssignments._Axis1DOF3 = cb_Assign_Axis1_DOF3.SelectedItem.ToString
        If cb_Assign_Axis1_PER1.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis1PER1 = 0
        Else
            _AxisAssignments._Axis1PER1 = CInt(cb_Assign_Axis1_PER1.SelectedItem)
        End If
        If cb_Assign_Axis1_PER2.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis1PER2 = 0
        Else
            _AxisAssignments._Axis1PER2 = CInt(cb_Assign_Axis1_PER2.SelectedItem)
        End If
        If cb_Assign_Axis1_PER3.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis1PER3 = 0
        Else
            _AxisAssignments._Axis1PER3 = CInt(cb_Assign_Axis1_PER3.SelectedItem)
        End If

        'Axis2
        _AxisAssignments._Axis2DIR1 = btn_Axis2_B1.Checked
        _AxisAssignments._Axis2DIR2 = btn_Axis2_B2.Checked
        _AxisAssignments._Axis2DIR3 = btn_Axis2_B3.Checked
        _AxisAssignments._Axis2DOF1 = cb_Assign_Axis2_DOF1.SelectedItem.ToString
        _AxisAssignments._Axis2DOF2 = cb_Assign_Axis2_DOF2.SelectedItem.ToString
        _AxisAssignments._Axis2DOF3 = cb_Assign_Axis2_DOF3.SelectedItem.ToString
        If cb_Assign_Axis2_PER1.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis2PER1 = 0
        Else
            _AxisAssignments._Axis2PER1 = CInt(cb_Assign_Axis2_PER1.SelectedItem)
        End If
        If cb_Assign_Axis2_PER2.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis2PER2 = 0
        Else
            _AxisAssignments._Axis2PER2 = CInt(cb_Assign_Axis2_PER2.SelectedItem)
        End If
        If cb_Assign_Axis2_PER3.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis2PER3 = 0
        Else
            _AxisAssignments._Axis2PER3 = CInt(cb_Assign_Axis2_PER3.SelectedItem)
        End If

        'Axis3
        _AxisAssignments._Axis3DIR1 = btn_Axis3_B1.Checked
        _AxisAssignments._Axis3DIR2 = btn_Axis3_B2.Checked
        _AxisAssignments._Axis3DIR3 = btn_Axis3_B3.Checked
        _AxisAssignments._Axis3DOF1 = cb_Assign_Axis3_DOF1.SelectedItem.ToString
        _AxisAssignments._Axis3DOF2 = cb_Assign_Axis3_DOF2.SelectedItem.ToString
        _AxisAssignments._Axis3DOF3 = cb_Assign_Axis3_DOF3.SelectedItem.ToString
        If cb_Assign_Axis3_PER1.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis3PER1 = 0
        Else
            _AxisAssignments._Axis3PER1 = CInt(cb_Assign_Axis3_PER1.SelectedItem)
        End If
        If cb_Assign_Axis3_PER2.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis3PER2 = 0
        Else
            _AxisAssignments._Axis3PER2 = CInt(cb_Assign_Axis3_PER2.SelectedItem)
        End If
        If cb_Assign_Axis3_PER3.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis3PER3 = 0
        Else
            _AxisAssignments._Axis3PER3 = CInt(cb_Assign_Axis3_PER3.SelectedItem)
        End If

        'Axis4
        _AxisAssignments._Axis4DIR1 = btn_Axis4_B1.Checked
        _AxisAssignments._Axis4DIR2 = btn_Axis4_B2.Checked
        _AxisAssignments._Axis4DIR3 = btn_Axis4_B3.Checked
        _AxisAssignments._Axis4DOF1 = cb_Assign_Axis4_DOF1.SelectedItem.ToString
        _AxisAssignments._Axis4DOF2 = cb_Assign_Axis4_DOF2.SelectedItem.ToString
        _AxisAssignments._Axis4DOF3 = cb_Assign_Axis4_DOF3.SelectedItem.ToString
        If cb_Assign_Axis4_PER1.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis4PER1 = 0
        Else
            _AxisAssignments._Axis4PER1 = CInt(cb_Assign_Axis4_PER1.SelectedItem)
        End If
        If cb_Assign_Axis4_PER2.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis4PER2 = 0
        Else
            _AxisAssignments._Axis4PER2 = CInt(cb_Assign_Axis4_PER2.SelectedItem)
        End If
        If cb_Assign_Axis4_PER3.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis4PER3 = 0
        Else
            _AxisAssignments._Axis4PER3 = CInt(cb_Assign_Axis4_PER3.SelectedItem)
        End If

        'Axis5
        _AxisAssignments._Axis5DIR1 = btn_Axis5_B1.Checked
        _AxisAssignments._Axis5DIR2 = btn_Axis5_B2.Checked
        _AxisAssignments._Axis5DIR3 = btn_Axis5_B3.Checked
        _AxisAssignments._Axis5DOF1 = cb_Assign_Axis5_DOF1.SelectedItem.ToString
        _AxisAssignments._Axis5DOF2 = cb_Assign_Axis5_DOF2.SelectedItem.ToString
        _AxisAssignments._Axis5DOF3 = cb_Assign_Axis5_DOF3.SelectedItem.ToString
        If cb_Assign_Axis5_PER1.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis5PER1 = 0
        Else
            _AxisAssignments._Axis5PER1 = CInt(cb_Assign_Axis5_PER1.SelectedItem)
        End If
        If cb_Assign_Axis5_PER2.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis5PER2 = 0
        Else
            _AxisAssignments._Axis5PER2 = CInt(cb_Assign_Axis5_PER2.SelectedItem)
        End If
        If cb_Assign_Axis5_PER3.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis5PER3 = 0
        Else
            _AxisAssignments._Axis5PER3 = CInt(cb_Assign_Axis5_PER3.SelectedItem)
        End If

        'Axis6
        _AxisAssignments._Axis6DIR1 = btn_Axis6_B1.Checked
        _AxisAssignments._Axis6DIR2 = btn_Axis6_B2.Checked
        _AxisAssignments._Axis6DIR3 = btn_Axis6_B3.Checked
        _AxisAssignments._Axis6DOF1 = cb_Assign_Axis6_DOF1.SelectedItem.ToString
        _AxisAssignments._Axis6DOF2 = cb_Assign_Axis6_DOF2.SelectedItem.ToString
        _AxisAssignments._Axis6DOF3 = cb_Assign_Axis6_DOF3.SelectedItem.ToString
        If cb_Assign_Axis6_PER1.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis6PER1 = 0
        Else
            _AxisAssignments._Axis6PER1 = CInt(cb_Assign_Axis6_PER1.SelectedItem)
        End If
        If cb_Assign_Axis6_PER2.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis6PER2 = 0
        Else
            _AxisAssignments._Axis6PER2 = CInt(cb_Assign_Axis6_PER2.SelectedItem)
        End If
        If cb_Assign_Axis6_PER3.SelectedItem.ToString = "-" Then
            _AxisAssignments._Axis6PER3 = 0
        Else
            _AxisAssignments._Axis6PER3 = CInt(cb_Assign_Axis6_PER3.SelectedItem)
        End If
    End Sub

    'Game Engine uses this to (Clear the Form)
    Public Sub ClearSettingsWindow()
        'lets clear the form
        btn_Axis1_B1.Checked = False
        btn_Axis1_B2.Checked = False
        btn_Axis1_B3.Checked = False
        btn_Axis2_B1.Checked = False
        btn_Axis2_B2.Checked = False
        btn_Axis2_B3.Checked = False
        btn_Axis3_B1.Checked = False
        btn_Axis3_B2.Checked = False
        btn_Axis3_B3.Checked = False
        btn_Axis4_B1.Checked = False
        btn_Axis4_B2.Checked = False
        btn_Axis4_B3.Checked = False
        btn_Axis5_B1.Checked = False
        btn_Axis5_B2.Checked = False
        btn_Axis5_B3.Checked = False
        btn_Axis6_B1.Checked = False
        btn_Axis6_B2.Checked = False
        btn_Axis6_B3.Checked = False
        cb_Assign_Axis1_DOF1.SelectedItem = "-"
        cb_Assign_Axis1_DOF2.SelectedItem = "-"
        cb_Assign_Axis1_DOF3.SelectedItem = "-"
        cb_Assign_Axis2_DOF1.SelectedItem = "-"
        cb_Assign_Axis2_DOF2.SelectedItem = "-"
        cb_Assign_Axis2_DOF3.SelectedItem = "-"
        cb_Assign_Axis3_DOF1.SelectedItem = "-"
        cb_Assign_Axis3_DOF2.SelectedItem = "-"
        cb_Assign_Axis3_DOF3.SelectedItem = "-"
        cb_Assign_Axis4_DOF1.SelectedItem = "-"
        cb_Assign_Axis4_DOF2.SelectedItem = "-"
        cb_Assign_Axis4_DOF3.SelectedItem = "-"
        cb_Assign_Axis5_DOF1.SelectedItem = "-"
        cb_Assign_Axis5_DOF2.SelectedItem = "-"
        cb_Assign_Axis5_DOF3.SelectedItem = "-"
        cb_Assign_Axis6_DOF1.SelectedItem = "-"
        cb_Assign_Axis6_DOF2.SelectedItem = "-"
        cb_Assign_Axis6_DOF3.SelectedItem = "-"
        cb_Assign_Axis1_PER1.SelectedItem = "-"
        cb_Assign_Axis1_PER2.SelectedItem = "-"
        cb_Assign_Axis1_PER3.SelectedItem = "-"
        cb_Assign_Axis2_PER1.SelectedItem = "-"
        cb_Assign_Axis2_PER2.SelectedItem = "-"
        cb_Assign_Axis2_PER3.SelectedItem = "-"
        cb_Assign_Axis3_PER1.SelectedItem = "-"
        cb_Assign_Axis3_PER2.SelectedItem = "-"
        cb_Assign_Axis3_PER3.SelectedItem = "-"
        cb_Assign_Axis4_PER1.SelectedItem = "-"
        cb_Assign_Axis4_PER2.SelectedItem = "-"
        cb_Assign_Axis4_PER3.SelectedItem = "-"
        cb_Assign_Axis5_PER1.SelectedItem = "-"
        cb_Assign_Axis5_PER2.SelectedItem = "-"
        cb_Assign_Axis5_PER3.SelectedItem = "-"
        cb_Assign_Axis6_PER1.SelectedItem = "-"
        cb_Assign_Axis6_PER2.SelectedItem = "-"
        cb_Assign_Axis6_PER3.SelectedItem = "-"
    End Sub

    'Game Engine uses this to determine when the form has enough info to enable the 'Save' button. 
    Public Function CheckSaveButton() As Boolean
        'Option 1)If you ARE using CheckSaveButton() - Uncomment the block of text below
        'Try
        '    'If using a conditional save button, edit the condition for which the save button should be enabled
        '    If COMPONENT_1.SelectedItem.ToString <> "-" And COMPONENT_2.SelectedItem.ToString <> "-" And COMPONENT_3.SelectedItem.ToString <> "-" Then
        '        btn_Save.Enabled = True
        '        Return True
        '    Else
        '        btn_Save.Enabled = False
        '        Return False
        '    End If
        'Catch ex As Exception
        'End Try

        'Option 2)If your NOT using CheckSaveButton() - Uncomment the (Return True) line below
        Return True
    End Function

    '////////////////////////////////////////////////////////////////////////////////////////
    '///               Edit the User Controls for the Settings Form Here                  ///
    '////////////////////////////////////////////////////////////////////////////////////////
    'All components that are part of the Optional CheckSaveButton sub above, must run CheckSaveButton() when the user makes a change.

    'Example of using the "CheckSaveButton()" sub above
    'Private Sub cb_Assign_Axis1_DOF1_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cb_Assign_Axis1_DOF1.SelectionChangeCommitted
    '    CheckSaveButton()
    'End Sub

    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '///                                                        DO NOT EDIT BELOW HERE!!!                                                           ///
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#Region "No Change Needed - works for all plugins!"
    'Our Settings Structure - used to hold all editable user settings (no change needed)
    Public _AxisAssignments As New AxisAssignmentsPlugin.AxisAssignments
    Public _AxisAssignmentNumber As Integer 'SimTools sets this when it loads the dll 
    Public _CurrentGameName As String = "Default" 'SimTools sets this when the user selects a game to edit settings for 

    'default save location - (no change needed)
    Private _SavePath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\SimTools\GameEngine\"

    'Write the AxisAssignments settings to a file
    Public Sub Save_AxisAssignments(FileName As String)
        LoadStrutureFromForm()

        'Write file
        Dim objWriter As New System.IO.StreamWriter(FileName, False)
        objWriter.WriteLine(SerializeString(_AxisAssignments))
        objWriter.Close()
    End Sub

    'Create Preset folder when loaded
    Private Sub UserControl_Settings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ''create preset folder if it does not exist
        Dim FileName As String = _SavePath & "AxisAssignmentsPresets\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_Presets"
        If System.IO.Directory.Exists(FileName) = False Then
            System.IO.Directory.CreateDirectory(FileName)
        End If

        'create Interface Plugin folder if it does not exist
        FileName = _SavePath & "AxisAssignments" & _AxisAssignmentNumber & "\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "")
        If System.IO.Directory.Exists(FileName) = False Then
            System.IO.Directory.CreateDirectory(FileName)
        End If
    End Sub

    'Save a new/edited Preset
    Public Sub SaveThisPreset(Name As String)
        Dim FileName As String = _SavePath & "AxisAssignmentsPresets\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_Presets\" & Name & "_" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_AxisAssignments.pre"
        Save_AxisAssignments(FileName)
    End Sub

    'Save Settings
    Private Sub btn_Save_AxisAssignments_Click(sender As System.Object, e As System.EventArgs) Handles btn_Save.Click
        'Set Save path
        Dim Save_Path As String = (_SavePath & "AxisAssignments" & _AxisAssignmentNumber & "\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "\" & _CurrentGameName & "_" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_AxisAssignments" & _AxisAssignmentNumber & ".cfg")

        'Save New Settings
        Save_AxisAssignments(Save_Path)

        'Load New Saved Settings into structure
        Dim objReader As New System.IO.StreamReader(Save_Path)
        Dim SerializedString As String = objReader.ReadToEnd()
        objReader.Close()
        _AxisAssignments = CType(DeSerializeString(SerializedString), AxisAssignmentsPlugin.AxisAssignments) 'Structure Loaded Here  

        'inform user that it saved
        MsgBox("Settings Saved", MsgBoxStyle.Information, "Axis Assignments")

        'Make sure we have a Default profile
        Dim defaultfilename As String = _SavePath & "AxisAssignments" & _AxisAssignmentNumber & "\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "\Default_" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_AxisAssignments" & _AxisAssignmentNumber & ".cfg"
        If File.Exists(defaultfilename) = False Then
            Dim result As Integer = Windows.Forms.MessageBox.Show("You do not have a Saved 'Default' profile yet." & vbCrLf & "Would you like to Save these Settings for the 'Default' profile?", "Create a Default Profile?", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Information)
            If result = Windows.Forms.DialogResult.Yes Then
                'Save a copy for Default Settings also
                Save_AxisAssignments(defaultfilename)
                'inform user that it saved
                MsgBox("Default Settings Saved", MsgBoxStyle.Information, "Axis Assignments")
            End If
        End If
    End Sub

    'Serialize to string
    Private Function SerializeString(MyStructure As Object) As String
        Dim string_writer As New StringWriter
        Dim SerializedOutput As String
        Dim xml_serializer As New XmlSerializer(GetType(AxisAssignmentsPlugin.AxisAssignments))
        xml_serializer.Serialize(string_writer, MyStructure)
        SerializedOutput = string_writer.ToString()
        string_writer.Close()
        Return SerializedOutput
    End Function

    'De-Serialize from string
    Private Function DeSerializeString(InputString As String) As Object
        Dim xml_serializer As New XmlSerializer(GetType(AxisAssignmentsPlugin.AxisAssignments))
        Dim string_reader As New StringReader(InputString)
        Dim DeserializedOutput As AxisAssignmentsPlugin.AxisAssignments = DirectCast(xml_serializer.Deserialize(string_reader), AxisAssignmentsPlugin.AxisAssignments)
        string_reader.Close()
        Return DeserializedOutput
    End Function

    'Load saved settings
    Public Sub LoadSavedSettings(ByVal FilePath As String)
        If System.IO.File.Exists(FilePath) = True Then
            Try
                Dim objReader As New System.IO.StreamReader(FilePath)
                Dim SerializedString As String = objReader.ReadToEnd()
                objReader.Close()
                _AxisAssignments = CType(DeSerializeString(SerializedString), AxisAssignmentsPlugin.AxisAssignments) 'Structure Loaded Here
                LoadFormFromStructure()
            Catch ex As Exception
                'clear the form
                ClearSettingsWindow()
                'load structure
                LoadStrutureFromForm()
                'delete bad file
                System.IO.File.Delete(FilePath)
            End Try
        Else
            'copy default file if possible
            Dim defaultfilename As String = _SavePath & "AxisAssignments" & _AxisAssignmentNumber & "\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "\Default_" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_AxisAssignments" & _AxisAssignmentNumber & ".cfg"
            If File.Exists(defaultfilename) = True Then
                'load Default saved settings for the game
                LoadSavedSettings(defaultfilename)
                'save settings for the new game
                Save_AxisAssignments(FilePath)
            Else
                'clear the form
                ClearSettingsWindow()
                'load structure
                LoadStrutureFromForm()
            End If
        End If

        'Set the Save Button
        CheckSaveButton()
    End Sub

    'Load a preset file
    Public Sub Load_Preset(ProfileName As String)
        Dim FileName As String = _SavePath & "AxisAssignmentsPresets\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_Presets\" & ProfileName & "_" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_AxisAssignments.pre"
        If System.IO.File.Exists(FileName) = True Then
            Try
                Dim objReader As New System.IO.StreamReader(FileName)
                Dim SerializedString As String = objReader.ReadToEnd()
                objReader.Close()
                'clear the form
                ClearSettingsWindow()
                'load structure
                _AxisAssignments = CType(DeSerializeString(SerializedString), AxisAssignmentsPlugin.AxisAssignments) 'Structure Loaded Here
                'load form
                LoadFormFromStructure()
                MsgBox(ProfileName & " Axis Assignments Preset Loaded!" & vbCrLf & "Remember to Click [Save] when finished.", MsgBoxStyle.Information, "Axis Assignments Preset")
            Catch ex As Exception
                'clear the form
                ClearSettingsWindow()
                'load structure
                LoadStrutureFromForm()
                'delete bad file
                System.IO.File.Delete(FileName)
                MsgBox(ProfileName & " Is a Invalid Axis Assignments Preset File!" & vbCrLf & "Bad or Corrupt file has been Deleted!", MsgBoxStyle.Critical, "Axis Assignments Preset")
            End Try
        End If

        'Reset the save button
        CheckSaveButton() 'required - do not edit
    End Sub
#End Region
End Class
