using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
using System.Xml;

namespace SMLWebService
{
    public static class _myGlobal
    {
        public static Boolean _isDesignMode = true;
        public static List<_providerListClass> _providerList = new List<_providerListClass>();



        /// <summary>
        /// true=ติดต่อสำเร็จ,false=ติดต่อไม่สำเร็จ
        /// </summary>
        public static Boolean _serviceConnected = false;
        /// <summary>
        /// ให้แสดง Menu ทุกรายการ ไม่สน TAG
        /// </summary>
        public static Boolean _menuAll = false;


        /// <summary>อนุญาติให้ ดึง report</summary>
        public static Boolean _allowProcessReportServer = true;

        //โหมดฉุกเฉิน
        public static Boolean _emergencyMode = false;
        public static String _emergencyURL = "";
        public static String _emergencyPort = "";

        /// <summary>
        /// เป็น User ที่สามารถทำการ Lock เอกสารได้หรือไม่
        /// </summary>
        public static Boolean _isUserLockDocument = false;


        public static string _internetSyncName = "thai7";
        public static _databaseType _masterDatabaseType = _databaseType.PostgreSql;

        /// <summary>
        /// ใช้ระบบ Proxy (0=Disable,1=Enable)
        /// </summary>
        public static int _proxyUsed = 0;
        public static string _proxyUrl = "";
        public static string _proxyUser = "";
        public static string _proxyPassword = "";


        /// <summary>รหัสกลุ่มข้อมูลที่ใช้งาน</summary>
        public static string _dataGroup = "SML";
        /// <summary>ชื่อ Server ที่เก็บ Webservice</summary>
        public static string _webServiceServer;
        public static ArrayList _webServiceServerList = new ArrayList();
        /// <summary>
        /// รายชื่อ Table ที่จะ Unlock เมื่อจบโปรแกรม หรือโปรแกรมหลุด หรือปิดเครื่อง
        /// </summary>
        public static ArrayList _tableForAutoUnlock = new ArrayList();

        public static string _getFirstWebServiceServer
        {
            get
            {
                if (_webServiceServerList.Count == 0)
                    return "";

                return ((_myWebserviceType)_webServiceServerList[0])._webServiceName;
            }
        }
        /// <summary>
        /// ชื่อเครื่องคอมพิวเตอร์
        /// </summary>
        public static string _computerNameTemp = "";
        public static string _computerName
        {
            set
            {
                StringBuilder __buffer = new StringBuilder();
                for (int __loop = 0; __loop < value.Length; __loop++)
                {
                    if (value[__loop] > ' ')
                    {
                        __buffer.Append(value[__loop]);
                    }
                }
                _computerNameTemp = (__buffer.ToString() + Guid.NewGuid().ToString()).Replace("\\", "").Replace("-", "");
            }
            get
            {
                return _computerNameTemp;
            }
        }
        /// <summary>
        /// ย่อข้อมูลระหว่างรับส่ง
        /// </summary>
        public static bool _compressWebservice = false;

        /// <summary>ชื่อ webService</summary>
        public static string _webServiceName;//"SMLWebServiceOld";
        /// <summary>ชื่อแฟ้ม XML ที่ใช้เก็บการใช้งาน (เก็บไว้ที่เครื่อง Client)</summary>
        public static string _profileFileName;
        public static bool _serverSetupCreateDatabaseSuccess = false;
        /// <summary>การ Login สมบูรณ์</summary>
        public static bool _userLoginSuccess = false;
        /// <summary>กลุ่มหน้าจอค้นหาของ User ที่ Login เข้ามาใช้งาน</summary>
        public static int _userSearchScreenGroup = 1;
        public static string _providerCode = "";




        public static int _serverCount = 100;

        public static string _smlCloudServicePath = "/SMLCloudService/service/rest";

        public static void _help(string name)
        {
            System.Diagnostics.Process.Start("http://www.smlsoft.com/smlaccountmanual/" + name);
        }



        private static string _getOSName()
        {
            System.OperatingSystem __os = System.Environment.OSVersion;
            string __osName = "Unknown";
            switch (__os.Platform)
            {
                case System.PlatformID.Win32Windows:
                    switch (__os.Version.Minor)
                    {
                        case 0:
                            __osName = "Windows 95";
                            break;
                        case 10:
                            __osName = "Windows 98";
                            break;
                        case 90:
                            __osName = "Windows ME";
                            break;
                    }
                    break;
                case System.PlatformID.Win32NT:
                    switch (__os.Version.Major)
                    {
                        case 3:
                            __osName = "Windws NT 3.51";
                            break;
                        case 4:
                            __osName = "Windows NT 4";
                            break;
                        case 5:
                            if (__os.Version.Minor == 0)
                                __osName = "Windows 2000";
                            else if (__os.Version.Minor == 1)
                                __osName = "Windows XP";
                            else if (__os.Version.Minor == 2)
                                __osName = "Windows Server 2003";
                            break;
                        case 6:
                            if (__os.Version.Minor == 0)
                                __osName = "Windows Vista";
                            else if (__os.Version.Minor == 1)
                                __osName = "Windows 7";
                            break;
                    }
                    break;
            }

            return __osName + ", " + __os.Version.ToString();
        }


        public static bool _checkConnectionAvailable(string strServer)
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(strServer);
                reqFP.Timeout = 1000;
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    // HTTP = 200 - Internet connection available, server online
                    rspFP.Close();
                    return true;
                }
                else
                {
                    // Other status - Server or connection not available
                    rspFP.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                // Exception - connection not available
                return false;
            }
        }

        public static string _xmlHeader = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
         public static object[] _databaseColumnTypeList = new object[] { "varchar", "currency", "int", "tinyint", "smallint", "float", "date", "text" };

        //
        /// <summary>
        /// ชื่อโครงสร้างฐานข้อมูลหลักของโปรแกรม
        /// </summary>
        public static string _mainDatabaseStruct = "";
        /// <summary>
        /// ชื่อแฟ้มที่เก็บรายละเอียดการเชื่อมข้อมูล
        /// </summary>
        static string _databaseConfigPrivate = "";
        /// <summary>
        /// ข้อความที่ป้อนล่าสุด
        /// </summary>
        public static string _lastTextBox = "";


        public static void _showHtml(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception exc1)
            {
                // System.ComponentModel.Win32Exception is a known exception that occurs when Firefox is default browser.  
                // It actually opens the browser but STILL throws this exception so we can just ignore it.  If not this exception,
                // then attempt to open the URL in IE instead.
                if (exc1.GetType().ToString() != "System.ComponentModel.Win32Exception")
                {
                    // sometimes throws exception so we have to just ignore
                    // this is a common .NET bug that no one online really has a great reason for so now we just need to try to open
                    // the URL using IE if we can.
                    try
                    {
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("IExplore.exe", url);
                        System.Diagnostics.Process.Start(startInfo);
                        startInfo = null;
                    }
                    catch (Exception __ex)
                    {
                        MessageBox.Show(__ex.Message);
                    }
                }
            }
        }

        public static string _deleteAscError(string source)
        {
            StringBuilder __result = new StringBuilder();
            for (int __loop = 0; __loop < source.Length; __loop++)
            {
                if (source[__loop] >= 32 || source[__loop] == 10 || source[__loop] == 13)
                {
                    __result.Append(source[__loop]);
                }
            }
            return __result.ToString();
        }

        public static string _fieldAndComma(params string[] fieldName)
        {
            StringBuilder __result = new StringBuilder();
            foreach (string __fieldName in fieldName)
            {
                if (__result.Length > 0)
                {
                    __result.Append(", ");
                }
                __result.Append(__fieldName);
            }
            return __result.ToString();
        }

        public static WebProxy _webProxy()
        {
            WebProxy __proxy = new WebProxy("www.smlsoft.com:3128", true);
            __proxy.Credentials = new NetworkCredential("pim", "pim");
            return __proxy;
        }


        public static string _databaseConfig
        {
            set
            {
                _databaseConfigPrivate = value;
            }
            get
            {
                try
                {
                    string[] __split = _databaseConfigPrivate.Split('.');
                    return __split[0].ToString() + _providerCode + "." + __split[1].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        // public static _databaseType _databaseSelectType = _databaseType.PostgreSql;

        public enum _databaseType
        {
            PostgreSql,
            MySql,
            MicrosoftSQL2000,
            MicrosoftSQL2005,
            Oracle,
            Firebird
        }

         

        // toe 
        public static object _objectFromXml(string Xml, System.Type ObjType)
        {
            XmlSerializer ser = new XmlSerializer(ObjType);
            StringReader stringReader;
            stringReader = new StringReader(Xml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            object obj = ser.Deserialize(xmlReader);
            xmlReader.Close();
            stringReader.Close();
            return obj;
        }

        public static string _objectToXml(object Obj, System.Type ObjType)
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;

            XmlSerializer ser = new XmlSerializer(ObjType);
            MemoryStream memStream = new MemoryStream();
            StringBuilder __str = new StringBuilder();
            XmlWriter xmlWriter = XmlWriter.Create(__str, setting);

            ser.Serialize(xmlWriter, Obj);
            xmlWriter.Close();
            memStream.Close();
            return __str.ToString();
        }

        public static void _writeLogFile(string filePath, string text, bool _startNewLog)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    if (_startNewLog)
                    {
                        FileStream aFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(aFile);
                        sw.Write(text);
                        sw.Close();
                        aFile.Close();
                    }
                    else
                    {
                        FileStream aFile = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(aFile);
                        sw.WriteLine(text);
                        sw.Close();
                        aFile.Close();
                    }
                }
                else
                {
                    FileStream aFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(aFile);
                    sw.Write(text);
                    sw.Close();
                    aFile.Close();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ตัดเครื่องหมาย แปลก ๆ ที่ทำให้ query error
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string _convertStrToQuery(string str)
        {
            return str.Replace("\'", "\'\'");
        }


        public static string _encapeStringForFilePath(string code)
        {
            return code.Replace("\\", "_").Replace(":", "__").Replace("/", string.Empty).Replace("*", string.Empty).Replace("\"", string.Empty).Replace("|", string.Empty).Replace("?", string.Empty).Replace("<", string.Empty).Replace(">", string.Empty).Replace(".", "_");
        }

        public static object FromXml(string Xml, System.Type ObjType)
        {
            XmlSerializer __ser = new XmlSerializer(ObjType);
            StringReader __stringReader;
            __stringReader = new StringReader(Xml);
            XmlReader __xmlReader = XmlReader.Create(__stringReader);
            object obj = __ser.Deserialize(__xmlReader);
            __xmlReader.Close();
            __stringReader.Close();
            return obj;
        }

    }

    public class _PermissionsType
    {

        /// <summary>
        /// เข้าใช้งานได้
        /// </summary>
        public bool _isRead;
        /// <summary>
        /// เพิ่มได้
        /// </summary>
        public bool _isAdd;
        /// <summary>
        /// แก้ไขได้
        /// </summary>
        public bool _isEdit;
        /// <summary>
        /// ลบได้
        /// </summary>
        public bool _isDelete;
    }


    class _myDatabaseType
    {
        public string _codeOld { get; set; }
        public string _code { get; set; }
        public string _name { get; set; }
        public string _databaseGroup { get; set; }
    }


    public class _myWebserviceType
    {
        public string _webServiceName = "";
        public bool _webServiceConnected = false;
        public int _connectBytesPerSecond = 100000;
    }

    class _myGroupMemberType
    {
        public ArrayList _userCode { get; set; }
    }

    class _myDatabaseGroupType
    {
        public string _code { get; set; }
        public string _name { get; set; }
        public ArrayList _adminList { get; set; }
    }


    public class _providerListClass
    {
        public string _name;
        public _myGlobal._databaseType _databaseType;
    }

}
