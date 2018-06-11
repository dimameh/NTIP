namespace CardListApp
{
	partial class BookControl
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
			this.CityTextBox = new System.Windows.Forms.TextBox();
			this.CityLabel = new System.Windows.Forms.Label();
			this.VolumeTextBox = new System.Windows.Forms.TextBox();
			this.VolumeLabel = new System.Windows.Forms.Label();
			this.YearTextBox = new System.Windows.Forms.TextBox();
			this.YearLabel = new System.Windows.Forms.Label();
			this.AdditionalInfoTextBox = new System.Windows.Forms.TextBox();
			this.AdditionalInfoLabel = new System.Windows.Forms.Label();
			this.PublishingHouseTextBox = new System.Windows.Forms.TextBox();
			this.PublishingHouseLabel = new System.Windows.Forms.Label();
			this.GenreTextBox = new System.Windows.Forms.TextBox();
			this.GenreLabel = new System.Windows.Forms.Label();
			this.TitleTextBox = new System.Windows.Forms.TextBox();
			this.TitleLabel = new System.Windows.Forms.Label();
			this.FieldsBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// FieldsBox2
			// 
			this.FieldsBox2.Controls.Add(this.CityTextBox);
			this.FieldsBox2.Controls.Add(this.CityLabel);
			this.FieldsBox2.Controls.Add(this.VolumeTextBox);
			this.FieldsBox2.Controls.Add(this.VolumeLabel);
			this.FieldsBox2.Controls.Add(this.YearTextBox);
			this.FieldsBox2.Controls.Add(this.YearLabel);
			this.FieldsBox2.Controls.Add(this.AdditionalInfoTextBox);
			this.FieldsBox2.Controls.Add(this.AdditionalInfoLabel);
			this.FieldsBox2.Controls.Add(this.PublishingHouseTextBox);
			this.FieldsBox2.Controls.Add(this.PublishingHouseLabel);
			this.FieldsBox2.Controls.Add(this.GenreTextBox);
			this.FieldsBox2.Controls.Add(this.GenreLabel);
			this.FieldsBox2.Controls.Add(this.TitleTextBox);
			this.FieldsBox2.Controls.Add(this.TitleLabel);
			this.FieldsBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FieldsBox2.Location = new System.Drawing.Point(3, 3);
			this.FieldsBox2.Name = "FieldsBox2";
			this.FieldsBox2.Size = new System.Drawing.Size(753, 347);
			this.FieldsBox2.TabIndex = 7;
			this.FieldsBox2.TabStop = false;
			this.FieldsBox2.Text = "Fields";
			// 
			// CityTextBox
			// 
			this.CityTextBox.Location = new System.Drawing.Point(248, 173);
			this.CityTextBox.Name = "CityTextBox";
			this.CityTextBox.Size = new System.Drawing.Size(492, 22);
			this.CityTextBox.TabIndex = 14;
			this.CityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.City_KeyPress);
			// 
			// CityLabel
			// 
			this.CityLabel.AutoSize = true;
			this.CityLabel.Location = new System.Drawing.Point(6, 173);
			this.CityLabel.Name = "CityLabel";
			this.CityLabel.Size = new System.Drawing.Size(119, 17);
			this.CityLabel.TabIndex = 13;
			this.CityLabel.Text = "City of publication";
			// 
			// VolumeTextBox
			// 
			this.VolumeTextBox.Location = new System.Drawing.Point(248, 265);
			this.VolumeTextBox.Name = "VolumeTextBox";
			this.VolumeTextBox.Size = new System.Drawing.Size(492, 22);
			this.VolumeTextBox.TabIndex = 6;
			this.VolumeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Volume_KeyPress);
			// 
			// VolumeLabel
			// 
			this.VolumeLabel.AutoSize = true;
			this.VolumeLabel.Location = new System.Drawing.Point(6, 267);
			this.VolumeLabel.Name = "VolumeLabel";
			this.VolumeLabel.Size = new System.Drawing.Size(109, 17);
			this.VolumeLabel.TabIndex = 11;
			this.VolumeLabel.Text = "Volume (Pages)";
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
			// AdditionalInfoTextBox
			// 
			this.AdditionalInfoTextBox.Location = new System.Drawing.Point(248, 311);
			this.AdditionalInfoTextBox.Name = "AdditionalInfoTextBox";
			this.AdditionalInfoTextBox.Size = new System.Drawing.Size(492, 22);
			this.AdditionalInfoTextBox.TabIndex = 7;
			this.AdditionalInfoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AdditionalInfoTextBox_KeyPress);
			// 
			// AdditionalInfoLabel
			// 
			this.AdditionalInfoLabel.AutoSize = true;
			this.AdditionalInfoLabel.Location = new System.Drawing.Point(6, 314);
			this.AdditionalInfoLabel.Name = "AdditionalInfoLabel";
			this.AdditionalInfoLabel.Size = new System.Drawing.Size(164, 17);
			this.AdditionalInfoLabel.TabIndex = 7;
			this.AdditionalInfoLabel.Text = "Additional Info (Optional)";
			// 
			// PublishingHouseTextBox
			// 
			this.PublishingHouseTextBox.Location = new System.Drawing.Point(248, 123);
			this.PublishingHouseTextBox.Name = "PublishingHouseTextBox";
			this.PublishingHouseTextBox.Size = new System.Drawing.Size(492, 22);
			this.PublishingHouseTextBox.TabIndex = 3;
			this.PublishingHouseTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PublishingHouse_KeyPress);
			// 
			// PublishingHouseLabel
			// 
			this.PublishingHouseLabel.AutoSize = true;
			this.PublishingHouseLabel.Location = new System.Drawing.Point(6, 126);
			this.PublishingHouseLabel.Name = "PublishingHouseLabel";
			this.PublishingHouseLabel.Size = new System.Drawing.Size(116, 17);
			this.PublishingHouseLabel.TabIndex = 5;
			this.PublishingHouseLabel.Text = "Publishing house";
			// 
			// GenreTextBox
			// 
			this.GenreTextBox.Location = new System.Drawing.Point(248, 76);
			this.GenreTextBox.Name = "GenreTextBox";
			this.GenreTextBox.Size = new System.Drawing.Size(492, 22);
			this.GenreTextBox.TabIndex = 2;
			this.GenreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Genre_KeyPress);
			// 
			// GenreLabel
			// 
			this.GenreLabel.AutoSize = true;
			this.GenreLabel.Location = new System.Drawing.Point(6, 79);
			this.GenreLabel.Name = "GenreLabel";
			this.GenreLabel.Size = new System.Drawing.Size(48, 17);
			this.GenreLabel.TabIndex = 3;
			this.GenreLabel.Text = "Genre";
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
			// BookControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FieldsBox2);
			this.Name = "BookControl";
			this.Size = new System.Drawing.Size(760, 353);
			this.FieldsBox2.ResumeLayout(false);
			this.FieldsBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox FieldsBox2;
		private System.Windows.Forms.Label CityLabel;
		private System.Windows.Forms.TextBox VolumeTextBox;
		private System.Windows.Forms.Label VolumeLabel;
		private System.Windows.Forms.TextBox YearTextBox;
		private System.Windows.Forms.Label YearLabel;
		private System.Windows.Forms.TextBox AdditionalInfoTextBox;
		private System.Windows.Forms.Label AdditionalInfoLabel;
		private System.Windows.Forms.TextBox PublishingHouseTextBox;
		private System.Windows.Forms.Label PublishingHouseLabel;
		private System.Windows.Forms.TextBox GenreTextBox;
		private System.Windows.Forms.Label GenreLabel;
		private System.Windows.Forms.TextBox TitleTextBox;
		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.TextBox CityTextBox;
	}
}
