
namespace LingoLearn
{
    partial class startpage
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
            this.lingolearn = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.register_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lingolearn
            // 
            this.lingolearn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lingolearn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lingolearn.Location = new System.Drawing.Point(0, 0);
            this.lingolearn.Name = "lingolearn";
            this.lingolearn.Size = new System.Drawing.Size(882, 395);
            this.lingolearn.TabIndex = 6;
            this.lingolearn.Text = "LingoLearn";
            this.lingolearn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // login_button
            // 
            this.login_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.login_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.Location = new System.Drawing.Point(283, 308);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(300, 65);
            this.login_button.TabIndex = 7;
            this.login_button.Text = "Sign In";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.sign_in_button_Click);
            // 
            // register_label
            // 
            this.register_label.AutoSize = true;
            this.register_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_label.Location = new System.Drawing.Point(398, 386);
            this.register_label.Name = "register_label";
            this.register_label.Size = new System.Drawing.Size(72, 20);
            this.register_label.TabIndex = 8;
            this.register_label.Text = "Register";
            this.register_label.Click += new System.EventHandler(this.register_label_Click);
            // 
            // startpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.register_label);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.lingolearn);
            this.Name = "startpage";
            this.Text = "StartPage";
            this.Load += new System.EventHandler(this.startpage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lingolearn;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label register_label;
    }
}