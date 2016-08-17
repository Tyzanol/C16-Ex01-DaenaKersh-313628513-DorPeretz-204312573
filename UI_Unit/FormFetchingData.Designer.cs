namespace UI_Unit
{
    partial class FormFetchingData
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
            this.progressBarFetchingData = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBarFetchingData
            // 
            this.progressBarFetchingData.Location = new System.Drawing.Point(26, 275);
            this.progressBarFetchingData.Name = "progressBarFetchingData";
            this.progressBarFetchingData.Size = new System.Drawing.Size(797, 58);
            this.progressBarFetchingData.TabIndex = 0;
            // 
            // FormFetchingData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 376);
            this.Controls.Add(this.progressBarFetchingData);
            this.Name = "FormFetchingData";
            this.Text = "FormFetchingData";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarFetchingData;
    }
}