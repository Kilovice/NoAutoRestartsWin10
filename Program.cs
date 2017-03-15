using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using Microsoft.Win32;

namespace NoAutoRestartsWin10
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            OpenForm(IsAdministrator());
        }

        public static void OpenForm(bool b) {
            if (b)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new Form2());
            }
                
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        //Check to see if the registry key exists
        public static bool DoesWindowsUpdateExist() {
            bool rt = false;
            string key = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU";
            string value = "NoAutoRebootWithLoggedOnUsers";
            if (Registry.GetValue(key, value, null) != null)
            {
                rt = true;
            }
            return rt;
        }

        //Create the necessary registry keys if they don't already exist
        public static void RegistryCreateIfNotExist() {
            if (!DoesWindowsUpdateExist())
            {
                string key = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU";
                string value1 = "DetectionFrequency";
                string value2 = "DetectionFrequencyEnabled";
                string value3 = "NoAutoRebootWithLoggedOnUsers";

                Registry.SetValue(key, value1, 1, RegistryValueKind.DWord);
                Registry.SetValue(key, value2, 1, RegistryValueKind.DWord);
                Registry.SetValue(key, value3, 0, RegistryValueKind.DWord);
                RegistryMod();
            }
            else
            {
                RegistryMod();

            }
           
        }

        //Edit necessary registry key
        public static void RegistryMod()
        {
            string key = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU";
            string value = "NoAutoRebootWithLoggedOnUsers";
            Registry.SetValue(key, value, 1, RegistryValueKind.DWord);
            Form5 f5 = new Form5();
            f5.Show();
        }

        public static void ForceReboot()
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }

        public static void ForceExit() {
            Application.Exit();
        }
    }
}
