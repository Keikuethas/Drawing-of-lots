namespace Жеребьёвка
{
    partial class Export
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Continue = new System.Windows.Forms.Button();
            this.Deny = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Будут экспортированы таблицы для следующих категорий:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(308, 147);
            this.listBox1.TabIndex = 1;
            // 
            // Continue
            // 
            this.Continue.Location = new System.Drawing.Point(13, 184);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(138, 23);
            this.Continue.TabIndex = 2;
            this.Continue.Text = "Продолжить";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // Deny
            // 
            this.Deny.Location = new System.Drawing.Point(179, 184);
            this.Deny.Name = "Deny";
            this.Deny.Size = new System.Drawing.Size(142, 23);
            this.Deny.TabIndex = 3;
            this.Deny.Text = "Отмена";
            this.Deny.UseVisualStyleBackColor = true;
            this.Deny.Click += new System.EventHandler(this.Deny_Click);
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 216);
            this.Controls.Add(this.Deny);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "Export";
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Button Deny;
    }
}