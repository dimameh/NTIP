using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO: неправильное название проекта: MainWindow - это одно окно, а не проект
//TODO: пространство имен не совпадает с именем проекта!
namespace WindowsFormsApp1
{
    //TODO: имя решения не должно содержать пробелов!
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}
	}
}
