
namespace LingoLearn
{
    partial class student_teacher_page
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
            this.hello_label = new System.Windows.Forms.Label();
            this.add_quizzes_button = new System.Windows.Forms.Button();
            this.students_button = new System.Windows.Forms.Button();
            this.leaderboards_button = new System.Windows.Forms.Button();
            this.settings_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.answer_quizes_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hello_label
            // 
            this.hello_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.hello_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hello_label.Location = new System.Drawing.Point(0, 0);
            this.hello_label.Name = "hello_label";
            this.hello_label.Size = new System.Drawing.Size(882, 102);
            this.hello_label.TabIndex = 5;
            this.hello_label.Text = "Hello";
            this.hello_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // add_quizzes_button
            // 
            this.add_quizzes_button.Location = new System.Drawing.Point(352, 150);
            this.add_quizzes_button.Name = "add_quizzes_button";
            this.add_quizzes_button.Size = new System.Drawing.Size(170, 150);
            this.add_quizzes_button.TabIndex = 6;
            this.add_quizzes_button.Text = "Add Quizzes";
            this.add_quizzes_button.UseVisualStyleBackColor = true;
            this.add_quizzes_button.Click += new System.EventHandler(this.add_quizzes_button_Click);
            // 
            // students_button
            // 
            this.students_button.Location = new System.Drawing.Point(596, 150);
            this.students_button.Name = "students_button";
            this.students_button.Size = new System.Drawing.Size(170, 150);
            this.students_button.TabIndex = 7;
            this.students_button.Text = "Students";
            this.students_button.UseVisualStyleBackColor = true;
            // 
            // leaderboards_button
            // 
            this.leaderboards_button.Location = new System.Drawing.Point(352, 351);
            this.leaderboards_button.Name = "leaderboards_button";
            this.leaderboards_button.Size = new System.Drawing.Size(170, 150);
            this.leaderboards_button.TabIndex = 8;
            this.leaderboards_button.Text = "Leaderboards";
            this.leaderboards_button.UseVisualStyleBackColor = true;
            // 
            // settings_button
            // 
            this.settings_button.Location = new System.Drawing.Point(596, 351);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(170, 150);
            this.settings_button.TabIndex = 9;
            this.settings_button.Text = "Settings";
            this.settings_button.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 150);
            this.button1.TabIndex = 11;
            this.button1.Text = "Leaderboards";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // answer_quizes_button
            // 
            this.answer_quizes_button.Location = new System.Drawing.Point(109, 150);
            this.answer_quizes_button.Name = "answer_quizes_button";
            this.answer_quizes_button.Size = new System.Drawing.Size(170, 150);
            this.answer_quizes_button.TabIndex = 10;
            this.answer_quizes_button.Text = "Answer Quizzes";
            this.answer_quizes_button.UseVisualStyleBackColor = true;
            this.answer_quizes_button.Click += new System.EventHandler(this.answer_quizes_button_Click);
            // 
            // student_teacher_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.answer_quizes_button);
            this.Controls.Add(this.settings_button);
            this.Controls.Add(this.leaderboards_button);
            this.Controls.Add(this.students_button);
            this.Controls.Add(this.add_quizzes_button);
            this.Controls.Add(this.hello_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "student_teacher_page";
            this.Text = "Main Page";
            this.Load += new System.EventHandler(this.student_teacher_page_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label hello_label;
        private System.Windows.Forms.Button add_quizzes_button;
        private System.Windows.Forms.Button students_button;
        private System.Windows.Forms.Button leaderboards_button;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button answer_quizes_button;
    }
}

