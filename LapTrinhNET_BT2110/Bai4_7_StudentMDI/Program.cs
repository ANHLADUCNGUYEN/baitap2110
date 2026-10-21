using System;
using System.Windows.Forms;

namespace Bai4_7_StudentMDI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}
