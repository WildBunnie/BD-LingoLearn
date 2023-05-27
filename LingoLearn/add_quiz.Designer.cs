
namespace LingoLearn
{
    partial class add_quiz
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
            this.answer = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.Label();
            this.answer_text = new System.Windows.Forms.TextBox();
            this.question_text = new System.Windows.Forms.TextBox();
            this.add_new_question_button = new System.Windows.Forms.Button();
            this.create_quiz_button = new System.Windows.Forms.Button();
            this.translation_radio = new System.Windows.Forms.RadioButton();
            this.multiple_choice_radio = new System.Windows.Forms.RadioButton();
            this.multi_check_4 = new System.Windows.Forms.CheckBox();
            this.multi_text_4 = new System.Windows.Forms.TextBox();
            this.multi_check_3 = new System.Windows.Forms.CheckBox();
            this.multi_text_3 = new System.Windows.Forms.TextBox();
            this.multi_check_2 = new System.Windows.Forms.CheckBox();
            this.multi_text_2 = new System.Windows.Forms.TextBox();
            this.multi_check_1 = new System.Windows.Forms.CheckBox();
            this.multi_text_1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // answer
            // 
            this.answer.AutoSize = true;
            this.answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer.Location = new System.Drawing.Point(192, 246);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(109, 32);
            this.answer.TabIndex = 14;
            this.answer.Text = "Answer";
            this.answer.Visible = false;
            // 
            // question
            // 
            this.question.AutoSize = true;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question.Location = new System.Drawing.Point(192, 105);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(130, 32);
            this.question.TabIndex = 13;
            this.question.Text = "Question";
            this.question.Visible = false;
            // 
            // answer_text
            // 
            this.answer_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer_text.Location = new System.Drawing.Point(198, 304);
            this.answer_text.Multiline = true;
            this.answer_text.Name = "answer_text";
            this.answer_text.Size = new System.Drawing.Size(516, 64);
            this.answer_text.TabIndex = 11;
            this.answer_text.Visible = false;
            // 
            // question_text
            // 
            this.question_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question_text.Location = new System.Drawing.Point(198, 158);
            this.question_text.Multiline = true;
            this.question_text.Name = "question_text";
            this.question_text.Size = new System.Drawing.Size(516, 71);
            this.question_text.TabIndex = 12;
            this.question_text.Visible = false;
            // 
            // add_new_question_button
            // 
            this.add_new_question_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_new_question_button.Location = new System.Drawing.Point(472, 435);
            this.add_new_question_button.Name = "add_new_question_button";
            this.add_new_question_button.Size = new System.Drawing.Size(282, 77);
            this.add_new_question_button.TabIndex = 10;
            this.add_new_question_button.Text = "Next question";
            this.add_new_question_button.UseVisualStyleBackColor = false;
            this.add_new_question_button.Click += new System.EventHandler(this.add_new_question_button_Click);
            // 
            // create_quiz_button
            // 
            this.create_quiz_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.create_quiz_button.Location = new System.Drawing.Point(134, 435);
            this.create_quiz_button.Name = "create_quiz_button";
            this.create_quiz_button.Size = new System.Drawing.Size(282, 77);
            this.create_quiz_button.TabIndex = 9;
            this.create_quiz_button.Text = "Finish quiz";
            this.create_quiz_button.UseVisualStyleBackColor = false;
            this.create_quiz_button.Click += new System.EventHandler(this.create_quiz_button_Click);
            // 
            // translation_radio
            // 
            this.translation_radio.AutoSize = true;
            this.translation_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translation_radio.Location = new System.Drawing.Point(234, 209);
            this.translation_radio.Name = "translation_radio";
            this.translation_radio.Size = new System.Drawing.Size(178, 36);
            this.translation_radio.TabIndex = 15;
            this.translation_radio.TabStop = true;
            this.translation_radio.Text = "Translation";
            this.translation_radio.UseVisualStyleBackColor = true;
            this.translation_radio.CheckedChanged += new System.EventHandler(this.translation_radio_CheckedChanged);
            // 
            // multiple_choice_radio
            // 
            this.multiple_choice_radio.AutoSize = true;
            this.multiple_choice_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiple_choice_radio.Location = new System.Drawing.Point(451, 209);
            this.multiple_choice_radio.Name = "multiple_choice_radio";
            this.multiple_choice_radio.Size = new System.Drawing.Size(232, 36);
            this.multiple_choice_radio.TabIndex = 16;
            this.multiple_choice_radio.TabStop = true;
            this.multiple_choice_radio.Text = "Multiple Choice";
            this.multiple_choice_radio.UseVisualStyleBackColor = true;
            this.multiple_choice_radio.CheckedChanged += new System.EventHandler(this.multiple_choice_radio_CheckedChanged);
            // 
            // multi_check_4
            // 
            this.multi_check_4.AutoSize = true;
            this.multi_check_4.Location = new System.Drawing.Point(488, 362);
            this.multi_check_4.Name = "multi_check_4";
            this.multi_check_4.Size = new System.Drawing.Size(18, 17);
            this.multi_check_4.TabIndex = 24;
            this.multi_check_4.UseVisualStyleBackColor = true;
            this.multi_check_4.Visible = false;
            // 
            // multi_text_4
            // 
            this.multi_text_4.Location = new System.Drawing.Point(512, 362);
            this.multi_text_4.Name = "multi_text_4";
            this.multi_text_4.Size = new System.Drawing.Size(180, 22);
            this.multi_text_4.TabIndex = 23;
            this.multi_text_4.Visible = false;
            // 
            // multi_check_3
            // 
            this.multi_check_3.AutoSize = true;
            this.multi_check_3.Location = new System.Drawing.Point(488, 288);
            this.multi_check_3.Name = "multi_check_3";
            this.multi_check_3.Size = new System.Drawing.Size(18, 17);
            this.multi_check_3.TabIndex = 22;
            this.multi_check_3.UseVisualStyleBackColor = true;
            this.multi_check_3.Visible = false;
            // 
            // multi_text_3
            // 
            this.multi_text_3.Location = new System.Drawing.Point(512, 288);
            this.multi_text_3.Name = "multi_text_3";
            this.multi_text_3.Size = new System.Drawing.Size(180, 22);
            this.multi_text_3.TabIndex = 21;
            this.multi_text_3.Visible = false;
            // 
            // multi_check_2
            // 
            this.multi_check_2.AutoSize = true;
            this.multi_check_2.Location = new System.Drawing.Point(212, 362);
            this.multi_check_2.Name = "multi_check_2";
            this.multi_check_2.Size = new System.Drawing.Size(18, 17);
            this.multi_check_2.TabIndex = 20;
            this.multi_check_2.UseVisualStyleBackColor = true;
            this.multi_check_2.Visible = false;
            // 
            // multi_text_2
            // 
            this.multi_text_2.Location = new System.Drawing.Point(236, 362);
            this.multi_text_2.Name = "multi_text_2";
            this.multi_text_2.Size = new System.Drawing.Size(180, 22);
            this.multi_text_2.TabIndex = 19;
            this.multi_text_2.Visible = false;
            // 
            // multi_check_1
            // 
            this.multi_check_1.AutoSize = true;
            this.multi_check_1.Location = new System.Drawing.Point(212, 288);
            this.multi_check_1.Name = "multi_check_1";
            this.multi_check_1.Size = new System.Drawing.Size(18, 17);
            this.multi_check_1.TabIndex = 18;
            this.multi_check_1.UseVisualStyleBackColor = true;
            this.multi_check_1.Visible = false;
            // 
            // multi_text_1
            // 
            this.multi_text_1.Location = new System.Drawing.Point(236, 288);
            this.multi_text_1.Name = "multi_text_1";
            this.multi_text_1.Size = new System.Drawing.Size(180, 22);
            this.multi_text_1.TabIndex = 17;
            this.multi_text_1.Visible = false;
            // 
            // add_quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.multi_check_4);
            this.Controls.Add(this.multi_text_4);
            this.Controls.Add(this.multi_check_3);
            this.Controls.Add(this.multi_text_3);
            this.Controls.Add(this.multi_check_2);
            this.Controls.Add(this.multi_text_2);
            this.Controls.Add(this.multi_check_1);
            this.Controls.Add(this.multi_text_1);
            this.Controls.Add(this.multiple_choice_radio);
            this.Controls.Add(this.translation_radio);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.question);
            this.Controls.Add(this.answer_text);
            this.Controls.Add(this.question_text);
            this.Controls.Add(this.add_new_question_button);
            this.Controls.Add(this.create_quiz_button);
            this.Name = "add_quiz";
            this.Text = "Quizzes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label answer;
        private System.Windows.Forms.Label question;
        private System.Windows.Forms.TextBox answer_text;
        private System.Windows.Forms.TextBox question_text;
        private System.Windows.Forms.Button add_new_question_button;
        private System.Windows.Forms.Button create_quiz_button;
        private System.Windows.Forms.RadioButton translation_radio;
        private System.Windows.Forms.RadioButton multiple_choice_radio;
        private System.Windows.Forms.CheckBox multi_check_4;
        private System.Windows.Forms.TextBox multi_text_4;
        private System.Windows.Forms.CheckBox multi_check_3;
        private System.Windows.Forms.TextBox multi_text_3;
        private System.Windows.Forms.CheckBox multi_check_2;
        private System.Windows.Forms.TextBox multi_text_2;
        private System.Windows.Forms.CheckBox multi_check_1;
        private System.Windows.Forms.TextBox multi_text_1;
    }
}