using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WCO_NetMon
{
    public partial class MainForm : Form
    {
        public LogFileClass LogFiles;

        public MainForm()
        {
            InitializeComponent();
            LogFiles = new LogFileClass();
            LogFiles.InitValues();

            //set up the initial table
            dgvLogFiles.DataSource = new List<LogFileClass.Disp_LogFiles_rec>();
            LogFileList_refresh();
        }


        private void LogFileList_refresh()
        {
            //refresh the log file list
            if (LogFiles.Disp_LogFile_table.Count() > 0)
            {
                dgvLogFiles.DataSource = new List<LogFileClass.Disp_LogFiles_rec>();
                dgvLogFiles.Refresh();
                dgvLogFiles.DataSource = LogFiles.Disp_LogFile_table;
            };

            dgvLogFiles.Columns[0].HeaderText = " # ";
            dgvLogFiles.Columns[0].Width = 60;
            dgvLogFiles.Columns[0].ReadOnly = true;
            dgvLogFiles.Columns[0].Visible = true;

            dgvLogFiles.Columns[1].HeaderText = "File ";
            dgvLogFiles.Columns[1].Width = 500;
            dgvLogFiles.Columns[1].ReadOnly = true;
            dgvLogFiles.Columns[1].Visible = true;

            dgvLogFiles.Columns[2].HeaderText = "# rec";
            dgvLogFiles.Columns[2].Width = 70;
            dgvLogFiles.Columns[2].ReadOnly = true;
            dgvLogFiles.Columns[2].Visible = true;
            dgvLogFiles.Refresh();
        }



        private void LogDataList_refresh()
        {
            //refresh the log file list
            if (LogFiles.DispLogInfo_table.Count() > 0)
            {
                dgvLogData.DataSource = new List<LogFileClass.Disp_LogInfo_rec>();
                dgvLogData.Refresh();
                dgvLogData.DataSource = LogFiles.DispLogInfo_table;
            };

            dgvLogData.Columns[0].HeaderText = "Time";
            dgvLogData.Columns[0].Width = 300;
            dgvLogData.Columns[0].ReadOnly = true;
            dgvLogData.Columns[0].Visible = true;

            dgvLogData.Columns[1].HeaderText = "M1";
            dgvLogData.Columns[1].Width = 35;
            dgvLogData.Columns[1].ReadOnly = true;
            dgvLogData.Columns[1].Visible = true;

            dgvLogData.Columns[2].HeaderText = "M2";
            dgvLogData.Columns[2].Width = 35;
            dgvLogData.Columns[2].ReadOnly = true;
            dgvLogData.Columns[2].Visible = true;

            dgvLogData.Columns[3].HeaderText = "M3";
            dgvLogData.Columns[3].Width = 35;
            dgvLogData.Columns[3].ReadOnly = true;
            dgvLogData.Columns[3].Visible = true;

            dgvLogData.Columns[4].HeaderText = "M4";
            dgvLogData.Columns[4].Width = 35;
            dgvLogData.Columns[4].ReadOnly = true;
            dgvLogData.Columns[4].Visible = true;

            dgvLogData.Columns[5].HeaderText = "M5";
            dgvLogData.Columns[5].Width = 35;
            dgvLogData.Columns[5].ReadOnly = true;
            dgvLogData.Columns[5].Visible = true;

            dgvLogData.Columns[6].HeaderText = "M6";
            dgvLogData.Columns[6].Width = 35;
            dgvLogData.Columns[6].ReadOnly = true;
            dgvLogData.Columns[6].Visible = true;

            dgvLogData.Columns[7].HeaderText = "M7";
            dgvLogData.Columns[7].Width = 35;
            dgvLogData.Columns[7].ReadOnly = true;
            dgvLogData.Columns[7].Visible = true;

            dgvLogData.Columns[8].HeaderText = "M8";
            dgvLogData.Columns[8].Width = 35;
            dgvLogData.Columns[8].ReadOnly = true;
            dgvLogData.Columns[8].Visible = true;

            dgvLogData.Columns[9].HeaderText = "M9";
            dgvLogData.Columns[9].Width = 35;
            dgvLogData.Columns[9].ReadOnly = true;
            dgvLogData.Columns[9].Visible = true;
        }




        private void LogEventList_refresh()
        {
            //refresh the log file list
            if (LogFiles.Disp_LogEvents_table.Count() > 0)
            {
                dgvLogEvent.DataSource = new List<LogFileClass.Disp_LogEvents_rec>();
                dgvLogEvent.Refresh();
                dgvLogEvent.DataSource = LogFiles.Disp_LogEvents_table;
            };

            dgvLogEvent.Columns[0].HeaderText = "Time Start";
            dgvLogEvent.Columns[0].Width = 170;
            dgvLogEvent.Columns[0].ReadOnly = true;
            dgvLogEvent.Columns[0].Visible = true;

            dgvLogEvent.Columns[1].HeaderText = "Time Stop";
            dgvLogEvent.Columns[1].Width = 170;
            dgvLogEvent.Columns[1].ReadOnly = true;
            dgvLogEvent.Columns[1].Visible = true;

            dgvLogEvent.Columns[2].HeaderText = "Time Diff";
            dgvLogEvent.Columns[2].Width = 170;
            dgvLogEvent.Columns[2].ReadOnly = true;
            dgvLogEvent.Columns[2].Visible = true;

            dgvLogEvent.Columns[3].HeaderText = "M1";
            dgvLogEvent.Columns[3].Width = 35;
            dgvLogEvent.Columns[3].ReadOnly = true;
            dgvLogEvent.Columns[3].Visible = true;

            dgvLogEvent.Columns[4].HeaderText = "M2";
            dgvLogEvent.Columns[4].Width = 35;
            dgvLogEvent.Columns[4].ReadOnly = true;
            dgvLogEvent.Columns[4].Visible = true;

            dgvLogEvent.Columns[5].HeaderText = "M3";
            dgvLogEvent.Columns[5].Width = 35;
            dgvLogEvent.Columns[5].ReadOnly = true;
            dgvLogEvent.Columns[5].Visible = true;

            dgvLogEvent.Columns[6].HeaderText = "M4";
            dgvLogEvent.Columns[6].Width = 35;
            dgvLogEvent.Columns[6].ReadOnly = true;
            dgvLogEvent.Columns[6].Visible = true;

            dgvLogEvent.Columns[7].HeaderText = "M5";
            dgvLogEvent.Columns[7].Width = 35;
            dgvLogEvent.Columns[7].ReadOnly = true;
            dgvLogEvent.Columns[7].Visible = true;

            dgvLogEvent.Columns[8].HeaderText = "M6";
            dgvLogEvent.Columns[8].Width = 35;
            dgvLogEvent.Columns[8].ReadOnly = true;
            dgvLogEvent.Columns[8].Visible = true;

            dgvLogEvent.Columns[9].HeaderText = "M7";
            dgvLogEvent.Columns[9].Width = 35;
            dgvLogEvent.Columns[9].ReadOnly = true;
            dgvLogEvent.Columns[9].Visible = true;

            dgvLogEvent.Columns[10].HeaderText = "M8";
            dgvLogEvent.Columns[10].Width = 35;
            dgvLogEvent.Columns[10].ReadOnly = true;
            dgvLogEvent.Columns[10].Visible = true;

            dgvLogEvent.Columns[11].HeaderText = "M9";
            dgvLogEvent.Columns[11].Width = 35;
            dgvLogEvent.Columns[11].ReadOnly = true;
            dgvLogEvent.Columns[11].Visible = true;
        }



        private void LogMachEvents_refresh()
        {
            //refresh the log file list
            if (LogFiles.Disp_LogMachEvents_table.Count() > 0)
            {
                dgvLogByMach.DataSource = new List<LogFileClass.Disp_LogMachEvents_rec>();
                dgvLogByMach.Refresh();
                dgvLogByMach.DataSource = LogFiles.Disp_LogMachEvents_table;
            };

            dgvLogByMach.Columns[0].HeaderText = "Mach";
            dgvLogByMach.Columns[0].Width = 120;
            dgvLogByMach.Columns[0].ReadOnly = true;
            dgvLogByMach.Columns[0].Visible = true;

            dgvLogByMach.Columns[1].HeaderText = "Time Start";
            dgvLogByMach.Columns[1].Width = 170;
            dgvLogByMach.Columns[1].ReadOnly = true;
            dgvLogByMach.Columns[1].Visible = true;

            dgvLogByMach.Columns[2].HeaderText = "Time Stop";
            dgvLogByMach.Columns[2].Width = 170;
            dgvLogByMach.Columns[2].ReadOnly = true;
            dgvLogByMach.Columns[2].Visible = true;

            dgvLogByMach.Columns[3].HeaderText = "Time Diff";
            dgvLogByMach.Columns[3].Width = 100;
            dgvLogByMach.Columns[3].ReadOnly = true;
            dgvLogByMach.Columns[3].Visible = true;

            dgvLogByMach.Columns[4].HeaderText = "Time On";
            dgvLogByMach.Columns[4].Width = 100;
            dgvLogByMach.Columns[4].ReadOnly = true;
            dgvLogByMach.Columns[4].Visible = true;

            dgvLogByMach.Columns[5].HeaderText = "Time Off";
            dgvLogByMach.Columns[5].Width = 100;
            dgvLogByMach.Columns[5].ReadOnly = true;
            dgvLogByMach.Columns[5].Visible = true;
        }



        private void bttn_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void bttn_LogFile_Click(object sender, EventArgs e)
        {
            //first open up the file input box
            openFileDialog.ShowDialog();
            string LogInputFile = openFileDialog.FileName;
            LogFiles.NumLogFiles = LogFiles.NumLogFiles + 1;

            LogFiles.Disp_LogFile_add(LogFiles.NumLogFiles, LogInputFile, 0);
            LogFileList_refresh();
        }

        private void bttn_ReadLogs_Click(object sender, EventArgs e)
        {
            LogFiles.DispLogInfo_table.Clear();
            LogFiles.LogFile_In_table.Clear();

            for (int i = 0; i < LogFiles.NumLogFiles; i++)
            {
                //loop thru and read all the log files
                string currFile = LogFiles.Disp_LogFile_table[i].fileName;
                StreamReader sr = new StreamReader(currFile);

                //keep reading the entire file
                bool continF = true;
                string firstLine = sr.ReadLine();  //scrap the first line
                if (firstLine == null) continF = false;  
                while (continF)
                {
                    //loop for all the rows
                    //Disp_NestInput_TableRow_rec2 tempRec = new Disp_NestInput_TableRow_rec2();
                    string inFileStr = sr.ReadLine();
                    if (inFileStr == null)
                    {
                        //end of file
                        continF = false;
                    } else
                    {
                        LogFiles.LogFile_In_add(LogFiles.LogFile_In_table, inFileStr);
                    };
                };
               // Console.WriteLine("log file # " + i.ToString().Trim());
            };

            //all the lines are read in
            //now move to disp table but only list if there are changes
            LogFiles.Disp_LogInfo_load(LogFiles.LogFile_In_table, LogFiles.DispLogInfo_table, 
                LogFiles.LogEvents_table,
                LogFiles.Disp_LogEvents_table);
            LogDataList_refresh();
            LogEventList_refresh();
            LogMachEvents_refresh();
        }

        private void bttn_SaveReport_Click(object sender, EventArgs e)
        {
            //save the file
            saveReportFile.InitialDirectory = openFileDialog.InitialDirectory;
            saveReportFile.ShowDialog();
            string Report_fileName = saveReportFile.FileName;
            LogFiles.SaveReportFile(Report_fileName, LogFiles.LogFile_In_table, LogFiles.Disp_LogFile_table,
                LogFiles.Disp_LogMachEvents_table);
        }
    }
}
