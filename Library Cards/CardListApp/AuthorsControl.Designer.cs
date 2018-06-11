namespace CardListApp
{
	partial class AuthorsControl
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.PatronymicTextBox = new System.Windows.Forms.TextBox();
			this.SurnameTextBox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.AddAuthor = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.PatronymicTextBox);
			this.groupBox1.Controls.Add(this.SurnameTextBox);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.NameTextBox);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.RemoveButton);
			this.groupBox1.Controls.Add(this.AddAuthor);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(621, 136);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Authors fields";
			// 
			// PatronymicTextBox
			// 
			this.PatronymicTextBox.Location = new System.Drawing.Point(105, 77);
			this.PatronymicTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PatronymicTextBox.Name = "PatronymicTextBox";
			this.PatronymicTextBox.Size = new System.Drawing.Size(217, 22);
			this.PatronymicTextBox.TabIndex = 21;
			this.PatronymicTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatronymicTextBox_KeyPress_1);
			// 
			// SurnameTextBox
			// 
			this.SurnameTextBox.Location = new System.Drawing.Point(105, 48);
			this.SurnameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.SurnameTextBox.Name = "SurnameTextBox";
			this.SurnameTextBox.Size = new System.Drawing.Size(217, 22);
			this.SurnameTextBox.TabIndex = 20;
			this.SurnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SurnameTextBox_KeyPress_1);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 85);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(78, 17);
			this.label10.TabIndex = 27;
			this.label10.Text = "Patronymic";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 57);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(65, 17);
			this.label9.TabIndex = 26;
			this.label9.Text = "Surname";
			// 
			// NameTextBox
			// 
			this.NameTextBox.Location = new System.Drawing.Point(105, 20);
			this.NameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(217, 22);
			this.NameTextBox.TabIndex = 19;
			this.NameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameTextBox_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(45, 17);
			this.label8.TabIndex = 25;
			this.label8.Text = "Name";
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(211, 103);
			this.RemoveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(111, 27);
			this.RemoveButton.TabIndex = 23;
			this.RemoveButton.Text = "Remove";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveAuthor_Click);
			// 
			// AddAuthor
			// 
			this.AddAuthor.Location = new System.Drawing.Point(105, 103);
			this.AddAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.AddAuthor.Name = "AddAuthor";
			this.AddAuthor.Size = new System.Drawing.Size(100, 27);
			this.AddAuthor.TabIndex = 22;
			this.AddAuthor.Text = "Add";
			this.AddAuthor.UseVisualStyleBackColor = true;
			this.AddAuthor.Click += new System.EventHandler(this.AddAuthor_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(328, 20);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(287, 110);
			this.dataGridView1.TabIndex = 24;
			// 
			// AuthorsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "AuthorsControl";
			this.Size = new System.Drawing.Size(627, 143);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox PatronymicTextBox;
		private System.Windows.Forms.TextBox SurnameTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.Button AddAuthor;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}
