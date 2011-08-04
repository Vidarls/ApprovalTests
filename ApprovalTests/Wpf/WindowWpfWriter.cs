using System;
using System.Windows;
using ApprovalTests.Core;
using ApprovalUtilities.Wpf;

namespace ApprovalTests.Wpf
{
    public class WindowWpfWriter : IApprovalWriter
    {

        public delegate T Loader<T>();
				private readonly Func<Window> Action;

				public WindowWpfWriter(Func<Window> action)
        {
            Action = action;
        }


        public string GetApprovalFilename(string basename)
        {
            return basename + ".approved.png";
        }

        public string GetReceivedFilename(string basename)
        {
            return basename + ".received.png";
        }

        public string WriteReceivedFile(string received)
        {
        	return WpfUtils.ScreeenCaptureInStaThread(received, Action);
        }
    }
}