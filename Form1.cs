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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace WCO_NetMon
{

    public partial class MainForm : Form
    {
        public LogFileClass LogFiles;
        static HttpClient client = new HttpClient();
        static HttpClient client2 = new HttpClient();
        static HttpClient client3 = new HttpClient();  //for eventByMach
        static Boolean isSendingLogFile = false;
        static Boolean isSendingEventByTime = false;
        static Boolean isSendingEventByMach = false;


        public class sqlLogFileRec
        {
            public string fileName { get; set; }
        }


        public class sqlEventByTimeRec
        {
            public string startTimeStr { get; set; }
            public string endTimeStr { get; set; }
            public string eventDuration { get; set; }
            public int ontim_utc_yr { get; set; }
            public int ontim_utc_mon { get; set; }
            public int ontim_utc_day { get; set; }
            public int ontim_utc_hr { get; set; }
            public int ontim_utc_min { get; set; }
            public int ontim_utc_sec { get; set; }

            //off time
            public int offtim_utc_yr { get; set; }
            public int offtim_utc_mon { get; set; }
            public int offtim_utc_day { get; set; }
            public int offtim_utc_hr { get; set; }
            public int offtim_utc_min { get; set; }
            public int offtim_utc_sec { get; set; }

            //duration time
            public int durtim_utc_yr { get; set; }
            public int durtim_utc_mon { get; set; }
            public int durtim_utc_day { get; set; }
            public int durtim_utc_hr { get; set; }
            public int durtim_utc_min { get; set; }
            public int durtim_utc_sec { get; set; }

            //m1 thru m9
            public string m1 { get; set; }
            public string m2 { get; set; }
            public string m3 { get; set; }
            public string m4 { get; set; }
            public string m5 { get; set; }
            public string m6 { get; set; }
            public string m7 { get; set; }
            public string m8 { get; set; }
            public string m9 { get; set; }
        }


        public class sqlEventByMachRec
        {
            public string machNumStr { get; set; }
            public string machNum { get; set; }
            public string eventStr { get; set; }
            public string startTimeStr { get; set; }
            public string endTimeStr { get; set; }
            public int starttime_utc_yr { get; set; }
            public int starttime_utc_mon { get; set; }
            public int starttime_utc_day { get; set; }
            public int starttime_utc_hr { get; set; }
            public int starttime_utc_min { get; set; }
            public int starttime_utc_sec { get; set; }

            //off time
            public int endtime_utc_yr { get; set; }
            public int endtime_utc_mon { get; set; }
            public int endtime_utc_day { get; set; }
            public int endtime_utc_hr { get; set; }
            public int endtime_utc_min { get; set; }
            public int endtime_utc_sec { get; set; }
        }


        public MainForm()
        {
            InitializeComponent();
            LogFiles = new LogFileClass();
            LogFiles.InitValues();

            //set up the initial table
            dgvLogFiles.DataSource = new List<LogFileClass.Disp_LogFiles_rec>();
            LogFileList_refresh();
        }


        static async Task<Boolean> CreateLogFileRec( sqlLogFileRec _logFileRec )
        {
            HttpResponseMessage response = await client.PostAsJsonAsync<sqlLogFileRec>(
                "api/logfile2", _logFileRec );
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
            //return response.Headers.Location;
        }


        static async Task RunAsyncCreateLogFile(sqlLogFileRec _logFileRec)
        {
            //client had to be setup prior to entering here
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync<sqlLogFileRec>(
                    "api/logfile", _logFileRec);
                response.EnsureSuccessStatusCode();
                var isCreateSuccessful = response.IsSuccessStatusCode;

                //var isCreateSuccessful = await CreateLogFileRec( logFileRec );
                //Console.WriteLine($"Write was successful {isCreateSuccessful}");
               isSendingLogFile = false;
                //Console.WriteLine($"Created at {url}");
            }
            catch (Exception e)
            {
                Console.WriteLine("---an error occurred");
                Console.WriteLine(e.Message);
            }
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
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != System.Windows.Forms.DialogResult.Cancel)
            {
                //did not hit the cancel button
                int numFiles = openFileDialog.FileNames.Count();
                Console.WriteLine(numFiles);

                for (int i = 0; i < numFiles; i++)
                {
                    //loop thru all of the file names
                    string LogInputFile = openFileDialog.FileNames[i];
                    LogFiles.NumLogFiles = LogFiles.NumLogFiles + 1;

                    LogFiles.Disp_LogFile_add(LogFiles.NumLogFiles, LogInputFile, 0);
                };
            };
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


        public void UploadLogFileName(string _fileName)
        {
            //upload the file to the AWS / mySQL database
            while (isSendingLogFile)
            {
                //keep looping until the file is sent
                Application.DoEvents();
            };
            // Create a new record
            sqlLogFileRec logFileRec = new sqlLogFileRec
            {
                fileName = _fileName
            };
            //RunAsync().GetAwaiter().GetResult();
            isSendingLogFile = true;
            RunAsyncCreateLogFile(logFileRec).GetAwaiter();
            while (isSendingLogFile)
            {
                //keep looping until the file is sent
                Application.DoEvents();
            };
        }


        public void UploadAllLogFileNames()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://devnetlogger.herokuapp.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //refresh the log file list
            if (LogFiles.Disp_LogFile_table.Count() > 0)
            {
                for (int i=0; i<LogFiles.Disp_LogFile_table.Count(); i++)
                {
                    Console.WriteLine($"Sending file # {i} : {LogFiles.Disp_LogFile_table[i].fileName}");
                    UploadLogFileName(LogFiles.Disp_LogFile_table[i].fileName);
                };
            };
        }

        private void bttnSendToWeb_Click(object sender, EventArgs e)
        {
            //upload to mySQL using backend API
            UploadAllLogFileNames();
        }




        //for the event by time
        static async Task RunAsyncCreateEventByTime(sqlEventByTimeRec _eventByTimeRec)
        {
            //client had to be setup prior to entering here
            try
            {
                HttpResponseMessage response = await client2.PostAsJsonAsync<sqlEventByTimeRec>(
                    "api/eventbytime", _eventByTimeRec);
                response.EnsureSuccessStatusCode();
                var isCreateSuccessful = response.IsSuccessStatusCode;

                isSendingEventByTime = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("---an error occurred");
                Console.WriteLine(e.Message);
            }
        }


        public void UploadEventByTime(sqlEventByTimeRec _eventByTimeRec)
        {
            //upload the event by time record to the AWS / mySQL database
            while (isSendingEventByTime)
            {
                //keep looping until the file is sent
                Application.DoEvents();
            };
            isSendingEventByTime = true;
            RunAsyncCreateEventByTime(_eventByTimeRec).GetAwaiter();
            while (isSendingEventByTime)
            {
                //keep looping until the file is sent
                Application.DoEvents();
            };
        }


        public void UploadAllEventsByTime()
        {
            // Update port # in the following line.
            client2.BaseAddress = new Uri("https://devnetlogger.herokuapp.com/");
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //refresh the log file list
            if (LogFiles.Disp_LogEvents_table.Count() > 0)
            {
                for (int i = 0; i < LogFiles.Disp_LogEvents_table.Count(); i++)
                {
                    sqlEventByTimeRec eventByTimeRec = new sqlEventByTimeRec();
                    eventByTimeRec.startTimeStr = LogFiles.Disp_LogEvents_table[i].timeStartStr;
                    eventByTimeRec.endTimeStr = LogFiles.Disp_LogEvents_table[i].timeStopStr;
                    eventByTimeRec.eventDuration = LogFiles.Disp_LogEvents_table[i].timeDiffStr;

                    string tempTimeString = eventByTimeRec.startTimeStr;
                    string tempString = tempTimeString.Substring(0, 4);
                    eventByTimeRec.ontim_utc_yr = int.Parse(tempString);
                    tempString = tempTimeString.Substring(5, 2);
                    eventByTimeRec.ontim_utc_mon = int.Parse(tempString);
                    tempString = tempTimeString.Substring(8, 2);
                    eventByTimeRec.ontim_utc_day = int.Parse(tempString);

                    tempString = tempTimeString.Substring(11, 2);
                    eventByTimeRec.ontim_utc_hr = int.Parse(tempString);
                    tempString = tempTimeString.Substring(14, 2);
                    eventByTimeRec.ontim_utc_min = int.Parse(tempString);
                    tempString = tempTimeString.Substring(17, 2);
                    eventByTimeRec.ontim_utc_sec = int.Parse(tempString);


                    //stop time
                    tempTimeString = eventByTimeRec.endTimeStr;
                    tempString = tempTimeString.Substring(0, 4);
                    eventByTimeRec.offtim_utc_yr = int.Parse(tempString);
                    tempString = tempTimeString.Substring(5, 2);
                    eventByTimeRec.offtim_utc_mon = int.Parse(tempString);
                    tempString = tempTimeString.Substring(8, 2);
                    eventByTimeRec.offtim_utc_day = int.Parse(tempString);

                    tempString = tempTimeString.Substring(11, 2);
                    eventByTimeRec.offtim_utc_hr = int.Parse(tempString);
                    tempString = tempTimeString.Substring(14, 2);
                    eventByTimeRec.offtim_utc_min = int.Parse(tempString);
                    tempString = tempTimeString.Substring(17, 2);
                    eventByTimeRec.offtim_utc_sec = int.Parse(tempString);


                    //duration time
                    tempTimeString = eventByTimeRec.eventDuration;
                    eventByTimeRec.durtim_utc_yr  = int.Parse("0");
                    eventByTimeRec.durtim_utc_mon = int.Parse("0");
                    eventByTimeRec.durtim_utc_day = int.Parse("0");

                    tempString = tempTimeString.Substring(0, 2);
                    eventByTimeRec.durtim_utc_hr = int.Parse(tempString);
                    tempString = tempTimeString.Substring(3, 2);
                    eventByTimeRec.durtim_utc_min = int.Parse(tempString);
                    tempString = tempTimeString.Substring(6, 2);
                    eventByTimeRec.durtim_utc_sec = int.Parse(tempString);

                    eventByTimeRec.m1 = LogFiles.Disp_LogEvents_table[i].mach_01;
                    eventByTimeRec.m2 = LogFiles.Disp_LogEvents_table[i].mach_02;
                    eventByTimeRec.m3 = LogFiles.Disp_LogEvents_table[i].mach_03;
                    eventByTimeRec.m4 = LogFiles.Disp_LogEvents_table[i].mach_04;
                    eventByTimeRec.m5 = LogFiles.Disp_LogEvents_table[i].mach_05;
                    eventByTimeRec.m6 = LogFiles.Disp_LogEvents_table[i].mach_06;
                    eventByTimeRec.m7 = LogFiles.Disp_LogEvents_table[i].mach_07;
                    eventByTimeRec.m8 = LogFiles.Disp_LogEvents_table[i].mach_08;
                    eventByTimeRec.m9 = LogFiles.Disp_LogEvents_table[i].mach_09;

                    Console.WriteLine($"Sending # {i} : {LogFiles.Disp_LogEvents_table[i].timeStartStr}");
                    UploadEventByTime(eventByTimeRec);
                };
            };
        }




        //for the event by machine
        static async Task RunAsyncCreateEventByMach(sqlEventByMachRec _eventByMachRec)
        {
            //client had to be setup prior to entering here
            try
            {
                HttpResponseMessage response = await client3.PostAsJsonAsync<sqlEventByMachRec>(
                    "api/eventbymach", _eventByMachRec);
                response.EnsureSuccessStatusCode();
                var isCreateSuccessful = response.IsSuccessStatusCode;

                isSendingEventByMach = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("---an error occurred");
                Console.WriteLine(e.Message);
            }
        }


        public void UploadEventByMach(sqlEventByMachRec _eventByMachRec)
        {
            //upload the event by mach record to the AWS / mySQL database
            while (isSendingEventByMach)
            {
                //keep looping until the file is sent
                Application.DoEvents();
            };
            isSendingEventByMach = true;
            RunAsyncCreateEventByMach(_eventByMachRec).GetAwaiter();
            while (isSendingEventByMach)
            {
                //keep looping until the file is sent
                Application.DoEvents();
            };
        }

        public void UploadAllEventsByMach()
        {
            // Update port # in the following line.
            client3.BaseAddress = new Uri("https://devnetlogger.herokuapp.com/");
            client3.DefaultRequestHeaders.Accept.Clear();
            client3.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //refresh the events by mach
            if (LogFiles.Disp_LogMachEvents_table.Count() > 0)
            {
                for (int i = 0; i < LogFiles.Disp_LogMachEvents_table.Count(); i++)
                {
                    sqlEventByMachRec eventByMachRec = new sqlEventByMachRec();
                    //check to see if the record should be added
                    if((LogFiles.Disp_LogMachEvents_table[i].machNum =="") || (LogFiles.LeftStr(LogFiles.Disp_LogMachEvents_table[i].machNum,1)=="-") || (LogFiles.LeftStr(LogFiles.Disp_LogMachEvents_table[i].machNum, 1) != "M"))
                    {
                        //do nothing
                    } else
                    {
                        eventByMachRec.machNumStr = LogFiles.LeftStr(LogFiles.Disp_LogMachEvents_table[i].machNum, 3);
                        eventByMachRec.machNum = LogFiles.RightStr(eventByMachRec.machNumStr, 2);
                        eventByMachRec.eventStr = LogFiles.Disp_LogMachEvents_table[i].machNum;
                        eventByMachRec.startTimeStr = LogFiles.Disp_LogMachEvents_table[i].timeStartStr;
                        eventByMachRec.endTimeStr = LogFiles.Disp_LogMachEvents_table[i].timeStopStr;

                        string tempTimeString = eventByMachRec.startTimeStr;
                        string tempString = tempTimeString.Substring(0, 4);
                        eventByMachRec.starttime_utc_yr = int.Parse(tempString);
                        tempString = tempTimeString.Substring(5, 2);
                        eventByMachRec.starttime_utc_mon = int.Parse(tempString);
                        tempString = tempTimeString.Substring(8, 2);
                        eventByMachRec.starttime_utc_day = int.Parse(tempString);

                        tempString = tempTimeString.Substring(11, 2);
                        eventByMachRec.starttime_utc_hr = int.Parse(tempString);
                        tempString = tempTimeString.Substring(14, 2);
                        eventByMachRec.starttime_utc_min = int.Parse(tempString);
                        tempString = tempTimeString.Substring(17, 2);
                        eventByMachRec.starttime_utc_sec = int.Parse(tempString);


                        //end time
                        tempTimeString = eventByMachRec.endTimeStr;
                        tempString = tempTimeString.Substring(0, 4);
                        eventByMachRec.endtime_utc_yr = int.Parse(tempString);
                        tempString = tempTimeString.Substring(5, 2);
                        eventByMachRec.endtime_utc_mon = int.Parse(tempString);
                        tempString = tempTimeString.Substring(8, 2);
                        eventByMachRec.endtime_utc_day = int.Parse(tempString);

                        tempString = tempTimeString.Substring(11, 2);
                        eventByMachRec.endtime_utc_hr = int.Parse(tempString);
                        tempString = tempTimeString.Substring(14, 2);
                        eventByMachRec.endtime_utc_min = int.Parse(tempString);
                        tempString = tempTimeString.Substring(17, 2);
                        eventByMachRec.endtime_utc_sec = int.Parse(tempString);

                        Console.WriteLine($"Sending # {i} : {LogFiles.Disp_LogMachEvents_table[i].timeStartStr}");
                        UploadEventByMach(eventByMachRec);
                    };
                };
            };
        }


        private void bttnSendTimeToWeb_Click(object sender, EventArgs e)
        {
            UploadAllEventsByTime();
        }

        private void bttnSendMachEvtToWeb_click(object sender, EventArgs e)
        {
            UploadAllEventsByMach();
        }
    }
}

