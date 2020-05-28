Option Strict On
Option Explicit On

Imports AxisAssignments_PluginAPI
Imports System.Threading

Public Class AxisAssignmentsPlugin
    Implements IPlugin_AxisAssignments
    Private _SavePath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\SimTools\GameEngine\"
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '///         SimTools AxisAssignments Plugin - Edit the Settings below to provide support for your new AxisAssignments plugin!         ///
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '////////////////////////////////////////////////////////////////////////////
    '///        Per AxisAssignments Settings - Change for Each Plugin         ///
    '////////////////////////////////////////////////////////////////////////////
    Private Const _PluginAuthorsName As String = "yobuddy" 'Authors Name Here
    Public Const _AxisAssignmentsName As String = "Generic 2D Example" 'Full Name of the Math Plugin  - Must Be Unique - (Don't use 'Plugin' in name please)
    '/////////////////////////////////////////////////////////////////////////////
    '///   What AxisAssignments SimTools will make this Plugin Available for   ///
    '/////////////////////////////////////////////////////////////////////////////
    Private Const _Enable_AxisAssignments1 As Boolean = True
    Private Const _Enable_AxisAssignments2 As Boolean = True
    '//////////////////////////////////////////////////////////////////////////////
    '///      The AxisAssignments Structure - Edit the Elements as Needed       ///
    '//////////////////////////////////////////////////////////////////////////////
    Structure AxisAssignments
        'Axis1
        Public _Axis1DIR1 As Boolean
        Public _Axis1DOF1 As String
        Public _Axis1PER1 As Integer
        Public _Axis1DIR2 As Boolean
        Public _Axis1DOF2 As String
        Public _Axis1PER2 As Integer
        Public _Axis1DIR3 As Boolean
        Public _Axis1DOF3 As String
        Public _Axis1PER3 As Integer

        'Axis2
        Public _Axis2DIR1 As Boolean
        Public _Axis2DOF1 As String
        Public _Axis2PER1 As Integer
        Public _Axis2DIR2 As Boolean
        Public _Axis2DOF2 As String
        Public _Axis2PER2 As Integer
        Public _Axis2DIR3 As Boolean
        Public _Axis2DOF3 As String
        Public _Axis2PER3 As Integer

        'Axis3
        Public _Axis3DIR1 As Boolean
        Public _Axis3DOF1 As String
        Public _Axis3PER1 As Integer
        Public _Axis3DIR2 As Boolean
        Public _Axis3DOF2 As String
        Public _Axis3PER2 As Integer
        Public _Axis3DIR3 As Boolean
        Public _Axis3DOF3 As String
        Public _Axis3PER3 As Integer

        'Axis4
        Public _Axis4DIR1 As Boolean
        Public _Axis4DOF1 As String
        Public _Axis4PER1 As Integer
        Public _Axis4DIR2 As Boolean
        Public _Axis4DOF2 As String
        Public _Axis4PER2 As Integer
        Public _Axis4DIR3 As Boolean
        Public _Axis4DOF3 As String
        Public _Axis4PER3 As Integer

        'Axis5
        Public _Axis5DIR1 As Boolean
        Public _Axis5DOF1 As String
        Public _Axis5PER1 As Integer
        Public _Axis5DIR2 As Boolean
        Public _Axis5DOF2 As String
        Public _Axis5PER2 As Integer
        Public _Axis5DIR3 As Boolean
        Public _Axis5DOF3 As String
        Public _Axis5PER3 As Integer

        'Axis6
        Public _Axis6DIR1 As Boolean
        Public _Axis6DOF1 As String
        Public _Axis6PER1 As Integer
        Public _Axis6DIR2 As Boolean
        Public _Axis6DOF2 As String
        Public _Axis6PER2 As Integer
        Public _Axis6DIR3 As Boolean
        Public _Axis6DOF3 As String
        Public _Axis6PER3 As Integer
    End Structure

    '///////////////////////////////////////////////////////////////////////////////
    '///                     Edit these 5 Subroutines Below                      ///
    '///////////////////////////////////////////////////////////////////////////////
    'Used by GameEngine when the plugin gets loaded.
    Public Sub StartUp()
        'When the Plugin gets Loaded
    End Sub

    'Used by GameEngine when the plugin gets un-loaded.
    Public Sub ShutDown() Implements IPlugin_AxisAssignments.ShutDown
        'When the Plugin gets Un-Loaded
        Output_Calculations_Running = False
    End Sub

    ''Used by GameEngine when a Game Starts
    Public Sub GameStart()
        'Game Started, Start your engine here.
        StartupSelected()
    End Sub

    'Used by GameEngine when the Game Stops
    Public Sub GameStop()
        'Game Ended, Stop your engine here.
        Output_Calculations_Running = False
    End Sub

    'Reset any need vars here - gets called after 'GameStop()'
    Private Sub ResetValues()
        'Reset anything else needed here.
    End Sub

    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '///                                                 PLACE EXTRA NEEDED CODE/FUNCTIONS HERE                                                     ///
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#Region "Extra Code Needed for this AxisAssignmnets Plugin"
    Private Const CalculateRateMS As Integer = 1 'how fast in ms to loop when calculating Axis (Do not use a value smaller than 1)   
    Private Output_Calculations_Running As Boolean = False 'Running/Not_Running Flag

    'startup selected calculations - Make sure 2 can't startup at the same time 
    Private Sub StartupSelected()
        If Output_Calculations_Running = False Then

            'set the IsRunning flag
            Output_Calculations_Running = True

            'Only turn the axis output on if the axis is being used.
            'Axis1
            If MyForm._AxisAssignments._Axis1DOF1 <> "-" Or MyForm._AxisAssignments._Axis1DOF2 <> "-" Or MyForm._AxisAssignments._Axis1DOF3 <> "-" Then
                'Axis 1
                Dim trd1 As Thread = New Thread(AddressOf Axis1_Calulations)
                trd1.IsBackground = True
                trd1.Start()
            End If

            'Axis2
            If MyForm._AxisAssignments._Axis2DOF1 <> "-" Or MyForm._AxisAssignments._Axis2DOF2 <> "-" Or MyForm._AxisAssignments._Axis2DOF3 <> "-" Then
                'Axis 2
                Dim trd2 As Thread = New Thread(AddressOf Axis2_Calulations)
                trd2.IsBackground = True
                trd2.Start()
            End If

            'Axis3
            If MyForm._AxisAssignments._Axis3DOF1 <> "-" Or MyForm._AxisAssignments._Axis3DOF2 <> "-" Or MyForm._AxisAssignments._Axis3DOF3 <> "-" Then
                'Axis 3
                Dim trd3 As Thread = New Thread(AddressOf Axis3_Calulations)
                trd3.IsBackground = True
                trd3.Start()
            End If

            'Axis4
            If MyForm._AxisAssignments._Axis4DOF1 <> "-" Or MyForm._AxisAssignments._Axis4DOF2 <> "-" Or MyForm._AxisAssignments._Axis4DOF3 <> "-" Then
                'Axis 4
                Dim trd4 As Thread = New Thread(AddressOf Axis4_Calulations)
                trd4.IsBackground = True
                trd4.Start()
            End If

            'Axis5
            If MyForm._AxisAssignments._Axis5DOF1 <> "-" Or MyForm._AxisAssignments._Axis5DOF2 <> "-" Or MyForm._AxisAssignments._Axis5DOF3 <> "-" Then
                'Axis 5
                Dim trd5 As Thread = New Thread(AddressOf Axis5_Calulations)
                trd5.IsBackground = True
                trd5.Start()
            End If

            'Axis6
            If MyForm._AxisAssignments._Axis6DOF1 <> "-" Or MyForm._AxisAssignments._Axis6DOF2 <> "-" Or MyForm._AxisAssignments._Axis6DOF3 <> "-" Then
                'Axis 6
                Dim trd6 As Thread = New Thread(AddressOf Axis6_Calulations)
                trd6.IsBackground = True
                trd6.Start()
            End If
        End If
    End Sub

    'Calculate Axis ************************
#Region "Axis Calulations"
#Region "Axis1"
    Private Axis1_Value1_Out As Double = 0 'DOF1 value
    Private Axis1_Value2_Out As Double = 0 'DOF2 value
    Private Axis1_Value3_Out As Double = 0 'DOF3 value
    Private Sub Axis1_Calulations()
        Do While Output_Calculations_Running = True
            With MyForm._AxisAssignments
                'DOF1
                Select Case ._Axis1DOF1
                    Case "-"
                        Axis1_Value1_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis1_Value1_Out = _Roll_Input * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis1_Value1_Out = _Pitch_Input * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis1_Value1_Out = _Heave_Input * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis1_Value1_Out = _Yaw_Input * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis1_Value1_Out = _Sway_Input * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis1_Value1_Out = _Surge_Input * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis1_Value1_Out = _Extra1_Input * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis1_Value1_Out = _Extra2_Input * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis1_Value1_Out = _Extra3_Input * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis1DOF2
                    Case "-"
                        Axis1_Value2_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis1_Value2_Out = _Roll_Input * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis1_Value2_Out = _Pitch_Input * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis1_Value2_Out = _Heave_Input * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis1_Value2_Out = _Yaw_Input * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis1_Value2_Out = _Sway_Input * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis1_Value2_Out = _Surge_Input * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis1_Value2_Out = _Extra1_Input * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis1_Value2_Out = _Extra2_Input * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis1_Value2_Out = _Extra3_Input * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis1DOF3
                    Case "-"
                        Axis1_Value3_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis1_Value3_Out = _Roll_Input * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis1_Value3_Out = _Pitch_Input * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis1_Value3_Out = _Heave_Input * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis1_Value3_Out = _Yaw_Input * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis1_Value3_Out = _Sway_Input * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis1_Value3_Out = _Surge_Input * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis1_Value3_Out = _Extra1_Input * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis1_Value3_Out = _Extra2_Input * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis1_Value3_Out = _Extra3_Input * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                End Select

                'BUILD Value & Assign Output
                _Axis1Output = Axis1_Value1_Out + Axis1_Value2_Out + Axis1_Value3_Out
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis2"
    Private Axis2_Value1_Out As Double = 0
    Private Axis2_Value2_Out As Double = 0
    Private Axis2_Value3_Out As Double = 0
    Private Sub Axis2_Calulations()
        Do While Output_Calculations_Running = True
            With MyForm._AxisAssignments
                'DOF1
                Select Case ._Axis2DOF1
                    Case "-"
                        Axis2_Value1_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis2_Value1_Out = _Roll_Input * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis2_Value1_Out = _Pitch_Input * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis2_Value1_Out = _Heave_Input * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis2_Value1_Out = _Yaw_Input * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis2_Value1_Out = _Sway_Input * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis2_Value1_Out = _Surge_Input * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis2_Value1_Out = _Extra1_Input * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis2_Value1_Out = _Extra2_Input * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis2_Value1_Out = _Extra3_Input * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis2DOF2
                    Case "-"
                        Axis2_Value2_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis2_Value2_Out = _Roll_Input * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis2_Value2_Out = _Pitch_Input * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis2_Value2_Out = _Heave_Input * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis2_Value2_Out = _Yaw_Input * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis2_Value2_Out = _Sway_Input * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis2_Value2_Out = _Surge_Input * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis2_Value2_Out = _Extra1_Input * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis2_Value2_Out = _Extra2_Input * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis2_Value2_Out = _Extra3_Input * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis2DOF3
                    Case "-"
                        Axis2_Value3_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis2_Value3_Out = _Roll_Input * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis2_Value3_Out = _Pitch_Input * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis2_Value3_Out = _Heave_Input * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis2_Value3_Out = _Yaw_Input * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis2_Value3_Out = _Sway_Input * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis2_Value3_Out = _Surge_Input * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis2_Value3_Out = _Extra1_Input * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis2_Value3_Out = _Extra2_Input * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis2_Value3_Out = _Extra3_Input * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                End Select


                'BUILD Value & Assign Output
                _Axis2Output = Axis2_Value1_Out + Axis2_Value2_Out + Axis2_Value3_Out
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis3"
    Private Axis3_Value1_Out As Double = 0
    Private Axis3_Value2_Out As Double = 0
    Private Axis3_Value3_Out As Double = 0
    Private Sub Axis3_Calulations()
        Do While Output_Calculations_Running = True
            With MyForm._AxisAssignments
                'DOF1
                Select Case ._Axis3DOF1
                    Case "-"
                        Axis3_Value1_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis3_Value1_Out = _Roll_Input * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis3_Value1_Out = _Pitch_Input * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis3_Value1_Out = _Heave_Input * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis3_Value1_Out = _Yaw_Input * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis3_Value1_Out = _Sway_Input * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis3_Value1_Out = _Surge_Input * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis3_Value1_Out = _Extra1_Input * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis3_Value1_Out = _Extra2_Input * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis3_Value1_Out = _Extra3_Input * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis3DOF2
                    Case "-"
                        Axis3_Value2_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis3_Value2_Out = _Roll_Input * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis3_Value2_Out = _Pitch_Input * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis3_Value2_Out = _Heave_Input * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis3_Value2_Out = _Yaw_Input * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis3_Value2_Out = _Sway_Input * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis3_Value2_Out = _Surge_Input * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis3_Value2_Out = _Extra1_Input * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis3_Value2_Out = _Extra2_Input * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis3_Value2_Out = _Extra3_Input * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis3DOF3
                    Case "-"
                        Axis3_Value3_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis3_Value3_Out = _Roll_Input * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis3_Value3_Out = _Pitch_Input * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis3_Value3_Out = _Heave_Input * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis3_Value3_Out = _Yaw_Input * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis3_Value3_Out = _Sway_Input * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis3_Value3_Out = _Surge_Input * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis3_Value3_Out = _Extra1_Input * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis3_Value3_Out = _Extra2_Input * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis3_Value3_Out = _Extra3_Input * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                End Select


                'BUILD Value
                _Axis3Output = Axis3_Value1_Out + Axis3_Value2_Out + Axis3_Value3_Out
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis4"
    Private Axis4_Value1_Out As Double = 0
    Private Axis4_Value2_Out As Double = 0
    Private Axis4_Value3_Out As Double = 0
    Private Sub Axis4_Calulations()
        Do While Output_Calculations_Running = True
            With MyForm._AxisAssignments
                'DOF1
                Select Case ._Axis4DOF1
                    Case "-"
                        Axis4_Value1_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis4_Value1_Out = _Roll_Input * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis4_Value1_Out = _Pitch_Input * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis4_Value1_Out = _Heave_Input * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis4_Value1_Out = _Yaw_Input * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis4_Value1_Out = _Sway_Input * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis4_Value1_Out = _Surge_Input * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis4_Value1_Out = _Extra1_Input * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis4_Value1_Out = _Extra2_Input * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis4_Value1_Out = _Extra3_Input * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis4DOF2
                    Case "-"
                        Axis4_Value2_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis4_Value2_Out = _Roll_Input * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis4_Value2_Out = _Pitch_Input * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis4_Value2_Out = _Heave_Input * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis4_Value2_Out = _Yaw_Input * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis4_Value2_Out = _Sway_Input * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis4_Value2_Out = _Surge_Input * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis4_Value2_Out = _Extra1_Input * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis4_Value2_Out = _Extra2_Input * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis4_Value2_Out = _Extra3_Input * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis4DOF3
                    Case "-"
                        Axis4_Value3_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis4_Value3_Out = _Roll_Input * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis4_Value3_Out = _Pitch_Input * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis4_Value3_Out = _Heave_Input * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis4_Value3_Out = _Yaw_Input * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis4_Value3_Out = _Sway_Input * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis4_Value3_Out = _Surge_Input * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis4_Value3_Out = _Extra1_Input * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis4_Value3_Out = _Extra2_Input * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis4_Value3_Out = _Extra3_Input * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                End Select

                'BUILD Value
                _Axis4Output = Axis4_Value1_Out + Axis4_Value2_Out + Axis4_Value3_Out
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis5"
    Private Axis5_Value1_Out As Double = 0
    Private Axis5_Value2_Out As Double = 0
    Private Axis5_Value3_Out As Double = 0
    Private Sub Axis5_Calulations()
        Do While Output_Calculations_Running = True
            With MyForm._AxisAssignments
                'DOF1
                Select Case ._Axis5DOF1
                    Case "-"
                        Axis5_Value1_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis5_Value1_Out = _Roll_Input * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis5_Value1_Out = _Pitch_Input * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis5_Value1_Out = _Heave_Input * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis5_Value1_Out = _Yaw_Input * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis5_Value1_Out = _Sway_Input * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis5_Value1_Out = _Surge_Input * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis5_Value1_Out = _Extra1_Input * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis5_Value1_Out = _Extra2_Input * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis5_Value1_Out = _Extra3_Input * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis5DOF2
                    Case "-"
                        Axis5_Value2_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis5_Value2_Out = _Roll_Input * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis5_Value2_Out = _Pitch_Input * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis5_Value2_Out = _Heave_Input * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis5_Value2_Out = _Yaw_Input * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis5_Value2_Out = _Sway_Input * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis5_Value2_Out = _Surge_Input * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis5_Value2_Out = _Extra1_Input * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis5_Value2_Out = _Extra2_Input * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis5_Value2_Out = _Extra3_Input * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis5DOF3
                    Case "-"
                        Axis5_Value3_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis5_Value3_Out = _Roll_Input * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis5_Value3_Out = _Pitch_Input * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis5_Value3_Out = _Heave_Input * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis5_Value3_Out = _Yaw_Input * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis5_Value3_Out = _Sway_Input * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis5_Value3_Out = _Surge_Input * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis5_Value3_Out = _Extra1_Input * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis5_Value3_Out = _Extra2_Input * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis5_Value3_Out = _Extra3_Input * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                End Select

                'BUILD Value
                _Axis5Output = Axis5_Value1_Out + Axis5_Value2_Out + Axis5_Value3_Out
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis6"
    Private Axis6_Value1_Out As Double = 0
    Private Axis6_Value2_Out As Double = 0
    Private Axis6_Value3_Out As Double = 0
    Private Sub Axis6_Calulations()
        Do While Output_Calculations_Running = True
            With MyForm._AxisAssignments
                'DOF1
                Select Case ._Axis6DOF1
                    Case "-"
                        Axis6_Value1_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis6_Value1_Out = _Roll_Input * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis6_Value1_Out = _Pitch_Input * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis6_Value1_Out = _Heave_Input * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis6_Value1_Out = _Yaw_Input * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis6_Value1_Out = _Sway_Input * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis6_Value1_Out = _Surge_Input * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis6_Value1_Out = _Extra1_Input * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis6_Value1_Out = _Extra2_Input * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis6_Value1_Out = _Extra3_Input * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis6DOF2
                    Case "-"
                        Axis6_Value2_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis6_Value2_Out = _Roll_Input * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis6_Value2_Out = _Pitch_Input * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis6_Value2_Out = _Heave_Input * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis6_Value2_Out = _Yaw_Input * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis6_Value2_Out = _Sway_Input * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis6_Value2_Out = _Surge_Input * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis6_Value2_Out = _Extra1_Input * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis6_Value2_Out = _Extra2_Input * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis6_Value2_Out = _Extra3_Input * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis6DOF3
                    Case "-"
                        Axis6_Value3_Out = 0
                    Case "Roll"
                        'Get percent used for DOF
                        Axis6_Value3_Out = _Roll_Input * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis6_Value3_Out = _Pitch_Input * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis6_Value3_Out = _Heave_Input * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis6_Value3_Out = _Yaw_Input * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis6_Value3_Out = _Sway_Input * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis6_Value3_Out = _Surge_Input * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis6_Value3_Out = _Extra1_Input * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis6_Value3_Out = _Extra2_Input * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis6_Value3_Out = _Extra3_Input * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                End Select

                'BUILD Value
                _Axis6Output = Axis6_Value1_Out + Axis6_Value2_Out + Axis6_Value3_Out
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region
#End Region
#End Region

    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '///                                                        DO NOT EDIT BELOW HERE!!!                                                           ///
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#Region "SimTools Required Functions - Do Not Change"
    Public MyForm As New UserControl_Settings 'Our Settings Form for this AxisAssignments
    Private GameStarted_ProperSettings As Boolean = False 'Only start if there is proper settings

    'DOF Inputs (DOF Inputs from GameEngine  - these should be values from -1 to 1)
    Private _Roll_Input As Double = 0.0
    Private _Pitch_Input As Double = 0.0
    Private _Heave_Input As Double = 0.0
    Private _Yaw_Input As Double = 0.0
    Private _Sway_Input As Double = 0.0
    Private _Surge_Input As Double = 0.0
    Private _Extra1_Input As Double = 0.0
    Private _Extra2_Input As Double = 0.0
    Private _Extra3_Input As Double = 0.0

    'Axis Outputs (What gets returned to GameEngine - these should be values from -1 to 1)
    Private _Axis1Output As Double = 0.0
    Private _Axis2Output As Double = 0.0
    Private _Axis3Output As Double = 0.0
    Private _Axis4Output As Double = 0.0
    Private _Axis5Output As Double = 0.0
    Private _Axis6Output As Double = 0.0

    'Sets the current game name
    Sub SetCurrentGame(Value As String) Implements IPlugin_AxisAssignments.SetGameName
        'Set the new game name
        MyForm._CurrentGameName = Value.Replace(" ", "")

        'loadfile
        MyForm.LoadSavedSettings(_SavePath & "AxisAssignments" & MyForm._AxisAssignmentNumber & "\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "\" & MyForm._CurrentGameName & "_" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_AxisAssignments" & MyForm._AxisAssignmentNumber & ".cfg") 'load any saved settings 
    End Sub

    'Resets the Internal Vars
    Public Sub Reset_Plugin()
        'Input DOF values from GameEngine - OUR INPUTS
        _Roll_Input = 0.0
        _Pitch_Input = 0.0
        _Heave_Input = 0.0
        _Yaw_Input = 0.0
        _Sway_Input = 0.0
        _Surge_Input = 0.0
        _Extra1_Input = 0.0
        _Extra2_Input = 0.0
        _Extra3_Input = 0.0

        'Axis Outputs (What gets returned to Game Engine)- OUR OUTPUTS
        _Axis1Output = 0.0
        _Axis2Output = 0.0
        _Axis3Output = 0.0
        _Axis4Output = 0.0
        _Axis5Output = 0.0
        _Axis6Output = 0.0

        'reset any extra needed vars (Above)
        ResetValues()
    End Sub

    'game start
    Public Sub Game_Start() Implements IPlugin_AxisAssignments.GameStart
        'Start Engine if there are proper settings
        Dim filename As String = _SavePath & "AxisAssignments" & MyForm._AxisAssignmentNumber & "\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "\" & MyForm._CurrentGameName & "_" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_AxisAssignments" & MyForm._AxisAssignmentNumber & ".cfg"
        If IO.File.Exists(filename) = True And GameStarted_ProperSettings = False Then
            GameStarted_ProperSettings = True
            GameStart()
        End If
    End Sub

    'game end
    Public Sub Game_End() Implements IPlugin_AxisAssignments.GameEnd
        'Stop Engine if it has been started
        If GameStarted_ProperSettings = True Then
            GameStarted_ProperSettings = False
            GameStop()
            'pause to let calculation routines shut down
            Thread.Sleep(100)
        End If
        'Reset Plugin
        Reset_Plugin()
    End Sub

    'what axis assignments enable for
    Public ReadOnly Property Enable_AxisAssignments1 As Boolean Implements IPlugin_AxisAssignments.IsEnabled_AxisAssignments1
        Get
            Return _Enable_AxisAssignments1
        End Get
    End Property

    Public ReadOnly Property Enable_AxisAssignments2 As Boolean Implements IPlugin_AxisAssignments.IsEnabled_AxisAssignments2
        Get
            Return _Enable_AxisAssignments2
        End Get
    End Property

    'set what Axis Assignment number
    Public WriteOnly Property AxisAssignmentNumber As Integer Implements IPlugin_AxisAssignments.WhatAxisAssignments
        Set(value As Integer)
            MyForm._AxisAssignmentNumber = value
        End Set
    End Property

    'get name
    Public ReadOnly Property Get_AxisAssignmentsName As String Implements IPlugin_AxisAssignments.AxisAssignmentsName
        Get
            Return _AxisAssignmentsName
        End Get
    End Property

    'get author
    Public ReadOnly Property Get_PluginAuthorsName As String Implements IPlugin_AxisAssignments.PluginAuthorsName
        Get
            Return _PluginAuthorsName
        End Get
    End Property

    'Axis Outputs - end value returns
    Public ReadOnly Property Get_Axis1_Output As Double Implements IPlugin_AxisAssignments.Get_Axis1_Output
        Get
            'Stay in the limits (-1 to 1)
            Dim ReturnValue As Double = _Axis1Output
            If ReturnValue > 1 Then
                Return 1
            ElseIf ReturnValue < -1 Then
                Return -1
            Else
                Return ReturnValue
            End If
        End Get
    End Property

    Public ReadOnly Property Get_Axis2_Output As Double Implements IPlugin_AxisAssignments.Get_Axis2_Output
        Get
            'Stay in the limits (-1 to 1)
            Dim ReturnValue As Double = _Axis2Output
            If ReturnValue > 1 Then
                Return 1
            ElseIf ReturnValue < -1 Then
                Return -1
            Else
                Return ReturnValue
            End If
        End Get
    End Property

    Public ReadOnly Property Get_Axis3_Output As Double Implements IPlugin_AxisAssignments.Get_Axis3_Output
        Get
            'Stay in the limits (-1 to 1)
            Dim ReturnValue As Double = _Axis3Output
            If ReturnValue > 1 Then
                Return 1
            ElseIf ReturnValue < -1 Then
                Return -1
            Else
                Return ReturnValue
            End If
        End Get
    End Property

    Public ReadOnly Property Get_Axis4_Output As Double Implements IPlugin_AxisAssignments.Get_Axis4_Output
        Get
            'Stay in the limits (-1 to 1)
            Dim ReturnValue As Double = _Axis4Output
            If ReturnValue > 1 Then
                Return 1
            ElseIf ReturnValue < -1 Then
                Return -1
            Else
                Return ReturnValue
            End If
        End Get
    End Property

    Public ReadOnly Property Get_Axis5_Output As Double Implements IPlugin_AxisAssignments.Get_Axis5_Output
        Get
            'Stay in the limits (-1 to 1)
            Dim ReturnValue As Double = _Axis5Output
            If ReturnValue > 1 Then
                Return 1
            ElseIf ReturnValue < -1 Then
                Return -1
            Else
                Return ReturnValue
            End If
        End Get
    End Property

    Public ReadOnly Property Get_Axis6_Output As Double Implements IPlugin_AxisAssignments.Get_Axis6_Output
        Get
            'Stay in the limits (-1 to 1)
            Dim ReturnValue As Double = _Axis6Output
            If ReturnValue > 1 Then
                Return 1
            ElseIf ReturnValue < -1 Then
                Return -1
            Else
                Return ReturnValue
            End If
        End Get
    End Property

    'DOF Inputs - GameEngine Sets this Input while a game running
    Public WriteOnly Property Set_InputRoll As Double Implements IPlugin_AxisAssignments.Set_InputRoll
        Set(value As Double)
            _Roll_Input = value
        End Set
    End Property

    Public WriteOnly Property Set_InputPitch As Double Implements IPlugin_AxisAssignments.Set_InputPitch
        Set(value As Double)
            _Pitch_Input = value
        End Set
    End Property

    Public WriteOnly Property Set_InputHeave As Double Implements IPlugin_AxisAssignments.Set_InputHeave
        Set(value As Double)
            _Heave_Input = value
        End Set
    End Property

    Public WriteOnly Property Set_InputYaw As Double Implements IPlugin_AxisAssignments.Set_InputYaw
        Set(value As Double)
            _Yaw_Input = value
        End Set
    End Property

    Public WriteOnly Property Set_InputSway As Double Implements IPlugin_AxisAssignments.Set_InputSway
        Set(value As Double)
            _Sway_Input = value
        End Set
    End Property

    Public WriteOnly Property Set_InputSurge As Double Implements IPlugin_AxisAssignments.Set_InputSurge
        Set(value As Double)
            _Surge_Input = value
        End Set
    End Property

    Public WriteOnly Property Set_InputExtra1 As Double Implements IPlugin_AxisAssignments.Set_InputExtra1
        Set(value As Double)
            _Extra1_Input = value
        End Set
    End Property

    Public WriteOnly Property Set_InputExtra2 As Double Implements IPlugin_AxisAssignments.Set_InputExtra2
        Set(value As Double)
            _Extra2_Input = value
        End Set
    End Property

    Public WriteOnly Property Set_InputExtra3 As Double Implements IPlugin_AxisAssignments.Set_InputExtra3
        Set(value As Double)
            _Extra3_Input = value
        End Set
    End Property

    'gets the window and loads settings if found
    Public Function GetSettingsWindow() As Object Implements AxisAssignments_PluginAPI.IPlugin_AxisAssignments.GetSettingsWindow
        'current path
        Dim FinalPath As String = _SavePath & "AxisAssignments" & MyForm._AxisAssignmentNumber & "\" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "\" & MyForm._CurrentGameName & "_" & AxisAssignmentsPlugin._AxisAssignmentsName.Replace(" ", "") & "_AxisAssignments" & MyForm._AxisAssignmentNumber & ".cfg"
        'Run Startup Commands Above
        StartUp()
        'see if there are any saved settings
        If IO.File.Exists(FinalPath) Then
            MyForm.LoadSavedSettings(FinalPath)
        Else
            ResetSettingsWindow()
        End If
        'return Panel
        Return MyForm
    End Function

    'Save a preset
    Public Sub SavePreset(Name As String) Implements AxisAssignments_PluginAPI.IPlugin_AxisAssignments.SavePreset
        MyForm.SaveThisPreset(Name)
    End Sub

    'Load a preset
    Public Sub LoadPreset(ProName As String) Implements AxisAssignments_PluginAPI.IPlugin_AxisAssignments.LoadPreset
        MyForm.Load_Preset(ProName)
    End Sub

    'Load a saved settings file for a game
    Public Sub LoadAxisAssignments(FilePath As String) Implements AxisAssignments_PluginAPI.IPlugin_AxisAssignments.LoadAxisAssignments
        MyForm.LoadSavedSettings(FilePath)
    End Sub

    'Clear_AxisAssignments form
    Public Sub ResetSettingsWindow() Implements AxisAssignments_PluginAPI.IPlugin_AxisAssignments.ResetSettingsWindow
        'clear the form
        MyForm.ClearSettingsWindow()
        'load structure
        MyForm.LoadStrutureFromForm()
        'Reset the save button
        MyForm.CheckSaveButton()
    End Sub
#End Region
End Class