using System;
using System.Collections.Generic;
using System.Text;

namespace SoftHairQuickLanch
{
    public class CommandLineArguments
    {
        private readonly List<string> _list = new List<string>();

        public CommandLineArguments(string[] args)
        {
            foreach (var value in args)
            {
                _list.Add(value.ToLower());
            }
        }

        public string this[int index]
        {
            get { return (string)_list[index]; }
            set { _list[index] = value; }
        }

        public void Remove(string value)
        {
            _list.Remove(value);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public bool Contains(string value)
        {
            return _list.Contains(value);
        }

        public int IndexOf(string value)
        {
            return _list.IndexOf(value);
        }
    }
}
