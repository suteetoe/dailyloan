using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace SMLWebService
{
    public class _datasetExtension
    {
        public static DataSet _convertStringToDataSet(string source)
        {

            // ดัก error text ด้วยนะ

            DataSet __ds = new DataSet();
            try
            {
                source = _sanitizeXmlString(source);

                XmlTextReader __readXml = new XmlTextReader(new StringReader(source));
                // Convert MDataSet into a standard ADO.NET DataSet
                __ds.ReadXml(__readXml, XmlReadMode.InferSchema);
                if (__ds.Tables.Count == 0)
                {
                    DataTable __table = new DataTable();
                    __ds.Tables.Add(__table);
                }
            }
            catch (Exception e)
            {
                string __error = e.Message;
            }
            return __ds;
        }

        /// <summary>
        /// Remove illegal XML characters from a string.
        /// </summary>
        public static string _sanitizeXmlString(string xml)
        {
            if (xml == null)
            {
                throw new ArgumentNullException("xml");
            }

            StringBuilder buffer = new StringBuilder(xml.Length);

            foreach (char c in xml)
            {
                if (_isLegalXmlChar(c))
                {
                    buffer.Append(c);
                }
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Whether a given character is allowed by XML 1.0.
        /// </summary>
        public static bool _isLegalXmlChar(int character)
        {
            return
            (
                 character == 0x9 /* == '\t' == 9   */          ||
                 character == 0xA /* == '\n' == 10  */          ||
                 character == 0xD /* == '\r' == 13  */          ||
                (character >= 0x20 && character <= 0xD7FF) ||
                (character >= 0xE000 && character <= 0xFFFD) ||
                (character >= 0x10000 && character <= 0x10FFFF)
            );
        }
    }
}
