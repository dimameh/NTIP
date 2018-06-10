using System.Drawing;
using System.Windows.Forms;
using LibraryCards;

namespace CardListApp
{
	public partial class AddRecordForm : Form
	{
		public AddRecordForm()
		{
			InitializeComponent();
            //TODO: Иконка отваливается при открытии формы
            //Icon = new Icon("ico.ico");
        }

        public ICard NewCard
		{
			get => cardControl1.Card;
			set => cardControl1.Card = value;
		}

		public bool ReadOnly
		{
			set => cardControl1.ReadOnly = value;
		}
	}
}