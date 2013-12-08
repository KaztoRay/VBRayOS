Public Class DesktopForm
    Inherits Form

    Private taskbar As Panel
    Private startButton As Button
    Private clockLabel As Label
    Private WithEvents clockTimer As Timer
    Private desktopArea As Panel

    ' 데스크톱 아이콘들
    Private myComputerIcon As Button
    Private internetIcon As Button
    Private recycleIcon As Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        ' Form 설정
        Me.Text = "VBRayOS Desktop"
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.FromArgb(0, 120, 215) ' Windows 블루 배경
        Me.TopMost = True

        ' 데스크톱 영역
        desktopArea = New Panel()
        desktopArea.Dock = DockStyle.Fill
        desktopArea.BackColor = Color.FromArgb(0, 120, 215)
        Me.Controls.Add(desktopArea)

        ' 작업 표시줄
        taskbar = New Panel()
        taskbar.Height = 40
        taskbar.Dock = DockStyle.Bottom
        taskbar.BackColor = Color.FromArgb(32, 32, 32)
        Me.Controls.Add(taskbar)

        ' 시작 버튼
        startButton = New Button()
        startButton.Text = "Start"
        startButton.Width = 80
        startButton.Height = 35
        startButton.Location = New Point(5, 2)
        startButton.BackColor = Color.FromArgb(64, 64, 64)
        startButton.ForeColor = Color.White
        startButton.FlatStyle = FlatStyle.Flat
        AddHandler startButton.Click, AddressOf StartButton_Click
        taskbar.Controls.Add(startButton)

        ' 시계 라벨
        clockLabel = New Label()
        clockLabel.Font = New Font("Segoe UI", 9)
        clockLabel.ForeColor = Color.White
        clockLabel.BackColor = Color.Transparent
        clockLabel.AutoSize = True
        taskbar.Controls.Add(clockLabel)

        ' 시계 타이머
        clockTimer = New Timer()
        clockTimer.Interval = 1000
        clockTimer.Enabled = True
        UpdateClock()

        CreateDesktopIcons()
    End Sub

    Private Sub CreateDesktopIcons()
        ' 내 컴퓨터 아이콘
        myComputerIcon = New Button()
        myComputerIcon.Text = "My Computer" & vbCrLf & "내 컴퓨터"
        myComputerIcon.Width = 80
        myComputerIcon.Height = 80
        myComputerIcon.Location = New Point(50, 50)
        myComputerIcon.BackColor = Color.Transparent
        myComputerIcon.ForeColor = Color.White
        myComputerIcon.FlatStyle = FlatStyle.Flat
        myComputerIcon.FlatAppearance.BorderSize = 0
        myComputerIcon.Font = New Font("Segoe UI", 8)
        myComputerIcon.TextAlign = ContentAlignment.BottomCenter
        AddHandler myComputerIcon.Click, AddressOf MyComputerIcon_Click
        desktopArea.Controls.Add(myComputerIcon)

        ' 인터넷 아이콘
        internetIcon = New Button()
        internetIcon.Text = "Internet" & vbCrLf & "인터넷"
        internetIcon.Width = 80
        internetIcon.Height = 80
        internetIcon.Location = New Point(50, 150)
        internetIcon.BackColor = Color.Transparent
        internetIcon.ForeColor = Color.White
        internetIcon.FlatStyle = FlatStyle.Flat
        internetIcon.FlatAppearance.BorderSize = 0
        internetIcon.Font = New Font("Segoe UI", 8)
        internetIcon.TextAlign = ContentAlignment.BottomCenter
        AddHandler internetIcon.Click, AddressOf InternetIcon_Click
        desktopArea.Controls.Add(internetIcon)

        ' 휴지통 아이콘
        recycleIcon = New Button()
        recycleIcon.Text = "Recycle Bin" & vbCrLf & "휴지통"
        recycleIcon.Width = 80
        recycleIcon.Height = 80
        recycleIcon.Location = New Point(50, 250)
        recycleIcon.BackColor = Color.Transparent
        recycleIcon.ForeColor = Color.White
        recycleIcon.FlatStyle = FlatStyle.Flat
        recycleIcon.FlatAppearance.BorderSize = 0
        recycleIcon.Font = New Font("Segoe UI", 8)
        recycleIcon.TextAlign = ContentAlignment.BottomCenter
        AddHandler recycleIcon.Click, AddressOf RecycleIcon_Click
        desktopArea.Controls.Add(recycleIcon)
    End Sub

    Private Sub UpdateClock()
        clockLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        clockLabel.Location = New Point(taskbar.Width - clockLabel.Width - 10, 
                                       (taskbar.Height - clockLabel.Height) \ 2)
    End Sub

    Private Sub clockTimer_Tick(sender As Object, e As EventArgs) Handles clockTimer.Tick
        UpdateClock()
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("VBRayOS를 종료하시겠습니까?", "시작 메뉴", 
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub MyComputerIcon_Click(sender As Object, e As EventArgs)
        MessageBox.Show("내 컴퓨터가 실행되었습니다.", "내 컴퓨터", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub InternetIcon_Click(sender As Object, e As EventArgs)
        Try
            ' 기본 브라우저로 구글 열기
            System.Diagnostics.Process.Start("https://www.google.com")
        Catch ex As Exception
            MessageBox.Show("브라우저를 실행할 수 없습니다: " & ex.Message, "오류", 
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RecycleIcon_Click(sender As Object, e As EventArgs)
        MessageBox.Show("휴지통이 실행되었습니다.", "휴지통", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DesktopForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If clockLabel IsNot Nothing Then
            UpdateClock()
        End If
    End Sub
End Class
