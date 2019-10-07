using System.Collections.Generic;
using System.Data;


namespace ClientManage.BL.Library
{
    public class StringTokenFormat
    {
        private readonly List<object> _list = new List<object>();
        private int _startIndex;

        public string FormatString(string pattern, DataRow row)
        {
            _startIndex = 0;
            var token = GetToken(pattern);
            string targetString;

            while (token != null)
            {
                targetString = token.GetTargetString(_list.Count);
                pattern = pattern.Replace(token.SourceString, targetString);
                _list.Add(GetValue(row, token));
                _startIndex += targetString.Length;
                token = GetToken(pattern);
            }

            return string.Format(pattern, _list.ToArray());
        }

        private Token GetToken(string pattern)
        {
            var start = pattern.IndexOf("{", _startIndex);
            var end = pattern.IndexOf("}", _startIndex);
            Token token = null;

            if (start >= 0 && end > 0 && end - start > 0)
            {
                var toketString = pattern.Substring(start + 1, end - start - 1);
                token = new Token(toketString);
                _startIndex = start;
            }

            return token;
        }

        private static object GetValue(DataRow row, Token token)
        {
            object value = null;

            if (row.Table.Columns.IndexOf(token.Value) >= 0)
            {
                value = row[token.Value];
            }

            return value;
        }
    }

    public class Token
    {
        private readonly string _tokenString;

        public Token(string tokenString)
        {
            _tokenString = tokenString;
            var pos = tokenString.IndexOf(':');
            if (pos > 0)
            {
                _value = tokenString.Substring(0, pos);
                _format = tokenString.Substring(pos + 1);
            }
            else
            {
                _value = tokenString;
            }
        }

        private readonly string _value;
        public string Value
        {
            get { return _value; }
        }

        private readonly string _format = string.Empty;
        public string Format
        {
            get { return _format; }
        }

        public string SourceString
        {
            get { return "{" + _tokenString + "}"; }
        }

        public string GetTargetString(int index)
        {
            string format;

            if (_format.Length > 0)
            {
                format = "{" + index + ":" + _format + "}";
            }
            else
            {
                format = "{" + index + "}";
            }

            return format;
        }
    }
}
