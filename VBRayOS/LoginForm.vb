Public Class LoginForm
    Inherits Form

    Private usernameTextBox As TextBox
    Private passwordTextBox As TextBox
    Private loginButton As Button
    Private usernameLabel As Label
    Private passwordLabel As Label
    Private titleLabel As Label

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        ' Form 설정
        Me.Text = "VBRayOS Login"
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.FromArgb(0, 120, 215) ' Windows 블루 색상
        Me.TopMost = True

        ' 제목 라벨
        titleLabel = New Label()
        titleLabel.Text = "Welcome to VBRayOS"
        titleLabel.Font = New Font("Segoe UI", 32, FontStyle.Regular)
        titleLabel.ForeColor = Color.White
        titleLabel.BackColor = Color.Transparent
        titleLabel.AutoSize = True
        Me.Controls.Add(titleLabel)

        ' 사용자명 라벨
        usernameLabel = New Label()
        usernameLabel.Text = "Username:"
        usernameLabel.Font = New Font("Segoe UI", 12)
        usernameLabel.ForeColor = Color.White
        usernameLabel.BackColor = Color.Transparent
        usernameLabel.AutoSize = True
        Me.Controls.Add(usernameLabel)

        ' 사용자명 텍스트박스
        usernameTextBox = New TextBox()
        usernameTextBox.Font = New Font("Segoe UI", 12)
        usernameTextBox.Width = 250
        usernameTextBox.Height = 30
        usernameTextBox.Text = "User"
        Me.Controls.Add(usernameTextBox)

        ' 패스워드 라벨
        passwordLabel = New Label()
        passwordLabel.Text = "Password:"
        passwordLabel.Font = New Font("Segoe UI", 12)
        passwordLabel.ForeColor = Color.White
        passwordLabel.BackColor = Color.Transparent
        passwordLabel.AutoSize = True
        Me.Controls.Add(passwordLabel)

        ' 패스워드 텍스트박스
        passwordTextBox = New TextBox()
        passwordTextBox.Font = New Font("Segoe UI", 12)
        passwordTextBox.Width = 250
        passwordTextBox.Height = 30
        passwordTextBox.PasswordChar = "*"c
        Me.Controls.Add(passwordTextBox)

        ' 로그인 버튼
        loginButton = New Button()
        loginButton.Text = "Login"
        loginButton.Font = New Font("Segoe UI", 12)
        loginButton.Width = 100
        loginButton.Height = 35
        loginButton.BackColor = Color.White
        loginButton.ForeColor = Color.Black
        loginButton.FlatStyle = FlatStyle.Flat
        AddHandler loginButton.Click, AddressOf LoginButton_Click
        Me.Controls.Add(loginButton)

        PositionControls()
        Me.AcceptButton = loginButton
    End Sub

    Private Sub PositionControls()
        Dim centerX As Integer = Me.Width \ 2
        Dim centerY As Integer = Me.Height \ 2

        titleLabel.Location = New Point(centerX - (titleLabel.Width \ 2), centerY - 150)
        usernameLabel.Location = New Point(centerX - 125, centerY - 80)
        usernameTextBox.Location = New Point(centerX - 125, centerY - 50)
        passwordLabel.Location = New Point(centerX - 125, centerY - 10)
        passwordTextBox.Location = New Point(centerX - 125, centerY + 20)
        loginButton.Location = New Point(centerX - 50, centerY + 70)
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs)
        ' 간단한 로그인 검증 (실제 구현에서는 더 복잡한 인증 필요)
        If usernameTextBox.Text.Trim() <> "" Then
            ' 데스크톱으로 전환
            Dim desktopForm As New DesktopForm()
            desktopForm.Show()
            Me.Hide()
        Else
            MessageBox.Show("Please enter a username.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub LoginForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If titleLabel IsNot Nothing Then
            PositionControls()
        End If
    End Sub
End Class
