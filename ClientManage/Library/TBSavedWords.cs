using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.Library
{
    public class TBSavedWords
    {
        private readonly TextBox _textBox;
        private string _lastValue = string.Empty;

        public TBSavedWords(TextBox textBox)
        {
            _textBox = textBox;
            _lastValue = _textBox.Text;
            _textBox.KeyPress += new KeyPressEventHandler(_textBox_KeyPress);
            _textBox.KeyDown += new KeyEventHandler(_textBox_KeyDown);
        }

        void _textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (_textBox.Text[_textBox.SelectionStart] == '{') _textBox.SelectionStart++;
                    e.Handled = DetectClearWord(Char.MinValue);
                }
                catch { }
            }
        }

        void _textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try { e.Handled = DetectClearWord(e.KeyChar); }
            catch { }
        }

        private bool DetectClearWord(char key)
        {
            var handled = false;

            if (key == '{' || key == '}')
            {
                handled = true;
            }
            else
            {
                if (key == '\b')
                {
                    if (_textBox.SelectionStart > 0 && _textBox.Text[_textBox.SelectionStart - 1].Equals('}'))
                    {
                        _textBox.SelectionStart--;
                    }
                }
                if (_textBox.Text.Length > 0)
                {
                    var rep = ClearDeletedWord(_textBox.SelectionStart);
                    if (_textBox.SelectionLength > 0)
                    {
                        rep = rep || ClearDeletedWord(_textBox.SelectionStart + _textBox.SelectionLength);
                    }
                    if (rep && key == '\b') handled = true;
                }
            }

            return handled;
        }

        private bool ClearDeletedWord(int startPos)
        {
            var iStart = GetOpenBrekate(startPos);
            var iEnd = GetCloseBrekate(startPos);
            var ret = false;

            if (iStart != -1 && iEnd != -1)
            {
                var word = _textBox.Text.Substring(iStart, iEnd - iStart + 1);
                _textBox.Text = _textBox.Text.Substring(0, iStart) + _textBox.Text.Substring(iEnd + 1);
                _textBox.SelectionStart = iStart;
                ret = true;
            }
            return ret;
        }
        private int GetOpenBrekate(int startPoint)
        {
            var _text = _textBox.Text;
            for (var i = startPoint-1; i >= 0; i--)
            {
                if (_text[i].Equals('{')) return i;
                if (_text[i].Equals('}')) break;
            }
            return -1;
        }
        private int GetCloseBrekate(int startPoint)
        {
            var _text = _textBox.Text;
            for (var i = startPoint; i < _text.Length; i++)
            {
                if (_text[i].Equals('}')) return i;
                if (_text[i].Equals('{')) break;
            }
            return -1;
        }
       
        //private bool IsSavedWord(string value)
        //{
        //    foreach (string word in _savedWord)
        //    {
        //        if (word.Equals(value)) return true;
        //    }
        //    return false;
        //}
    }
}
