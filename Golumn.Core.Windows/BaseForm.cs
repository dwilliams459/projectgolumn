using Golumn.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golumn.Core.Windows
{

    public class BaseForm : Form
    {
        protected TimeEventsContext _ctx { get; set; }

        public BaseForm()
        {
            _ctx = new TimeEventsContext();
        }


    }
}
