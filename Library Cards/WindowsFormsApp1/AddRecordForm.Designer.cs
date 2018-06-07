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
			this.cardControl1 = new WindowsFormsApp1.CardControl();
			this.SuspendLayout();
			// 
			// cardControl1
			// 
			this.cardControl1.Location = new System.Drawing.Point(4, 2);
			this.cardControl1.Name = "cardControl1";
			this.cardControl1.Card = null;
			this.cardControl1.Size = new System.Drawing.Size(759, 813);
			this.cardControl1.TabIndex = 0;
			// 
			// AddRecordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(766, 814);
			this.Controls.Add(this.cardControl1);
			this.Name = "AddRecordForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Record";
			this.ResumeLayout(false);

		}

		#endregion

		private WindowsFormsApp1.CardControl cardControl1;
	}
}