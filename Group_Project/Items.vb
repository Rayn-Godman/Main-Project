Option Strict On
Option Infer Off
Option Explicit On

<Serializable> Public Class Items

    'Declare instance variables
    Private _ItemName As String
    Private _MaterialType As String
    Private _MaterialNum As Integer 'For enumeration. See in form
    Private _SerialNum As Integer
    Private _IsReusable As Boolean
    Private _IsBiodigradable As Boolean



    'Declare all property methods for each of the instance variables
    Public Property ItemName As String
        Get
            Return _ItemName
        End Get
        Set(value As String)
            _ItemName = value
        End Set
    End Property

    Public Property Material As String
        Get
            Return _MaterialType
        End Get
        Set(value As String)
            _MaterialType = value
        End Set
    End Property

    Public Property MaterialNum As Integer
        Get
            Return _MaterialNum
        End Get
        Set(value As Integer)
            _MaterialNum = ValidInt(value)
        End Set
    End Property

    Public Property SerialNum As Integer
        Get
            Return _SerialNum
        End Get
        Set(value As Integer)
            _SerialNum = value
        End Set
    End Property

    Public Property IsReusable As Boolean
        Get
            Return _IsReusable
        End Get
        Set(value As Boolean)
            _IsReusable = value
        End Set
    End Property

    Public Property IsBiodigradable As Boolean
        Get
            Return _IsBiodigradable
        End Get
        Set(value As Boolean)
            _IsBiodigradable = value
        End Set
    End Property


    'Function to validate any property methods
    Protected Function ValidInt(num As Integer) As Integer
        If num < 0 Then
            Return 0
        Else
            Return num
        End If
    End Function

    'Function to validate any property methods
    Protected Function ValidDouble(num As Double) As Double
        If num < 0 Then
            Return 0
        Else
            Return num
        End If
    End Function

    'Function that determine where each item should go in a category
    Public Overridable Function DetermineItemCategory() As String
        Dim category As String = "Unknown"
        Select Case Material
            Case "Plastic"
                category = "A"
            Case "Glass"
                category = "B"
            Case "Organic"
                category = "C"
            Case "Paper"
                category = "D"
            Case "Textile"
                category = "E"
            Case "Metal"
                category = "F"
            Case "Other"
                category = "G"
        End Select
        Return category
    End Function

    'Function that gives a warning, telling the user what to do with item depending on if it is biodigradble or not.
    Public Overridable Function Warning() As String
        Select Case IsBiodigradable
            Case True
                If (IsReusable = True) Then
                    Return "Should be Reused/Donated to Avoid Dumbing"
                Else
                    Return "Dispose of it in a recyclable bin. It is less harmful to environment"
                End If
            Case False
                If (IsReusable = True) Then
                    Return "Should be Reused/Donated to Avoid Dumbing"
                Else
                    Return "Dispose of it in a non-recyclable bin. It is very Harmful to the Environment. Disposal of this item should be limited"
                End If
            Case Else
                Return Nothing
        End Select
    End Function

    'Display Function to display data
    Public Overridable Function Display() As String
        Return "Item Name: " & ItemName & Environment.NewLine &
            "Type of material: " & Material & Environment.NewLine
    End Function

    'Use of my MyClass to display category Item belongs in
    Public Function ItemCategory() As String
        Return MyClass.DetermineItemCategory()
    End Function

End Class
