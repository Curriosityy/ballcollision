using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DouBuf
{
    class MojPanel:Panel
    {
        public MojPanel():base()
        {
            DoubleBuffered = true;
        }
    }
}
