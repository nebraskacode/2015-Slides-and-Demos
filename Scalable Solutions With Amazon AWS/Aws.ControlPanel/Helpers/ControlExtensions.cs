using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Aws.ControlPanel.Helpers
{
    public static class ControlExtensions
    {
        public static void UIThread(this Control @this, Action code)
        {
            try
            {
                if (@this.InvokeRequired)
                {
                    @this.BeginInvoke(code);
                }
                else
                {
                    @this.Invoke((MethodInvoker)(() => code()));
                }
            }
            catch (Exception)
            {
            }
        }
    }
}