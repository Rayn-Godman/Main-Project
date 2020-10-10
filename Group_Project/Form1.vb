Option Strict On
Option Infer Off
Option Explicit On

Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class frmHousehold

    Private _houseObj As HouseHold
    Private numItems, numPeople As Integer
    Private totalRec As Integer = 0 'to get total recyclable items
    Private totalNon As Integer = 0 'To get total non-recyclable items
    Private recAve, nonAve As Double  'To get average of recyclable and non-recyclable respectively
    Private address As String 'Use for instantiation of household object

    Private FS As FileStream
    Private FileName As String = "ItemCategory.txt"  'Local file
    Private BF As BinaryFormatter

    'Enumeration for Items
    Enum ItemType
        Recyclable = 1
        Non_Recyclable = 2
    End Enum

    'Enumeration for Material of each item
    'These are the main materials used in most households
    Enum MaterialType
        Plastic = 1
        Glass = 2
        Metal = 3
        Organic = 4
        Paper = 5
        Textiles = 6
        Other = 7
    End Enum

    Private Sub BtnSetData_Click(sender As Object, e As EventArgs) Handles btnSetData.Click
        'Allow user to input data about household
        numPeople = CInt(InputBox("How many people live in your household?"))
        address = InputBox("What is the address of your houseshold?")
        numItems = CInt(InputBox("How many items do you want to capture?"))

        'Instantiation of Household object
        _houseObj = New HouseHold(numItems, numPeople, address)
        _houseObj.OwnerSurname = InputBox("What is the household owner's surname?")
        _houseObj.OwnerName = InputBox("Who is the household owner's name?")
    End Sub



    Private Sub BtnReadData_Click(sender As Object, e As EventArgs) Handles btnReadData.Click
        'Read in information for each item
        For r As Integer = 1 To numItems
            Dim choice As Integer = CInt(InputBox("What kind of item is item " & CStr(r) & "?" & Environment.NewLine &
                                                  "1- Recyclable Item" & Environment.NewLine &
                                                  "2- Non-Recyclable Item"))
            Dim name As String = InputBox("What is the name of the item?")
            Dim material As Integer = CInt(InputBox("What is the material type of the item?" & Environment.NewLine &
                                                    "1- Plastic" & Environment.NewLine &
                                                    "2- Glass" & Environment.NewLine &
                                                    "3- Metal" & Environment.NewLine &
                                                    "4- Organic" & Environment.NewLine &
                                                    "5- Paper" & Environment.NewLine &
                                                    "6- Textile" & Environment.NewLine &
                                                    "7- Other "))
            Dim serialnum As Integer = CInt(InputBox("What is the serial number of this itme?"))
            Dim bio As Boolean = CBool(InputBox("Is the item biodigradble? Enter True or False"))
            Dim reusable As Boolean = CBool(InputBox("Is the item reusable? Enter True or False"))

            'Use enumeration of ItemType to sort data of each item into either recyclable or non-recyclable
            'For each enumeration in ItemType delcare temporary Objects of either recyclable or non-recyclable depending on which option user picks
            'After information of each item is inputted up cast temporary recyclable or non-recyclable object into the Items array
            Select Case choice
                Case ItemType.Recyclable
                    Dim RecItem As Recyclable
                    RecItem = New Recyclable()
                    RecItem.ItemName = name
                    RecItem.MaterialNum = material
                    'Use of second enumeration called MaterialType to read in the material of the item depending on what the user chose
                    Select Case material
                        Case MaterialType.Plastic
                            RecItem.Material = "Plastic"
                        Case MaterialType.Glass
                            RecItem.Material = "Glass"
                        Case MaterialType.Metal
                            RecItem.Material = "Metal"
                        Case MaterialType.Organic
                            RecItem.Material = "Organic"
                        Case MaterialType.Paper
                            RecItem.Material = "Paper"
                        Case MaterialType.Textiles
                            RecItem.Material = "Textile"
                        Case MaterialType.Other
                            RecItem.Material = "Other"
                    End Select

                    RecItem.SerialNum = serialnum
                    RecItem.IsBiodigradable = bio
                    RecItem.IsReusable = reusable
                    totalRec += 1
                    _houseObj.Items(r) = RecItem


                Case ItemType.Non_Recyclable
                    Dim NonItem As Non_Recyclable
                    NonItem = New Non_Recyclable()
                    NonItem.ItemName = name
                    NonItem.MaterialNum = material
                    Select Case material
                        'Use of second enumeration called MaterialType to read in the material of the item depending on what the user chose
                        Case MaterialType.Plastic
                            NonItem.Material = "Plastic"
                        Case MaterialType.Glass
                            NonItem.Material = "Glass"
                        Case MaterialType.Metal
                            NonItem.Material = "Metal"
                        Case MaterialType.Organic
                            NonItem.Material = "Organic"
                        Case MaterialType.Paper
                            NonItem.Material = "Paper"
                        Case MaterialType.Textiles
                            NonItem.Material = "Textile"
                        Case MaterialType.Other
                            NonItem.Material = "Other"
                    End Select

                    NonItem.SerialNum = serialnum
                    NonItem.IsBiodigradable = bio
                    NonItem.IsReusable = reusable
                    totalNon += 1
                    _houseObj.Items(r) = NonItem
            End Select
        Next

    End Sub


    Private Sub BtnDetailsItem_Click(sender As Object, e As EventArgs) Handles btnDetailsItem.Click
        'Display information of each item in textbox
        For r As Integer = 1 To numItems
            txtDisplayItem.Text &= _houseObj.Items(r).Display()
        Next
    End Sub


    Private Sub BtnHouseDetails_Click(sender As Object, e As EventArgs) Handles btnHouseDetails.Click
        'Get averages of recyclable items and non-recyclable items
        recAve = _houseObj.CalcAverage(totalRec)
        nonAve = _houseObj.CalcAverage(totalNon)

        'Display information of household in textbox 
        txtDisplayHouse.Text &= _houseObj.Display() & "Household Rating: " & _houseObj.CalcHouseRating(recAve, nonAve)
    End Sub


    Private Sub BtnCategory_Click(sender As Object, e As EventArgs) Handles btnCategory.Click
        txtDisplayItem.Clear()
        'Display category which each item belongs to by use of the MyClass function
        For r As Integer = 1 To numItems
            txtDisplayItem.Text &= "Category for Item " & CStr(r) & ": " & _houseObj.Items(r).ItemCategory() & Environment.NewLine
        Next
    End Sub

    Private Sub BtnCreateFile_Click(sender As Object, e As EventArgs) Handles btnCreateFile.Click
        'Declare instantiation of Filestream to create file 
        'Declare instatiation of Binary Formatter
        FS = New FileStream(FileName, FileMode.Create, FileAccess.ReadWrite)
        BF = New BinaryFormatter()
        FS.Close()

    End Sub


    Private Sub BtnSaveFile_Click(sender As Object, e As EventArgs) Handles btnSaveFile.Click
        'Declare filestream by opening file and write data to it
        FS = New FileStream(FileName, FileMode.Open, FileAccess.Write)
        BF = New BinaryFormatter()

        'Save objects to file by serializing recyclable object only in array
        For r As Integer = 1 To numItems
            If (TypeOf _houseObj.Items(r) Is Recyclable) Then
                Dim ItemRec As Recyclable
                ItemRec = DirectCast(_houseObj.Items(r), Recyclable)
                BF.Serialize(FS, ItemRec)
            End If
        Next
        FS.Close()
    End Sub


    Private Sub BtnFileRead_Click(sender As Object, e As EventArgs) Handles btnFileRead.Click

        txtDisplayItem.Clear()
        'Declare local variables to add in total of a specific type of item material
        Dim totalA As Integer = 0
        Dim totalB As Integer = 0
        Dim totalC As Integer = 0
        Dim totalD As Integer = 0
        Dim totalE As Integer = 0
        Dim totalF As Integer = 0
        Dim totalG As Integer = 0

        'Open File Stream and read File
        FS = New FileStream(FileName, FileMode.Open, FileAccess.Read)
        BF = New BinaryFormatter()

        While FS.Position < FS.Length
            'Declare local variable Items then directcast each desrialized recyclable object in the File into Items
            'Then Declare if statements to get totals of each RECYCLABLE item material
            Dim ItemCat As Recyclable
            ItemCat = DirectCast(BF.Deserialize(FS), Recyclable)
            If ItemCat.Material = "Plastic" Then
                totalA += 1
            ElseIf ItemCat.Material = "Glass" Then
                totalB += 1
            ElseIf ItemCat.Material = "Metal" Then
                totalC += 1
            ElseIf ItemCat.Material = "Organic" Then
                totalD += 1
            ElseIf ItemCat.Material = "Paper" Then
                totalE += 1
            ElseIf ItemCat.Material = "Textile" Then
                totalF += 1
            ElseIf ItemCat.Material = "Other" Then
                totalG += 1
            End If
        End While

        'Display objects in textbox
        txtDisplayItem.Text &= "Information on Recyclable Items:" & Environment.NewLine & Environment.NewLine &
                    "Total Plastic Items: " & totalA & Environment.NewLine &
                    "Total Glass Items: " & totalB & Environment.NewLine &
                    "Total Metal Items: " & totalC & Environment.NewLine &
                    "Total Organic Items: " & totalD & Environment.NewLine &
                    "Total Paper Items: " & totalE & Environment.NewLine &
                    "Total Textile Items: " & totalF & Environment.NewLine &
                    "Total Other Items: " & totalG & Environment.NewLine

        FS.Close()

    End Sub


End Class

