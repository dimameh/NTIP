using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CardListApp
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (IsAssociated())
			{
				Associate();
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (args.Length == 0)
			{
				Application.Run(new MainForm());
			}
			else
			{
				Application.Run(new MainForm(args[0]));
			}
		}

		public static bool IsAssociated()
		{
			return Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.cardDB", false) == null;
		}

		public static void Associate()
		{
            //TODO: Вообще, это всё делается в скрипте InnoSetup
			RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\.cardDB");
			RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\LibraryCardsTable.exe");
			RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.cardDB");

			FileReg.CreateSubKey("DefaultIcon").SetValue("","ico.ico");
			FileReg.CreateSubKey("PerceivedType").SetValue("","Text");

			AppReg.CreateSubKey("shell\\open\\command").SetValue("","\"" + Application.ExecutablePath + "\" %1");
			AppReg.CreateSubKey("shell\\edit\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
			AppReg.CreateSubKey("DefaultIcon").SetValue("","ico.ico");

			AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\LibraryCardsTable.exe");

			SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
		}

		[DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
	}
}
