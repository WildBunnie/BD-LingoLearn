
namespace LingoLearn
{
    partial class teachers_list
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
            this.answer_quizzes_button = new System.Windows.Forms.Button();
            this.leaderboards_button = new System.Windows.Forms.Button();
            this.homepage_button = new System.Windows.Forms.Button();
            this.teacher_table = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.teacher_table)).BeginInit();
            this.SuspendLayout();
            // 
            // answer_quizzes_button
            // 
            this.answer_quizzes_button.Location = new System.Drawing.Point(12, 29);
            this.answer_quizzes_button.Name = "answer_quizzes_button";
            this.answer_quizzes_button.Size = new System.Drawing.Size(282, 50);
            this.answer_quizzes_button.TabIndex = 0;
            this.answer_quizzes_button.Text = "Answer Quizes";
            this.answer_quizzes_button.UseVisualStyleBackColor = true;
            this.answer_quizzes_button.Click += new System.EventHandler(this.answer_quizzes_button_Click);
            // 
            // leaderboards_button
            // 
            this.leaderboards_button.Location = new System.Drawing.Point(300, 29);
            this.leaderboards_button.Name = "leaderboards_button";
            this.leaderboards_button.Size = new System.Drawing.Size(282, 50);
            this.leaderboards_button.TabIndex = 1;
            this.leaderboards_button.Text = "Leaderboards";
            this.leaderboards_button.UseVisualStyleBackColor = true;
            this.leaderboards_button.Click += new System.EventHandler(this.leaderboards_button_Click);
            // 
            // homepage_button
            // 
            this.homepage_button.Location = new System.Drawing.Point(588, 29);
            this.homepage_button.Name = "homepage_button";
            this.homepage_button.Size = new System.Drawing.Size(282, 50);
            this.homepage_button.TabIndex = 2;
            this.homepage_button.Text = "Homepage";
            this.homepage_button.UseVisualStyleBackColor = true;
            this.homepage_button.Click += new System.EventHandler(this.homepage_button_Click);
            // 
            // teacher_table
            // 
            this.teacher_table.AllowUserToAddRows = false;
            this.teacher_table.AllowUserToDeleteRows = false;
            this.teacher_table.AllowUserToResizeColumns = false;
            this.teacher_table.AllowUserToResizeRows = false;
            this.teacher_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.teacher_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.teacher_table.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.teacher_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teacher_table.Location = new System.Drawing.Point(12, 165);
            this.teacher_table.MultiSelect = false;
            this.teacher_table.Name = "teacher_table";
            this.teacher_table.ReadOnly = true;
            this.teacher_table.RowHeadersVisible = false;
            this.teacher_table.RowHeadersWidth = 51;
            this.teacher_table.RowTemplate.Height = 24;
            this.teacher_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.teacher_table.Size = new System.Drawing.Size(858, 375);
            this.teacher_table.TabIndex = 3;
            this.teacher_table.MouseClick += new System.Windows.Forms.MouseEventHandler(this.teacher_table_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(297, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Available Teachers:";
            // 
            // teachers_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.teacher_table);
            this.Controls.Add(this.homepage_button);
            this.Controls.Add(this.leaderboards_button);
            this.Controls.Add(this.answer_quizzes_button);
            this.Name = "teachers_list";
            this.Text = "Teachers";
            this.Load += new System.EventHandler(this.students_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teacher_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button answer_quizzes_button;
        private System.Windows.Forms.Button leaderboards_button;
        private System.Windows.Forms.Button homepage_button;
        private System.Windows.Forms.DataGridView teacher_table;
        private System.Windows.Forms.Label label1;
    }
}