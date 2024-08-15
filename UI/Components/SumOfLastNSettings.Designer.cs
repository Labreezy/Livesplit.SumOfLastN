namespace Livesplit.UI.Components
{
    partial class SumOfLastNSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.numSplitsNumUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numSplitsNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Splits";
            // 
            // numSplitsNumUpDown
            // 
            this.numSplitsNumUpDown.Location = new System.Drawing.Point(93, 29);
            this.numSplitsNumUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numSplitsNumUpDown.Name = "numSplitsNumUpDown";
            this.numSplitsNumUpDown.Size = new System.Drawing.Size(120, 20);
            this.numSplitsNumUpDown.TabIndex = 1;
            this.numSplitsNumUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // SumOfLastNSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.numSplitsNumUpDown);
            this.Controls.Add(this.label1);
            this.Name = "SumOfLastNSettings";
            this.Size = new System.Drawing.Size(274, 152);
            this.Load += new System.EventHandler(this.SumOfLastNSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSplitsNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSplitsNumUpDown;
    }
}
