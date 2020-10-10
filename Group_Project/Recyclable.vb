Option Strict On
Option Infer Off
Option Explicit On

<Serializable> Public Class Recyclable
    Inherits Items
    Private _Usage As String    'What was the item sed for 

    Public Property Usage() As String
        Set(value As String)
            _Usage = value
        End Set
        Get
            Return _Usage
        End Get
    End Property


    ' Method that returns category item belongs in
    Public Overrides Function DetermineItemCategory() As String
        Return "Recyclable"
    End Function

    Public Overrides Function Warning() As String 'Gives a warning, telling the user what to do with item depending on if it is biodigradble or not.
        Select Case IsBiodigradable
            Case True
                If (IsReusable = True) Then
                    _Usage = "Many ways to use this item."
                    Return "Should be Reused/Recycled to Avoid Dumbing."
                Else
                    _Usage = "There ways are ways to recycle item. Though not many."
                    Return "Dispose of it in a recyclable bin if you do not want to recycle it."
                End If
            Case False
                If (IsReusable = True) Then
                    _Usage = "Though not biodigradable, there are many ways to recycle item."
                    Return "Should be Reused/Recycled to Avoid Dumbing"
                Else
                    _Usage = "Number of ways to recycle the item are very few."
                    Return "Dispose of it in a recyclable bin if you do not want to recycle item. Recycle with caution."
                End If
            Case Else
                Return Nothing
        End Select
    End Function

    'Method for Displaying Data
    Public Overrides Function Display() As String
        Return "Item Name: " & ItemName & Environment.NewLine &
                   "Type of material: " & Material & Environment.NewLine &
                   "Category : " & DetermineItemCategory() & Environment.NewLine &
                   "Warning: " & Warning() & Environment.NewLine &
                   "Usage: " & _Usage & Environment.NewLine & Environment.NewLine
    End Function

End Class
