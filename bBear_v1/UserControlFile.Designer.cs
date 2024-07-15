namespace bBear_v1
{
    partial class UserControlFile
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
            this.userControlMenuRecord1 = new bBear_v1.UserControlMenuRecord();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "SubFormFile";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userControlMenuRecord1
            // 
            this.userControlMenuRecord1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlMenuRecord1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userControlMenuRecord1.Location = new System.Drawing.Point(0, 560);
            this.userControlMenuRecord1.Name = "userControlMenuRecord1";
            this.userControlMenuRecord1.Size = new System.Drawing.Size(800, 40);
            this.userControlMenuRecord1.TabIndex = 1;
            // 
            // UserControlFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.userControlMenuRecord1);
            this.Controls.Add(this.label1);
            this.Name = "UserControlFile";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UserControlMenuRecord userControlMenuRecord1;
    }
}
