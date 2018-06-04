using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One_Time_Pad_CS{
    static class Program{
        [STAThread]
        static void Main(){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new otp());
        }
    }
}
