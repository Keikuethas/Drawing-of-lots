namespace Жеребьёвка
{
    partial class addCategory
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
            this.label1 = new System.Windows.Forms.Label();
            this.categoryText = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.denyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название категории:";
            // 
            // categoryText
            // 
            this.categoryText.Location = new System.Drawing.Point(142, 10);
            this.categoryText.Name = "categoryText";
            this.categoryText.Size = new System.Drawing.Size(100, 20);
            this.categoryText.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(24, 43);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Готово";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // denyButton
            // 
            this.denyButton.Location = new System.Drawing.Point(166, 43);
            this.denyButton.Name = "denyButton";
            this.denyButton.Size = new System.Drawing.Size(75, 23);
            this.denyButton.TabIndex = 3;
            this.denyButton.Text = "Отмена";
            this.denyButton.UseVisualStyleBackColor = true;
            this.denyButton.Click += new System.EventHandler(this.denyButton_Click);
            // 
            // addCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 73);
            this.Controls.Add(this.denyButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.categoryText);
            this.Controls.Add(this.label1);
            this.Name = "addCategory";
            this.Text = "Добавление категории";
            this.Load += new System.EventHandler(this.addCategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox categoryText;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button denyButton;
    }
}