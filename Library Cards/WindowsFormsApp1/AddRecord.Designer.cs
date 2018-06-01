namespace WindowsFormsApp1
{
	partial class AddRecord
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CollectionRadioButton = new System.Windows.Forms.RadioButton();
			this.JournalRadioButton = new System.Windows.Forms.RadioButton();
			this.DissertationRadioButton = new System.Windows.Forms.RadioButton();
			this.BookRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TextBox6 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.TextBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.AdditionalInfoTextBox = new System.Windows.Forms.TextBox();
			this.AdditionalInfoLabel = new System.Windows.Forms.Label();
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.PatronymicTextBox = new System.Windows.Forms.TextBox();
			this.SurnameTextBox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.AddAuthor = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.RandomButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CollectionRadioButton);
			this.groupBox1.Controls.Add(this.JournalRadioButton);
			this.groupBox1.Controls.Add(this.DissertationRadioButton);
			this.groupBox1.Controls.Add(this.BookRadioButton);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(13, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(753, 68);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select the type of record";
			// 
			// CollectionRadioButton
			// 
			this.CollectionRadioButton.AutoSize = true;
			this.CollectionRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CollectionRadioButton.Location = new System.Drawing.Point(597, 30);
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
			this.JournalRadioButton.Location = new System.Drawing.Point(426, 30);
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
			this.DissertationRadioButton.Location = new System.Drawing.Point(219, 30);
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
			this.BookRadioButton.Location = new System.Drawing.Point(65, 30);
			this.BookRadioButton.Name = "BookRadioButton";
			this.BookRadioButton.Size = new System.Drawing.Size(68, 24);
			this.BookRadioButton.TabIndex = 0;
			this.BookRadioButton.TabStop = true;
			this.BookRadioButton.Text = "Book";
			this.BookRadioButton.UseVisualStyleBackColor = true;
			this.BookRadioButton.CheckedChanged += new System.EventHandler(this.BookRadioButton_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.maskedTextBox4);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.TextBox6);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.TextBox5);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.AdditionalInfoTextBox);
			this.groupBox2.Controls.Add(this.AdditionalInfoLabel);
			this.groupBox2.Controls.Add(this.TextBox3);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.TextBox2);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.TextBox1);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox2.Location = new System.Drawing.Point(13, 81);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(753, 696);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Fields";
			// 
			// maskedTextBox4
			// 
			this.maskedTextBox4.Location = new System.Drawing.Point(248, 170);
			this.maskedTextBox4.Name = "maskedTextBox4";
			this.maskedTextBox4.Size = new System.Drawing.Size(492, 27);
			this.maskedTextBox4.TabIndex = 4;
			this.maskedTextBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox4_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 173);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(142, 20);
			this.label4.TabIndex = 13;
			this.label4.Text = "City of publication";
			// 
			// TextBox6
			// 
			this.TextBox6.Location = new System.Drawing.Point(248, 265);
			this.TextBox6.Name = "TextBox6";
			this.TextBox6.Size = new System.Drawing.Size(492, 27);
			this.TextBox6.TabIndex = 6;
			this.TextBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox6_KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 267);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(129, 20);
			this.label6.TabIndex = 11;
			this.label6.Text = "Volume (Pages)";
			// 
			// TextBox5
			// 
			this.TextBox5.Location = new System.Drawing.Point(248, 218);
			this.TextBox5.Name = "TextBox5";
			this.TextBox5.Size = new System.Drawing.Size(492, 27);
			this.TextBox5.TabIndex = 5;
			this.TextBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox5_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 220);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 20);
			this.label5.TabIndex = 9;
			this.label5.Text = "Year";
			// 
			// AdditionalInfoTextBox
			// 
			this.AdditionalInfoTextBox.Location = new System.Drawing.Point(248, 311);
			this.AdditionalInfoTextBox.Name = "AdditionalInfoTextBox";
			this.AdditionalInfoTextBox.Size = new System.Drawing.Size(492, 27);
			this.AdditionalInfoTextBox.TabIndex = 7;
			this.AdditionalInfoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AdditionalInfoTextBox_KeyPress);
			// 
			// AdditionalInfoLabel
			// 
			this.AdditionalInfoLabel.AutoSize = true;
			this.AdditionalInfoLabel.Location = new System.Drawing.Point(6, 314);
			this.AdditionalInfoLabel.Name = "AdditionalInfoLabel";
			this.AdditionalInfoLabel.Size = new System.Drawing.Size(193, 20);
			this.AdditionalInfoLabel.TabIndex = 7;
			this.AdditionalInfoLabel.Text = "Additional Info (Optional)";
			// 
			// TextBox3
			// 
			this.TextBox3.Location = new System.Drawing.Point(248, 123);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.Size = new System.Drawing.Size(492, 27);
			this.TextBox3.TabIndex = 3;
			this.TextBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox3_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 126);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Publishing house";
			// 
			// TextBox2
			// 
			this.TextBox2.Location = new System.Drawing.Point(248, 76);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(492, 27);
			this.TextBox2.TabIndex = 2;
			this.TextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox2_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Genre";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.PatronymicTextBox);
			this.groupBox3.Controls.Add(this.SurnameTextBox);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.NameTextBox);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.RemoveButton);
			this.groupBox3.Controls.Add(this.AddAuthor);
			this.groupBox3.Controls.Add(this.dataGridView1);
			this.groupBox3.Location = new System.Drawing.Point(10, 355);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(737, 330);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Authors";
			// 
			// PatronymicTextBox
			// 
			this.PatronymicTextBox.Location = new System.Drawing.Point(161, 93);
			this.PatronymicTextBox.Name = "PatronymicTextBox";
			this.PatronymicTextBox.Size = new System.Drawing.Size(255, 27);
			this.PatronymicTextBox.TabIndex = 10;
			this.PatronymicTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatronymicTextBox_KeyPress);
			// 
			// SurnameTextBox
			// 
			this.SurnameTextBox.Location = new System.Drawing.Point(161, 60);
			this.SurnameTextBox.Name = "SurnameTextBox";
			this.SurnameTextBox.Size = new System.Drawing.Size(255, 27);
			this.SurnameTextBox.TabIndex = 9;
			this.SurnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SurnameTextBox_KeyPress);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(17, 96);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(93, 20);
			this.label10.TabIndex = 18;
			this.label10.Text = "Patronymic";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(17, 63);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(76, 20);
			this.label9.TabIndex = 17;
			this.label9.Text = "Surname";
			// 
			// NameTextBox
			// 
			this.NameTextBox.Location = new System.Drawing.Point(161, 27);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(255, 27);
			this.NameTextBox.TabIndex = 8;
			this.NameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameTextBox_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 30);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 20);
			this.label8.TabIndex = 15;
			this.label8.Text = "Name";
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(579, 27);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(151, 93);
			this.RemoveButton.TabIndex = 12;
			this.RemoveButton.Text = "Remove Author";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveAuthor_Click);
			// 
			// AddAuthor
			// 
			this.AddAuthor.Location = new System.Drawing.Point(422, 27);
			this.AddAuthor.Name = "AddAuthor";
			this.AddAuthor.Size = new System.Drawing.Size(151, 93);
			this.AddAuthor.TabIndex = 11;
			this.AddAuthor.Text = "Add Author";
			this.AddAuthor.UseVisualStyleBackColor = true;
			this.AddAuthor.Click += new System.EventHandler(this.AddAuthor_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(10, 126);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(720, 198);
			this.dataGridView1.TabIndex = 13;
			// 
			// TextBox1
			// 
			this.TextBox1.Location = new System.Drawing.Point(248, 29);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(492, 27);
			this.TextBox1.TabIndex = 1;
			this.TextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title";
			// 
			// OKButton
			// 
			this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.OKButton.Location = new System.Drawing.Point(96, 783);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(257, 38);
			this.OKButton.TabIndex = 2;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OK_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CancelButton.Location = new System.Drawing.Point(445, 783);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(257, 38);
			this.CancelButton.TabIndex = 3;
			this.CancelButton.Text = "Canсel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// RandomButton
			// 
			this.RandomButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.RandomButton.Location = new System.Drawing.Point(359, 783);
			this.RandomButton.Name = "RandomButton";
			this.RandomButton.Size = new System.Drawing.Size(80, 38);
			this.RandomButton.TabIndex = 4;
			this.RandomButton.Text = "Rand";
			this.RandomButton.UseVisualStyleBackColor = true;
			this.RandomButton.Click += new System.EventHandler(this.Rand_Click);
			// 
			// AddRecord
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(775, 829);
			this.Controls.Add(this.RandomButton);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "AddRecord";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Record";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton CollectionRadioButton;
		private System.Windows.Forms.RadioButton JournalRadioButton;
		private System.Windows.Forms.RadioButton DissertationRadioButton;
		private System.Windows.Forms.RadioButton BookRadioButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.TextBox AdditionalInfoTextBox;
		private System.Windows.Forms.Label AdditionalInfoLabel;
		private System.Windows.Forms.TextBox TextBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TextBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TextBox6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox TextBox5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.Button AddAuthor;
		private System.Windows.Forms.TextBox PatronymicTextBox;
		private System.Windows.Forms.TextBox SurnameTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.MaskedTextBox maskedTextBox4;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button RandomButton;
	}
}