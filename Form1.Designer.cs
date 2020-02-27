namespace WCO_NetMon
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Import = new System.Windows.Forms.TabPage();
            this.bttnSendToWeb = new System.Windows.Forms.Button();
            this.dgvLogFiles = new System.Windows.Forms.DataGridView();
            this.bttn_LogFile = new System.Windows.Forms.Button();
            this.logData = new System.Windows.Forms.TabPage();
            this.bttn_ReadLogs = new System.Windows.Forms.Button();
            this.dgvLogData = new System.Windows.Forms.DataGridView();
            this.byTime = new System.Windows.Forms.TabPage();
            this.dgvLogEvent = new System.Windows.Forms.DataGridView();
            this.byMach = new System.Windows.Forms.TabPage();
            this.bttn_SaveReport = new System.Windows.Forms.Button();
            this.dgvLogByMach = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bttn_Quit = new System.Windows.Forms.Button();
            this.saveReportFile = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.Import.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogFiles)).BeginInit();
            this.logData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogData)).BeginInit();
            this.byTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogEvent)).BeginInit();
            this.byMach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogByMach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "N M Soft";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Import);
            this.tabControl1.Controls.Add(this.logData);
            this.tabControl1.Controls.Add(this.byTime);
            this.tabControl1.Controls.Add(this.byMach);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(34, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 334);
            this.tabControl1.TabIndex = 1;
            // 
            // Import
            // 
            this.Import.Controls.Add(this.bttnSendToWeb);
            this.Import.Controls.Add(this.dgvLogFiles);
            this.Import.Controls.Add(this.bttn_LogFile);
            this.Import.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Import.Location = new System.Drawing.Point(4, 29);
            this.Import.Name = "Import";
            this.Import.Padding = new System.Windows.Forms.Padding(3);
            this.Import.Size = new System.Drawing.Size(688, 301);
            this.Import.TabIndex = 0;
            this.Import.Text = "Import";
            this.Import.UseVisualStyleBackColor = true;
            // 
            // bttnSendToWeb
            // 
            this.bttnSendToWeb.Location = new System.Drawing.Point(275, 244);
            this.bttnSendToWeb.Name = "bttnSendToWeb";
            this.bttnSendToWeb.Size = new System.Drawing.Size(116, 51);
            this.bttnSendToWeb.TabIndex = 107;
            this.bttnSendToWeb.Text = "Send To Web";
            this.bttnSendToWeb.UseVisualStyleBackColor = true;
            this.bttnSendToWeb.Click += new System.EventHandler(this.bttnSendToWeb_Click);
            // 
            // dgvLogFiles
            // 
            this.dgvLogFiles.AllowUserToAddRows = false;
            this.dgvLogFiles.AllowUserToDeleteRows = false;
            this.dgvLogFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogFiles.Location = new System.Drawing.Point(7, 6);
            this.dgvLogFiles.Name = "dgvLogFiles";
            this.dgvLogFiles.Size = new System.Drawing.Size(675, 153);
            this.dgvLogFiles.TabIndex = 106;
            // 
            // bttn_LogFile
            // 
            this.bttn_LogFile.Location = new System.Drawing.Point(3, 247);
            this.bttn_LogFile.Name = "bttn_LogFile";
            this.bttn_LogFile.Size = new System.Drawing.Size(75, 51);
            this.bttn_LogFile.TabIndex = 0;
            this.bttn_LogFile.Text = "Log File";
            this.bttn_LogFile.UseVisualStyleBackColor = true;
            this.bttn_LogFile.Click += new System.EventHandler(this.bttn_LogFile_Click);
            // 
            // logData
            // 
            this.logData.Controls.Add(this.bttn_ReadLogs);
            this.logData.Controls.Add(this.dgvLogData);
            this.logData.Location = new System.Drawing.Point(4, 29);
            this.logData.Name = "logData";
            this.logData.Size = new System.Drawing.Size(688, 301);
            this.logData.TabIndex = 3;
            this.logData.Text = "Log Data";
            this.logData.UseVisualStyleBackColor = true;
            // 
            // bttn_ReadLogs
            // 
            this.bttn_ReadLogs.Location = new System.Drawing.Point(66, 247);
            this.bttn_ReadLogs.Name = "bttn_ReadLogs";
            this.bttn_ReadLogs.Size = new System.Drawing.Size(75, 51);
            this.bttn_ReadLogs.TabIndex = 108;
            this.bttn_ReadLogs.Text = "Read Logs";
            this.bttn_ReadLogs.UseVisualStyleBackColor = true;
            this.bttn_ReadLogs.Click += new System.EventHandler(this.bttn_ReadLogs_Click);
            // 
            // dgvLogData
            // 
            this.dgvLogData.AllowUserToAddRows = false;
            this.dgvLogData.AllowUserToDeleteRows = false;
            this.dgvLogData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogData.Location = new System.Drawing.Point(3, 3);
            this.dgvLogData.Name = "dgvLogData";
            this.dgvLogData.Size = new System.Drawing.Size(675, 153);
            this.dgvLogData.TabIndex = 107;
            // 
            // byTime
            // 
            this.byTime.Controls.Add(this.dgvLogEvent);
            this.byTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byTime.Location = new System.Drawing.Point(4, 29);
            this.byTime.Name = "byTime";
            this.byTime.Padding = new System.Windows.Forms.Padding(3);
            this.byTime.Size = new System.Drawing.Size(688, 301);
            this.byTime.TabIndex = 1;
            this.byTime.Text = "By Time";
            this.byTime.UseVisualStyleBackColor = true;
            // 
            // dgvLogEvent
            // 
            this.dgvLogEvent.AllowUserToAddRows = false;
            this.dgvLogEvent.AllowUserToDeleteRows = false;
            this.dgvLogEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogEvent.Location = new System.Drawing.Point(6, 6);
            this.dgvLogEvent.Name = "dgvLogEvent";
            this.dgvLogEvent.Size = new System.Drawing.Size(675, 153);
            this.dgvLogEvent.TabIndex = 108;
            // 
            // byMach
            // 
            this.byMach.Controls.Add(this.bttn_SaveReport);
            this.byMach.Controls.Add(this.dgvLogByMach);
            this.byMach.Location = new System.Drawing.Point(4, 29);
            this.byMach.Name = "byMach";
            this.byMach.Size = new System.Drawing.Size(688, 301);
            this.byMach.TabIndex = 2;
            this.byMach.Text = "By Machine";
            this.byMach.UseVisualStyleBackColor = true;
            // 
            // bttn_SaveReport
            // 
            this.bttn_SaveReport.Location = new System.Drawing.Point(210, 247);
            this.bttn_SaveReport.Name = "bttn_SaveReport";
            this.bttn_SaveReport.Size = new System.Drawing.Size(75, 51);
            this.bttn_SaveReport.TabIndex = 110;
            this.bttn_SaveReport.Text = "Save Report";
            this.bttn_SaveReport.UseVisualStyleBackColor = true;
            this.bttn_SaveReport.Click += new System.EventHandler(this.bttn_SaveReport_Click);
            // 
            // dgvLogByMach
            // 
            this.dgvLogByMach.AllowUserToAddRows = false;
            this.dgvLogByMach.AllowUserToDeleteRows = false;
            this.dgvLogByMach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogByMach.Location = new System.Drawing.Point(3, 3);
            this.dgvLogByMach.Name = "dgvLogByMach";
            this.dgvLogByMach.Size = new System.Drawing.Size(675, 153);
            this.dgvLogByMach.TabIndex = 109;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog.FilterIndex = 0;
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Log File to Read";
            // 
            // bttn_Quit
            // 
            this.bttn_Quit.Location = new System.Drawing.Point(713, 407);
            this.bttn_Quit.Name = "bttn_Quit";
            this.bttn_Quit.Size = new System.Drawing.Size(75, 31);
            this.bttn_Quit.TabIndex = 2;
            this.bttn_Quit.Text = "Quit";
            this.bttn_Quit.UseVisualStyleBackColor = true;
            this.bttn_Quit.Click += new System.EventHandler(this.bttn_Quit_Click);
            // 
            // saveReportFile
            // 
            this.saveReportFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveReportFile.FilterIndex = 0;
            this.saveReportFile.Title = "Report File to Save To";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttn_Quit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Network Monitoring App";
            this.tabControl1.ResumeLayout(false);
            this.Import.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogFiles)).EndInit();
            this.logData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogData)).EndInit();
            this.byTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogEvent)).EndInit();
            this.byMach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogByMach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Import;
        private System.Windows.Forms.TabPage byTime;
        private System.Windows.Forms.TabPage byMach;
        private System.Windows.Forms.Button bttn_LogFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button bttn_Quit;
        private System.Windows.Forms.DataGridView dgvLogFiles;
        private System.Windows.Forms.TabPage logData;
        private System.Windows.Forms.Button bttn_ReadLogs;
        private System.Windows.Forms.DataGridView dgvLogData;
        private System.Windows.Forms.DataGridView dgvLogEvent;
        private System.Windows.Forms.DataGridView dgvLogByMach;
        private System.Windows.Forms.Button bttn_SaveReport;
        private System.Windows.Forms.SaveFileDialog saveReportFile;
        private System.Windows.Forms.Button bttnSendToWeb;
    }
}

