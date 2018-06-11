namespace CardListApp
{
	partial class JournalControl
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

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.FieldsBox2 = new System.Windows.Forms.GroupBox();
			this.YearTextBox = new System.Windows.Forms.TextBox();
			this.StartingPageTextBox = new System.Windows.Forms.TextBox();
			this.YearLabel = new System.Windows.Forms.Label();
			this.StartingPageLabel = new System.Windows.Forms.Label();
			this.LastPageTextBox = new System.Windows.Forms.TextBox();
			this.LastPageLabel = new System.Windows.Forms.Label();
			this.JournalNumberTextBox = new System.Windows.Forms.TextBox();
			this.JournalNumberLabel = new System.Windows.Forms.Label();
			this.TitleOfPeriodicalTextBox = new System.Windows.Forms.TextBox();
			this.TitleOfPeriodicalLabel = new System.Windows.Forms.Label();
			this.TitleTextBox = new System.Windows.Forms.TextBox();
			this.TitleLabel = new System.Windows.Forms.Label();
			this.FieldsBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// FieldsBox2
			// 
			this.FieldsBox2.Controls.Add(this.YearTextBox);
			this.FieldsBox2.Controls.Add(this.StartingPageTextBox);
			this.FieldsBox2.Controls.Add(this.YearLabel);
			this.FieldsBox2.Controls.Add(this.StartingPageLabel);
			this.FieldsBox2.Controls.Add(this.LastPageTextBox);
			this.FieldsBox2.Controls.Add(this.LastPageLabel);
			this.FieldsBox2.Controls.Add(this.JournalNumberTextBox);
			this.FieldsBox2.Controls.Add(this.JournalNumberLabel);
			this.FieldsBox2.Controls.Add(this.TitleOfPeriodicalTextBox);
			this.FieldsBox2.Controls.Add(this.TitleOfPeriodicalLabel);
			this.FieldsBox2.Controls.Add(this.TitleTextBox);
			this.FieldsBox2.Controls.Add(this.TitleLabel);
			this.FieldsBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FieldsBox2.Location = new System.Drawing.Point(3, 3);
			this.FieldsBox2.Name = "FieldsBox2";
			this.FieldsBox2.Size = new System.Drawing.Size(621, 139);
			this.FieldsBox2.TabIndex = 9;
			this.FieldsBox2.TabStop = false;
			this.FieldsBox2.Text = "Fields";
			// 
			// YearTextBox
			// 
			this.YearTextBox.Location = new System.Drawing.Point(535, 105);
			this.YearTextBox.MaxLength = 4;
			this.YearTextBox.Name = "YearTextBox";
			this.YearTextBox.Size = new System.Drawing.Size(80, 22);
			this.YearTextBox.TabIndex = 15;
			this.YearTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Year_KeyPress);
			// 
			// StartingPageTextBox
			// 
			this.StartingPageTextBox.Location = new System.Drawing.Point(170, 106);
			this.StartingPageTextBox.Name = "StartingPageTextBox";
			this.StartingPageTextBox.Size = new System.Drawing.Size(116, 22);
			this.StartingPageTextBox.TabIndex = 14;
			this.StartingPageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartingPage_KeyPress);
			// 
			// YearLabel
			// 
			this.YearLabel.AutoSize = true;
			this.YearLabel.Location = new System.Drawing.Point(491, 108);
			this.YearLabel.Name = "YearLabel";
			this.YearLabel.Size = new System.Drawing.Size(38, 17);
			this.YearLabel.TabIndex = 13;
			this.YearLabel.Text = "Year";
			// 
			// StartingPageLabel
			// 
			this.StartingPageLabel.AutoSize = true;
			this.StartingPageLabel.Location = new System.Drawing.Point(6, 111);
			this.StartingPageLabel.Name = "StartingPageLabel";
			this.StartingPageLabel.Size = new System.Drawing.Size(93, 17);
			this.StartingPageLabel.TabIndex = 11;
			this.StartingPageLabel.Text = "Starting page";
			// 
			// LastPageTextBox
			// 
			this.LastPageTextBox.Location = new System.Drawing.Point(369, 106);
			this.LastPageTextBox.MaxLength = 4;
			this.LastPageTextBox.Name = "LastPageTextBox";
			this.LastPageTextBox.Size = new System.Drawing.Size(116, 22);
			this.LastPageTextBox.TabIndex = 5;
			this.LastPageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LastPage_KeyPress);
			// 
			// LastPageLabel
			// 
			this.LastPageLabel.AutoSize = true;
			this.LastPageLabel.Location = new System.Drawing.Point(292, 108);
			this.LastPageLabel.Name = "LastPageLabel";
			this.LastPageLabel.Size = new System.Drawing.Size(71, 17);
			this.LastPageLabel.TabIndex = 9;
			this.LastPageLabel.Text = "Last page";
			// 
			// JournalNumberTextBox
			// 
			this.JournalNumberTextBox.Location = new System.Drawing.Point(170, 77);
			this.JournalNumberTextBox.Name = "JournalNumberTextBox";
			this.JournalNumberTextBox.Size = new System.Drawing.Size(445, 22);
			this.JournalNumberTextBox.TabIndex = 3;
			this.JournalNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JournalNumber_KeyPress);
			// 
			// JournalNumberLabel
			// 
			this.JournalNumberLabel.AutoSize = true;
			this.JournalNumberLabel.Location = new System.Drawing.Point(6, 83);
			this.JournalNumberLabel.Name = "JournalNumberLabel";
			this.JournalNumberLabel.Size = new System.Drawing.Size(107, 17);
			this.JournalNumberLabel.TabIndex = 5;
			this.JournalNumberLabel.Text = "Journal number";
			// 
			// TitleOfPeriodicalTextBox
			// 
			this.TitleOfPeriodicalTextBox.Location = new System.Drawing.Point(170, 49);
			this.TitleOfPeriodicalTextBox.Name = "TitleOfPeriodicalTextBox";
			this.TitleOfPeriodicalTextBox.Size = new System.Drawing.Size(445, 22);
			this.TitleOfPeriodicalTextBox.TabIndex = 2;
			this.TitleOfPeriodicalTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleOfPeriodical_KeyPress);
			// 
			// TitleOfPeriodicalLabel
			// 
			this.TitleOfPeriodicalLabel.AutoSize = true;
			this.TitleOfPeriodicalLabel.Location = new System.Drawing.Point(6, 55);
			this.TitleOfPeriodicalLabel.Name = "TitleOfPeriodicalLabel";
			this.TitleOfPeriodicalLabel.Size = new System.Drawing.Size(120, 17);
			this.TitleOfPeriodicalLabel.TabIndex = 3;
			this.TitleOfPeriodicalLabel.Text = "Title Of Periodical";
			// 
			// TitleTextBox
			// 
			this.TitleTextBox.Location = new System.Drawing.Point(170, 21);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.Size = new System.Drawing.Size(445, 22);
			this.TitleTextBox.TabIndex = 1;
			this.TitleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Title_KeyPress);
			// 
			// TitleLabel
			// 
			this.TitleLabel.AutoSize = true;
			this.TitleLabel.Location = new System.Drawing.Point(6, 27);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(35, 17);
			this.TitleLabel.TabIndex = 0;
			this.TitleLabel.Text = "Title";
			// 
			// JournalControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FieldsBox2);
			this.Name = "JournalControl";
			this.Size = new System.Drawing.Size(627, 145);
			this.FieldsBox2.ResumeLayout(false);
			this.FieldsBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox FieldsBox2;
		private System.Windows.Forms.TextBox StartingPageTextBox;
		private System.Windows.Forms.Label YearLabel;
		private System.Windows.Forms.Label StartingPageLabel;
		private System.Windows.Forms.TextBox LastPageTextBox;
		private System.Windows.Forms.Label LastPageLabel;
		private System.Windows.Forms.TextBox JournalNumberTextBox;
		private System.Windows.Forms.Label JournalNumberLabel;
		private System.Windows.Forms.TextBox TitleOfPeriodicalTextBox;
		private System.Windows.Forms.Label TitleOfPeriodicalLabel;
		private System.Windows.Forms.TextBox TitleTextBox;
		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.TextBox YearTextBox;
	}
}
