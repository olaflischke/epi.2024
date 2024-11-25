Imports HistoricalRatesDal
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace HistoricalRatesUintTests
    <TestClass>
    Public Class ArchivTests

        Dim url As String = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml"

        <TestMethod>
        Sub CanArchivInitialisieren()
            Dim archiv As New Archiv(url)

            Console.WriteLine($"Gefundene Handelstage: {archiv.Handelstage.Count:0.00}")

            Dim tag As Handelstag = archiv.Handelstage.FirstOrDefault()
            If tag IsNot Nothing Then
                Dim waehrung As Waehrung = tag.Waehrungen.FirstOrDefault()

                Console.WriteLine($"Datum: {tag.Datum}, {waehrung.Symbol}: {waehrung.Eurokurs:#,##0.0000}")
            End If

            Assert.AreEqual(GetAttributeCount("time"), archiv.Handelstage.Count)
        End Sub

        Function GetAttributeCount(attribute As String)
            ' TODO: Implement this method
            Return 64
        End Function

    End Class
End Namespace

