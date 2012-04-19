
Public Class [!output SAFE_CLASS_NAME]

    ' This comment was generated when the solution was upgraded.
    '
    ' For tools support, it is recommended that you copy the
    ' existing code in the OfficeCodeBehind class to the
    ' corresponding methods below. Once all code has been moved,
    ' [!output OLD_CODE_BEHIND] can be removed from the project.
    '
    ' For more information, see Visual Studio Tools for Office
    ' Help on upgrading solutions.

    Friend OldCode As [!output UPGRADE_CLASS_NAME]

    Private Sub [!output SAFE_CLASS_NAME]_Startup() Handles Me.Startup
        OldCode = New [!output UPGRADE_CLASS_NAME]()
        OldCode._Startup(Me.ThisApplication, Me.InnerObject)
    End Sub

    Private Sub [!output SAFE_CLASS_NAME]_Shutdown() Handles Me.Shutdown
        OldCode._Shutdown()
    End Sub

    ' This comment was generated when the solution was upgraded.
    '
    ' The commented event handlers below can be uncommented and used
    ' in one of two ways:
    '
    ' To move all code from the OfficeCodeBehind class, copy the
    ' existing code in the OfficeCodeBehind class to the
    ' corresponding methods below.
    '
    ' To call the existing code in the OfficeCodeBehind class,
    ' change the existing method so that it is no longer a private
    ' method or an event handler.
    '
    ' For more information, see Visual Studio Tools for Office Help
    ' on upgrading solutions.

    'Private Sub [!output SAFE_CLASS_NAME]_Open() Handles MyBase.Open
    '    OldCode.ThisDocument_Open()
    'End Sub

    'Private Sub [!output SAFE_CLASS_NAME]_CloseEvent() Handles MyBase.CloseEvent
    '    OldCode.ThisDocument_Close()
    'End Sub

End Class
