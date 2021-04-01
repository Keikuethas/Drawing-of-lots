namespace Жеребьёвка
{
    partial class AddMember
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
            this.nameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clubText = new System.Windows.Forms.TextBox();
            this.categoryChoose = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.denyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(97, 10);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(145, 20);
            this.nameText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Организация:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Категория:";
            // 
            // clubText
            // 
            this.clubText.Location = new System.Drawing.Point(97, 33);
            this.clubText.Name = "clubText";
            this.clubText.Size = new System.Drawing.Size(145, 20);
            this.clubText.TabIndex = 4;
            // 
            // categoryChoose
            // 
            this.categoryChoose.FormattingEnabled = true;
            this.categoryChoose.Location = new System.Drawing.Point(97, 59);
            this.categoryChoose.Name = "categoryChoose";
            this.categoryChoose.Size = new System.Drawing.Size(145, 21);
            this.categoryChoose.TabIndex = 5;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 104);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Готово";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // denyButton
            // 
            this.denyButton.Location = new System.Drawing.Point(166, 104);
            this.denyButton.Name = "denyButton";
            this.denyButton.Size = new System.Drawing.Size(75, 23);
            this.denyButton.TabIndex = 7;
            this.denyButton.Text = "Отмена";
            this.denyButton.UseVisualStyleBackColor = true;
            this.denyButton.Click += new System.EventHandler(this.denyButton_Click);
            // 
            // AddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 140);
            this.Controls.Add(this.denyButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.categoryChoose);
            this.Controls.Add(this.clubText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameText);
            this.Name = "AddMember";
            this.Text = "Добавление участника";
            this.Load += new System.EventHandler(this.AddMember_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clubText;
        private System.Windows.Forms.ComboBox categoryChoose;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button denyButton;
    }
}