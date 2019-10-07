using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.Interfaces
{
    public class ProcProgress
    {
        public event EventHandler ValueChanged;
        public event EventHandler MaximumChanged;

        private int _value = 0;
        private int _maximum = 0;

        public ProcProgress() { }
        public ProcProgress(int maximum) { _maximum = maximum; }

        public int Maximum
        {
            get { return _maximum; }
            set 
            {
                if (_maximum != value)
                {
                    _maximum = value;
                    if (MaximumChanged != null) MaximumChanged(this, new EventArgs());
                }
            }
        }

        public int Value
        {
            get { return _value; }
            set 
            {
                if (_value != value)
                {
                    _value = value;
                    if (ValueChanged != null) ValueChanged(this, new EventArgs());
                }
            }
        }

        public void IncreaseValue()
        {
            _value++;
            if (ValueChanged != null) ValueChanged(this, new EventArgs());
        }

        public void DecreaseValue()
        {
            _value--;
            if (ValueChanged != null) ValueChanged(this, new EventArgs());
        }

        public double PercentValue
        {
            get 
            {
                if (_maximum == 0) return 0;
                return Convert.ToDouble(Value) / _maximum; 
            }
        }
    }
}
