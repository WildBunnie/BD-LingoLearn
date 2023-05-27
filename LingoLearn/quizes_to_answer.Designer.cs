
namespace LingoLearn
{
    partial class quizes_to_answer
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
            this.look_for_teacher_button = new System.Windows.Forms.Button();
            this.leaderboards_button = new System.Windows.Forms.Button();
            this.settings_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // look_for_teacher_button
            // 
            this.look_for_teacher_button.Location = new System.Drawing.Point(12, 29);
            this.look_for_teacher_button.Name = "look_for_teacher_button";
            this.look_for_teacher_button.Size = new System.Drawing.Size(282, 50);
            this.look_for_teacher_button.TabIndex = 0;
            this.look_for_teacher_button.Text = "Look for teacher";
            this.look_for_teacher_button.UseVisualStyleBackColor = true;
            // 
            // leaderboards_button
            // 
            this.leaderboards_button.Location = new System.Drawing.Point(300, 29);
            this.leaderboards_button.Name = "leaderboards_button";
            this.leaderboards_button.Size = new System.Drawing.Size(282, 50);
            this.leaderboards_button.TabIndex = 1;
            this.leaderboards_button.Text = "Leaderboards";
            this.leaderboards_button.UseVisualStyleBackColor = true;
            // 
            // settings_button
            // 
            this.settings_button.Location = new System.Drawing.Point(588, 29);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(282, 50);
            this.settings_button.TabIndex = 2;
            this.settings_button.Text = "Settings";
            this.settings_button.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 156);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(858, 375);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // quizes_to_answer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.settings_button);
            this.Controls.Add(this.leaderboards_button);
            this.Controls.Add(this.look_for_teacher_button);
            this.Name = "quizes_to_answer";
            this.Text = "Students";
            this.Load += new System.EventHandler(this.students_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button look_for_teacher_button;
        private System.Windows.Forms.Button leaderboards_button;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}