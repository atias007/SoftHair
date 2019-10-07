using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using DirectShowLib;
using System.Runtime.InteropServices;
using System.Drawing;

namespace BizCare.WebCam
{
    public class WebCamViewer
    {
        #region Private Memebers

        private readonly PictureBox _container = null;
        private readonly int d = Convert.ToInt32("0X8000", 16);
        private readonly int WM_GRAPHNOTIFY;
        private IVideoWindow _videoWindow = null;
        private IMediaControl _mediaControl = null;
        private IMediaEventEx _mediaEventEx = null;
        private IGraphBuilder _graphBuilder = null;
        private ICaptureGraphBuilder2 _captureGraphBuilder = null;
        private DsROTEntry _rot = null;

        #endregion

        #region Constructor

        public WebCamViewer(PictureBox container)
        {
            WM_GRAPHNOTIFY = d + 1;
            _container = container;
            _container.SizeChanged += new EventHandler(_container_SizeChanged);
        }

        #endregion

        #region Container Events

        void _container_SizeChanged(object sender, EventArgs e)
        {
            ResizeVideoWindow();
        }

        #endregion

        #region Public Methods

        public Image GetImage()
        {
            var sc = new ScreenCapture();
            var image = sc.CaptureWindow(_container.Handle);
            return image;
        }

        public void CaptureVideo()
        {
            try
            {
                DoCaptureVideo();
            }
            catch (Exception)
            {
                this.Close();
                throw;
            }
        }

        public void WndProc(ref Message m)
        {
            if (m.Msg == WM_GRAPHNOTIFY)
            {
                HandleGraphEvent();
            }
            if (!(this._videoWindow == null))
            {
                this._videoWindow.NotifyOwnerMessage(m.HWnd, m.Msg, m.WParam.ToInt32(), m.LParam.ToInt32());
            }
        }

        public void Close()
        {
            ////stop previewing data
            if (!(this._mediaControl == null))
            {
                this._mediaControl.StopWhenReady();
            }

            ////stop recieving events
            if (!(this._mediaEventEx == null))
            {
                this._mediaEventEx.SetNotifyWindow(IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero);
            }

            //// Relinquish ownership (IMPORTANT!) of the video window.
            //// Failing to call put_Owner can lead to assert failures within
            //// the video renderer, as it still assumes that it has a valid
            //// parent window.
            if (!(this._videoWindow == null))
            {
                this._videoWindow.put_Visible(OABool.False);
                this._videoWindow.put_Owner(IntPtr.Zero);
            }

            // // Remove filter graph from the running object table
            if (!(_rot == null))
            {
                _rot.Dispose();
                _rot = null;
            }

            //// Release DirectShow interfaces
            if (this._mediaControl != null)
            {
                Marshal.ReleaseComObject(this._mediaControl);
                this._mediaControl = null;
            }
            if (this._mediaEventEx != null)
            {
                Marshal.ReleaseComObject(this._mediaEventEx);
                this._mediaEventEx = null;
            }
            if (this._videoWindow != null)
            {
                Marshal.ReleaseComObject(this._videoWindow);
                this._videoWindow = null;
            }
            if (this._graphBuilder != null)
            {
                Marshal.ReleaseComObject(this._graphBuilder);
                this._graphBuilder = null;
            }
            if (this._captureGraphBuilder != null)
            {
                Marshal.ReleaseComObject(this._captureGraphBuilder);
                this._captureGraphBuilder = null;
            }
        }

        public void Run()
        {
            if (_mediaControl != null)
            {
                _mediaControl.Run();
            }
        }

        public void Stop()
        {
            if (_mediaControl != null)
            {
                _mediaControl.StopWhenReady();
            }
        }

        public void Pause()
        {
            if (_mediaControl != null)
            {
                _mediaControl.Pause();
            }
        }

        #endregion

        #region Private Functions

        private void DoCaptureVideo()
        {
            var hr = 0;
            IBaseFilter sourceFilter = null;

            GetInterfaces();

            hr = this._captureGraphBuilder.SetFiltergraph(this._graphBuilder);

            //Specifies filter graph "graphbuilder" for the capture graph builder "captureGraphBuilder" to use.
            DsError.ThrowExceptionForHR(hr);

            sourceFilter = FindCaptureDevice();

            hr = this._graphBuilder.AddFilter(sourceFilter, "Video Capture");
            DsError.ThrowExceptionForHR(hr);

            hr = this._captureGraphBuilder.RenderStream(PinCategory.Preview, MediaType.Video, sourceFilter, null, null);
            DsError.ThrowExceptionForHR(hr);

            Marshal.ReleaseComObject(sourceFilter);

            SetupVideoWindow();

            _rot = new DsROTEntry(this._graphBuilder);

            hr = this._mediaControl.Run();
            DsError.ThrowExceptionForHR(hr);
        }

        private void ResizeVideoWindow()
        {
            if (this._videoWindow != null)
            {
                this._videoWindow.SetWindowPosition(0, 0, _container.Width, _container.Height);
            }
        }

        private void GetInterfaces()
        {
            var hr = 0;
            this._graphBuilder = (IGraphBuilder)new FilterGraph();
            this._captureGraphBuilder = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
            this._mediaControl = (IMediaControl)this._graphBuilder;
            this._videoWindow = (IVideoWindow)this._graphBuilder;
            this._mediaEventEx = (IMediaEventEx)this._graphBuilder;
            hr = this._mediaEventEx.SetNotifyWindow(_container.Handle, WM_GRAPHNOTIFY, IntPtr.Zero);

            //This method designates a window as the recipient of messages generated by or sent to the current DirectShow object
            DsError.ThrowExceptionForHR(hr);

            //ThrowExceptionForHR is a wrapper for Marshal.ThrowExceptionForHR, but additionally provides descriptions for any DirectShow specific error messages.If the hr value is not a fatal error, no exception will be thrown:
        }

        private IBaseFilter FindCaptureDevice()
        {
            var hr = 0;
            UCOMIEnumMoniker classEnum = null;
            var moniker = new UCOMIMoniker[1];
            object source = null;
            var devEnum = (ICreateDevEnum)(new CreateDevEnum());
            hr = devEnum.CreateClassEnumerator(FilterCategory.VideoInputDevice, out classEnum, (CDef)0);
            DsError.ThrowExceptionForHR(hr);
            Marshal.ReleaseComObject(devEnum);
            if (classEnum == null)
            {
                throw new ApplicationException("No video capture device was detected.\r\n\r\n" +
                               "This sample requires a video capture device, such as a USB WebCam,\r\n" +
                               "to be installed and working properly.  The sample will now close.");
            }
            var i = 0;
            if (classEnum.Next(moniker.Length, moniker, out i) == 0)
            {
                var iid = typeof(IBaseFilter).GUID;
                moniker[0].BindToObject(null, null, ref iid, out source);
            }
            else
            {
                throw new ApplicationException("Unable to access video capture device!");
            }
            Marshal.ReleaseComObject(moniker[0]);
            Marshal.ReleaseComObject(classEnum);
            return (IBaseFilter)source;
        }

        private void SetupVideoWindow()
        {
            var hr = 0;
            //set the video window to be a child of the main window
            //putowner : Sets the owning parent window for the video playback window. 
            hr = this._videoWindow.put_Owner(_container.Handle);
            DsError.ThrowExceptionForHR(hr);

            hr = this._videoWindow.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipChildren);
            DsError.ThrowExceptionForHR(hr);

            //Use helper function to position video window in client rect of main application window
            ResizeVideoWindow();

            //Make the video window visible, now that it is properly positioned
            //put_visible : This method changes the visibility of the video window. 
            hr = this._videoWindow.put_Visible(OABool.True);
            DsError.ThrowExceptionForHR(hr);
        }

        private void HandleGraphEvent()
        {
            var hr = 0;
            EventCode evCode;
            int evParam1;
            int evParam2;
            if (this._mediaEventEx == null)
            {
                return;
            }
            while (this._mediaEventEx.GetEvent(out evCode, out evParam1, out evParam2, 0) == 0)
            {
                //// Free event parameters to prevent memory leaks associated with
                //// event parameter data.  While this application is not interested
                //// in the received events, applications should always process them.
                hr = this._mediaEventEx.FreeEventParams(evCode, evParam1, evParam2);
                DsError.ThrowExceptionForHR(hr);

                //// Insert event processing code here, if desired
            }
        }

        #endregion
    }
}
