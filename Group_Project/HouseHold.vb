Option Explicit On
Option Strict On
Option Infer Off
<Serializable> Public Class HouseHold
    Implements IPerson

    Private _Items() As Items
    Private _NumItems As Integer
    Private _Address As String
    Private _NumberPeople As Integer  'to get number of people per household including owner
    Private _PersonName As String ' to record name of Item owner
    Private _PersonSurname As String ' to record Surname of item owener

    'Constructor accepting three parameters and resizing Items array
    Public Sub New(NumItems As Integer, numPeople As Integer, Address As String)
        _NumberPeople = numPeople
        _NumItems = ValidInt(NumItems) ' Number of items cannot be less than zero
        _Address = Address
        ReDim _Items(_NumItems)

        For i As Integer = 1 To NumItems
            _Items(i) = New Items()
        Next
    End Sub


    Public ReadOnly Property Address As String
        Get
            Return _Address
        End Get
    End Property
    ' Declare properties for every attribute
    Public Property Items(Index As Integer) As Items
        Get
            Return _Items(Index)
        End Get
        Set(value As Items)
            _Items(Index) = value
        End Set
    End Property

    Public Property NumItems As Integer
        Get
            Return _NumItems
        End Get
        Set(value As Integer)
            _NumItems = ValidInt(value)
        End Set
    End Property

    Public Property OwnerName As String Implements IPerson.Name
        Get
            Return _PersonName
        End Get
        Set(value As String)
            _PersonName = value
        End Set
    End Property

    Public Property OwnerSurname As String Implements IPerson.Surname
        Get
            Return _PersonSurname
        End Get
        Set(value As String)
            _PersonSurname = value
        End Set
    End Property

    Public Property NumberPeople As Integer
        Get
            Return _NumberPeople
        End Get
        Set(value As Integer)
            _NumberPeople = ValidInt(value)
        End Set
    End Property

    ' Function to turn nagative integer to zero
    Protected Function ValidInt(Value As Integer) As Integer
        If (Value < 0) Then
            Return 0
        Else
            Return Value
        End If
    End Function


    Public Function CalcAverage(num As Double) As Double 'function calculates average waste disposed of non_recycable or recycable items 
        Dim average As Double
        average = num / _NumItems
        Return average
    End Function

    'Function that will return rating of household based on each average of recycable and non recycable items 
    Public Function CalcHouseRating(RecyclableAve As Double, NonRecyclableAve As Double) As String
        Dim rating As String
        If RecyclableAve > NonRecyclableAve Then
            rating = "Good"

        ElseIf RecyclableAve = NonRecyclableAve Then
            rating = "Okay"
        Else
            rating = "Bad. Need to buy more items that are recyclable."
        End If
        Return rating
    End Function

    'Function that Displays information of household
    Public Function Display() As String
        Return "Owner Name & Surname: " & _PersonName & " " & _PersonSurname & Environment.NewLine &
            "Number Of People in the House: " & CStr(_NumberPeople) & Environment.NewLine &
            "Address: " & _Address & Environment.NewLine
    End Function
End Class
