using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public class _myResource
    {
        public static _myResourceType _findResource(string code, string text, bool autoInsertResult = false)
        {
            _myResourceType fineResult = new _myResourceType
            {
                _str = text,
                _length = text.Length
            };

            return fineResult;
        }

    }

    public class _myResourceType
    {
        public string _str = "";
        public int _length = 0;
    }
}
