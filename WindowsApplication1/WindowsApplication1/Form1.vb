Imports System.IO
Imports System.IO.Compression


Public Class Form1
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim strFilePath As String

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main()
    End Sub

    Public Sub ZipCreate(ByVal strFilePath As String)

    End Sub
End Class

Module Module1
    Sub Main()
        Dim objOpenFileDialog As New OpenFileDialog

        ' ZIPファイルのパス
        Dim zipPath As String
        If objOpenFileDialog.ShowDialog = DialogResult.OK Then
            zipPath = objOpenFileDialog.FileName
            'TextBox1.Text = zipPath
            ' ファイルを書き出すフォルダーを作成する
            Const ExtractPath As String = "\Extract"
            Dim directoryInfo = Directory.CreateDirectory(ExtractPath)

            ' ZIPファイルを開いてZipArchiveオブジェクトを作る
            Using archive As ZipArchive = ZipFile.OpenRead(zipPath)
                ' 展開するファイルを選択する（ここでは、拡張子が".txt"のものとする）
                Dim allTextFiles _
                    = archive.Entries _
                .Where(Function(e) e.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase)) _
                .OrderBy(Function(e) e.FullName)
                Console.WriteLine("全{0}ファイル（txtファイルは{1}）",
                              archive.Entries.Count, allTextFiles.Count())

                ' 選択したファイルを指定したフォルダーに書き出す
                For Each entry As ZipArchiveEntry In allTextFiles
                    ' ZipArchiveEntryオブジェクトのExtractToFileメソッドにフルパスを渡す
                    entry.ExtractToFile(Path.Combine(ExtractPath, entry.FullName))
                    Console.WriteLine("展開: {0}", entry.FullName)
                Next
            End Using
        End If

#If DEBUG Then
        'Console.ReadKey()
#End If
    End Sub
End Module




