Option Explicit On
Option Strict On
Option Infer Off

Public Class Non_Recyclable
    Inherits Items
    Private _Dispose As String ' Tell user if item should be disposed or not.

    Public Property Dispose As String
        Get
            Return _Dispose
        End Get
        Set(value As String)
            _Dispose = value
        End Set
    End Property

    Public Overrides Function DetermineItemCategory() As String 'Return Category Item belongs in
        Return "Non-Recyclable"
    End Function


    Public Overrides Function Warning() As String 'Gives a warning, telling the user what to do with item depending on if it is biodigradble or not.
        Select Case IsBiodigradable
            Case True
                If (IsReusable = True) Then
                    _Dispose = "No"
                    Return "Should be Reused/Donated to Avoid Dumbing"
                Else
                    _Dispose = "Yes"
                    Return "Dispose of it in a recyclable bin. It is less harmful to environment"
                End If
            Case False
                If (IsReusable = True) Then
                    _Dispose = "No"
                    Return "Should be Reused/Donated to Avoid Dumbing"
                Else
                    _Dispose = "Yes"
                    Return "Dispose of it in a non-recyclable bin. It is very Harmful to the Environment. Disposal of this item should be limited"
                End If
            Case Else
                Return Nothing
        End Select
    End Function


    Public Overrides Function Display() As String 'Dispay data
        Return "Item Name: " & ItemName & Environment.NewLine &
            "Type of material: " & Material & Environment.NewLine &
            "Category : " & DetermineItemCategory() & Environment.NewLine &
            "Warining: " & Warning() & Environment.NewLine &
            "Dispose?: " & _Dispose & Environment.NewLine & Environment.NewLine
    End Function

End Class
