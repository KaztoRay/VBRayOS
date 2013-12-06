Public Class BootForm
    Inherits Form

    Private WithEvents bootTimer As Timer
    Private progressBar As ProgressBar
    Private logoLabel As Label

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        ' Form 설정
        Me.Text = "VBRayOS"
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.Black
        Me.TopMost = True

        ' 로고 라벨
        logoLabel = New Label()
        logoLabel.Text = "VBRayOS"
        logoLabel.Font = New Font("Arial", 48, FontStyle.Bold)
        logoLabel.ForeColor = Color.White
        logoLabel.BackColor = Color.Transparent
        logoLabel.AutoSize = True
        Me.Controls.Add(logoLabel)

        ' 프로그레스 바
        progressBar = New ProgressBar()
        progressBar.Width = 400
        progressBar.Height = 20
        progressBar.Minimum = 0
        progressBar.Maximum = 100
        progressBar.Value = 0
        Me.Controls.Add(progressBar)

        ' 타이머 설정
        bootTimer = New Timer()
        bootTimer.Interval = 100
        bootTimer.Enabled = True

        PositionControls()
    End Sub
End Class
