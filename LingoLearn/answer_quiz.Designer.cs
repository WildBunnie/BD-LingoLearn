
namespace LingoLearn
{
    partial class answer_quiz
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
            this.question_label = new System.Windows.Forms.Label();
            this.answer1_button = new System.Windows.Forms.Button();
            this.answer2_button = new System.Windows.Forms.Button();
            this.answer3_button = new System.Windows.Forms.Button();
            this.answer4_button = new System.Windows.Forms.Button();
            this.answer_translate_text_box = new System.Windows.Forms.TextBox();
            this.next_question_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // question_label
            // 
            this.question_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.question_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question_label.Location = new System.Drawing.Point(0, 0);
            this.question_label.Name = "question_label";
            this.question_label.Size = new System.Drawing.Size(882, 158);
            this.question_label.TabIndex = 6;
            this.question_label.Text = "question";
            this.question_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answer1_button
            // 
            this.answer1_button.Location = new System.Drawing.Point(132, 215);
            this.answer1_button.Name = "answer1_button";
            this.answer1_button.Size = new System.Drawing.Size(223, 103);
            this.answer1_button.TabIndex = 7;
            this.answer1_button.Text = "button1";
            this.answer1_button.UseVisualStyleBackColor = true;
            this.answer1_button.Click += new System.EventHandler(this.answer1_button_Click);
            // 
            // answer2_button
            // 
            this.answer2_button.Location = new System.Drawing.Point(535, 215);
            this.answer2_button.Name = "answer2_button";
            this.answer2_button.Size = new System.Drawing.Size(223, 103);
            this.answer2_button.TabIndex = 8;
            this.answer2_button.Text = "button2";
            this.answer2_button.UseVisualStyleBackColor = true;
            this.answer2_button.Click += new System.EventHandler(this.answer2_button_Click);
            // 
            // answer3_button
            // 
            this.answer3_button.Location = new System.Drawing.Point(132, 387);
            this.answer3_button.Name = "answer3_button";
            this.answer3_button.Size = new System.Drawing.Size(223, 103);
            this.answer3_button.TabIndex = 9;
            this.answer3_button.Text = "button3";
            this.answer3_button.UseVisualStyleBackColor = true;
            this.answer3_button.Click += new System.EventHandler(this.answer3_button_Click);
            // 
            // answer4_button
            // 
            this.answer4_button.Location = new System.Drawing.Point(535, 387);
            this.answer4_button.Name = "answer4_button";
            this.answer4_button.Size = new System.Drawing.Size(223, 103);
            this.answer4_button.TabIndex = 10;
            this.answer4_button.Text = "button4";
            this.answer4_button.UseVisualStyleBackColor = true;
            this.answer4_button.Click += new System.EventHandler(this.answer4_button_Click);
            // 
            // answer_translate_text_box
            // 
            this.answer_translate_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer_translate_text_box.Location = new System.Drawing.Point(347, 292);
            this.answer_translate_text_box.Name = "answer_translate_text_box";
            this.answer_translate_text_box.Size = new System.Drawing.Size(191, 45);
            this.answer_translate_text_box.TabIndex = 11;
            // 
            // next_question_button
            // 
            this.next_question_button.Location = new System.Drawing.Point(370, 486);
            this.next_question_button.Name = "next_question_button";
            this.next_question_button.Size = new System.Drawing.Size(146, 55);
            this.next_question_button.TabIndex = 12;
            this.next_question_button.Text = "Next Question";
            this.next_question_button.UseVisualStyleBackColor = true;
            this.next_question_button.Click += new System.EventHandler(this.next_question_button_Click);
            // 
            // answer_quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.next_question_button);
            this.Controls.Add(this.answer_translate_text_box);
            this.Controls.Add(this.answer4_button);
            this.Controls.Add(this.answer3_button);
            this.Controls.Add(this.answer2_button);
            this.Controls.Add(this.answer1_button);
            this.Controls.Add(this.question_label);
            this.Name = "answer_quiz";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.answer_quiz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label question_label;
        private System.Windows.Forms.Button answer1_button;
        private System.Windows.Forms.Button answer2_button;
        private System.Windows.Forms.Button answer3_button;
        private System.Windows.Forms.Button answer4_button;
        private System.Windows.Forms.TextBox answer_translate_text_box;
        private System.Windows.Forms.Button next_question_button;
    }
}