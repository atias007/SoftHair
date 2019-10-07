using System.IO.Ports;
using System;

namespace ClientManage.BL.Library
{
    public class ComPort
    {
        public delegate void CommCallHandler(object sender, CommCallEventArgs e);
        public event CommCallHandler CommIncomeData;

        #region Private Members

        //private bool bError;
        private string _sEvent = string.Empty;
        private readonly SerialPort _port;
        //private string _initCallerIdCommand = string.Empty;


        #endregion

        public ComPort()
        {
            _port = new SerialPort();
            _port.DataReceived += PortDataReceived;
        }

        public ComPort(string portName, int boundRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _port = new SerialPort(portName, boundRate, parity, dataBits, stopBits);
            _port.DataReceived += PortDataReceived;
        }

        public void CommCallEvent(object sender, CommCallEventArgs e)
        {
            if (CommIncomeData != null) CommIncomeData(sender, e);
        }

        #region Public Properties

        public bool IsConnected
        {
            get { return _port.IsOpen; }
        }

        public SerialPort Port
        {
            get { return _port; }
        }

        #endregion

        #region Public Methods

        public void Connect()
        {
            _port.Open();
            _port.DtrEnable = true;
            _port.RtsEnable = true;
            //bError = false;
            //SendCommand("atz");   // Send command to put Identifier in event mode and receive serial number
            //Wait();

            //if (bError)
            //{
            //    _port.Close();     // Close the port and update app UI
            //    throw new Exception("Port " + _port.PortName + ": Modem not Caller ID enabled");
            //}
        
        }

        public void Disconnect()
        {
            _port.Close();
        }

        public void SendCommand(string command)
        {
            _port.WriteLine(command + "\r");
            Wait();
        }

        #endregion

        #region Private Functions

        private static void Wait()
        {
            System.Threading.Thread.Sleep(300);
            //System.Windows.Forms.Application.DoEvents();
        }

        private void ProcessEvent(string stEvent)
        {
            switch (stEvent)
            {
                case "OK":
                    if (CommIncomeData != null)
                        CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Ok, string.Empty, _sEvent));
                    break;

                case "ERROR":
                    //bError = true;
                    if (CommIncomeData != null)
                        CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Error, string.Empty, _sEvent));
                    break;

                case "RING":
                    if (CommIncomeData != null)
                        CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Ring, string.Empty, _sEvent));
                    break;

                case "BUSY":
                    if (CommIncomeData != null)
                        CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Busy, string.Empty, _sEvent));
                    break;

                case "NO CARRIER":
                    if (CommIncomeData != null)
                        CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.NoCarrier, string.Empty, _sEvent));
                    break;

                case "NO DIALTONE":
                    if (CommIncomeData != null)
                        CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.NoDialTone, string.Empty, _sEvent));
                    break;
                
                case "NO ANSWER":
                    if (CommIncomeData != null)
                        CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.NoAnswer, string.Empty, _sEvent));
                    break;

                case "CONNECT":
                    if (CommIncomeData != null)
                        CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Connect, string.Empty, _sEvent));
                    break;

                default:
                    if (_sEvent.Length < 4)
                    {
                        if (CommIncomeData != null)
                            CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Unknown, string.Empty, _sEvent));
                    }
                    else
                    {
                        var param = string.Empty;
                        _sEvent = _sEvent.Replace(" ", string.Empty);
                        if (_sEvent.Length > 5) param = _sEvent.Substring(5);
                        switch (stEvent.Substring(0, 4))
                        {
                            case "TIME":
                                if (CommIncomeData != null)
                                    CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Time, param, _sEvent));
                                break;
                            case "DATE":
                                if (CommIncomeData != null)
                                    CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Date, param, _sEvent));
                                break;
                            case "NMBR":
                                if (CommIncomeData != null)
                                    CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Number, param, _sEvent));
                                break;
                            case "NAME":
                                if (CommIncomeData != null)
                                    CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Name, param, _sEvent));
                                break;
                            default:
                                if (CommIncomeData != null)
                                    CommIncomeData(this, new CommCallEventArgs(CommCallEventArgs.CommCallEventType.Unknown, string.Empty, _sEvent));
                                break;
                        }
                    }
                    break;
            }
        }

        #endregion

        #region Internal Events

        void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            char cInput;
            //string val = _port.ReadLine();

            if (e.EventType == SerialData.Chars)
            {
                do
                {
                    cInput = (char)(_port.ReadChar());

                    switch (cInput)
                    {
                        case '\n':
                            break;

                        case '\r':
                            if (_sEvent.Length > 0)
                            {
                                ProcessEvent(_sEvent);
                                _sEvent = string.Empty;
                            }
                            break;

                        default:
                            _sEvent += cInput.ToString();
                            break;
                    }
                } while (_port.BytesToRead > 0);

                Port.DiscardInBuffer();
                Port.DiscardOutBuffer();
            }
        }

        #endregion
    }

    public class CommCallEventArgs : EventArgs
    {
        public enum CommCallEventType { Unknown, Ok, Error, Busy, NoCarrier, NoDialTone, NoAnswer, Connect, Ring, Time, Date, Number, Name };
        private readonly CommCallEventType _type;
        private readonly string _modemData = string.Empty;
        private readonly string _eventData = string.Empty;

        public CommCallEventArgs(CommCallEventType type, string eventData, string modemData)
        {
            _type = type;
            _eventData = eventData;
            _modemData = modemData;
        }

        public string EventData
        {
            get { return _eventData; }
        }

        public CommCallEventType Type
        {
            get { return _type; }
        }
        
        public string ModemData
        {
            get { return _modemData; }
        }
    }
}
