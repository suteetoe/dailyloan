using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data
{
    public class AutoRunning
    {
        string docTypeCode;
        string runningFormat;
        DateTime runningDate;
        string formatNumber = "";
        int numberDigitBegin = -1;
        int numberDigitEnd = -1;
        string docFormatPattern = "";

        public AutoRunning(string docTypeCode, string format, DateTime date)
        {
            this.docTypeCode = docTypeCode;
            this.runningFormat = format;
            this.runningDate = date;

            buildDocPattern();
        }

        void buildDocPattern()
        {
            string __getFormat = this.runningFormat;


            DateTime __date = this.runningDate;


            CultureInfo __dateUSZone = new CultureInfo("en-US");
            CultureInfo __dateTHZone = new CultureInfo("th-TH");
            __getFormat = __getFormat.Replace("DD", __date.ToString("dd", __dateUSZone));
            __getFormat = __getFormat.Replace("MM", __date.ToString("MM", __dateUSZone));
            __getFormat = __getFormat.Replace("YYYY", __date.ToString("yyyy", __dateUSZone));
            __getFormat = __getFormat.Replace("YY", __date.ToString("yy", __dateUSZone));
            __getFormat = __getFormat.Replace("วว", __date.ToString("dd", __dateTHZone));
            __getFormat = __getFormat.Replace("ดด", __date.ToString("MM", __dateTHZone));
            __getFormat = __getFormat.Replace("ปปปป", __date.ToString("yyyy", __dateTHZone));
            __getFormat = __getFormat.Replace("ปป", __date.ToString("yy", __dateTHZone));

            __getFormat = __getFormat.Replace("@", this.docTypeCode);

            int __numberBegin = __getFormat.IndexOf("#");
            if (__numberBegin != -1)
            {
                StringBuilder __getFormatNumber = new StringBuilder();
                int __numberEnd = __numberBegin;
                while (__numberEnd < __getFormat.Length && __getFormat[__numberEnd] == '#')
                {
                    __getFormatNumber.Append("0");
                    __numberEnd++;
                }
                __getFormat = __getFormat.Remove(__numberBegin, __numberEnd - __numberBegin);
                this.formatNumber = __getFormatNumber.ToString();
                this.docFormatPattern = __getFormat;
                this.numberDigitBegin = __numberBegin;
                this.numberDigitEnd = __numberEnd;

            }
        }

        public string NextRunningQuery(string tableName, string fieldName, string extraWhere = "")
        {

            string docPattern = this.docFormatPattern.Insert(this.numberDigitBegin, "%");
            StringBuilder where = new StringBuilder(fieldName + " like '" + docPattern + "' ");
            if (extraWhere.Length > 0)
            {
                where.Append(" AND " + extraWhere);
            }
            string query = "select " + fieldName + " from " + tableName + " where " + where.ToString() + " order by " + fieldName + " desc limit 1 ";
            return query;
        }

        public String NextRunning(string lastDocNo)
        {
            int __runningNumber = 0;
            if (lastDocNo.Length >= numberDigitEnd)
            {
                string checkDocMatch = lastDocNo.Remove(this.numberDigitBegin, numberDigitEnd - this.numberDigitBegin);
                // check match 
                if (checkDocMatch.Equals(this.docFormatPattern))
                {
                    string __docRun = lastDocNo.Substring(this.numberDigitBegin, numberDigitEnd - this.numberDigitBegin);
                    __runningNumber = int.Parse(__docRun);
                }
            }


            //if (this.startRunningDoc != "" && this.startRunningDoc.Length >= this.numberDigitEnd)
            //{
            //    // start doc 0 หรือ start default
            //    string defaultDocMatch = this.startRunningDoc.Remove(this.numberDigitBegin, this.numberDigitEnd - this.numberDigitBegin);
            //    if (defaultDocMatch.Equals(this.docFormatPattern))
            //    {
            //        //return this.startRunningDoc;
            //        string __docRun = startRunningDoc.Substring(this.numberDigitBegin, numberDigitEnd - this.numberDigitBegin);
            //        __runningNumber = int.Parse(__docRun);
            //    }
            //}

            __runningNumber++;
            string NextNumber = String.Format("{0:" + this.formatNumber.Remove(0, 1) + "#}", __runningNumber);

            if (NextNumber.Length > numberDigitEnd - this.numberDigitBegin)
            {
                NextNumber = String.Format("{0:" + this.formatNumber.Remove(0, 1) + "#}", 1);
            }

            string newDocNo = this.docFormatPattern.Insert(this.numberDigitBegin, NextNumber);
            return newDocNo;
        }

    }
}
