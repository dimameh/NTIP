namespace CardListApp
{
	partial class SearchForm
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.TitleTextBox = new System.Windows.Forms.TextBox();
			this.AuthorTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SearchButton = new System.Windows.Forms.Button();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(6, 19);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowTemplate.Height = 24;
			this.dataGridView.Size = new System.Drawing.Size(550, 218);
			this.dataGridView.TabIndex = 0;
			// 
			// TitleTextBox
			// 
			this.TitleTextBox.Location = new System.Drawing.Point(282, 28);
			this.TitleTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.Size = new System.Drawing.Size(264, 22);
			this.TitleTextBox.TabIndex = 1;
			// 
			// AuthorTextBox
			// 
			this.AuthorTextBox.Location = new System.Drawing.Point(282, 58);
			this.AuthorTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.AuthorTextBox.Name = "AuthorTextBox";
			this.AuthorTextBox.Size = new System.Drawing.Size(264, 22);
			this.AuthorTextBox.TabIndex = 2;
			this.AuthorTextBox.Enter += new System.EventHandler(this.AuthorTextBox_Enter);
			this.AuthorTextBox.Leave += new System.EventHandler(this.AuthorTextBox_Leave);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataGridView);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(8, 3);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox1.Size = new System.Drawing.Size(562, 243);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Results";
			// 
			// SearchButton
			// 
			this.SearchButton.Location = new System.Drawing.Point(29, 25);
			this.SearchButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(74, 24);
			this.SearchButton.TabIndex = 4;
			this.SearchButton.Text = "SearchForm";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(29, 54);
			this.RemoveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(74, 24);
			this.RemoveButton.TabIndex = 5;
			this.RemoveButton.Text = "Remove";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.RemoveButton);
			this.groupBox2.Controls.Add(this.SearchButton);
			this.groupBox2.Controls.Add(this.TitleTextBox);
			this.groupBox2.Controls.Add(this.AuthorTextBox);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox2.Location = new System.Drawing.Point(10, 251);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox2.Size = new System.Drawing.Size(560, 94);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "SearchForm control panel";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(186, 60);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 17);
			this.label2.TabIndex = 7;
			this.label2.Text = "First Author";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(186, 30);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "Title";
			// 
			// SearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 350);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "SearchForm";
			this.Text = "SearchForm";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.TextBox TitleTextBox;
		private System.Windows.Forms.TextBox AuthorTextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}