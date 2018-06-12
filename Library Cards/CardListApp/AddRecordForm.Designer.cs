namespace CardListApp
{
	partial class AddRecordForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecordForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CollectionRadioButton = new System.Windows.Forms.RadioButton();
			this.JournalRadioButton = new System.Windows.Forms.RadioButton();
			this.DissertationRadioButton = new System.Windows.Forms.RadioButton();
			this.BookRadioButton = new System.Windows.Forms.RadioButton();
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.RandomButton = new System.Windows.Forms.Button();
			this.journalControl = new CardListApp.JournalControl();
			this.dissertationControl = new CardListApp.DissertationControl();
			this.collectionControl = new CardListApp.CollectionControl();
			this.bookControl = new CardListApp.BookControl();
			this.authorsControl = new CardListApp.AuthorsControl();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CollectionRadioButton);
			this.groupBox1.Controls.Add(this.JournalRadioButton);
			this.groupBox1.Controls.Add(this.DissertationRadioButton);
			this.groupBox1.Controls.Add(this.BookRadioButton);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(627, 55);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select the type of record";
			// 
			// CollectionRadioButton
			// 
			this.CollectionRadioButton.AutoSize = true;
			this.CollectionRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CollectionRadioButton.Location = new System.Drawing.Point(515, 21);
			this.CollectionRadioButton.Name = "CollectionRadioButton";
			this.CollectionRadioButton.Size = new System.Drawing.Size(104, 24);
			this.CollectionRadioButton.TabIndex = 3;
			this.CollectionRadioButton.Text = "Collection";
			this.CollectionRadioButton.UseVisualStyleBackColor = true;
			this.CollectionRadioButton.CheckedChanged += new System.EventHandler(this.CollectionRadioButton_CheckedChanged);
			// 
			// JournalRadioButton
			// 
			this.JournalRadioButton.AutoSize = true;
			this.JournalRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.JournalRadioButton.Location = new System.Drawing.Point(352, 21);
			this.JournalRadioButton.Name = "JournalRadioButton";
			this.JournalRadioButton.Size = new System.Drawing.Size(85, 24);
			this.JournalRadioButton.TabIndex = 2;
			this.JournalRadioButton.Text = "Journal";
			this.JournalRadioButton.UseVisualStyleBackColor = true;
			this.JournalRadioButton.CheckedChanged += new System.EventHandler(this.JournalRadioButton_CheckedChanged);
			// 
			// DissertationRadioButton
			// 
			this.DissertationRadioButton.AutoSize = true;
			this.DissertationRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DissertationRadioButton.Location = new System.Drawing.Point(153, 21);
			this.DissertationRadioButton.Name = "DissertationRadioButton";
			this.DissertationRadioButton.Size = new System.Drawing.Size(121, 24);
			this.DissertationRadioButton.TabIndex = 1;
			this.DissertationRadioButton.Text = "Dissertation";
			this.DissertationRadioButton.UseVisualStyleBackColor = true;
			this.DissertationRadioButton.CheckedChanged += new System.EventHandler(this.DissertationRadioButton_CheckedChanged);
			// 
			// BookRadioButton
			// 
			this.BookRadioButton.AutoSize = true;
			this.BookRadioButton.Checked = true;
			this.BookRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.BookRadioButton.Location = new System.Drawing.Point(10, 21);
			this.BookRadioButton.Name = "BookRadioButton";
			this.BookRadioButton.Size = new System.Drawing.Size(68, 24);
			this.BookRadioButton.TabIndex = 0;
			this.BookRadioButton.TabStop = true;
			this.BookRadioButton.Text = "Book";
			this.BookRadioButton.UseVisualStyleBackColor = true;
			this.BookRadioButton.CheckedChanged += new System.EventHandler(this.BookRadioButton_CheckedChanged);
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(12, 395);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(125, 24);
			this.OKButton.TabIndex = 12;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Location = new System.Drawing.Point(506, 395);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(125, 24);
			this.CancelButton.TabIndex = 13;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// RandomButton
			// 
			this.RandomButton.Location = new System.Drawing.Point(259, 395);
			this.RandomButton.Name = "RandomButton";
			this.RandomButton.Size = new System.Drawing.Size(125, 24);
			this.RandomButton.TabIndex = 14;
			this.RandomButton.Text = "Random";
			this.RandomButton.UseVisualStyleBackColor = true;
			this.RandomButton.Click += new System.EventHandler(this.RandomButton_Click);
			// 
			// journalControl
			// 
			this.journalControl.Location = new System.Drawing.Point(5, 66);
			this.journalControl.Name = "journalControl";
			this.journalControl.Size = new System.Drawing.Size(627, 145);
			this.journalControl.TabIndex = 18;
			this.journalControl.Title = "";
			this.journalControl.TitleOfPeriodical = "";
			// 
			// dissertationControl
			// 
			this.dissertationControl.CityOfPublication = "";
			this.dissertationControl.Location = new System.Drawing.Point(5, 66);
			this.dissertationControl.Name = "dissertationControl";
			this.dissertationControl.ScienceDegree = "";
			this.dissertationControl.Size = new System.Drawing.Size(627, 145);
			this.dissertationControl.SpecializationNumber = "  .  .";
			this.dissertationControl.TabIndex = 17;
			this.dissertationControl.Title = "";
			// 
			// collectionControl
			// 
			this.collectionControl.City = "";
			this.collectionControl.Location = new System.Drawing.Point(5, 66);
			this.collectionControl.Name = "collectionControl";
			this.collectionControl.Size = new System.Drawing.Size(627, 145);
			this.collectionControl.TabIndex = 16;
			this.collectionControl.ThemeOfCollection = "";
			this.collectionControl.Title = "";
			// 
			// bookControl
			// 
			this.bookControl.AdditionalInfo = "";
			this.bookControl.CityOfPublication = "";
			this.bookControl.Genre = "";
			this.bookControl.Location = new System.Drawing.Point(5, 65);
			this.bookControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.bookControl.Name = "bookControl";
			this.bookControl.PublishingHouse = "";
			this.bookControl.Size = new System.Drawing.Size(627, 178);
			this.bookControl.TabIndex = 15;
			this.bookControl.Title = "";
			// 
			// authorsControl
			// 
			this.authorsControl.Location = new System.Drawing.Point(4, 247);
			this.authorsControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.authorsControl.Name = "authorsControl";
			this.authorsControl.Size = new System.Drawing.Size(627, 143);
			this.authorsControl.TabIndex = 19;
			// 
			// AddRecordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(639, 425);
			this.Controls.Add(this.authorsControl);
			this.Controls.Add(this.journalControl);
			this.Controls.Add(this.dissertationControl);
			this.Controls.Add(this.collectionControl);
			this.Controls.Add(this.bookControl);
			this.Controls.Add(this.RandomButton);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddRecordForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Record";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton CollectionRadioButton;
		private System.Windows.Forms.RadioButton JournalRadioButton;
		private System.Windows.Forms.RadioButton DissertationRadioButton;
		private System.Windows.Forms.RadioButton BookRadioButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button RandomButton;
		private BookControl bookControl;
		private CollectionControl collectionControl;
		private DissertationControl dissertationControl;
		private JournalControl journalControl;
		private AuthorsControl authorsControl;
	}
}