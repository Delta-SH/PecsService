using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.ServiceProcess;
using Microsoft.Win32;
using Delta.PECS.WebService.BLL;
using Delta.PECS.WebService.Model;

namespace Delta.PECS.WebService.DataService {
    partial class DataService : ServiceBase {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private EnmRunState runState = EnmRunState.Stop;
        private DateTime StartupDateTime;
        private Guid UniqueID;
        private Int64 SyncModifyInterval;
        private Int64 SyncTimeInterval;
        private Int64 SyncMachineCodeInterval;
        private Int64 SyncLscParamInterval;
        private Int64 MaxRepeatCount;
        private Thread workerThread;
        private static List<Thread> workerThreads;
        private static List<ClientObjectInfo> workerClients;
        private static List<LscInfo> totalLscs;
        private static List<AlarmInfo> totalAlarms;
        private static List<TrendAlarmInfo> totalTrendAlarms;
        private static List<LoadAlarmInfo> totalLoadAlarms;
        private static List<FrequencyAlarmInfo> totalFrequencyAlarms;
        private static Dictionary<String, DevInfo> totalDevices;
        private static Queue<PackageInfo> settingQueue;
        private static Queue<PackageInfo> alarmQueue;
        private static Queue<PackageInfo> trendQueue;
        private static Queue<PackageInfo> loadQueue;
        private static Queue<PackageInfo> frequencyQueue;
        private static Queue<PackageInfo> nodeQueue;
        private static Queue<LogInfo> logQueue;
        private EventWaitHandle allDone;

        /// <summary>
        /// Initialize Component
        /// </summary>
        public DataService() {
            InitializeComponent();
        }

        /// <summary>
        /// Start Service
        /// </summary>
        protected override void OnStart(string[] args) {
            try {
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "=============================================");
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", String.Format("启动服务\"DataService {0}\"", ConfigurationManager.AppSettings["Version"]));

                //初始化全局标志位
                allDone = new EventWaitHandle(false, EventResetMode.ManualReset);
                allDone.Reset();

                //初始化全局变量
                SyncModifyInterval = 60;
                var timeInterval = ConfigurationManager.AppSettings["SyncTimeInterval"];
                SyncTimeInterval = !String.IsNullOrEmpty(timeInterval) && ComUtility.IsNumeric(timeInterval) ? Int32.Parse(timeInterval) : 0;
                SyncMachineCodeInterval = 300;
                var paramInterval = ConfigurationManager.AppSettings["SyncLscParamInterval"];
                SyncLscParamInterval = !String.IsNullOrEmpty(paramInterval) && ComUtility.IsNumeric(paramInterval) ? Int32.Parse(paramInterval) : 0;
                runState = EnmRunState.Start;
                StartupDateTime = DateTime.Now;
                UniqueID = Guid.NewGuid();
                MaxRepeatCount = 3;
                workerThreads = new List<Thread>();
                workerClients = new List<ClientObjectInfo>();
                totalLscs = new List<LscInfo>();
                totalAlarms = new List<AlarmInfo>();
                totalTrendAlarms = new List<TrendAlarmInfo>();
                totalLoadAlarms = new List<LoadAlarmInfo>();
                totalFrequencyAlarms = new List<FrequencyAlarmInfo>();
                totalDevices = new Dictionary<String, DevInfo>();
                settingQueue = new Queue<PackageInfo>();
                alarmQueue = new Queue<PackageInfo>();
                trendQueue = new Queue<PackageInfo>();
                loadQueue = new Queue<PackageInfo>();
                frequencyQueue = new Queue<PackageInfo>();
                nodeQueue = new Queue<PackageInfo>();
                logQueue = new Queue<LogInfo>();

                //创建线程初始化数据
                workerThreads = new List<Thread>();
                workerThread = new Thread(new ThreadStart(DoInitData));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "数据初始化线程创建成功");

                //创建线程监听链路
                workerThread = new Thread(new ThreadStart(HeartBeat));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "链路侦测线程创建成功");

                //创建线程监听指令表
                workerThread = new Thread(new ThreadStart(DoOrder));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "指令监听线程创建成功");

                //创建线程监听客户端配置
                workerThread = new Thread(new ThreadStart(DoCSCModify));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "客户端配置监听线程创建成功");

                //创建线程处理状态量数据包
                workerThread = new Thread(new ThreadStart(DoNodeQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "数据包(状态量)处理线程创建成功");

                //创建线程处理告警量数据包
                workerThread = new Thread(new ThreadStart(DoAlarmQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "数据包(告警量)处理线程创建成功");

                //创建线程处理预警量数据包
                workerThread = new Thread(new ThreadStart(DoPreAlarmQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "数据包(预警量)处理线程创建成功");

                //创建线程处理设置量数据包
                workerThread = new Thread(new ThreadStart(DoSettingQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "数据包(参数设置量)处理线程创建成功");

                if (SyncTimeInterval > 0) {
                    //创建线程处理时钟同步
                    workerThread = new Thread(new ThreadStart(DoSyncTime));
                    workerThread.IsBackground = true;
                    workerThread.Start();
                    workerThreads.Add(workerThread);
                    WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "时钟同步线程创建成功");
                }

                //创建线程处理日志数据包
                workerThread = new Thread(new ThreadStart(DoLogQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "日志处理线程创建成功");

                //创建线程处理指定任务
                workerThread = new Thread(new ThreadStart(DoTask));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "任务处理线程创建成功");

                //置标志位
                runState = EnmRunState.Init;
            } catch (Exception err) {
                WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[Start Click]{0}", err.Message));
                WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", "启动时发生错误，服务启动失败。");
                Restart();
            }
        }

        /// <summary>
        /// Stop Service
        /// </summary>
        protected override void OnStop() {
            try {
                WriteLog(DateTime.Now, EnmLogType.Info, "System", "正在停止服务...");
                runState = EnmRunState.Stop;
                allDone.Set();

                foreach (var workerThread in workerThreads) {
                    if (workerThread != null && workerThread.IsAlive) {
                        workerThread.Join(10000);
                    }
                }

                foreach (var clientInfo in workerClients) {
                    if (clientInfo.LinkState == EnmLinkState.Connected) {
                        TcpClose(clientInfo);
                    }

                    if (clientInfo.LinkState == EnmLinkState.Authentication) {
                        TcpLogout(clientInfo);
                    }
                }

                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("服务\"DataService\"已停止{0}", Environment.NewLine));
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[Stop Click]{0}", err.Message));
            } finally {
                try {
                    var revPackages = new List<LogInfo>();
                    lock (logQueue) {
                        while (logQueue.Count > 0) {
                            revPackages.Add(logQueue.Dequeue());
                        }
                    }

                    if (revPackages.Count > 0) {
                        WriteRealTimeLog(revPackages);
                    }
                } catch { }
            }
        }

        /// <summary>
        /// Init Registry
        /// </summary>
        private void InitRegistry() {
            var subKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Delta\\PECS\\DataService\\Install", true);
            if (subKey != null) {
                var startup = subKey.GetValue("Startup");
                if (startup != null) {
                    StartupDateTime = new DateTime(Convert.ToInt64(startup));
                } else {
                    subKey.SetValue("Startup", StartupDateTime.Ticks);
                }

                var uniqueid = subKey.GetValue("UniqueID");
                if (uniqueid != null) {
                    UniqueID = new Guid(uniqueid.ToString());
                } else {
                    subKey.SetValue("UniqueID", UniqueID.ToString());
                }
            } else {
                subKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Delta\\PECS\\DataService\\Install");
                if (subKey != null) {
                    subKey.SetValue("Startup", StartupDateTime.Ticks);
                    subKey.SetValue("UniqueID", UniqueID.ToString());
                }
            }
        }

        /// <summary>
        /// Init Setting
        /// </summary>
        private void InitCSCSetting() {
            var settingEntity = new BSetting();
            var modifyEntity = new BCSCModify();

            settingEntity.PurgeArea();
            settingEntity.PurgeBuilding();
            settingEntity.PurgeSta();
            settingEntity.PurgeDev();
            settingEntity.PurgeAI();
            settingEntity.PurgeAO();
            settingEntity.PurgeDI();
            settingEntity.PurgeDO();
            settingEntity.PurgeGroup();
            settingEntity.PurgeGroupTree();
            settingEntity.PurgeUDGroup();
            settingEntity.PurgeUDGroupTree();
            settingEntity.PurgeUser();
            settingEntity.PurgeSS();
            settingEntity.PurgeRS();
            settingEntity.PurgeRTU();
            settingEntity.PurgeSIC();
            settingEntity.PurgeSubSic();
            settingEntity.PurgeSubDevCap();
            foreach (var lsc in totalLscs) {
                try {
                    var connectionString = ComUtility.CreateLscConnectionString(lsc);
                    settingEntity.SyncArea(lsc.LscID, connectionString);
                    settingEntity.SyncBuilding(lsc.LscID, connectionString);
                    settingEntity.SyncSta(lsc.LscID, connectionString);
                    settingEntity.SyncDev(lsc.LscID, connectionString);
                    settingEntity.SyncAI(lsc.LscID, connectionString);
                    settingEntity.SyncAO(lsc.LscID, connectionString);
                    settingEntity.SyncDI(lsc.LscID, connectionString);
                    settingEntity.SyncDO(lsc.LscID, connectionString);
                    settingEntity.SyncGroup(lsc.LscID, connectionString);
                    settingEntity.SyncGroupTree(lsc.LscID, connectionString);
                    settingEntity.SyncUDGroup(lsc.LscID, connectionString);
                    settingEntity.SyncUDGroupTree(lsc.LscID, connectionString);
                    settingEntity.SyncUser(lsc.LscID, connectionString);
                    settingEntity.SyncSS(lsc.LscID, connectionString);
                    settingEntity.SyncRS(lsc.LscID, connectionString);
                    settingEntity.SyncRTU(lsc.LscID, connectionString);
                    settingEntity.SyncSIC(lsc.LscID, connectionString);
                    settingEntity.SyncSubSic(lsc.LscID, connectionString);
                    settingEntity.SyncSubDevCap(lsc.LscID, connectionString);

                    lsc.MaxNodeModify = modifyEntity.GetMaxCSCModify(lsc.LscID, connectionString);
                    lsc.MaxChangeLog = modifyEntity.GetMaxChangeLog(lsc.LscID, connectionString);
                } catch (Exception err) {
                    lsc.Enabled = false;
                    WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[InitSetting]{0}", err.Message));
                    WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("初始化Lsc客户端配置失败[Lsc:{0} - {1}]", lsc.LscID, lsc.LscName));
                }
            }

            totalLscs.RemoveAll(l => !l.Enabled);
            if (totalLscs.Count > 0) { WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "初始化配置信息完成"); }
        }

        /// <summary>
        /// Init Clients
        /// </summary>
        private void InitClients() {
            foreach (var lsc in totalLscs) {
                try {
                    workerClients.Add(new ClientObjectInfo(lsc));
                } catch (Exception err) {
                    lsc.Enabled = false;
                    WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[InitClients]{0}", err.Message));
                    WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("初始化Lsc客户端Tcp对象失败[Lsc:{0} - {1}]", lsc.LscID, lsc.LscName));
                }
            }

            totalLscs.RemoveAll(l => !l.Enabled);
            if (totalLscs.Count > 0) { WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "初始化Tcp对象完成"); }
        }

        /// <summary>
        /// Init Alarms
        /// </summary>
        private void InitAlarms() {
            var alarmEntity = new BAlarm();
            var preAlarmEntity = new BPreAlarm();
            alarmEntity.Purge();
            preAlarmEntity.ClearTrendAlarms();
            preAlarmEntity.ClearLoadAlarms();
            preAlarmEntity.ClearFrequencyAlarms();
            foreach (var lsc in totalLscs) {
                try {
                    var connectionString = ComUtility.CreateLscConnectionString(lsc);
                    var alarms = alarmEntity.SynAlarms(lsc.LscID, connectionString);
                    if (alarms.Count > 0) { totalAlarms.AddRange(alarms); }

                    var trendAlarms = preAlarmEntity.SynTrendAlarms(lsc.LscID, connectionString);
                    if (trendAlarms.Count > 0) { totalTrendAlarms.AddRange(trendAlarms); }

                    var loadAlarms = preAlarmEntity.SynLoadAlarms(lsc.LscID, connectionString);
                    if (loadAlarms.Count > 0) { totalLoadAlarms.AddRange(loadAlarms); }

                    var frequencyAlarms = preAlarmEntity.SynFrequencyAlarms(lsc.LscID, connectionString);
                    if (frequencyAlarms.Count > 0) { totalFrequencyAlarms.AddRange(frequencyAlarms); }
                } catch (Exception err) {
                    lsc.Enabled = false;
                    workerClients.RemoveAll(wc => wc.Lsc.LscID == lsc.LscID);
                    WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[InitAlarms]{0}", err.Message));
                    WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("初始化Lsc客户端告警信息失败[Lsc:{0} - {1}]", lsc.LscID, lsc.LscName));
                }
            }

            totalLscs.RemoveAll(l => !l.Enabled);
            if (totalLscs.Count > 0) { WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "初始化告警信息完成"); }
        }

        /// <summary>
        /// Init Nodes
        /// </summary>
        private void InitNodes() {
            var nodeEntity = new BNode();
            nodeEntity.Purge();
            nodeEntity.SynNodes();
            WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "初始化测点信息完成");
        }

        /// <summary>
        /// Init Orders
        /// </summary>
        private void InitOrders() {
            new BOrder().Purge();
            WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "初始化指令集完成");
        }

        /// <summary>
        /// Init Devices
        /// </summary>
        private void InitDevices() {
            try {
                totalDevices.Clear();
                foreach (var lsc in totalLscs) {
                    var devices = new BCommon().GetDevices(lsc.LscID, ComUtility.DefaultInt32);
                    foreach (var dev in devices) {
                        totalDevices[String.Format("{0}-{1}", dev.LscID, dev.DevID)] = dev;
                    }
                }
            } catch (Exception err) {
                WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[InitDevices]{0}", err.Message));
            }
        }

        /// <summary>
        /// Do Init Data
        /// </summary>
        private void DoInitData() {
            var maxRepeat = this.MaxRepeatCount;
            while (runState < EnmRunState.Run) {
                try {
                    if (runState == EnmRunState.Init) {
                        maxRepeat--;
                        WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "数据初始化...");

                        //取消注册码机制
                        //InitRegistry();
                        totalLscs.AddRange(new BLsc().GetLscs());
                        totalLscs.RemoveAll(l => !l.Enabled);
                        InitCSCSetting();
                        InitClients();
                        InitAlarms();
                        InitNodes();
                        InitOrders();
                        InitDevices();
                        runState = EnmRunState.Run;
                        WriteRealTimeLog(DateTime.Now, EnmLogType.Info, "System", "数据初始化完成");
                        allDone.Set();
                    }
                } catch (Exception err) {
                    if (maxRepeat <= 0) {
                        WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", "数据初始化错误,服务启动失败。");
                        WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoInitData]{0}", err.Message));
                        runState = EnmRunState.Stop;
                        allDone.Set();
                        break;
                    } else {
                        WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", "数据初始化错误,稍后将重试。");
                        Thread.Sleep(29000);
                    }
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Node Queue
        /// </summary>
        private void DoNodeQueue() {
            allDone.WaitOne();
            var nodeEntity = new BNode();
            var revPackages = new List<PackageInfo>();
            var revNodes = new List<NodeInfo>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        lock (nodeQueue) {
                            while (nodeQueue.Count > 0) {
                                revPackages.Add(nodeQueue.Dequeue());
                            }
                        }

                        foreach (var revQueue in revPackages) {
                            try {
                                if (revQueue.Bytes.Length > 33) {
                                    var result = BitConverter.ToInt32(revQueue.Bytes, 24);
                                    var enmResult = Enum.IsDefined(typeof(EnmResult), result) ? (EnmResult)result : EnmResult.Failure;
                                    if (enmResult == EnmResult.Success) {
                                        var cnt = BitConverter.ToInt32(revQueue.Bytes, 28);
                                        var curIndex = 32;
                                        for (var i = 1; i <= cnt; i++) {
                                            try {
                                                var nodeType = BitConverter.ToInt32(revQueue.Bytes, curIndex);
                                                var enmNodeType = Enum.IsDefined(typeof(EnmNodeType), nodeType) ? (EnmNodeType)nodeType : EnmNodeType.Null;
                                                var nodeId = BitConverter.ToInt32(revQueue.Bytes, curIndex + 4);
                                                var targetNode = nodeEntity.GetNode(revQueue.LscID, nodeId, enmNodeType);
                                                if (targetNode == null) { continue; }

                                                targetNode.DateTime = ComUtility.DefaultDateTime;
                                                lock (totalAlarms) {
                                                    var targetAlarms = totalAlarms.FindAll(a => {
                                                        return a.LscID == revQueue.LscID && a.NodeID == nodeId;
                                                    });

                                                    if (targetAlarms != null && targetAlarms.Count > 0) {
                                                        targetNode.DateTime = targetAlarms.Max(a => a.StartTime);
                                                    }
                                                }

                                                switch (enmNodeType) {
                                                    case EnmNodeType.Dic:
                                                    case EnmNodeType.Doc:
                                                        targetNode.Value = Convert.ToInt16(revQueue.Bytes[curIndex + 8]);
                                                        targetNode.Status = Enum.IsDefined(typeof(EnmState), Convert.ToInt32(revQueue.Bytes[curIndex + 9])) ? (EnmState)Convert.ToInt32(revQueue.Bytes[curIndex + 9]) : EnmState.Null;
                                                        targetNode.UpdateTime = DateTime.Now;

                                                        curIndex += 10;
                                                        break;
                                                    case EnmNodeType.Aic:
                                                    case EnmNodeType.Aoc:
                                                        targetNode.Value = BitConverter.ToSingle(revQueue.Bytes, curIndex + 8);
                                                        targetNode.Status = Enum.IsDefined(typeof(EnmState), Convert.ToInt32(revQueue.Bytes[curIndex + 12])) ? (EnmState)Convert.ToInt32(revQueue.Bytes[curIndex + 12]) : EnmState.Null;
                                                        targetNode.UpdateTime = DateTime.Now;

                                                        curIndex += 13;
                                                        break;
                                                    default:
                                                        break;
                                                }

                                                revNodes.Add(targetNode);
                                            } catch (Exception err) {
                                                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoNodeQueue-01]{0}", err.Message));
                                            }
                                        }

                                        if (revNodes.Count > 0) { nodeEntity.UpdateNodes(revNodes); }
                                    }
                                }
                            } catch (Exception err) {
                                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoNodeQueue-02]{0}", err.Message));
                            } finally {
                                revNodes.Clear();
                            }
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoNodeQueue-03]{0}", err.Message));
                } finally {
                    revPackages.Clear();
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Alarm Queue
        /// </summary>
        private void DoAlarmQueue() {
            allDone.WaitOne();
            var alarmEntity = new BAlarm();
            var revPackages = new List<PackageInfo>();
            var startAlarms = new List<AlarmInfo>();
            var confirmAlarms = new List<AlarmInfo>();
            var endAlarms = new List<AlarmInfo>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        lock (alarmQueue) {
                            while (alarmQueue.Count > 0) {
                                revPackages.Add(alarmQueue.Dequeue());
                            }
                        }

                        foreach (var revQueue in revPackages) {
                            try {
                                var cnt = BitConverter.ToInt32(revQueue.Bytes, 16);
                                if (22 + cnt * 453 != revQueue.Bytes.Length)
                                    continue;

                                var clientInfo = workerClients.Find(c => c.Lsc.LscID == revQueue.LscID);
                                var curIndex = 20;
                                var totalCnt = 0;
                                for (var i = 0; i < cnt; i++) {
                                    try {
                                        var revAlarm = new AlarmInfo();
                                        revAlarm.LscID = revQueue.LscID;
                                        revAlarm.SerialNO = BitConverter.ToInt32(revQueue.Bytes, curIndex);
                                        var nodeType = BitConverter.ToInt32(revQueue.Bytes, curIndex + 4);
                                        revAlarm.NodeType = Enum.IsDefined(typeof(EnmNodeType), nodeType) ? (EnmNodeType)nodeType : EnmNodeType.Null;
                                        revAlarm.NodeID = BitConverter.ToInt32(revQueue.Bytes, curIndex + 8);
                                        revAlarm.NodeName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 12, 40).Trim(Convert.ToChar(0));
                                        revAlarm.Area1Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 52, 40).Trim(Convert.ToChar(0));
                                        revAlarm.Area2Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 92, 40).Trim(Convert.ToChar(0));
                                        revAlarm.Area3Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 132, 40).Trim(Convert.ToChar(0));
                                        revAlarm.Area4Name = ComUtility.DefaultString;
                                        revAlarm.StaName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 172, 40).Trim(Convert.ToChar(0));
                                        revAlarm.DevName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 212, 40).Trim(Convert.ToChar(0));
                                        revAlarm.DevDesc = ComUtility.DefaultString;
                                        revAlarm.StartTime = Convert.ToDateTime(String.Format("{0}-{1}-{2} {3}:{4}:{5}", BitConverter.ToInt16(revQueue.Bytes, curIndex + 252), revQueue.Bytes[curIndex + 254], revQueue.Bytes[curIndex + 255], revQueue.Bytes[curIndex + 256], revQueue.Bytes[curIndex + 257], revQueue.Bytes[curIndex + 258]));
                                        revAlarm.EndTime = ComUtility.DefaultDateTime;
                                        var alarmLevel = BitConverter.ToInt32(revQueue.Bytes, curIndex + 259);
                                        revAlarm.AlarmLevel = Enum.IsDefined(typeof(EnmAlarmLevel), alarmLevel) ? (EnmAlarmLevel)alarmLevel : EnmAlarmLevel.Null;
                                        var alarmStatus = BitConverter.ToInt32(revQueue.Bytes, curIndex + 263);
                                        revAlarm.AlarmStatus = Enum.IsDefined(typeof(EnmAlarmStatus), alarmStatus) ? (EnmAlarmStatus)alarmStatus : EnmAlarmStatus.Null;
                                        revAlarm.AlarmDesc = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 267, 40).Trim(Convert.ToChar(0));
                                        revAlarm.AuxAlarmDesc = ComUtility.DefaultString;
                                        revAlarm.AlarmValue = BitConverter.ToSingle(revQueue.Bytes, curIndex + 307);
                                        revAlarm.ConfirmName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 311, 20).Trim(Convert.ToChar(0));
                                        var confirmMarking = BitConverter.ToInt32(revQueue.Bytes, curIndex + 331);
                                        revAlarm.ConfirmMarking = Enum.IsDefined(typeof(EnmConfirmMarking), confirmMarking) ? (EnmConfirmMarking)confirmMarking : EnmConfirmMarking.Null;
                                        revAlarm.ConfirmTime = ComUtility.DefaultDateTime;
                                        revAlarm.AlarmID = BitConverter.ToInt32(revQueue.Bytes, curIndex + 335);
                                        var dspClearDelay = BitConverter.ToInt32(revQueue.Bytes, curIndex + 339);
                                        revAlarm.ProjName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 343, 20).Trim(Convert.ToChar(0));
                                        revAlarm.AuxSet = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 363, 80).Trim(Convert.ToChar(0));
                                        revAlarm.TaskID = ComUtility.DefaultString;
                                        revAlarm.TurnCount = BitConverter.ToInt32(revQueue.Bytes, curIndex + 443);
                                        revAlarm.TotalCount = totalCnt = BitConverter.ToInt32(revQueue.Bytes, curIndex + 447);
                                        revAlarm.IsSyncAlarm = BitConverter.ToBoolean(revQueue.Bytes, curIndex + 451);
                                        revAlarm.IsSyncAlarmFirst = BitConverter.ToBoolean(revQueue.Bytes, curIndex + 452);
                                        revAlarm.UpdateTime = DateTime.Now;
                                        if (revAlarm.NodeType == EnmNodeType.Aic || revAlarm.NodeType == EnmNodeType.Aoc) {
                                            revAlarm.AlarmDesc = String.Format("{0}(触发值:{1})", revAlarm.AlarmDesc, revAlarm.AlarmValue);
                                        }

                                        //Set device description
                                        lock (totalDevices) {
                                            var key = String.Format("{0}-{1}", revAlarm.LscID, ComUtility.GetDevID(revAlarm.NodeID));
                                            if (totalDevices.ContainsKey(key)) {
                                                var dev = totalDevices[key];
                                                revAlarm.DevDesc = dev.DevDesc;
                                            }
                                        }

                                        //Sync Package Header
                                        if (revAlarm.IsSyncAlarmFirst) {
                                            WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("接收同步的实时告警信息[LscID:{0}]", revAlarm.LscID));
                                            alarmEntity.Purge(revAlarm.LscID);
                                            lock (totalAlarms) { totalAlarms.RemoveAll(a => a.LscID == revAlarm.LscID); }
                                            startAlarms.Clear();
                                            confirmAlarms.Clear();
                                            endAlarms.Clear();
                                        }

                                        switch (revAlarm.AlarmStatus) {
                                            case EnmAlarmStatus.Start:
                                                startAlarms.Add(revAlarm);
                                                break;
                                            case EnmAlarmStatus.Confirm:
                                                lock (totalAlarms) {
                                                    var targetAlarm = totalAlarms.Find(a => {
                                                        return a.LscID == revAlarm.LscID && a.SerialNO == revAlarm.SerialNO;
                                                    });

                                                    if (targetAlarm != null) {
                                                        targetAlarm.ConfirmName = revAlarm.ConfirmName;
                                                        targetAlarm.ConfirmMarking = revAlarm.ConfirmMarking;
                                                        targetAlarm.ConfirmTime = revAlarm.StartTime;
                                                        targetAlarm.UpdateTime = DateTime.Now;
                                                        confirmAlarms.Add(targetAlarm);
                                                    }
                                                }
                                                break;
                                            case EnmAlarmStatus.Ended:
                                                endAlarms.Add(revAlarm);
                                                break;
                                            case EnmAlarmStatus.Invalid:
                                            default:
                                                break;
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoAlarmQueue-01]{0}", err.Message));
                                    } finally {
                                        curIndex += 453;
                                    }
                                }

                                if (startAlarms.Count > 0) {
                                    alarmEntity.AddAlarms(startAlarms);
                                    lock (totalAlarms) { totalAlarms.AddRange(startAlarms); }
                                }

                                if (confirmAlarms.Count > 0) {
                                    alarmEntity.UpdateAlarms(confirmAlarms);
                                }

                                if (endAlarms.Count > 0) {
                                    alarmEntity.DeleteAlarms(endAlarms);
                                    lock (totalAlarms) {
                                        foreach (var alarm in endAlarms) {
                                            totalAlarms.RemoveAll(a => a.LscID == alarm.LscID && a.SerialNO == alarm.SerialNO);
                                        }
                                    }
                                }

                                if (clientInfo != null && clientInfo.LinkState == EnmLinkState.Authentication) {
                                    var totalAlarmCnt = totalAlarms.Count(ai => { return ai.LscID == revQueue.LscID; });
                                    if (totalAlarmCnt != totalCnt && DateTime.Now >= clientInfo.LastSyncAlarmTime.AddMinutes(5)) {
                                        SyncAlarms(clientInfo);
                                        clientInfo.LastSyncAlarmTime = DateTime.Now;
                                    }
                                }
                            } catch (Exception err) {
                                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoAlarmQueue-02]{0}", err.Message));
                            } finally {
                                startAlarms.Clear();
                                confirmAlarms.Clear();
                                endAlarms.Clear();
                            }
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoAlarmQueue-03]{0}", err.Message));
                } finally {
                    revPackages.Clear();
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do PreAlarm Queue
        /// </summary>
        private void DoPreAlarmQueue() {
            allDone.WaitOne();
            var preAlarmEntity = new BPreAlarm();
            var revPackages = new List<PackageInfo>();

            var trendStartAlarms = new List<TrendAlarmInfo>();
            var trendConfirmAlarms = new List<TrendAlarmInfo>();
            var trendEndAlarms = new List<TrendAlarmInfo>();
            var trendAlarmCnt = new Dictionary<Int32, Int32>();

            var loadStartAlarms = new List<LoadAlarmInfo>();
            var loadConfirmAlarms = new List<LoadAlarmInfo>();
            var loadEndAlarms = new List<LoadAlarmInfo>();
            var loadAlarmCnt = new Dictionary<Int32, Int32>();

            var frequencyStartAlarms = new List<FrequencyAlarmInfo>();
            var frequencyConfirmAlarms = new List<FrequencyAlarmInfo>();
            var frequencyEndAlarms = new List<FrequencyAlarmInfo>();
            var frequencyAlarmCnt = new Dictionary<Int32, Int32>();

            while (runState < EnmRunState.Stop) {
                #region Trend Alarm
                try {
                    lock (trendQueue) {
                        while (trendQueue.Count > 0) {
                            revPackages.Add(trendQueue.Dequeue());
                        }
                    }

                    foreach (var revQueue in revPackages) {
                        try {
                            var cnt = BitConverter.ToInt32(revQueue.Bytes, 16);
                            if (22 + cnt * 322 != revQueue.Bytes.Length)
                                continue;

                            var clientInfo = workerClients.Find(c => c.Lsc.LscID == revQueue.LscID);
                            var curIndex = 20;
                            for (var i = 0; i < cnt; i++) {
                                try {
                                    var revAlarm = new TrendAlarmInfo();
                                    revAlarm.LscID = revQueue.LscID;
                                    revAlarm.NodeID = BitConverter.ToInt32(revQueue.Bytes, curIndex);
                                    revAlarm.NodeType = EnmNodeType.Aic;
                                    revAlarm.NodeName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 4, 40).Trim(Convert.ToChar(0));
                                    revAlarm.Area1Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 44, 40).Trim(Convert.ToChar(0));
                                    revAlarm.Area2Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 84, 40).Trim(Convert.ToChar(0));
                                    revAlarm.Area3Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 124, 40).Trim(Convert.ToChar(0));
                                    revAlarm.StaName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 164, 40).Trim(Convert.ToChar(0));
                                    revAlarm.DevName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 204, 40).Trim(Convert.ToChar(0));
                                    revAlarm.AlarmType = "实时监测";
                                    revAlarm.EventTime = ComUtility.ConvertToDateTime(BitConverter.ToInt16(revQueue.Bytes, curIndex + 244), revQueue.Bytes[curIndex + 246], revQueue.Bytes[curIndex + 247], revQueue.Bytes[curIndex + 248], revQueue.Bytes[curIndex + 249], revQueue.Bytes[curIndex + 250]);
                                    revAlarm.AlarmTime = ComUtility.ConvertToDateTime(BitConverter.ToInt16(revQueue.Bytes, curIndex + 251), revQueue.Bytes[curIndex + 253], revQueue.Bytes[curIndex + 254], revQueue.Bytes[curIndex + 255], revQueue.Bytes[curIndex + 256], revQueue.Bytes[curIndex + 257]);
                                    revAlarm.AlarmLevel = BitConverter.ToInt32(revQueue.Bytes, curIndex + 258);
                                    revAlarm.AlarmStatus = BitConverter.ToInt32(revQueue.Bytes, curIndex + 262);
                                    revAlarm.StartValue = BitConverter.ToSingle(revQueue.Bytes, curIndex + 266);
                                    revAlarm.AlarmValue = BitConverter.ToSingle(revQueue.Bytes, curIndex + 270);
                                    revAlarm.DiffValue = BitConverter.ToSingle(revQueue.Bytes, curIndex + 274);
                                    revAlarm.ConfirmName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 278, 20).Trim(Convert.ToChar(0));
                                    revAlarm.EndName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 298, 20).Trim(Convert.ToChar(0));
                                    trendAlarmCnt[revAlarm.LscID] = BitConverter.ToInt32(revQueue.Bytes, curIndex + 318);

                                    switch (revAlarm.AlarmStatus) {
                                        case (Int32)EnmAlarmStatus.Start:
                                            revAlarm.StartTime = revAlarm.AlarmTime = revAlarm.EventTime;
                                            trendStartAlarms.Add(revAlarm);
                                            break;
                                        case (Int32)EnmAlarmStatus.Confirm:
                                            lock (totalTrendAlarms) {
                                                var targetAlarm = totalTrendAlarms.Find(a => { return a.LscID == revAlarm.LscID && a.NodeID == revAlarm.NodeID; });
                                                if (targetAlarm != null) {
                                                    targetAlarm.ConfirmName = revAlarm.ConfirmName;
                                                    targetAlarm.ConfirmTime = revAlarm.EventTime;
                                                    trendConfirmAlarms.Add(targetAlarm);
                                                }
                                            }
                                            break;
                                        case (Int32)EnmAlarmStatus.Ended:
                                            trendEndAlarms.Add(revAlarm);
                                            break;
                                        default:
                                            break;
                                    }
                                } catch (Exception err) {
                                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Receive.Trend.01]{0}", err.Message));
                                } finally {
                                    curIndex += 322;
                                }
                            }

                            if (trendStartAlarms.Count > 0) {
                                preAlarmEntity.SaveTrendAlarms(trendStartAlarms);
                                lock (totalTrendAlarms) { totalTrendAlarms.AddRange(trendStartAlarms); }
                            }

                            if (trendConfirmAlarms.Count > 0) {
                                preAlarmEntity.SaveTrendAlarms(trendConfirmAlarms);
                            }

                            if (trendEndAlarms.Count > 0) {
                                preAlarmEntity.DeleteTrendAlarms(trendEndAlarms);
                                lock (totalTrendAlarms) {
                                    foreach (var alarm in trendEndAlarms) {
                                        totalTrendAlarms.RemoveAll(a => a.LscID == alarm.LscID && a.NodeID == alarm.NodeID);
                                    }
                                }
                            }
                        } catch (Exception err) {
                            WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Receive.Trend.02]{0}", err.Message));
                        } finally {
                            trendStartAlarms.Clear();
                            trendConfirmAlarms.Clear();
                            trendEndAlarms.Clear();
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Receive.Trend.03]{0}", err.Message));
                } finally {
                    revPackages.Clear();
                }
                #endregion

                #region Load Alarm
                try {
                    lock (loadQueue) {
                        while (loadQueue.Count > 0) {
                            revPackages.Add(loadQueue.Dequeue());
                        }
                    }

                    foreach (var revQueue in revPackages) {
                        try {
                            var cnt = BitConverter.ToInt32(revQueue.Bytes, 16);
                            if (22 + cnt * 283 != revQueue.Bytes.Length)
                                continue;

                            var clientInfo = workerClients.Find(c => c.Lsc.LscID == revQueue.LscID);
                            var curIndex = 20;
                            for (var i = 0; i < cnt; i++) {
                                try {
                                    var revAlarm = new LoadAlarmInfo();
                                    revAlarm.LscID = revQueue.LscID;
                                    revAlarm.DevID = BitConverter.ToInt32(revQueue.Bytes, curIndex);
                                    revAlarm.Area1Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 4, 40).Trim(Convert.ToChar(0));
                                    revAlarm.Area2Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 44, 40).Trim(Convert.ToChar(0));
                                    revAlarm.Area3Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 84, 40).Trim(Convert.ToChar(0));
                                    revAlarm.StaName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 124, 40).Trim(Convert.ToChar(0));
                                    revAlarm.DevName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 164, 40).Trim(Convert.ToChar(0));
                                    revAlarm.DevTypeID = BitConverter.ToInt32(revQueue.Bytes, curIndex + 204);
                                    revAlarm.EventTime = ComUtility.ConvertToDateTime(BitConverter.ToInt16(revQueue.Bytes, curIndex + 208), revQueue.Bytes[curIndex + 210], revQueue.Bytes[curIndex + 211], revQueue.Bytes[curIndex + 212], revQueue.Bytes[curIndex + 213], revQueue.Bytes[curIndex + 214]);
                                    revAlarm.AlarmLevel = BitConverter.ToInt32(revQueue.Bytes, curIndex + 215);
                                    revAlarm.AlarmStatus = BitConverter.ToInt32(revQueue.Bytes, curIndex + 219);
                                    revAlarm.RateValue = BitConverter.ToSingle(revQueue.Bytes, curIndex + 223);
                                    revAlarm.LoadValue = BitConverter.ToSingle(revQueue.Bytes, curIndex + 227);
                                    revAlarm.LoadPercent = BitConverter.ToSingle(revQueue.Bytes, curIndex + 231);
                                    revAlarm.RightPercent = BitConverter.ToSingle(revQueue.Bytes, curIndex + 235);
                                    revAlarm.ConfirmName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 239, 20).Trim(Convert.ToChar(0));
                                    revAlarm.EndName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 259, 20).Trim(Convert.ToChar(0));
                                    loadAlarmCnt[revAlarm.LscID] = BitConverter.ToInt32(revQueue.Bytes, curIndex + 279);

                                    switch (revAlarm.AlarmStatus) {
                                        case (Int32)EnmAlarmStatus.Start:
                                            revAlarm.StartTime = revAlarm.EventTime;
                                            loadStartAlarms.Add(revAlarm);
                                            break;
                                        case (Int32)EnmAlarmStatus.Confirm:
                                            lock (totalLoadAlarms) {
                                                var targetAlarm = totalLoadAlarms.Find(a => { return a.LscID == revAlarm.LscID && a.DevID == revAlarm.DevID; });
                                                if (targetAlarm != null) {
                                                    targetAlarm.ConfirmName = revAlarm.ConfirmName;
                                                    targetAlarm.ConfirmTime = revAlarm.EventTime;
                                                    loadConfirmAlarms.Add(targetAlarm);
                                                }
                                            }
                                            break;
                                        case (Int32)EnmAlarmStatus.Ended:
                                            loadEndAlarms.Add(revAlarm);
                                            break;
                                        default:
                                            break;
                                    }
                                } catch (Exception err) {
                                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Receive.Load.01]{0}", err.Message));
                                } finally {
                                    curIndex += 283;
                                }
                            }

                            if (loadStartAlarms.Count > 0) {
                                preAlarmEntity.SaveLoadAlarms(loadStartAlarms);
                                lock (totalLoadAlarms) { totalLoadAlarms.AddRange(loadStartAlarms); }
                            }

                            if (loadConfirmAlarms.Count > 0) {
                                preAlarmEntity.SaveLoadAlarms(loadConfirmAlarms);
                            }

                            if (loadEndAlarms.Count > 0) {
                                preAlarmEntity.DeleteLoadAlarms(loadEndAlarms);
                                lock (totalLoadAlarms) {
                                    foreach (var alarm in loadEndAlarms) {
                                        totalLoadAlarms.RemoveAll(a => a.LscID == alarm.LscID && a.DevID == alarm.DevID);
                                    }
                                }
                            }
                        } catch (Exception err) {
                            WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Receive.Load.02]{0}", err.Message));
                        } finally {
                            loadStartAlarms.Clear();
                            loadConfirmAlarms.Clear();
                            loadEndAlarms.Clear();
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Receive.Load.03]{0}", err.Message));
                } finally {
                    revPackages.Clear();
                }
                #endregion

                #region Frequency Alarm
                try {
                    lock (frequencyQueue) {
                        while (frequencyQueue.Count > 0) {
                            revPackages.Add(frequencyQueue.Dequeue());
                        }
                    }

                    foreach (var revQueue in revPackages) {
                        try {
                            var cnt = BitConverter.ToInt32(revQueue.Bytes, 16);
                            if (22 + cnt * 322 != revQueue.Bytes.Length)
                                continue;

                            var clientInfo = workerClients.Find(c => c.Lsc.LscID == revQueue.LscID);
                            var curIndex = 20;
                            for (var i = 0; i < cnt; i++) {
                                try {
                                    var revAlarm = new FrequencyAlarmInfo();
                                    revAlarm.LscID = revQueue.LscID;
                                    revAlarm.NodeID = BitConverter.ToInt32(revQueue.Bytes, curIndex);
                                    var nodeType = BitConverter.ToInt32(revQueue.Bytes, curIndex + 4);
                                    revAlarm.NodeType = Enum.IsDefined(typeof(EnmNodeType), nodeType) ? (EnmNodeType)nodeType : EnmNodeType.Null;
                                    revAlarm.NodeName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 8, 40).Trim(Convert.ToChar(0));
                                    revAlarm.Area1Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 48, 40).Trim(Convert.ToChar(0));
                                    revAlarm.Area2Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 88, 40).Trim(Convert.ToChar(0));
                                    revAlarm.Area3Name = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 128, 40).Trim(Convert.ToChar(0));
                                    revAlarm.StaName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 168, 40).Trim(Convert.ToChar(0));
                                    revAlarm.DevName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 208, 40).Trim(Convert.ToChar(0));
                                    revAlarm.EventTime = ComUtility.ConvertToDateTime(BitConverter.ToInt16(revQueue.Bytes, curIndex + 248), revQueue.Bytes[curIndex + 250], revQueue.Bytes[curIndex + 251], revQueue.Bytes[curIndex + 252], revQueue.Bytes[curIndex + 253], revQueue.Bytes[curIndex + 254]);
                                    revAlarm.StartTime = ComUtility.ConvertToDateTime(BitConverter.ToInt16(revQueue.Bytes, curIndex + 255), revQueue.Bytes[curIndex + 257], revQueue.Bytes[curIndex + 258], revQueue.Bytes[curIndex + 259], revQueue.Bytes[curIndex + 260], revQueue.Bytes[curIndex + 261]);
                                    revAlarm.AlarmLevel = BitConverter.ToInt32(revQueue.Bytes, curIndex + 262);
                                    revAlarm.AlarmStatus = BitConverter.ToInt32(revQueue.Bytes, curIndex + 266);
                                    revAlarm.FreAlarmValue = BitConverter.ToInt32(revQueue.Bytes, curIndex + 270);
                                    revAlarm.FreRightValue = BitConverter.ToInt32(revQueue.Bytes, curIndex + 274);
                                    revAlarm.ConfirmName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 278, 20).Trim(Convert.ToChar(0));
                                    revAlarm.EndName = ASCIIEncoding.Default.GetString(revQueue.Bytes, curIndex + 298, 20).Trim(Convert.ToChar(0));
                                    frequencyAlarmCnt[revAlarm.LscID] = BitConverter.ToInt32(revQueue.Bytes, curIndex + 318);

                                    switch (revAlarm.AlarmStatus) {
                                        case (Int32)EnmAlarmStatus.Start:
                                            revAlarm.AlarmTime = revAlarm.EventTime;
                                            frequencyStartAlarms.Add(revAlarm);
                                            break;
                                        case (Int32)EnmAlarmStatus.Confirm:
                                            lock (totalFrequencyAlarms) {
                                                var targetAlarm = totalFrequencyAlarms.Find(a => { return a.LscID == revAlarm.LscID && a.NodeID == revAlarm.NodeID && a.NodeType == revAlarm.NodeType; });
                                                if (targetAlarm != null) {
                                                    targetAlarm.ConfirmName = revAlarm.ConfirmName;
                                                    targetAlarm.ConfirmTime = revAlarm.EventTime;
                                                    frequencyConfirmAlarms.Add(targetAlarm);
                                                }
                                            }
                                            break;
                                        case (Int32)EnmAlarmStatus.Ended:
                                            frequencyEndAlarms.Add(revAlarm);
                                            break;
                                        case (Int32)EnmAlarmStatus.Truning:
                                            lock (totalFrequencyAlarms) {
                                                var targetAlarm = totalFrequencyAlarms.Find(a => { return a.LscID == revAlarm.LscID && a.NodeID == revAlarm.NodeID && a.NodeType == revAlarm.NodeType; });
                                                if (targetAlarm != null) {
                                                    targetAlarm.FreRightValue = revAlarm.FreRightValue;
                                                    frequencyConfirmAlarms.Add(targetAlarm);
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                } catch (Exception err) {
                                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Receive.Frequency.01]{0}", err.Message));
                                } finally {
                                    curIndex += 322;
                                }
                            }

                            if (frequencyStartAlarms.Count > 0) {
                                preAlarmEntity.SaveFrequencyAlarms(frequencyStartAlarms);
                                lock (totalFrequencyAlarms) { totalFrequencyAlarms.AddRange(frequencyStartAlarms); }
                            }

                            if (frequencyConfirmAlarms.Count > 0) {
                                preAlarmEntity.SaveFrequencyAlarms(frequencyConfirmAlarms);
                            }

                            if (frequencyEndAlarms.Count > 0) {
                                preAlarmEntity.DeleteFrequencyAlarms(frequencyEndAlarms);
                                lock (totalFrequencyAlarms) {
                                    foreach (var alarm in frequencyEndAlarms) {
                                        totalFrequencyAlarms.RemoveAll(a => a.LscID == alarm.LscID && a.NodeID == alarm.NodeID);
                                    }
                                }
                            }
                        } catch (Exception err) {
                            WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Receive.Frequency.02]{0}", err.Message));
                        } finally {
                            frequencyStartAlarms.Clear();
                            frequencyConfirmAlarms.Clear();
                            frequencyEndAlarms.Clear();
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Receive.Frequency.03]{0}", err.Message));
                } finally {
                    revPackages.Clear();
                }
                #endregion

                var temp = new List<LscInfo>();
                lock (totalLscs) { temp.AddRange(totalLscs); }
                foreach (var lsc in temp) {
                    var connectionString = ComUtility.CreateLscConnectionString(lsc);

                    #region Sync Trend Alarm
                    try {
                        if (trendAlarmCnt.ContainsKey(lsc.LscID)) {
                            var alarmCnt = totalTrendAlarms.Count(ta => ta.LscID == lsc.LscID);
                            if (trendAlarmCnt[lsc.LscID] != alarmCnt) {
                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("开始同步{0}趋势预警信息[LscID:{1}]...", lsc.LscName, lsc.LscID));
                                preAlarmEntity.ClearTrendAlarms(lsc.LscID);
                                lock (trendQueue) {
                                    var tempQueue = new Queue<PackageInfo>();
                                    while (trendQueue.Count > 0) {
                                        var queue = trendQueue.Dequeue();
                                        if (queue.LscID != lsc.LscID) {
                                            tempQueue.Enqueue(queue);
                                        }
                                    }

                                    while (tempQueue.Count > 0) {
                                        trendQueue.Enqueue(tempQueue.Dequeue());
                                    }
                                }

                                var trendAlarms = preAlarmEntity.SynTrendAlarms(lsc.LscID, connectionString);
                                lock (totalTrendAlarms) {
                                    totalTrendAlarms.RemoveAll(ta => ta.LscID == lsc.LscID);
                                    totalTrendAlarms.AddRange(trendAlarms);
                                }
                                trendAlarmCnt[lsc.LscID] = trendAlarms.Count;
                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}趋势预警信息同步完成", lsc.LscName));
                            }
                        }
                    } catch (Exception err) {
                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Sync.Trend]{0}", err.Message));
                    }
                    #endregion

                    #region Sync Load Alarm
                    try {
                        if (loadAlarmCnt.ContainsKey(lsc.LscID)) {
                            var alarmCnt = totalLoadAlarms.Count(ta => ta.LscID == lsc.LscID);
                            if (loadAlarmCnt[lsc.LscID] != alarmCnt) {
                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("开始同步{0}负荷预警信息[LscID:{1}]...", lsc.LscName, lsc.LscID));
                                preAlarmEntity.ClearLoadAlarms(lsc.LscID);
                                lock (loadQueue) {
                                    var tempQueue = new Queue<PackageInfo>();
                                    while (loadQueue.Count > 0) {
                                        var queue = loadQueue.Dequeue();
                                        if (queue.LscID != lsc.LscID) {
                                            tempQueue.Enqueue(queue);
                                        }
                                    }

                                    while (tempQueue.Count > 0) {
                                        loadQueue.Enqueue(tempQueue.Dequeue());
                                    }
                                }

                                var loadAlarms = preAlarmEntity.SynLoadAlarms(lsc.LscID, connectionString);
                                lock (totalLoadAlarms) {
                                    totalLoadAlarms.RemoveAll(ta => ta.LscID == lsc.LscID);
                                    totalLoadAlarms.AddRange(loadAlarms);
                                }
                                loadAlarmCnt[lsc.LscID] = loadAlarms.Count;
                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}负荷预警信息同步完成", lsc.LscName));
                            }
                        }
                    } catch (Exception err) {
                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Sync.Load]{0}", err.Message));
                    }
                    #endregion

                    #region Sync Frequency Alarm
                    try {
                        if (frequencyAlarmCnt.ContainsKey(lsc.LscID)) {
                            var alarmCnt = totalFrequencyAlarms.Count(ta => ta.LscID == lsc.LscID);
                            if (frequencyAlarmCnt[lsc.LscID] != alarmCnt) {
                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("开始同步{0}频度预警信息[LscID:{1}]...", lsc.LscName, lsc.LscID));
                                preAlarmEntity.ClearFrequencyAlarms(lsc.LscID);
                                lock (frequencyQueue) {
                                    var tempQueue = new Queue<PackageInfo>();
                                    while (frequencyQueue.Count > 0) {
                                        var queue = frequencyQueue.Dequeue();
                                        if (queue.LscID != lsc.LscID) {
                                            tempQueue.Enqueue(queue);
                                        }
                                    }

                                    while (tempQueue.Count > 0) {
                                        frequencyQueue.Enqueue(tempQueue.Dequeue());
                                    }
                                }

                                var frequencyAlarms = preAlarmEntity.SynFrequencyAlarms(lsc.LscID, connectionString);
                                lock (totalFrequencyAlarms) {
                                    totalFrequencyAlarms.RemoveAll(ta => ta.LscID == lsc.LscID);
                                    totalFrequencyAlarms.AddRange(frequencyAlarms);
                                }
                                frequencyAlarmCnt[lsc.LscID] = frequencyAlarms.Count;
                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}频度预警信息同步完成", lsc.LscName));
                            }
                        }
                    } catch (Exception err) {
                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoPreAlarmQueue.Sync.Frequency]{0}", err.Message));
                    }
                    #endregion
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Setting Queue
        /// </summary>
        private void DoSettingQueue() {
            allDone.WaitOne();
            var revPackages = new List<PackageInfo>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        lock (settingQueue) {
                            while (settingQueue.Count > 0) {
                                revPackages.Add(settingQueue.Dequeue());
                            }
                        }

                        foreach (var revQueue in revPackages) {
                            try {
                                if (revQueue.Bytes.Length == 30) {
                                    var nodeId = BitConverter.ToInt32(revQueue.Bytes, 20);
                                    var result = BitConverter.ToInt32(revQueue.Bytes, 24);
                                    var enmResult = Enum.IsDefined(typeof(EnmResult), result) ? (EnmResult)result : EnmResult.Failure;

                                    if (enmResult == EnmResult.Success) {
                                        WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("测点设置成功[LscID:{0} NodeID:{1}]", revQueue.LscID, nodeId));
                                    } else {
                                        WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("测点设置失败[LscID:{0} NodeID:{1}]", revQueue.LscID, nodeId));
                                    }
                                }
                            } catch (Exception err) {
                                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoSettingQueue-01]{0}", err.Message));
                            }
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoSettingQueue-02]{0}", err.Message));
                } finally {
                    revPackages.Clear();
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Log Queue
        /// </summary>
        private void DoLogQueue() {
            allDone.WaitOne();
            var logEntity = new BLog();
            var revPackages = new List<LogInfo>();

            while (runState < EnmRunState.Stop) {
                try {
                    lock (logQueue) {
                        while (logQueue.Count > 0) {
                            revPackages.Add(logQueue.Dequeue());
                        }
                    }

                    if (revPackages.Count > 0) {
                        logEntity.WriteTxtLog(revPackages);
                        logEntity.WriteDBLog(revPackages);
                    }
                } catch { } finally { revPackages.Clear(); }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Order
        /// </summary>
        private void DoOrder() {
            allDone.WaitOne();
            var orderEntity = new BOrder();
            var rNodes = new List<OrderInfo>();
            var rConfirms = new List<OrderInfo>();
            var rAocs = new List<OrderInfo>();
            var rDocs = new List<OrderInfo>();
            var rTrendConfirm = new List<OrderInfo>();
            var rTrendEnd = new List<OrderInfo>();
            var rLoadConfirm = new List<OrderInfo>();
            var rLoadEnd = new List<OrderInfo>();
            var rFrequencyConfirm = new List<OrderInfo>();
            var rFrequencyEnd = new List<OrderInfo>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        var orders = orderEntity.GetOrders();
                        if (orders != null && orders.Count > 0) {
                            #region Restart Service
                            var restart = orders.Find(o => o.OrderType == EnmActType.Restart);
                            if (restart != null) {
                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("请求重启服务[User:{0} IP:{1}]", restart.RelValue1, restart.RelValue2));
                                Restart();
                                continue;
                            }
                            #endregion

                            var ordersGroup = orders.GroupBy(o => o.LscID);
                            foreach (var group in ordersGroup) {
                                #region Delete Lsc
                                var delete = group.FirstOrDefault(o => o.OrderType == EnmActType.DeleteLsc);
                                if (delete != null) {
                                    try {
                                        WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("请求删除Lsc客户端[Lsc:{0} User:{1} IP:{2}]", delete.LscID, delete.RelValue1, delete.RelValue2));
                                        DeleteLsc(delete.LscID);
                                        continue;
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-01]{0}", err.Message));
                                    }
                                }
                                #endregion

                                #region Sync Data
                                var sync = group.FirstOrDefault(o => o.OrderType == EnmActType.SynData);
                                if (sync != null) {
                                    try {
                                        var lsc = new BLsc().GetLsc(sync.LscID);
                                        if (lsc != null) {
                                            switch (sync.RelValue1) {
                                                case "ST":
                                                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("请求同步Lsc客户端配置数据[Lsc:{0} - {1} User:{2} IP:{3}]", lsc.LscID, lsc.LscName, sync.RelValue2, sync.RelValue3));
                                                    SyncSetting(lsc);
                                                    break;
                                                case "CA":
                                                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("请求同步Lsc客户端配置数据并清空告警[Lsc:{0} - {1} User:{2} IP:{3}]", lsc.LscID, lsc.LscName, sync.RelValue2, sync.RelValue3));
                                                    SyncSetting(lsc);
                                                    new BAlarm().Purge(sync.LscID);
                                                    lock (totalAlarms) { totalAlarms.RemoveAll(a => a.LscID == sync.LscID); }
                                                    break;
                                                case "TC":
                                                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("请求同步Lsc客户端标准化信息[Lsc:{0} - {1} User:{2} IP:{3}]", lsc.LscID, lsc.LscName, sync.RelValue2, sync.RelValue3));
                                                    SyncTCSetting(lsc);
                                                    break;
                                                default:
                                                    break;
                                            }

                                            if (lsc.Enabled) {
                                                if (!totalLscs.Any(l => l.LscID == lsc.LscID)) {
                                                    lock (totalLscs) { totalLscs.Add(lsc); }
                                                }
                                                if (!workerClients.Any(wc => wc.Lsc.LscID == lsc.LscID)) {
                                                    lock (workerClients) { workerClients.Add(new ClientObjectInfo(lsc)); }
                                                }
                                            }
                                        } else {
                                            WriteLog(DateTime.Now, EnmLogType.Info, "System", "未查询到Lsc信息，请求同步数据失败。");
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-02]{0}", err.Message));
                                    }
                                }
                                #endregion

                                var clientInfo = workerClients.Find(c => c.Lsc.LscID == group.Key);
                                if (clientInfo == null || clientInfo.LinkState != EnmLinkState.Authentication) { continue; }
                                foreach (var order in group) {
                                    switch (order.OrderType) {
                                        case EnmActType.RequestNode:
                                            rNodes.Add(order);
                                            break;
                                        case EnmActType.ConfirmAlarm:
                                            rConfirms.Add(order);
                                            break;
                                        case EnmActType.SetAoc:
                                            rAocs.Add(order);
                                            break;
                                        case EnmActType.SetDoc:
                                            rDocs.Add(order);
                                            break;
                                        case EnmActType.TrendConfirm:
                                            rTrendConfirm.Add(order);
                                            break;
                                        case EnmActType.TrendComplete:
                                            rTrendEnd.Add(order);
                                            break;
                                        case EnmActType.LoadConfirm:
                                            rLoadConfirm.Add(order);
                                            break;
                                        case EnmActType.LoadComplete:
                                            rLoadEnd.Add(order);
                                            break;
                                        case EnmActType.FrequencyConfirm:
                                            rFrequencyConfirm.Add(order);
                                            break;
                                        case EnmActType.FrequencyComplete:
                                            rFrequencyEnd.Add(order);
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                #region Requst Nodes
                                if (rNodes.Count > 0) {
                                    try {
                                        var nodes = new Dictionary<int, int>();
                                        foreach (var node in rNodes) {
                                            if (!nodes.ContainsKey(node.TargetID))
                                                nodes.Add(node.TargetID, (int)node.TargetType);
                                        }

                                        var sedPack = ComUtility.GetNodePack(0, 0, (byte)EnmAcceMode.Ask_Answer, 2, clientInfo.CurPackNo, nodes);
                                        if (sedPack != null) { clientInfo.Send(sedPack); }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-03]{0}", err.Message));
                                    } finally {
                                        rNodes.Clear();
                                    }
                                }
                                #endregion

                                #region Confirm Alarms
                                if (rConfirms.Count > 0) {
                                    try {
                                        var confirmsGroup = rConfirms.GroupBy(c => new { c.RelValue1, c.RelValue2 }).ToList();
                                        foreach (var confirmGroup in confirmsGroup) {
                                            var ids = confirmGroup.Select(c => c.TargetID).ToList();
                                            var dispatchNO = Convert.ToInt32(confirmGroup.Key.RelValue1);
                                            var userName = confirmGroup.Key.RelValue2;

                                            var sedPack = ComUtility.GetConfirmAlarmPack(ids, dispatchNO, userName, clientInfo.CurPackNo);
                                            if (sedPack != null) { clientInfo.Send(sedPack); }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-04]{0}", err.Message));
                                    } finally {
                                        rConfirms.Clear();
                                    }
                                }
                                #endregion

                                #region Set AO
                                if (rAocs.Count > 0) {
                                    try {
                                        foreach (var order in rAocs) {
                                            var setValue = Convert.ToSingle(order.RelValue1);
                                            var lscId = Convert.ToInt32(order.RelValue2);
                                            var userId = Convert.ToInt32(order.RelValue3);
                                            var userName = order.RelValue4;

                                            var sedPack = ComUtility.GetSetAOPack(order.TargetID, setValue, lscId, userId, userName, clientInfo.CurPackNo);
                                            if (sedPack != null) { clientInfo.Send(sedPack); }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-05]{0}", err.Message));
                                    } finally {
                                        rAocs.Clear();
                                    }
                                }
                                #endregion

                                #region Set DO
                                if (rDocs.Count > 0) {
                                    try {
                                        foreach (var order in rDocs) {
                                            if (clientInfo.LinkState == EnmLinkState.Authentication) {
                                                var setValue = Convert.ToByte(order.RelValue1);
                                                var lscId = Convert.ToInt32(order.RelValue2);
                                                var userId = Convert.ToInt32(order.RelValue3);
                                                var userName = order.RelValue4;

                                                var sedPack = ComUtility.GetSetDOPack(order.TargetID, setValue, lscId, userId, userName, clientInfo.CurPackNo);
                                                if (sedPack != null) { clientInfo.Send(sedPack); }
                                            }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-06]{0}", err.Message));
                                    } finally {
                                        rDocs.Clear();
                                    }
                                }
                                #endregion

                                #region Trend Confirm Alarms
                                if (rTrendConfirm.Count > 0) {
                                    try {
                                        var confirmsGroup = rTrendConfirm.GroupBy(c => new { c.RelValue1 }).ToList();
                                        foreach (var confirmGroup in confirmsGroup) {
                                            var ids = confirmGroup.Select(c => c.TargetID).ToList();
                                            var userName = confirmGroup.Key.RelValue1;

                                            var sedPack = ComUtility.GetConfirmTrendAlarmPack(clientInfo.CurPackNo, ids, userName);
                                            if (sedPack != null) { clientInfo.Send(sedPack); }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-07]{0}", err.Message));
                                    } finally {
                                        rTrendConfirm.Clear();
                                    }
                                }
                                #endregion

                                #region Trend End Alarms
                                if (rTrendEnd.Count > 0) {
                                    try {
                                        var confirmsGroup = rTrendEnd.GroupBy(c => new { c.RelValue1 }).ToList();
                                        foreach (var confirmGroup in confirmsGroup) {
                                            var ids = confirmGroup.Select(c => c.TargetID).ToList();
                                            var userName = confirmGroup.Key.RelValue1;

                                            var sedPack = ComUtility.GetEndTrendAlarmPack(clientInfo.CurPackNo, ids, userName);
                                            if (sedPack != null) { clientInfo.Send(sedPack); }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-08]{0}", err.Message));
                                    } finally {
                                        rTrendEnd.Clear();
                                    }
                                }
                                #endregion

                                #region Load Confirm Alarms
                                if (rLoadConfirm.Count > 0) {
                                    try {
                                        var confirmsGroup = rLoadConfirm.GroupBy(c => new { c.RelValue1 }).ToList();
                                        foreach (var confirmGroup in confirmsGroup) {
                                            var ids = confirmGroup.Select(c => c.TargetID).ToList();
                                            var userName = confirmGroup.Key.RelValue1;

                                            var sedPack = ComUtility.GetConfirmLoadAlarmPack(clientInfo.CurPackNo, ids, userName);
                                            if (sedPack != null) { clientInfo.Send(sedPack); }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-09]{0}", err.Message));
                                    } finally {
                                        rLoadConfirm.Clear();
                                    }
                                }
                                #endregion

                                #region Load End Alarms
                                if (rLoadEnd.Count > 0) {
                                    try {
                                        var confirmsGroup = rLoadEnd.GroupBy(c => new { c.RelValue1 }).ToList();
                                        foreach (var confirmGroup in confirmsGroup) {
                                            var ids = confirmGroup.Select(c => c.TargetID).ToList();
                                            var userName = confirmGroup.Key.RelValue1;

                                            var sedPack = ComUtility.GetEndLoadAlarmPack(clientInfo.CurPackNo, ids, userName);
                                            if (sedPack != null) { clientInfo.Send(sedPack); }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-10]{0}", err.Message));
                                    } finally {
                                        rLoadEnd.Clear();
                                    }
                                }
                                #endregion

                                #region Frequency Confirm Alarms
                                if (rFrequencyConfirm.Count > 0) {
                                    try {
                                        var confirmsGroup = rFrequencyConfirm.GroupBy(c => new { c.RelValue1 }).ToList();
                                        foreach (var confirmGroup in confirmsGroup) {
                                            var ids = confirmGroup.Select(c => c.TargetID).ToList();
                                            var userName = confirmGroup.Key.RelValue1;

                                            var sedPack = ComUtility.GetConfirmFrequencyAlarmPack(clientInfo.CurPackNo, ids, userName);
                                            if (sedPack != null) { clientInfo.Send(sedPack); }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-11]{0}", err.Message));
                                    } finally {
                                        rFrequencyConfirm.Clear();
                                    }
                                }
                                #endregion

                                #region Frequency End Alarms
                                if (rFrequencyEnd.Count > 0) {
                                    try {
                                        var confirmsGroup = rFrequencyEnd.GroupBy(c => new { c.RelValue1 }).ToList();
                                        foreach (var confirmGroup in confirmsGroup) {
                                            var ids = confirmGroup.Select(c => c.TargetID).ToList();
                                            var userName = confirmGroup.Key.RelValue1;

                                            var sedPack = ComUtility.GetEndFrequencyAlarmPack(clientInfo.CurPackNo, ids, userName);
                                            if (sedPack != null) { clientInfo.Send(sedPack); }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-10]{0}", err.Message));
                                    } finally {
                                        rFrequencyEnd.Clear();
                                    }
                                }
                                #endregion
                            }

                            orderEntity.DeleteOrders(orders);
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoOrder-07]{0}", err.Message));
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do CSC Modify
        /// </summary>
        private void DoCSCModify() {
            allDone.WaitOne();
            if (SyncModifyInterval <= 0) { return; }

            var modifyEntity = new BCSCModify();
            var modifyCnt = -1L;
            while (runState < EnmRunState.Stop) {
                if (runState == EnmRunState.Run) {
                    try {
                        if (modifyCnt == -1 || modifyCnt >= SyncModifyInterval) {
                            modifyCnt = 0;
                            lock (totalLscs) {
                                foreach (var lsc in totalLscs) {
                                    var connectionString = ComUtility.CreateLscConnectionString(lsc);
                                    try {
                                        var modifies = modifyEntity.GetCSCModifies(lsc.LscID, lsc.MaxNodeModify == null ? 0 : lsc.MaxNodeModify.ID, connectionString);
                                        if (modifies != null && modifies.Count > 0) {
                                            foreach (var modify in modifies) {
                                                #region Sync data by modify
                                                switch (modify.NodeType) {
                                                    case EnmNodeType.Area:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddArea(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加区域节点[LscID:{1} AreaID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelArea(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除区域节点[LscID:{1} AreaID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateArea(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新区域节点[LscID:{1} AreaID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.Sta:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddSta(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加局站节点[LscID:{1} StaID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelSta(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除局站节点[LscID:{1} StaID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateSta(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新局站节点[LscID:{1} StaID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.Dev:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddInNodes:
                                                                modifyEntity.AddDevWithNodes(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加设备节点[LscID:{1} DevID:{2}],并同步添加该设备下所有测点", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddDev(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加设备节点[LscID:{1} DevID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelDev(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除设备节点[LscID:{1} DevID:{2}],并同步删除该设备下所有测点", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyInNodes:
                                                                modifyEntity.UpdateDevWithNodes(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新设备节点[LscID:{1} DevID:{2}],并同步更新该设备下所有测点", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateDev(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新设备节点[LscID:{1} DevID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        SyncDevices(lsc.LscID, modify.NodeID);
                                                        break;
                                                    case EnmNodeType.Dic:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddDI(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加DI节点[LscID:{1} DIID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelDI(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除DI节点[LscID:{1} DIID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateDI(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新DI节点[LscID:{1} DIID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.Aic:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddAI(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加AI节点[LscID:{1} AIID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelAI(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除AI节点[LscID:{1} AIID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateAI(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新AI节点[LscID:{1} AIID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.Doc:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddDO(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加DO节点[LscID:{1} DOID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelDO(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除DO节点[LscID:{1} DOID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateDO(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新DO节点[LscID:{1} DOID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.Aoc:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddAO(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加AO节点[LscID:{1} AOID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelAO(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除AO节点[LscID:{1} AOID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateAO(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新AO节点[LscID:{1} AOID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.Sic:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddSIC(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加SIC节点[LscID:{1} SICID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelSIC(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除SIC节点[LscID:{1} SICID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateSIC(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新SIC节点[LscID:{1} SICID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.SS:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddSS(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加SS节点[LscID:{1} SSID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelSS(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除SS节点[LscID:{1} SSID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateSS(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新SS节点[LscID:{1} SSID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.RS:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddRS(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新RS节点[LscID:{1} RSID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelRS(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新RS节点[LscID:{1} RSID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateRS(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新RS节点[LscID:{1} RSID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.RTU:
                                                        switch (modify.ModifyType) {
                                                            case EnmModifyType.AddInNodes:
                                                                modifyEntity.AddRTUWithNodes(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加RTU节点[LscID:{1} RTUID:{2}],并同步添加该RTU下所有测点", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddRTU(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加RTU节点[LscID:{1} RTUID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelRTU(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除RTU节点[LscID:{1} RTUID:{2}],并同步删除该RTU下所有测点", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyInNodes:
                                                                modifyEntity.UpdateRTUWithNodes(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新RTU节点[LscID:{1} RTUID:{2}],并同步更新该RTU下所有测点", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateRTU(lsc.LscID, modify.NodeID, connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新RTU节点[LscID:{1} RTUID:{2}]", lsc.LscName, lsc.LscID, modify.NodeID));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmNodeType.Null:
                                                    case EnmNodeType.LSC:
                                                    case EnmNodeType.Str:
                                                    case EnmNodeType.Img:
                                                    default:
                                                        break;
                                                }
                                                #endregion

                                                if (lsc.MaxNodeModify == null || lsc.MaxNodeModify.ID < modify.ID)
                                                    lsc.MaxNodeModify = modify;
                                            }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoCSCModify-01]{0}", err.Message));
                                    }

                                    try {
                                        var logs = modifyEntity.GetChangeLogs(lsc.LscID, lsc.MaxChangeLog == null ? 0 : lsc.MaxChangeLog.LogID, connectionString);
                                        if (logs != null && logs.Count > 0) {
                                            foreach (var log in logs) {
                                                #region Sync data by change logs.
                                                switch (log.TableID) {
                                                    case EnmTableID.TU_User:
                                                        if (!ComUtility.IsNumeric(log.OpDesc))
                                                            break;

                                                        switch (log.OpType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddUser(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加用户[LscID:{1} UserID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelUser(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除用户[LscID:{1} UserID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateUser(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新用户[LscID:{1} UserID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmTableID.TU_Group:
                                                        if (!ComUtility.IsNumeric(log.OpDesc))
                                                            break;

                                                        switch (log.OpType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddGroup(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加群组[LscID:{1} GroupID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelGroup(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除群组[LscID:{1} GroupID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateGroup(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新群组[LscID:{1} GroupID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmTableID.TU_GroupTree:
                                                        if (!ComUtility.IsNumeric(log.OpDesc))
                                                            break;

                                                        switch (log.OpType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddGroupTree(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加群组树[LscID:{1} GroupID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelGroupTree(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除群组树[LscID:{1} GroupID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateGroupTree(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新群组树[LscID:{1} GroupID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmTableID.TU_UDGroup:
                                                        var udgIds = log.OpDesc.Split(new char[] { ';' });
                                                        if (udgIds.Length != 2)
                                                            break;

                                                        if (!ComUtility.IsNumeric(udgIds[0]) || !ComUtility.IsNumeric(udgIds[1]))
                                                            break;

                                                        switch (log.OpType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddUDGroupTree(lsc.LscID, Convert.ToInt32(udgIds[0]), Convert.ToInt32(udgIds[1]), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加自定义群组[LscID:{1} UserID:{2} GroupID:{3}]", lsc.LscName, lsc.LscID, udgIds[0], udgIds[1]));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelUDGroupTree(lsc.LscID, Convert.ToInt32(udgIds[0]), Convert.ToInt32(udgIds[1]), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除自定义群组[LscID:{1} UserID:{2} GroupID:{3}]", lsc.LscName, lsc.LscID, udgIds[0], udgIds[1]));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateUDGroupTree(lsc.LscID, Convert.ToInt32(udgIds[0]), Convert.ToInt32(udgIds[1]), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新自定义群组[LscID:{1} UserID:{2} GroupID:{3}]", lsc.LscName, lsc.LscID, udgIds[0], udgIds[1]));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmTableID.TU_UDGroupTree:
                                                        string[] udgNodesIds = log.OpDesc.Split(new char[] { ';' });
                                                        if (udgNodesIds.Length != 2)
                                                            break;

                                                        if (!ComUtility.IsNumeric(udgNodesIds[0]) || !ComUtility.IsNumeric(udgNodesIds[1]))
                                                            break;

                                                        switch (log.OpType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddUDGroupTree(lsc.LscID, Convert.ToInt32(udgNodesIds[0]), Convert.ToInt32(udgNodesIds[1]), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加自定义群组树[LscID:{1} UserID:{2} GroupID:{3}]", lsc.LscName, lsc.LscID, udgNodesIds[0], udgNodesIds[1]));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelUDGroupTree(lsc.LscID, Convert.ToInt32(udgNodesIds[0]), Convert.ToInt32(udgNodesIds[1]), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除自定义群组树[LscID:{1} UserID:{2} GroupID:{3}]", lsc.LscName, lsc.LscID, udgNodesIds[0], udgNodesIds[1]));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateUDGroupTree(lsc.LscID, Convert.ToInt32(udgNodesIds[0]), Convert.ToInt32(udgNodesIds[1]), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新自定义群组树[LscID:{1} UserID:{2} GroupID:{3}]", lsc.LscName, lsc.LscID, udgNodesIds[0], udgNodesIds[1]));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmTableID.TM_Building:
                                                        if (!ComUtility.IsNumeric(log.OpDesc))
                                                            break;

                                                        switch (log.OpType) {
                                                            case EnmModifyType.AddNoNodes:
                                                                modifyEntity.AddBuilding(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}添加机楼[LscID:{1} BuildingID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            case EnmModifyType.Delete:
                                                                modifyEntity.DelBuilding(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}删除机楼[LscID:{1} BuildingID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            case EnmModifyType.ModifyNoNodes:
                                                                modifyEntity.UpdateBuilding(lsc.LscID, Convert.ToInt32(log.OpDesc), connectionString);
                                                                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("{0}更新机楼[LscID:{1} BuildingID:{2}]", lsc.LscName, lsc.LscID, log.OpDesc));
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case EnmTableID.TM_ProjBooking:
                                                    case EnmTableID.Null:
                                                    default:
                                                        break;
                                                }
                                                #endregion

                                                if (lsc.MaxChangeLog == null || lsc.MaxChangeLog.LogID < log.LogID)
                                                    lsc.MaxChangeLog = log;
                                            }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoCSCModify-02]{0}", err.Message));
                                    }
                                }
                            }
                        }
                    } catch (Exception err) {
                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoCSCModify-03]{0}", err.Message));
                    }

                    modifyCnt++;
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Sync Time
        /// </summary>
        private void DoSyncTime() {
            allDone.WaitOne();
            if (SyncTimeInterval <= 0) { return; }

            var timeCnt = -1L;
            while (runState < EnmRunState.Stop) {
                if (runState == EnmRunState.Run) {
                    try {
                        if (timeCnt == -1 || timeCnt >= SyncTimeInterval) {
                            timeCnt = 0;
                            lock (workerClients) {
                                foreach (var clientInfo in workerClients) {
                                    try {
                                        if (clientInfo == null || clientInfo.LinkState != EnmLinkState.Authentication)
                                            continue;

                                        var sedPack = ComUtility.GetServerDateTimePack(clientInfo.CurPackNo, DateTime.Now);
                                        if (sedPack != null) { clientInfo.Send(sedPack); }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoSyncTime-01]{0}", err.Message));
                                    }
                                }
                            }
                        }
                    } catch (Exception err) {
                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoSyncTime-02]{0}", err.Message));
                    }

                    timeCnt++;
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Task
        /// </summary>
        private void DoTask() {
            allDone.WaitOne();
            var orderEntity = new BOrder();
            var cscModifyEntity = new BCSCModify();
            var mcode = String.Empty;
            var mcodeCnt = -1L;
            var paramCnt = -1L;

            while (runState < EnmRunState.Stop) {
                if (runState == EnmRunState.Run) {
                    #region DoMachineCode
                    /*
                    try {
                        if (SyncMachineCodeInterval > 0 && (mcodeCnt == -1 || mcodeCnt >= SyncMachineCodeInterval)) {
                            mcodeCnt = 0;
                            if (String.IsNullOrEmpty(mcode)) { mcode = ComUtility.GetMachineCode(); }
                            if (!ComUtility.DefaultKeys.Equals(mcode)) {
                                var license = orderEntity.GetSysParams(20000001);
                                if (license == null || license.Count == 0) {
                                    orderEntity.SaveSysParams(new List<SysParamInfo>() { 
                                        new SysParamInfo() {
                                            ID = 3,
                                            ParaCode = 20000001,
                                            ParaData = 0,
                                            ParaDisplay = mcode,
                                            Note = ComUtility.CreateTempCode(mcode, StartupDateTime)
                                        }
                                    });
                                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("生成机器标识码[{0}]", mcode));
                                } else if (license.Count > 1) {
                                    license[0].ParaDisplay = mcode;
                                    if (license[0].Note == null || license[0].Note.Trim() == String.Empty) {
                                        license[0].Note = ComUtility.CreateTempCode(mcode, StartupDateTime);
                                    }

                                    orderEntity.DeleteSysParams(20000001);
                                    orderEntity.SaveSysParams(new List<SysParamInfo>() { license[0] });
                                } else if (!mcode.Equals(license[0].ParaDisplay)) {
                                    var ocode = license[0].ParaDisplay;
                                    license[0].ParaDisplay = mcode;
                                    if (license[0].Note == null || license[0].Note.Trim() == String.Empty) {
                                        license[0].Note = ComUtility.CreateTempCode(mcode, StartupDateTime);
                                    }

                                    orderEntity.SaveSysParams(new List<SysParamInfo>() { license[0] });
                                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("更新机器标识码[{0}]=>[{1}]", ocode, mcode));
                                } else if (license[0].Note == null || license[0].Note.Trim() == String.Empty) {
                                    license[0].Note = ComUtility.CreateTempCode(mcode, StartupDateTime);
                                    orderEntity.SaveSysParams(new List<SysParamInfo>() { license[0] });
                                }
                            } else {
                                WriteLog(DateTime.Now, EnmLogType.Error, "System", "生成机器标识码时发生错误，稍后将重试。");
                            }
                        }
                    } catch (Exception err) {
                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoTask-01]{0}", err.Message));
                    }
                     * */
                    #endregion

                    #region DoSyncLscParam
                    try {
                        if (SyncLscParamInterval > 0 && (paramCnt == -1 || paramCnt >= SyncLscParamInterval)) {
                            paramCnt = 0;
                            var parms = new List<LscParamInfo>();
                            lock (totalLscs) {
                                foreach (var lsc in totalLscs) {
                                    try {
                                        var connectionString = ComUtility.CreateLscConnectionString(lsc);
                                        var parm = cscModifyEntity.GetLscParam(lsc.LscID, connectionString);
                                        if (parm != null) { parms.Add(parm); }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoTask-02]{0}", err.Message));
                                    }
                                }
                            }

                            if (parms.Count > 0) {
                                cscModifyEntity.UpdateLscParam(parms);
                            }
                        }
                    } catch (Exception err) {
                        WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[DoTask-03]{0}", err.Message));
                    }
                    #endregion

                    if (SyncMachineCodeInterval > 0) mcodeCnt++;
                    if (SyncLscParamInterval > 0) paramCnt++;
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Delete Lsc
        /// </summary>
        /// <param name="lscId">lscId</param>
        private void DeleteLsc(Int32 lscId) {
            WriteLog(DateTime.Now, EnmLogType.Info, "System", "正在删除Lsc客户端...");
            lock (workerClients) {
                var clientInfo = workerClients.Find(wc => wc.Lsc.LscID == lscId);
                if (clientInfo != null) {
                    if (clientInfo.LinkState == EnmLinkState.Connected) {
                        TcpClose(clientInfo);
                    }

                    if (clientInfo.LinkState == EnmLinkState.Authentication) {
                        TcpLogout(clientInfo);
                    }

                    workerClients.Remove(clientInfo);
                }
            }
            lock (settingQueue) {
                var temp = new Queue<PackageInfo>();
                while (settingQueue.Count > 0) {
                    var pack = settingQueue.Dequeue();
                    if (pack.LscID != lscId) { temp.Enqueue(pack); }
                }
                while (temp.Count > 0) {
                    settingQueue.Enqueue(temp.Dequeue());
                }
            }
            lock (alarmQueue) {
                var temp = new Queue<PackageInfo>();
                while (alarmQueue.Count > 0) {
                    var pack = alarmQueue.Dequeue();
                    if (pack.LscID != lscId) { temp.Enqueue(pack); }
                }
                while (temp.Count > 0) {
                    alarmQueue.Enqueue(temp.Dequeue());
                }
            }
            lock (nodeQueue) {
                var temp = new Queue<PackageInfo>();
                while (nodeQueue.Count > 0) {
                    var pack = nodeQueue.Dequeue();
                    if (pack.LscID != lscId) { temp.Enqueue(pack); }
                }
                while (temp.Count > 0) {
                    nodeQueue.Enqueue(temp.Dequeue());
                }
            }
            lock (totalLscs) { totalLscs.RemoveAll(l => l.LscID == lscId); }
            lock (totalAlarms) { totalAlarms.RemoveAll(a => a.LscID == lscId); }
            lock (totalDevices) {
                var keys = new List<String>(totalDevices.Keys);
                foreach (var key in keys) {
                    if (key.StartsWith(String.Format("{0}-", lscId))
                        && totalDevices.ContainsKey(key)) {
                        totalDevices.Remove(key);
                    }
                }
            }

            new BAlarm().Purge(lscId);
            new BNode().Purge(lscId);
            var settingEntity = new BSetting();
            settingEntity.DeleteArea(lscId);
            settingEntity.DeleteSta(lscId);
            settingEntity.DeleteDev(lscId);
            settingEntity.DeleteAI(lscId);
            settingEntity.DeleteAO(lscId);
            settingEntity.DeleteDI(lscId);
            settingEntity.DeleteDO(lscId);
            settingEntity.DeleteGroup(lscId);
            settingEntity.DeleteGroupTree(lscId);
            settingEntity.DeleteUDGroup(lscId);
            settingEntity.DeleteUDGroupTree(lscId);
            settingEntity.DeleteUser(lscId);
            settingEntity.DeleteSS(lscId);
            settingEntity.DeleteRS(lscId);
            settingEntity.DeleteRTU(lscId);
            settingEntity.DeleteSIC(lscId);
            settingEntity.DeleteSubSic(lscId);
            settingEntity.DeleteSubDevCap(lscId);
            WriteLog(DateTime.Now, EnmLogType.Info, "System", "Lsc客户端删除完成");
        }

        /// <summary>
        /// Sync Setting
        /// </summary>
        /// <param name="lsc">lsc</param>
        private void SyncSetting(LscInfo lsc) {
            WriteLog(DateTime.Now, EnmLogType.Info, "System", "正在同步Lsc客户端配置...");
            var settingEntity = new BSetting();
            var modifyEntity = new BCSCModify();
            var nodeEntity = new BNode();

            settingEntity.DeleteArea(lsc.LscID);
            settingEntity.DeleteBuilding(lsc.LscID);
            settingEntity.DeleteSta(lsc.LscID);
            settingEntity.DeleteDev(lsc.LscID);
            settingEntity.DeleteAI(lsc.LscID);
            settingEntity.DeleteAO(lsc.LscID);
            settingEntity.DeleteDI(lsc.LscID);
            settingEntity.DeleteDO(lsc.LscID);
            settingEntity.DeleteGroup(lsc.LscID);
            settingEntity.DeleteGroupTree(lsc.LscID);
            settingEntity.DeleteUDGroup(lsc.LscID);
            settingEntity.DeleteUDGroupTree(lsc.LscID);
            settingEntity.DeleteUser(lsc.LscID);
            settingEntity.DeleteSS(lsc.LscID);
            settingEntity.DeleteRS(lsc.LscID);
            settingEntity.DeleteRTU(lsc.LscID);
            settingEntity.DeleteSIC(lsc.LscID);
            settingEntity.DeleteSubSic(lsc.LscID);
            settingEntity.DeleteSubDevCap(lsc.LscID);
            nodeEntity.Purge(lsc.LscID);

            var connectionString = ComUtility.CreateLscConnectionString(lsc);
            settingEntity.SyncArea(lsc.LscID, connectionString);
            settingEntity.SyncBuilding(lsc.LscID, connectionString);
            settingEntity.SyncSta(lsc.LscID, connectionString);
            settingEntity.SyncDev(lsc.LscID, connectionString);
            settingEntity.SyncAI(lsc.LscID, connectionString);
            settingEntity.SyncAO(lsc.LscID, connectionString);
            settingEntity.SyncDI(lsc.LscID, connectionString);
            settingEntity.SyncDO(lsc.LscID, connectionString);
            settingEntity.SyncGroup(lsc.LscID, connectionString);
            settingEntity.SyncGroupTree(lsc.LscID, connectionString);
            settingEntity.SyncUDGroup(lsc.LscID, connectionString);
            settingEntity.SyncUDGroupTree(lsc.LscID, connectionString);
            settingEntity.SyncUser(lsc.LscID, connectionString);
            settingEntity.SyncSS(lsc.LscID, connectionString);
            settingEntity.SyncRS(lsc.LscID, connectionString);
            settingEntity.SyncRTU(lsc.LscID, connectionString);
            settingEntity.SyncSIC(lsc.LscID, connectionString);
            settingEntity.SyncSubSic(lsc.LscID, connectionString);
            settingEntity.SyncSubDevCap(lsc.LscID, connectionString);

            lsc.MaxNodeModify = modifyEntity.GetMaxCSCModify(lsc.LscID, connectionString);
            lsc.MaxChangeLog = modifyEntity.GetMaxChangeLog(lsc.LscID, connectionString);
            nodeEntity.SynNodes(lsc.LscID);
            SyncDevices(lsc.LscID, ComUtility.DefaultInt32);
            WriteLog(DateTime.Now, EnmLogType.Info, "System", "Lsc客户端配置同步完成");
        }

        /// <summary>
        /// Sync TC_Table Setting
        /// </summary>
        /// <param name="lsc">lsc</param>
        private void SyncTCSetting(LscInfo lsc) {
            WriteLog(DateTime.Now, EnmLogType.Info, "System", "正在同步Lsc客户端标准化信息...");
            var settingEntity = new BSetting();
            settingEntity.PurgeAlarmDeviceType();
            settingEntity.PurgeAlarmLogType();
            settingEntity.PurgeAlarmName();
            settingEntity.PurgeDeviceType();
            settingEntity.PurgeProductor();
            settingEntity.PurgeProtocol();
            settingEntity.PurgeStaFeatures();
            settingEntity.PurgeStationType();
            settingEntity.PurgeSubAlarmLogType();

            var connectionString = ComUtility.CreateLscConnectionString(lsc);
            settingEntity.SyncAlarmDeviceType(lsc.LscID, connectionString);
            settingEntity.SyncAlarmLogType(lsc.LscID, connectionString);
            settingEntity.SyncAlarmName(lsc.LscID, connectionString);
            settingEntity.SyncDeviceType(lsc.LscID, connectionString);
            settingEntity.SyncProductor(lsc.LscID, connectionString);
            settingEntity.SyncProtocol(lsc.LscID, connectionString);
            settingEntity.SyncStaFeatures(lsc.LscID, connectionString);
            settingEntity.SyncStationType(lsc.LscID, connectionString);
            settingEntity.SyncSubAlarmLogType(lsc.LscID, connectionString);
            WriteLog(DateTime.Now, EnmLogType.Info, "System", "Lsc客户端标准化信息同步完成");
        }

        /// <summary>
        /// Sync Alarms
        /// </summary>
        /// <param name="clientInfo">clientInfo</param>
        private void SyncAlarms(ClientObjectInfo clientInfo) {
            try {
                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("开始同步实时告警信息[{0}:{1}]...", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                var sedPack = ComUtility.GetSyncAlarmPack(clientInfo.CurPackNo);
                if (sedPack != null) { clientInfo.Send(sedPack); }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[SyncAlarms]{0}", err.Message));
                WriteLog(DateTime.Now, EnmLogType.Error, "System", "同步实时告警信息失败");
            }
        }

        /// <summary>
        /// Sync Devices
        /// </summary>
        /// <param name="lscId">lscId</param>
        /// <param name="devId">devId</param>
        private void SyncDevices(Int32 lscId, Int32 devId) {
            try {
                lock (totalDevices) {
                    if (devId == ComUtility.DefaultInt32) {
                        var keys = new List<String>(totalDevices.Keys);
                        foreach (var key in keys) {
                            if (key.StartsWith(String.Format("{0}-", lscId))
                                && totalDevices.ContainsKey(key)) {
                                totalDevices.Remove(key);
                            }
                        }
                    } else {
                        var key = String.Format("{0}-{1}", lscId, devId);
                        if (totalDevices.ContainsKey(key)) {
                            totalDevices.Remove(key);
                        }
                    }

                    var devices = new BCommon().GetDevices(lscId, devId);
                    foreach (var dev in devices) {
                        totalDevices[String.Format("{0}-{1}", dev.LscID, dev.DevID)] = dev;
                    }
                }
            } catch (Exception err) {
                WriteRealTimeLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[SyncDevices]{0}", err.Message));
            }
        }

        /// <summary>
        /// Restart Service
        /// </summary>
        private void Restart() {
            WriteLog(DateTime.Now, EnmLogType.Info, "System", "正在重启服务...");
            this.OnStop();
            Environment.Exit(-1);
        }

        /// <summary>
        /// Tcp Login
        /// </summary>
        /// <param name="clientInfo">clientInfo</param>
        private void TcpLogin(ClientObjectInfo clientInfo) {
            try {
                if (clientInfo.LinkState == EnmLinkState.Connected) {
                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("Lsc客户端用户验证中[{0}:{1}]...", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                    var sedPack = ComUtility.GetLoginPack(clientInfo.Lsc.LscUID, clientInfo.Lsc.LscPwd, clientInfo.CurPackNo);
                    if (sedPack != null) {
                        clientInfo.Send(sedPack, TcpLoginSendAck);
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[TcpLogin]{0}", err.Message));
                TcpClose(clientInfo);
            }
        }

        /// <summary>
        /// Tcp Login Send Ack
        /// </summary>
        /// <param name="iar">IAsyncResult</param>
        private void TcpLoginSendAck(IAsyncResult iar) {
            try {
                var clientInfo = (ClientObjectInfo)iar.AsyncState;
                if (clientInfo != null && clientInfo.NetStream != null) {
                    clientInfo.NetStream.EndWrite(iar);
                    if (clientInfo.LinkState == EnmLinkState.Connected) {
                        clientInfo.Read(TcpLoginAck);
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[TcpLoginSendAck]{0}", err.Message));
            }
        }

        /// <summary>
        /// Tcp Login Ack
        /// </summary>
        /// <param name="iar">IAsyncResult</param>
        private void TcpLoginAck(IAsyncResult iar) {
            try {
                var clientInfo = (ClientObjectInfo)iar.AsyncState;
                if (clientInfo != null && clientInfo.NetStream != null) {
                    byte[] revPack = null;
                    var revLen = clientInfo.NetStream.EndRead(iar);
                    if (ComUtility.CheckSinglePackage(clientInfo.ReadBuffer, revLen)) {
                        revPack = new byte[revLen];
                        Buffer.BlockCopy(clientInfo.ReadBuffer, 0, revPack, 0, revLen);
                    } else {
                        for (var i = 0; i < revLen; i++) {
                            clientInfo.BytesBuffer.Add(clientInfo.ReadBuffer[i]);
                        }

                        revPack = clientInfo.GetReceivePack();
                    }

                    if (revPack != null) {
                        var packType = BitConverter.ToInt32(revPack, 12);
                        var enmPackType = Enum.IsDefined(typeof(EnmMsgType), packType) ? (EnmMsgType)packType : EnmMsgType.Pack;
                        if (enmPackType == EnmMsgType.packLoginAck && revPack.Length == 22) {
                            switch (BitConverter.ToInt32(revPack, 16)) {
                                case (int)EnmRightMode.Level1:
                                case (int)EnmRightMode.Level2:
                                case (int)EnmRightMode.Level3:
                                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("Lsc客户端用户验证成功[{0}:{1}]", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                                    clientInfo.Lsc.Connected = true;
                                    clientInfo.Lsc.ChangeTime = DateTime.Now;
                                    UpdateLscAttributes(clientInfo.Lsc);

                                    clientInfo.LinkState = EnmLinkState.Authentication;
                                    clientInfo.LoginCnt = 0;
                                    clientInfo.Read(RevPackAck);
                                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("开始处理Lsc客户端数据包[{0}:{1}]", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                                    break;
                                case (int)EnmRightMode.Invalid:
                                default:
                                    break;
                            }
                        }
                    }
                }

                if (clientInfo.LinkState != EnmLinkState.Authentication) {
                    clientInfo.LinkState = EnmLinkState.Disconnect;
                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("Lsc客户端用户验证失败[{0}:{1}]", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[TcpLoginAck]{0}", err.Message));
            }
        }

        /// <summary>
        /// Reveice Packages ack
        /// </summary>
        /// <param name="iar">IAsyncResult</param>
        private void RevPackAck(IAsyncResult iar) {
            try {
                var clientInfo = (ClientObjectInfo)iar.AsyncState;
                if (clientInfo != null && clientInfo.NetStream != null) {
                    byte[] revPack = null;
                    var revLen = clientInfo.NetStream.EndRead(iar);
                    if (ComUtility.CheckSinglePackage(clientInfo.ReadBuffer, revLen)) {
                        revPack = new byte[revLen];
                        Buffer.BlockCopy(clientInfo.ReadBuffer, 0, revPack, 0, revLen);
                    } else {
                        for (var i = 0; i < revLen; i++) {
                            clientInfo.BytesBuffer.Add(clientInfo.ReadBuffer[i]);
                        }

                        revPack = clientInfo.GetReceivePack();
                    }

                    if (revPack != null) {
                        var serialsNO = BitConverter.ToInt32(revPack, 8);
                        var packType = BitConverter.ToInt32(revPack, 12);
                        var enmPackType = Enum.IsDefined(typeof(EnmMsgType), packType) ? (EnmMsgType)packType : EnmMsgType.Pack;
                        switch (enmPackType) {
                            case EnmMsgType.packSetAcceModeAck2:
                                if (runState == EnmRunState.Run) {
                                    lock (nodeQueue) {
                                        var revQueue = new PackageInfo();
                                        revQueue.LscID = clientInfo.Lsc.LscID;
                                        revQueue.Bytes = revPack;
                                        nodeQueue.Enqueue(revQueue);
                                    }
                                }
                                break;
                            case EnmMsgType.packSendAlarm:
                                if (runState == EnmRunState.Run) {
                                    lock (alarmQueue) {
                                        var revQueue = new PackageInfo();
                                        revQueue.LscID = clientInfo.Lsc.LscID;
                                        revQueue.Bytes = revPack;
                                        alarmQueue.Enqueue(revQueue);
                                    }
                                }
                                break;
                            case EnmMsgType.packSendTrendAlarm:
                                if (runState == EnmRunState.Run) {
                                    lock (trendQueue) {
                                        var revQueue = new PackageInfo();
                                        revQueue.LscID = clientInfo.Lsc.LscID;
                                        revQueue.Bytes = revPack;
                                        trendQueue.Enqueue(revQueue);
                                    }
                                }
                                break;
                            case EnmMsgType.packSendLoadAlarm:
                                if (runState == EnmRunState.Run) {
                                    lock (loadQueue) {
                                        var revQueue = new PackageInfo();
                                        revQueue.LscID = clientInfo.Lsc.LscID;
                                        revQueue.Bytes = revPack;
                                        loadQueue.Enqueue(revQueue);
                                    }
                                }
                                break;
                            case EnmMsgType.packSendFrequencyAlarm:
                                if (runState == EnmRunState.Run) {
                                    lock (frequencyQueue) {
                                        var revQueue = new PackageInfo();
                                        revQueue.LscID = clientInfo.Lsc.LscID;
                                        revQueue.Bytes = revPack;
                                        frequencyQueue.Enqueue(revQueue);
                                    }
                                }
                                break;
                            case EnmMsgType.packSetPointAck:
                                if (runState == EnmRunState.Run) {
                                    lock (settingQueue) {
                                        var revQueue = new PackageInfo();
                                        revQueue.LscID = clientInfo.Lsc.LscID;
                                        revQueue.Bytes = revPack;
                                        settingQueue.Enqueue(revQueue);
                                    }
                                }
                                break;
                            case EnmMsgType.packHeartbeat:
                                HeartBeatAck(revPack, clientInfo);
                                break;
                            case EnmMsgType.packHeartbeatAck:
                                clientInfo.HeartBeatCnt = 0;
                                break;
                            case EnmMsgType.packLogoutAck:
                                TcpLogoutAck(revPack, clientInfo);
                                break;
                            default:
                                break;
                        }
                    }

                    if (clientInfo.LinkState == EnmLinkState.Authentication) {
                        clientInfo.Read(RevPackAck);
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[RevPackAck]{0}", err.Message));
            }
        }

        /// <summary>
        /// HeartBeat
        /// </summary>
        private void HeartBeat() {
            allDone.WaitOne();

            while (runState < EnmRunState.Stop) {
                try {
                    lock (workerClients) {
                        foreach (var clientInfo in workerClients) {
                            try {
                                if (clientInfo.LinkState == EnmLinkState.Disconnect) {
                                    if (clientInfo.ConnectCnt++ % 5 == 0) {
                                        clientInfo.Connect();
                                        WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("Lsc客户端TCP连接已建立[{0}:{1}]", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                                    }
                                }

                                if (clientInfo.LinkState == EnmLinkState.Connected) {
                                    if (clientInfo.LoginCnt++ % 5 == 0) {
                                        TcpLogin(clientInfo);
                                    }
                                }

                                if (clientInfo.LinkState == EnmLinkState.Authentication) {
                                    clientInfo.HeartBeatCnt++;
                                    if (clientInfo.HeartBeatCnt % clientInfo.Lsc.BeatInterval == 0) {
                                        var sedPack = ComUtility.GetHeartBeatPack(clientInfo.CurPackNo);
                                        if (sedPack != null) { clientInfo.Send(sedPack); }
                                    } else if (clientInfo.HeartBeatCnt >= clientInfo.Lsc.BeatInterval + clientInfo.Lsc.BeatDelay) {
                                        TcpClose(clientInfo);
                                    }
                                }
                            } catch (Exception err) {
                                WriteLog(DateTime.Now, EnmLogType.Error, "System", err.Message);
                            }
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[HeartBeat]{0}", err.Message));
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// HeartBeatAck
        /// </summary>
        /// <param name="revPack">revPack</param>
        /// <param name="clientInfo">clientInfo</param>
        private void HeartBeatAck(byte[] revPack, ClientObjectInfo clientInfo) {
            try {
                if (clientInfo.LinkState == EnmLinkState.Authentication) {
                    var sedPack = ComUtility.GetHeartBeatAckPack(revPack);
                    if (sedPack != null) { clientInfo.Send(sedPack); }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[HeartBeatAck]{0}", err.Message));
            }
        }

        /// <summary>
        /// Tcp Logout
        /// </summary>
        private void TcpLogout(ClientObjectInfo clientInfo) {
            try {
                if (clientInfo.LinkState == EnmLinkState.Authentication) {
                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("Lsc客户端用户注销中[{0}:{1}]...", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                    var sedPack = ComUtility.GetLogOutPack(clientInfo.CurPackNo);
                    if (sedPack != null) {
                        clientInfo.Send(sedPack);
                        while (true) {
                            if (clientInfo.LinkState == EnmLinkState.Connected || clientInfo.LogoutCnt++ >= 50) {
                                break;
                            }

                            Thread.Sleep(100);
                        }
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[TcpLogout]{0}", err.Message));
            } finally {
                TcpClose(clientInfo);
            }
        }

        /// <summary>
        /// Tcp Logout Ack
        /// </summary>
        /// <param name="revPack">revPack</param>
        /// <param name="clientInfo">clientInfo</param>
        private void TcpLogoutAck(byte[] revPack, ClientObjectInfo clientInfo) {
            if (clientInfo == null)
                return;

            try {
                var packType = BitConverter.ToInt32(revPack, 12);
                var enmPackType = Enum.IsDefined(typeof(EnmMsgType), packType) ? (EnmMsgType)packType : EnmMsgType.Pack;
                if (enmPackType == EnmMsgType.packLogoutAck && revPack.Length == 22) {
                    var result = BitConverter.ToInt32(clientInfo.ReadBuffer, 16);
                    var enmResult = Enum.IsDefined(typeof(EnmResult), result) ? (EnmResult)result : EnmResult.Failure;
                    if (enmResult == EnmResult.Success) {
                        clientInfo.LinkState = EnmLinkState.Connected;
                        WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("Lsc客户端用户注销成功[{0}:{1}]", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                    } else {
                        WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("Lsc客户端用户注销失败[{0}:{1}]", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[TcpLogoutAck]{0}", err.Message));
            }
        }

        /// <summary>
        /// Tcp Close
        /// </summary>
        private void TcpClose(ClientObjectInfo clientInfo) {
            if (clientInfo == null)
                return;

            try {
                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("Lsc客户端断开中[{0}:{1}]...", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
                clientInfo.ClientDispose();
                clientInfo.LinkState = EnmLinkState.Disconnect;
                WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("Lsc客户端断开成功[{0}:{1}]", clientInfo.Lsc.LscIP, clientInfo.Lsc.LscPort));
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[TcpClose]{0}", err.Message));
            } finally {
                clientInfo.Lsc.Connected = false;
                clientInfo.Lsc.ChangeTime = DateTime.Now;
                UpdateLscAttributes(clientInfo.Lsc);
            }
        }

        /// <summary>
        /// Update Lsc Attributes
        /// </summary>
        /// <param name="lsc">lsc</param>
        private void UpdateLscAttributes(LscInfo lsc) {
            try {
                if (lsc != null) {
                    new BLsc().UpdateAttributes(lsc.LscID, lsc.Connected, lsc.ChangeTime);
                    WriteLog(DateTime.Now, EnmLogType.Info, "System", String.Format("Lsc通信状态更新成功[Lsc:{0} - {1})]", lsc.LscID, lsc.LscName));
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmLogType.Error, "System", String.Format("[UpdateLscAttributes]{0}", err.Message));
            }
        }

        /// <summary>
        /// Write Log
        /// </summary>
        /// <param name="dt">dt</param>
        /// <param name="type">type</param>
        /// <param name="_operator">_operator</param>
        /// <param name="msg">msg</param>
        private void WriteLog(DateTime dt, EnmLogType type, string _operator, string msg) {
            try {
                lock (logQueue) {
                    var log = new LogInfo();
                    log.EventTime = dt;
                    log.EventType = type;
                    log.Message = msg;
                    log.Operator = _operator;
                    logQueue.Enqueue(log);
                }
            } catch { }
        }

        /// <summary>
        /// Write RealTime Log
        /// </summary>
        /// <param name="dt">dt</param>
        /// <param name="type">type</param>
        /// <param name="_operator">_operator</param>
        /// <param name="msg">msg</param>
        private void WriteRealTimeLog(DateTime dt, EnmLogType type, string _operator, string msg) {
            try {
                var logEntity = new BLog();
                var log = new LogInfo();

                log.EventTime = dt;
                log.EventType = type;
                log.Message = msg;
                log.Operator = _operator;
                logEntity.WriteTxtLog(log);
                logEntity.WriteDBLog(log);
            } catch { }
        }

        /// <summary>
        /// Write RealTime Log
        /// </summary>
        /// <param name="log">log</param>
        private void WriteRealTimeLog(IList<LogInfo> logs) {
            try {
                var logEntity = new BLog();
                logEntity.WriteTxtLog(logs);
                logEntity.WriteDBLog(logs);
            } catch { }
        }
    }
}