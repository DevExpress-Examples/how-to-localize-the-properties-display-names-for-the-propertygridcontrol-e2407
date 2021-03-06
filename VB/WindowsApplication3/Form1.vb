Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading
Imports DevExpress.XtraEditors



Namespace DXSample
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			radioGroup1.SelectedIndex = 2
		End Sub

		Private Shared Function CreateProduct() As Product
			Dim pr As New Product("123-12-23", "Orange", "Fruit", 12, 100)
			Return pr
		End Function


		Private Sub radioGroup1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioGroup1.SelectedIndexChanged
			Dim radioGroup As RadioGroup = TryCast(sender, RadioGroup)
			Dim cultureName As String = radioGroup.EditValue.ToString()

			SetCulture(cultureName)

			propertyGridControl1.SelectedObject = Nothing
			propertyGridControl1.Rows.Clear()
			propertyGridControl1.SelectedObject = CreateProduct()
		End Sub

		Private Shared Sub SetCulture(ByVal cultureName As String)
			Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(cultureName)
			Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(cultureName)
		End Sub
	End Class

	Public Class Product
		Private productCode_Renamed, name_Renamed, category_Renamed As String
		Private price_Renamed As Decimal
		Private quantity_Renamed As Integer

		Public Sub New(ByVal code As String, ByVal name As String, ByVal category As String, ByVal price As Decimal, ByVal quantity As Integer)
			Me.productCode_Renamed = code
			Me.name_Renamed = name
			Me.category_Renamed = category
			Me.price_Renamed = price
			Me.quantity_Renamed = quantity
		End Sub
		<CustomDisplayNameAttribute("ProductCode")> _
		Public Property ProductCode() As String
			Get
				Return productCode_Renamed
			End Get
			Set(ByVal value As String)
				productCode_Renamed = value
			End Set
		End Property
		<CustomDisplayNameAttribute("Name")> _
		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property
		<CustomDisplayNameAttribute("Category")> _
		Public Property Category() As String
			Get
				Return category_Renamed
			End Get
			Set(ByVal value As String)
				category_Renamed = value
			End Set
		End Property
		<CustomDisplayNameAttribute("Price")> _
		Public Property Price() As Decimal
			Get
				Return price_Renamed
			End Get
			Set(ByVal value As Decimal)
				price_Renamed = value
			End Set
		End Property
		<CustomDisplayNameAttribute("Quantity")> _
		Public Property Quantity() As Integer
			Get
				Return quantity_Renamed
			End Get
			Set(ByVal value As Integer)
				quantity_Renamed = value
			End Set
		End Property
	End Class

	Public Class CustomDisplayNameAttribute
		Inherits DisplayNameAttribute
		Public Sub New(ByVal displayName As String)
			MyBase.New(displayName)
		End Sub
		Public Overrides ReadOnly Property DisplayName() As String
			Get
				Return CustomLocalizer.GetLocalizedString(MyBase.DisplayName)
			End Get
		End Property
	End Class


	Public NotInheritable Class CustomLocalizer
		Private Sub New()
		End Sub
		Public Shared Function GetLocalizedString(ByVal name As String) As String
			If Thread.CurrentThread.CurrentCulture.Name = "fr-FR" Then
				If name = "ProductCode" Then
					Return "Produit Code"
				End If
				If name = "Name" Then
					Return "Nom"
				End If
				If name = "Category" Then
					Return "Catégorie"
				End If
				If name = "Price" Then
					Return "Prix"
				End If
				If name = "Quantity" Then
					Return "Quantité"
				End If
			Else
				If Thread.CurrentThread.CurrentCulture.Name = "de-DE" Then
					If name = "ProductCode" Then
						Return "Produkt Code"
					End If
					If name = "Name" Then
						Return "Name"
					End If
					If name = "Category" Then
						Return "Kategorie"
					End If
					If name = "Price" Then
						Return "Preis"
					End If
					If name = "Quantity" Then
						Return "Zahl"
					End If
				End If
			End If
			Return name
		End Function

	End Class
End Namespace





