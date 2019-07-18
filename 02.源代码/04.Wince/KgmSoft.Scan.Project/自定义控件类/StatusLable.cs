using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace KgmSoft.Scan.Project
{
    public class StatusLable
    {
        private Label _label = null;
        public StatusLable(Label label)
        {
            _label = label;
        }

        public void UpdateMessage(string msg)
        {
            try
            {
                _label.Text = msg.PadRight(20);
                _label.Update();

                Thread.Sleep(200);//用于演示效果.
            }
            catch
            { 
            
            }
        }
    }
}
