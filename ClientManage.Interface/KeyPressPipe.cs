using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ClientManage.Interfaces
{
    public class KeyPressPipe
    {
        public event EventHandler<KeyPressPipeEventArgs> MatchFound;

        private readonly KeyPressPattern[] _patterns;
        private readonly List<KeySnap> _list;
        private readonly int _pipeSize;
        private readonly int _delay;

        public KeyPressPipe(KeyPressPattern[] patterns, int pipeSize, int delay)
        {
            _patterns = patterns;
            _pipeSize = pipeSize;
            _delay = delay;
            _list = new List<KeySnap>();
        }

        public void Push(char pressChar)
        {
            Trace.TraceInformation("KeyPressPipe: " + pressChar);
            Console.WriteLine("KeyPressPipe: " + pressChar);
            while (_list.Count >= _pipeSize)
            {
                _list.RemoveAt(0);
            }
            _list.Add(new KeySnap(pressChar));
            SeekMatch();
        }

        private void SeekMatch()
        {
            Regex regex;
            Match match;
            var isMatch = false;
            var value = this.ToString();

            Trace.TraceInformation("KeyPressPipe: " + value);
            Console.WriteLine("KeyPressPipe: " + value);

            foreach (var p in _patterns)
            {
                regex = new Regex(p.Pattern);
                match = regex.Match(value);
                if (match.Success)
                {
                    Trace.TraceInformation("Match Success");
                    var totalTicks = _list[match.Index + match.Value.Length - 1].Ticks - _list[match.Index].Ticks;                                       
                    if (_delay == 0 || totalTicks <= _delay)
                    {
                        Trace.TraceInformation("Match Found");
                        isMatch = true;
                        if (MatchFound != null) MatchFound(this, new KeyPressPipeEventArgs(match.Value, p, totalTicks));
                    }
                }
            }
            if(isMatch) _list.Clear();
        }

        public override string ToString()
        {
            var text = string.Empty;
// ReSharper disable LoopCanBeConvertedToQuery
            foreach (var k in _list)
// ReSharper restore LoopCanBeConvertedToQuery
            {
                text += k.KeyChar.ToString();
            }
            return text;
        }
    }

    public class KeySnap
    {
        public KeySnap(char keyChar)
        {
            KeyChar = keyChar;
            Ticks = DateTime.Now.Ticks;
        }

        public char KeyChar { get; set; }

        public long Ticks { get; private set; }
    }

    public class KeyPressPipeEventArgs : EventArgs
    {
        internal KeyPressPipeEventArgs(string value, KeyPressPattern pattern, long totalTicks)
        {
            Value = value;
            Pattern = pattern;
            TotalTicks = totalTicks;
        }

        public string Value { get; private set; }

        public KeyPressPattern Pattern { get; private set; }

        public long TotalTicks { get; private set; }
    }

    public class KeyPressPattern
    {
        private readonly string _pattern;
        private readonly int _formIndex;
        private readonly int _length;

        public KeyPressPattern(string pattern, int size)
        {
            _pattern = pattern + @"\d{" + size + "}";
            _formIndex = pattern.Length;
            _length = size;
        }

        public string Pattern
        {
            get { return _pattern; }
        }
        public int FromIndex
        {
            get { return _formIndex; }
        }
        public int Length
        {
            get { return _length; }
        }
    }
}