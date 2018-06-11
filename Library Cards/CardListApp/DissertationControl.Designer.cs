namespace CardListApp
{
	partial class DissertationControl
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
			this.SpecializationNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.CityTextBox = new System.Windows.Forms.TextBox();
			this.SpecializationNumberLabel = new System.Windows.Forms.Label();
			this.CityLabel = new System.Windows.Forms.Label();
			this.YearTextBox = new System.Windows.Forms.TextBox();
			this.YearLabel = new System.Windows.Forms.Label();
			this.ScienceDegreeTextBox = new System.Windows.Forms.TextBox();
			this.ScienceDegreeLabel = new System.Windows.Forms.Label();
			this.PageTextBox = new System.Windows.Forms.TextBox();
			this.PageLabel = new System.Windows.Forms.Label();
			this.TitleTextBox = new System.Windows.Forms.TextBox();
			this.TitleLabel = new System.Windows.Forms.Label();
			this.FieldsBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// FieldsBox2
			// 
			this.FieldsBox2.Controls.Add(this.SpecializationNumberMaskedTextBox);
			this.FieldsBox2.Controls.Add(this.CityTextBox);
			this.FieldsBox2.Controls.Add(this.SpecializationNumberLabel);
			this.FieldsBox2.Controls.Add(this.CityLabel);
			this.FieldsBox2.Controls.Add(this.YearTextBox);
			this.FieldsBox2.Controls.Add(this.YearLabel);
			this.FieldsBox2.Controls.Add(this.ScienceDegreeTextBox);
			this.FieldsBox2.Controls.Add(this.ScienceDegreeLabel);
			this.FieldsBox2.Controls.Add(this.PageTextBox);
			this.FieldsBox2.Controls.Add(this.PageLabel);
			this.FieldsBox2.Controls.Add(this.TitleTextBox);
			this.FieldsBox2.Controls.Add(this.TitleLabel);
			this.FieldsBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FieldsBox2.Location = new System.Drawing.Point(3, 3);
			this.FieldsBox2.Name = "FieldsBox2";
			this.FieldsBox2.Size = new System.Drawing.Size(753, 300);
			this.FieldsBox2.TabIndex = 8;
			this.FieldsBox2.TabStop = false;
			this.FieldsBox2.Text = "Fields";
			// 
			// SpecializationNumberMaskedTextBox
			// 
			this.SpecializationNumberMaskedTextBox.Location = new System.Drawing.Point(248, 262);
			this.SpecializationNumberMaskedTextBox.Mask = "00/00/00";
			this.SpecializationNumberMaskedTextBox.Name = "SpecializationNumberMaskedTextBox";
			this.SpecializationNumberMaskedTextBox.Size = new System.Drawing.Size(492, 22);
			this.SpecializationNumberMaskedTextBox.TabIndex = 15;
			this.SpecializationNumberMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpecializationNumber_KeyPress);
			// 
			// CityTextBox
			// 
			this.CityTextBox.Location = new System.Drawing.Point(248, 173);
			this.CityTextBox.Name = "CityTextBox";
			this.CityTextBox.Size = new System.Drawing.Size(492, 22);
			this.CityTextBox.TabIndex = 14;
			this.CityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.City_KeyPress);
			// 
			// SpecializationNumberLabel
			// 
			this.SpecializationNumberLabel.AutoSize = true;
			this.SpecializationNumberLabel.Location = new System.Drawing.Point(6, 265);
			this.SpecializationNumberLabel.Name = "SpecializationNumberLabel";
			this.SpecializationNumberLabel.Size = new System.Drawing.Size(147, 17);
			this.SpecializationNumberLabel.TabIndex = 13;
			this.SpecializationNumberLabel.Text = "Specialization number";
			// 
			// CityLabel
			// 
			this.CityLabel.AutoSize = true;
			this.CityLabel.Location = new System.Drawing.Point(6, 173);
			this.CityLabel.Name = "CityLabel";
			this.CityLabel.Size = new System.Drawing.Size(120, 17);
			this.CityLabel.TabIndex = 11;
			this.CityLabel.Text = "City of Publication";
			// 
			// YearTextBox
			// 
			this.YearTextBox.Location = new System.Drawing.Point(248, 218);
			this.YearTextBox.MaxLength = 4;
			this.YearTextBox.Name = "YearTextBox";
			this.YearTextBox.Size = new System.Drawing.Size(492, 22);
			this.YearTextBox.TabIndex = 5;
			this.YearTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Year_KeyPress);
			// 
			// YearLabel
			// 
			this.YearLabel.AutoSize = true;
			this.YearLabel.Location = new System.Drawing.Point(6, 220);
			this.YearLabel.Name = "YearLabel";
			this.YearLabel.Size = new System.Drawing.Size(38, 17);
			this.YearLabel.TabIndex = 9;
			this.YearLabel.Text = "Year";
			// 
			// ScienceDegreeTextBox
			// 
			this.ScienceDegreeTextBox.Location = new System.Drawing.Point(248, 123);
			this.ScienceDegreeTextBox.Name = "ScienceDegreeTextBox";
			this.ScienceDegreeTextBox.Size = new System.Drawing.Size(492, 22);
			this.ScienceDegreeTextBox.TabIndex = 3;
			this.ScienceDegreeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScienceDegree_KeyPress);
			// 
			// ScienceDegreeLabel
			// 
			this.ScienceDegreeLabel.AutoSize = true;
			this.ScienceDegreeLabel.Location = new System.Drawing.Point(6, 126);
			this.ScienceDegreeLabel.Name = "ScienceDegreeLabel";
			this.ScienceDegreeLabel.Size = new System.Drawing.Size(107, 17);
			this.ScienceDegreeLabel.TabIndex = 5;
			this.ScienceDegreeLabel.Text = "Science degree";
			// 
			// PageTextBox
			// 
			this.PageTextBox.Location = new System.Drawing.Point(248, 76);
			this.PageTextBox.Name = "PageTextBox";
			this.PageTextBox.Size = new System.Drawing.Size(492, 22);
			this.PageTextBox.TabIndex = 2;
			this.PageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Page_KeyPress);
			// 
			// PageLabel
			// 
			this.PageLabel.AutoSize = true;
			this.PageLabel.Location = new System.Drawing.Point(6, 79);
			this.PageLabel.Name = "PageLabel";
			this.PageLabel.Size = new System.Drawing.Size(41, 17);
			this.PageLabel.TabIndex = 3;
			this.PageLabel.Text = "Page";
			// 
			// TitleTextBox
			// 
			this.TitleTextBox.Location = new System.Drawing.Point(248, 29);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.Size = new System.Drawing.Size(492, 22);
			this.TitleTextBox.TabIndex = 1;
			this.TitleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Title_KeyPress);
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
			// DissertationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FieldsBox2);
			this.Name = "DissertationControl";
			this.Size = new System.Drawing.Size(760, 308);
			this.FieldsBox2.ResumeLayout(false);
			this.FieldsBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox FieldsBox2;
		private System.Windows.Forms.TextBox CityTextBox;
		private System.Windows.Forms.Label SpecializationNumberLabel;
		private System.Windows.Forms.Label CityLabel;
		private System.Windows.Forms.TextBox YearTextBox;
		private System.Windows.Forms.Label YearLabel;
		private System.Windows.Forms.TextBox ScienceDegreeTextBox;
		private System.Windows.Forms.Label ScienceDegreeLabel;
		private System.Windows.Forms.TextBox PageTextBox;
		private System.Windows.Forms.Label PageLabel;
		private System.Windows.Forms.TextBox TitleTextBox;
		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.MaskedTextBox SpecializationNumberMaskedTextBox;
	}
}
