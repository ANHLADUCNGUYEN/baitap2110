using System;
using System.Windows.Forms;

namespace Bai4_6_StudentManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmStudentManager());
        }
    }
}
