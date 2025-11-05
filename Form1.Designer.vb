<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.web = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.web, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'web
        '
        Me.web.AllowExternalDrop = True
        Me.web.CreationProperties = Nothing
        Me.web.DefaultBackgroundColor = System.Drawing.Color.White
        Me.web.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web.Location = New System.Drawing.Point(0, 0)
        Me.web.Name = "web"
        Me.web.Size = New System.Drawing.Size(800, 450)
        Me.web.TabIndex = 0
        Me.web.ZoomFactor = 1.0R
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.web)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.web, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents web As Microsoft.Web.WebView2.WinForms.WebView2
End Class
