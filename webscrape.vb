
Option Explicit On
Option Strict On

Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions


Namespace Application
	Private Sub Scrape()
        Try
            Dim strURL As String = "http://codeguru.com"
            Dim strOutput As String = ""

            Dim wrResponse As WebReponse
            Dim weRequest As WebRequest = HttpWebRequest.Create(strURL)

            txtScrape.Text = "Extracting..." & Environment.NewLine

            wrResponse = wrRequest.GetResponse()

            Using sr As New StreamReader(wrResponse.GetResponseStream())
               strOutput = sr.ReadToEnd()
               ' Close and clean up the sr.
               sr.Close()
            End Using

            txtScrape.Text = strOutput

                      'Formatting Techniques

            ' Remove Doctype ( HTML 5 )
            strOutput = Regex.Replace(strOutput, "<!(.|\s)*?>", "")

            ' Remove HTML Tags
            strOutput = Regex.Replace(strOutput, "</?[a-z][a-z0-9]*[^<>]*>", "")

            ' Remove HTML Comments
            strOutput = Regex.Replace(strOutput, "<!--(.|\s)*?-->", "")

            ' Remove Script Tags
            strOutput = Regex.Replace(strOutput, "<script.*?</script>", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)

            ' Remove Stylesheets
            strOutput = Regex.Replace(strOutput, "<style.*?</style>", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)

            txtFormatted.Text = strOutput 'write Formatted Output To Separate TB

        Catch ex As Exception
            Console.WriteLine(ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnExtract_Click(sender As Object, e As EventArgs) Handles btnExtract.Click
        Scrape() 'Scrape text from the url.
    End Sub
End Namespace


' credit: https://www.codeguru.com/visual-basic/creating-a-web-text-scraper-with-visual-basic/
