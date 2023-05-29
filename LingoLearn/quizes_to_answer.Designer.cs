
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
            this.homepage_button = new System.Windows.Forms.Button();
            this.quiz_table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.quiz_table)).BeginInit();
            this.SuspendLayout();
            // 
            // look_for_teacher_button
            // 
            this.look_for_teacher_button.Location = new System.Drawing.Point(12, 30);
            this.look_for_teacher_button.Name = "look_for_teacher_button";
            this.look_for_teacher_button.Size = new System.Drawing.Size(282, 50);
            this.look_for_teacher_button.TabIndex = 0;
            this.look_for_teacher_button.Text = "Look for teacher";
            this.look_for_teacher_button.UseVisualStyleBackColor = true;
            this.look_for_teacher_button.Click += new System.EventHandler(this.look_for_teacher_button_Click);
            // 
            // leaderboards_button
            // 
            this.leaderboards_button.Location = new System.Drawing.Point(300, 30);
            this.leaderboards_button.Name = "leaderboards_button";
            this.leaderboards_button.Size = new System.Drawing.Size(282, 50);
            this.leaderboards_button.TabIndex = 1;
            this.leaderboards_button.Text = "Leaderboards";
            this.leaderboards_button.UseVisualStyleBackColor = true;
            this.leaderboards_button.Click += new System.EventHandler(this.leaderboards_button_Click);
            // 
            // homepage_button
            // 
            this.homepage_button.Location = new System.Drawing.Point(588, 30);
            this.homepage_button.Name = "homepage_button";
            this.homepage_button.Size = new System.Drawing.Size(282, 50);
            this.homepage_button.TabIndex = 4;
            this.homepage_button.Text = "Homepage";
            this.homepage_button.UseVisualStyleBackColor = true;
            this.homepage_button.Click += new System.EventHandler(this.homepage_button_Click);
            // 
            // quiz_table
            // 
            this.quiz_table.AllowUserToAddRows = false;
            this.quiz_table.AllowUserToDeleteRows = false;
            this.quiz_table.AllowUserToResizeColumns = false;
            this.quiz_table.AllowUserToResizeRows = false;
            this.quiz_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.quiz_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.quiz_table.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.quiz_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quiz_table.Location = new System.Drawing.Point(12, 165);
            this.quiz_table.MultiSelect = false;
            this.quiz_table.Name = "quiz_table";
            this.quiz_table.ReadOnly = true;
            this.quiz_table.RowHeadersVisible = false;
            this.quiz_table.RowHeadersWidth = 51;
            this.quiz_table.RowTemplate.Height = 24;
            this.quiz_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.quiz_table.Size = new System.Drawing.Size(858, 375);
            this.quiz_table.TabIndex = 3;
            this.quiz_table.MouseClick += new System.Windows.Forms.MouseEventHandler(this.quiz_table_MouseClick);
            // 
            // quizes_to_answer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.quiz_table);
            this.Controls.Add(this.homepage_button);
            this.Controls.Add(this.leaderboards_button);
            this.Controls.Add(this.look_for_teacher_button);
            this.Name = "quizes_to_answer";
            this.Text = "Students";
            this.Load += new System.EventHandler(this.students_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quiz_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button look_for_teacher_button;
        private System.Windows.Forms.Button leaderboards_button;
        private System.Windows.Forms.Button homepage_button;
        private System.Windows.Forms.DataGridView quiz_table;
    }
}