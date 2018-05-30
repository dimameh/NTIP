namespace WindowsFormsApp1
{
	partial class MainWindow
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.AddCardButton = new System.Windows.Forms.Button();
			this.RemoveCardButton = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FirstAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.AddCardButton);
			this.groupBox1.Controls.Add(this.RemoveCardButton);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(744, 567);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// AddCardButton
			// 
			this.AddCardButton.Location = new System.Drawing.Point(6, 470);
			this.AddCardButton.Name = "AddCardButton";
			this.AddCardButton.Size = new System.Drawing.Size(168, 91);
			this.AddCardButton.TabIndex = 3;
			this.AddCardButton.Text = "Add Card";
			this.AddCardButton.UseVisualStyleBackColor = true;
			this.AddCardButton.Click += new System.EventHandler(this.AddButtonClick);
			// 
			// RemoveCardButton
			// 
			this.RemoveCardButton.Location = new System.Drawing.Point(570, 470);
			this.RemoveCardButton.Name = "RemoveCardButton";
			this.RemoveCardButton.Size = new System.Drawing.Size(168, 91);
			this.RemoveCardButton.TabIndex = 2;
			this.RemoveCardButton.Text = "Remove Card";
			this.RemoveCardButton.UseVisualStyleBackColor = true;
			this.RemoveCardButton.Click += new System.EventHandler(this.RemoveButtonClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.FirstAuthor});
			this.dataGridView1.Location = new System.Drawing.Point(6, 21);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(732, 443);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// Title
			// 
			this.Title.HeaderText = "Title";
			this.Title.Name = "Title";
			this.Title.ReadOnly = true;
			// 
			// FirstAuthor
			// 
			this.FirstAuthor.HeaderText = "First Author";
			this.FirstAuthor.Name = "FirstAuthor";
			this.FirstAuthor.ReadOnly = true;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(768, 591);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainWindow";
			this.Text = "MainWindow";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Button AddCardButton;
		private System.Windows.Forms.Button RemoveCardButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn Title;
		private System.Windows.Forms.DataGridViewTextBoxColumn FirstAuthor;
	}
}

