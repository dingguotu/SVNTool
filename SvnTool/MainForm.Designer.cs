
namespace SvnTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlBtn = new System.Windows.Forms.Button();
            this.urlFBD = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.startDTP = new System.Windows.Forms.DateTimePicker();
            this.endDTP = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.logBtn = new System.Windows.Forms.Button();
            this.logDataGrid = new System.Windows.Forms.DataGridView();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appendLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logFormatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.authorCMB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.appendBox = new System.Windows.Forms.TextBox();
            this.removeBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.totalBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logFormatBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目位置：";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(93, 35);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(355, 21);
            this.urlTextBox.TabIndex = 1;
            // 
            // urlBtn
            // 
            this.urlBtn.Location = new System.Drawing.Point(454, 34);
            this.urlBtn.Name = "urlBtn";
            this.urlBtn.Size = new System.Drawing.Size(67, 23);
            this.urlBtn.TabIndex = 2;
            this.urlBtn.Text = "浏览";
            this.urlBtn.UseVisualStyleBackColor = true;
            this.urlBtn.Click += new System.EventHandler(this.urlBtn_Click);
            // 
            // urlFBD
            // 
            this.urlFBD.Description = "请选择需要统计的项目";
            this.urlFBD.ShowNewFolderButton = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "开始时间：";
            // 
            // startDTP
            // 
            this.startDTP.Checked = false;
            this.startDTP.Location = new System.Drawing.Point(93, 79);
            this.startDTP.Name = "startDTP";
            this.startDTP.Size = new System.Drawing.Size(131, 21);
            this.startDTP.TabIndex = 4;
            // 
            // endDTP
            // 
            this.endDTP.Location = new System.Drawing.Point(316, 79);
            this.endDTP.Name = "endDTP";
            this.endDTP.Size = new System.Drawing.Size(132, 21);
            this.endDTP.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "结束时间：";
            // 
            // logBtn
            // 
            this.logBtn.Location = new System.Drawing.Point(454, 78);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(67, 23);
            this.logBtn.TabIndex = 7;
            this.logBtn.Text = "拉取日志";
            this.logBtn.UseVisualStyleBackColor = true;
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
            // 
            // logDataGrid
            // 
            this.logDataGrid.AllowUserToAddRows = false;
            this.logDataGrid.AllowUserToDeleteRows = false;
            this.logDataGrid.AutoGenerateColumns = false;
            this.logDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.authorDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.appendLinesDataGridViewTextBoxColumn,
            this.removeLinesDataGridViewTextBoxColumn,
            this.totalLinesDataGridViewTextBoxColumn,
            this.checkTimeDataGridViewTextBoxColumn});
            this.logDataGrid.DataSource = this.logFormatBindingSource;
            this.logDataGrid.Location = new System.Drawing.Point(12, 166);
            this.logDataGrid.Name = "logDataGrid";
            this.logDataGrid.ReadOnly = true;
            this.logDataGrid.RowTemplate.Height = 23;
            this.logDataGrid.Size = new System.Drawing.Size(660, 226);
            this.logDataGrid.TabIndex = 8;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "author";
            this.authorDataGridViewTextBoxColumn.HeaderText = "作者";
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            this.authorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "fileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "文件名";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // appendLinesDataGridViewTextBoxColumn
            // 
            this.appendLinesDataGridViewTextBoxColumn.DataPropertyName = "appendLines";
            this.appendLinesDataGridViewTextBoxColumn.HeaderText = "增加的行数";
            this.appendLinesDataGridViewTextBoxColumn.Name = "appendLinesDataGridViewTextBoxColumn";
            this.appendLinesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // removeLinesDataGridViewTextBoxColumn
            // 
            this.removeLinesDataGridViewTextBoxColumn.DataPropertyName = "removeLines";
            this.removeLinesDataGridViewTextBoxColumn.HeaderText = "删除的行数";
            this.removeLinesDataGridViewTextBoxColumn.Name = "removeLinesDataGridViewTextBoxColumn";
            this.removeLinesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalLinesDataGridViewTextBoxColumn
            // 
            this.totalLinesDataGridViewTextBoxColumn.DataPropertyName = "totalLines";
            this.totalLinesDataGridViewTextBoxColumn.HeaderText = "总行数";
            this.totalLinesDataGridViewTextBoxColumn.Name = "totalLinesDataGridViewTextBoxColumn";
            this.totalLinesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkTimeDataGridViewTextBoxColumn
            // 
            this.checkTimeDataGridViewTextBoxColumn.DataPropertyName = "checkTime";
            this.checkTimeDataGridViewTextBoxColumn.HeaderText = "提交时间";
            this.checkTimeDataGridViewTextBoxColumn.Name = "checkTimeDataGridViewTextBoxColumn";
            this.checkTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logFormatBindingSource
            // 
            this.logFormatBindingSource.DataSource = typeof(SvnTool.LogFormat);
            // 
            // authorCMB
            // 
            this.authorCMB.FormattingEnabled = true;
            this.authorCMB.Location = new System.Drawing.Point(93, 123);
            this.authorCMB.Name = "authorCMB";
            this.authorCMB.Size = new System.Drawing.Size(88, 20);
            this.authorCMB.TabIndex = 9;
            this.authorCMB.SelectedValueChanged += new System.EventHandler(this.authorCMB_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "作  者：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "增加的行数：";
            // 
            // appendBox
            // 
            this.appendBox.Location = new System.Drawing.Point(281, 123);
            this.appendBox.Name = "appendBox";
            this.appendBox.ReadOnly = true;
            this.appendBox.Size = new System.Drawing.Size(70, 21);
            this.appendBox.TabIndex = 12;
            // 
            // removeBox
            // 
            this.removeBox.Location = new System.Drawing.Point(454, 122);
            this.removeBox.Name = "removeBox";
            this.removeBox.ReadOnly = true;
            this.removeBox.Size = new System.Drawing.Size(67, 21);
            this.removeBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "删除的行数：";
            // 
            // totalBox
            // 
            this.totalBox.Location = new System.Drawing.Point(605, 123);
            this.totalBox.Name = "totalBox";
            this.totalBox.ReadOnly = true;
            this.totalBox.Size = new System.Drawing.Size(67, 21);
            this.totalBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(546, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "总行数：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 429);
            this.Controls.Add(this.totalBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.removeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.appendBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.authorCMB);
            this.Controls.Add(this.logDataGrid);
            this.Controls.Add(this.logBtn);
            this.Controls.Add(this.endDTP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startDTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlBtn);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SVNLog";
            ((System.ComponentModel.ISupportInitialize)(this.logDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logFormatBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button urlBtn;
        private System.Windows.Forms.FolderBrowserDialog urlFBD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker startDTP;
        private System.Windows.Forms.DateTimePicker endDTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button logBtn;
        private System.Windows.Forms.DataGridView logDataGrid;
        private System.Windows.Forms.ComboBox authorCMB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appendLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn removeLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource logFormatBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox appendBox;
        private System.Windows.Forms.TextBox removeBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox totalBox;
        private System.Windows.Forms.Label label7;
    }
}

