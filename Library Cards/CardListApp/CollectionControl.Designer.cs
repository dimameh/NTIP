namespace CardListApp
{
	partial class CollectionControl
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
			this.DateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.LastPageTextBox = new System.Windows.Forms.TextBox();
			this.LastPageLabel = new System.Windows.Forms.Label();
			this.DateLabel = new System.Windows.Forms.Label();
			this.FirstPageTextBox = new System.Windows.Forms.TextBox();
			this.FirstPageLabel = new System.Windows.Forms.Label();
			this.CityTextBox = new System.Windows.Forms.TextBox();
			this.CityLabel = new System.Windows.Forms.Label();
			this.ThemeTextBox = new System.Windows.Forms.TextBox();
			this.ThemeOfCollectionLabel = new System.Windows.Forms.Label();
			this.TitleTextBox = new System.Windows.Forms.TextBox();
			this.TitleLabel = new System.Windows.Forms.Label();
			this.FieldsBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// FieldsBox2
			// 
			this.FieldsBox2.Controls.Add(this.DateMaskedTextBox);
			this.FieldsBox2.Controls.Add(this.LastPageTextBox);
			this.FieldsBox2.Controls.Add(this.LastPageLabel);
			this.FieldsBox2.Controls.Add(this.DateLabel);
			this.FieldsBox2.Controls.Add(this.FirstPageTextBox);
			this.FieldsBox2.Controls.Add(this.FirstPageLabel);
			this.FieldsBox2.Controls.Add(this.CityTextBox);
			this.FieldsBox2.Controls.Add(this.CityLabel);
			this.FieldsBox2.Controls.Add(this.ThemeTextBox);
			this.FieldsBox2.Controls.Add(this.ThemeOfCollectionLabel);
			this.FieldsBox2.Controls.Add(this.TitleTextBox);
			this.FieldsBox2.Controls.Add(this.TitleLabel);
			this.FieldsBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FieldsBox2.Location = new System.Drawing.Point(3, 3);
			this.FieldsBox2.Name = "FieldsBox2";
			this.FieldsBox2.Size = new System.Drawing.Size(753, 300);
			this.FieldsBox2.TabIndex = 9;
			this.FieldsBox2.TabStop = false;
			this.FieldsBox2.Text = "Fields";
			// 
			// DateMaskedTextBox
			// 
			this.DateMaskedTextBox.Location = new System.Drawing.Point(248, 170);
			this.DateMaskedTextBox.Mask = "00/00/00";
			this.DateMaskedTextBox.Name = "DateMaskedTextBox";
			this.DateMaskedTextBox.Size = new System.Drawing.Size(492, 22);
			this.DateMaskedTextBox.TabIndex = 15;
			// 
			// LastPageTextBox
			// 
			this.LastPageTextBox.Location = new System.Drawing.Point(248, 262);
			this.LastPageTextBox.Name = "LastPageTextBox";
			this.LastPageTextBox.Size = new System.Drawing.Size(492, 22);
			this.LastPageTextBox.TabIndex = 14;
			// 
			// LastPageLabel
			// 
			this.LastPageLabel.AutoSize = true;
			this.LastPageLabel.Location = new System.Drawing.Point(6, 265);
			this.LastPageLabel.Name = "LastPageLabel";
			this.LastPageLabel.Size = new System.Drawing.Size(71, 17);
			this.LastPageLabel.TabIndex = 13;
			this.LastPageLabel.Text = "Last page";
			// 
			// DateLabel
			// 
			this.DateLabel.AutoSize = true;
			this.DateLabel.Location = new System.Drawing.Point(6, 173);
			this.DateLabel.Name = "DateLabel";
			this.DateLabel.Size = new System.Drawing.Size(127, 17);
			this.DateLabel.TabIndex = 11;
			this.DateLabel.Text = "Date of Publication";
			// 
			// FirstPageTextBox
			// 
			this.FirstPageTextBox.Location = new System.Drawing.Point(248, 218);
			this.FirstPageTextBox.MaxLength = 4;
			this.FirstPageTextBox.Name = "FirstPageTextBox";
			this.FirstPageTextBox.Size = new System.Drawing.Size(492, 22);
			this.FirstPageTextBox.TabIndex = 5;
			// 
			// FirstPageLabel
			// 
			this.FirstPageLabel.AutoSize = true;
			this.FirstPageLabel.Location = new System.Drawing.Point(6, 220);
			this.FirstPageLabel.Name = "FirstPageLabel";
			this.FirstPageLabel.Size = new System.Drawing.Size(71, 17);
			this.FirstPageLabel.TabIndex = 9;
			this.FirstPageLabel.Text = "First page";
			// 
			// CityTextBox
			// 
			this.CityTextBox.Location = new System.Drawing.Point(248, 123);
			this.CityTextBox.Name = "CityTextBox";
			this.CityTextBox.Size = new System.Drawing.Size(492, 22);
			this.CityTextBox.TabIndex = 3;
			// 
			// CityLabel
			// 
			this.CityLabel.AutoSize = true;
			this.CityLabel.Location = new System.Drawing.Point(6, 126);
			this.CityLabel.Name = "CityLabel";
			this.CityLabel.Size = new System.Drawing.Size(119, 17);
			this.CityLabel.TabIndex = 5;
			this.CityLabel.Text = "City of publication";
			// 
			// ThemeTextBox
			// 
			this.ThemeTextBox.Location = new System.Drawing.Point(248, 76);
			this.ThemeTextBox.Name = "ThemeTextBox";
			this.ThemeTextBox.Size = new System.Drawing.Size(492, 22);
			this.ThemeTextBox.TabIndex = 2;
			// 
			// ThemeOfCollectionLabel
			// 
			this.ThemeOfCollectionLabel.AutoSize = true;
			this.ThemeOfCollectionLabel.Location = new System.Drawing.Point(6, 79);
			this.ThemeOfCollectionLabel.Name = "ThemeOfCollectionLabel";
			this.ThemeOfCollectionLabel.Size = new System.Drawing.Size(131, 17);
			this.ThemeOfCollectionLabel.TabIndex = 3;
			this.ThemeOfCollectionLabel.Text = "Theme of collection";
			// 
			// TitleTextBox
			// 
			this.TitleTextBox.Location = new System.Drawing.Point(248, 29);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.Size = new System.Drawing.Size(492, 22);
			this.TitleTextBox.TabIndex = 1;
			// 
			// TitleLabel
			// 
			this.TitleLabel.AutoSize = true;
			this.TitleLabel.Location = new System.Drawing.Point(6, 32);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(35, 17);
			this.TitleLabel.TabIndex = 0;
			this.TitleLabel.Text = "Title";
			// 
			// CollectionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FieldsBox2);
			this.Name = "CollectionControl";
			this.Size = new System.Drawing.Size(760, 306);
			this.FieldsBox2.ResumeLayout(false);
			this.FieldsBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox FieldsBox2;
		private System.Windows.Forms.MaskedTextBox DateMaskedTextBox;
		private System.Windows.Forms.TextBox LastPageTextBox;
		private System.Windows.Forms.Label LastPageLabel;
		private System.Windows.Forms.Label DateLabel;
		private System.Windows.Forms.TextBox FirstPageTextBox;
		private System.Windows.Forms.Label FirstPageLabel;
		private System.Windows.Forms.TextBox CityTextBox;
		private System.Windows.Forms.Label CityLabel;
		private System.Windows.Forms.TextBox ThemeTextBox;
		private System.Windows.Forms.Label ThemeOfCollectionLabel;
		private System.Windows.Forms.TextBox TitleTextBox;
		private System.Windows.Forms.Label TitleLabel;
	}
}
