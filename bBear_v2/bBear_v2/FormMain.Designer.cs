namespace bBear_v2
{
    partial class FormMain
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
    
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.TitleBarpanel = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.LeftMenuPanel = new System.Windows.Forms.Panel();
            this.TitleBarpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleBarpanel
            // 
            this.TitleBarpanel.Controls.Add(this.btnMinimize);
            this.TitleBarpanel.Controls.Add(this.btnClose);
            this.TitleBarpanel.Controls.Add(this.btnMaximize);
            this.TitleBarpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBarpanel.Location = new System.Drawing.Point(0, 0);
            this.TitleBarpanel.Name = "TitleBarpanel";
            this.TitleBarpanel.Size = new System.Drawing.Size(800, 45);
            this.TitleBarpanel.TabIndex = 0;
            this.TitleBarpanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBarpanel_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMinimize.Location = new System.Drawing.Point(683, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(31, 23);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.btnMinimize.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClose.Location = new System.Drawing.Point(757, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnMaximize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMaximize.Location = new System.Drawing.Point(720, 12);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(31, 23);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.Text = "□";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            this.btnMaximize.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.btnMaximize.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // LeftMenuPanel
            // 
            this.LeftMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LeftMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMenuPanel.ForeColor = System.Drawing.Color.Blue;
            this.LeftMenuPanel.Location = new System.Drawing.Point(0, 45);
            this.LeftMenuPanel.Name = "LeftMenuPanel";
            this.LeftMenuPanel.Size = new System.Drawing.Size(76, 405);
            this.LeftMenuPanel.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LeftMenuPanel);
            this.Controls.Add(this.TitleBarpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bBear";
            this.TitleBarpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBarpanel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel LeftMenuPanel;
    }
}

