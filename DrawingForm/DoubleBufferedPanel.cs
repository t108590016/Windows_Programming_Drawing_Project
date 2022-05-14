using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            DoubleBuffered = true;
        }

        public bool IsDoubleBuffer
        {
            get
            {
                return DoubleBuffered;
            }
            set
            {
                DoubleBuffered = value;
            }
        }
    }
}
