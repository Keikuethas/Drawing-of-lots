namespace Жеребьёвка
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.chooseCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plusCategory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteMember = new System.Windows.Forms.Button();
            this.getMemberInformation = new System.Windows.Forms.Button();
            this.membersList = new System.Windows.Forms.ListBox();
            this.addMember = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.categorySettings = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.makeTable = new System.Windows.Forms.Button();
            this.exportTable = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Table = new System.Windows.Forms.GroupBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.addTable = new System.Windows.Forms.Button();
            this.deleteTable = new System.Windows.Forms.Button();
            this.openTable = new System.Windows.Forms.Button();
            this.openExcelFile = new System.Windows.Forms.Button();
            this.showSuccess = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseCategory
            // 
            this.chooseCategory.FormattingEnabled = true;
            this.chooseCategory.Location = new System.Drawing.Point(65, 12);
            this.chooseCategory.Name = "chooseCategory";
            this.chooseCategory.Size = new System.Drawing.Size(121, 21);
            this.chooseCategory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Категория:";
            // 
            // plusCategory
            // 
            this.plusCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusCategory.Location = new System.Drawing.Point(192, 12);
            this.plusCategory.Name = "plusCategory";
            this.plusCategory.Size = new System.Drawing.Size(22, 21);
            this.plusCategory.TabIndex = 2;
            this.plusCategory.Text = "+";
            this.plusCategory.UseVisualStyleBackColor = true;
            this.plusCategory.Click += new System.EventHandler(this.plusCategory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteMember);
            this.groupBox2.Controls.Add(this.getMemberInformation);
            this.groupBox2.Controls.Add(this.membersList);
            this.groupBox2.Location = new System.Drawing.Point(843, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 585);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Участники";
            // 
            // deleteMember
            // 
            this.deleteMember.Location = new System.Drawing.Point(183, 550);
            this.deleteMember.Name = "deleteMember";
            this.deleteMember.Size = new System.Drawing.Size(174, 29);
            this.deleteMember.TabIndex = 2;
            this.deleteMember.Text = "Удалить участника";
            this.deleteMember.UseVisualStyleBackColor = true;
            this.deleteMember.Click += new System.EventHandler(this.deleteMember_Click);
            // 
            // getMemberInformation
            // 
            this.getMemberInformation.Location = new System.Drawing.Point(7, 550);
            this.getMemberInformation.Name = "getMemberInformation";
            this.getMemberInformation.Size = new System.Drawing.Size(179, 29);
            this.getMemberInformation.TabIndex = 1;
            this.getMemberInformation.Text = "Информация об участнике";
            this.getMemberInformation.UseVisualStyleBackColor = true;
            this.getMemberInformation.Click += new System.EventHandler(this.getMemberInformation_Click);
            // 
            // membersList
            // 
            this.membersList.FormattingEnabled = true;
            this.membersList.Location = new System.Drawing.Point(7, 20);
            this.membersList.Name = "membersList";
            this.membersList.Size = new System.Drawing.Size(350, 524);
            this.membersList.TabIndex = 0;
            // 
            // addMember
            // 
            this.addMember.Location = new System.Drawing.Point(843, 36);
            this.addMember.Name = "addMember";
            this.addMember.Size = new System.Drawing.Size(363, 29);
            this.addMember.TabIndex = 5;
            this.addMember.Text = "Добавить участника";
            this.addMember.UseVisualStyleBackColor = true;
            this.addMember.Click += new System.EventHandler(this.addMember_Click);
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(1138, 8);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(68, 22);
            this.help.TabIndex = 7;
            this.help.Text = "Справка";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // categorySettings
            // 
            this.categorySettings.Location = new System.Drawing.Point(216, 12);
            this.categorySettings.Name = "categorySettings";
            this.categorySettings.Size = new System.Drawing.Size(135, 21);
            this.categorySettings.TabIndex = 8;
            this.categorySettings.Text = "Настройки категории";
            this.categorySettings.UseVisualStyleBackColor = true;
            this.categorySettings.Click += new System.EventHandler(this.categorySettings_Click);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(991, 8);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(69, 22);
            this.open.TabIndex = 9;
            this.open.Text = "Открыть";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(1062, 8);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(73, 21);
            this.save.TabIndex = 10;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // makeTable
            // 
            this.makeTable.Location = new System.Drawing.Point(745, 9);
            this.makeTable.Name = "makeTable";
            this.makeTable.Size = new System.Drawing.Size(114, 23);
            this.makeTable.TabIndex = 11;
            this.makeTable.Text = "Составить таблицу";
            this.makeTable.UseVisualStyleBackColor = true;
            this.makeTable.Click += new System.EventHandler(this.makeTable_Click);
            // 
            // exportTable
            // 
            this.exportTable.Location = new System.Drawing.Point(410, 621);
            this.exportTable.Name = "exportTable";
            this.exportTable.Size = new System.Drawing.Size(167, 35);
            this.exportTable.TabIndex = 12;
            this.exportTable.Text = "Экспорт таблицы для Excel";
            this.exportTable.UseVisualStyleBackColor = true;
            this.exportTable.Click += new System.EventHandler(this.exportTable_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Table
            // 
            this.Table.BackColor = System.Drawing.SystemColors.Control;
            this.Table.Controls.Add(this.hScrollBar1);
            this.Table.Controls.Add(this.vScrollBar1);
            this.Table.Location = new System.Drawing.Point(1, 36);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(835, 578);
            this.Table.TabIndex = 3;
            this.Table.TabStop = false;
            this.Table.Text = "Турнирная таблица";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(1, 560);
            this.hScrollBar1.Maximum = 0;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(834, 17);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.LargeChange = 1;
            this.vScrollBar1.Location = new System.Drawing.Point(818, 0);
            this.vScrollBar1.Maximum = 0;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 560);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(358, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(247, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = " Ограничить встречи из одной организации";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // addTable
            // 
            this.addTable.Location = new System.Drawing.Point(1, 621);
            this.addTable.Name = "addTable";
            this.addTable.Size = new System.Drawing.Size(161, 35);
            this.addTable.TabIndex = 14;
            this.addTable.Text = "Добавить таблицу к файлу";
            this.addTable.UseVisualStyleBackColor = true;
            this.addTable.Click += new System.EventHandler(this.addTable_Click);
            // 
            // deleteTable
            // 
            this.deleteTable.Location = new System.Drawing.Point(205, 621);
            this.deleteTable.Name = "deleteTable";
            this.deleteTable.Size = new System.Drawing.Size(199, 35);
            this.deleteTable.TabIndex = 15;
            this.deleteTable.Text = "Удалить таблицу для данной категории";
            this.deleteTable.UseVisualStyleBackColor = true;
            this.deleteTable.Click += new System.EventHandler(this.deleteTable_Click);
            // 
            // openTable
            // 
            this.openTable.Location = new System.Drawing.Point(608, 621);
            this.openTable.Name = "openTable";
            this.openTable.Size = new System.Drawing.Size(220, 35);
            this.openTable.TabIndex = 16;
            this.openTable.Text = "Открыть таблицу для данной категории";
            this.openTable.UseVisualStyleBackColor = true;
            this.openTable.Click += new System.EventHandler(this.openTable_Click);
            // 
            // openExcelFile
            // 
            this.openExcelFile.Location = new System.Drawing.Point(861, 9);
            this.openExcelFile.Name = "openExcelFile";
            this.openExcelFile.Size = new System.Drawing.Size(128, 22);
            this.openExcelFile.TabIndex = 17;
            this.openExcelFile.Text = "Открыть Excel файл";
            this.openExcelFile.UseVisualStyleBackColor = true;
            this.openExcelFile.Click += new System.EventHandler(this.openExcelFile_Click);
            // 
            // showSuccess
            // 
            this.showSuccess.AutoSize = true;
            this.showSuccess.Checked = true;
            this.showSuccess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showSuccess.Location = new System.Drawing.Point(611, 15);
            this.showSuccess.Name = "showSuccess";
            this.showSuccess.Size = new System.Drawing.Size(135, 17);
            this.showSuccess.TabIndex = 18;
            this.showSuccess.Text = "сообщения об успехе";
            this.showSuccess.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 659);
            this.Controls.Add(this.showSuccess);
            this.Controls.Add(this.openExcelFile);
            this.Controls.Add(this.openTable);
            this.Controls.Add(this.deleteTable);
            this.Controls.Add(this.addTable);
            this.Controls.Add(this.exportTable);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.makeTable);
            this.Controls.Add(this.save);
            this.Controls.Add(this.open);
            this.Controls.Add(this.categorySettings);
            this.Controls.Add(this.help);
            this.Controls.Add(this.addMember);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.plusCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseCategory);
            this.Name = "Form1";
            this.Text = "Жеребьёвка";
            this.groupBox2.ResumeLayout(false);
            this.Table.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chooseCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button plusCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox membersList;
        private System.Windows.Forms.Button addMember;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button categorySettings;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button makeTable;
        private System.Windows.Forms.Button exportTable;
        private System.Windows.Forms.Button getMemberInformation;
        private System.Windows.Forms.Button deleteMember;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox Table;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button addTable;
        private System.Windows.Forms.Button deleteTable;
        private System.Windows.Forms.Button openTable;
        private System.Windows.Forms.Button openExcelFile;
        private System.Windows.Forms.CheckBox showSuccess;
    }
}

