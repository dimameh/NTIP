namespace CardListApp
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ModifyButton = new System.Windows.Forms.Button();
			this.SearchButton = new System.Windows.Forms.Button();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.AddCardButton = new System.Windows.Forms.Button();
			this.dataGridViewMain = new System.Windows.Forms.DataGridView();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dataGridViewAuthors = new System.Windows.Forms.DataGridView();
			this.bookControl1 = new CardListApp.BookControl();
			this.collectionControl1 = new CardListApp.CollectionControl();
			this.dissertationControl1 = new CardListApp.DissertationControl();
			this.journalControl1 = new CardListApp.JournalControl();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuthors)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ModifyButton);
			this.groupBox1.Controls.Add(this.SearchButton);
			this.groupBox1.Controls.Add(this.RemoveButton);
			this.groupBox1.Controls.Add(this.AddCardButton);
			this.groupBox1.Controls.Add(this.dataGridViewMain);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(12, 31);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1101, 344);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Записи";
			// 
			// ModifyButton
			// 
			this.ModifyButton.Location = new System.Drawing.Point(124, 299);
			this.ModifyButton.Name = "ModifyButton";
			this.ModifyButton.Size = new System.Drawing.Size(112, 36);
			this.ModifyButton.TabIndex = 6;
			this.ModifyButton.Text = "Modify card";
			this.ModifyButton.UseVisualStyleBackColor = true;
			this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
			// 
			// SearchButton
			// 
			this.SearchButton.Location = new System.Drawing.Point(242, 299);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(112, 36);
			this.SearchButton.TabIndex = 5;
			this.SearchButton.Text = "Search";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(360, 299);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(112, 36);
			this.RemoveButton.TabIndex = 4;
			this.RemoveButton.Text = "Remove";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.Remove_Click);
			// 
			// AddCardButton
			// 
			this.AddCardButton.Location = new System.Drawing.Point(6, 299);
			this.AddCardButton.Name = "AddCardButton";
			this.AddCardButton.Size = new System.Drawing.Size(112, 36);
			this.AddCardButton.TabIndex = 3;
			this.AddCardButton.Text = "Add Card";
			this.AddCardButton.UseVisualStyleBackColor = true;
			this.AddCardButton.Click += new System.EventHandler(this.AddButtonClick);
			// 
			// dataGridViewMain
			// 
			this.dataGridViewMain.AllowUserToAddRows = false;
			this.dataGridViewMain.AllowUserToDeleteRows = false;
			this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMain.Location = new System.Drawing.Point(6, 26);
			this.dataGridViewMain.Name = "dataGridViewMain";
			this.dataGridViewMain.ReadOnly = true;
			this.dataGridViewMain.RowTemplate.Height = 24;
			this.dataGridViewMain.Size = new System.Drawing.Size(1089, 267);
			this.dataGridViewMain.TabIndex = 0;
			this.dataGridViewMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "cardDB";
			this.saveFileDialog.FileName = "newCard";
			this.saveFileDialog.Filter = "card files (*.cardDB)|*.cardDB";
			this.saveFileDialog.InitialDirectory = "/data";
			this.saveFileDialog.RestoreDirectory = true;
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "cardDB";
			this.openFileDialog.FileName = "openFileDialog";
			this.openFileDialog.Filter = "cardDB | *.cardDB";
			this.openFileDialog.RestoreDirectory = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1125, 28);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
			this.saveToolStripMenuItem.Text = "Save as...";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.journalControl1);
			this.groupBox2.Controls.Add(this.dissertationControl1);
			this.groupBox2.Controls.Add(this.collectionControl1);
			this.groupBox2.Controls.Add(this.bookControl1);
			this.groupBox2.Controls.Add(this.dataGridViewAuthors);
			this.groupBox2.Location = new System.Drawing.Point(12, 381);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1101, 203);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Card Info";
			// 
			// dataGridViewAuthors
			// 
			this.dataGridViewAuthors.AllowUserToAddRows = false;
			this.dataGridViewAuthors.AllowUserToDeleteRows = false;
			this.dataGridViewAuthors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAuthors.Location = new System.Drawing.Point(639, 12);
			this.dataGridViewAuthors.Name = "dataGridViewAuthors";
			this.dataGridViewAuthors.ReadOnly = true;
			this.dataGridViewAuthors.RowTemplate.Height = 24;
			this.dataGridViewAuthors.Size = new System.Drawing.Size(456, 180);
			this.dataGridViewAuthors.TabIndex = 0;
			// 
			// bookControl1
			// 
			this.bookControl1.AdditionalInfo = "";
			this.bookControl1.CityOfPublication = "";
			this.bookControl1.Genre = "";
			this.bookControl1.Location = new System.Drawing.Point(6, 20);
			this.bookControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.bookControl1.Name = "bookControl1";
			this.bookControl1.PublishingHouse = "";
			this.bookControl1.Size = new System.Drawing.Size(627, 178);
			this.bookControl1.TabIndex = 1;
			this.bookControl1.Title = "";
			// 
			// collectionControl1
			// 
			this.collectionControl1.City = "";
			this.collectionControl1.Location = new System.Drawing.Point(6, 21);
			this.collectionControl1.Name = "collectionControl1";
			this.collectionControl1.Size = new System.Drawing.Size(627, 145);
			this.collectionControl1.TabIndex = 2;
			this.collectionControl1.ThemeOfCollection = "";
			this.collectionControl1.Title = "";
			// 
			// dissertationControl1
			// 
			this.dissertationControl1.CityOfPublication = "";
			this.dissertationControl1.Location = new System.Drawing.Point(6, 21);
			this.dissertationControl1.Name = "dissertationControl1";
			this.dissertationControl1.ScienceDegree = "";
			this.dissertationControl1.Size = new System.Drawing.Size(627, 145);
			this.dissertationControl1.SpecializationNumber = "  .  .";
			this.dissertationControl1.TabIndex = 3;
			this.dissertationControl1.Title = "";
			// 
			// journalControl1
			// 
			this.journalControl1.Location = new System.Drawing.Point(6, 21);
			this.journalControl1.Name = "journalControl1";
			this.journalControl1.Size = new System.Drawing.Size(627, 145);
			this.journalControl1.TabIndex = 4;
			this.journalControl1.Title = "";
			this.journalControl1.TitleOfPeriodical = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1125, 592);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Library Cards";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuthors)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dataGridViewMain;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Button AddCardButton;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button ModifyButton;
		private System.Windows.Forms.DataGridView dataGridViewAuthors;
		private JournalControl journalControl1;
		private DissertationControl dissertationControl1;
		private CollectionControl collectionControl1;
		private BookControl bookControl1;
	}
}

