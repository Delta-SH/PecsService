using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Delta.PECS.WebService.Model;
using Delta.PECS.WebService.DBUtility;

namespace Delta.PECS.WebService.DataServer
{
    /// <summary>
    /// Collection of utility methods for presentation-tier
    /// </summary>
    public abstract class ComUtility
    {
        /// <summary>
        /// String Default Value
        /// </summary>
        public static readonly string DefaultString = String.Empty;

        /// <summary>
        /// Int32 Default Value
        /// </summary>
        public static readonly int DefaultInt32 = Int32.MinValue;

        /// <summary>
        /// Int16 Default Value
        /// </summary>
        public static readonly short DefaultInt16 = Int16.MinValue;

        /// <summary>
        /// Single Default Value
        /// </summary>
        public static readonly float DefaultFloat = Single.MinValue;

        /// <summary>
        /// DateTime Default Value
        /// </summary>
        public static readonly DateTime DefaultDateTime = DateTime.MinValue;

        /// <summary>
        /// Boolean Default Value
        /// </summary>
        public static readonly bool DefaultBoolean = false;

        /// <summary>
        /// Default Keys
        /// </summary>
        public const string DefaultKeys = "00000000000000000000000000000000";

        /// <summary>
        /// Default Salts.
        /// </summary>
        private static readonly string[] DefaultSalts = new string[] { "5xpjyi47bvhw", "97A0", "4B96", "XIsu", "eX9dz8DixWe" };

        #region Login Package
        /// <summary>
        /// Login Package
        /// </summary>
        /// <param name="uId">UID</param>
        /// <param name="pwd">PWD</param>
        /// <param name="serialNo">SerialNo</param>
        /// <returns>Login Package</returns>
        public static byte[] GetLoginPack(string uId, string pwd, int serialNo) {
            try {
                byte[] pack = new byte[58];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 58;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 101;

                byt = ASCIIEncoding.Default.GetBytes(uId);
                for(int b = 1; b <= 20; b++) {
                    if(byt.Length < b)
                        pack[15 + b] = 0;
                    else
                        pack[15 + b] = byt[b - 1];
                }

                byt = ASCIIEncoding.Default.GetBytes(pwd);
                for(int b = 1; b <= 20; b++) {
                    if(byt.Length < b)
                        pack[35 + b] = 0;
                    else
                        pack[35 + b] = byt[b - 1];
                }

                byt = CRC16T(pack, 4, 55);
                pack[56] = byt[0];
                pack[57] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Logout Package
        /// <summary>
        /// Logout Package
        /// </summary>
        /// <param name="serialNo">serialNo</param>
        /// <returns>Logout Package</returns>
        public static byte[] GetLogOutPack(int serialNo) {
            try {
                byte[] pack = new byte[18];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 18;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 103;

                byt = CRC16T(pack, 4, 15);
                pack[16] = byt[0];
                pack[17] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region NodeState Package
        /// <summary>
        /// NodeState Package
        /// </summary>
        /// <param name="TerminalID">TerminalID</param>
        /// <param name="GroudID">GroudID</param>
        /// <param name="AcceMode">AcceMode</param>
        /// <param name="Polling">Polling</param>
        /// <param name="serialNo">serialNo</param>
        /// <param name="nodes">nodes</param>
        /// <returns>NodeState Package</returns>
        public static byte[] GetNodePack(int TerminalID, int GroudID, byte AcceMode, int Polling, int serialNo, Dictionary<int, int> nodes) {
            if(nodes == null || nodes.Count <= 0)
                return null;

            try {
                int len = 38 + nodes.Count * 8;
                byte[] pack = new byte[len];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;

                byt = BitConverter.GetBytes(len);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0xAB;
                pack[13] = 0xF;

                byt = BitConverter.GetBytes(TerminalID);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                byt = BitConverter.GetBytes(GroudID);
                pack[20] = byt[0];
                pack[21] = byt[1];
                pack[22] = byt[2];
                pack[23] = byt[3];
                pack[24] = AcceMode;

                byt = BitConverter.GetBytes(Polling);
                pack[28] = byt[0];
                pack[29] = byt[1];
                pack[30] = byt[2];
                pack[31] = byt[3];

                byt = BitConverter.GetBytes(nodes.Count);
                pack[32] = byt[0];
                pack[33] = byt[1];
                pack[34] = byt[2];
                pack[35] = byt[3];

                int packIndex = 35;
                foreach(KeyValuePair<int, int> key in nodes) {
                    byt = BitConverter.GetBytes(key.Value);
                    pack[packIndex + 1] = byt[0];
                    pack[packIndex + 2] = byt[1];
                    pack[packIndex + 3] = byt[2];
                    pack[packIndex + 4] = byt[3];
                    byt = BitConverter.GetBytes(key.Key);
                    pack[packIndex + 5] = byt[0];
                    pack[packIndex + 6] = byt[1];
                    pack[packIndex + 7] = byt[2];
                    pack[packIndex + 8] = byt[3];
                    packIndex += 8;
                }

                byt = CRC16T(pack, 4, pack.Length - 3);
                pack[pack.Length - 2] = byt[0];
                pack[pack.Length - 1] = byt[1];
                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region SetDO Package
        /// <summary>
        /// SetDO Package
        /// </summary>
        /// <param name="NodeId">NodeId</param>
        /// <param name="Value">Value</param>
        /// <param name="LscId">LscId</param>
        /// <param name="UserId">UserId</param>
        /// <param name="UserName">UserName</param>
        /// <param name="serialNo">serialNo</param>
        /// <returns>SetDO Package</returns>
        public static byte[] GetSetDOPack(int NodeId, byte Value, int LscId, int UserId, string UserName, int serialNo) {
            try {
                byte[] pack = new byte[59];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 59;
                
                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0x89;
                pack[13] = 0x13;
                pack[16] = 4;
                
                byt = BitConverter.GetBytes(NodeId);
                pack[20] = byt[0];
                pack[21] = byt[1];
                pack[22] = byt[2];
                pack[23] = byt[3];
                
                byt = BitConverter.GetBytes(LscId);
                pack[24] = byt[0];
                pack[25] = byt[1];
                pack[26] = byt[2];
                pack[27] = byt[3];
                pack[28] = Value;
                pack[29] = (byte)EnmState.Opevent;
                
                byt = BitConverter.GetBytes(UserId);
                pack[33] = byt[0];
                pack[34] = byt[1];
                pack[35] = byt[2];
                pack[36] = byt[3];
                
                byt = ASCIIEncoding.Default.GetBytes(UserName);
                for(int i = 0; i < byt.Length; i++) {
                    pack[37 + i] = byt[i];
                }
                
                byt = CRC16T(pack, 4, 56);
                pack[57] = byt[0];
                pack[58] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region SetAO Package
        /// <summary>
        /// SetAO Package
        /// </summary>
        /// <param name="NodeId">NodeId</param>
        /// <param name="Value">Value</param>
        /// <param name="LscId">LscId</param>
        /// <param name="UserId">UserId</param>
        /// <param name="UserName">UserName</param>
        /// <param name="serialNo">serialNo</param>
        /// <returns>SetAO Package</returns>
        public static byte[] GetSetAOPack(int NodeId, float Value, int LscId, int UserId, string UserName, int serialNo) {
            try {
                byte[] pack = new byte[62];
                byte[] byt;
                
                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 62;
                
                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0x89;
                pack[13] = 0x13;
                pack[16] = 5;
                
                byt = BitConverter.GetBytes(NodeId);
                pack[20] = byt[0];
                pack[21] = byt[1];
                pack[22] = byt[2];
                pack[23] = byt[3];
                
                byt = BitConverter.GetBytes(LscId);
                pack[24] = byt[0];
                pack[25] = byt[1];
                pack[26] = byt[2];
                pack[27] = byt[3];
                
                byt = BitConverter.GetBytes(Value);
                pack[28] = byt[0];
                pack[29] = byt[1];
                pack[30] = byt[2];
                pack[31] = byt[3];
                pack[32] = (byte)EnmState.Opevent;
                
                byt = BitConverter.GetBytes(UserId);
                pack[36] = byt[0];
                pack[37] = byt[1];
                pack[38] = byt[2];
                pack[39] = byt[3];
                
                byt = ASCIIEncoding.Default.GetBytes(UserName);
                for(int i = 0; i < byt.Length; i++) {
                    pack[40 + i] = byt[i];
                }
                
                byt = CRC16T(pack, 4, 59);
                pack[60] = byt[0];
                pack[61] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region ConfirmAlarm Package
        /// <summary>
        /// ConfirmAlarm Package
        /// </summary>
        /// <param name="Ids">Ids</param>
        /// <param name="DispatchNO">DispatchNO</param>
        /// <param name="UserName">UserName</param>
        /// <param name="serialNo">serialNo</param>
        /// <returns>ConfirmAlarm Package</returns>
        public static byte[] GetConfirmAlarmPack(List<int> Ids, int DispatchNO, string UserName, int serialNo) {
            try {
                byte[] pack = new byte[46 + Ids.Count * 4];
                byte[] byt;
                
                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                byt = BitConverter.GetBytes(pack.Length);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];
                
                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0x7C;
                pack[13] = 0x15;
                
                byt = BitConverter.GetBytes(Ids.Count);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];
                
                int n = 20;
                for(int i = 0; i < Ids.Count; i++) {
                    byt = BitConverter.GetBytes(Ids[i]);
                    pack[n] = byt[0];
                    pack[n + 1] = byt[1];
                    pack[n + 2] = byt[2];
                    pack[n + 3] = byt[3];
                    n += 4;
                }
                
                byt = BitConverter.GetBytes(DispatchNO);
                pack[n] = byt[0];
                pack[n + 1] = byt[1];
                pack[n + 2] = byt[2];
                pack[n + 3] = byt[3];
                n += 4;
                
                byt = ASCIIEncoding.Default.GetBytes(UserName);
                for(int i = 0; i < 20; i++) {
                    if(byt.Length - 1 < i)
                        pack[n + i] = 0;
                    else
                        pack[n + i] = byt[i];
                }
                n += 19;

                byt = CRC16T(pack, 4, n);
                pack[n + 1] = byt[0];
                pack[n + 2] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Alarm Ack Package
        /// <summary>
        /// GetAlarmAckPack
        /// </summary>
        /// <param name="revPack">revPack</param>
        public static byte[] GetAlarmAckPack(byte[] revPack) {
            try {
                byte[] byt;
                revPack[12] = 0xF8;
                byt = CRC16T(revPack, 4, revPack.Length - 3);
                revPack[revPack.Length - 2] = byt[0];
                revPack[revPack.Length - 1] = byt[1];

                return revPack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Sync Alarm Package
        public static byte[] GetSyncAlarmPack(int serialNo) {
            try {
                byte[] pack = new byte[22];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 22;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];

                byt = BitConverter.GetBytes((int)EnmMsgType.packReqSyncAlarm);
                pack[12] = byt[0];
                pack[13] = byt[1];
                pack[14] = byt[2];
                pack[15] = byt[3];

                byt = BitConverter.GetBytes(0);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                byt = CRC16T(pack, 4, 19);
                pack[20] = byt[0];
                pack[21] = byt[1];

                return pack;
            }
            catch {
                throw;
            }
        }
        #endregion

        #region HeartBeat Package
        /// <summary>
        /// HeartBeat Package
        /// </summary>
        /// <param name="serialNo">serialNo</param>
        /// <returns>HeartBeat Package</returns>
        public static byte[] GetHeartBeatPack(int serialNo) {
            try {
                byte[] pack = new byte[18];
                byte[] byt;
                
                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 18;
                
                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0xB1;
                pack[13] = 4;

                byt = CRC16T(pack, 4, 15);
                pack[16] = byt[0];
                pack[17] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region HeartBeat Ack Package
        /// <summary>
        /// HeartBeat Ack Package
        /// </summary>
        /// <param name="pack">pack</param>
        /// <returns></returns>
        public static byte[] GetHeartBeatAckPack(byte[] pack) {
            try {
                byte[] byt;
                
                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 18;
                
                pack[12] = 0xB2;
                pack[13] = 4;

                byt = CRC16T(pack, 4, 15);
                pack[16] = byt[0];
                pack[17] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Sync Server Datetime Package
        /// <summary>
        /// Sync Server Datetime Package
        /// </summary>
        /// <param name="pack">pack</param>
        /// <param name="curTime">curTime</param>
        /// <returns></returns>
        public static byte[] GetServerDateTimePack(int serialNo, DateTime curTime) {
            try {
                byte[] pack = new byte[25];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;

                byt = BitConverter.GetBytes(25);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];

                byt = BitConverter.GetBytes((Int32)EnmMsgType.packTimeCheck);
                pack[12] = byt[0];
                pack[13] = byt[1];
                pack[14] = byt[2];
                pack[15] = byt[3];

                byt = BitConverter.GetBytes((Int16)curTime.Year);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = (byte)curTime.Month;
                pack[19] = (byte)curTime.Day;
                pack[20] = (byte)curTime.Hour;
                pack[21] = (byte)curTime.Minute;
                pack[22] = (byte)curTime.Second;

                byt = CRC16T(pack, 4, 22);
                pack[23] = byt[0];
                pack[24] = byt[1];
                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Confirm Trend Alarm Package
        /// <summary>
        /// Confirm Trend Alarm Package
        /// </summary>
        /// <param name="pack">pack</param>
        /// <param name="Ids">Ids</param>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        public static byte[] GetConfirmTrendAlarmPack(int serialNo, List<int> Ids, string userName) {
            try {
                byte[] pack = new byte[42 + Ids.Count * 4];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;

                byt = BitConverter.GetBytes(pack.Length);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];

                byt = BitConverter.GetBytes((Int32)EnmMsgType.packConfirmTrendAlarm);
                pack[12] = byt[0];
                pack[13] = byt[1];
                pack[14] = byt[2];
                pack[15] = byt[3];

                byt = BitConverter.GetBytes(Ids.Count);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                int n = 20;
                for (int i = 0; i < Ids.Count; i++) {
                    byt = BitConverter.GetBytes(Ids[i]);
                    pack[n] = byt[0];
                    pack[n + 1] = byt[1];
                    pack[n + 2] = byt[2];
                    pack[n + 3] = byt[3];
                    n += 4;
                }

                byt = ASCIIEncoding.Default.GetBytes(userName);
                for (int i = 0; i < 20; i++) {
                    if (byt.Length - 1 < i)
                        pack[n + i] = 0;
                    else
                        pack[n + i] = byt[i];
                }
                n += 19;

                byt = CRC16T(pack, 4, n);
                pack[n + 1] = byt[0];
                pack[n + 2] = byt[1];
                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region End Trend Alarm Package
        /// <summary>
        /// End Trend Alarm Package
        /// </summary>
        /// <param name="pack">pack</param>
        /// <param name="Ids">Ids</param>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        public static byte[] GetEndTrendAlarmPack(int serialNo, List<int> Ids, string userName) {
            try {
                byte[] pack = new byte[42 + Ids.Count * 4];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;

                byt = BitConverter.GetBytes(pack.Length);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];

                byt = BitConverter.GetBytes((Int32)EnmMsgType.packEndTrendAlarm);
                pack[12] = byt[0];
                pack[13] = byt[1];
                pack[14] = byt[2];
                pack[15] = byt[3];

                byt = BitConverter.GetBytes(Ids.Count);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                int n = 20;
                for (int i = 0; i < Ids.Count; i++) {
                    byt = BitConverter.GetBytes(Ids[i]);
                    pack[n] = byt[0];
                    pack[n + 1] = byt[1];
                    pack[n + 2] = byt[2];
                    pack[n + 3] = byt[3];
                    n += 4;
                }

                byt = ASCIIEncoding.Default.GetBytes(userName);
                for (int i = 0; i < 20; i++) {
                    if (byt.Length - 1 < i)
                        pack[n + i] = 0;
                    else
                        pack[n + i] = byt[i];
                }
                n += 19;

                byt = CRC16T(pack, 4, n);
                pack[n + 1] = byt[0];
                pack[n + 2] = byt[1];
                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Confirm Load Alarm Package
        /// <summary>
        /// Confirm Load Alarm Package
        /// </summary>
        /// <param name="pack">pack</param>
        /// <param name="Ids">Ids</param>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        public static byte[] GetConfirmLoadAlarmPack(int serialNo, List<int> Ids, string userName) {
            try {
                byte[] pack = new byte[42 + Ids.Count * 4];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;

                byt = BitConverter.GetBytes(pack.Length);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];

                byt = BitConverter.GetBytes((Int32)EnmMsgType.packConfirmLoadAlarm);
                pack[12] = byt[0];
                pack[13] = byt[1];
                pack[14] = byt[2];
                pack[15] = byt[3];

                byt = BitConverter.GetBytes(Ids.Count);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                int n = 20;
                for (int i = 0; i < Ids.Count; i++) {
                    byt = BitConverter.GetBytes(Ids[i]);
                    pack[n] = byt[0];
                    pack[n + 1] = byt[1];
                    pack[n + 2] = byt[2];
                    pack[n + 3] = byt[3];
                    n += 4;
                }

                byt = ASCIIEncoding.Default.GetBytes(userName);
                for (int i = 0; i < 20; i++) {
                    if (byt.Length - 1 < i)
                        pack[n + i] = 0;
                    else
                        pack[n + i] = byt[i];
                }
                n += 19;

                byt = CRC16T(pack, 4, n);
                pack[n + 1] = byt[0];
                pack[n + 2] = byt[1];
                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region End Load Alarm Package
        /// <summary>
        /// End Load Alarm Package
        /// </summary>
        /// <param name="pack">pack</param>
        /// <param name="Ids">Ids</param>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        public static byte[] GetEndLoadAlarmPack(int serialNo, List<int> Ids, string userName) {
            try {
                byte[] pack = new byte[42 + Ids.Count * 4];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;

                byt = BitConverter.GetBytes(pack.Length);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];

                byt = BitConverter.GetBytes((Int32)EnmMsgType.packEndLoadAlarm);
                pack[12] = byt[0];
                pack[13] = byt[1];
                pack[14] = byt[2];
                pack[15] = byt[3];

                byt = BitConverter.GetBytes(Ids.Count);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                int n = 20;
                for (int i = 0; i < Ids.Count; i++) {
                    byt = BitConverter.GetBytes(Ids[i]);
                    pack[n] = byt[0];
                    pack[n + 1] = byt[1];
                    pack[n + 2] = byt[2];
                    pack[n + 3] = byt[3];
                    n += 4;
                }

                byt = ASCIIEncoding.Default.GetBytes(userName);
                for (int i = 0; i < 20; i++) {
                    if (byt.Length - 1 < i)
                        pack[n + i] = 0;
                    else
                        pack[n + i] = byt[i];
                }
                n += 19;

                byt = CRC16T(pack, 4, n);
                pack[n + 1] = byt[0];
                pack[n + 2] = byt[1];
                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Confirm Frequency Alarm Package
        /// <summary>
        /// Confirm Frequency Alarm Package
        /// </summary>
        /// <param name="pack">pack</param>
        /// <param name="Ids">Ids</param>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        public static byte[] GetConfirmFrequencyAlarmPack(int serialNo, List<int> Ids, string userName) {
            try {
                byte[] pack = new byte[42 + Ids.Count * 4];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;

                byt = BitConverter.GetBytes(pack.Length);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];

                byt = BitConverter.GetBytes((Int32)EnmMsgType.packConfirmFrequencyAlarm);
                pack[12] = byt[0];
                pack[13] = byt[1];
                pack[14] = byt[2];
                pack[15] = byt[3];

                byt = BitConverter.GetBytes(Ids.Count);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                int n = 20;
                for (int i = 0; i < Ids.Count; i++) {
                    byt = BitConverter.GetBytes(Ids[i]);
                    pack[n] = byt[0];
                    pack[n + 1] = byt[1];
                    pack[n + 2] = byt[2];
                    pack[n + 3] = byt[3];
                    n += 4;
                }

                byt = ASCIIEncoding.Default.GetBytes(userName);
                for (int i = 0; i < 20; i++) {
                    if (byt.Length - 1 < i)
                        pack[n + i] = 0;
                    else
                        pack[n + i] = byt[i];
                }
                n += 19;

                byt = CRC16T(pack, 4, n);
                pack[n + 1] = byt[0];
                pack[n + 2] = byt[1];
                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region End Frequency Alarm Package
        /// <summary>
        /// End Frequency Alarm Package
        /// </summary>
        /// <param name="pack">pack</param>
        /// <param name="Ids">Ids</param>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        public static byte[] GetEndFrequencyAlarmPack(int serialNo, List<int> Ids, string userName) {
            try {
                byte[] pack = new byte[42 + Ids.Count * 4];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;

                byt = BitConverter.GetBytes(pack.Length);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];

                byt = BitConverter.GetBytes((Int32)EnmMsgType.packEndFrequencyAlarm);
                pack[12] = byt[0];
                pack[13] = byt[1];
                pack[14] = byt[2];
                pack[15] = byt[3];

                byt = BitConverter.GetBytes(Ids.Count);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                int n = 20;
                for (int i = 0; i < Ids.Count; i++) {
                    byt = BitConverter.GetBytes(Ids[i]);
                    pack[n] = byt[0];
                    pack[n + 1] = byt[1];
                    pack[n + 2] = byt[2];
                    pack[n + 3] = byt[3];
                    n += 4;
                }

                byt = ASCIIEncoding.Default.GetBytes(userName);
                for (int i = 0; i < 20; i++) {
                    if (byt.Length - 1 < i)
                        pack[n + i] = 0;
                    else
                        pack[n + i] = byt[i];
                }
                n += 19;

                byt = CRC16T(pack, 4, n);
                pack[n + 1] = byt[0];
                pack[n + 2] = byt[1];
                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region CRC-16T Package
        /// <summary>
        /// CRC-16T Package
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="offset">offset</param>
        /// <param name="endset">endset</param>
        /// <returns>CRC-16T Package</returns>
        public static byte[] CRC16T(byte[] data, int offset, int endset) {
            byte[] returnData = { 0, 0 };
            if(data == null)
                return returnData;

            byte CRC16Hi;
            byte CRC16Lo;
            int iIndex;

            try {
                CRC16Hi = 0xFF;
                CRC16Lo = 0xFF;

                if(endset == 0)
                    endset = data.GetUpperBound(0);

                for(int i = offset; i <= endset; i++) {
                    iIndex = CRC16Lo ^ data[i];
                    CRC16Lo = (byte)(CRC16Hi ^ GetCRC_16_Lo(iIndex));
                    CRC16Hi = GetCRC_16_Hi(iIndex);
                }

                returnData[0] = CRC16Hi;
                returnData[1] = CRC16Lo;

                return returnData;
            } catch{
                return (new byte[2] { 0, 0 });
            }
        }
        #endregion

        #region CRC-16T Low List
        /// <summary>
        /// CRC-16T Low List
        /// </summary>
        /// <param name="Ind">Ind</param>
        /// <returns>CRC-16T Low List</returns>
        private static byte GetCRC_16_Lo(int Ind) {
            try {
                byte[] LoBty = { 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 
                                 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 
                                 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 
                                 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0,
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 
                                 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 
                                 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 
                                 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 
                                 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 
                                 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 
                                 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40
                               };

                return LoBty[Ind];
            } catch{
                return 0;
            }
        }
        #endregion

        #region CRC-16T High List
        /// <summary>
        /// CRC-16T High List
        /// </summary>
        /// <param name="Ind">Ind</param>
        /// <returns>CRC-16T High List</returns>
        private static byte GetCRC_16_Hi(int Ind) {
            try {
                byte[] HiBty = { 0x0, 0xC0, 0xC1, 0x1, 0xC3, 0x3, 0x2, 0xC2, 0xC6, 0x6,
                                 0x7, 0xC7, 0x5, 0xC5, 0xC4, 0x4, 0xCC, 0xC, 0xD, 0xCD, 
                                 0xF, 0xCF, 0xCE, 0xE, 0xA, 0xCA, 0xCB, 0xB, 0xC9, 0x9,
                                 0x8, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A,
                                 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 0x14, 0xD4,
                                 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3, 
                                 0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3,
                                 0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 
                                 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 
                                 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 
                                 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED, 
                                 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26, 
                                 0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 
                                 0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 
                                 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 
                                 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 
                                 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 
                                 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5, 
                                 0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 
                                 0x70, 0xB0, 0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 
                                 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 
                                 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 
                                 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B, 
                                 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C, 
                                 0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 
                                 0x43, 0x83, 0x41, 0x81, 0x80, 0x40
                               };

                return HiBty[Ind];
            } catch{
                return 0;
            }
        }
        #endregion

        #region Check Single Package
        /// <summary>
        /// Check Single Package
        /// </summary>
        /// <param name="package">package</param>
        /// <param name="revLen">revLen</param>
        public static bool CheckSinglePackage(byte[] package, int revLen) {
            try {
                if(revLen > 17
                    && package[0] == 0x5A
                    && package[1] == 0x6B
                    && package[2] == 0x7C
                    && package[3] == 0x7E) {
                    int packLen = BitConverter.ToInt32(package, 4);
                    return revLen == packLen;
                }

                return false;
            } catch {
                throw;
            }
        }
        #endregion

        #region Alarm Describe String
        /// <summary>
        /// Alarm Describe String
        /// </summary>
        /// <param name="Describe">Describe</param>
        /// <param name="value">value</param>
        /// <returns>Alarm Describe String</returns>
        public static string GetDesc(string Describe, string value) {
            try {
                string[] strs = Describe.Split(new char[] { '\t' });
                string[] strs1;
                for(int i = 0; i < strs.Length; i++) {
                    strs1 = strs[i].Split(new char[] { '&' });
                    if(strs1[0].Equals(value))
                        return strs1[1];
                }

                return String.Empty;
            } catch {
                return String.Empty;
            }
        }
        #endregion

        #region Create Lsc ConnectionString
        /// <summary>
        /// Create Lsc ConnectionString
        /// </summary>
        /// <param name="lsc">lsc</param>
        /// <returns>Lsc ConnectionString</returns>
        public static string CreateLscConnectionString(LscInfo lsc) {
            try {
                return SqlHelper.CreateConnectionString(false, lsc.DBServer, lsc.DBPort, lsc.DBName, lsc.DBUID, lsc.DBPwd, 120);
            }
            catch {
                throw;
            }
        }
        #endregion

        #region Check Numeric
        /// <summary>
        /// Check Numeric
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>true or false</returns>
        public static bool IsNumeric(string val) {
            return Regex.IsMatch(val, @"^[-]?\d+[.]?\d*$");
        }
        #endregion

        #region Get Machine Code
        /// <summary>
        /// Get Machine Code
        /// </summary>
        public static String GetMachineCode() {
            try {
                var hdd = GetHDDId();
                var cpu = GetCPUId();
                var bbd = GetBaseBoardId();
                if (!String.IsNullOrEmpty(hdd)
                    || !String.IsNullOrEmpty(cpu)
                    || !String.IsNullOrEmpty(bbd)) {
                    var originalKey = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}", DefaultSalts[0], cpu, DefaultSalts[1], DefaultSalts[2], bbd, DefaultSalts[3], hdd, DefaultSalts[4]);
                    var bs = Encoding.UTF8.GetBytes(originalKey);
                    var hs = MD5.Create().ComputeHash(bs);
                    return new Guid(hs).ToString("N").ToUpper();
                }
            } catch { }
            return DefaultKeys;
        }
        #endregion

        #region Get CPU ID
        /// <summary>
        /// Get cpu id.
        /// </summary>
        /// <returns>cpu id</returns>
        private static String GetCPUId() {
            try {
                using (var searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_processor")) {
                    foreach (var mo in searcher.Get()) {
                        var id = mo.GetPropertyValue("ProcessorId");
                        if (id != null) { return id.ToString().Trim().ToUpper(); }
                    }
                }
            } catch { }
            return String.Empty;
        }
        #endregion

        #region Get BaseBoard ID
        /// <summary>
        /// Get baseboard id.
        /// </summary>
        /// <returns>baseboard id</returns>
        private static String GetBaseBoardId() {
            try {
                using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard")) {
                    foreach (var mo in searcher.Get()) {
                        var id = mo.GetPropertyValue("SerialNumber");
                        if (id != null) { return id.ToString().Trim().ToUpper(); }
                    }
                }
            } catch { }
            return String.Empty;
        }
        #endregion

        #region Get HardDisk ID
        /// <summary>
        /// Get hard disk id.
        /// </summary>
        /// <returns>Hard disk id</returns>
        private static String GetHDDId() {
            try {
                using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia")) {
                    foreach (var mo in searcher.Get()) {
                        var id = mo.GetPropertyValue("SerialNumber");
                        if (id != null) { return id.ToString().Trim().ToUpper(); }
                    }
                }
            } catch { }
            return String.Empty;
        }
        #endregion

        #region Create Temp Code
        public static String CreateTempCode(String mcode, DateTime startDate) {
            var text = String.Format("试用注册码┋中达电通股份有限公司┋5┋{0}", startDate.AddMonths(3).Ticks);
            var keys = mcode.ToCharArray().Reverse().ToArray();
            var aesKey = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", keys[3], keys[6], keys[9], keys[12], keys[13], keys[16], keys[19], keys[25], keys[29], keys[31], keys[7], keys[16], keys[12], keys[20], keys[2], keys[3]);
            var aesIV = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", keys[5], keys[8], keys[10], keys[14], keys[20], keys[21], keys[24], keys[25], keys[29], keys[30], keys[2], keys[5], keys[6], keys[17], keys[22], keys[10]);
            return Encrypt(text, aesKey, aesIV);
        }
        #endregion

        #region Encrypt
        /// <summary>
        /// AES Encryption
        /// </summary>
        private static String Encrypt(String text, String aesKey, String aesIV) {
            // AesCryptoServiceProvider
            var aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = Encoding.UTF8.GetBytes(aesIV);
            aes.Key = Encoding.UTF8.GetBytes(aesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert string to byte array
            byte[] src = Encoding.Unicode.GetBytes(text);

            // encryption
            using (ICryptoTransform encrypt = aes.CreateEncryptor()) {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // Convert byte array to Base64 strings
                return Convert.ToBase64String(dest);
            }
        }
        #endregion

        #region Convert DateTime
        /// <summary>
        /// Convert DateTime
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="month">month</param>
        /// <param name="day">day</param>
        /// <param name="hour">hour</param>
        /// <param name="minute">minute</param>
        /// <param name="second">second</param>
        /// <returns>DateTime</returns>
        public static DateTime ConvertToDateTime(int year, int month, int day, int hour, int minute, int second) {
            if (year <= 0) year = 1;
            if (month <= 0) month = 1;
            if (day <= 0) day = 1;
            if (hour < 0) hour = 0;
            if (minute < 0) minute = 0;
            if (second < 0) second = 0;
            return new DateTime(year, month, day, hour, minute, second);
        }
        #endregion

        #region Get DevID By NodeID
        /// <summary>
        /// Get DevID
        /// </summary>
        /// <param name="nodeId">nodeId</param>
        /// <returns>device id</returns>
        public static int GetDevID(int nodeId) {
            return (int)(nodeId & 0xFFFFF800);
        }
        #endregion
    }
}