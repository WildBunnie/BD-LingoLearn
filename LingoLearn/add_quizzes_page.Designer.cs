
namespace LingoLearn
{
    partial class add_quizes
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
            this.add_quizzes_button = new System.Windows.Forms.Button();
            this.leaderboards_button = new System.Windows.Forms.Button();
            this.settings_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.create_quiz_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dropdown = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // add_quizzes_button
            // 
            this.add_quizzes_button.Location = new System.Drawing.Point(12, 29);
            this.add_quizzes_button.Name = "add_quizzes_button";
            this.add_quizzes_button.Size = new System.Drawing.Size(282, 50);
            this.add_quizzes_button.TabIndex = 0;
            this.add_quizzes_button.Text = "View Students";
            this.add_quizzes_button.UseVisualStyleBackColor = true;
            this.add_quizzes_button.Click += new System.EventHandler(this.add_quizzes_button_Click);
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
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(858, 375);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // create_quiz_button
            // 
            this.create_quiz_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.create_quiz_button.Location = new System.Drawing.Point(442, 100);
            this.create_quiz_button.Name = "create_quiz_button";
            this.create_quiz_button.Size = new System.Drawing.Size(183, 50);
            this.create_quiz_button.TabIndex = 4;
            this.create_quiz_button.Text = "Create new quiz";
            this.create_quiz_button.UseVisualStyleBackColor = false;
            this.create_quiz_button.Click += new System.EventHandler(this.create_quiz_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your Quizzes:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(631, 129);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 21);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Grammar";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(631, 102);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(66, 21);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Verbs";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // dropdown
            // 
            this.dropdown.FormattingEnabled = true;
            this.dropdown.Location = new System.Drawing.Point(735, 114);
            this.dropdown.Name = "dropdown";
            this.dropdown.Size = new System.Drawing.Size(135, 24);
            this.dropdown.TabIndex = 8;
            // 
            // add_quizes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.dropdown);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.create_quiz_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.settings_button);
            this.Controls.Add(this.leaderboards_button);
            this.Controls.Add(this.add_quizzes_button);
            this.Name = "add_quizes";
            this.Text = "Quizzes";
            this.Load += new System.EventHandler(this.quiz_list_load);
            this.Load += new System.EventHandler(this.designations_load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_quizzes_button;
        private System.Windows.Forms.Button leaderboards_button;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button create_quiz_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox dropdown;
    }
}