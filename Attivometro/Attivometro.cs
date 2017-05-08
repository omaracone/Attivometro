using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttivometroDataManager;

namespace Attivometro
{
    public partial class Attivometro : Form
    {
        public Attivometro()
        {
            InitializeComponent();
     
            AttivometroDataObject data = new AttivometroDataObject();

        }
    }
}
