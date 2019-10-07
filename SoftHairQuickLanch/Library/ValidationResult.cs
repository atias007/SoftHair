using System;
using System.Collections.Generic;
using System.Text;

namespace SoftHairQuickLanch
{
    public class ValidationResult
    {
        private readonly List<string> _list = new List<string>();

        public string this[int index]
        {
            get { return _list[index]; }
        }
        public void Add(string message)
        {
            _list.Add(message);
        }
        public int Count
        {
            get { return _list.Count; }
        }
        public bool Contains(string message)
        {
            return _list.Contains(message);
        }
        public int IndexOf(string message)
        {
            return _list.IndexOf(message);
        }
        public void Clear()
        {
            _list.Clear();
        }
        public bool HasResult
        {
            get { return _list.Count > 0; }
        }
        public override string  ToString()
        {
            var m = string.Empty;
            foreach (var msg in _list)
            {
                m += "\t• " + msg + "\n";
            }
            return m;
        }
    }
}
