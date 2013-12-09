Public Class FileManagerForm
    Inherits Form

    Private treeView As TreeView
    Private listView As ListView
    Private pathTextBox As TextBox
    Private toolStrip As ToolStrip
    Private backButton As ToolStripButton
    Private forwardButton As ToolStripButton
    Private upButton As ToolStripButton

    Public Sub New()
        InitializeComponent()
        LoadSystemDrives()
    End Sub

    Private Sub InitializeComponent()
        ' Form 설정
        Me.Text = "My Computer - VBRayOS"
        Me.Size = New Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = SystemIcons.Application

        ' 툴스트립
        toolStrip = New ToolStrip()
        toolStrip.Height = 25

        backButton = New ToolStripButton("◀")
        backButton.DisplayStyle = ToolStripItemDisplayStyle.Text
        toolStrip.Items.Add(backButton)

        forwardButton = New ToolStripButton("▶")
        forwardButton.DisplayStyle = ToolStripItemDisplayStyle.Text
        toolStrip.Items.Add(forwardButton)

        upButton = New ToolStripButton("↑")
        upButton.DisplayStyle = ToolStripItemDisplayStyle.Text
        toolStrip.Items.Add(upButton)

        Me.Controls.Add(toolStrip)

        ' 경로 텍스트박스
        pathTextBox = New TextBox()
        pathTextBox.Dock = DockStyle.Top
        pathTextBox.Font = New Font("Consolas", 10)
        pathTextBox.ReadOnly = True
        Me.Controls.Add(pathTextBox)

        ' 분할 패널
        Dim splitContainer As New SplitContainer()
        splitContainer.Dock = DockStyle.Fill
        splitContainer.SplitterDistance = 200

        ' 트리뷰 (폴더 구조)
        treeView = New TreeView()
        treeView.Dock = DockStyle.Fill
        treeView.ShowRootLines = True
        treeView.ShowPlusMinus = True
        splitContainer.Panel1.Controls.Add(treeView)

        ' 리스트뷰 (파일 목록)
        listView = New ListView()
        listView.Dock = DockStyle.Fill
        listView.View = View.Details
        listView.FullRowSelect = True
        listView.GridLines = True

        ' 리스트뷰 컬럼 추가
        listView.Columns.Add("Name", 200)
        listView.Columns.Add("Type", 100)
        listView.Columns.Add("Size", 100)
        listView.Columns.Add("Modified", 150)

        splitContainer.Panel2.Controls.Add(listView)
        Me.Controls.Add(splitContainer)

        AddHandler treeView.AfterSelect, AddressOf TreeView_AfterSelect
        AddHandler listView.DoubleClick, AddressOf ListView_DoubleClick
    End Sub

    Private Sub LoadSystemDrives()
        treeView.Nodes.Clear()
        
        Dim computerNode As TreeNode = treeView.Nodes.Add("Computer")
        computerNode.ImageIndex = 0
        
        Try
            For Each drive As System.IO.DriveInfo In System.IO.DriveInfo.GetDrives()
                If drive.IsReady Then
                    Dim driveNode As TreeNode = computerNode.Nodes.Add(drive.Name)
                    driveNode.Tag = drive.Name
                    driveNode.Nodes.Add("Loading...")
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error loading drives: " & ex.Message)
        End Try
        
        computerNode.Expand()
    End Sub

    Private Sub TreeView_AfterSelect(sender As Object, e As TreeViewEventArgs)
        If e.Node.Tag IsNot Nothing Then
            LoadDirectoryContents(e.Node.Tag.ToString())
        End If
    End Sub

    Private Sub LoadDirectoryContents(path As String)
        listView.Items.Clear()
        pathTextBox.Text = path

        Try
            Dim dirInfo As New System.IO.DirectoryInfo(path)
            
            ' 디렉토리 추가
            For Each dir As System.IO.DirectoryInfo In dirInfo.GetDirectories()
                Dim item As New ListViewItem(dir.Name)
                item.SubItems.Add("Folder")
                item.SubItems.Add("")
                item.SubItems.Add(dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm"))
                item.Tag = dir.FullName
                listView.Items.Add(item)
            Next

            ' 파일 추가
            For Each file As System.IO.FileInfo In dirInfo.GetFiles()
                Dim item As New ListViewItem(file.Name)
                item.SubItems.Add("File")
                item.SubItems.Add(FormatFileSize(file.Length))
                item.SubItems.Add(file.LastWriteTime.ToString("yyyy-MM-dd HH:mm"))
                item.Tag = file.FullName
                listView.Items.Add(item)
            Next

        Catch ex As UnauthorizedAccessException
            MessageBox.Show("Access denied: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Function FormatFileSize(bytes As Long) As String
        If bytes < 1024 Then Return bytes.ToString() & " B"
        If bytes < 1024 * 1024 Then Return (bytes \ 1024).ToString() & " KB"
        If bytes < 1024 * 1024 * 1024 Then Return (bytes \ (1024 * 1024)).ToString() & " MB"
        Return (bytes \ (1024 * 1024 * 1024)).ToString() & " GB"
    End Function

    Private Sub ListView_DoubleClick(sender As Object, e As EventArgs)
        If listView.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = listView.SelectedItems(0)
            Dim path As String = selectedItem.Tag.ToString()

            If selectedItem.SubItems(1).Text = "Folder" Then
                LoadDirectoryContents(path)
            Else
                Try
                    System.Diagnostics.Process.Start(path)
                Catch ex As Exception
                    MessageBox.Show("Cannot open file: " & ex.Message)
                End Try
            End If
        End If
    End Sub
End Class
