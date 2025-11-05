Imports Microsoft.Web.WebView2.Core

Public Class Form1

    Public Sub New()
        Application.EnableVisualStyles()

        InitializeComponent()

        Dim webview_environment As CoreWebView2Environment
        Dim msedgewebview2Folder As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)

        Dim user_data_folder As String = IO.Path.Combine(IO.Path.GetTempPath(), System.Reflection.Assembly.GetExecutingAssembly().GetName.Name)
        If IO.Directory.Exists(user_data_folder) = False Then IO.Directory.CreateDirectory(user_data_folder)

        msedgewebview2Folder = IO.Path.Combine(msedgewebview2Folder, "Microsoft\EdgeWebView\Application\")
        If IO.Directory.Exists(msedgewebview2Folder) Then
            For Each subs As IO.DirectoryInfo In New IO.DirectoryInfo(msedgewebview2Folder).GetDirectories()
                Dim tempv As New Version
                If Char.IsDigit(subs.Name.Chars(0)) AndAlso Version.TryParse(subs.Name, tempv) Then
                    Dim t = CoreWebView2Environment.CreateAsync(subs.FullName, user_data_folder)
                    t.Wait()
                    webview_environment = t.Result
                End If
            Next
        End If


        web.EnsureCoreWebView2Async(webview_environment, Nothing)
        web.Visible = False
    End Sub

    Private LoadURI As Uri
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Loading..."
        Dim args As String() = Environment.GetCommandLineArgs()
        If args.Length = 2 Then
            If IO.File.Exists(args(1)) Then
                If IO.Path.GetExtension(args(1)) = ".url" Then
                    For Each ll As String In IO.File.ReadAllLines(args(1))
                        If ll.StartsWith("URL=") Then
                            LoadURI = New Uri(ll.Substring(4))
                        ElseIf ll.StartsWith("IconFile=") Then
                            Me.Icon = New Icon(ll.Substring(9))
                        End If
                    Next
                Else
                    LoadURI = New Uri("file:///" & args(1))
                    Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(args(1))
                End If
            Else
                Try
                    LoadURI = New Uri(args(1))
                Catch ex As Exception
                    MsgBox("Call me with an URI or file as parameter" & vbCrLf & vbCrLf & ex.GetType().Name & ": " & ex.Message, MsgBoxStyle.Exclamation)
                    Me.Close()
                    Exit Sub
                End Try
            End If
        Else
            MsgBox("Call me with an URI or file as parameter", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub web_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles web.CoreWebView2InitializationCompleted
        web.Visible = True
        web.Source = LoadURI
    End Sub

    Private Sub web_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles web.NavigationCompleted
        Me.Text = web.CoreWebView2.DocumentTitle
    End Sub
End Class
