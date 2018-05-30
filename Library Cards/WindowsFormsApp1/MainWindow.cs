using LibraryCards;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			List<ICard> cardList;
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void AddButtonClick(object sender, EventArgs e)
		{
			AddRecord newRecordForm = new AddRecord();
			newRecordForm.Show();
		}

		private void RemoveButtonClick(object sender, EventArgs e)
		{

		}
	}
}
