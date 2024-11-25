Option Strict On

Public Class Archiv
    Public Sub New(url As String)
        Me.Handelstage = GetData(url)
    End Sub

    Private Function GetData(url As String) As List(Of Handelstag)
        Dim doc As XDocument = XDocument.Load(url)

        Dim qTage = doc.Root.Descendants() _
        .Where(Function(xe) xe.Name.LocalName = "Cube" And xe.Attributes().Any(Function(at) at.Name.LocalName = "time")) _
        .Select(Function(xe) _
                    New Handelstag(xe)
                    )

        Dim tage As List(Of Handelstag) = qTage.ToList()

        'For Each element As XElement In qTage
        '    Dim tag As Handelstag = New Handelstag With {.Datum = DateOnly.Parse(element.Attribute("time").Value)}
        '    tage.Add(tag)
        'Next

        Return tage
    End Function

    Public Property Handelstage As List(Of Handelstag)
End Class
