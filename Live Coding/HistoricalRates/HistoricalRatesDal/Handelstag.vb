Imports System.Globalization

Public Class Handelstag
    ''' <summary>
    ''' Erzeugt ein neues Handelstag-Objekt aus einem XElement
    ''' </summary>
    ''' <param name="handelstagNode">Ein GESMES-XML-Node, der einen Handelstag repräsentiert</param>
    Public Sub New(handelstagNode As XElement)
        Me.Datum = System.DateOnly.Parse(handelstagNode.Attribute("time").Value)

        Dim qWaehrungen = handelstagNode.Elements().Select(Function(xe) New Waehrung With {
                                                               .Symbol = xe.Attribute("currency").Value,
                                                               .Eurokurs = Double.Parse(xe.Attribute("rate").Value, provider:=NumberFormatInfo.InvariantInfo)})

        Me.Waehrungen = qWaehrungen.ToList()
    End Sub

    Public Property Waehrungen As List(Of Waehrung)

    Public Property Datum As System.DateOnly
End Class
