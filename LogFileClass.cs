using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WCO_NetMon
{
    public class LogFileClass
    {
        public List<Disp_LogFiles_rec> Disp_LogFile_table;
        public List<LogFile_In_rec> LogFile_In_table;
        public List<Disp_LogInfo_rec> DispLogInfo_table;
        public List<LogEvents_rec> LogEvents_table;            //table of events
        public List<Disp_LogEvents_rec> Disp_LogEvents_table;  //for dgv display
        public List<Disp_LogMachEvents_rec> Disp_LogMachEvents_table;  //sorted by machine

        public int NumLogFiles;
        public int NumMachines = 9;  //fixed number of machines to read


        public class Disp_LogFiles_rec
        {
            //all incoming program files
            public string fileNum { get; set; }
            public string fileName { get; set; }
            public string numLines { get; set; }
        }


        public void Disp_LogFile_add(
            int _fileNum, string _fileName, int _numLines)
        {
            Disp_LogFiles_rec newRec = new Disp_LogFiles_rec();
            newRec.fileNum = RightStr(("000" + _fileNum.ToString().Trim()), 2).Trim();
            newRec.fileName = _fileName;
            newRec.numLines = _numLines.ToString().Trim();
            Disp_LogFile_table.Add(newRec);
        }


        public void Disp_LogFile_table_clear_all()
        {
            //clear the table
            Disp_LogFile_table.Clear();
        }



        public class LogEvents_rec          //elapsed time
        {
            public string timeStartStr { get; set; }
            public DateTime timeStart { get; set; }
            public string timeStopStr { get; set; }
            public DateTime timeStop { get; set; }
            public string timeDiffStr { get; set; }
            public DateTime timeDiff { get; set; }
            public string timeInStr { get; set; }
            public List<bool> machStat { get; set; }  //machine status
            public List<string> machStatStr { get; set; }
            public List<bool> machStatChanged { get; set; }  //machine status changed
            public List<string> machStatChangeStr { get; set; }
        }


        public class Disp_LogEvents_rec      //unique events by time
        {
            public string timeStartStr { get; set; }
            public string timeStopStr { get; set; }
            public string timeDiffStr { get; set; }
            public string mach_01 { get; set; }
            public string mach_02 { get; set; }
            public string mach_03 { get; set; }
            public string mach_04 { get; set; }
            public string mach_05 { get; set; }
            public string mach_06 { get; set; }
            public string mach_07 { get; set; }
            public string mach_08 { get; set; }
            public string mach_09 { get; set; }
        }


        public class LogMachEvents_rec     //log events sorted by machine
        {
            public string machNum { get; set; }
            public string timeStartStr { get; set; }
            public string timeStopStr { get; set; }
            public string timeDiffStr { get; set; }
        }


        public class Disp_LogMachEvents_rec     //log events sorted by machine
        {
            public string machNum { get; set; }
            public string timeStartStr { get; set; }
            public string timeStopStr { get; set; }
            public string timeDiffStr { get; set; }
            public string timeOnStr { get; set; }
            public string timeOffStr { get; set; }
        }



        public class LogFile_In_rec
        {
            public string stringIn { get; set; }
            public string timeInStr { get; set; }
            public List<bool> machStat { get; set; }  //machine status
        }


        public string ConvLogTimeToStr( string _LogTimeStr)
        {
            //converts the incoming log file's time string to standard time string that 
            //can then be used for time calculations

            string outString;
            outString = RightStr(_LogTimeStr, 4) + "-" + MidStr(_LogTimeStr, 9, 2) + "-" + MidStr(_LogTimeStr, 12, 2);
            outString = outString + " " + LeftStr(_LogTimeStr, 8);
            return outString;
        }


        public string CalcTimeDiffStr( string _startTime, string _stopTime)
        {
            string outString;

            int iYear, iMonth, iDay;
            int iHour, iMin, iSec;

            iYear = int.Parse(LeftStr(_startTime, 4));
            iMonth = int.Parse(MidStr(_startTime, 5, 2));
            iDay = int.Parse(MidStr(_startTime, 8, 2));

            iHour = int.Parse(MidStr(_startTime, 11, 2));
            iMin = int.Parse(MidStr(_startTime, 14, 2));
            iSec = int.Parse(MidStr(_startTime, 17, 2));

            DateTime startDT = new DateTime(iYear, iMonth, iDay, iHour, iMin, iSec);

            iYear = int.Parse(LeftStr(_stopTime, 4));
            iMonth = int.Parse(MidStr(_stopTime, 5, 2));
            iDay = int.Parse(MidStr(_stopTime, 8, 2));

            iHour = int.Parse(MidStr(_stopTime, 11, 2));
            iMin = int.Parse(MidStr(_stopTime, 14, 2));
            iSec = int.Parse(MidStr(_stopTime, 17, 2));

            DateTime stopDT = new DateTime(iYear, iMonth, iDay, iHour, iMin, iSec);

            TimeSpan diffDT = stopDT.Subtract(startDT);

            int chkDay = int.Parse(diffDT.ToString(@"%d").Trim());
            int chkHour = int.Parse(diffDT.ToString(@"hh").Trim());
            int totHour = chkDay * 24 + chkHour;
            string totHourStr = RightStr("000" + totHour.ToString().Trim(), 2);
            int totMin = int.Parse(diffDT.ToString(@"mm").Trim());
            string totMinStr = RightStr("000" + totMin.ToString().Trim(),2);
            int totSec = int.Parse(diffDT.ToString(@"ss").Trim());
            string totSecStr = RightStr("000" + totSec.ToString().Trim(), 2);
            outString = totHourStr + ":" + totMinStr + ":" + totSecStr;

            return outString;
        } 


        public TimeSpan AddToTime( TimeSpan _InTimeSpan,
            string _TimeInStr
            )
        {
            //adds to TimeSpan
            TimeSpan outVal;
            //int iDay = int.Parse(MidStr(_TimeInStr, 0, 2));
            int iHour = int.Parse(MidStr(_TimeInStr, 0, 2));
            int iMin = int.Parse(MidStr(_TimeInStr, 3, 2));
            int iSec = int.Parse(MidStr(_TimeInStr, 6, 2));
            TimeSpan TimeDuration = new TimeSpan(0, iHour, iMin, iSec);
            outVal = _InTimeSpan.Add(TimeDuration);
            return outVal;
        }


        public void LogFile_In_add(List<LogFile_In_rec> _LogFile_In_table, string _inString)
        {
            LogFile_In_rec newRec = new LogFile_In_rec();
            newRec.machStat = new List<bool>();
            newRec.stringIn = _inString;

            newRec.timeInStr = LeftStr(_inString, 19);

            string noTimeStr = RightStr(_inString, _inString.Length - 20);

            //Console.WriteLine("orig = " + _inString);
            //Console.WriteLine("strip= " + noTimeStr);
            for (int i=1; i<=NumMachines; i++)
            {
                string testStr = i.ToString().Trim();
                if ( noTimeStr.Contains(testStr) )
                {
                    newRec.machStat.Add(true);
                } else
                {
                    newRec.machStat.Add(false);
                };
            };

            _LogFile_In_table.Add(newRec);
        }

        
        public class Disp_LogInfo_rec
        {
            public string timeStr { get; set; }
            public string mach_01 { get; set; }
            public string mach_02 { get; set; }
            public string mach_03 { get; set; }
            public string mach_04 { get; set; }
            public string mach_05 { get; set; }
            public string mach_06 { get; set; }
            public string mach_07 { get; set; }
            public string mach_08 { get; set; }
            public string mach_09 { get; set; }
        }


        public void Disp_LogInfo_add(
            LogFile_In_rec _logFileRec,
            List<Disp_LogInfo_rec> _DispLogInfo_table
            )
        {
            //add record to display table
            Disp_LogInfo_rec newDispRec = new Disp_LogInfo_rec();
            newDispRec.timeStr = _logFileRec.timeInStr;
            for (int i=0; i<9; i++)
            {
                string outStr = "    ";
                if (_logFileRec.machStat[i]) outStr = "on";
                switch (i) {
                    case 0:
                        newDispRec.mach_01 = outStr;
                        break;
                    case 1:
                        newDispRec.mach_02 = outStr;
                        break;
                    case 2:
                        newDispRec.mach_03 = outStr;
                        break;
                    case 3:
                        newDispRec.mach_04 = outStr;
                        break;
                    case 4:
                        newDispRec.mach_05 = outStr;
                        break;
                    case 5:
                        newDispRec.mach_06 = outStr;
                        break;
                    case 6:
                        newDispRec.mach_07 = outStr;
                        break;
                    case 7:
                        newDispRec.mach_08 = outStr;
                        break;
                    case 8:
                        newDispRec.mach_09 = outStr;
                        break;
                };
            }
            _DispLogInfo_table.Add(newDispRec);
        }



        public void LogEvents_Check_add(
            List<LogEvents_rec> _LogEvents_table,
            LogFile_In_rec _RecToStore,
            LogFile_In_rec _PrevRec,
            bool _ForceAdd
            )
        {
            //check if there is a change, if so add an event to the LogEvents table
            LogEvents_rec newRec = new LogEvents_rec();
            newRec.timeStartStr = ConvLogTimeToStr( _PrevRec.timeInStr );
            newRec.timeStopStr = ConvLogTimeToStr( _RecToStore.timeInStr );
            newRec.timeDiffStr = CalcTimeDiffStr(newRec.timeStartStr, newRec.timeStopStr);

            newRec.machStat = new List<bool>();
            newRec.machStatStr = new List<string>();
            newRec.machStatChanged = new List<bool>();
            newRec.machStatChangeStr = new List<string>();
            bool isStatChanged = false;
            for (int i=0; i<NumMachines; i++)
            {
                newRec.machStat.Add(_RecToStore.machStat[i]);
                if (_RecToStore.machStat[i]) newRec.machStatStr.Add("on");
                else newRec.machStatStr.Add("off");

                if (_PrevRec.machStat[i] != _RecToStore.machStat[i])
                {
                    //there is a difference
                    isStatChanged = true;
                    newRec.machStat[i] = _RecToStore.machStat[i];
                    newRec.machStatChanged.Add(true);
                    if (_RecToStore.machStat[i])  newRec.machStatChangeStr.Add("on");
                    else newRec.machStatChangeStr.Add("off");
                } else
                {
                    //no change on this machine, but store in case there is another change
                    newRec.machStat[i] = _RecToStore.machStat[i];
                    newRec.machStatChanged.Add(false);
                    newRec.machStatChangeStr.Add(" ");  //nothing changed so just store blank string
                };
            }
            //after going thru all the machines, if something changed save the event
            if (isStatChanged || _ForceAdd)
            {
                _LogEvents_table.Add(newRec);
                //if record changed, reset the Prev Record
                _PrevRec.stringIn = _RecToStore.stringIn;
                _PrevRec.timeInStr = _RecToStore.timeInStr;
                for (int j=0; j<NumMachines; j++)
                {
                    _PrevRec.machStat[j] = _RecToStore.machStat[j];
                };
            };
        }

        public void Disp_LogEvents_add(
            List<Disp_LogEvents_rec> _Disp_LogEvents_table,
            List<LogEvents_rec> _LogEvents_table
            )
        {
            //add an event to the table
            for (int i=0; i<_LogEvents_table.Count(); i++)
            {
                Disp_LogEvents_rec newRec = new Disp_LogEvents_rec();
                newRec.timeStartStr = _LogEvents_table[i].timeStartStr;
                newRec.timeStopStr = _LogEvents_table[i].timeStopStr;
                newRec.timeDiffStr = _LogEvents_table[i].timeDiffStr;
                newRec.mach_01 = _LogEvents_table[i].machStatChangeStr[0];
                newRec.mach_02 = _LogEvents_table[i].machStatChangeStr[1];
                newRec.mach_03 = _LogEvents_table[i].machStatChangeStr[2];
                newRec.mach_04 = _LogEvents_table[i].machStatChangeStr[3];
                newRec.mach_05 = _LogEvents_table[i].machStatChangeStr[4];
                newRec.mach_06 = _LogEvents_table[i].machStatChangeStr[5];
                newRec.mach_07 = _LogEvents_table[i].machStatChangeStr[6];
                newRec.mach_08 = _LogEvents_table[i].machStatChangeStr[7];
                newRec.mach_09 = _LogEvents_table[i].machStatChangeStr[8];
                _Disp_LogEvents_table.Add(newRec);
            };
        }


        public void Disp_LogInfo_load(
            List<LogFile_In_rec> _LogFile_In_table,
            List<Disp_LogInfo_rec> _DispLogInfo_table,
            List<LogEvents_rec> _LogEvents_table,
            List<Disp_LogEvents_rec> _Disp_LogEvents_table
            )
        {
            //load all of the data into disp table
            //this routine is for all the Log data even if there were no changes
            //_DispLogInfo_table = new List<Disp_LogInfo_rec>();

            _DispLogInfo_table.Clear();

            //store the first record automatically
            if (_LogFile_In_table.Count() > 0)
            {
                //used to store prev log, now it does not matter
            };
            if (_LogFile_In_table.Count() > 1) //more than one record
            {
                //there is more than one record, so loop thru all
                for (int i = 0; i < _LogFile_In_table.Count(); i++)
                {
                    //first step is to load all of the log data as it came in
                    Disp_LogInfo_add(_LogFile_In_table[i], _DispLogInfo_table);
                };
            };
            Console.WriteLine("End of log info");

            //load the log Events
            //make as a separate function later on
            LogFile_In_rec prevLogRec = new LogFile_In_rec();
            LogFile_In_rec newLogRec = new LogFile_In_rec();
            if (_LogFile_In_table.Count() > 0)
            {
                prevLogRec.timeInStr =  _LogFile_In_table[0].timeInStr;
                prevLogRec.machStat = new List<bool>();
                for( int j=0; j<NumMachines; j++)
                {
                    prevLogRec.machStat.Add(_LogFile_In_table[0].machStat[j]);
                };

                //add a record to the events display table with the first record
            };

            if (_LogFile_In_table.Count() > 1) //more than one record
            {
                //there is more than one record, so loop thru all
                for (int i = 0; i < _LogFile_In_table.Count(); i++)
                {
                    newLogRec.timeInStr = "";
                    newLogRec.machStat = new List<bool>();

                    bool forceAdd = false;
                    if (i == 0) forceAdd = true;
                    LogEvents_Check_add(_LogEvents_table, _LogFile_In_table[i], prevLogRec, forceAdd);
                };
                //for the storage of the last record
                LogEvents_Check_add( _LogEvents_table, _LogFile_In_table[_LogFile_In_table.Count()-1], prevLogRec, true);
            };
            Console.WriteLine("End of Log Events");

            //now load LogEvents to the Display Log Events
            Disp_LogEvents_add(_Disp_LogEvents_table, LogEvents_table);
            Console.WriteLine("all display log events are created");


            //sort by machine
            for (int machNum=0; machNum<NumMachines; machNum++)
            {
                //reset running sum
                TimeSpan totOnSpan = new TimeSpan(0, 0, 0, 0);
                TimeSpan totOffSpan = new TimeSpan(0, 0, 0, 0);
                TimeSpan totTimeSpan = new TimeSpan(0, 0, 0, 0);

                //load the first data
                Disp_LogMachEvents_rec newRec = new Disp_LogMachEvents_rec();  //new record
                string machNumStr = "M" + RightStr(("000" + (machNum+1).ToString().Trim()), 2);
                newRec.timeStartStr = ConvLogTimeToStr( _LogFile_In_table[0].timeInStr );
                
                bool oldStat = _LogFile_In_table[0].machStat[machNum];
                if (oldStat) newRec.machNum = machNumStr + " on";
                else newRec.machNum = machNumStr + " off";

                for (int i=1; i<_LogFile_In_table.Count()-1; i++)
                {
                    if ( _LogFile_In_table[i].machStat[machNum] != oldStat )
                    {
                        //status has changed
                        newRec.timeStopStr = ConvLogTimeToStr( _LogFile_In_table[i].timeInStr );
                        newRec.timeDiffStr = CalcTimeDiffStr(newRec.timeStartStr, newRec.timeStopStr);
                        if (newRec.machNum.Contains("on"))
                        {
                            newRec.timeOnStr = newRec.timeDiffStr;
                            newRec.timeOffStr = "";
                            totOnSpan = AddToTime(totOnSpan, newRec.timeOnStr);
                            totTimeSpan = AddToTime(totTimeSpan, newRec.timeOnStr);
                        } else
                        {
                            newRec.timeOnStr = "";
                            newRec.timeOffStr = newRec.timeDiffStr;
                            totOffSpan = AddToTime(totOffSpan, newRec.timeOffStr);
                            totTimeSpan = AddToTime(totTimeSpan, newRec.timeOffStr);
                        };                      
                        Disp_LogMachEvents_table.Add(newRec);
                        oldStat = _LogFile_In_table[i].machStat[machNum];

                        //now prepare for the next record
                        newRec = new Disp_LogMachEvents_rec();
                        newRec.timeStartStr = ConvLogTimeToStr( _LogFile_In_table[i].timeInStr );
                        if (oldStat) newRec.machNum = machNumStr + " on";
                        else newRec.machNum = machNumStr + " off";
                    };
                };
                //loop ended so close out the record
                newRec.timeStopStr = ConvLogTimeToStr( _LogFile_In_table[_LogFile_In_table.Count() - 1].timeInStr );
                newRec.timeDiffStr = CalcTimeDiffStr(newRec.timeStartStr, newRec.timeStopStr);
                if (newRec.machNum.Contains("on"))
                {
                    newRec.timeOnStr = newRec.timeDiffStr;
                    newRec.timeOffStr = "";
                    totOnSpan = AddToTime(totOnSpan, newRec.timeOnStr);
                    totTimeSpan = AddToTime(totTimeSpan, newRec.timeOnStr);
                }
                else
                {
                    newRec.timeOnStr = "";
                    newRec.timeOffStr = newRec.timeDiffStr;
                    totOffSpan = AddToTime(totOffSpan, newRec.timeOffStr);
                    totTimeSpan = AddToTime(totTimeSpan, newRec.timeOffStr);
                };
                Disp_LogMachEvents_table.Add(newRec);

                newRec = new Disp_LogMachEvents_rec();
                newRec.machNum = "------------";
                newRec.timeStartStr = "";
                newRec.timeStopStr = "";
                newRec.timeDiffStr = "";
                newRec.timeOnStr = "----------";
                newRec.timeOffStr = "----------";
                Disp_LogMachEvents_table.Add(newRec);

                newRec = new Disp_LogMachEvents_rec();
                newRec.machNum = "total times";
                newRec.timeStartStr = "";
                newRec.timeStopStr = "";
                //newRec.timeDiffStr = "";
                if (totTimeSpan.TotalHours == 0) newRec.timeDiffStr = "--";
                else newRec.timeDiffStr = totTimeSpan.TotalHours.ToString("####.##") + " total";
                if (totOnSpan.TotalHours == 0) newRec.timeOnStr = "--"; 
                else newRec.timeOnStr = totOnSpan.TotalHours.ToString("####.##") + " hrs";
                if (totOffSpan.TotalHours == 0) newRec.timeOffStr = "--";
                else newRec.timeOffStr = totOffSpan.TotalHours.ToString("####.##") + " hrs";
                /*
                newRec.timeOnStr = (totOnSpan.Days*24+totOnSpan.Hours).ToString().Trim() + ":" + 
                    RightStr("000" + totOnSpan.Minutes.ToString().Trim(),2);
                newRec.timeOffStr = (totOffSpan.Days * 24 + totOffSpan.Hours).ToString().Trim() + ":" +
                    RightStr("000" + totOffSpan.Minutes.ToString().Trim(), 2);
                */
                Disp_LogMachEvents_table.Add(newRec);

                newRec = new Disp_LogMachEvents_rec();
                newRec.machNum = "percentages";
                newRec.timeStartStr = "";
                newRec.timeStopStr = "";
                newRec.timeDiffStr = "";
                double OnPercent = (totOnSpan.TotalHours / totTimeSpan.TotalHours) * 100.00;
                if (OnPercent == 0) newRec.timeOnStr = "";
                else newRec.timeOnStr = OnPercent.ToString("###.##") + "%";

                double OffPercent = (totOffSpan.TotalHours / totTimeSpan.TotalHours) * 100.00;
                if (OffPercent == 0) newRec.timeOffStr = "";
                else newRec.timeOffStr = OffPercent.ToString("###.##") + "%";
                Disp_LogMachEvents_table.Add(newRec);

                newRec = new Disp_LogMachEvents_rec();
                newRec.machNum = "------------";
                newRec.timeStartStr = "";
                newRec.timeStopStr = "";
                newRec.timeDiffStr = "";
                newRec.timeOnStr = "----------";
                newRec.timeOffStr = "----------";
                Disp_LogMachEvents_table.Add(newRec);

                newRec = new Disp_LogMachEvents_rec();
                newRec.machNum = "";
                newRec.timeStartStr = "";
                newRec.timeStopStr = "";
                newRec.timeDiffStr = "";
                newRec.timeOnStr = "";
                newRec.timeOffStr = "";
                Disp_LogMachEvents_table.Add(newRec);
            };
        }


        public string StringFixedLength(string _strIn, int _finalLen, bool _leftJust, char _padChar)
        {
            //pads a string with spaces to a fixed width
            //can pad from the left or the right
            //use for reports or file output

            string outVal;
            string PadStr = new string(_padChar, _finalLen + 1);

            if (_leftJust) outVal = LeftStr(_strIn + PadStr, _finalLen);
            else outVal = RightStr(PadStr + _strIn, _finalLen);

            return outVal;
        }


        public void SaveReportFile( string _ReportFileName,
            List<LogFile_In_rec> _LogFile_In_table,
            List<Disp_LogFiles_rec> _Disp_LogFile_table,
            List<Disp_LogMachEvents_rec> _Disp_LogMachEvents_table
            )
        {
            //saves the report file name
            //first get the time frame
            string ReportTimeStart;
            string ReportTimeStop;

            ReportTimeStart = ConvLogTimeToStr( _LogFile_In_table[0].timeInStr );
            int LastLogRec = _LogFile_In_table.Count() - 1;
            ReportTimeStop = ConvLogTimeToStr(_LogFile_In_table[LastLogRec].timeInStr);

            StreamWriter sw = new StreamWriter(_ReportFileName);
            sw.WriteLine("");
            sw.WriteLine("               Network Monitoring Report - by machine");
            sw.WriteLine("");
            sw.WriteLine("Report Generated on : " + DateTime.Now.ToString("MM/dd/yyyy  hh:mm:ss") );
            sw.WriteLine("");
            sw.WriteLine("Time span in report : " + ReportTimeStart + " to " + ReportTimeStop);
            sw.WriteLine("Log Files Read in   : ");

            for (int i=0; i<_Disp_LogFile_table.Count(); i++)
            {
                string FileNum = StringFixedLength((i + 1).ToString().Trim(), 3, false, '0');
                sw.WriteLine("     " + FileNum + "=" + _Disp_LogFile_table[i].fileName);
            };
            sw.WriteLine("");
            sw.WriteLine("");

            //setup columns widths for headers and data
            List<int> ColWid = new List<int>();
            ColWid.Add( 15 );  //mach num
            ColWid.Add( 20 );  //start time
            ColWid.Add( 20 );  //stop time
            ColWid.Add( 15 );  //time diff
            ColWid.Add( 15 );  //on time
            ColWid.Add( 15 );  //off time

            string ColHead00 = StringFixedLength("Machine", ColWid[0], true, ' ');
            string ColHead01 = StringFixedLength("Start Time", ColWid[1], true, ' ');
            string ColHead02 = StringFixedLength("Stop Time", ColWid[2], true, ' ');
            string ColHead03 = StringFixedLength("Duration", ColWid[3], true, ' ');
            string ColHead04 = StringFixedLength("On Time", ColWid[4], true, ' ');
            string ColHead05 = StringFixedLength("Off Time", ColWid[5], true, ' ');
            string HeaderStr = ColHead00 + " " + ColHead01 + " " + ColHead02 + " | " + ColHead03 + " | ";
            HeaderStr = HeaderStr + ColHead04 + " " + ColHead05;
            sw.WriteLine(HeaderStr);

            ColHead00 = StringFixedLength("_", ColWid[0], true, '_');
            ColHead01 = StringFixedLength("_", ColWid[1], true, '_');
            ColHead02 = StringFixedLength("_", ColWid[2], true, '_');
            ColHead03 = StringFixedLength("_", ColWid[3], true, '_');
            ColHead04 = StringFixedLength("_", ColWid[4], true, '_');
            ColHead05 = StringFixedLength("_", ColWid[5], true, '_');
            HeaderStr = ColHead00 + " " + ColHead01 + " " + ColHead02 + " | " + ColHead03 + " | ";
            HeaderStr = HeaderStr + ColHead04 + " " + ColHead05;
            sw.WriteLine(HeaderStr);

            //now loop thru all of the machine data
            string LastMachNum="";
            for (int i=0; i< _Disp_LogMachEvents_table.Count(); i++)
            {
                Disp_LogMachEvents_rec currRec = _Disp_LogMachEvents_table[i];
                if ( currRec.machNum.Contains("M")) LastMachNum = LeftStr(currRec.machNum, 3);
                string Col00 = StringFixedLength(currRec.machNum, ColWid[0], true, ' ');
                string Col01 = StringFixedLength(currRec.timeStartStr, ColWid[1], true, ' ');
                string Col02 = StringFixedLength(currRec.timeStopStr, ColWid[2], true, ' ');
                string Col03 = StringFixedLength(currRec.timeDiffStr, ColWid[3], true, ' ');
                string Col04 = StringFixedLength(currRec.timeOnStr, ColWid[4], true, ' ');
                string tempStr = "";
                if (currRec.machNum.Contains("total")) tempStr = " " + LastMachNum;
                string Col05 = StringFixedLength(currRec.timeOffStr+tempStr, ColWid[5], true, ' ');
                string RecStr = Col00 + " " + Col01 + " " + Col02 + " | " + Col03 + " | ";
                RecStr = RecStr + Col04 + " " + Col05;
                sw.WriteLine(RecStr);
            };

            sw.WriteLine("");
            sw.Flush();
            sw.Close();
        }

        public string RightStr(string _strIn, int _length)
        {
            int iStart = _strIn.Length - _length;
            //string result = _strIn.Substring( iStart, _length);
            return _strIn.Substring(iStart, _length);
        }


        public string LeftStr(string _strIn, int _length)
        {
            int iStart = 0;
            //string result = _strIn.Substring( iStart, _length);
            return _strIn.Substring(iStart, _length);
        }


        public string MidStr(string _strIn, int _startPos, int _endPos)
        {
            int lenToGet = _endPos - _startPos;
            return _strIn.Substring(_startPos, _endPos);
        }


        public void InitValues()
        {
            Disp_LogFile_table = new List<Disp_LogFiles_rec>();
            Disp_LogFile_table_clear_all();

            DispLogInfo_table = new List<Disp_LogInfo_rec>();
            DispLogInfo_table.Clear();

            LogFile_In_table = new List<LogFile_In_rec>();
            LogFile_In_table.Clear();

            LogEvents_table = new List<LogEvents_rec>();
            LogEvents_table.Clear();

            Disp_LogEvents_table = new List<Disp_LogEvents_rec>();
            Disp_LogEvents_table.Clear();

            Disp_LogMachEvents_table = new List<Disp_LogMachEvents_rec>();
            Disp_LogMachEvents_table.Clear();

            NumLogFiles = 0;
        }

    }
}
