Option Explicit On
Option Strict On

Imports System.Threading
Module Mod_Calc
    'Private ReadOnly SavePath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\SimTools\GameEngine"
    Private Const CalculateRateMS As Integer = 1 'how fast to loop when calculating Axis   
    Private Output_Calulations_Running As Boolean = False
    Private Struct_AxisAssignments As New MathPlugin.AxisAssignments

    'Per Axies DOF Outputs
    Private Roll_Input As Double = 0.0
    Private Pitch_Input As Double = 0.0
    Private Heave_Input As Double = 0.0
    Private Yaw_Input As Double = 0.0
    Private Sway_Input As Double = 0.0
    Private Surge_Input As Double = 0.0
    Private Extra1_Input As Double = 0.0
    Private Extra2_Input As Double = 0.0
    Private Extra3_Input As Double = 0.0
    Private _OutputRoll_Axis1 As Double = 0.0
    Private _OutputPitch_Axis1 As Double = 0.0
    Private _OutputHeave_Axis1 As Double = 0.0
    Private _OutputYaw_Axis1 As Double = 0.0
    Private _OutputSway_Axis1 As Double = 0.0
    Private _OutputSurge_Axis1 As Double = 0.0
    Private _OutputExtra1_Axis1 As Double = 0.0
    Private _OutputExtra2_Axis1 As Double = 0.0
    Private _OutputExtra3_Axis1 As Double = 0.0
    Private _OutputRoll_Axis2 As Double = 0.0
    Private _OutputPitch_Axis2 As Double = 0.0
    Private _OutputHeave_Axis2 As Double = 0.0
    Private _OutputYaw_Axis2 As Double = 0.0
    Private _OutputSway_Axis2 As Double = 0.0
    Private _OutputSurge_Axis2 As Double = 0.0
    Private _OutputExtra1_Axis2 As Double = 0.0
    Private _OutputExtra2_Axis2 As Double = 0.0
    Private _OutputExtra3_Axis2 As Double = 0.0
    Private _OutputRoll_Axis3 As Double = 0.0
    Private _OutputPitch_Axis3 As Double = 0.0
    Private _OutputHeave_Axis3 As Double = 0.0
    Private _OutputYaw_Axis3 As Double = 0.0
    Private _OutputSway_Axis3 As Double = 0.0
    Private _OutputSurge_Axis3 As Double = 0.0
    Private _OutputExtra1_Axis3 As Double = 0.0
    Private _OutputExtra2_Axis3 As Double = 0.0
    Private _OutputExtra3_Axis3 As Double = 0.0
    Private _OutputRoll_Axis4 As Double = 0.0
    Private _OutputPitch_Axis4 As Double = 0.0
    Private _OutputHeave_Axis4 As Double = 0.0
    Private _OutputYaw_Axis4 As Double = 0.0
    Private _OutputSway_Axis4 As Double = 0.0
    Private _OutputSurge_Axis4 As Double = 0.0
    Private _OutputExtra1_Axis4 As Double = 0.0
    Private _OutputExtra2_Axis4 As Double = 0.0
    Private _OutputExtra3_Axis4 As Double = 0.0
    Private _OutputRoll_Axis5 As Double = 0.0
    Private _OutputPitch_Axis5 As Double = 0.0
    Private _OutputHeave_Axis5 As Double = 0.0
    Private _OutputYaw_Axis5 As Double = 0.0
    Private _OutputSway_Axis5 As Double = 0.0
    Private _OutputSurge_Axis5 As Double = 0.0
    Private _OutputExtra1_Axis5 As Double = 0.0
    Private _OutputExtra2_Axis5 As Double = 0.0
    Private _OutputExtra3_Axis5 As Double = 0.0
    Private _OutputRoll_Axis6 As Double = 0.0
    Private _OutputPitch_Axis6 As Double = 0.0
    Private _OutputHeave_Axis6 As Double = 0.0
    Private _OutputYaw_Axis6 As Double = 0.0
    Private _OutputSway_Axis6 As Double = 0.0
    Private _OutputSurge_Axis6 As Double = 0.0
    Private _OutputExtra1_Axis6 As Double = 0.0
    Private _OutputExtra2_Axis6 As Double = 0.0
    Private _OutputExtra3_Axis6 As Double = 0.0

    'Axis Outputs (What gets returned to Game Engine)
    Private _Axis1Output As Double = 0.0
    Private _Axis2Output As Double = 0.0
    Private _Axis3Output As Double = 0.0
    Private _Axis4Output As Double = 0.0
    Private _Axis5Output As Double = 0.0
    Private _Axis6Output As Double = 0.0

    'Axis IsUsed (Game Engine sets these on startup - depends on users interface outputs)
    Private Axis1_IsUsed As Boolean = False
    Private Axis2_IsUsed As Boolean = False
    Private Axis3_IsUsed As Boolean = False
    Private Axis4_IsUsed As Boolean = False
    Private Axis5_IsUsed As Boolean = False
    Private Axis6_IsUsed As Boolean = False

    'DOFs IsUsed (These get returned to Game Engine so it knows what DOF error to calculate)
    Private Roll_IsUsed As Boolean = False
    Private Pitch_IsUsed As Boolean = False
    Private Heave_IsUsed As Boolean = False
    Private Yaw_IsUsed As Boolean = False
    Private Sway_IsUsed As Boolean = False
    Private Surge_IsUsed As Boolean = False
    Private Extra1_IsUsed As Boolean = False
    Private Extra2_IsUsed As Boolean = False
    Private Extra3_IsUsed As Boolean = False

    'startup selected calculations  
    Public Sub StartupSelected()
        'Now we know what AXIS output are used ###############################################
        'Now we need what DOF's to start
        'AxisAssignments
        If Axis1_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis1DOF1
                Case "Roll"
                    Start_OutputRoll_Axis1()
                Case "Pitch"
                    Start_OutputPitch_Axis1()
                Case "Heave"
                    Start_OutputHeave_Axis1()
                Case "Yaw"
                    Start_OutputYaw_Axis1()
                Case "Sway"
                    Start_OutputSway_Axis1()
                Case "Surge"
                    Start_OutputSurge_Axis1()
                Case "Extra1"
                    Start_OutputExtra1_Axis1()
                Case "Extra2"
                    Start_OutputExtra2_Axis1()
                Case "Extra3"
                    Start_OutputExtra3_Axis1()
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF2
                Case "Roll"
                    Start_OutputRoll_Axis1()
                Case "Pitch"
                    Start_OutputPitch_Axis1()
                Case "Heave"
                    Start_OutputHeave_Axis1()
                Case "Yaw"
                    Start_OutputYaw_Axis1()
                Case "Sway"
                    Start_OutputSway_Axis1()
                Case "Surge"
                    Start_OutputSurge_Axis1()
                Case "Extra1"
                    Start_OutputExtra1_Axis1()
                Case "Extra2"
                    Start_OutputExtra2_Axis1()
                Case "Extra3"
                    Start_OutputExtra3_Axis1()
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF3
                Case "Roll"
                    Start_OutputRoll_Axis1()
                Case "Pitch"
                    Start_OutputPitch_Axis1()
                Case "Heave"
                    Start_OutputHeave_Axis1()
                Case "Yaw"
                    Start_OutputYaw_Axis1()
                Case "Sway"
                    Start_OutputSway_Axis1()
                Case "Surge"
                    Start_OutputSurge_Axis1()
                Case "Extra1"
                    Start_OutputExtra1_Axis1()
                Case "Extra2"
                    Start_OutputExtra2_Axis1()
                Case "Extra3"
                    Start_OutputExtra3_Axis1()
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF4
                Case "Roll"
                    Start_OutputRoll_Axis1()
                Case "Pitch"
                    Start_OutputPitch_Axis1()
                Case "Heave"
                    Start_OutputHeave_Axis1()
                Case "Yaw"
                    Start_OutputYaw_Axis1()
                Case "Sway"
                    Start_OutputSway_Axis1()
                Case "Surge"
                    Start_OutputSurge_Axis1()
                Case "Extra1"
                    Start_OutputExtra1_Axis1()
                Case "Extra2"
                    Start_OutputExtra2_Axis1()
                Case "Extra3"
                    Start_OutputExtra3_Axis1()
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF5
                Case "Roll"
                    Start_OutputRoll_Axis1()
                Case "Pitch"
                    Start_OutputPitch_Axis1()
                Case "Heave"
                    Start_OutputHeave_Axis1()
                Case "Yaw"
                    Start_OutputYaw_Axis1()
                Case "Sway"
                    Start_OutputSway_Axis1()
                Case "Surge"
                    Start_OutputSurge_Axis1()
                Case "Extra1"
                    Start_OutputExtra1_Axis1()
                Case "Extra2"
                    Start_OutputExtra2_Axis1()
                Case "Extra3"
                    Start_OutputExtra3_Axis1()
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF6
                Case "Roll"
                    Start_OutputRoll_Axis1()
                Case "Pitch"
                    Start_OutputPitch_Axis1()
                Case "Heave"
                    Start_OutputHeave_Axis1()
                Case "Yaw"
                    Start_OutputYaw_Axis1()
                Case "Sway"
                    Start_OutputSway_Axis1()
                Case "Surge"
                    Start_OutputSurge_Axis1()
                Case "Extra1"
                    Start_OutputExtra1_Axis1()
                Case "Extra2"
                    Start_OutputExtra2_Axis1()
                Case "Extra3"
                    Start_OutputExtra3_Axis1()
            End Select
        End If
        If Axis2_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis2DOF1
                Case "Roll"
                    Start_OutputRoll_Axis2()
                Case "Pitch"
                    Start_OutputPitch_Axis2()
                Case "Heave"
                    Start_OutputHeave_Axis2()
                Case "Yaw"
                    Start_OutputYaw_Axis2()
                Case "Sway"
                    Start_OutputSway_Axis2()
                Case "Surge"
                    Start_OutputSurge_Axis2()
                Case "Extra1"
                    Start_OutputExtra1_Axis2()
                Case "Extra2"
                    Start_OutputExtra2_Axis2()
                Case "Extra3"
                    Start_OutputExtra3_Axis2()
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF2
                Case "Roll"
                    Start_OutputRoll_Axis2()
                Case "Pitch"
                    Start_OutputPitch_Axis2()
                Case "Heave"
                    Start_OutputHeave_Axis2()
                Case "Yaw"
                    Start_OutputYaw_Axis2()
                Case "Sway"
                    Start_OutputSway_Axis2()
                Case "Surge"
                    Start_OutputSurge_Axis2()
                Case "Extra1"
                    Start_OutputExtra1_Axis2()
                Case "Extra2"
                    Start_OutputExtra2_Axis2()
                Case "Extra3"
                    Start_OutputExtra3_Axis2()
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF3
                Case "Roll"
                    Start_OutputRoll_Axis2()
                Case "Pitch"
                    Start_OutputPitch_Axis2()
                Case "Heave"
                    Start_OutputHeave_Axis2()
                Case "Yaw"
                    Start_OutputYaw_Axis2()
                Case "Sway"
                    Start_OutputSway_Axis2()
                Case "Surge"
                    Start_OutputSurge_Axis2()
                Case "Extra1"
                    Start_OutputExtra1_Axis2()
                Case "Extra2"
                    Start_OutputExtra2_Axis2()
                Case "Extra3"
                    Start_OutputExtra3_Axis2()
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF4
                Case "Roll"
                    Start_OutputRoll_Axis2()
                Case "Pitch"
                    Start_OutputPitch_Axis2()
                Case "Heave"
                    Start_OutputHeave_Axis2()
                Case "Yaw"
                    Start_OutputYaw_Axis2()
                Case "Sway"
                    Start_OutputSway_Axis2()
                Case "Surge"
                    Start_OutputSurge_Axis2()
                Case "Extra1"
                    Start_OutputExtra1_Axis2()
                Case "Extra2"
                    Start_OutputExtra2_Axis2()
                Case "Extra3"
                    Start_OutputExtra3_Axis2()
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF5
                Case "Roll"
                    Start_OutputRoll_Axis2()
                Case "Pitch"
                    Start_OutputPitch_Axis2()
                Case "Heave"
                    Start_OutputHeave_Axis2()
                Case "Yaw"
                    Start_OutputYaw_Axis2()
                Case "Sway"
                    Start_OutputSway_Axis2()
                Case "Surge"
                    Start_OutputSurge_Axis2()
                Case "Extra1"
                    Start_OutputExtra1_Axis2()
                Case "Extra2"
                    Start_OutputExtra2_Axis2()
                Case "Extra3"
                    Start_OutputExtra3_Axis2()
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF6
                Case "Roll"
                    Start_OutputRoll_Axis2()
                Case "Pitch"
                    Start_OutputPitch_Axis2()
                Case "Heave"
                    Start_OutputHeave_Axis2()
                Case "Yaw"
                    Start_OutputYaw_Axis2()
                Case "Sway"
                    Start_OutputSway_Axis2()
                Case "Surge"
                    Start_OutputSurge_Axis2()
                Case "Extra1"
                    Start_OutputExtra1_Axis2()
                Case "Extra2"
                    Start_OutputExtra2_Axis2()
                Case "Extra3"
                    Start_OutputExtra3_Axis2()
            End Select
        End If
        If Axis3_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis3DOF1
                Case "Roll"
                    Start_OutputRoll_Axis3()
                Case "Pitch"
                    Start_OutputPitch_Axis3()
                Case "Heave"
                    Start_OutputHeave_Axis3()
                Case "Yaw"
                    Start_OutputYaw_Axis3()
                Case "Sway"
                    Start_OutputSway_Axis3()
                Case "Surge"
                    Start_OutputSurge_Axis3()
                Case "Extra1"
                    Start_OutputExtra1_Axis3()
                Case "Extra2"
                    Start_OutputExtra2_Axis3()
                Case "Extra3"
                    Start_OutputExtra3_Axis3()
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF2
                Case "Roll"
                    Start_OutputRoll_Axis3()
                Case "Pitch"
                    Start_OutputPitch_Axis3()
                Case "Heave"
                    Start_OutputHeave_Axis3()
                Case "Yaw"
                    Start_OutputYaw_Axis3()
                Case "Sway"
                    Start_OutputSway_Axis3()
                Case "Surge"
                    Start_OutputSurge_Axis3()
                Case "Extra1"
                    Start_OutputExtra1_Axis3()
                Case "Extra2"
                    Start_OutputExtra2_Axis3()
                Case "Extra3"
                    Start_OutputExtra3_Axis3()
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF3
                Case "Roll"
                    Start_OutputRoll_Axis3()
                Case "Pitch"
                    Start_OutputPitch_Axis3()
                Case "Heave"
                    Start_OutputHeave_Axis3()
                Case "Yaw"
                    Start_OutputYaw_Axis3()
                Case "Sway"
                    Start_OutputSway_Axis3()
                Case "Surge"
                    Start_OutputSurge_Axis3()
                Case "Extra1"
                    Start_OutputExtra1_Axis3()
                Case "Extra2"
                    Start_OutputExtra2_Axis3()
                Case "Extra3"
                    Start_OutputExtra3_Axis3()
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF4
                Case "Roll"
                    Start_OutputRoll_Axis3()
                Case "Pitch"
                    Start_OutputPitch_Axis3()
                Case "Heave"
                    Start_OutputHeave_Axis3()
                Case "Yaw"
                    Start_OutputYaw_Axis3()
                Case "Sway"
                    Start_OutputSway_Axis3()
                Case "Surge"
                    Start_OutputSurge_Axis3()
                Case "Extra1"
                    Start_OutputExtra1_Axis3()
                Case "Extra2"
                    Start_OutputExtra2_Axis3()
                Case "Extra3"
                    Start_OutputExtra3_Axis3()
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF5
                Case "Roll"
                    Start_OutputRoll_Axis3()
                Case "Pitch"
                    Start_OutputPitch_Axis3()
                Case "Heave"
                    Start_OutputHeave_Axis3()
                Case "Yaw"
                    Start_OutputYaw_Axis3()
                Case "Sway"
                    Start_OutputSway_Axis3()
                Case "Surge"
                    Start_OutputSurge_Axis3()
                Case "Extra1"
                    Start_OutputExtra1_Axis3()
                Case "Extra2"
                    Start_OutputExtra2_Axis3()
                Case "Extra3"
                    Start_OutputExtra3_Axis3()
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF6
                Case "Roll"
                    Start_OutputRoll_Axis3()
                Case "Pitch"
                    Start_OutputPitch_Axis3()
                Case "Heave"
                    Start_OutputHeave_Axis3()
                Case "Yaw"
                    Start_OutputYaw_Axis3()
                Case "Sway"
                    Start_OutputSway_Axis3()
                Case "Surge"
                    Start_OutputSurge_Axis3()
                Case "Extra1"
                    Start_OutputExtra1_Axis3()
                Case "Extra2"
                    Start_OutputExtra2_Axis3()
                Case "Extra3"
                    Start_OutputExtra3_Axis3()
            End Select
        End If
        If Axis4_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis4DOF1
                Case "Roll"
                    Start_OutputRoll_Axis4()
                Case "Pitch"
                    Start_OutputPitch_Axis4()
                Case "Heave"
                    Start_OutputHeave_Axis4()
                Case "Yaw"
                    Start_OutputYaw_Axis4()
                Case "Sway"
                    Start_OutputSway_Axis4()
                Case "Surge"
                    Start_OutputSurge_Axis4()
                Case "Extra1"
                    Start_OutputExtra1_Axis4()
                Case "Extra2"
                    Start_OutputExtra2_Axis4()
                Case "Extra3"
                    Start_OutputExtra3_Axis4()
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF2
                Case "Roll"
                    Start_OutputRoll_Axis4()
                Case "Pitch"
                    Start_OutputPitch_Axis4()
                Case "Heave"
                    Start_OutputHeave_Axis4()
                Case "Yaw"
                    Start_OutputYaw_Axis4()
                Case "Sway"
                    Start_OutputSway_Axis4()
                Case "Surge"
                    Start_OutputSurge_Axis4()
                Case "Extra1"
                    Start_OutputExtra1_Axis4()
                Case "Extra2"
                    Start_OutputExtra2_Axis4()
                Case "Extra3"
                    Start_OutputExtra3_Axis4()
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF3
                Case "Roll"
                    Start_OutputRoll_Axis4()
                Case "Pitch"
                    Start_OutputPitch_Axis4()
                Case "Heave"
                    Start_OutputHeave_Axis4()
                Case "Yaw"
                    Start_OutputYaw_Axis4()
                Case "Sway"
                    Start_OutputSway_Axis4()
                Case "Surge"
                    Start_OutputSurge_Axis4()
                Case "Extra1"
                    Start_OutputExtra1_Axis4()
                Case "Extra2"
                    Start_OutputExtra2_Axis4()
                Case "Extra3"
                    Start_OutputExtra3_Axis4()
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF4
                Case "Roll"
                    Start_OutputRoll_Axis4()
                Case "Pitch"
                    Start_OutputPitch_Axis4()
                Case "Heave"
                    Start_OutputHeave_Axis4()
                Case "Yaw"
                    Start_OutputYaw_Axis4()
                Case "Sway"
                    Start_OutputSway_Axis4()
                Case "Surge"
                    Start_OutputSurge_Axis4()
                Case "Extra1"
                    Start_OutputExtra1_Axis4()
                Case "Extra2"
                    Start_OutputExtra2_Axis4()
                Case "Extra3"
                    Start_OutputExtra3_Axis4()
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF5
                Case "Roll"
                    Start_OutputRoll_Axis4()
                Case "Pitch"
                    Start_OutputPitch_Axis4()
                Case "Heave"
                    Start_OutputHeave_Axis4()
                Case "Yaw"
                    Start_OutputYaw_Axis4()
                Case "Sway"
                    Start_OutputSway_Axis4()
                Case "Surge"
                    Start_OutputSurge_Axis4()
                Case "Extra1"
                    Start_OutputExtra1_Axis4()
                Case "Extra2"
                    Start_OutputExtra2_Axis4()
                Case "Extra3"
                    Start_OutputExtra3_Axis4()
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF6
                Case "Roll"
                    Start_OutputRoll_Axis4()
                Case "Pitch"
                    Start_OutputPitch_Axis4()
                Case "Heave"
                    Start_OutputHeave_Axis4()
                Case "Yaw"
                    Start_OutputYaw_Axis4()
                Case "Sway"
                    Start_OutputSway_Axis4()
                Case "Surge"
                    Start_OutputSurge_Axis4()
                Case "Extra1"
                    Start_OutputExtra1_Axis4()
                Case "Extra2"
                    Start_OutputExtra2_Axis4()
                Case "Extra3"
                    Start_OutputExtra3_Axis4()
            End Select
        End If
        If Axis5_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis5DOF1
                Case "Roll"
                    Start_OutputRoll_Axis5()
                Case "Pitch"
                    Start_OutputPitch_Axis5()
                Case "Heave"
                    Start_OutputHeave_Axis5()
                Case "Yaw"
                    Start_OutputYaw_Axis5()
                Case "Sway"
                    Start_OutputSway_Axis5()
                Case "Surge"
                    Start_OutputSurge_Axis5()
                Case "Extra1"
                    Start_OutputExtra1_Axis5()
                Case "Extra2"
                    Start_OutputExtra2_Axis5()
                Case "Extra3"
                    Start_OutputExtra3_Axis5()
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF2
                Case "Roll"
                    Start_OutputRoll_Axis5()
                Case "Pitch"
                    Start_OutputPitch_Axis5()
                Case "Heave"
                    Start_OutputHeave_Axis5()
                Case "Yaw"
                    Start_OutputYaw_Axis5()
                Case "Sway"
                    Start_OutputSway_Axis5()
                Case "Surge"
                    Start_OutputSurge_Axis5()
                Case "Extra1"
                    Start_OutputExtra1_Axis5()
                Case "Extra2"
                    Start_OutputExtra2_Axis5()
                Case "Extra3"
                    Start_OutputExtra3_Axis5()
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF3
                Case "Roll"
                    Start_OutputRoll_Axis5()
                Case "Pitch"
                    Start_OutputPitch_Axis5()
                Case "Heave"
                    Start_OutputHeave_Axis5()
                Case "Yaw"
                    Start_OutputYaw_Axis5()
                Case "Sway"
                    Start_OutputSway_Axis5()
                Case "Surge"
                    Start_OutputSurge_Axis5()
                Case "Extra1"
                    Start_OutputExtra1_Axis5()
                Case "Extra2"
                    Start_OutputExtra2_Axis5()
                Case "Extra3"
                    Start_OutputExtra3_Axis5()
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF4
                Case "Roll"
                    Start_OutputRoll_Axis5()
                Case "Pitch"
                    Start_OutputPitch_Axis5()
                Case "Heave"
                    Start_OutputHeave_Axis5()
                Case "Yaw"
                    Start_OutputYaw_Axis5()
                Case "Sway"
                    Start_OutputSway_Axis5()
                Case "Surge"
                    Start_OutputSurge_Axis5()
                Case "Extra1"
                    Start_OutputExtra1_Axis5()
                Case "Extra2"
                    Start_OutputExtra2_Axis5()
                Case "Extra3"
                    Start_OutputExtra3_Axis5()
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF5
                Case "Roll"
                    Start_OutputRoll_Axis5()
                Case "Pitch"
                    Start_OutputPitch_Axis5()
                Case "Heave"
                    Start_OutputHeave_Axis5()
                Case "Yaw"
                    Start_OutputYaw_Axis5()
                Case "Sway"
                    Start_OutputSway_Axis5()
                Case "Surge"
                    Start_OutputSurge_Axis5()
                Case "Extra1"
                    Start_OutputExtra1_Axis5()
                Case "Extra2"
                    Start_OutputExtra2_Axis5()
                Case "Extra3"
                    Start_OutputExtra3_Axis5()
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF6
                Case "Roll"
                    Start_OutputRoll_Axis5()
                Case "Pitch"
                    Start_OutputPitch_Axis5()
                Case "Heave"
                    Start_OutputHeave_Axis5()
                Case "Yaw"
                    Start_OutputYaw_Axis5()
                Case "Sway"
                    Start_OutputSway_Axis5()
                Case "Surge"
                    Start_OutputSurge_Axis5()
                Case "Extra1"
                    Start_OutputExtra1_Axis5()
                Case "Extra2"
                    Start_OutputExtra2_Axis5()
                Case "Extra3"
                    Start_OutputExtra3_Axis5()
            End Select
        End If
        If Axis6_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis6DOF1
                Case "Roll"
                    Start_OutputRoll_Axis6()
                Case "Pitch"
                    Start_OutputPitch_Axis6()
                Case "Heave"
                    Start_OutputHeave_Axis6()
                Case "Yaw"
                    Start_OutputYaw_Axis6()
                Case "Sway"
                    Start_OutputSway_Axis6()
                Case "Surge"
                    Start_OutputSurge_Axis6()
                Case "Extra1"
                    Start_OutputExtra1_Axis6()
                Case "Extra2"
                    Start_OutputExtra2_Axis6()
                Case "Extra3"
                    Start_OutputExtra3_Axis6()
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF2
                Case "Roll"
                    Start_OutputRoll_Axis6()
                Case "Pitch"
                    Start_OutputPitch_Axis6()
                Case "Heave"
                    Start_OutputHeave_Axis6()
                Case "Yaw"
                    Start_OutputYaw_Axis6()
                Case "Sway"
                    Start_OutputSway_Axis6()
                Case "Surge"
                    Start_OutputSurge_Axis6()
                Case "Extra1"
                    Start_OutputExtra1_Axis6()
                Case "Extra2"
                    Start_OutputExtra2_Axis6()
                Case "Extra3"
                    Start_OutputExtra3_Axis6()
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF3
                Case "Roll"
                    Start_OutputRoll_Axis6()
                Case "Pitch"
                    Start_OutputPitch_Axis6()
                Case "Heave"
                    Start_OutputHeave_Axis6()
                Case "Yaw"
                    Start_OutputYaw_Axis6()
                Case "Sway"
                    Start_OutputSway_Axis6()
                Case "Surge"
                    Start_OutputSurge_Axis6()
                Case "Extra1"
                    Start_OutputExtra1_Axis6()
                Case "Extra2"
                    Start_OutputExtra2_Axis6()
                Case "Extra3"
                    Start_OutputExtra3_Axis6()
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF4
                Case "Roll"
                    Start_OutputRoll_Axis6()
                Case "Pitch"
                    Start_OutputPitch_Axis6()
                Case "Heave"
                    Start_OutputHeave_Axis6()
                Case "Yaw"
                    Start_OutputYaw_Axis6()
                Case "Sway"
                    Start_OutputSway_Axis6()
                Case "Surge"
                    Start_OutputSurge_Axis6()
                Case "Extra1"
                    Start_OutputExtra1_Axis6()
                Case "Extra2"
                    Start_OutputExtra2_Axis6()
                Case "Extra3"
                    Start_OutputExtra3_Axis6()
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF5
                Case "Roll"
                    Start_OutputRoll_Axis6()
                Case "Pitch"
                    Start_OutputPitch_Axis6()
                Case "Heave"
                    Start_OutputHeave_Axis6()
                Case "Yaw"
                    Start_OutputYaw_Axis6()
                Case "Sway"
                    Start_OutputSway_Axis6()
                Case "Surge"
                    Start_OutputSurge_Axis6()
                Case "Extra1"
                    Start_OutputExtra1_Axis6()
                Case "Extra2"
                    Start_OutputExtra2_Axis6()
                Case "Extra3"
                    Start_OutputExtra3_Axis6()
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF6
                Case "Roll"
                    Start_OutputRoll_Axis6()
                Case "Pitch"
                    Start_OutputPitch_Axis6()
                Case "Heave"
                    Start_OutputHeave_Axis6()
                Case "Yaw"
                    Start_OutputYaw_Axis6()
                Case "Sway"
                    Start_OutputSway_Axis6()
                Case "Surge"
                    Start_OutputSurge_Axis6()
                Case "Extra1"
                    Start_OutputExtra1_Axis6()
                Case "Extra2"
                    Start_OutputExtra2_Axis6()
                Case "Extra3"
                    Start_OutputExtra3_Axis6()
            End Select
        End If

        'Turn the Right Axis Output On
        If Axis1_IsUsed = True Or Axis2_IsUsed = True Or Axis3_IsUsed = True Or Axis4_IsUsed = True Or Axis5_IsUsed = True Or Axis6_IsUsed = True Then
            Output_Calulations_Running = True
        End If
        If Axis1_IsUsed = True Then
            'Axis 1
            Dim trd1 As Thread = New Thread(AddressOf Axis1_Calulations)
            trd1.IsBackground = True
            trd1.Start()
        End If
        If Axis2_IsUsed = True Then
            'Axis 2
            Dim trd2 As Thread = New Thread(AddressOf Axis2_Calulations)
            trd2.IsBackground = True
            trd2.Start()
        End If
        If Axis3_IsUsed = True Then
            'Axis 3
            Dim trd3 As Thread = New Thread(AddressOf Axis3_Calulations)
            trd3.IsBackground = True
            trd3.Start()
        End If
        If Axis4_IsUsed = True Then
            'Axis 4
            Dim trd4 As Thread = New Thread(AddressOf Axis4_Calulations)
            trd4.IsBackground = True
            trd4.Start()
        End If
        If Axis5_IsUsed = True Then
            'Axis 5
            Dim trd5 As Thread = New Thread(AddressOf Axis5_Calulations)
            trd5.IsBackground = True
            trd5.Start()
        End If
        If Axis6_IsUsed = True Then
            'Axis 6
            Dim trd6 As Thread = New Thread(AddressOf Axis6_Calulations)
            trd6.IsBackground = True
            trd6.Start()
        End If
    End Sub

    'Calculate Axes ************************
#Region "Axis Calulations"
#Region "Axis1"
    Private Axis1_Output As Double = 0
    Private Axis1_Value1_Out As Double = 0
    Private Axis1_Value2_Out As Double = 0
    Private Axis1_Value3_Out As Double = 0
    Private Axis1_Value4_Out As Double = 0
    Private Axis1_Value5_Out As Double = 0
    Private Axis1_Value6_Out As Double = 0
    Private Sub Axis1_Calulations()
        Do While Output_Calulations_Running = True
            With Struct_AxisAssignments
                Dim RollPercentUsed As Double = _OutputRoll_Axis1
                Dim PitchPercentUsed As Double = _OutputPitch_Axis1
                Dim HeavePercentUsed As Double = _OutputHeave_Axis1
                Dim YawPercentUsed As Double = _OutputYaw_Axis1
                Dim SwayPercentUsed As Double = _OutputSway_Axis1
                Dim SurgePercentUsed As Double = _OutputSurge_Axis1
                Dim Extra1PercentUsed As Double = _OutputExtra1_Axis1
                Dim Extra2PercentUsed As Double = _OutputExtra2_Axis1
                Dim Extra3PercentUsed As Double = _OutputExtra3_Axis1

                'DOF1
                Select Case ._Axis1DOF1
                    Case "-"
                        Axis1_Value1_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis1_Value1_Out = RollPercentUsed * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis1_Value1_Out = PitchPercentUsed * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis1_Value1_Out = HeavePercentUsed * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis1_Value1_Out = YawPercentUsed * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis1_Value1_Out = SwayPercentUsed * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis1_Value1_Out = SurgePercentUsed * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis1_Value1_Out = Extra1PercentUsed * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis1_Value1_Out = Extra2PercentUsed * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis1_Value1_Out = Extra3PercentUsed * (._Axis1PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR1 = True Then
                            Axis1_Value1_Out = Axis1_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis1DOF2
                    Case "-"
                        Axis1_Value2_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis1_Value2_Out = RollPercentUsed * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis1_Value2_Out = PitchPercentUsed * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis1_Value2_Out = HeavePercentUsed * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis1_Value2_Out = YawPercentUsed * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis1_Value2_Out = SwayPercentUsed * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis1_Value2_Out = SurgePercentUsed * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis1_Value2_Out = Extra1PercentUsed * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis1_Value2_Out = Extra2PercentUsed * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis1_Value2_Out = Extra3PercentUsed * (._Axis1PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR2 = True Then
                            Axis1_Value2_Out = Axis1_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis1DOF3
                    Case "-"
                        Axis1_Value3_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis1_Value3_Out = RollPercentUsed * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis1_Value3_Out = PitchPercentUsed * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis1_Value3_Out = HeavePercentUsed * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis1_Value3_Out = YawPercentUsed * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis1_Value3_Out = SwayPercentUsed * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis1_Value3_Out = SurgePercentUsed * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis1_Value3_Out = Extra1PercentUsed * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis1_Value3_Out = Extra2PercentUsed * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis1_Value3_Out = Extra3PercentUsed * (._Axis1PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR3 = True Then
                            Axis1_Value3_Out = Axis1_Value3_Out * -1
                        End If
                End Select
                'DOF4
                Select Case ._Axis1DOF4
                    Case "-"
                        Axis1_Value4_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis1_Value4_Out = RollPercentUsed * (._Axis1PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR4 = True Then
                            Axis1_Value4_Out = Axis1_Value4_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis1_Value4_Out = PitchPercentUsed * (._Axis1PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR4 = True Then
                            Axis1_Value4_Out = Axis1_Value4_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis1_Value4_Out = HeavePercentUsed * (._Axis1PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR4 = True Then
                            Axis1_Value4_Out = Axis1_Value4_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis1_Value4_Out = YawPercentUsed * (._Axis1PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR4 = True Then
                            Axis1_Value4_Out = Axis1_Value4_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis1_Value4_Out = SwayPercentUsed * (._Axis1PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR4 = True Then
                            Axis1_Value4_Out = Axis1_Value4_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis1_Value4_Out = SurgePercentUsed * (._Axis1PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR4 = True Then
                            Axis1_Value4_Out = Axis1_Value4_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis1_Value4_Out = Extra1PercentUsed * (._Axis1PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR4 = True Then
                            Axis1_Value4_Out = Axis1_Value4_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis1_Value4_Out = Extra2PercentUsed * (._Axis1PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR4 = True Then
                            Axis1_Value4_Out = Axis1_Value4_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis1_Value4_Out = Extra3PercentUsed * (._Axis1PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR4 = True Then
                            Axis1_Value4_Out = Axis1_Value4_Out * -1
                        End If
                End Select
                'DOF5
                Select Case ._Axis1DOF5
                    Case "-"
                        Axis1_Value5_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis1_Value5_Out = RollPercentUsed * (._Axis1PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR5 = True Then
                            Axis1_Value5_Out = Axis1_Value5_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis1_Value5_Out = PitchPercentUsed * (._Axis1PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR5 = True Then
                            Axis1_Value5_Out = Axis1_Value5_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis1_Value5_Out = HeavePercentUsed * (._Axis1PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR5 = True Then
                            Axis1_Value5_Out = Axis1_Value5_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis1_Value5_Out = YawPercentUsed * (._Axis1PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR5 = True Then
                            Axis1_Value5_Out = Axis1_Value5_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis1_Value5_Out = SwayPercentUsed * (._Axis1PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR5 = True Then
                            Axis1_Value5_Out = Axis1_Value5_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis1_Value5_Out = SurgePercentUsed * (._Axis1PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR5 = True Then
                            Axis1_Value5_Out = Axis1_Value5_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis1_Value5_Out = Extra1PercentUsed * (._Axis1PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR5 = True Then
                            Axis1_Value5_Out = Axis1_Value5_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis1_Value5_Out = Extra2PercentUsed * (._Axis1PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR5 = True Then
                            Axis1_Value5_Out = Axis1_Value5_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis1_Value5_Out = Extra3PercentUsed * (._Axis1PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR5 = True Then
                            Axis1_Value5_Out = Axis1_Value5_Out * -1
                        End If
                End Select
                'DOF6
                Select Case ._Axis1DOF6
                    Case "-"
                        Axis1_Value6_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis1_Value6_Out = RollPercentUsed * (._Axis1PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR6 = True Then
                            Axis1_Value6_Out = Axis1_Value6_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis1_Value6_Out = PitchPercentUsed * (._Axis1PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR6 = True Then
                            Axis1_Value6_Out = Axis1_Value6_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis1_Value6_Out = HeavePercentUsed * (._Axis1PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR6 = True Then
                            Axis1_Value6_Out = Axis1_Value6_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis1_Value6_Out = YawPercentUsed * (._Axis1PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR6 = True Then
                            Axis1_Value6_Out = Axis1_Value6_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis1_Value6_Out = SwayPercentUsed * (._Axis1PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR6 = True Then
                            Axis1_Value6_Out = Axis1_Value6_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis1_Value6_Out = SurgePercentUsed * (._Axis1PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR6 = True Then
                            Axis1_Value6_Out = Axis1_Value6_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis1_Value6_Out = Extra1PercentUsed * (._Axis1PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR6 = True Then
                            Axis1_Value6_Out = Axis1_Value6_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis1_Value6_Out = Extra2PercentUsed * (._Axis1PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR6 = True Then
                            Axis1_Value6_Out = Axis1_Value6_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis1_Value6_Out = Extra3PercentUsed * (._Axis1PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis1DIR6 = True Then
                            Axis1_Value6_Out = Axis1_Value6_Out * -1
                        End If
                End Select

                'BUILD Value
                Axis1_Output = Axis1_Value1_Out + Axis1_Value2_Out + Axis1_Value3_Out + Axis1_Value4_Out + Axis1_Value5_Out + Axis1_Value6_Out

                'Stay in the limits
                If Axis1_Output > 1 Then
                    Axis1_Output = 1
                ElseIf Axis1_Output < -1 Then
                    Axis1_Output = -1
                End If

                'Adjust ouput with axis Limiter (Scaler)
                'Axis1_Output = Axis1_Output * (Struct_AxisLimiting._Axis1Limiter * 0.01)

                'fix output for rotational if needed
                'If Struct_AxisType._Axis1_OutputType = "Rotational" Then
                '    Axis1_Output = RotationalOutputFix(Axis1_Output, Struct_AxisType._Axis1_DegreesUsed)
                'End If

                'Set output
                _Axis1Output = Axis1_Output
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis2"
    Private Axis2_Output As Double = 0
    Private Axis2_Value1_Out As Double = 0
    Private Axis2_Value2_Out As Double = 0
    Private Axis2_Value3_Out As Double = 0
    Private Axis2_Value4_Out As Double = 0
    Private Axis2_Value5_Out As Double = 0
    Private Axis2_Value6_Out As Double = 0
    Private Sub Axis2_Calulations()
        Do While Output_Calulations_Running = True
            With Struct_AxisAssignments
                Dim RollPercentUsed As Double = _OutputRoll_Axis2
                Dim PitchPercentUsed As Double = _OutputPitch_Axis2
                Dim HeavePercentUsed As Double = _OutputHeave_Axis2
                Dim YawPercentUsed As Double = _OutputYaw_Axis2
                Dim SwayPercentUsed As Double = _OutputSway_Axis2
                Dim SurgePercentUsed As Double = _OutputSurge_Axis2
                Dim Extra1PercentUsed As Double = _OutputExtra1_Axis2
                Dim Extra2PercentUsed As Double = _OutputExtra2_Axis2
                Dim Extra3PercentUsed As Double = _OutputExtra3_Axis2

                'DOF1
                Select Case ._Axis2DOF1
                    Case "-"
                        Axis2_Value1_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis2_Value1_Out = RollPercentUsed * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis2_Value1_Out = PitchPercentUsed * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis2_Value1_Out = HeavePercentUsed * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis2_Value1_Out = YawPercentUsed * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis2_Value1_Out = SwayPercentUsed * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis2_Value1_Out = SurgePercentUsed * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis2_Value1_Out = Extra1PercentUsed * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis2_Value1_Out = Extra2PercentUsed * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis2_Value1_Out = Extra3PercentUsed * (._Axis2PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR1 = True Then
                            Axis2_Value1_Out = Axis2_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis2DOF2
                    Case "-"
                        Axis2_Value2_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis2_Value2_Out = RollPercentUsed * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis2_Value2_Out = PitchPercentUsed * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis2_Value2_Out = HeavePercentUsed * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis2_Value2_Out = YawPercentUsed * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis2_Value2_Out = SwayPercentUsed * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis2_Value2_Out = SurgePercentUsed * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis2_Value2_Out = Extra1PercentUsed * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis2_Value2_Out = Extra2PercentUsed * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis2_Value2_Out = Extra3PercentUsed * (._Axis2PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR2 = True Then
                            Axis2_Value2_Out = Axis2_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis2DOF3
                    Case "-"
                        Axis2_Value3_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis2_Value3_Out = RollPercentUsed * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis2_Value3_Out = PitchPercentUsed * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis2_Value3_Out = HeavePercentUsed * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis2_Value3_Out = YawPercentUsed * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis2_Value3_Out = SwayPercentUsed * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis2_Value3_Out = SurgePercentUsed * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis2_Value3_Out = Extra1PercentUsed * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis2_Value3_Out = Extra2PercentUsed * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis2_Value3_Out = Extra3PercentUsed * (._Axis2PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR3 = True Then
                            Axis2_Value3_Out = Axis2_Value3_Out * -1
                        End If
                End Select
                'DOF4
                Select Case ._Axis2DOF4
                    Case "-"
                        Axis2_Value4_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis2_Value4_Out = RollPercentUsed * (._Axis2PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR4 = True Then
                            Axis2_Value4_Out = Axis2_Value4_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis2_Value4_Out = PitchPercentUsed * (._Axis2PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR4 = True Then
                            Axis2_Value4_Out = Axis2_Value4_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis2_Value4_Out = HeavePercentUsed * (._Axis2PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR4 = True Then
                            Axis2_Value4_Out = Axis2_Value4_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis2_Value4_Out = YawPercentUsed * (._Axis2PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR4 = True Then
                            Axis2_Value4_Out = Axis2_Value4_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis2_Value4_Out = SwayPercentUsed * (._Axis2PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR4 = True Then
                            Axis2_Value4_Out = Axis2_Value4_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis2_Value4_Out = SurgePercentUsed * (._Axis2PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR4 = True Then
                            Axis2_Value4_Out = Axis2_Value4_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis2_Value4_Out = Extra1PercentUsed * (._Axis2PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR4 = True Then
                            Axis2_Value4_Out = Axis2_Value4_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis2_Value4_Out = Extra2PercentUsed * (._Axis2PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR4 = True Then
                            Axis2_Value4_Out = Axis2_Value4_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis2_Value4_Out = Extra3PercentUsed * (._Axis2PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR4 = True Then
                            Axis2_Value4_Out = Axis2_Value4_Out * -1
                        End If
                End Select
                'DOF5
                Select Case ._Axis2DOF5
                    Case "-"
                        Axis2_Value5_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis2_Value5_Out = RollPercentUsed * (._Axis2PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR5 = True Then
                            Axis2_Value5_Out = Axis2_Value5_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis2_Value5_Out = PitchPercentUsed * (._Axis2PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR5 = True Then
                            Axis2_Value5_Out = Axis2_Value5_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis2_Value5_Out = HeavePercentUsed * (._Axis2PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR5 = True Then
                            Axis2_Value5_Out = Axis2_Value5_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis2_Value5_Out = YawPercentUsed * (._Axis2PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR5 = True Then
                            Axis2_Value5_Out = Axis2_Value5_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis2_Value5_Out = SwayPercentUsed * (._Axis2PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR5 = True Then
                            Axis2_Value5_Out = Axis2_Value5_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis2_Value5_Out = SurgePercentUsed * (._Axis2PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR5 = True Then
                            Axis2_Value5_Out = Axis2_Value5_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis2_Value5_Out = Extra1PercentUsed * (._Axis2PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR5 = True Then
                            Axis2_Value5_Out = Axis2_Value5_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis2_Value5_Out = Extra2PercentUsed * (._Axis2PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR5 = True Then
                            Axis2_Value5_Out = Axis2_Value5_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis2_Value5_Out = Extra3PercentUsed * (._Axis2PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR5 = True Then
                            Axis2_Value5_Out = Axis2_Value5_Out * -1
                        End If
                End Select
                'DOF6
                Select Case ._Axis2DOF6
                    Case "-"
                        Axis2_Value6_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis2_Value6_Out = RollPercentUsed * (._Axis2PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR6 = True Then
                            Axis2_Value6_Out = Axis2_Value6_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis2_Value6_Out = PitchPercentUsed * (._Axis2PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR6 = True Then
                            Axis2_Value6_Out = Axis2_Value6_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis2_Value6_Out = HeavePercentUsed * (._Axis2PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR6 = True Then
                            Axis2_Value6_Out = Axis2_Value6_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis2_Value6_Out = YawPercentUsed * (._Axis2PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR6 = True Then
                            Axis2_Value6_Out = Axis2_Value6_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis2_Value6_Out = SwayPercentUsed * (._Axis2PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR6 = True Then
                            Axis2_Value6_Out = Axis2_Value6_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis2_Value6_Out = SurgePercentUsed * (._Axis2PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR6 = True Then
                            Axis2_Value6_Out = Axis2_Value6_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis2_Value6_Out = Extra1PercentUsed * (._Axis2PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR6 = True Then
                            Axis2_Value6_Out = Axis2_Value6_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis2_Value6_Out = Extra2PercentUsed * (._Axis2PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR6 = True Then
                            Axis2_Value6_Out = Axis2_Value6_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis2_Value6_Out = Extra3PercentUsed * (._Axis2PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis2DIR6 = True Then
                            Axis2_Value6_Out = Axis2_Value6_Out * -1
                        End If
                End Select

                'BUILD Value
                Axis2_Output = Axis2_Value1_Out + Axis2_Value2_Out + Axis2_Value3_Out + Axis2_Value4_Out + Axis2_Value5_Out + Axis2_Value6_Out

                'Stay in the limits
                If Axis2_Output > 1 Then
                    Axis2_Output = 1
                ElseIf Axis2_Output < -1 Then
                    Axis2_Output = -1
                End If

                ''Adjust ouput with axis Limiter (Scaler)
                'Axis2_Output = Axis2_Output * (Struct_AxisLimiting._Axis2Limiter * 0.01)

                ''fix output for rotational if needed
                'If Struct_AxisType._Axis2_OutputType = "Rotational" Then
                '    Axis2_Output = RotationalOutputFix(Axis2_Output, Struct_AxisType._Axis2_DegreesUsed)
                'End If

                'Set output
                _Axis2Output = Axis2_Output
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis3"
    Private Axis3_Output As Double = 0
    Private Axis3_Value1_Out As Double = 0
    Private Axis3_Value2_Out As Double = 0
    Private Axis3_Value3_Out As Double = 0
    Private Axis3_Value4_Out As Double = 0
    Private Axis3_Value5_Out As Double = 0
    Private Axis3_Value6_Out As Double = 0
    Private Sub Axis3_Calulations()
        Do While Output_Calulations_Running = True
            With Struct_AxisAssignments
                Dim RollPercentUsed As Double = _OutputRoll_Axis3
                Dim PitchPercentUsed As Double = _OutputPitch_Axis3
                Dim HeavePercentUsed As Double = _OutputHeave_Axis3
                Dim YawPercentUsed As Double = _OutputYaw_Axis3
                Dim SwayPercentUsed As Double = _OutputSway_Axis3
                Dim SurgePercentUsed As Double = _OutputSurge_Axis3
                Dim Extra1PercentUsed As Double = _OutputExtra1_Axis3
                Dim Extra2PercentUsed As Double = _OutputExtra2_Axis3
                Dim Extra3PercentUsed As Double = _OutputExtra3_Axis3

                'DOF1
                Select Case ._Axis3DOF1
                    Case "-"
                        Axis3_Value1_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis3_Value1_Out = RollPercentUsed * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis3_Value1_Out = PitchPercentUsed * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis3_Value1_Out = HeavePercentUsed * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis3_Value1_Out = YawPercentUsed * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis3_Value1_Out = SwayPercentUsed * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis3_Value1_Out = SurgePercentUsed * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis3_Value1_Out = Extra1PercentUsed * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis3_Value1_Out = Extra2PercentUsed * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis3_Value1_Out = Extra3PercentUsed * (._Axis3PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR1 = True Then
                            Axis3_Value1_Out = Axis3_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis3DOF2
                    Case "-"
                        Axis3_Value2_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis3_Value2_Out = RollPercentUsed * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis3_Value2_Out = PitchPercentUsed * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis3_Value2_Out = HeavePercentUsed * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis3_Value2_Out = YawPercentUsed * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis3_Value2_Out = SwayPercentUsed * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis3_Value2_Out = SurgePercentUsed * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis3_Value2_Out = Extra1PercentUsed * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis3_Value2_Out = Extra2PercentUsed * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis3_Value2_Out = Extra3PercentUsed * (._Axis3PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR2 = True Then
                            Axis3_Value2_Out = Axis3_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis3DOF3
                    Case "-"
                        Axis3_Value3_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis3_Value3_Out = RollPercentUsed * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis3_Value3_Out = PitchPercentUsed * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis3_Value3_Out = HeavePercentUsed * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis3_Value3_Out = YawPercentUsed * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis3_Value3_Out = SwayPercentUsed * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis3_Value3_Out = SurgePercentUsed * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis3_Value3_Out = Extra1PercentUsed * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis3_Value3_Out = Extra2PercentUsed * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis3_Value3_Out = Extra3PercentUsed * (._Axis3PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR3 = True Then
                            Axis3_Value3_Out = Axis3_Value3_Out * -1
                        End If
                End Select
                'DOF4
                Select Case ._Axis3DOF4
                    Case "-"
                        Axis3_Value4_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis3_Value4_Out = RollPercentUsed * (._Axis3PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR4 = True Then
                            Axis3_Value4_Out = Axis3_Value4_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis3_Value4_Out = PitchPercentUsed * (._Axis3PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR4 = True Then
                            Axis3_Value4_Out = Axis3_Value4_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis3_Value4_Out = HeavePercentUsed * (._Axis3PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR4 = True Then
                            Axis3_Value4_Out = Axis3_Value4_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis3_Value4_Out = YawPercentUsed * (._Axis3PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR4 = True Then
                            Axis3_Value4_Out = Axis3_Value4_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis3_Value4_Out = SwayPercentUsed * (._Axis3PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR4 = True Then
                            Axis3_Value4_Out = Axis3_Value4_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis3_Value4_Out = SurgePercentUsed * (._Axis3PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR4 = True Then
                            Axis3_Value4_Out = Axis3_Value4_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis3_Value4_Out = Extra1PercentUsed * (._Axis3PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR4 = True Then
                            Axis3_Value4_Out = Axis3_Value4_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis3_Value4_Out = Extra2PercentUsed * (._Axis3PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR4 = True Then
                            Axis3_Value4_Out = Axis3_Value4_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis3_Value4_Out = Extra3PercentUsed * (._Axis3PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR4 = True Then
                            Axis3_Value4_Out = Axis3_Value4_Out * -1
                        End If
                End Select
                'DOF5
                Select Case ._Axis3DOF5
                    Case "-"
                        Axis3_Value5_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis3_Value5_Out = RollPercentUsed * (._Axis3PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR5 = True Then
                            Axis3_Value5_Out = Axis3_Value5_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis3_Value5_Out = PitchPercentUsed * (._Axis3PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR5 = True Then
                            Axis3_Value5_Out = Axis3_Value5_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis3_Value5_Out = HeavePercentUsed * (._Axis3PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR5 = True Then
                            Axis3_Value5_Out = Axis3_Value5_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis3_Value5_Out = YawPercentUsed * (._Axis3PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR5 = True Then
                            Axis3_Value5_Out = Axis3_Value5_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis3_Value5_Out = SwayPercentUsed * (._Axis3PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR5 = True Then
                            Axis3_Value5_Out = Axis3_Value5_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis3_Value5_Out = SurgePercentUsed * (._Axis3PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR5 = True Then
                            Axis3_Value5_Out = Axis3_Value5_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis3_Value5_Out = Extra1PercentUsed * (._Axis3PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR5 = True Then
                            Axis3_Value5_Out = Axis3_Value5_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis3_Value5_Out = Extra2PercentUsed * (._Axis3PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR5 = True Then
                            Axis3_Value5_Out = Axis3_Value5_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis3_Value5_Out = Extra3PercentUsed * (._Axis3PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR5 = True Then
                            Axis3_Value5_Out = Axis3_Value5_Out * -1
                        End If
                End Select
                'DOF6
                Select Case ._Axis3DOF6
                    Case "-"
                        Axis3_Value6_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis3_Value6_Out = RollPercentUsed * (._Axis3PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR6 = True Then
                            Axis3_Value6_Out = Axis3_Value6_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis3_Value6_Out = PitchPercentUsed * (._Axis3PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR6 = True Then
                            Axis3_Value6_Out = Axis3_Value6_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis3_Value6_Out = HeavePercentUsed * (._Axis3PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR6 = True Then
                            Axis3_Value6_Out = Axis3_Value6_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis3_Value6_Out = YawPercentUsed * (._Axis3PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR6 = True Then
                            Axis3_Value6_Out = Axis3_Value6_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis3_Value6_Out = SwayPercentUsed * (._Axis3PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR6 = True Then
                            Axis3_Value6_Out = Axis3_Value6_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis3_Value6_Out = SurgePercentUsed * (._Axis3PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR6 = True Then
                            Axis3_Value6_Out = Axis3_Value6_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis3_Value6_Out = Extra1PercentUsed * (._Axis3PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR6 = True Then
                            Axis3_Value6_Out = Axis3_Value6_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis3_Value6_Out = Extra2PercentUsed * (._Axis3PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR6 = True Then
                            Axis3_Value6_Out = Axis3_Value6_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis3_Value6_Out = Extra3PercentUsed * (._Axis3PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis3DIR6 = True Then
                            Axis3_Value6_Out = Axis3_Value6_Out * -1
                        End If
                End Select

                'BUILD Value
                Axis3_Output = Axis3_Value1_Out + Axis3_Value2_Out + Axis3_Value3_Out + Axis3_Value4_Out + Axis3_Value5_Out + Axis3_Value6_Out

                'Stay in the limits
                If Axis3_Output > 1 Then
                    Axis3_Output = 1
                ElseIf Axis3_Output < -1 Then
                    Axis3_Output = -1
                End If

                ''Adjust ouput with axis Limiter (Scaler)
                'Axis3_Output = Axis3_Output * (Struct_AxisLimiting._Axis3Limiter * 0.01)

                ''fix output for rotational if needed
                'If Struct_AxisType._Axis3_OutputType = "Rotational" Then
                '    Axis3_Output = RotationalOutputFix(Axis3_Output, Struct_AxisType._Axis3_DegreesUsed)
                'End If

                'Set output
                _Axis3Output = Axis3_Output
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis4"
    Private Axis4_Output As Double = 0
    Private Axis4_Value1_Out As Double = 0
    Private Axis4_Value2_Out As Double = 0
    Private Axis4_Value3_Out As Double = 0
    Private Axis4_Value4_Out As Double = 0
    Private Axis4_Value5_Out As Double = 0
    Private Axis4_Value6_Out As Double = 0
    Private Sub Axis4_Calulations()
        Do While Output_Calulations_Running = True
            With Struct_AxisAssignments
                Dim RollPercentUsed As Double = _OutputRoll_Axis4
                Dim PitchPercentUsed As Double = _OutputPitch_Axis4
                Dim HeavePercentUsed As Double = _OutputHeave_Axis4
                Dim YawPercentUsed As Double = _OutputYaw_Axis4
                Dim SwayPercentUsed As Double = _OutputSway_Axis4
                Dim SurgePercentUsed As Double = _OutputSurge_Axis4
                Dim Extra1PercentUsed As Double = _OutputExtra1_Axis4
                Dim Extra2PercentUsed As Double = _OutputExtra2_Axis4
                Dim Extra3PercentUsed As Double = _OutputExtra3_Axis4

                'DOF1
                Select Case ._Axis4DOF1
                    Case "-"
                        Axis4_Value1_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis4_Value1_Out = RollPercentUsed * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis4_Value1_Out = PitchPercentUsed * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis4_Value1_Out = HeavePercentUsed * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis4_Value1_Out = YawPercentUsed * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis4_Value1_Out = SwayPercentUsed * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis4_Value1_Out = SurgePercentUsed * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis4_Value1_Out = Extra1PercentUsed * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis4_Value1_Out = Extra2PercentUsed * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis4_Value1_Out = Extra3PercentUsed * (._Axis4PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR1 = True Then
                            Axis4_Value1_Out = Axis4_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis4DOF2
                    Case "-"
                        Axis4_Value2_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis4_Value2_Out = RollPercentUsed * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis4_Value2_Out = PitchPercentUsed * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis4_Value2_Out = HeavePercentUsed * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis4_Value2_Out = YawPercentUsed * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis4_Value2_Out = SwayPercentUsed * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis4_Value2_Out = SurgePercentUsed * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis4_Value2_Out = Extra1PercentUsed * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis4_Value2_Out = Extra2PercentUsed * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis4_Value2_Out = Extra3PercentUsed * (._Axis4PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR2 = True Then
                            Axis4_Value2_Out = Axis4_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis4DOF3
                    Case "-"
                        Axis4_Value3_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis4_Value3_Out = RollPercentUsed * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis4_Value3_Out = PitchPercentUsed * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis4_Value3_Out = HeavePercentUsed * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis4_Value3_Out = YawPercentUsed * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis4_Value3_Out = SwayPercentUsed * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis4_Value3_Out = SurgePercentUsed * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis4_Value3_Out = Extra1PercentUsed * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis4_Value3_Out = Extra2PercentUsed * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis4_Value3_Out = Extra3PercentUsed * (._Axis4PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR3 = True Then
                            Axis4_Value3_Out = Axis4_Value3_Out * -1
                        End If
                End Select
                'DOF4
                Select Case ._Axis4DOF4
                    Case "-"
                        Axis4_Value4_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis4_Value4_Out = RollPercentUsed * (._Axis4PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR4 = True Then
                            Axis4_Value4_Out = Axis4_Value4_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis4_Value4_Out = PitchPercentUsed * (._Axis4PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR4 = True Then
                            Axis4_Value4_Out = Axis4_Value4_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis4_Value4_Out = HeavePercentUsed * (._Axis4PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR4 = True Then
                            Axis4_Value4_Out = Axis4_Value4_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis4_Value4_Out = YawPercentUsed * (._Axis4PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR4 = True Then
                            Axis4_Value4_Out = Axis4_Value4_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis4_Value4_Out = SwayPercentUsed * (._Axis4PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR4 = True Then
                            Axis4_Value4_Out = Axis4_Value4_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis4_Value4_Out = SurgePercentUsed * (._Axis4PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR4 = True Then
                            Axis4_Value4_Out = Axis4_Value4_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis4_Value4_Out = Extra1PercentUsed * (._Axis4PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR4 = True Then
                            Axis4_Value4_Out = Axis4_Value4_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis4_Value4_Out = Extra2PercentUsed * (._Axis4PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR4 = True Then
                            Axis4_Value4_Out = Axis4_Value4_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis4_Value4_Out = Extra3PercentUsed * (._Axis4PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR4 = True Then
                            Axis4_Value4_Out = Axis4_Value4_Out * -1
                        End If
                End Select
                'DOF5
                Select Case ._Axis4DOF5
                    Case "-"
                        Axis4_Value5_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis4_Value5_Out = RollPercentUsed * (._Axis4PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR5 = True Then
                            Axis4_Value5_Out = Axis4_Value5_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis4_Value5_Out = PitchPercentUsed * (._Axis4PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR5 = True Then
                            Axis4_Value5_Out = Axis4_Value5_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis4_Value5_Out = HeavePercentUsed * (._Axis4PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR5 = True Then
                            Axis4_Value5_Out = Axis4_Value5_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis4_Value5_Out = YawPercentUsed * (._Axis4PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR5 = True Then
                            Axis4_Value5_Out = Axis4_Value5_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis4_Value5_Out = SwayPercentUsed * (._Axis4PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR5 = True Then
                            Axis4_Value5_Out = Axis4_Value5_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis4_Value5_Out = SurgePercentUsed * (._Axis4PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR5 = True Then
                            Axis4_Value5_Out = Axis4_Value5_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis4_Value5_Out = Extra1PercentUsed * (._Axis4PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR5 = True Then
                            Axis4_Value5_Out = Axis4_Value5_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis4_Value5_Out = Extra2PercentUsed * (._Axis4PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR5 = True Then
                            Axis4_Value5_Out = Axis4_Value5_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis4_Value5_Out = Extra3PercentUsed * (._Axis4PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR5 = True Then
                            Axis4_Value5_Out = Axis4_Value5_Out * -1
                        End If
                End Select
                'DOF6
                Select Case ._Axis4DOF6
                    Case "-"
                        Axis4_Value6_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis4_Value6_Out = RollPercentUsed * (._Axis4PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR6 = True Then
                            Axis4_Value6_Out = Axis4_Value6_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis4_Value6_Out = PitchPercentUsed * (._Axis4PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR6 = True Then
                            Axis4_Value6_Out = Axis4_Value6_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis4_Value6_Out = HeavePercentUsed * (._Axis4PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR6 = True Then
                            Axis4_Value6_Out = Axis4_Value6_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis4_Value6_Out = YawPercentUsed * (._Axis4PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR6 = True Then
                            Axis4_Value6_Out = Axis4_Value6_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis4_Value6_Out = SwayPercentUsed * (._Axis4PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR6 = True Then
                            Axis4_Value6_Out = Axis4_Value6_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis4_Value6_Out = SurgePercentUsed * (._Axis4PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR6 = True Then
                            Axis4_Value6_Out = Axis4_Value6_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis4_Value6_Out = Extra1PercentUsed * (._Axis4PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR6 = True Then
                            Axis4_Value6_Out = Axis4_Value6_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis4_Value6_Out = Extra2PercentUsed * (._Axis4PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR6 = True Then
                            Axis4_Value6_Out = Axis4_Value6_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis4_Value6_Out = Extra3PercentUsed * (._Axis4PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis4DIR6 = True Then
                            Axis4_Value6_Out = Axis4_Value6_Out * -1
                        End If
                End Select

                'BUILD Value
                Axis4_Output = Axis4_Value1_Out + Axis4_Value2_Out + Axis4_Value3_Out + Axis4_Value4_Out + Axis4_Value5_Out + Axis4_Value6_Out

                'Stay in the limits
                If Axis4_Output > 1 Then
                    Axis4_Output = 1
                ElseIf Axis4_Output < -1 Then
                    Axis4_Output = -1
                End If

                ''Adjust ouput with axis Limiter (Scaler)
                'Axis4_Output = Axis4_Output * (Struct_AxisLimiting._Axis4Limiter * 0.01)

                ''fix output for rotational if needed
                'If Struct_AxisType._Axis4_OutputType = "Rotational" Then
                '    Axis4_Output = RotationalOutputFix(Axis4_Output, Struct_AxisType._Axis4_DegreesUsed)
                'End If

                'Set output
                _Axis4Output = Axis4_Output
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis5"
    Private Axis5_Output As Double = 0
    Private Axis5_Value1_Out As Double = 0
    Private Axis5_Value2_Out As Double = 0
    Private Axis5_Value3_Out As Double = 0
    Private Axis5_Value4_Out As Double = 0
    Private Axis5_Value5_Out As Double = 0
    Private Axis5_Value6_Out As Double = 0
    Private Sub Axis5_Calulations()
        Do While Output_Calulations_Running = True
            With Struct_AxisAssignments
                Dim RollPercentUsed As Double = _OutputRoll_Axis5
                Dim PitchPercentUsed As Double = _OutputPitch_Axis5
                Dim HeavePercentUsed As Double = _OutputHeave_Axis5
                Dim YawPercentUsed As Double = _OutputYaw_Axis5
                Dim SwayPercentUsed As Double = _OutputSway_Axis5
                Dim SurgePercentUsed As Double = _OutputSurge_Axis5
                Dim Extra1PercentUsed As Double = _OutputExtra1_Axis5
                Dim Extra2PercentUsed As Double = _OutputExtra2_Axis5
                Dim Extra3PercentUsed As Double = _OutputExtra3_Axis5

                'DOF1
                Select Case ._Axis5DOF1
                    Case "-"
                        Axis5_Value1_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis5_Value1_Out = RollPercentUsed * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis5_Value1_Out = PitchPercentUsed * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis5_Value1_Out = HeavePercentUsed * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis5_Value1_Out = YawPercentUsed * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis5_Value1_Out = SwayPercentUsed * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis5_Value1_Out = SurgePercentUsed * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis5_Value1_Out = Extra1PercentUsed * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis5_Value1_Out = Extra2PercentUsed * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis5_Value1_Out = Extra3PercentUsed * (._Axis5PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR1 = True Then
                            Axis5_Value1_Out = Axis5_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis5DOF2
                    Case "-"
                        Axis5_Value2_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis5_Value2_Out = RollPercentUsed * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis5_Value2_Out = PitchPercentUsed * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis5_Value2_Out = HeavePercentUsed * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis5_Value2_Out = YawPercentUsed * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis5_Value2_Out = SwayPercentUsed * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis5_Value2_Out = SurgePercentUsed * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis5_Value2_Out = Extra1PercentUsed * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis5_Value2_Out = Extra2PercentUsed * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis5_Value2_Out = Extra3PercentUsed * (._Axis5PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR2 = True Then
                            Axis5_Value2_Out = Axis5_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis5DOF3
                    Case "-"
                        Axis5_Value3_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis5_Value3_Out = RollPercentUsed * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis5_Value3_Out = PitchPercentUsed * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis5_Value3_Out = HeavePercentUsed * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis5_Value3_Out = YawPercentUsed * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis5_Value3_Out = SwayPercentUsed * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis5_Value3_Out = SurgePercentUsed * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis5_Value3_Out = Extra1PercentUsed * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis5_Value3_Out = Extra2PercentUsed * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis5_Value3_Out = Extra3PercentUsed * (._Axis5PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR3 = True Then
                            Axis5_Value3_Out = Axis5_Value3_Out * -1
                        End If
                End Select
                'DOF4
                Select Case ._Axis5DOF4
                    Case "-"
                        Axis5_Value4_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis5_Value4_Out = RollPercentUsed * (._Axis5PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR4 = True Then
                            Axis5_Value4_Out = Axis5_Value4_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis5_Value4_Out = PitchPercentUsed * (._Axis5PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR4 = True Then
                            Axis5_Value4_Out = Axis5_Value4_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis5_Value4_Out = HeavePercentUsed * (._Axis5PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR4 = True Then
                            Axis5_Value4_Out = Axis5_Value4_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis5_Value4_Out = YawPercentUsed * (._Axis5PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR4 = True Then
                            Axis5_Value4_Out = Axis5_Value4_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis5_Value4_Out = SwayPercentUsed * (._Axis5PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR4 = True Then
                            Axis5_Value4_Out = Axis5_Value4_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis5_Value4_Out = SurgePercentUsed * (._Axis5PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR4 = True Then
                            Axis5_Value4_Out = Axis5_Value4_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis5_Value4_Out = Extra1PercentUsed * (._Axis5PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR4 = True Then
                            Axis5_Value4_Out = Axis5_Value4_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis5_Value4_Out = Extra2PercentUsed * (._Axis5PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR4 = True Then
                            Axis5_Value4_Out = Axis5_Value4_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis5_Value4_Out = Extra3PercentUsed * (._Axis5PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR4 = True Then
                            Axis5_Value4_Out = Axis5_Value4_Out * -1
                        End If
                End Select
                'DOF5
                Select Case ._Axis5DOF5
                    Case "-"
                        Axis5_Value5_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis5_Value5_Out = RollPercentUsed * (._Axis5PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR5 = True Then
                            Axis5_Value5_Out = Axis5_Value5_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis5_Value5_Out = PitchPercentUsed * (._Axis5PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR5 = True Then
                            Axis5_Value5_Out = Axis5_Value5_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis5_Value5_Out = HeavePercentUsed * (._Axis5PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR5 = True Then
                            Axis5_Value5_Out = Axis5_Value5_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis5_Value5_Out = YawPercentUsed * (._Axis5PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR5 = True Then
                            Axis5_Value5_Out = Axis5_Value5_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis5_Value5_Out = SwayPercentUsed * (._Axis5PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR5 = True Then
                            Axis5_Value5_Out = Axis5_Value5_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis5_Value5_Out = SurgePercentUsed * (._Axis5PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR5 = True Then
                            Axis5_Value5_Out = Axis5_Value5_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis5_Value5_Out = Extra1PercentUsed * (._Axis5PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR5 = True Then
                            Axis5_Value5_Out = Axis5_Value5_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis5_Value5_Out = Extra2PercentUsed * (._Axis5PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR5 = True Then
                            Axis5_Value5_Out = Axis5_Value5_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis5_Value5_Out = Extra3PercentUsed * (._Axis5PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR5 = True Then
                            Axis5_Value5_Out = Axis5_Value5_Out * -1
                        End If
                End Select
                'DOF6
                Select Case ._Axis5DOF6
                    Case "-"
                        Axis5_Value6_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis5_Value6_Out = RollPercentUsed * (._Axis5PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR6 = True Then
                            Axis5_Value6_Out = Axis5_Value6_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis5_Value6_Out = PitchPercentUsed * (._Axis5PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR6 = True Then
                            Axis5_Value6_Out = Axis5_Value6_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis5_Value6_Out = HeavePercentUsed * (._Axis5PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR6 = True Then
                            Axis5_Value6_Out = Axis5_Value6_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis5_Value6_Out = YawPercentUsed * (._Axis5PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR6 = True Then
                            Axis5_Value6_Out = Axis5_Value6_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis5_Value6_Out = SwayPercentUsed * (._Axis5PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR6 = True Then
                            Axis5_Value6_Out = Axis5_Value6_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis5_Value6_Out = SurgePercentUsed * (._Axis5PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR6 = True Then
                            Axis5_Value6_Out = Axis5_Value6_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis5_Value6_Out = Extra1PercentUsed * (._Axis5PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR6 = True Then
                            Axis5_Value6_Out = Axis5_Value6_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis5_Value6_Out = Extra2PercentUsed * (._Axis5PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR6 = True Then
                            Axis5_Value6_Out = Axis5_Value6_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis5_Value6_Out = Extra3PercentUsed * (._Axis5PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis5DIR6 = True Then
                            Axis5_Value6_Out = Axis5_Value6_Out * -1
                        End If
                End Select

                'BUILD Value
                Axis5_Output = Axis5_Value1_Out + Axis5_Value2_Out + Axis5_Value3_Out + Axis5_Value4_Out + Axis5_Value5_Out + Axis5_Value6_Out

                'Stay in the limits
                If Axis5_Output > 1 Then
                    Axis5_Output = 1
                ElseIf Axis5_Output < -1 Then
                    Axis5_Output = -1
                End If

                ''Adjust ouput with axis Limiter (Scaler)
                'Axis5_Output = Axis5_Output * (Struct_AxisLimiting._Axis5Limiter * 0.01)

                ''fix output for rotational if needed
                'If Struct_AxisType._Axis5_OutputType = "Rotational" Then
                '    Axis5_Output = RotationalOutputFix(Axis5_Output, Struct_AxisType._Axis5_DegreesUsed)
                'End If

                'Set output
                _Axis5Output = Axis5_Output
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region

#Region "Axis6"
    Private Axis6_Output As Double = 0
    Private Axis6_Value1_Out As Double = 0
    Private Axis6_Value2_Out As Double = 0
    Private Axis6_Value3_Out As Double = 0
    Private Axis6_Value4_Out As Double = 0
    Private Axis6_Value5_Out As Double = 0
    Private Axis6_Value6_Out As Double = 0
    Private Sub Axis6_Calulations()
        Do While Output_Calulations_Running = True
            With Struct_AxisAssignments
                Dim RollPercentUsed As Double = _OutputRoll_Axis6
                Dim PitchPercentUsed As Double = _OutputPitch_Axis6
                Dim HeavePercentUsed As Double = _OutputHeave_Axis6
                Dim YawPercentUsed As Double = _OutputYaw_Axis6
                Dim SwayPercentUsed As Double = _OutputSway_Axis6
                Dim SurgePercentUsed As Double = _OutputSurge_Axis6
                Dim Extra1PercentUsed As Double = _OutputExtra1_Axis6
                Dim Extra2PercentUsed As Double = _OutputExtra2_Axis6
                Dim Extra3PercentUsed As Double = _OutputExtra3_Axis6

                'DOF1
                Select Case ._Axis6DOF1
                    Case "-"
                        Axis6_Value1_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis6_Value1_Out = RollPercentUsed * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis6_Value1_Out = PitchPercentUsed * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis6_Value1_Out = HeavePercentUsed * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis6_Value1_Out = YawPercentUsed * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis6_Value1_Out = SwayPercentUsed * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis6_Value1_Out = SurgePercentUsed * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis6_Value1_Out = Extra1PercentUsed * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis6_Value1_Out = Extra2PercentUsed * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis6_Value1_Out = Extra3PercentUsed * (._Axis6PER1 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR1 = True Then
                            Axis6_Value1_Out = Axis6_Value1_Out * -1
                        End If
                End Select
                'DOF2
                Select Case ._Axis6DOF2
                    Case "-"
                        Axis6_Value2_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis6_Value2_Out = RollPercentUsed * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis6_Value2_Out = PitchPercentUsed * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis6_Value2_Out = HeavePercentUsed * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis6_Value2_Out = YawPercentUsed * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis6_Value2_Out = SwayPercentUsed * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis6_Value2_Out = SurgePercentUsed * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis6_Value2_Out = Extra1PercentUsed * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis6_Value2_Out = Extra2PercentUsed * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis6_Value2_Out = Extra3PercentUsed * (._Axis6PER2 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR2 = True Then
                            Axis6_Value2_Out = Axis6_Value2_Out * -1
                        End If
                End Select
                'DOF3
                Select Case ._Axis6DOF3
                    Case "-"
                        Axis6_Value3_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis6_Value3_Out = RollPercentUsed * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis6_Value3_Out = PitchPercentUsed * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis6_Value3_Out = HeavePercentUsed * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis6_Value3_Out = YawPercentUsed * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis6_Value3_Out = SwayPercentUsed * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis6_Value3_Out = SurgePercentUsed * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis6_Value3_Out = Extra1PercentUsed * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis6_Value3_Out = Extra2PercentUsed * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis6_Value3_Out = Extra3PercentUsed * (._Axis6PER3 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR3 = True Then
                            Axis6_Value3_Out = Axis6_Value3_Out * -1
                        End If
                End Select
                'DOF4
                Select Case ._Axis6DOF4
                    Case "-"
                        Axis6_Value4_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis6_Value4_Out = RollPercentUsed * (._Axis6PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR4 = True Then
                            Axis6_Value4_Out = Axis6_Value4_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis6_Value4_Out = PitchPercentUsed * (._Axis6PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR4 = True Then
                            Axis6_Value4_Out = Axis6_Value4_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis6_Value4_Out = HeavePercentUsed * (._Axis6PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR4 = True Then
                            Axis6_Value4_Out = Axis6_Value4_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis6_Value4_Out = YawPercentUsed * (._Axis6PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR4 = True Then
                            Axis6_Value4_Out = Axis6_Value4_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis6_Value4_Out = SwayPercentUsed * (._Axis6PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR4 = True Then
                            Axis6_Value4_Out = Axis6_Value4_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis6_Value4_Out = SurgePercentUsed * (._Axis6PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR4 = True Then
                            Axis6_Value4_Out = Axis6_Value4_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis6_Value4_Out = Extra1PercentUsed * (._Axis6PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR4 = True Then
                            Axis6_Value4_Out = Axis6_Value4_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis6_Value4_Out = Extra2PercentUsed * (._Axis6PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR4 = True Then
                            Axis6_Value4_Out = Axis6_Value4_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis6_Value4_Out = Extra3PercentUsed * (._Axis6PER4 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR4 = True Then
                            Axis6_Value4_Out = Axis6_Value4_Out * -1
                        End If
                End Select
                'DOF5
                Select Case ._Axis6DOF5
                    Case "-"
                        Axis6_Value5_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis6_Value5_Out = RollPercentUsed * (._Axis6PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR5 = True Then
                            Axis6_Value5_Out = Axis6_Value5_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis6_Value5_Out = PitchPercentUsed * (._Axis6PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR5 = True Then
                            Axis6_Value5_Out = Axis6_Value5_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis6_Value5_Out = HeavePercentUsed * (._Axis6PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR5 = True Then
                            Axis6_Value5_Out = Axis6_Value5_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis6_Value5_Out = YawPercentUsed * (._Axis6PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR5 = True Then
                            Axis6_Value5_Out = Axis6_Value5_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis6_Value5_Out = SwayPercentUsed * (._Axis6PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR5 = True Then
                            Axis6_Value5_Out = Axis6_Value5_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis6_Value5_Out = SurgePercentUsed * (._Axis6PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR5 = True Then
                            Axis6_Value5_Out = Axis6_Value5_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis6_Value5_Out = Extra1PercentUsed * (._Axis6PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR5 = True Then
                            Axis6_Value5_Out = Axis6_Value5_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis6_Value5_Out = Extra2PercentUsed * (._Axis6PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR5 = True Then
                            Axis6_Value5_Out = Axis6_Value5_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis6_Value5_Out = Extra3PercentUsed * (._Axis6PER5 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR5 = True Then
                            Axis6_Value5_Out = Axis6_Value5_Out * -1
                        End If
                End Select
                'DOF6
                Select Case ._Axis6DOF6
                    Case "-"
                        Axis6_Value6_Out = 0
                        Exit Select
                    Case "Roll"
                        'Get percent used for DOF
                        Axis6_Value6_Out = RollPercentUsed * (._Axis6PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR6 = True Then
                            Axis6_Value6_Out = Axis6_Value6_Out * -1
                        End If
                    Case "Pitch"
                        'Get percent used for DOF
                        Axis6_Value6_Out = PitchPercentUsed * (._Axis6PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR6 = True Then
                            Axis6_Value6_Out = Axis6_Value6_Out * -1
                        End If
                    Case "Heave"
                        'Get percent used for DOF
                        Axis6_Value6_Out = HeavePercentUsed * (._Axis6PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR6 = True Then
                            Axis6_Value6_Out = Axis6_Value6_Out * -1
                        End If
                    Case "Yaw"
                        'Get percent used for DOF
                        Axis6_Value6_Out = YawPercentUsed * (._Axis6PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR6 = True Then
                            Axis6_Value6_Out = Axis6_Value6_Out * -1
                        End If
                    Case "Sway"
                        'Get percent used for DOF
                        Axis6_Value6_Out = SwayPercentUsed * (._Axis6PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR6 = True Then
                            Axis6_Value6_Out = Axis6_Value6_Out * -1
                        End If
                    Case "Surge"
                        'Get percent used for DOF
                        Axis6_Value6_Out = SurgePercentUsed * (._Axis6PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR6 = True Then
                            Axis6_Value6_Out = Axis6_Value6_Out * -1
                        End If
                    Case "Extra1"
                        'Get percent used for DOF
                        Axis6_Value6_Out = Extra1PercentUsed * (._Axis6PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR6 = True Then
                            Axis6_Value6_Out = Axis6_Value6_Out * -1
                        End If
                    Case "Extra2"
                        'Get percent used for DOF
                        Axis6_Value6_Out = Extra2PercentUsed * (._Axis6PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR6 = True Then
                            Axis6_Value6_Out = Axis6_Value6_Out * -1
                        End If
                    Case "Extra3"
                        'Get percent used for DOF
                        Axis6_Value6_Out = Extra3PercentUsed * (._Axis6PER6 * 0.01)
                        'Flip if necessary
                        If ._Axis6DIR6 = True Then
                            Axis6_Value6_Out = Axis6_Value6_Out * -1
                        End If
                End Select

                'BUILD Value
                Axis6_Output = Axis6_Value1_Out + Axis6_Value2_Out + Axis6_Value3_Out + Axis6_Value4_Out + Axis6_Value5_Out + Axis6_Value6_Out

                'Stay in the limits
                If Axis6_Output > 1 Then
                    Axis6_Output = 1
                ElseIf Axis6_Output < -1 Then
                    Axis6_Output = -1
                End If

                ''Adjust ouput with axis Limiter (Scaler)
                'Axis6_Output = Axis6_Output * (Struct_AxisLimiting._Axis6Limiter * 0.01)

                ''fix output for rotational if needed
                'If Struct_AxisType._Axis6_OutputType = "Rotational" Then
                '    Axis6_Output = RotationalOutputFix(Axis6_Output, Struct_AxisType._Axis6_DegreesUsed)
                'End If

                'Set output
                _Axis6Output = Axis6_Output
            End With
            'start a new thread
            Thread.Sleep(CalculateRateMS)
        Loop
    End Sub
#End Region
#End Region

    'Calculate DOF's ************************
#Region "DOF Calculations"
#Region "Roll_Axis1 _ Output"
    'Output and Filters
    Private Roll_Output_Axis1 As Double
    Private Roll_Filter_DeadZone_Axis1 As Integer
    Private Roll_Filter_Boundary_Axis1 As Integer
    Private Roll_Filter_Washout_Axis1 As Integer
    Private Roll_Filter_Smoothing_Axis1 As Integer
    'Private Roll_Filter_Rescaling_Axis1 As Integer
    Private Roll_Filters_Axis1 As Cls_Filters

    Private Sub Start_OutputRoll_Axis1()
        'Create New Filter Object (resets object to default values)
        Roll_Filters_Axis1 = New Cls_Filters

        'load the right DOF values
        Select Case "Roll"
            Case Struct_AxisAssignments._Axis1DOF1
                Roll_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_DeadZone
                Roll_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Boundary
                Roll_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Washout
                Roll_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF2
                Roll_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_DeadZone
                Roll_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Boundary
                Roll_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Washout
                Roll_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF3
                Roll_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_DeadZone
                Roll_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Boundary
                Roll_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Washout
                Roll_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF4
                Roll_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_DeadZone
                Roll_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Boundary
                Roll_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Washout
                Roll_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF5
                Roll_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_DeadZone
                Roll_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Boundary
                Roll_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Washout
                Roll_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF6
                Roll_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_DeadZone
                Roll_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Boundary
                Roll_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Washout
                Roll_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputRoll_Axis1)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputRoll_Axis1()
        Do While Output_Calulations_Running = True
            'Get Input
            Roll_Output_Axis1 = Roll_Input

            'DeadZone Filter
            Roll_Output_Axis1 = Roll_Filters_Axis1.DeadZone(Roll_Output_Axis1, Roll_Filter_DeadZone_Axis1)

            'Boundry filter 
            Roll_Output_Axis1 = Roll_Filters_Axis1.Boundry(Roll_Output_Axis1, Roll_Filter_Boundary_Axis1)

            'Washout filter
            Roll_Output_Axis1 = Roll_Filters_Axis1.WashoutDeg(Roll_Output_Axis1, Roll_Filter_Washout_Axis1)

            'Smoothing Filter
            Roll_Output_Axis1 = Roll_Filters_Axis1.Smoothing(Roll_Output_Axis1, Roll_Filter_Smoothing_Axis1)

            'Main Profile Smoothing
            '/////////Roll_Output_Axis1 = Roll_Filters_Axis1.MainProfile_Smoothing(Roll_Output_Axis1, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputRoll_Axis1 = Roll_Output_Axis1

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Roll_Axis2 _ Output"
    'Output and Filters
    Private Roll_Output_Axis2 As Double
    Private Roll_Filter_DeadZone_Axis2 As Integer
    Private Roll_Filter_Boundary_Axis2 As Integer
    Private Roll_Filter_Washout_Axis2 As Integer
    Private Roll_Filter_Smoothing_Axis2 As Integer
    'Private Roll_Filter_Rescaling_Axis2 As Integer
    Private Roll_Filters_Axis2 As Cls_Filters
    Private Sub Start_OutputRoll_Axis2()
        'Create New Filter Object (resets object to default values)
        Roll_Filters_Axis2 = New Cls_Filters

        'load the right DOF values
        Select Case "Roll"
            Case Struct_AxisAssignments._Axis2DOF1
                Roll_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_DeadZone
                Roll_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Boundary
                Roll_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Washout
                Roll_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF2
                Roll_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_DeadZone
                Roll_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Boundary
                Roll_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Washout
                Roll_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF3
                Roll_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_DeadZone
                Roll_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Boundary
                Roll_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Washout
                Roll_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF4
                Roll_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_DeadZone
                Roll_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Boundary
                Roll_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Washout
                Roll_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF5
                Roll_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_DeadZone
                Roll_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Boundary
                Roll_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Washout
                Roll_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF6
                Roll_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_DeadZone
                Roll_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Boundary
                Roll_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Washout
                Roll_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputRoll_Axis2)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputRoll_Axis2()
        Do While Output_Calulations_Running = True
            'Get Input
            Roll_Output_Axis2 = Roll_Input

            'DeadZone Filter
            Roll_Output_Axis2 = Roll_Filters_Axis2.DeadZone(Roll_Output_Axis2, Roll_Filter_DeadZone_Axis2)

            'Boundry filter 
            Roll_Output_Axis2 = Roll_Filters_Axis2.Boundry(Roll_Output_Axis2, Roll_Filter_Boundary_Axis2)

            'Washout filter
            Roll_Output_Axis2 = Roll_Filters_Axis2.WashoutDeg(Roll_Output_Axis2, Roll_Filter_Washout_Axis2)

            'Smoothing Filter
            Roll_Output_Axis2 = Roll_Filters_Axis2.Smoothing(Roll_Output_Axis2, Roll_Filter_Smoothing_Axis2)

            'Main Profile Smoothing
            'Roll_Output_Axis2 = Roll_Filters_Axis2.MainProfile_Smoothing(Roll_Output_Axis2, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputRoll_Axis2 = Roll_Output_Axis2

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Roll_Axis3 _ Output"
    'Output and Filters
    Private Roll_Output_Axis3 As Double
    Private Roll_Filter_DeadZone_Axis3 As Integer
    Private Roll_Filter_Boundary_Axis3 As Integer
    Private Roll_Filter_Washout_Axis3 As Integer
    Private Roll_Filter_Smoothing_Axis3 As Integer
    'Private Roll_Filter_Rescaling_Axis3 As Integer
    Private Roll_Filters_Axis3 As Cls_Filters
    Private Sub Start_OutputRoll_Axis3()
        'Create New Filter Object (resets object to default values)
        Roll_Filters_Axis3 = New Cls_Filters

        'load the right DOF values
        Select Case "Roll"
            Case Struct_AxisAssignments._Axis3DOF1
                Roll_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_DeadZone
                Roll_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Boundary
                Roll_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Washout
                Roll_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF2
                Roll_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_DeadZone
                Roll_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Boundary
                Roll_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Washout
                Roll_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF3
                Roll_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_DeadZone
                Roll_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Boundary
                Roll_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Washout
                Roll_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF4
                Roll_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_DeadZone
                Roll_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Boundary
                Roll_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Washout
                Roll_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF5
                Roll_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_DeadZone
                Roll_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Boundary
                Roll_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Washout
                Roll_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF6
                Roll_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_DeadZone
                Roll_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Boundary
                Roll_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Washout
                Roll_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputRoll_Axis3)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputRoll_Axis3()
        Do While Output_Calulations_Running = True
            'Get Input
            Roll_Output_Axis3 = Roll_Input

            'DeadZone Filter
            Roll_Output_Axis3 = Roll_Filters_Axis3.DeadZone(Roll_Output_Axis3, Roll_Filter_DeadZone_Axis3)

            'Boundry filter 
            Roll_Output_Axis3 = Roll_Filters_Axis3.Boundry(Roll_Output_Axis3, Roll_Filter_Boundary_Axis3)

            'Washout filter
            Roll_Output_Axis3 = Roll_Filters_Axis3.WashoutDeg(Roll_Output_Axis3, Roll_Filter_Washout_Axis3)

            'Smoothing Filter
            Roll_Output_Axis3 = Roll_Filters_Axis3.Smoothing(Roll_Output_Axis3, Roll_Filter_Smoothing_Axis3)

            'Main Profile Smoothing
            'Roll_Output_Axis3 = Roll_Filters_Axis3.MainProfile_Smoothing(Roll_Output_Axis3, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputRoll_Axis3 = Roll_Output_Axis3

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Roll_Axis4 _ Output"
    'Output and Filters
    Private Roll_Output_Axis4 As Double
    Private Roll_Filter_DeadZone_Axis4 As Integer
    Private Roll_Filter_Boundary_Axis4 As Integer
    Private Roll_Filter_Washout_Axis4 As Integer
    Private Roll_Filter_Smoothing_Axis4 As Integer
    'Private Roll_Filter_Rescaling_Axis4 As Integer
    Private Roll_Filters_Axis4 As Cls_Filters
    Private Sub Start_OutputRoll_Axis4()
        'Create New Filter Object (resets object to default values)
        Roll_Filters_Axis4 = New Cls_Filters

        'load the right DOF values
        Select Case "Roll"
            Case Struct_AxisAssignments._Axis4DOF1
                Roll_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_DeadZone
                Roll_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Boundary
                Roll_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Washout
                Roll_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF2
                Roll_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_DeadZone
                Roll_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Boundary
                Roll_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Washout
                Roll_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF3
                Roll_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_DeadZone
                Roll_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Boundary
                Roll_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Washout
                Roll_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF4
                Roll_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_DeadZone
                Roll_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Boundary
                Roll_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Washout
                Roll_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF5
                Roll_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_DeadZone
                Roll_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Boundary
                Roll_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Washout
                Roll_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF6
                Roll_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_DeadZone
                Roll_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Boundary
                Roll_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Washout
                Roll_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputRoll_Axis4)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputRoll_Axis4()
        Do While Output_Calulations_Running = True
            'Get Input
            Roll_Output_Axis4 = Roll_Input

            'DeadZone Filter
            Roll_Output_Axis4 = Roll_Filters_Axis4.DeadZone(Roll_Output_Axis4, Roll_Filter_DeadZone_Axis4)

            'Boundry filter 
            Roll_Output_Axis4 = Roll_Filters_Axis4.Boundry(Roll_Output_Axis4, Roll_Filter_Boundary_Axis4)

            'Washout filter
            Roll_Output_Axis4 = Roll_Filters_Axis4.WashoutDeg(Roll_Output_Axis4, Roll_Filter_Washout_Axis4)

            'Smoothing Filter
            Roll_Output_Axis4 = Roll_Filters_Axis4.Smoothing(Roll_Output_Axis4, Roll_Filter_Smoothing_Axis4)

            'Main Profile Smoothing
            'Roll_Output_Axis4 = Roll_Filters_Axis4.MainProfile_Smoothing(Roll_Output_Axis4, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputRoll_Axis4 = Roll_Output_Axis4

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Roll_Axis5 _ Output"
    'Output and Filters
    Private Roll_Output_Axis5 As Double
    Private Roll_Filter_DeadZone_Axis5 As Integer
    Private Roll_Filter_Boundary_Axis5 As Integer
    Private Roll_Filter_Washout_Axis5 As Integer
    Private Roll_Filter_Smoothing_Axis5 As Integer
    'Private Roll_Filter_Rescaling_Axis5 As Integer
    Private Roll_Filters_Axis5 As Cls_Filters
    Private Sub Start_OutputRoll_Axis5()
        'Create New Filter Object (resets object to default values)
        Roll_Filters_Axis5 = New Cls_Filters

        'load the right DOF values
        Select Case "Roll"
            Case Struct_AxisAssignments._Axis5DOF1
                Roll_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_DeadZone
                Roll_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Boundary
                Roll_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Washout
                Roll_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF2
                Roll_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_DeadZone
                Roll_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Boundary
                Roll_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Washout
                Roll_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF3
                Roll_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_DeadZone
                Roll_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Boundary
                Roll_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Washout
                Roll_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF4
                Roll_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_DeadZone
                Roll_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Boundary
                Roll_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Washout
                Roll_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF5
                Roll_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_DeadZone
                Roll_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Boundary
                Roll_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Washout
                Roll_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF6
                Roll_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_DeadZone
                Roll_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Boundary
                Roll_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Washout
                Roll_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputRoll_Axis5)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputRoll_Axis5()
        Do While Output_Calulations_Running = True
            'Get Input
            Roll_Output_Axis5 = Roll_Input

            'DeadZone Filter
            Roll_Output_Axis5 = Roll_Filters_Axis5.DeadZone(Roll_Output_Axis5, Roll_Filter_DeadZone_Axis5)

            'Boundry filter 
            Roll_Output_Axis5 = Roll_Filters_Axis5.Boundry(Roll_Output_Axis5, Roll_Filter_Boundary_Axis5)

            'Washout filter
            Roll_Output_Axis5 = Roll_Filters_Axis5.WashoutDeg(Roll_Output_Axis5, Roll_Filter_Washout_Axis5)

            'Smoothing Filter
            Roll_Output_Axis5 = Roll_Filters_Axis5.Smoothing(Roll_Output_Axis5, Roll_Filter_Smoothing_Axis5)

            'Main Profile Smoothing
            'Roll_Output_Axis5 = Roll_Filters_Axis5.MainProfile_Smoothing(Roll_Output_Axis5, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputRoll_Axis5 = Roll_Output_Axis5

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Roll_Axis6 _ Output"
    'Output and Filters
    Private Roll_Output_Axis6 As Double
    Private Roll_Filter_DeadZone_Axis6 As Integer
    Private Roll_Filter_Boundary_Axis6 As Integer
    Private Roll_Filter_Washout_Axis6 As Integer
    Private Roll_Filter_Smoothing_Axis6 As Integer
    'Private Roll_Filter_Rescaling_Axis6 As Integer
    Private Roll_Filters_Axis6 As Cls_Filters
    Private Sub Start_OutputRoll_Axis6()
        'Create New Filter Object (resets object to default values)
        Roll_Filters_Axis6 = New Cls_Filters

        'load the right DOF values
        Select Case "Roll"
            Case Struct_AxisAssignments._Axis6DOF1
                Roll_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_DeadZone
                Roll_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Boundary
                Roll_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Washout
                Roll_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF2
                Roll_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_DeadZone
                Roll_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Boundary
                Roll_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Washout
                Roll_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF3
                Roll_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_DeadZone
                Roll_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Boundary
                Roll_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Washout
                Roll_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF4
                Roll_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_DeadZone
                Roll_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Boundary
                Roll_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Washout
                Roll_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF5
                Roll_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_DeadZone
                Roll_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Boundary
                Roll_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Washout
                Roll_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF6
                Roll_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_DeadZone
                Roll_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Boundary
                Roll_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Washout
                Roll_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Smoothing
                'Roll_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputRoll_Axis6)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputRoll_Axis6()
        Do While Output_Calulations_Running = True
            'Get Input
            Roll_Output_Axis6 = Roll_Input

            'DeadZone Filter
            Roll_Output_Axis6 = Roll_Filters_Axis6.DeadZone(Roll_Output_Axis6, Roll_Filter_DeadZone_Axis6)

            'Boundry filter 
            Roll_Output_Axis6 = Roll_Filters_Axis6.Boundry(Roll_Output_Axis6, Roll_Filter_Boundary_Axis6)

            'Washout filter
            Roll_Output_Axis6 = Roll_Filters_Axis6.WashoutDeg(Roll_Output_Axis6, Roll_Filter_Washout_Axis6)

            'Smoothing Filter
            Roll_Output_Axis6 = Roll_Filters_Axis6.Smoothing(Roll_Output_Axis6, Roll_Filter_Smoothing_Axis6)

            'Main Profile Smoothing
            'Roll_Output_Axis6 = Roll_Filters_Axis6.MainProfile_Smoothing(Roll_Output_Axis6, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputRoll_Axis6 = Roll_Output_Axis6

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Pitch_Axis1 _ Output"
    'Output and Filters
    Private Pitch_Output_Axis1 As Double
    Private Pitch_Filter_DeadZone_Axis1 As Integer
    Private Pitch_Filter_Boundary_Axis1 As Integer
    Private Pitch_Filter_Washout_Axis1 As Integer
    Private Pitch_Filter_Smoothing_Axis1 As Integer
    'Private Pitch_Filter_Rescaling_Axis1 As Integer
    Private Pitch_Filters_Axis1 As Cls_Filters
    Private Sub Start_OutputPitch_Axis1()
        'Create New Filter Object (resets object to default values)
        Pitch_Filters_Axis1 = New Cls_Filters

        'load the right DOF values
        Select Case "Pitch"
            Case Struct_AxisAssignments._Axis1DOF1
                Pitch_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_DeadZone
                Pitch_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Boundary
                Pitch_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Washout
                Pitch_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF2
                Pitch_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_DeadZone
                Pitch_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Boundary
                Pitch_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Washout
                Pitch_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF3
                Pitch_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_DeadZone
                Pitch_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Boundary
                Pitch_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Washout
                Pitch_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF4
                Pitch_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_DeadZone
                Pitch_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Boundary
                Pitch_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Washout
                Pitch_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF5
                Pitch_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_DeadZone
                Pitch_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Boundary
                Pitch_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Washout
                Pitch_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF6
                Pitch_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_DeadZone
                Pitch_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Boundary
                Pitch_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Washout
                Pitch_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputPitch_Axis1)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputPitch_Axis1()
        Do While Output_Calulations_Running = True
            'Get Input
            Pitch_Output_Axis1 = Pitch_Input

            'DeadZone Filter
            Pitch_Output_Axis1 = Pitch_Filters_Axis1.DeadZone(Pitch_Output_Axis1, Pitch_Filter_DeadZone_Axis1)

            'Boundry filter 
            Pitch_Output_Axis1 = Pitch_Filters_Axis1.Boundry(Pitch_Output_Axis1, Pitch_Filter_Boundary_Axis1)

            'Washout filter
            Pitch_Output_Axis1 = Pitch_Filters_Axis1.WashoutDeg(Pitch_Output_Axis1, Pitch_Filter_Washout_Axis1)

            'Smoothing Filter
            Pitch_Output_Axis1 = Pitch_Filters_Axis1.Smoothing(Pitch_Output_Axis1, Pitch_Filter_Smoothing_Axis1)

            'Main Profile Smoothing
            'Pitch_Output_Axis1 = Pitch_Filters_Axis1.MainProfile_Smoothing(Pitch_Output_Axis1, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputPitch_Axis1 = Pitch_Output_Axis1

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Pitch_Axis2 _ Output"
    'Output and Filters
    Private Pitch_Output_Axis2 As Double
    Private Pitch_Filter_DeadZone_Axis2 As Integer
    Private Pitch_Filter_Boundary_Axis2 As Integer
    Private Pitch_Filter_Washout_Axis2 As Integer
    Private Pitch_Filter_Smoothing_Axis2 As Integer
    'Private Pitch_Filter_Rescaling_Axis2 As Integer
    Private Pitch_Filters_Axis2 As Cls_Filters
    Private Sub Start_OutputPitch_Axis2()
        'Create New Filter Object (resets object to default values)
        Pitch_Filters_Axis2 = New Cls_Filters

        'load the right DOF values
        Select Case "Pitch"
            Case Struct_AxisAssignments._Axis2DOF1
                Pitch_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_DeadZone
                Pitch_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Boundary
                Pitch_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Washout
                Pitch_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF2
                Pitch_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_DeadZone
                Pitch_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Boundary
                Pitch_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Washout
                Pitch_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF3
                Pitch_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_DeadZone
                Pitch_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Boundary
                Pitch_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Washout
                Pitch_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF4
                Pitch_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_DeadZone
                Pitch_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Boundary
                Pitch_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Washout
                Pitch_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF5
                Pitch_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_DeadZone
                Pitch_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Boundary
                Pitch_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Washout
                Pitch_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF6
                Pitch_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_DeadZone
                Pitch_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Boundary
                Pitch_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Washout
                Pitch_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputPitch_Axis2)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputPitch_Axis2()
        Do While Output_Calulations_Running = True
            'Get Input
            Pitch_Output_Axis2 = Pitch_Input

            'DeadZone Filter
            Pitch_Output_Axis2 = Pitch_Filters_Axis2.DeadZone(Pitch_Output_Axis2, Pitch_Filter_DeadZone_Axis2)

            'Boundry filter 
            Pitch_Output_Axis2 = Pitch_Filters_Axis2.Boundry(Pitch_Output_Axis2, Pitch_Filter_Boundary_Axis2)

            'Washout filter
            Pitch_Output_Axis2 = Pitch_Filters_Axis2.WashoutDeg(Pitch_Output_Axis2, Pitch_Filter_Washout_Axis2)

            'Smoothing Filter
            Pitch_Output_Axis2 = Pitch_Filters_Axis2.Smoothing(Pitch_Output_Axis2, Pitch_Filter_Smoothing_Axis2)

            'Main Profile Smoothing
            'Pitch_Output_Axis2 = Pitch_Filters_Axis2.MainProfile_Smoothing(Pitch_Output_Axis2, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputPitch_Axis2 = Pitch_Output_Axis2

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Pitch_Axis3 _ Output"
    'Output and Filters
    Private Pitch_Output_Axis3 As Double
    Private Pitch_Filter_DeadZone_Axis3 As Integer
    Private Pitch_Filter_Boundary_Axis3 As Integer
    Private Pitch_Filter_Washout_Axis3 As Integer
    Private Pitch_Filter_Smoothing_Axis3 As Integer
    'Private Pitch_Filter_Rescaling_Axis3 As Integer
    Private Pitch_Filters_Axis3 As Cls_Filters
    Private Sub Start_OutputPitch_Axis3()
        'Create New Filter Object (resets object to default values)
        Pitch_Filters_Axis3 = New Cls_Filters

        'load the right DOF values
        Select Case "Pitch"
            Case Struct_AxisAssignments._Axis3DOF1
                Pitch_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_DeadZone
                Pitch_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Boundary
                Pitch_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Washout
                Pitch_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF2
                Pitch_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_DeadZone
                Pitch_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Boundary
                Pitch_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Washout
                Pitch_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF3
                Pitch_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_DeadZone
                Pitch_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Boundary
                Pitch_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Washout
                Pitch_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF4
                Pitch_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_DeadZone
                Pitch_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Boundary
                Pitch_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Washout
                Pitch_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF5
                Pitch_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_DeadZone
                Pitch_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Boundary
                Pitch_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Washout
                Pitch_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF6
                Pitch_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_DeadZone
                Pitch_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Boundary
                Pitch_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Washout
                Pitch_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputPitch_Axis3)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputPitch_Axis3()
        Do While Output_Calulations_Running = True
            'Get Input
            Pitch_Output_Axis3 = Pitch_Input

            'DeadZone Filter
            Pitch_Output_Axis3 = Pitch_Filters_Axis3.DeadZone(Pitch_Output_Axis3, Pitch_Filter_DeadZone_Axis3)

            'Boundry filter 
            Pitch_Output_Axis3 = Pitch_Filters_Axis3.Boundry(Pitch_Output_Axis3, Pitch_Filter_Boundary_Axis3)

            'Washout filter
            Pitch_Output_Axis3 = Pitch_Filters_Axis3.WashoutDeg(Pitch_Output_Axis3, Pitch_Filter_Washout_Axis3)

            'Smoothing Filter
            Pitch_Output_Axis3 = Pitch_Filters_Axis3.Smoothing(Pitch_Output_Axis3, Pitch_Filter_Smoothing_Axis3)

            'Main Profile Smoothing
            'Pitch_Output_Axis3 = Pitch_Filters_Axis3.MainProfile_Smoothing(Pitch_Output_Axis3, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputPitch_Axis3 = Pitch_Output_Axis3

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Pitch_Axis4 _ Output"
    'Output and Filters
    Private Pitch_Output_Axis4 As Double
    Private Pitch_Filter_DeadZone_Axis4 As Integer
    Private Pitch_Filter_Boundary_Axis4 As Integer
    Private Pitch_Filter_Washout_Axis4 As Integer
    Private Pitch_Filter_Smoothing_Axis4 As Integer
    'Private Pitch_Filter_Rescaling_Axis4 As Integer
    Private Pitch_Filters_Axis4 As Cls_Filters
    Private Sub Start_OutputPitch_Axis4()
        'Create New Filter Object (resets object to default values)
        Pitch_Filters_Axis4 = New Cls_Filters

        'load the right DOF values
        Select Case "Pitch"
            Case Struct_AxisAssignments._Axis4DOF1
                Pitch_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_DeadZone
                Pitch_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Boundary
                Pitch_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Washout
                Pitch_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF2
                Pitch_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_DeadZone
                Pitch_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Boundary
                Pitch_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Washout
                Pitch_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF3
                Pitch_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_DeadZone
                Pitch_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Boundary
                Pitch_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Washout
                Pitch_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF4
                Pitch_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_DeadZone
                Pitch_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Boundary
                Pitch_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Washout
                Pitch_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF5
                Pitch_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_DeadZone
                Pitch_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Boundary
                Pitch_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Washout
                Pitch_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF6
                Pitch_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_DeadZone
                Pitch_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Boundary
                Pitch_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Washout
                Pitch_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputPitch_Axis4)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputPitch_Axis4()
        Do While Output_Calulations_Running = True
            'Get Input
            Pitch_Output_Axis4 = Pitch_Input

            'DeadZone Filter
            Pitch_Output_Axis4 = Pitch_Filters_Axis4.DeadZone(Pitch_Output_Axis4, Pitch_Filter_DeadZone_Axis4)

            'Boundry filter 
            Pitch_Output_Axis4 = Pitch_Filters_Axis4.Boundry(Pitch_Output_Axis4, Pitch_Filter_Boundary_Axis4)

            'Washout filter
            Pitch_Output_Axis4 = Pitch_Filters_Axis4.WashoutDeg(Pitch_Output_Axis4, Pitch_Filter_Washout_Axis4)

            'Smoothing Filter
            Pitch_Output_Axis4 = Pitch_Filters_Axis4.Smoothing(Pitch_Output_Axis4, Pitch_Filter_Smoothing_Axis4)

            'Main Profile Smoothing
            'Pitch_Output_Axis4 = Pitch_Filters_Axis4.MainProfile_Smoothing(Pitch_Output_Axis4, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputPitch_Axis4 = Pitch_Output_Axis4

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Pitch_Axis5 _ Output"
    'Output and Filters
    Private Pitch_Output_Axis5 As Double
    Private Pitch_Filter_DeadZone_Axis5 As Integer
    Private Pitch_Filter_Boundary_Axis5 As Integer
    Private Pitch_Filter_Washout_Axis5 As Integer
    Private Pitch_Filter_Smoothing_Axis5 As Integer
    'Private Pitch_Filter_Rescaling_Axis5 As Integer
    Private Pitch_Filters_Axis5 As Cls_Filters
    Private Sub Start_OutputPitch_Axis5()
        'Create New Filter Object (resets object to default values)
        Pitch_Filters_Axis5 = New Cls_Filters

        'load the right DOF values
        Select Case "Pitch"
            Case Struct_AxisAssignments._Axis5DOF1
                Pitch_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_DeadZone
                Pitch_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Boundary
                Pitch_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Washout
                Pitch_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF2
                Pitch_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_DeadZone
                Pitch_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Boundary
                Pitch_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Washout
                Pitch_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF3
                Pitch_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_DeadZone
                Pitch_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Boundary
                Pitch_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Washout
                Pitch_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF4
                Pitch_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_DeadZone
                Pitch_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Boundary
                Pitch_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Washout
                Pitch_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF5
                Pitch_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_DeadZone
                Pitch_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Boundary
                Pitch_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Washout
                Pitch_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF6
                Pitch_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_DeadZone
                Pitch_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Boundary
                Pitch_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Washout
                Pitch_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputPitch_Axis5)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputPitch_Axis5()
        Do While Output_Calulations_Running = True
            'Get Input
            Pitch_Output_Axis5 = Pitch_Input

            'DeadZone Filter
            Pitch_Output_Axis5 = Pitch_Filters_Axis5.DeadZone(Pitch_Output_Axis5, Pitch_Filter_DeadZone_Axis5)

            'Boundry filter 
            Pitch_Output_Axis5 = Pitch_Filters_Axis5.Boundry(Pitch_Output_Axis5, Pitch_Filter_Boundary_Axis5)

            'Washout filter
            Pitch_Output_Axis5 = Pitch_Filters_Axis5.WashoutDeg(Pitch_Output_Axis5, Pitch_Filter_Washout_Axis5)

            'Smoothing Filter
            Pitch_Output_Axis5 = Pitch_Filters_Axis5.Smoothing(Pitch_Output_Axis5, Pitch_Filter_Smoothing_Axis5)

            'Main Profile Smoothing
            'Pitch_Output_Axis5 = Pitch_Filters_Axis5.MainProfile_Smoothing(Pitch_Output_Axis5, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputPitch_Axis5 = Pitch_Output_Axis5

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Pitch_Axis6 _ Output"
    'Output and Filters
    Private Pitch_Output_Axis6 As Double
    Private Pitch_Filter_DeadZone_Axis6 As Integer
    Private Pitch_Filter_Boundary_Axis6 As Integer
    Private Pitch_Filter_Washout_Axis6 As Integer
    Private Pitch_Filter_Smoothing_Axis6 As Integer
    'Private Pitch_Filter_Rescaling_Axis6 As Integer
    Private Pitch_Filters_Axis6 As Cls_Filters
    Private Sub Start_OutputPitch_Axis6()
        'Create New Filter Object (resets object to default values)
        Pitch_Filters_Axis6 = New Cls_Filters

        'load the right DOF values
        Select Case "Pitch"
            Case Struct_AxisAssignments._Axis6DOF1
                Pitch_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_DeadZone
                Pitch_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Boundary
                Pitch_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Washout
                Pitch_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF2
                Pitch_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_DeadZone
                Pitch_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Boundary
                Pitch_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Washout
                Pitch_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF3
                Pitch_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_DeadZone
                Pitch_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Boundary
                Pitch_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Washout
                Pitch_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF4
                Pitch_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_DeadZone
                Pitch_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Boundary
                Pitch_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Washout
                Pitch_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF5
                Pitch_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_DeadZone
                Pitch_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Boundary
                Pitch_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Washout
                Pitch_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF6
                Pitch_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_DeadZone
                Pitch_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Boundary
                Pitch_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Washout
                Pitch_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Smoothing
                'Pitch_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputPitch_Axis6)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputPitch_Axis6()
        Do While Output_Calulations_Running = True
            'Get Input
            Pitch_Output_Axis6 = Pitch_Input

            'DeadZone Filter
            Pitch_Output_Axis6 = Pitch_Filters_Axis6.DeadZone(Pitch_Output_Axis6, Pitch_Filter_DeadZone_Axis6)

            'Boundry filter 
            Pitch_Output_Axis6 = Pitch_Filters_Axis6.Boundry(Pitch_Output_Axis6, Pitch_Filter_Boundary_Axis6)

            'Washout filter
            Pitch_Output_Axis6 = Pitch_Filters_Axis6.WashoutDeg(Pitch_Output_Axis6, Pitch_Filter_Washout_Axis6)

            'Smoothing Filter
            Pitch_Output_Axis6 = Pitch_Filters_Axis6.Smoothing(Pitch_Output_Axis6, Pitch_Filter_Smoothing_Axis6)

            'Main Profile Smoothing
            'Pitch_Output_Axis6 = Pitch_Filters_Axis6.MainProfile_Smoothing(Pitch_Output_Axis6, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputPitch_Axis6 = Pitch_Output_Axis6

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Heave_Axis1 _ Output"
    'Output and Filters
    Private Heave_Output_Axis1 As Double
    Private Heave_Filter_DeadZone_Axis1 As Integer
    Private Heave_Filter_Boundary_Axis1 As Integer
    Private Heave_Filter_Washout_Axis1 As Integer
    Private Heave_Filter_Smoothing_Axis1 As Integer
    'Private Heave_Filter_Rescaling_Axis1 As Integer
    Private Heave_Filters_Axis1 As Cls_Filters
    Private Sub Start_OutputHeave_Axis1()
        'Create New Filter Object (resets object to default values)
        Heave_Filters_Axis1 = New Cls_Filters

        'load the right DOF values
        Select Case "Heave"
            Case Struct_AxisAssignments._Axis1DOF1
                Heave_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_DeadZone
                Heave_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Boundary
                Heave_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Washout
                Heave_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF2
                Heave_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_DeadZone
                Heave_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Boundary
                Heave_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Washout
                Heave_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF3
                Heave_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_DeadZone
                Heave_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Boundary
                Heave_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Washout
                Heave_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF4
                Heave_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_DeadZone
                Heave_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Boundary
                Heave_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Washout
                Heave_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF5
                Heave_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_DeadZone
                Heave_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Boundary
                Heave_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Washout
                Heave_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF6
                Heave_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_DeadZone
                Heave_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Boundary
                Heave_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Washout
                Heave_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputHeave_Axis1)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputHeave_Axis1()
        Do While Output_Calulations_Running = True
            'Get Input
            Heave_Output_Axis1 = Heave_Input

            'DeadZone Filter
            Heave_Output_Axis1 = Heave_Filters_Axis1.DeadZone(Heave_Output_Axis1, Heave_Filter_DeadZone_Axis1)

            'Boundry filter 
            Heave_Output_Axis1 = Heave_Filters_Axis1.Boundry(Heave_Output_Axis1, Heave_Filter_Boundary_Axis1)

            'Washout filter
            Heave_Output_Axis1 = Heave_Filters_Axis1.WashoutAccel(Heave_Output_Axis1, Heave_Filter_Washout_Axis1)

            'Smoothing Filter
            Heave_Output_Axis1 = Heave_Filters_Axis1.Smoothing(Heave_Output_Axis1, Heave_Filter_Smoothing_Axis1)

            'Main Profile Smoothing
            'Heave_Output_Axis1 = Heave_Filters_Axis1.MainProfile_Smoothing(Heave_Output_Axis1, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputHeave_Axis1 = Heave_Output_Axis1

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Heave_Axis2 _ Output"
    'Output and Filters
    Private Heave_Output_Axis2 As Double
    Private Heave_Filter_DeadZone_Axis2 As Integer
    Private Heave_Filter_Boundary_Axis2 As Integer
    Private Heave_Filter_Washout_Axis2 As Integer
    Private Heave_Filter_Smoothing_Axis2 As Integer
    'Private Heave_Filter_Rescaling_Axis2 As Integer
    Private Heave_Filters_Axis2 As Cls_Filters
    Private Sub Start_OutputHeave_Axis2()
        'Create New Filter Object (resets object to default values)
        Heave_Filters_Axis2 = New Cls_Filters

        'load the right DOF values
        Select Case "Heave"
            Case Struct_AxisAssignments._Axis2DOF1
                Heave_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_DeadZone
                Heave_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Boundary
                Heave_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Washout
                Heave_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF2
                Heave_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_DeadZone
                Heave_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Boundary
                Heave_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Washout
                Heave_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF3
                Heave_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_DeadZone
                Heave_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Boundary
                Heave_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Washout
                Heave_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF4
                Heave_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_DeadZone
                Heave_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Boundary
                Heave_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Washout
                Heave_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF5
                Heave_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_DeadZone
                Heave_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Boundary
                Heave_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Washout
                Heave_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF6
                Heave_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_DeadZone
                Heave_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Boundary
                Heave_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Washout
                Heave_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputHeave_Axis2)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputHeave_Axis2()
        Do While Output_Calulations_Running = True
            'Get Input
            Heave_Output_Axis2 = Heave_Input

            'DeadZone Filter
            Heave_Output_Axis2 = Heave_Filters_Axis2.DeadZone(Heave_Output_Axis2, Heave_Filter_DeadZone_Axis2)

            'Boundry filter 
            Heave_Output_Axis2 = Heave_Filters_Axis2.Boundry(Heave_Output_Axis2, Heave_Filter_Boundary_Axis2)

            'Washout filter
            Heave_Output_Axis2 = Heave_Filters_Axis2.WashoutAccel(Heave_Output_Axis2, Heave_Filter_Washout_Axis2)

            'Smoothing Filter
            Heave_Output_Axis2 = Heave_Filters_Axis2.Smoothing(Heave_Output_Axis2, Heave_Filter_Smoothing_Axis2)

            'Main Profile Smoothing
            'Heave_Output_Axis2 = Heave_Filters_Axis2.MainProfile_Smoothing(Heave_Output_Axis2, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputHeave_Axis2 = Heave_Output_Axis2

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Heave_Axis3 _ Output"
    'Output and Filters
    Private Heave_Output_Axis3 As Double
    Private Heave_Filter_DeadZone_Axis3 As Integer
    Private Heave_Filter_Boundary_Axis3 As Integer
    Private Heave_Filter_Washout_Axis3 As Integer
    Private Heave_Filter_Smoothing_Axis3 As Integer
    'Private Heave_Filter_Rescaling_Axis3 As Integer
    Private Heave_Filters_Axis3 As Cls_Filters
    Private Sub Start_OutputHeave_Axis3()
        'Create New Filter Object (resets object to default values)
        Heave_Filters_Axis3 = New Cls_Filters

        'load the right DOF values
        Select Case "Heave"
            Case Struct_AxisAssignments._Axis3DOF1
                Heave_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_DeadZone
                Heave_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Boundary
                Heave_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Washout
                Heave_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF2
                Heave_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_DeadZone
                Heave_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Boundary
                Heave_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Washout
                Heave_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF3
                Heave_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_DeadZone
                Heave_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Boundary
                Heave_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Washout
                Heave_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF4
                Heave_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_DeadZone
                Heave_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Boundary
                Heave_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Washout
                Heave_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF5
                Heave_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_DeadZone
                Heave_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Boundary
                Heave_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Washout
                Heave_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF6
                Heave_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_DeadZone
                Heave_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Boundary
                Heave_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Washout
                Heave_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputHeave_Axis3)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputHeave_Axis3()
        Do While Output_Calulations_Running = True
            'Get Input
            Heave_Output_Axis3 = Heave_Input

            'DeadZone Filter
            Heave_Output_Axis3 = Heave_Filters_Axis3.DeadZone(Heave_Output_Axis3, Heave_Filter_DeadZone_Axis3)

            'Boundry filter 
            Heave_Output_Axis3 = Heave_Filters_Axis3.Boundry(Heave_Output_Axis3, Heave_Filter_Boundary_Axis3)

            'Washout filter
            Heave_Output_Axis3 = Heave_Filters_Axis3.WashoutAccel(Heave_Output_Axis3, Heave_Filter_Washout_Axis3)

            'Smoothing Filter
            Heave_Output_Axis3 = Heave_Filters_Axis3.Smoothing(Heave_Output_Axis3, Heave_Filter_Smoothing_Axis3)

            'Main Profile Smoothing
            'Heave_Output_Axis3 = Heave_Filters_Axis3.MainProfile_Smoothing(Heave_Output_Axis3, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputHeave_Axis3 = Heave_Output_Axis3

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Heave_Axis4 _ Output"
    'Output and Filters
    Private Heave_Output_Axis4 As Double
    Private Heave_Filter_DeadZone_Axis4 As Integer
    Private Heave_Filter_Boundary_Axis4 As Integer
    Private Heave_Filter_Washout_Axis4 As Integer
    Private Heave_Filter_Smoothing_Axis4 As Integer
    'Private Heave_Filter_Rescaling_Axis4 As Integer
    Private Heave_Filters_Axis4 As Cls_Filters
    Private Sub Start_OutputHeave_Axis4()
        'Create New Filter Object (resets object to default values)
        Heave_Filters_Axis4 = New Cls_Filters

        'load the right DOF values
        Select Case "Heave"
            Case Struct_AxisAssignments._Axis4DOF1
                Heave_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_DeadZone
                Heave_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Boundary
                Heave_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Washout
                Heave_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF2
                Heave_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_DeadZone
                Heave_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Boundary
                Heave_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Washout
                Heave_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF3
                Heave_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_DeadZone
                Heave_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Boundary
                Heave_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Washout
                Heave_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF4
                Heave_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_DeadZone
                Heave_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Boundary
                Heave_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Washout
                Heave_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF5
                Heave_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_DeadZone
                Heave_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Boundary
                Heave_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Washout
                Heave_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF6
                Heave_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_DeadZone
                Heave_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Boundary
                Heave_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Washout
                Heave_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputHeave_Axis4)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputHeave_Axis4()
        Do While Output_Calulations_Running = True
            'Get Input
            Heave_Output_Axis4 = Heave_Input

            'DeadZone Filter
            Heave_Output_Axis4 = Heave_Filters_Axis4.DeadZone(Heave_Output_Axis4, Heave_Filter_DeadZone_Axis4)

            'Boundry filter 
            Heave_Output_Axis4 = Heave_Filters_Axis4.Boundry(Heave_Output_Axis4, Heave_Filter_Boundary_Axis4)

            'Washout filter
            Heave_Output_Axis4 = Heave_Filters_Axis4.WashoutAccel(Heave_Output_Axis4, Heave_Filter_Washout_Axis4)

            'Smoothing Filter
            Heave_Output_Axis4 = Heave_Filters_Axis4.Smoothing(Heave_Output_Axis4, Heave_Filter_Smoothing_Axis4)

            'Main Profile Smoothing
            'Heave_Output_Axis4 = Heave_Filters_Axis4.MainProfile_Smoothing(Heave_Output_Axis4, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputHeave_Axis4 = Heave_Output_Axis4

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Heave_Axis5 _ Output"
    'Output and Filters
    Private Heave_Output_Axis5 As Double
    Private Heave_Filter_DeadZone_Axis5 As Integer
    Private Heave_Filter_Boundary_Axis5 As Integer
    Private Heave_Filter_Washout_Axis5 As Integer
    Private Heave_Filter_Smoothing_Axis5 As Integer
    'Private Heave_Filter_Rescaling_Axis5 As Integer
    Private Heave_Filters_Axis5 As Cls_Filters
    Private Sub Start_OutputHeave_Axis5()
        'Create New Filter Object (resets object to default values)
        Heave_Filters_Axis5 = New Cls_Filters

        'load the right DOF values
        Select Case "Heave"
            Case Struct_AxisAssignments._Axis5DOF1
                Heave_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_DeadZone
                Heave_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Boundary
                Heave_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Washout
                Heave_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF2
                Heave_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_DeadZone
                Heave_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Boundary
                Heave_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Washout
                Heave_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF3
                Heave_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_DeadZone
                Heave_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Boundary
                Heave_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Washout
                Heave_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF4
                Heave_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_DeadZone
                Heave_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Boundary
                Heave_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Washout
                Heave_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF5
                Heave_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_DeadZone
                Heave_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Boundary
                Heave_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Washout
                Heave_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF6
                Heave_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_DeadZone
                Heave_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Boundary
                Heave_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Washout
                Heave_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputHeave_Axis5)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputHeave_Axis5()
        Do While Output_Calulations_Running = True
            'Get Input
            Heave_Output_Axis5 = Heave_Input

            'DeadZone Filter
            Heave_Output_Axis5 = Heave_Filters_Axis5.DeadZone(Heave_Output_Axis5, Heave_Filter_DeadZone_Axis5)

            'Boundry filter 
            Heave_Output_Axis5 = Heave_Filters_Axis5.Boundry(Heave_Output_Axis5, Heave_Filter_Boundary_Axis5)

            'Washout filter
            Heave_Output_Axis5 = Heave_Filters_Axis5.WashoutAccel(Heave_Output_Axis5, Heave_Filter_Washout_Axis5)

            'Smoothing Filter
            Heave_Output_Axis5 = Heave_Filters_Axis5.Smoothing(Heave_Output_Axis5, Heave_Filter_Smoothing_Axis5)

            'Main Profile Smoothing
            'Heave_Output_Axis5 = Heave_Filters_Axis5.MainProfile_Smoothing(Heave_Output_Axis5, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputHeave_Axis5 = Heave_Output_Axis5

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Heave_Axis6 _ Output"
    'Output and Filters
    Private Heave_Output_Axis6 As Double
    Private Heave_Filter_DeadZone_Axis6 As Integer
    Private Heave_Filter_Boundary_Axis6 As Integer
    Private Heave_Filter_Washout_Axis6 As Integer
    Private Heave_Filter_Smoothing_Axis6 As Integer
    'Private Heave_Filter_Rescaling_Axis6 As Integer
    Private Heave_Filters_Axis6 As Cls_Filters
    Private Sub Start_OutputHeave_Axis6()
        'Create New Filter Object (resets object to default values)
        Heave_Filters_Axis6 = New Cls_Filters

        'load the right DOF values
        Select Case "Heave"
            Case Struct_AxisAssignments._Axis6DOF1
                Heave_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_DeadZone
                Heave_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Boundary
                Heave_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Washout
                Heave_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF2
                Heave_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_DeadZone
                Heave_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Boundary
                Heave_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Washout
                Heave_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF3
                Heave_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_DeadZone
                Heave_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Boundary
                Heave_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Washout
                Heave_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF4
                Heave_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_DeadZone
                Heave_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Boundary
                Heave_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Washout
                Heave_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF5
                Heave_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_DeadZone
                Heave_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Boundary
                Heave_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Washout
                Heave_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF6
                Heave_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_DeadZone
                Heave_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Boundary
                Heave_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Washout
                Heave_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Smoothing
                'Heave_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputHeave_Axis6)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputHeave_Axis6()
        Do While Output_Calulations_Running = True
            'Get Input
            Heave_Output_Axis6 = Heave_Input

            'DeadZone Filter
            Heave_Output_Axis6 = Heave_Filters_Axis6.DeadZone(Heave_Output_Axis6, Heave_Filter_DeadZone_Axis6)

            'Boundry filter 
            Heave_Output_Axis6 = Heave_Filters_Axis6.Boundry(Heave_Output_Axis6, Heave_Filter_Boundary_Axis6)

            'Washout filter
            Heave_Output_Axis6 = Heave_Filters_Axis6.WashoutAccel(Heave_Output_Axis6, Heave_Filter_Washout_Axis6)

            'Smoothing Filter
            Heave_Output_Axis6 = Heave_Filters_Axis6.Smoothing(Heave_Output_Axis6, Heave_Filter_Smoothing_Axis6)

            'Main Profile Smoothing
            'Heave_Output_Axis6 = Heave_Filters_Axis6.MainProfile_Smoothing(Heave_Output_Axis6, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputHeave_Axis6 = Heave_Output_Axis6

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Yaw_Axis1 _ Output"
    'Output and Filters
    Private Yaw_Output_Axis1 As Double
    Private Yaw_Filter_DeadZone_Axis1 As Integer
    Private Yaw_Filter_Boundary_Axis1 As Integer
    Private Yaw_Filter_Washout_Axis1 As Integer
    Private Yaw_Filter_Smoothing_Axis1 As Integer
    'Private Yaw_Filter_Rescaling_Axis1 As Integer
    Private Yaw_Filters_Axis1 As Cls_Filters
    Private Sub Start_OutputYaw_Axis1()
        'Create New Filter Object (resets object to default values)
        Yaw_Filters_Axis1 = New Cls_Filters

        'load the right DOF values
        Select Case "Yaw"
            Case Struct_AxisAssignments._Axis1DOF1
                Yaw_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_DeadZone
                Yaw_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Boundary
                Yaw_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Washout
                Yaw_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF2
                Yaw_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_DeadZone
                Yaw_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Boundary
                Yaw_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Washout
                Yaw_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF3
                Yaw_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_DeadZone
                Yaw_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Boundary
                Yaw_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Washout
                Yaw_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF4
                Yaw_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_DeadZone
                Yaw_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Boundary
                Yaw_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Washout
                Yaw_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF5
                Yaw_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_DeadZone
                Yaw_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Boundary
                Yaw_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Washout
                Yaw_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF6
                Yaw_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_DeadZone
                Yaw_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Boundary
                Yaw_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Washout
                Yaw_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputYaw_Axis1)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputYaw_Axis1()
        Do While Output_Calulations_Running = True
            'Get Input
            Yaw_Output_Axis1 = Yaw_Input

            'DeadZone Filter
            Yaw_Output_Axis1 = Yaw_Filters_Axis1.DeadZone(Yaw_Output_Axis1, Yaw_Filter_DeadZone_Axis1)

            'Boundry filter 
            Yaw_Output_Axis1 = Yaw_Filters_Axis1.Boundry(Yaw_Output_Axis1, Yaw_Filter_Boundary_Axis1)

            'Washout filter
            Yaw_Output_Axis1 = Yaw_Filters_Axis1.WashoutDeg(Yaw_Output_Axis1, Yaw_Filter_Washout_Axis1)

            'Smoothing Filter
            Yaw_Output_Axis1 = Yaw_Filters_Axis1.Smoothing(Yaw_Output_Axis1, Yaw_Filter_Smoothing_Axis1)

            'Main Profile Smoothing
            'Yaw_Output_Axis1 = Yaw_Filters_Axis1.MainProfile_Smoothing(Yaw_Output_Axis1, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputYaw_Axis1 = Yaw_Output_Axis1

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Yaw_Axis2 _ Output"
    'Output and Filters
    Private Yaw_Output_Axis2 As Double
    Private Yaw_Filter_DeadZone_Axis2 As Integer
    Private Yaw_Filter_Boundary_Axis2 As Integer
    Private Yaw_Filter_Washout_Axis2 As Integer
    Private Yaw_Filter_Smoothing_Axis2 As Integer
    'Private Yaw_Filter_Rescaling_Axis2 As Integer
    Private Yaw_Filters_Axis2 As Cls_Filters
    Private Sub Start_OutputYaw_Axis2()
        'Create New Filter Object (resets object to default values)
        Yaw_Filters_Axis2 = New Cls_Filters

        'load the right DOF values
        Select Case "Yaw"
            Case Struct_AxisAssignments._Axis2DOF1
                Yaw_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_DeadZone
                Yaw_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Boundary
                Yaw_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Washout
                Yaw_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF2
                Yaw_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_DeadZone
                Yaw_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Boundary
                Yaw_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Washout
                Yaw_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF3
                Yaw_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_DeadZone
                Yaw_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Boundary
                Yaw_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Washout
                Yaw_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF4
                Yaw_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_DeadZone
                Yaw_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Boundary
                Yaw_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Washout
                Yaw_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF5
                Yaw_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_DeadZone
                Yaw_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Boundary
                Yaw_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Washout
                Yaw_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF6
                Yaw_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_DeadZone
                Yaw_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Boundary
                Yaw_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Washout
                Yaw_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputYaw_Axis2)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputYaw_Axis2()
        Do While Output_Calulations_Running = True
            'Get Input
            Yaw_Output_Axis2 = Yaw_Input

            'DeadZone Filter
            Yaw_Output_Axis2 = Yaw_Filters_Axis2.DeadZone(Yaw_Output_Axis2, Yaw_Filter_DeadZone_Axis2)

            'Boundry filter 
            Yaw_Output_Axis2 = Yaw_Filters_Axis2.Boundry(Yaw_Output_Axis2, Yaw_Filter_Boundary_Axis2)

            'Washout filter
            Yaw_Output_Axis2 = Yaw_Filters_Axis2.WashoutDeg(Yaw_Output_Axis2, Yaw_Filter_Washout_Axis2)

            'Smoothing Filter
            Yaw_Output_Axis2 = Yaw_Filters_Axis2.Smoothing(Yaw_Output_Axis2, Yaw_Filter_Smoothing_Axis2)

            'Main Profile Smoothing
            'Yaw_Output_Axis2 = Yaw_Filters_Axis2.MainProfile_Smoothing(Yaw_Output_Axis2, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputYaw_Axis2 = Yaw_Output_Axis2

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Yaw_Axis3 _ Output"
    'Output and Filters
    Private Yaw_Output_Axis3 As Double
    Private Yaw_Filter_DeadZone_Axis3 As Integer
    Private Yaw_Filter_Boundary_Axis3 As Integer
    Private Yaw_Filter_Washout_Axis3 As Integer
    Private Yaw_Filter_Smoothing_Axis3 As Integer
    'Private Yaw_Filter_Rescaling_Axis3 As Integer
    Private Yaw_Filters_Axis3 As Cls_Filters
    Private Sub Start_OutputYaw_Axis3()
        'Create New Filter Object (resets object to default values)
        Yaw_Filters_Axis3 = New Cls_Filters

        'load the right DOF values
        Select Case "Yaw"
            Case Struct_AxisAssignments._Axis3DOF1
                Yaw_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_DeadZone
                Yaw_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Boundary
                Yaw_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Washout
                Yaw_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF2
                Yaw_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_DeadZone
                Yaw_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Boundary
                Yaw_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Washout
                Yaw_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF3
                Yaw_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_DeadZone
                Yaw_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Boundary
                Yaw_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Washout
                Yaw_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF4
                Yaw_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_DeadZone
                Yaw_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Boundary
                Yaw_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Washout
                Yaw_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF5
                Yaw_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_DeadZone
                Yaw_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Boundary
                Yaw_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Washout
                Yaw_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF6
                Yaw_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_DeadZone
                Yaw_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Boundary
                Yaw_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Washout
                Yaw_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputYaw_Axis3)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputYaw_Axis3()
        Do While Output_Calulations_Running = True
            'Get Input
            Yaw_Output_Axis3 = Yaw_Input

            'DeadZone Filter
            Yaw_Output_Axis3 = Yaw_Filters_Axis3.DeadZone(Yaw_Output_Axis3, Yaw_Filter_DeadZone_Axis3)

            'Boundry filter 
            Yaw_Output_Axis3 = Yaw_Filters_Axis3.Boundry(Yaw_Output_Axis3, Yaw_Filter_Boundary_Axis3)

            'Washout filter
            Yaw_Output_Axis3 = Yaw_Filters_Axis3.WashoutDeg(Yaw_Output_Axis3, Yaw_Filter_Washout_Axis3)

            'Smoothing Filter
            Yaw_Output_Axis3 = Yaw_Filters_Axis3.Smoothing(Yaw_Output_Axis3, Yaw_Filter_Smoothing_Axis3)

            'Main Profile Smoothing
            'Yaw_Output_Axis3 = Yaw_Filters_Axis3.MainProfile_Smoothing(Yaw_Output_Axis3, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputYaw_Axis3 = Yaw_Output_Axis3

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Yaw_Axis4 _ Output"
    'Output and Filters
    Private Yaw_Output_Axis4 As Double
    Private Yaw_Filter_DeadZone_Axis4 As Integer
    Private Yaw_Filter_Boundary_Axis4 As Integer
    Private Yaw_Filter_Washout_Axis4 As Integer
    Private Yaw_Filter_Smoothing_Axis4 As Integer
    'Private Yaw_Filter_Rescaling_Axis4 As Integer
    Private Yaw_Filters_Axis4 As Cls_Filters
    Private Sub Start_OutputYaw_Axis4()
        'Create New Filter Object (resets object to default values)
        Yaw_Filters_Axis4 = New Cls_Filters

        'load the right DOF values
        Select Case "Yaw"
            Case Struct_AxisAssignments._Axis4DOF1
                Yaw_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_DeadZone
                Yaw_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Boundary
                Yaw_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Washout
                Yaw_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF2
                Yaw_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_DeadZone
                Yaw_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Boundary
                Yaw_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Washout
                Yaw_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF3
                Yaw_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_DeadZone
                Yaw_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Boundary
                Yaw_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Washout
                Yaw_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF4
                Yaw_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_DeadZone
                Yaw_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Boundary
                Yaw_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Washout
                Yaw_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF5
                Yaw_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_DeadZone
                Yaw_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Boundary
                Yaw_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Washout
                Yaw_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF6
                Yaw_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_DeadZone
                Yaw_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Boundary
                Yaw_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Washout
                Yaw_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputYaw_Axis4)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputYaw_Axis4()
        Do While Output_Calulations_Running = True
            'Get Input
            Yaw_Output_Axis4 = Yaw_Input

            'DeadZone Filter
            Yaw_Output_Axis4 = Yaw_Filters_Axis4.DeadZone(Yaw_Output_Axis4, Yaw_Filter_DeadZone_Axis4)

            'Boundry filter 
            Yaw_Output_Axis4 = Yaw_Filters_Axis4.Boundry(Yaw_Output_Axis4, Yaw_Filter_Boundary_Axis4)

            'Washout filter
            Yaw_Output_Axis4 = Yaw_Filters_Axis4.WashoutDeg(Yaw_Output_Axis4, Yaw_Filter_Washout_Axis4)

            'Smoothing Filter
            Yaw_Output_Axis4 = Yaw_Filters_Axis4.Smoothing(Yaw_Output_Axis4, Yaw_Filter_Smoothing_Axis4)

            'Main Profile Smoothing
            'Yaw_Output_Axis4 = Yaw_Filters_Axis4.MainProfile_Smoothing(Yaw_Output_Axis4, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputYaw_Axis4 = Yaw_Output_Axis4

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Yaw_Axis5 _ Output"
    'Output and Filters
    Private Yaw_Output_Axis5 As Double
    Private Yaw_Filter_DeadZone_Axis5 As Integer
    Private Yaw_Filter_Boundary_Axis5 As Integer
    Private Yaw_Filter_Washout_Axis5 As Integer
    Private Yaw_Filter_Smoothing_Axis5 As Integer
    'Private Yaw_Filter_Rescaling_Axis5 As Integer
    Private Yaw_Filters_Axis5 As Cls_Filters
    Private Sub Start_OutputYaw_Axis5()
        'Create New Filter Object (resets object to default values)
        Yaw_Filters_Axis5 = New Cls_Filters

        'load the right DOF values
        Select Case "Yaw"
            Case Struct_AxisAssignments._Axis5DOF1
                Yaw_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_DeadZone
                Yaw_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Boundary
                Yaw_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Washout
                Yaw_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF2
                Yaw_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_DeadZone
                Yaw_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Boundary
                Yaw_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Washout
                Yaw_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF3
                Yaw_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_DeadZone
                Yaw_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Boundary
                Yaw_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Washout
                Yaw_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF4
                Yaw_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_DeadZone
                Yaw_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Boundary
                Yaw_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Washout
                Yaw_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF5
                Yaw_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_DeadZone
                Yaw_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Boundary
                Yaw_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Washout
                Yaw_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF6
                Yaw_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_DeadZone
                Yaw_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Boundary
                Yaw_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Washout
                Yaw_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputYaw_Axis5)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputYaw_Axis5()
        Do While Output_Calulations_Running = True
            'Get Input
            Yaw_Output_Axis5 = Yaw_Input

            'DeadZone Filter
            Yaw_Output_Axis5 = Yaw_Filters_Axis5.DeadZone(Yaw_Output_Axis5, Yaw_Filter_DeadZone_Axis5)

            'Boundry filter 
            Yaw_Output_Axis5 = Yaw_Filters_Axis5.Boundry(Yaw_Output_Axis5, Yaw_Filter_Boundary_Axis5)

            'Washout filter
            Yaw_Output_Axis5 = Yaw_Filters_Axis5.WashoutDeg(Yaw_Output_Axis5, Yaw_Filter_Washout_Axis5)

            'Smoothing Filter
            Yaw_Output_Axis5 = Yaw_Filters_Axis5.Smoothing(Yaw_Output_Axis5, Yaw_Filter_Smoothing_Axis5)

            'Main Profile Smoothing
            'Yaw_Output_Axis5 = Yaw_Filters_Axis5.MainProfile_Smoothing(Yaw_Output_Axis5, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputYaw_Axis5 = Yaw_Output_Axis5

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Yaw_Axis6 _ Output"
    'Output and Filters
    Private Yaw_Output_Axis6 As Double
    Private Yaw_Filter_DeadZone_Axis6 As Integer
    Private Yaw_Filter_Boundary_Axis6 As Integer
    Private Yaw_Filter_Washout_Axis6 As Integer
    Private Yaw_Filter_Smoothing_Axis6 As Integer
    'Private Yaw_Filter_Rescaling_Axis6 As Integer
    Private Yaw_Filters_Axis6 As Cls_Filters
    Private Sub Start_OutputYaw_Axis6()
        'Create New Filter Object (resets object to default values)
        Yaw_Filters_Axis6 = New Cls_Filters

        'load the right DOF values
        Select Case "Yaw"
            Case Struct_AxisAssignments._Axis6DOF1
                Yaw_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_DeadZone
                Yaw_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Boundary
                Yaw_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Washout
                Yaw_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF2
                Yaw_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_DeadZone
                Yaw_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Boundary
                Yaw_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Washout
                Yaw_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF3
                Yaw_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_DeadZone
                Yaw_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Boundary
                Yaw_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Washout
                Yaw_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF4
                Yaw_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_DeadZone
                Yaw_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Boundary
                Yaw_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Washout
                Yaw_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF5
                Yaw_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_DeadZone
                Yaw_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Boundary
                Yaw_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Washout
                Yaw_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF6
                Yaw_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_DeadZone
                Yaw_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Boundary
                Yaw_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Washout
                Yaw_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Smoothing
                'Yaw_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputYaw_Axis6)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputYaw_Axis6()
        Do While Output_Calulations_Running = True
            'Get Input
            Yaw_Output_Axis6 = Yaw_Input

            'DeadZone Filter
            Yaw_Output_Axis6 = Yaw_Filters_Axis6.DeadZone(Yaw_Output_Axis6, Yaw_Filter_DeadZone_Axis6)

            'Boundry filter 
            Yaw_Output_Axis6 = Yaw_Filters_Axis6.Boundry(Yaw_Output_Axis6, Yaw_Filter_Boundary_Axis6)

            'Washout filter
            Yaw_Output_Axis6 = Yaw_Filters_Axis6.WashoutDeg(Yaw_Output_Axis6, Yaw_Filter_Washout_Axis6)

            'Smoothing Filter
            Yaw_Output_Axis6 = Yaw_Filters_Axis6.Smoothing(Yaw_Output_Axis6, Yaw_Filter_Smoothing_Axis6)

            'Main Profile Smoothing
            'Yaw_Output_Axis6 = Yaw_Filters_Axis6.MainProfile_Smoothing(Yaw_Output_Axis6, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputYaw_Axis6 = Yaw_Output_Axis6

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Sway_Axis1 _ Output"
    'Output and Filters
    Private Sway_Output_Axis1 As Double
    Private Sway_Filter_DeadZone_Axis1 As Integer
    Private Sway_Filter_Boundary_Axis1 As Integer
    Private Sway_Filter_Washout_Axis1 As Integer
    Private Sway_Filter_Smoothing_Axis1 As Integer
    'Private Sway_Filter_Rescaling_Axis1 As Integer
    Private Sway_Filters_Axis1 As Cls_Filters
    Private Sub Start_OutputSway_Axis1()
        'Create New Filter Object (resets object to default values)
        Sway_Filters_Axis1 = New Cls_Filters

        'load the right DOF values
        Select Case "Sway"
            Case Struct_AxisAssignments._Axis1DOF1
                Sway_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_DeadZone
                Sway_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Boundary
                Sway_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Washout
                Sway_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF2
                Sway_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_DeadZone
                Sway_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Boundary
                Sway_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Washout
                Sway_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF3
                Sway_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_DeadZone
                Sway_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Boundary
                Sway_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Washout
                Sway_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF4
                Sway_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_DeadZone
                Sway_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Boundary
                Sway_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Washout
                Sway_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF5
                Sway_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_DeadZone
                Sway_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Boundary
                Sway_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Washout
                Sway_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF6
                Sway_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_DeadZone
                Sway_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Boundary
                Sway_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Washout
                Sway_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSway_Axis1)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSway_Axis1()
        Do While Output_Calulations_Running = True
            'Get Input
            Sway_Output_Axis1 = Sway_Input

            'DeadZone Filter
            Sway_Output_Axis1 = Sway_Filters_Axis1.DeadZone(Sway_Output_Axis1, Sway_Filter_DeadZone_Axis1)

            'Boundry filter 
            Sway_Output_Axis1 = Sway_Filters_Axis1.Boundry(Sway_Output_Axis1, Sway_Filter_Boundary_Axis1)

            'Washout filter
            Sway_Output_Axis1 = Sway_Filters_Axis1.WashoutAccel(Sway_Output_Axis1, Sway_Filter_Washout_Axis1)

            'Smoothing Filter
            Sway_Output_Axis1 = Sway_Filters_Axis1.Smoothing(Sway_Output_Axis1, Sway_Filter_Smoothing_Axis1)

            'Main Profile Smoothing
            'Sway_Output_Axis1 = Sway_Filters_Axis1.MainProfile_Smoothing(Sway_Output_Axis1, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSway_Axis1 = Sway_Output_Axis1

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Sway_Axis2 _ Output"
    'Output and Filters
    Private Sway_Output_Axis2 As Double
    Private Sway_Filter_DeadZone_Axis2 As Integer
    Private Sway_Filter_Boundary_Axis2 As Integer
    Private Sway_Filter_Washout_Axis2 As Integer
    Private Sway_Filter_Smoothing_Axis2 As Integer
    'Private Sway_Filter_Rescaling_Axis2 As Integer
    Private Sway_Filters_Axis2 As Cls_Filters
    Private Sub Start_OutputSway_Axis2()
        'Create New Filter Object (resets object to default values)
        Sway_Filters_Axis2 = New Cls_Filters

        'load the right DOF values
        Select Case "Sway"
            Case Struct_AxisAssignments._Axis2DOF1
                Sway_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_DeadZone
                Sway_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Boundary
                Sway_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Washout
                Sway_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF2
                Sway_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_DeadZone
                Sway_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Boundary
                Sway_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Washout
                Sway_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF3
                Sway_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_DeadZone
                Sway_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Boundary
                Sway_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Washout
                Sway_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF4
                Sway_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_DeadZone
                Sway_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Boundary
                Sway_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Washout
                Sway_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF5
                Sway_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_DeadZone
                Sway_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Boundary
                Sway_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Washout
                Sway_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF6
                Sway_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_DeadZone
                Sway_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Boundary
                Sway_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Washout
                Sway_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSway_Axis2)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSway_Axis2()
        Do While Output_Calulations_Running = True
            'Get Input
            Sway_Output_Axis2 = Sway_Input

            'DeadZone Filter
            Sway_Output_Axis2 = Sway_Filters_Axis2.DeadZone(Sway_Output_Axis2, Sway_Filter_DeadZone_Axis2)

            'Boundry filter 
            Sway_Output_Axis2 = Sway_Filters_Axis2.Boundry(Sway_Output_Axis2, Sway_Filter_Boundary_Axis2)

            'Washout filter
            Sway_Output_Axis2 = Sway_Filters_Axis2.WashoutAccel(Sway_Output_Axis2, Sway_Filter_Washout_Axis2)

            'Smoothing Filter
            Sway_Output_Axis2 = Sway_Filters_Axis2.Smoothing(Sway_Output_Axis2, Sway_Filter_Smoothing_Axis2)

            'Main Profile Smoothing
            'Sway_Output_Axis2 = Sway_Filters_Axis2.MainProfile_Smoothing(Sway_Output_Axis2, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSway_Axis2 = Sway_Output_Axis2

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Sway_Axis3 _ Output"
    'Output and Filters
    Private Sway_Output_Axis3 As Double
    Private Sway_Filter_DeadZone_Axis3 As Integer
    Private Sway_Filter_Boundary_Axis3 As Integer
    Private Sway_Filter_Washout_Axis3 As Integer
    Private Sway_Filter_Smoothing_Axis3 As Integer
    'Private Sway_Filter_Rescaling_Axis3 As Integer
    Private Sway_Filters_Axis3 As Cls_Filters
    Private Sub Start_OutputSway_Axis3()
        'Create New Filter Object (resets object to default values)
        Sway_Filters_Axis3 = New Cls_Filters

        'load the right DOF values
        Select Case "Sway"
            Case Struct_AxisAssignments._Axis3DOF1
                Sway_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_DeadZone
                Sway_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Boundary
                Sway_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Washout
                Sway_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF2
                Sway_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_DeadZone
                Sway_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Boundary
                Sway_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Washout
                Sway_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF3
                Sway_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_DeadZone
                Sway_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Boundary
                Sway_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Washout
                Sway_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF4
                Sway_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_DeadZone
                Sway_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Boundary
                Sway_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Washout
                Sway_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF5
                Sway_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_DeadZone
                Sway_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Boundary
                Sway_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Washout
                Sway_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF6
                Sway_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_DeadZone
                Sway_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Boundary
                Sway_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Washout
                Sway_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSway_Axis3)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSway_Axis3()
        Do While Output_Calulations_Running = True
            'Get Input
            Sway_Output_Axis3 = Sway_Input

            'DeadZone Filter
            Sway_Output_Axis3 = Sway_Filters_Axis3.DeadZone(Sway_Output_Axis3, Sway_Filter_DeadZone_Axis3)

            'Boundry filter 
            Sway_Output_Axis3 = Sway_Filters_Axis3.Boundry(Sway_Output_Axis3, Sway_Filter_Boundary_Axis3)

            'Washout filter
            Sway_Output_Axis3 = Sway_Filters_Axis3.WashoutAccel(Sway_Output_Axis3, Sway_Filter_Washout_Axis3)

            'Smoothing Filter
            Sway_Output_Axis3 = Sway_Filters_Axis3.Smoothing(Sway_Output_Axis3, Sway_Filter_Smoothing_Axis3)

            'Main Profile Smoothing
            'Sway_Output_Axis3 = Sway_Filters_Axis3.MainProfile_Smoothing(Sway_Output_Axis3, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSway_Axis3 = Sway_Output_Axis3

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Sway_Axis4 _ Output"
    'Output and Filters
    Private Sway_Output_Axis4 As Double
    Private Sway_Filter_DeadZone_Axis4 As Integer
    Private Sway_Filter_Boundary_Axis4 As Integer
    Private Sway_Filter_Washout_Axis4 As Integer
    Private Sway_Filter_Smoothing_Axis4 As Integer
    'Private Sway_Filter_Rescaling_Axis4 As Integer
    Private Sway_Filters_Axis4 As Cls_Filters
    Private Sub Start_OutputSway_Axis4()
        'Create New Filter Object (resets object to default values)
        Sway_Filters_Axis4 = New Cls_Filters

        'load the right DOF values
        Select Case "Sway"
            Case Struct_AxisAssignments._Axis4DOF1
                Sway_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_DeadZone
                Sway_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Boundary
                Sway_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Washout
                Sway_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF2
                Sway_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_DeadZone
                Sway_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Boundary
                Sway_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Washout
                Sway_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF3
                Sway_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_DeadZone
                Sway_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Boundary
                Sway_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Washout
                Sway_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF4
                Sway_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_DeadZone
                Sway_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Boundary
                Sway_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Washout
                Sway_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF5
                Sway_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_DeadZone
                Sway_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Boundary
                Sway_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Washout
                Sway_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF6
                Sway_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_DeadZone
                Sway_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Boundary
                Sway_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Washout
                Sway_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSway_Axis4)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSway_Axis4()
        Do While Output_Calulations_Running = True
            'Get Input
            Sway_Output_Axis4 = Sway_Input

            'DeadZone Filter
            Sway_Output_Axis4 = Sway_Filters_Axis4.DeadZone(Sway_Output_Axis4, Sway_Filter_DeadZone_Axis4)

            'Boundry filter 
            Sway_Output_Axis4 = Sway_Filters_Axis4.Boundry(Sway_Output_Axis4, Sway_Filter_Boundary_Axis4)

            'Washout filter
            Sway_Output_Axis4 = Sway_Filters_Axis4.WashoutAccel(Sway_Output_Axis4, Sway_Filter_Washout_Axis4)

            'Smoothing Filter
            Sway_Output_Axis4 = Sway_Filters_Axis4.Smoothing(Sway_Output_Axis4, Sway_Filter_Smoothing_Axis4)

            'Main Profile Smoothing
            'Sway_Output_Axis4 = Sway_Filters_Axis4.MainProfile_Smoothing(Sway_Output_Axis4, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSway_Axis4 = Sway_Output_Axis4

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Sway_Axis5 _ Output"
    'Output and Filters
    Private Sway_Output_Axis5 As Double
    Private Sway_Filter_DeadZone_Axis5 As Integer
    Private Sway_Filter_Boundary_Axis5 As Integer
    Private Sway_Filter_Washout_Axis5 As Integer
    Private Sway_Filter_Smoothing_Axis5 As Integer
    'Private Sway_Filter_Rescaling_Axis5 As Integer
    Private Sway_Filters_Axis5 As Cls_Filters
    Private Sub Start_OutputSway_Axis5()
        'Create New Filter Object (resets object to default values)
        Sway_Filters_Axis5 = New Cls_Filters

        'load the right DOF values
        Select Case "Sway"
            Case Struct_AxisAssignments._Axis5DOF1
                Sway_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_DeadZone
                Sway_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Boundary
                Sway_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Washout
                Sway_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF2
                Sway_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_DeadZone
                Sway_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Boundary
                Sway_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Washout
                Sway_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF3
                Sway_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_DeadZone
                Sway_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Boundary
                Sway_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Washout
                Sway_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF4
                Sway_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_DeadZone
                Sway_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Boundary
                Sway_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Washout
                Sway_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF5
                Sway_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_DeadZone
                Sway_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Boundary
                Sway_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Washout
                Sway_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF6
                Sway_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_DeadZone
                Sway_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Boundary
                Sway_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Washout
                Sway_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSway_Axis5)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSway_Axis5()
        Do While Output_Calulations_Running = True
            'Get Input
            Sway_Output_Axis5 = Sway_Input

            'DeadZone Filter
            Sway_Output_Axis5 = Sway_Filters_Axis5.DeadZone(Sway_Output_Axis5, Sway_Filter_DeadZone_Axis5)

            'Boundry filter 
            Sway_Output_Axis5 = Sway_Filters_Axis5.Boundry(Sway_Output_Axis5, Sway_Filter_Boundary_Axis5)

            'Washout filter
            Sway_Output_Axis5 = Sway_Filters_Axis5.WashoutAccel(Sway_Output_Axis5, Sway_Filter_Washout_Axis5)

            'Smoothing Filter
            Sway_Output_Axis5 = Sway_Filters_Axis5.Smoothing(Sway_Output_Axis5, Sway_Filter_Smoothing_Axis5)

            'Main Profile Smoothing
            'Sway_Output_Axis5 = Sway_Filters_Axis5.MainProfile_Smoothing(Sway_Output_Axis5, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSway_Axis5 = Sway_Output_Axis5

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Sway_Axis6 _ Output"
    'Output and Filters
    Private Sway_Output_Axis6 As Double
    Private Sway_Filter_DeadZone_Axis6 As Integer
    Private Sway_Filter_Boundary_Axis6 As Integer
    Private Sway_Filter_Washout_Axis6 As Integer
    Private Sway_Filter_Smoothing_Axis6 As Integer
    'Private Sway_Filter_Rescaling_Axis6 As Integer
    Private Sway_Filters_Axis6 As Cls_Filters
    Private Sub Start_OutputSway_Axis6()
        'Create New Filter Object (resets object to default values)
        Sway_Filters_Axis6 = New Cls_Filters

        'load the right DOF values
        Select Case "Sway"
            Case Struct_AxisAssignments._Axis6DOF1
                Sway_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_DeadZone
                Sway_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Boundary
                Sway_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Washout
                Sway_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF2
                Sway_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_DeadZone
                Sway_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Boundary
                Sway_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Washout
                Sway_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF3
                Sway_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_DeadZone
                Sway_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Boundary
                Sway_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Washout
                Sway_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF4
                Sway_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_DeadZone
                Sway_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Boundary
                Sway_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Washout
                Sway_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF5
                Sway_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_DeadZone
                Sway_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Boundary
                Sway_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Washout
                Sway_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF6
                Sway_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_DeadZone
                Sway_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Boundary
                Sway_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Washout
                Sway_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Smoothing
                'Sway_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSway_Axis6)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSway_Axis6()
        Do While Output_Calulations_Running = True
            'Get Input
            Sway_Output_Axis6 = Sway_Input

            'DeadZone Filter
            Sway_Output_Axis6 = Sway_Filters_Axis6.DeadZone(Sway_Output_Axis6, Sway_Filter_DeadZone_Axis6)

            'Boundry filter 
            Sway_Output_Axis6 = Sway_Filters_Axis6.Boundry(Sway_Output_Axis6, Sway_Filter_Boundary_Axis6)

            'Washout filter
            Sway_Output_Axis6 = Sway_Filters_Axis6.WashoutAccel(Sway_Output_Axis6, Sway_Filter_Washout_Axis6)

            'Smoothing Filter
            Sway_Output_Axis6 = Sway_Filters_Axis6.Smoothing(Sway_Output_Axis6, Sway_Filter_Smoothing_Axis6)

            'Main Profile Smoothing
            'Sway_Output_Axis6 = Sway_Filters_Axis6.MainProfile_Smoothing(Sway_Output_Axis6, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSway_Axis6 = Sway_Output_Axis6

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Surge_Axis1 _ Output"
    'Output and Filters
    Private Surge_Output_Axis1 As Double
    Private Surge_Filter_DeadZone_Axis1 As Integer
    Private Surge_Filter_Boundary_Axis1 As Integer
    Private Surge_Filter_Washout_Axis1 As Integer
    Private Surge_Filter_Smoothing_Axis1 As Integer
    'Private Surge_Filter_Rescaling_Axis1 As Integer
    Private Surge_Filters_Axis1 As Cls_Filters
    Private Sub Start_OutputSurge_Axis1()
        'Create New Filter Object (resets object to default values)
        Surge_Filters_Axis1 = New Cls_Filters

        'load the right DOF values
        Select Case "Surge"
            Case Struct_AxisAssignments._Axis1DOF1
                Surge_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_DeadZone
                Surge_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Boundary
                Surge_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Washout
                Surge_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF2
                Surge_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_DeadZone
                Surge_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Boundary
                Surge_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Washout
                Surge_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF3
                Surge_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_DeadZone
                Surge_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Boundary
                Surge_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Washout
                Surge_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF4
                Surge_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_DeadZone
                Surge_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Boundary
                Surge_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Washout
                Surge_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF5
                Surge_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_DeadZone
                Surge_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Boundary
                Surge_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Washout
                Surge_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF6
                Surge_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_DeadZone
                Surge_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Boundary
                Surge_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Washout
                Surge_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSurge_Axis1)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSurge_Axis1()
        Do While Output_Calulations_Running = True
            'Get Input
            Surge_Output_Axis1 = Surge_Input

            'DeadZone Filter
            Surge_Output_Axis1 = Surge_Filters_Axis1.DeadZone(Surge_Output_Axis1, Surge_Filter_DeadZone_Axis1)

            'Boundry filter 
            Surge_Output_Axis1 = Surge_Filters_Axis1.Boundry(Surge_Output_Axis1, Surge_Filter_Boundary_Axis1)

            'Washout filter
            Surge_Output_Axis1 = Surge_Filters_Axis1.WashoutAccel(Surge_Output_Axis1, Surge_Filter_Washout_Axis1)

            'Smoothing Filter
            Surge_Output_Axis1 = Surge_Filters_Axis1.Smoothing(Surge_Output_Axis1, Surge_Filter_Smoothing_Axis1)

            'Main Profile Smoothing
            'Surge_Output_Axis1 = Surge_Filters_Axis1.MainProfile_Smoothing(Surge_Output_Axis1, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSurge_Axis1 = Surge_Output_Axis1

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Surge_Axis2 _ Output"
    'Output and Filters
    Private Surge_Output_Axis2 As Double
    Private Surge_Filter_DeadZone_Axis2 As Integer
    Private Surge_Filter_Boundary_Axis2 As Integer
    Private Surge_Filter_Washout_Axis2 As Integer
    Private Surge_Filter_Smoothing_Axis2 As Integer
    'Private Surge_Filter_Rescaling_Axis2 As Integer
    Private Surge_Filters_Axis2 As Cls_Filters
    Private Sub Start_OutputSurge_Axis2()
        'Create New Filter Object (resets object to default values)
        Surge_Filters_Axis2 = New Cls_Filters

        'load the right DOF values
        Select Case "Surge"
            Case Struct_AxisAssignments._Axis2DOF1
                Surge_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_DeadZone
                Surge_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Boundary
                Surge_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Washout
                Surge_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF2
                Surge_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_DeadZone
                Surge_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Boundary
                Surge_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Washout
                Surge_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF3
                Surge_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_DeadZone
                Surge_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Boundary
                Surge_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Washout
                Surge_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF4
                Surge_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_DeadZone
                Surge_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Boundary
                Surge_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Washout
                Surge_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF5
                Surge_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_DeadZone
                Surge_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Boundary
                Surge_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Washout
                Surge_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF6
                Surge_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_DeadZone
                Surge_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Boundary
                Surge_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Washout
                Surge_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSurge_Axis2)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSurge_Axis2()
        Do While Output_Calulations_Running = True
            'Get Input
            Surge_Output_Axis2 = Surge_Input

            'DeadZone Filter
            Surge_Output_Axis2 = Surge_Filters_Axis2.DeadZone(Surge_Output_Axis2, Surge_Filter_DeadZone_Axis2)

            'Boundry filter 
            Surge_Output_Axis2 = Surge_Filters_Axis2.Boundry(Surge_Output_Axis2, Surge_Filter_Boundary_Axis2)

            'Washout filter
            Surge_Output_Axis2 = Surge_Filters_Axis2.WashoutAccel(Surge_Output_Axis2, Surge_Filter_Washout_Axis2)

            'Smoothing Filter
            Surge_Output_Axis2 = Surge_Filters_Axis2.Smoothing(Surge_Output_Axis2, Surge_Filter_Smoothing_Axis2)

            'Main Profile Smoothing
            'Surge_Output_Axis2 = Surge_Filters_Axis2.MainProfile_Smoothing(Surge_Output_Axis2, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSurge_Axis2 = Surge_Output_Axis2

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Surge_Axis3 _ Output"
    'Output and Filters
    Private Surge_Output_Axis3 As Double
    Private Surge_Filter_DeadZone_Axis3 As Integer
    Private Surge_Filter_Boundary_Axis3 As Integer
    Private Surge_Filter_Washout_Axis3 As Integer
    Private Surge_Filter_Smoothing_Axis3 As Integer
    'Private Surge_Filter_Rescaling_Axis3 As Integer
    Private Surge_Filters_Axis3 As Cls_Filters
    Private Sub Start_OutputSurge_Axis3()
        'Create New Filter Object (resets object to default values)
        Surge_Filters_Axis3 = New Cls_Filters

        'load the right DOF values
        Select Case "Surge"
            Case Struct_AxisAssignments._Axis3DOF1
                Surge_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_DeadZone
                Surge_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Boundary
                Surge_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Washout
                Surge_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF2
                Surge_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_DeadZone
                Surge_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Boundary
                Surge_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Washout
                Surge_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF3
                Surge_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_DeadZone
                Surge_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Boundary
                Surge_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Washout
                Surge_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF4
                Surge_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_DeadZone
                Surge_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Boundary
                Surge_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Washout
                Surge_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF5
                Surge_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_DeadZone
                Surge_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Boundary
                Surge_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Washout
                Surge_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF6
                Surge_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_DeadZone
                Surge_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Boundary
                Surge_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Washout
                Surge_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSurge_Axis3)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSurge_Axis3()
        Do While Output_Calulations_Running = True
            'Get Input
            Surge_Output_Axis3 = Surge_Input

            'DeadZone Filter
            Surge_Output_Axis3 = Surge_Filters_Axis3.DeadZone(Surge_Output_Axis3, Surge_Filter_DeadZone_Axis3)

            'Boundry filter 
            Surge_Output_Axis3 = Surge_Filters_Axis3.Boundry(Surge_Output_Axis3, Surge_Filter_Boundary_Axis3)

            'Washout filter
            Surge_Output_Axis3 = Surge_Filters_Axis3.WashoutAccel(Surge_Output_Axis3, Surge_Filter_Washout_Axis3)

            'Smoothing Filter
            Surge_Output_Axis3 = Surge_Filters_Axis3.Smoothing(Surge_Output_Axis3, Surge_Filter_Smoothing_Axis3)

            'Main Profile Smoothing
            'Surge_Output_Axis3 = Surge_Filters_Axis3.MainProfile_Smoothing(Surge_Output_Axis3, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSurge_Axis3 = Surge_Output_Axis3

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Surge_Axis4 _ Output"
    'Output and Filters
    Private Surge_Output_Axis4 As Double
    Private Surge_Filter_DeadZone_Axis4 As Integer
    Private Surge_Filter_Boundary_Axis4 As Integer
    Private Surge_Filter_Washout_Axis4 As Integer
    Private Surge_Filter_Smoothing_Axis4 As Integer
    'Private Surge_Filter_Rescaling_Axis4 As Integer
    Private Surge_Filters_Axis4 As Cls_Filters
    Private Sub Start_OutputSurge_Axis4()
        'Create New Filter Object (resets object to default values)
        Surge_Filters_Axis4 = New Cls_Filters

        'load the right DOF values
        Select Case "Surge"
            Case Struct_AxisAssignments._Axis4DOF1
                Surge_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_DeadZone
                Surge_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Boundary
                Surge_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Washout
                Surge_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF2
                Surge_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_DeadZone
                Surge_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Boundary
                Surge_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Washout
                Surge_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF3
                Surge_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_DeadZone
                Surge_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Boundary
                Surge_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Washout
                Surge_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF4
                Surge_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_DeadZone
                Surge_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Boundary
                Surge_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Washout
                Surge_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF5
                Surge_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_DeadZone
                Surge_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Boundary
                Surge_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Washout
                Surge_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF6
                Surge_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_DeadZone
                Surge_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Boundary
                Surge_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Washout
                Surge_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSurge_Axis4)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSurge_Axis4()
        Do While Output_Calulations_Running = True
            'Get Input
            Surge_Output_Axis4 = Surge_Input

            'DeadZone Filter
            Surge_Output_Axis4 = Surge_Filters_Axis4.DeadZone(Surge_Output_Axis4, Surge_Filter_DeadZone_Axis4)

            'Boundry filter 
            Surge_Output_Axis4 = Surge_Filters_Axis4.Boundry(Surge_Output_Axis4, Surge_Filter_Boundary_Axis4)

            'Washout filter
            Surge_Output_Axis4 = Surge_Filters_Axis4.WashoutAccel(Surge_Output_Axis4, Surge_Filter_Washout_Axis4)

            'Smoothing Filter
            Surge_Output_Axis4 = Surge_Filters_Axis4.Smoothing(Surge_Output_Axis4, Surge_Filter_Smoothing_Axis4)

            'Main Profile Smoothing
            'Surge_Output_Axis4 = Surge_Filters_Axis4.MainProfile_Smoothing(Surge_Output_Axis4, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSurge_Axis4 = Surge_Output_Axis4

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Surge_Axis5 _ Output"
    'Output and Filters
    Private Surge_Output_Axis5 As Double
    Private Surge_Filter_DeadZone_Axis5 As Integer
    Private Surge_Filter_Boundary_Axis5 As Integer
    Private Surge_Filter_Washout_Axis5 As Integer
    Private Surge_Filter_Smoothing_Axis5 As Integer
    'Private Surge_Filter_Rescaling_Axis5 As Integer
    Private Surge_Filters_Axis5 As Cls_Filters
    Private Sub Start_OutputSurge_Axis5()
        'Create New Filter Object (resets object to default values)
        Surge_Filters_Axis5 = New Cls_Filters

        'load the right DOF values
        Select Case "Surge"
            Case Struct_AxisAssignments._Axis5DOF1
                Surge_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_DeadZone
                Surge_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Boundary
                Surge_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Washout
                Surge_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF2
                Surge_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_DeadZone
                Surge_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Boundary
                Surge_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Washout
                Surge_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF3
                Surge_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_DeadZone
                Surge_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Boundary
                Surge_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Washout
                Surge_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF4
                Surge_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_DeadZone
                Surge_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Boundary
                Surge_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Washout
                Surge_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF5
                Surge_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_DeadZone
                Surge_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Boundary
                Surge_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Washout
                Surge_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF6
                Surge_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_DeadZone
                Surge_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Boundary
                Surge_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Washout
                Surge_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSurge_Axis5)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSurge_Axis5()
        Do While Output_Calulations_Running = True
            'Get Input
            Surge_Output_Axis5 = Surge_Input

            'DeadZone Filter
            Surge_Output_Axis5 = Surge_Filters_Axis5.DeadZone(Surge_Output_Axis5, Surge_Filter_DeadZone_Axis5)

            'Boundry filter 
            Surge_Output_Axis5 = Surge_Filters_Axis5.Boundry(Surge_Output_Axis5, Surge_Filter_Boundary_Axis5)

            'Washout filter
            Surge_Output_Axis5 = Surge_Filters_Axis5.WashoutAccel(Surge_Output_Axis5, Surge_Filter_Washout_Axis5)

            'Smoothing Filter
            Surge_Output_Axis5 = Surge_Filters_Axis5.Smoothing(Surge_Output_Axis5, Surge_Filter_Smoothing_Axis5)

            'Main Profile Smoothing
            'Surge_Output_Axis5 = Surge_Filters_Axis5.MainProfile_Smoothing(Surge_Output_Axis5, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSurge_Axis5 = Surge_Output_Axis5

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Surge_Axis6 _ Output"
    'Output and Filters
    Private Surge_Output_Axis6 As Double
    Private Surge_Filter_DeadZone_Axis6 As Integer
    Private Surge_Filter_Boundary_Axis6 As Integer
    Private Surge_Filter_Washout_Axis6 As Integer
    Private Surge_Filter_Smoothing_Axis6 As Integer
    'Private Surge_Filter_Rescaling_Axis6 As Integer
    Private Surge_Filters_Axis6 As Cls_Filters
    Private Sub Start_OutputSurge_Axis6()
        'Create New Filter Object (resets object to default values)
        Surge_Filters_Axis6 = New Cls_Filters

        'load the right DOF values
        Select Case "Surge"
            Case Struct_AxisAssignments._Axis6DOF1
                Surge_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_DeadZone
                Surge_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Boundary
                Surge_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Washout
                Surge_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF2
                Surge_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_DeadZone
                Surge_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Boundary
                Surge_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Washout
                Surge_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF3
                Surge_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_DeadZone
                Surge_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Boundary
                Surge_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Washout
                Surge_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF4
                Surge_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_DeadZone
                Surge_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Boundary
                Surge_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Washout
                Surge_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF5
                Surge_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_DeadZone
                Surge_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Boundary
                Surge_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Washout
                Surge_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF6
                Surge_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_DeadZone
                Surge_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Boundary
                Surge_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Washout
                Surge_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Smoothing
                'Surge_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputSurge_Axis6)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputSurge_Axis6()
        Do While Output_Calulations_Running = True
            'Get Input
            Surge_Output_Axis6 = Surge_Input

            'DeadZone Filter
            Surge_Output_Axis6 = Surge_Filters_Axis6.DeadZone(Surge_Output_Axis6, Surge_Filter_DeadZone_Axis6)

            'Boundry filter 
            Surge_Output_Axis6 = Surge_Filters_Axis6.Boundry(Surge_Output_Axis6, Surge_Filter_Boundary_Axis6)

            'Washout filter
            Surge_Output_Axis6 = Surge_Filters_Axis6.WashoutAccel(Surge_Output_Axis6, Surge_Filter_Washout_Axis6)

            'Smoothing Filter
            Surge_Output_Axis6 = Surge_Filters_Axis6.Smoothing(Surge_Output_Axis6, Surge_Filter_Smoothing_Axis6)

            'Main Profile Smoothing
            'Surge_Output_Axis6 = Surge_Filters_Axis6.MainProfile_Smoothing(Surge_Output_Axis6, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputSurge_Axis6 = Surge_Output_Axis6

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra1_Axis1 _ Output"
    'Output and Filters
    Private Extra1_Output_Axis1 As Double
    Private Extra1_Filter_DeadZone_Axis1 As Integer
    Private Extra1_Filter_Boundary_Axis1 As Integer
    Private Extra1_Filter_Washout_Axis1 As Integer
    Private Extra1_Filter_Smoothing_Axis1 As Integer
    'Private Extra1_Filter_Rescaling_Axis1 As Integer
    Private Extra1_Filters_Axis1 As Cls_Filters
    Private Sub Start_OutputExtra1_Axis1()
        'Create New Filter Object (resets object to default values)
        Extra1_Filters_Axis1 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra1"
            Case Struct_AxisAssignments._Axis1DOF1
                Extra1_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_DeadZone
                Extra1_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Boundary
                Extra1_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Washout
                Extra1_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF2
                Extra1_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_DeadZone
                Extra1_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Boundary
                Extra1_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Washout
                Extra1_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF3
                Extra1_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_DeadZone
                Extra1_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Boundary
                Extra1_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Washout
                Extra1_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF4
                Extra1_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_DeadZone
                Extra1_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Boundary
                Extra1_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Washout
                Extra1_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF5
                Extra1_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_DeadZone
                Extra1_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Boundary
                Extra1_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Washout
                Extra1_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF6
                Extra1_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_DeadZone
                Extra1_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Boundary
                Extra1_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Washout
                Extra1_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra1_Axis1)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra1_Axis1()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra1_Output_Axis1 = Extra1_Input

            'DeadZone Filter
            Extra1_Output_Axis1 = Extra1_Filters_Axis1.DeadZone(Extra1_Output_Axis1, Extra1_Filter_DeadZone_Axis1)

            'Boundry filter 
            Extra1_Output_Axis1 = Extra1_Filters_Axis1.Boundry(Extra1_Output_Axis1, Extra1_Filter_Boundary_Axis1)

            'Washout filter
            Extra1_Output_Axis1 = Extra1_Filters_Axis1.WashoutAccel(Extra1_Output_Axis1, Extra1_Filter_Washout_Axis1)

            'Smoothing Filter
            Extra1_Output_Axis1 = Extra1_Filters_Axis1.Smoothing(Extra1_Output_Axis1, Extra1_Filter_Smoothing_Axis1)

            'Main Profile Smoothing
            'Extra1_Output_Axis1 = Extra1_Filters_Axis1.MainProfile_Smoothing(Extra1_Output_Axis1, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra1_Axis1 = Extra1_Output_Axis1

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra1_Axis2 _ Output"
    'Output and Filters
    Private Extra1_Output_Axis2 As Double
    Private Extra1_Filter_DeadZone_Axis2 As Integer
    Private Extra1_Filter_Boundary_Axis2 As Integer
    Private Extra1_Filter_Washout_Axis2 As Integer
    Private Extra1_Filter_Smoothing_Axis2 As Integer
    'Private Extra1_Filter_Rescaling_Axis2 As Integer
    Private Extra1_Filters_Axis2 As Cls_Filters
    Private Sub Start_OutputExtra1_Axis2()
        'Create New Filter Object (resets object to default values)
        Extra1_Filters_Axis2 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra1"
            Case Struct_AxisAssignments._Axis2DOF1
                Extra1_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_DeadZone
                Extra1_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Boundary
                Extra1_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Washout
                Extra1_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF2
                Extra1_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_DeadZone
                Extra1_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Boundary
                Extra1_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Washout
                Extra1_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF3
                Extra1_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_DeadZone
                Extra1_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Boundary
                Extra1_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Washout
                Extra1_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF4
                Extra1_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_DeadZone
                Extra1_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Boundary
                Extra1_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Washout
                Extra1_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF5
                Extra1_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_DeadZone
                Extra1_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Boundary
                Extra1_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Washout
                Extra1_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF6
                Extra1_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_DeadZone
                Extra1_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Boundary
                Extra1_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Washout
                Extra1_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra1_Axis2)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra1_Axis2()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra1_Output_Axis2 = Extra1_Input

            'DeadZone Filter
            Extra1_Output_Axis2 = Extra1_Filters_Axis2.DeadZone(Extra1_Output_Axis2, Extra1_Filter_DeadZone_Axis2)

            'Boundry filter 
            Extra1_Output_Axis2 = Extra1_Filters_Axis2.Boundry(Extra1_Output_Axis2, Extra1_Filter_Boundary_Axis2)

            'Washout filter
            Extra1_Output_Axis2 = Extra1_Filters_Axis2.WashoutAccel(Extra1_Output_Axis2, Extra1_Filter_Washout_Axis2)

            'Smoothing Filter
            Extra1_Output_Axis2 = Extra1_Filters_Axis2.Smoothing(Extra1_Output_Axis2, Extra1_Filter_Smoothing_Axis2)

            'Main Profile Smoothing
            'Extra1_Output_Axis2 = Extra1_Filters_Axis2.MainProfile_Smoothing(Extra1_Output_Axis2, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra1_Axis2 = Extra1_Output_Axis2

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra1_Axis3 _ Output"
    'Output and Filters
    Private Extra1_Output_Axis3 As Double
    Private Extra1_Filter_DeadZone_Axis3 As Integer
    Private Extra1_Filter_Boundary_Axis3 As Integer
    Private Extra1_Filter_Washout_Axis3 As Integer
    Private Extra1_Filter_Smoothing_Axis3 As Integer
    'Private Extra1_Filter_Rescaling_Axis3 As Integer
    Private Extra1_Filters_Axis3 As Cls_Filters
    Private Sub Start_OutputExtra1_Axis3()
        'Create New Filter Object (resets object to default values)
        Extra1_Filters_Axis3 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra1"
            Case Struct_AxisAssignments._Axis3DOF1
                Extra1_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_DeadZone
                Extra1_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Boundary
                Extra1_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Washout
                Extra1_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF2
                Extra1_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_DeadZone
                Extra1_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Boundary
                Extra1_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Washout
                Extra1_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF3
                Extra1_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_DeadZone
                Extra1_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Boundary
                Extra1_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Washout
                Extra1_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF4
                Extra1_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_DeadZone
                Extra1_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Boundary
                Extra1_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Washout
                Extra1_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF5
                Extra1_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_DeadZone
                Extra1_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Boundary
                Extra1_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Washout
                Extra1_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF6
                Extra1_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_DeadZone
                Extra1_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Boundary
                Extra1_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Washout
                Extra1_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra1_Axis3)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra1_Axis3()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra1_Output_Axis3 = Extra1_Input

            'DeadZone Filter
            Extra1_Output_Axis3 = Extra1_Filters_Axis3.DeadZone(Extra1_Output_Axis3, Extra1_Filter_DeadZone_Axis3)

            'Boundry filter 
            Extra1_Output_Axis3 = Extra1_Filters_Axis3.Boundry(Extra1_Output_Axis3, Extra1_Filter_Boundary_Axis3)

            'Washout filter
            Extra1_Output_Axis3 = Extra1_Filters_Axis3.WashoutAccel(Extra1_Output_Axis3, Extra1_Filter_Washout_Axis3)

            'Smoothing Filter
            Extra1_Output_Axis3 = Extra1_Filters_Axis3.Smoothing(Extra1_Output_Axis3, Extra1_Filter_Smoothing_Axis3)

            'Main Profile Smoothing
            'Extra1_Output_Axis3 = Extra1_Filters_Axis3.MainProfile_Smoothing(Extra1_Output_Axis3, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra1_Axis3 = Extra1_Output_Axis3

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra1_Axis4 _ Output"
    'Output and Filters
    Private Extra1_Output_Axis4 As Double
    Private Extra1_Filter_DeadZone_Axis4 As Integer
    Private Extra1_Filter_Boundary_Axis4 As Integer
    Private Extra1_Filter_Washout_Axis4 As Integer
    Private Extra1_Filter_Smoothing_Axis4 As Integer
    'Private Extra1_Filter_Rescaling_Axis4 As Integer
    Private Extra1_Filters_Axis4 As Cls_Filters
    Private Sub Start_OutputExtra1_Axis4()
        'Create New Filter Object (resets object to default values)
        Extra1_Filters_Axis4 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra1"
            Case Struct_AxisAssignments._Axis4DOF1
                Extra1_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_DeadZone
                Extra1_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Boundary
                Extra1_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Washout
                Extra1_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF2
                Extra1_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_DeadZone
                Extra1_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Boundary
                Extra1_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Washout
                Extra1_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF3
                Extra1_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_DeadZone
                Extra1_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Boundary
                Extra1_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Washout
                Extra1_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF4
                Extra1_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_DeadZone
                Extra1_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Boundary
                Extra1_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Washout
                Extra1_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF5
                Extra1_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_DeadZone
                Extra1_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Boundary
                Extra1_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Washout
                Extra1_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF6
                Extra1_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_DeadZone
                Extra1_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Boundary
                Extra1_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Washout
                Extra1_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra1_Axis4)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra1_Axis4()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra1_Output_Axis4 = Extra1_Input

            'DeadZone Filter
            Extra1_Output_Axis4 = Extra1_Filters_Axis4.DeadZone(Extra1_Output_Axis4, Extra1_Filter_DeadZone_Axis4)

            'Boundry filter 
            Extra1_Output_Axis4 = Extra1_Filters_Axis4.Boundry(Extra1_Output_Axis4, Extra1_Filter_Boundary_Axis4)

            'Washout filter
            Extra1_Output_Axis4 = Extra1_Filters_Axis4.WashoutAccel(Extra1_Output_Axis4, Extra1_Filter_Washout_Axis4)

            'Smoothing Filter
            Extra1_Output_Axis4 = Extra1_Filters_Axis4.Smoothing(Extra1_Output_Axis4, Extra1_Filter_Smoothing_Axis4)

            'Main Profile Smoothing
            'Extra1_Output_Axis4 = Extra1_Filters_Axis4.MainProfile_Smoothing(Extra1_Output_Axis4, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra1_Axis4 = Extra1_Output_Axis4

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra1_Axis5 _ Output"
    'Output and Filters
    Private Extra1_Output_Axis5 As Double
    Private Extra1_Filter_DeadZone_Axis5 As Integer
    Private Extra1_Filter_Boundary_Axis5 As Integer
    Private Extra1_Filter_Washout_Axis5 As Integer
    Private Extra1_Filter_Smoothing_Axis5 As Integer
    'Private Extra1_Filter_Rescaling_Axis5 As Integer
    Private Extra1_Filters_Axis5 As Cls_Filters
    Private Sub Start_OutputExtra1_Axis5()
        'Create New Filter Object (resets object to default values)
        Extra1_Filters_Axis5 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra1"
            Case Struct_AxisAssignments._Axis5DOF1
                Extra1_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_DeadZone
                Extra1_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Boundary
                Extra1_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Washout
                Extra1_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF2
                Extra1_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_DeadZone
                Extra1_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Boundary
                Extra1_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Washout
                Extra1_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF3
                Extra1_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_DeadZone
                Extra1_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Boundary
                Extra1_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Washout
                Extra1_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF4
                Extra1_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_DeadZone
                Extra1_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Boundary
                Extra1_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Washout
                Extra1_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF5
                Extra1_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_DeadZone
                Extra1_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Boundary
                Extra1_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Washout
                Extra1_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF6
                Extra1_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_DeadZone
                Extra1_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Boundary
                Extra1_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Washout
                Extra1_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra1_Axis5)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra1_Axis5()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra1_Output_Axis5 = Extra1_Input

            'DeadZone Filter
            Extra1_Output_Axis5 = Extra1_Filters_Axis5.DeadZone(Extra1_Output_Axis5, Extra1_Filter_DeadZone_Axis5)

            'Boundry filter 
            Extra1_Output_Axis5 = Extra1_Filters_Axis5.Boundry(Extra1_Output_Axis5, Extra1_Filter_Boundary_Axis5)

            'Washout filter
            Extra1_Output_Axis5 = Extra1_Filters_Axis5.WashoutAccel(Extra1_Output_Axis5, Extra1_Filter_Washout_Axis5)

            'Smoothing Filter
            Extra1_Output_Axis5 = Extra1_Filters_Axis5.Smoothing(Extra1_Output_Axis5, Extra1_Filter_Smoothing_Axis5)

            'Main Profile Smoothing
            'Extra1_Output_Axis5 = Extra1_Filters_Axis5.MainProfile_Smoothing(Extra1_Output_Axis5, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra1_Axis5 = Extra1_Output_Axis5

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra1_Axis6 _ Output"
    'Output and Filters
    Private Extra1_Output_Axis6 As Double
    Private Extra1_Filter_DeadZone_Axis6 As Integer
    Private Extra1_Filter_Boundary_Axis6 As Integer
    Private Extra1_Filter_Washout_Axis6 As Integer
    Private Extra1_Filter_Smoothing_Axis6 As Integer
    'Private Extra1_Filter_Rescaling_Axis6 As Integer
    Private Extra1_Filters_Axis6 As Cls_Filters
    Private Sub Start_OutputExtra1_Axis6()
        'Create New Filter Object (resets object to default values)
        Extra1_Filters_Axis6 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra1"
            Case Struct_AxisAssignments._Axis6DOF1
                Extra1_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_DeadZone
                Extra1_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Boundary
                Extra1_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Washout
                Extra1_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF2
                Extra1_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_DeadZone
                Extra1_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Boundary
                Extra1_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Washout
                Extra1_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF3
                Extra1_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_DeadZone
                Extra1_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Boundary
                Extra1_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Washout
                Extra1_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF4
                Extra1_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_DeadZone
                Extra1_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Boundary
                Extra1_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Washout
                Extra1_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF5
                Extra1_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_DeadZone
                Extra1_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Boundary
                Extra1_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Washout
                Extra1_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF6
                Extra1_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_DeadZone
                Extra1_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Boundary
                Extra1_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Washout
                Extra1_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Smoothing
                'Extra1_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra1_Axis6)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra1_Axis6()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra1_Output_Axis6 = Extra1_Input

            'DeadZone Filter
            Extra1_Output_Axis6 = Extra1_Filters_Axis6.DeadZone(Extra1_Output_Axis6, Extra1_Filter_DeadZone_Axis6)

            'Boundry filter 
            Extra1_Output_Axis6 = Extra1_Filters_Axis6.Boundry(Extra1_Output_Axis6, Extra1_Filter_Boundary_Axis6)

            'Washout filter
            Extra1_Output_Axis6 = Extra1_Filters_Axis6.WashoutAccel(Extra1_Output_Axis6, Extra1_Filter_Washout_Axis6)

            'Smoothing Filter
            Extra1_Output_Axis6 = Extra1_Filters_Axis6.Smoothing(Extra1_Output_Axis6, Extra1_Filter_Smoothing_Axis6)

            'Main Profile Smoothing
            'Extra1_Output_Axis6 = Extra1_Filters_Axis6.MainProfile_Smoothing(Extra1_Output_Axis6, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra1_Axis6 = Extra1_Output_Axis6

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra2_Axis1 _ Output"
    'Output and Filters
    Private Extra2_Output_Axis1 As Double
    Private Extra2_Filter_DeadZone_Axis1 As Integer
    Private Extra2_Filter_Boundary_Axis1 As Integer
    Private Extra2_Filter_Washout_Axis1 As Integer
    Private Extra2_Filter_Smoothing_Axis1 As Integer
    'Private Extra2_Filter_Rescaling_Axis1 As Integer
    Private Extra2_Filters_Axis1 As Cls_Filters
    Private Sub Start_OutputExtra2_Axis1()
        'Create New Filter Object (resets object to default values)
        Extra2_Filters_Axis1 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra2"
            Case Struct_AxisAssignments._Axis1DOF1
                Extra2_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_DeadZone
                Extra2_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Boundary
                Extra2_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Washout
                Extra2_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF2
                Extra2_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_DeadZone
                Extra2_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Boundary
                Extra2_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Washout
                Extra2_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF3
                Extra2_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_DeadZone
                Extra2_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Boundary
                Extra2_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Washout
                Extra2_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF4
                Extra2_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_DeadZone
                Extra2_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Boundary
                Extra2_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Washout
                Extra2_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF5
                Extra2_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_DeadZone
                Extra2_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Boundary
                Extra2_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Washout
                Extra2_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF6
                Extra2_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_DeadZone
                Extra2_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Boundary
                Extra2_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Washout
                Extra2_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra2_Axis1)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra2_Axis1()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra2_Output_Axis1 = Extra2_Input

            'DeadZone Filter
            Extra2_Output_Axis1 = Extra2_Filters_Axis1.DeadZone(Extra2_Output_Axis1, Extra2_Filter_DeadZone_Axis1)

            'Boundry filter 
            Extra2_Output_Axis1 = Extra2_Filters_Axis1.Boundry(Extra2_Output_Axis1, Extra2_Filter_Boundary_Axis1)

            'Washout filter
            Extra2_Output_Axis1 = Extra2_Filters_Axis1.WashoutAccel(Extra2_Output_Axis1, Extra2_Filter_Washout_Axis1)

            'Smoothing Filter
            Extra2_Output_Axis1 = Extra2_Filters_Axis1.Smoothing(Extra2_Output_Axis1, Extra2_Filter_Smoothing_Axis1)

            'Main Profile Smoothing
            'Extra2_Output_Axis1 = Extra2_Filters_Axis1.MainProfile_Smoothing(Extra2_Output_Axis1, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra2_Axis1 = Extra2_Output_Axis1

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra2_Axis2 _ Output"
    'Output and Filters
    Private Extra2_Output_Axis2 As Double
    Private Extra2_Filter_DeadZone_Axis2 As Integer
    Private Extra2_Filter_Boundary_Axis2 As Integer
    Private Extra2_Filter_Washout_Axis2 As Integer
    Private Extra2_Filter_Smoothing_Axis2 As Integer
    'Private Extra2_Filter_Rescaling_Axis2 As Integer
    Private Extra2_Filters_Axis2 As Cls_Filters
    Private Sub Start_OutputExtra2_Axis2()
        'Create New Filter Object (resets object to default values)
        Extra2_Filters_Axis2 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra2"
            Case Struct_AxisAssignments._Axis2DOF1
                Extra2_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_DeadZone
                Extra2_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Boundary
                Extra2_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Washout
                Extra2_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF2
                Extra2_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_DeadZone
                Extra2_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Boundary
                Extra2_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Washout
                Extra2_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF3
                Extra2_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_DeadZone
                Extra2_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Boundary
                Extra2_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Washout
                Extra2_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF4
                Extra2_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_DeadZone
                Extra2_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Boundary
                Extra2_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Washout
                Extra2_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF5
                Extra2_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_DeadZone
                Extra2_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Boundary
                Extra2_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Washout
                Extra2_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF6
                Extra2_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_DeadZone
                Extra2_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Boundary
                Extra2_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Washout
                Extra2_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra2_Axis2)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra2_Axis2()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra2_Output_Axis2 = Extra2_Input

            'DeadZone Filter
            Extra2_Output_Axis2 = Extra2_Filters_Axis2.DeadZone(Extra2_Output_Axis2, Extra2_Filter_DeadZone_Axis2)

            'Boundry filter 
            Extra2_Output_Axis2 = Extra2_Filters_Axis2.Boundry(Extra2_Output_Axis2, Extra2_Filter_Boundary_Axis2)

            'Washout filter
            Extra2_Output_Axis2 = Extra2_Filters_Axis2.WashoutAccel(Extra2_Output_Axis2, Extra2_Filter_Washout_Axis2)

            'Smoothing Filter
            Extra2_Output_Axis2 = Extra2_Filters_Axis2.Smoothing(Extra2_Output_Axis2, Extra2_Filter_Smoothing_Axis2)

            'Main Profile Smoothing
            'Extra2_Output_Axis2 = Extra2_Filters_Axis2.MainProfile_Smoothing(Extra2_Output_Axis2, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra2_Axis2 = Extra2_Output_Axis2

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra2_Axis3 _ Output"
    'Output and Filters
    Private Extra2_Output_Axis3 As Double
    Private Extra2_Filter_DeadZone_Axis3 As Integer
    Private Extra2_Filter_Boundary_Axis3 As Integer
    Private Extra2_Filter_Washout_Axis3 As Integer
    Private Extra2_Filter_Smoothing_Axis3 As Integer
    'Private Extra2_Filter_Rescaling_Axis3 As Integer
    Private Extra2_Filters_Axis3 As Cls_Filters
    Private Sub Start_OutputExtra2_Axis3()
        'Create New Filter Object (resets object to default values)
        Extra2_Filters_Axis3 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra2"
            Case Struct_AxisAssignments._Axis3DOF1
                Extra2_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_DeadZone
                Extra2_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Boundary
                Extra2_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Washout
                Extra2_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF2
                Extra2_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_DeadZone
                Extra2_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Boundary
                Extra2_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Washout
                Extra2_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF3
                Extra2_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_DeadZone
                Extra2_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Boundary
                Extra2_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Washout
                Extra2_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF4
                Extra2_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_DeadZone
                Extra2_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Boundary
                Extra2_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Washout
                Extra2_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF5
                Extra2_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_DeadZone
                Extra2_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Boundary
                Extra2_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Washout
                Extra2_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF6
                Extra2_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_DeadZone
                Extra2_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Boundary
                Extra2_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Washout
                Extra2_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra2_Axis3)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra2_Axis3()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra2_Output_Axis3 = Extra2_Input

            'DeadZone Filter
            Extra2_Output_Axis3 = Extra2_Filters_Axis3.DeadZone(Extra2_Output_Axis3, Extra2_Filter_DeadZone_Axis3)

            'Boundry filter 
            Extra2_Output_Axis3 = Extra2_Filters_Axis3.Boundry(Extra2_Output_Axis3, Extra2_Filter_Boundary_Axis3)

            'Washout filter
            Extra2_Output_Axis3 = Extra2_Filters_Axis3.WashoutAccel(Extra2_Output_Axis3, Extra2_Filter_Washout_Axis3)

            'Smoothing Filter
            Extra2_Output_Axis3 = Extra2_Filters_Axis3.Smoothing(Extra2_Output_Axis3, Extra2_Filter_Smoothing_Axis3)

            'Main Profile Smoothing
            'Extra2_Output_Axis3 = Extra2_Filters_Axis3.MainProfile_Smoothing(Extra2_Output_Axis3, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra2_Axis3 = Extra2_Output_Axis3

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra2_Axis4 _ Output"
    'Output and Filters
    Private Extra2_Output_Axis4 As Double
    Private Extra2_Filter_DeadZone_Axis4 As Integer
    Private Extra2_Filter_Boundary_Axis4 As Integer
    Private Extra2_Filter_Washout_Axis4 As Integer
    Private Extra2_Filter_Smoothing_Axis4 As Integer
    'Private Extra2_Filter_Rescaling_Axis4 As Integer
    Private Extra2_Filters_Axis4 As Cls_Filters
    Private Sub Start_OutputExtra2_Axis4()
        'Create New Filter Object (resets object to default values)
        Extra2_Filters_Axis4 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra2"
            Case Struct_AxisAssignments._Axis4DOF1
                Extra2_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_DeadZone
                Extra2_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Boundary
                Extra2_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Washout
                Extra2_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF2
                Extra2_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_DeadZone
                Extra2_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Boundary
                Extra2_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Washout
                Extra2_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF3
                Extra2_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_DeadZone
                Extra2_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Boundary
                Extra2_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Washout
                Extra2_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF4
                Extra2_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_DeadZone
                Extra2_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Boundary
                Extra2_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Washout
                Extra2_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF5
                Extra2_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_DeadZone
                Extra2_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Boundary
                Extra2_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Washout
                Extra2_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF6
                Extra2_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_DeadZone
                Extra2_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Boundary
                Extra2_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Washout
                Extra2_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra2_Axis4)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra2_Axis4()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra2_Output_Axis4 = Extra2_Input

            'DeadZone Filter
            Extra2_Output_Axis4 = Extra2_Filters_Axis4.DeadZone(Extra2_Output_Axis4, Extra2_Filter_DeadZone_Axis4)

            'Boundry filter 
            Extra2_Output_Axis4 = Extra2_Filters_Axis4.Boundry(Extra2_Output_Axis4, Extra2_Filter_Boundary_Axis4)

            'Washout filter
            Extra2_Output_Axis4 = Extra2_Filters_Axis4.WashoutAccel(Extra2_Output_Axis4, Extra2_Filter_Washout_Axis4)

            'Smoothing Filter
            Extra2_Output_Axis4 = Extra2_Filters_Axis4.Smoothing(Extra2_Output_Axis4, Extra2_Filter_Smoothing_Axis4)

            'Main Profile Smoothing
            'Extra2_Output_Axis4 = Extra2_Filters_Axis4.MainProfile_Smoothing(Extra2_Output_Axis4, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra2_Axis4 = Extra2_Output_Axis4

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra2_Axis5 _ Output"
    'Output and Filters
    Private Extra2_Output_Axis5 As Double
    Private Extra2_Filter_DeadZone_Axis5 As Integer
    Private Extra2_Filter_Boundary_Axis5 As Integer
    Private Extra2_Filter_Washout_Axis5 As Integer
    Private Extra2_Filter_Smoothing_Axis5 As Integer
    'Private Extra2_Filter_Rescaling_Axis5 As Integer
    Private Extra2_Filters_Axis5 As Cls_Filters
    Private Sub Start_OutputExtra2_Axis5()
        'Create New Filter Object (resets object to default values)
        Extra2_Filters_Axis5 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra2"
            Case Struct_AxisAssignments._Axis5DOF1
                Extra2_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_DeadZone
                Extra2_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Boundary
                Extra2_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Washout
                Extra2_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF2
                Extra2_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_DeadZone
                Extra2_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Boundary
                Extra2_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Washout
                Extra2_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF3
                Extra2_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_DeadZone
                Extra2_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Boundary
                Extra2_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Washout
                Extra2_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF4
                Extra2_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_DeadZone
                Extra2_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Boundary
                Extra2_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Washout
                Extra2_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF5
                Extra2_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_DeadZone
                Extra2_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Boundary
                Extra2_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Washout
                Extra2_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF6
                Extra2_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_DeadZone
                Extra2_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Boundary
                Extra2_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Washout
                Extra2_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra2_Axis5)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra2_Axis5()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra2_Output_Axis5 = Extra2_Input

            'DeadZone Filter
            Extra2_Output_Axis5 = Extra2_Filters_Axis5.DeadZone(Extra2_Output_Axis5, Extra2_Filter_DeadZone_Axis5)

            'Boundry filter 
            Extra2_Output_Axis5 = Extra2_Filters_Axis5.Boundry(Extra2_Output_Axis5, Extra2_Filter_Boundary_Axis5)

            'Washout filter
            Extra2_Output_Axis5 = Extra2_Filters_Axis5.WashoutAccel(Extra2_Output_Axis5, Extra2_Filter_Washout_Axis5)

            'Smoothing Filter
            Extra2_Output_Axis5 = Extra2_Filters_Axis5.Smoothing(Extra2_Output_Axis5, Extra2_Filter_Smoothing_Axis5)

            'Main Profile Smoothing
            'Extra2_Output_Axis5 = Extra2_Filters_Axis5.MainProfile_Smoothing(Extra2_Output_Axis5, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra2_Axis5 = Extra2_Output_Axis5

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra2_Axis6 _ Output"
    'Output and Filters
    Private Extra2_Output_Axis6 As Double
    Private Extra2_Filter_DeadZone_Axis6 As Integer
    Private Extra2_Filter_Boundary_Axis6 As Integer
    Private Extra2_Filter_Washout_Axis6 As Integer
    Private Extra2_Filter_Smoothing_Axis6 As Integer
    'Private Extra2_Filter_Rescaling_Axis6 As Integer
    Private Extra2_Filters_Axis6 As Cls_Filters
    Private Sub Start_OutputExtra2_Axis6()
        'Create New Filter Object (resets object to default values)
        Extra2_Filters_Axis6 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra2"
            Case Struct_AxisAssignments._Axis6DOF1
                Extra2_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_DeadZone
                Extra2_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Boundary
                Extra2_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Washout
                Extra2_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF2
                Extra2_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_DeadZone
                Extra2_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Boundary
                Extra2_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Washout
                Extra2_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF3
                Extra2_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_DeadZone
                Extra2_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Boundary
                Extra2_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Washout
                Extra2_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF4
                Extra2_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_DeadZone
                Extra2_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Boundary
                Extra2_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Washout
                Extra2_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF5
                Extra2_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_DeadZone
                Extra2_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Boundary
                Extra2_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Washout
                Extra2_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF6
                Extra2_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_DeadZone
                Extra2_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Boundary
                Extra2_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Washout
                Extra2_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Smoothing
                'Extra2_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra2_Axis6)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra2_Axis6()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra2_Output_Axis6 = Extra2_Input

            'DeadZone Filter
            Extra2_Output_Axis6 = Extra2_Filters_Axis6.DeadZone(Extra2_Output_Axis6, Extra2_Filter_DeadZone_Axis6)

            'Boundry filter 
            Extra2_Output_Axis6 = Extra2_Filters_Axis6.Boundry(Extra2_Output_Axis6, Extra2_Filter_Boundary_Axis6)

            'Washout filter
            Extra2_Output_Axis6 = Extra2_Filters_Axis6.WashoutAccel(Extra2_Output_Axis6, Extra2_Filter_Washout_Axis6)

            'Smoothing Filter
            Extra2_Output_Axis6 = Extra2_Filters_Axis6.Smoothing(Extra2_Output_Axis6, Extra2_Filter_Smoothing_Axis6)

            'Main Profile Smoothing
            'Extra2_Output_Axis6 = Extra2_Filters_Axis6.MainProfile_Smoothing(Extra2_Output_Axis6, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra2_Axis6 = Extra2_Output_Axis6

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra3_Axis1 _ Output"
    'Output and Filters
    Private Extra3_Output_Axis1 As Double
    Private Extra3_Filter_DeadZone_Axis1 As Integer
    Private Extra3_Filter_Boundary_Axis1 As Integer
    Private Extra3_Filter_Washout_Axis1 As Integer
    Private Extra3_Filter_Smoothing_Axis1 As Integer
    'Private Extra3_Filter_Rescaling_Axis1 As Integer
    Private Extra3_Filters_Axis1 As Cls_Filters
    Private Sub Start_OutputExtra3_Axis1()
        'Create New Filter Object (resets object to default values)
        Extra3_Filters_Axis1 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra3"
            Case Struct_AxisAssignments._Axis1DOF1
                Extra3_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_DeadZone
                Extra3_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Boundary
                Extra3_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Washout
                Extra3_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF2
                Extra3_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_DeadZone
                Extra3_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Boundary
                Extra3_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Washout
                Extra3_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF3
                Extra3_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_DeadZone
                Extra3_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Boundary
                Extra3_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Washout
                Extra3_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF4
                Extra3_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_DeadZone
                Extra3_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Boundary
                Extra3_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Washout
                Extra3_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF5
                Extra3_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_DeadZone
                Extra3_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Boundary
                Extra3_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Washout
                Extra3_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis1DOF6
                Extra3_Filter_DeadZone_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_DeadZone
                Extra3_Filter_Boundary_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Boundary
                Extra3_Filter_Washout_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Washout
                Extra3_Filter_Smoothing_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis1 = Struct_AxisAssignments._Axis1_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra3_Axis1)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra3_Axis1()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra3_Output_Axis1 = Extra3_Input

            'DeadZone Filter
            Extra3_Output_Axis1 = Extra3_Filters_Axis1.DeadZone(Extra3_Output_Axis1, Extra3_Filter_DeadZone_Axis1)

            'Boundry filter 
            Extra3_Output_Axis1 = Extra3_Filters_Axis1.Boundry(Extra3_Output_Axis1, Extra3_Filter_Boundary_Axis1)

            'Washout filter
            Extra3_Output_Axis1 = Extra3_Filters_Axis1.WashoutAccel(Extra3_Output_Axis1, Extra3_Filter_Washout_Axis1)

            'Smoothing Filter
            Extra3_Output_Axis1 = Extra3_Filters_Axis1.Smoothing(Extra3_Output_Axis1, Extra3_Filter_Smoothing_Axis1)

            'Main Profile Smoothing
            'Extra3_Output_Axis1 = Extra3_Filters_Axis1.MainProfile_Smoothing(Extra3_Output_Axis1, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra3_Axis1 = Extra3_Output_Axis1

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra3_Axis2 _ Output"
    'Output and Filters
    Private Extra3_Output_Axis2 As Double
    Private Extra3_Filter_DeadZone_Axis2 As Integer
    Private Extra3_Filter_Boundary_Axis2 As Integer
    Private Extra3_Filter_Washout_Axis2 As Integer
    Private Extra3_Filter_Smoothing_Axis2 As Integer
    'Private Extra3_Filter_Rescaling_Axis2 As Integer
    Private Extra3_Filters_Axis2 As Cls_Filters
    Private Sub Start_OutputExtra3_Axis2()
        'Create New Filter Object (resets object to default values)
        Extra3_Filters_Axis2 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra3"
            Case Struct_AxisAssignments._Axis2DOF1
                Extra3_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_DeadZone
                Extra3_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Boundary
                Extra3_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Washout
                Extra3_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF2
                Extra3_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_DeadZone
                Extra3_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Boundary
                Extra3_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Washout
                Extra3_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF3
                Extra3_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_DeadZone
                Extra3_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Boundary
                Extra3_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Washout
                Extra3_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF4
                Extra3_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_DeadZone
                Extra3_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Boundary
                Extra3_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Washout
                Extra3_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF5
                Extra3_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_DeadZone
                Extra3_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Boundary
                Extra3_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Washout
                Extra3_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis2DOF6
                Extra3_Filter_DeadZone_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_DeadZone
                Extra3_Filter_Boundary_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Boundary
                Extra3_Filter_Washout_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Washout
                Extra3_Filter_Smoothing_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis2 = Struct_AxisAssignments._Axis2_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra3_Axis2)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra3_Axis2()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra3_Output_Axis2 = Extra3_Input

            'DeadZone Filter
            Extra3_Output_Axis2 = Extra3_Filters_Axis2.DeadZone(Extra3_Output_Axis2, Extra3_Filter_DeadZone_Axis2)

            'Boundry filter 
            Extra3_Output_Axis2 = Extra3_Filters_Axis2.Boundry(Extra3_Output_Axis2, Extra3_Filter_Boundary_Axis2)

            'Washout filter
            Extra3_Output_Axis2 = Extra3_Filters_Axis2.WashoutAccel(Extra3_Output_Axis2, Extra3_Filter_Washout_Axis2)

            'Smoothing Filter
            Extra3_Output_Axis2 = Extra3_Filters_Axis2.Smoothing(Extra3_Output_Axis2, Extra3_Filter_Smoothing_Axis2)

            'Main Profile Smoothing
            'Extra3_Output_Axis2 = Extra3_Filters_Axis2.MainProfile_Smoothing(Extra3_Output_Axis2, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra3_Axis2 = Extra3_Output_Axis2

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra3_Axis3 _ Output"
    'Output and Filters
    Private Extra3_Output_Axis3 As Double
    Private Extra3_Filter_DeadZone_Axis3 As Integer
    Private Extra3_Filter_Boundary_Axis3 As Integer
    Private Extra3_Filter_Washout_Axis3 As Integer
    Private Extra3_Filter_Smoothing_Axis3 As Integer
    'Private Extra3_Filter_Rescaling_Axis3 As Integer
    Private Extra3_Filters_Axis3 As Cls_Filters
    Private Sub Start_OutputExtra3_Axis3()
        'Create New Filter Object (resets object to default values)
        Extra3_Filters_Axis3 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra3"
            Case Struct_AxisAssignments._Axis3DOF1
                Extra3_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_DeadZone
                Extra3_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Boundary
                Extra3_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Washout
                Extra3_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF2
                Extra3_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_DeadZone
                Extra3_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Boundary
                Extra3_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Washout
                Extra3_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF3
                Extra3_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_DeadZone
                Extra3_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Boundary
                Extra3_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Washout
                Extra3_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF4
                Extra3_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_DeadZone
                Extra3_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Boundary
                Extra3_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Washout
                Extra3_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF5
                Extra3_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_DeadZone
                Extra3_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Boundary
                Extra3_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Washout
                Extra3_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis3DOF6
                Extra3_Filter_DeadZone_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_DeadZone
                Extra3_Filter_Boundary_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Boundary
                Extra3_Filter_Washout_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Washout
                Extra3_Filter_Smoothing_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis3 = Struct_AxisAssignments._Axis3_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra3_Axis3)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra3_Axis3()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra3_Output_Axis3 = Extra3_Input

            'DeadZone Filter
            Extra3_Output_Axis3 = Extra3_Filters_Axis3.DeadZone(Extra3_Output_Axis3, Extra3_Filter_DeadZone_Axis3)

            'Boundry filter 
            Extra3_Output_Axis3 = Extra3_Filters_Axis3.Boundry(Extra3_Output_Axis3, Extra3_Filter_Boundary_Axis3)

            'Washout filter
            Extra3_Output_Axis3 = Extra3_Filters_Axis3.WashoutAccel(Extra3_Output_Axis3, Extra3_Filter_Washout_Axis3)

            'Smoothing Filter
            Extra3_Output_Axis3 = Extra3_Filters_Axis3.Smoothing(Extra3_Output_Axis3, Extra3_Filter_Smoothing_Axis3)

            'Main Profile Smoothing
            'Extra3_Output_Axis3 = Extra3_Filters_Axis3.MainProfile_Smoothing(Extra3_Output_Axis3, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra3_Axis3 = Extra3_Output_Axis3

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra3_Axis4 _ Output"
    'Output and Filters
    Private Extra3_Output_Axis4 As Double
    Private Extra3_Filter_DeadZone_Axis4 As Integer
    Private Extra3_Filter_Boundary_Axis4 As Integer
    Private Extra3_Filter_Washout_Axis4 As Integer
    Private Extra3_Filter_Smoothing_Axis4 As Integer
    'Private Extra3_Filter_Rescaling_Axis4 As Integer
    Private Extra3_Filters_Axis4 As Cls_Filters
    Private Sub Start_OutputExtra3_Axis4()
        'Create New Filter Object (resets object to default values)
        Extra3_Filters_Axis4 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra3"
            Case Struct_AxisAssignments._Axis4DOF1
                Extra3_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_DeadZone
                Extra3_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Boundary
                Extra3_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Washout
                Extra3_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF2
                Extra3_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_DeadZone
                Extra3_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Boundary
                Extra3_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Washout
                Extra3_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF3
                Extra3_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_DeadZone
                Extra3_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Boundary
                Extra3_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Washout
                Extra3_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF4
                Extra3_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_DeadZone
                Extra3_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Boundary
                Extra3_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Washout
                Extra3_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF5
                Extra3_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_DeadZone
                Extra3_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Boundary
                Extra3_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Washout
                Extra3_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis4DOF6
                Extra3_Filter_DeadZone_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_DeadZone
                Extra3_Filter_Boundary_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Boundary
                Extra3_Filter_Washout_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Washout
                Extra3_Filter_Smoothing_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis4 = Struct_AxisAssignments._Axis4_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra3_Axis4)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra3_Axis4()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra3_Output_Axis4 = Extra3_Input

            'DeadZone Filter
            Extra3_Output_Axis4 = Extra3_Filters_Axis4.DeadZone(Extra3_Output_Axis4, Extra3_Filter_DeadZone_Axis4)

            'Boundry filter 
            Extra3_Output_Axis4 = Extra3_Filters_Axis4.Boundry(Extra3_Output_Axis4, Extra3_Filter_Boundary_Axis4)

            'Washout filter
            Extra3_Output_Axis4 = Extra3_Filters_Axis4.WashoutAccel(Extra3_Output_Axis4, Extra3_Filter_Washout_Axis4)

            'Smoothing Filter
            Extra3_Output_Axis4 = Extra3_Filters_Axis4.Smoothing(Extra3_Output_Axis4, Extra3_Filter_Smoothing_Axis4)

            'Main Profile Smoothing
            'Extra3_Output_Axis4 = Extra3_Filters_Axis4.MainProfile_Smoothing(Extra3_Output_Axis4, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra3_Axis4 = Extra3_Output_Axis4

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra3_Axis5 _ Output"
    'Output and Filters
    Private Extra3_Output_Axis5 As Double
    Private Extra3_Filter_DeadZone_Axis5 As Integer
    Private Extra3_Filter_Boundary_Axis5 As Integer
    Private Extra3_Filter_Washout_Axis5 As Integer
    Private Extra3_Filter_Smoothing_Axis5 As Integer
    'Private Extra3_Filter_Rescaling_Axis5 As Integer
    Private Extra3_Filters_Axis5 As Cls_Filters
    Private Sub Start_OutputExtra3_Axis5()
        'Create New Filter Object (resets object to default values)
        Extra3_Filters_Axis5 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra3"
            Case Struct_AxisAssignments._Axis5DOF1
                Extra3_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_DeadZone
                Extra3_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Boundary
                Extra3_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Washout
                Extra3_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF2
                Extra3_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_DeadZone
                Extra3_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Boundary
                Extra3_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Washout
                Extra3_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF3
                Extra3_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_DeadZone
                Extra3_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Boundary
                Extra3_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Washout
                Extra3_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF4
                Extra3_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_DeadZone
                Extra3_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Boundary
                Extra3_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Washout
                Extra3_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF5
                Extra3_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_DeadZone
                Extra3_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Boundary
                Extra3_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Washout
                Extra3_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis5DOF6
                Extra3_Filter_DeadZone_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_DeadZone
                Extra3_Filter_Boundary_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Boundary
                Extra3_Filter_Washout_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Washout
                Extra3_Filter_Smoothing_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis5 = Struct_AxisAssignments._Axis5_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra3_Axis5)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra3_Axis5()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra3_Output_Axis5 = Extra3_Input

            'DeadZone Filter
            Extra3_Output_Axis5 = Extra3_Filters_Axis5.DeadZone(Extra3_Output_Axis5, Extra3_Filter_DeadZone_Axis5)

            'Boundry filter 
            Extra3_Output_Axis5 = Extra3_Filters_Axis5.Boundry(Extra3_Output_Axis5, Extra3_Filter_Boundary_Axis5)

            'Washout filter
            Extra3_Output_Axis5 = Extra3_Filters_Axis5.WashoutAccel(Extra3_Output_Axis5, Extra3_Filter_Washout_Axis5)

            'Smoothing Filter
            Extra3_Output_Axis5 = Extra3_Filters_Axis5.Smoothing(Extra3_Output_Axis5, Extra3_Filter_Smoothing_Axis5)

            'Main Profile Smoothing
            'Extra3_Output_Axis5 = Extra3_Filters_Axis5.MainProfile_Smoothing(Extra3_Output_Axis5, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra3_Axis5 = Extra3_Output_Axis5

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region

#Region "Extra3_Axis6 _ Output"
    'Output and Filters
    Private Extra3_Output_Axis6 As Double
    Private Extra3_Filter_DeadZone_Axis6 As Integer
    Private Extra3_Filter_Boundary_Axis6 As Integer
    Private Extra3_Filter_Washout_Axis6 As Integer
    Private Extra3_Filter_Smoothing_Axis6 As Integer
    'Private Extra3_Filter_Rescaling_Axis6 As Integer
    Private Extra3_Filters_Axis6 As Cls_Filters
    Private Sub Start_OutputExtra3_Axis6()
        'Create New Filter Object (resets object to default values)
        Extra3_Filters_Axis6 = New Cls_Filters

        'load the right DOF values
        Select Case "Extra3"
            Case Struct_AxisAssignments._Axis6DOF1
                Extra3_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_DeadZone
                Extra3_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Boundary
                Extra3_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Washout
                Extra3_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF1_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF2
                Extra3_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_DeadZone
                Extra3_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Boundary
                Extra3_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Washout
                Extra3_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF2_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF3
                Extra3_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_DeadZone
                Extra3_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Boundary
                Extra3_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Washout
                Extra3_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF3_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF4
                Extra3_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_DeadZone
                Extra3_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Boundary
                Extra3_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Washout
                Extra3_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF4_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF5
                Extra3_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_DeadZone
                Extra3_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Boundary
                Extra3_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Washout
                Extra3_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF5_Filter_Rescaling
            Case Struct_AxisAssignments._Axis6DOF6
                Extra3_Filter_DeadZone_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_DeadZone
                Extra3_Filter_Boundary_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Boundary
                Extra3_Filter_Washout_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Washout
                Extra3_Filter_Smoothing_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Smoothing
                'Extra3_Filter_Rescaling_Axis6 = Struct_AxisAssignments._Axis6_DOF6_Filter_Rescaling
        End Select

        'Start Output
        Output_Calulations_Running = True
        Dim trd As Thread = New Thread(AddressOf OutputExtra3_Axis6)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private Sub OutputExtra3_Axis6()
        Do While Output_Calulations_Running = True
            'Get Input
            Extra3_Output_Axis6 = Extra3_Input

            'DeadZone Filter
            Extra3_Output_Axis6 = Extra3_Filters_Axis6.DeadZone(Extra3_Output_Axis6, Extra3_Filter_DeadZone_Axis6)

            'Boundry filter 
            Extra3_Output_Axis6 = Extra3_Filters_Axis6.Boundry(Extra3_Output_Axis6, Extra3_Filter_Boundary_Axis6)

            'Washout filter
            Extra3_Output_Axis6 = Extra3_Filters_Axis6.WashoutAccel(Extra3_Output_Axis6, Extra3_Filter_Washout_Axis6)

            'Smoothing Filter
            Extra3_Output_Axis6 = Extra3_Filters_Axis6.Smoothing(Extra3_Output_Axis6, Extra3_Filter_Smoothing_Axis6)

            'Main Profile Smoothing
            'Extra3_Output_Axis6 = Extra3_Filters_Axis6.MainProfile_Smoothing(Extra3_Output_Axis6, Struct_ProfileData._MainLevel)

            'Assign Output
            _OutputExtra3_Axis6 = Extra3_Output_Axis6

            'start a new thread
            Thread.Sleep(1)
        Loop
    End Sub
#End Region
#End Region

    'Turn ON Output
    Public Sub OutputCalulations_ON()
        StartupSelected()
    End Sub

    'Turn Off Output
    Public Sub OutputCalulations_OFF()
        Output_Calulations_Running = False
    End Sub

    'Returns true or false if engine is running
    Public Function Calulations_Enabled() As Boolean
        Return Output_Calulations_Running
    End Function

    'Sets the DOF return vars for game engine
    Private Sub SetDOFsUsed()
        'Now we know what AXIS output are used
        'Now we need what DOF's need to be started
        If Axis1_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis1DOF1
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF2
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF3
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF4
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF5
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis1DOF6
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
        End If
        If Axis2_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis2DOF1
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF2
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF3
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF4
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF5
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis2DOF6
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
        End If
        If Axis3_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis3DOF1
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF2
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF3
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF4
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF5
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis3DOF6
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
        End If
        If Axis4_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis4DOF1
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF2
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF3
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF4
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF5
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis4DOF6
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
        End If
        If Axis5_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis5DOF1
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF2
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF3
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF4
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF5
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis5DOF6
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
        End If
        If Axis6_IsUsed = True Then
            Select Case Struct_AxisAssignments._Axis6DOF1
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF2
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF3
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF4
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF5
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
            Select Case Struct_AxisAssignments._Axis6DOF6
                Case "Roll"
                    Roll_IsUsed = True
                Case "Pitch"
                    Pitch_IsUsed = True
                Case "Heave"
                    Heave_IsUsed = True
                Case "Yaw"
                    Yaw_IsUsed = True
                Case "Sway"
                    Sway_IsUsed = True
                Case "Surge"
                    Surge_IsUsed = True
                Case "Extra1"
                    Extra1_IsUsed = True
                Case "Extra2"
                    Extra2_IsUsed = True
                Case "Extra3"
                    Extra3_IsUsed = True
            End Select
        End If
    End Sub

    'GameEngine Sets this before it calls game start
    Public Sub Set_AxisUsed(Axis1 As Boolean, Axis2 As Boolean, Axis3 As Boolean, Axis4 As Boolean, Axis5 As Boolean, Axis6 As Boolean)
        Axis1_IsUsed = Axis1
        Axis2_IsUsed = Axis2
        Axis3_IsUsed = Axis3
        Axis4_IsUsed = Axis4
        Axis5_IsUsed = Axis5
        Axis6_IsUsed = Axis6

        'dynamicly sets what simtools sould calculate error for (what dofs)
        SetDOFsUsed() 'Just for 2 DOF Math Plugin?
    End Sub

    'Axis Outputs - end value returns
    Public Function Get_Axis1_Output() As Double
        Return _Axis1Output
    End Function

    Public Function Get_Axis2_Output() As Double
        Return _Axis2Output
    End Function

    Public Function Get_Axis3_Output() As Double
        Return _Axis3Output
    End Function

    Public Function Get_Axis4_Output() As Double
        Return _Axis4Output
    End Function

    Public Function Get_Axis5_Output() As Double
        Return _Axis5Output
    End Function

    Public Function Get_Axis6_Output() As Double
        Return _Axis6Output
    End Function

    'DOF Inputs - GameEngine Sets this Input while a game running
    Public Sub Set_InputRoll(Roll As Double)
        Roll_Input = Roll
    End Sub

    Public Sub Set_InputPitch(Pitch As Double)
        Pitch_Input = Pitch
    End Sub

    Public Sub Set_InputHeave(Heave As Double)
        Heave_Input = Heave
    End Sub

    Public Sub Set_InputYaw(Yaw As Double)
        Yaw_Input = Yaw
    End Sub

    Public Sub Set_InputSway(Sway As Double)
        Sway_Input = Sway
    End Sub

    Public Sub Set_InputSurge(Surge As Double)
        Surge_Input = Surge
    End Sub

    Public Sub Set_InputExtra1(Extra1 As Double)
        Extra1_Input = Extra1
    End Sub

    Public Sub Set_InputExtra2(Extra2 As Double)
        Extra2_Input = Extra2
    End Sub

    Public Sub Set_InputExtra3(Extra3 As Double)
        Extra3_Input = Extra3
    End Sub

    'Is DOF enabled Outputs
    Public Function Get_DOFsUsed_Roll() As Boolean
        Return Roll_IsUsed
    End Function

    Public Function Get_DOFsUsed_Pitch() As Boolean
        Return Pitch_IsUsed
    End Function

    Public Function Get_DOFsUsed_Heave() As Boolean
        Return Heave_IsUsed
    End Function

    Public Function Get_DOFsUsed_Yaw() As Boolean
        Return Yaw_IsUsed
    End Function

    Public Function Get_DOFsUsed_Sway() As Boolean
        Return Sway_IsUsed
    End Function

    Public Function Get_DOFsUsed_Surge() As Boolean
        Return Surge_IsUsed
    End Function

    Public Function Get_DOFsUsed_Extra1() As Boolean
        Return Extra1_IsUsed
    End Function

    Public Function Get_DOFsUsed_Extra2() As Boolean
        Return Extra2_IsUsed
    End Function

    Public Function Get_DOFsUsed_Extra3() As Boolean
        Return Extra3_IsUsed
    End Function
End Module

