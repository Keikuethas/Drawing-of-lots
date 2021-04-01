using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
//using EPPlus;

namespace Жеребьёвка
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Минимальный размер, в который помещается 1 символ шрифта Label (просто не меняй шрифт и всё будет ок)
        /// </summary>
        const int letterSize = 7;
        List<string> Categories = new List<string>();
        List<Member> members = new List<Member>();
        HScrollBar HScroll;
        VScrollBar VScroll;
        List<List<Member>> TableM = new List<List<Member>>();
        int mostLongNameLength = 0;
        ExcelPackage package = new ExcelPackage();
        Data data = new Data();

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Файлы данных жеребьёвки(*.zher)|*.zher";
            HScroll = hScrollBar1;
            VScroll = vScrollBar1;
        }

        private void addMember_Click(object sender, EventArgs e)
        {
            Member newMember = new Member();
            AddMember add = new AddMember(Categories.ToArray(), members.ToArray());
            add.ShowDialog();
            if (add.success)
            {
                newMember = add.newMemberData;
                members.Add(newMember);
                membersList.Items.Add(newMember.name);
                data.members.Add(newMember);
                if (showSuccess.Checked) MessageBox.Show("Участник успешно добавлен.", "Успех: добавление участника", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void plusCategory_Click(object sender, EventArgs e)
        {
            addCategory add = new addCategory(Categories.ToArray<string>());
            add.ShowDialog();
            if (add.newCategory != "")
            {
                Categories.Add(add.newCategory);
                chooseCategory.Items.Add(add.newCategory);
                data.categories.Add(add.newCategory);
                if (showSuccess.Checked) MessageBox.Show("Категория успешно добавлена.", "Успех: добавление категории", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void getMemberInformation_Click(object sender, EventArgs e)
        {
            if (membersList.Items.Count == 0)
            {
                MessageBox.Show("Чтобы редактировать данные участника, он должен существовать.", "Ошибка: изменение данных участника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AddMember add = new AddMember(Categories.ToArray(), members.ToArray());
            Member newMember = new Member();
            int i = 0;
            if (membersList.SelectedIndex < 0)
            {
                MessageBox.Show("Участник не выбран.", "Ошибка: изменение данных участника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for(; i < members.Count; i++)
                if (members[i].name == membersList.Items[membersList.SelectedIndex].ToString())
                {
                    newMember.name = members[i].name;
                    newMember.club = members[i].club;
                    newMember.category = members[i].category;
                    break;
                }
            add.newMemberData = newMember;
            add.Text = "Редактирование участника";
            add.ShowDialog();
            if (add.success)
            {
                members[i] = add.newMemberData;
                membersList.Items[membersList.SelectedIndex] = add.newMemberData.name;
                if (showSuccess.Checked) MessageBox.Show("Данные участника успешно изменены.", "Успех: изменение данных участника", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void deleteMember_Click(object sender, EventArgs e)
        {
            if (membersList.Items.Count == 0)
            {
                MessageBox.Show("Чтобы удалить участника, он должен существовать.", "Ошибка: удаление участника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            for (int i = 0; i < members.Count; i++)
                if (members[i].name == membersList.Items[membersList.SelectedIndex].ToString())
                    members.Remove(members[i]);
            membersList.Items.Remove(membersList.Items[membersList.SelectedIndex]);
            if (showSuccess.Checked) MessageBox.Show("Участник успешно удалён", "Успех: удаление участника", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void categorySettings_Click(object sender, EventArgs e)
        {
            if (chooseCategory.Items.Count == 0)
            {
                MessageBox.Show("Чтобы редактировать данные категории, она должна существовать.", "Ошибка: изменение данных категории", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            addCategory add = new addCategory(Categories.ToArray<string>());
            int i = 0;
            for (; i < Categories.Count; i++)
                if (Categories[i] == chooseCategory.Text)
                {
                    add.newCategory = Categories[i];
                    break;
                }
            if (add.newCategory == "")
            {
                MessageBox.Show("Выбранная категория не соответствует ни одной из созданных ранее.", "Ошибка: изменение данных категории", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            add.Text = "Редактирование категории";
            add.ShowDialog();
            if (add.newCategory != "")
            {
                for (int n = 0; n < members.Count; n++)
                    if (members[n].category == Categories[i])
                        members[n].category = add.newCategory;
                Categories[i] = add.newCategory;
                chooseCategory.Items[chooseCategory.SelectedIndex] = add.newCategory;
                //Изменение имени страницы страницы, если она есть в файле
                for (int n = 0; n < package.Workbook.Worksheets.Count; n++)
                    if (package.Workbook.Worksheets[n].Name == "Турнирная таблица " + Categories[i])
                    {
                        package.Workbook.Worksheets[n].Name = "Турнирная таблица " + add.newCategory;
                        break;
                    }
                //Изменение категории таблиц для данной категории, если они есть
                for (int n = 0; n < data.tables.Count; n++)
                    if (data.tables[n].forCategory == Categories[i])
                    {
                        data.tables[n].forCategory = add.newCategory;
                        break;
                    }
                if (showSuccess.Checked) MessageBox.Show("Данные категории успешно изменены.", "Успех: изменение данных категории", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Файлы данных жеребьёвки(*.zher)|*.zher";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                data.members = members;
                data.categories = Categories;
                SaveData toSave = new SaveData(data);
                string json = JsonSerializer.Serialize(toSave);
                File.WriteAllText(saveFileDialog1.FileName, json);
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (Categories.Count == 0)
            MessageBox.Show("Перед открытие нового файла рекомендуется сохранить текущий, если вы ещё этого не сделали.",
                "Предупреждение: открытие файла", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveData Saved = new SaveData();
                string json = File.ReadAllText(openFileDialog1.FileName);
                Saved = JsonSerializer.Deserialize<SaveData>(json);
                members = Saved.members.ToList();
                Categories = Saved.categories.ToList();
                membersList.Items.Clear();
                data.tables = Saved.tables.ToList();
                foreach (Member member in members)
                    membersList.Items.Add(member.name);
                chooseCategory.Items.Clear();
                foreach (string category in Categories)
                    chooseCategory.Items.Add(category);
            }
        }

        private void makeTable_Click(object sender, EventArgs e)
        {
            //==========================Проверка==============================
            if (Categories.Count == 0)
            {
                MessageBox.Show("Невозможно составить таблицу без категории.", "Ошибка: составление таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int i = 0;
            bool categoryVerified = false;
            for (; i < Categories.Count; i++)
                if (Categories[i] == chooseCategory.Text)
                {
                    categoryVerified = true;
                    break;
                }
            if (!categoryVerified)
            {
                MessageBox.Show("Выбранная категория не соответствует ни одной из созданных ранее.", "Ошибка: составление таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Member> inTableMembers = new List<Member>();
            
            foreach (Member member in members)
                if (member.category == Categories[i]) { inTableMembers.Add(member); if (member.name.Length > mostLongNameLength) mostLongNameLength = member.name.Length; }
            if (inTableMembers.Count <= 1)
            {
                MessageBox.Show("Недостаточно участников в категории для построения таблицы.", "Ошибка: составление таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //==========================Проверка==============================

            //Сортировка, если нужно
            if (checkBox1.Checked)
                for(int mn = 0; mn < inTableMembers.Count-2; mn+=2)
                    for(int n = mn; n < inTableMembers.Count-1; n++)
                        if (inTableMembers[n].club == inTableMembers[n+1].club)
                        {
                            Member toReplace = inTableMembers[n + 1];
                            inTableMembers.Remove(inTableMembers[n + 1]);
                            inTableMembers.Add(toReplace);
                        }

            //Сброс элементов управления
            Table.Controls.Clear();

            //Сброс списка участников таблицы
            TableM.Clear();
            //Добавляем "нулевой этап"
            TableM.Add(new List<Member>());

            //Если нечётное количество участников, просто добавляем ещё одного =P
            if (inTableMembers.Count % 2 != 0) inTableMembers.Add(new Member() { category = Categories[i], club = "Не знаю, как была получена эта информация, но знай, что я люблю пельмени." });
            for (int n = 0; n < inTableMembers.Count; n++) //заполнение участников
            {
                //Добавляем участника в "нулевой этап"
                TableM[0].Add(inTableMembers[n]);

                //Добавление нового элемента Tabel, представляющего участника
                Label label = new Label();
                label.Location = new System.Drawing.Point(10, 15 * (n + 1));
                if (inTableMembers[n].name != null) label.BackColor = (n % 2 == 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                label.ForeColor = (n % 2 != 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                label.Text = inTableMembers[n].name;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Size = new System.Drawing.Size(mostLongNameLength * letterSize, 15);
                label.Click += LabelClick;
                label.Name = 0 + "-" + n;
                Table.Controls.Add(label);
            }

            //позиции соседних элементов для расчёта шага
            int pos1 = 0;
            int pos2 = 0;

            //добавляем первый этап
            TableM.Add(new List<Member>());
            for (int bn = 0; bn < (int)Math.Round(inTableMembers.Count / 2.0); bn++)//первый этап
            {
                //Добавляем участника
                TableM[TableM.Count - 1].Add(new Member());
                Label label = new Label();
                label.Location = new System.Drawing.Point(mostLongNameLength * letterSize + 10, 15 + 30 * bn + 30 / 4 * (int)Math.Pow(2, 0));
                if (bn == 0) pos1 = 15 + 30 * bn + 30 / 4 * (int)Math.Pow(2, 0);
                if (bn == 1) pos2 = 15 + 30 * bn + 30 / 4 * (int)Math.Pow(2, 0);
                label.BackColor = (bn % 2 == 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                label.ForeColor = (bn % 2 != 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Size = new System.Drawing.Size(mostLongNameLength * letterSize, 15);
                label.Click += LabelClick;
                label.Name = 1 + "-" + bn;
                Table.Controls.Add(label);
            }

            int levels = 1;
            for (int left = inTableMembers.Count + (inTableMembers.Count % 2); left > 1; left /= 2)
                levels++;

            for (int an = 2; an < levels + (inTableMembers.Count % 3 == 0 ? 1 : 0); an++)//следующие этапы
            {
                //Добавление следующего этапа
                TableM.Add(new List<Member>());
                int step = pos2 - pos1; //шаг
                int startPos = pos1 + step / 2; //начало отсчёта
                for (int bn = 0; bn < Math.Round(inTableMembers.Count / Math.Pow(2, an)) /*+ (an == levels && inTableMembers.Count % 3 == 0 ? 1 : 0)*/; bn++)
                {
                    Label label = new Label();
                    //добавление участника
                    TableM[TableM.Count - 1].Add(new Member());
                    label.Location = new System.Drawing.Point(mostLongNameLength * letterSize * an + 10, startPos + step * bn * 2);//30 + 15 * (int)Math.Pow(2, an) * bn - (int)Math.Round(15.0 * an / 2.0) + 22 * (an-1) //30 * (bn+1) - 7 + 15 * (an-1)
                    if (bn == 0) pos1 = startPos + step * bn * 2;
                    if (bn == 1) pos2 = startPos + step * bn * 2;
                    label.BackColor = (bn % 2 == 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                    label.ForeColor = (bn % 2 != 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    label.Click += LabelClick;
                    label.Size = new System.Drawing.Size(mostLongNameLength * letterSize, 15);
                    label.Name = an + "-" + bn;
                    Table.Controls.Add(label);
                }
            }

            //возвращение и настройка ползунков
            VScroll.Maximum = (int)Math.Round(Table.Size.Height / (15.0 * (inTableMembers.Count + 1)));
            HScroll.Maximum = (int)Math.Round(Table.Size.Width / (10.0 + letterSize * mostLongNameLength * (levels+1)));
            Table.Controls.Add(VScroll);
            Table.Controls.Add(HScroll);

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (Control label in Table.Controls)
                if (label.GetType() == new Label().GetType()) //Если элемент - Label
                    label.Location = new System.Drawing.Point(label.Location.X, label.Location.Y - (e.NewValue - e.OldValue) * 15);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (Control label in Table.Controls)
                if (label.GetType() == new Label().GetType()) //Если элемент - Label
                    label.Location = new System.Drawing.Point(label.Location.X - (e.NewValue - e.OldValue) * letterSize * mostLongNameLength, label.Location.Y);
        }




        private void addTable_Click(object sender, EventArgs e)
        {
            //==========================Проверка==============================
            if (Categories.Count == 0)
            {
                MessageBox.Show("Невозможно составить таблицу без категории.", "Ошибка: составление таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int i = 0;
            bool categoryVerified = false;
            for (; i < Categories.Count; i++)
                if (Categories[i] == chooseCategory.Text)
                {
                    categoryVerified = true;
                    break;
                }
            if (!categoryVerified)
            {
                MessageBox.Show("Выбранная категория не соответствует ни одной из созданных ранее.", "Ошибка: составление таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Member> inTableMembers = new List<Member>();

            foreach (Member member in members)
                if (member.category == Categories[i]) { inTableMembers.Add(member); if (member.name.Length > mostLongNameLength) mostLongNameLength = member.name.Length; }
            if (inTableMembers.Count <= 1)
            {
                MessageBox.Show("Недостаточно участников в категории для построения таблицы.", "Ошибка: составление таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //==========================Проверка==============================


            //Сортировка, если нужно
            if (checkBox1.Checked)
                for (int mn = 0; mn < inTableMembers.Count - 2; mn+=2)
                    for (int n = mn; n < inTableMembers.Count - 1; n++)
                        if (inTableMembers[n].club == inTableMembers[n + 1].club)
                        {
                            Member toReplace = inTableMembers[n + 1];
                            inTableMembers.Remove(inTableMembers[n + 1]);
                            inTableMembers.Add(toReplace);
                        }

            //Удаление страницы, если она уже есть в файле
            foreach (ExcelWorksheet sh in package.Workbook.Worksheets)
                if (sh.Name == "Турнирная таблица " + Categories[i])
                {
                    package.Workbook.Worksheets.Delete("Турнирная таблица " + Categories[i]);
                    break;
                }

            var sheet = package.Workbook.Worksheets.Add("Турнирная таблица " + Categories[i]);

            sheet.Cells["A1"].Value = "Участники:";
            for (int n = 0; n / 2 < inTableMembers.Count; n += 2) //заполнение участников (здесь шаг = 2, чтобы оставить место между участниками)
            {

                //Устанавливаем цвет текста по номеру
                sheet.Cells[n + 2, 1].Style.Font.Color.SetColor(n / 2 % 2 == 0 ? System.Drawing.Color.Blue : System.Drawing.Color.Red);
                //Вписываем имя
                sheet.Cells[n + 2, 1].Value = inTableMembers[n / 2].name;
            }

            sheet.Column(1).AutoFit();


            for (int bn = 0; bn < Math.Round(inTableMembers.Count / 2.0); bn++)//первый этап
            {

                //Вписываем имя, если оно записано в таблице
                if (TableM[1][bn].name != "")
                    sheet.Cells[3 + bn * 4, 2].Value = TableM[1][bn].name;
                else
                    sheet.Cells[3 + bn * 4, 2].Value = 1; //иначе пишем номер этапа
                //Устанавливаем цвет текста по номеру
                sheet.Cells[3 + bn * 4, 2].Style.Font.Color.SetColor(bn % 2 == 0 ? System.Drawing.Color.Blue : System.Drawing.Color.Red);
            }

            sheet.Column(2).AutoFit();

            int levels = 2;
            for (int left = inTableMembers.Count + (inTableMembers.Count % 2); left > 1; left /= 2)
                levels++;

            for (int an = 3; an < levels + (inTableMembers.Count % 3 == 0 ? 1 : 0); an++)//следующие этапы
            {
                int step = (int)Math.Pow(2, an); //шаг
                int startPos = increased(3, an - 2);

                for (int bn = 0; bn < Math.Round(inTableMembers.Count / Math.Pow(2, an - 1)); bn++)
                {

                    //Вписываем имя
                    if (TableM[1][bn].name != "")
                        sheet.Cells[startPos + step * bn, an].Value = TableM[an - 1][bn].name;
                    else
                        sheet.Cells[startPos + step * bn, an].Value = an - 1; //иначе пишем номер этапа
                    //Устанавливаем цвет текста по номеру
                    sheet.Cells[startPos + step * bn, an].Style.Font.Color.SetColor(bn % 2 == 0 ? System.Drawing.Color.Blue : System.Drawing.Color.Red);
                }
                sheet.Column(an).AutoFit();
            }

            //Удаление таблицы для данной категории, если она есть (мало ли -\(-_-)/- )
            foreach (Table t in data.tables)
                if (t.forCategory == Categories[i])
                {
                    data.tables.Remove(t);
                    break;
                }
            //добавление таблицы к остальным
            List<Member>[] newOne = new List<Member>[TableM.ToArray().Length];
            TableM.CopyTo(newOne);
            List<List<Member>> newone = new List<List<Member>>();
            newone.AddRange(newOne);
            data.tables.Add(new Table(Categories[i], newone));
        }

        /// <summary>
        /// Событие нажатия на участника, тут он должен переходить на следующий этап...
        /// </summary>
        public void LabelClick(object sender, EventArgs e)
        {
            //Если некому переходить...
            if ((sender as Label).Text == "")
                return;

            //Переход участника 
            Label label = sender as Label;
            int an = 0;
            int bn = 0;
            //==========================ПАРСИНГ an И bn=====================================
            string helperstr = "";
            int i = 0;
            for (; i < label.Name.Length && label.Name[i] != '-'; i++)
                helperstr += label.Name[i];
            if (!int.TryParse(helperstr, out an))
            {
                MessageBox.Show("Ошибка: имя не содержит верного [an]. Если вы получили эту ошибку во время работы, обратитесь к разработчику (контакты указаны в справке)", "Внутренняя ошибка");
                return;
            }
                i++;
            helperstr = "";
            for (; i < label.Name.Length; i++)
                helperstr += label.Name[i];
            if (!int.TryParse(helperstr, out bn))
            {
                MessageBox.Show("Ошибка: имя не содержит верного [bn]. Если вы получили эту ошибку во время работы, обратитесь к разработчику (контакты указаны в справке)", "Внутренняя ошибка");
                return;
            }
            //==========================ПАРСИНГ an И bn=====================================

            //Номер следующего элемента по вертикали, он же номер пары
            int truncBn = (int)Math.Truncate(bn / 2.0);
            //перемещение участника в следующий этап
            try
            {
                TableM[an + 1][truncBn] = TableM[an][bn];
            }
            catch 
            {
                MessageBox.Show("Невозможно переместить участника дальше финала", "Ошибка: перемещение участника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Label l = (Label)Table.Controls.Find(an+1 + "-" + truncBn, false)[0];
            l.Text = TableM[an+1][truncBn].name;
        }

        public int increased(int start, int count)
        {
            for (; count > 0; count--)
                start += (int)Math.Pow(2, count);
            return start;
        }

        private void exportTable_Click(object sender, EventArgs e)
        {
            Export export = new Export();
            foreach (Table t in data.tables)
                export.Categories.Add(t.forCategory);
            export.ShowDialog();
            if (!export.success) return;
            saveFileDialog1.Filter = "файлы Excel (*.xlsx)|*.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                for (int i = 0; i < 10; i++)
                    try
                    {
                        File.WriteAllBytes(saveFileDialog1.FileName, package.GetAsByteArray());
                        return;
                    }
                    catch { }
           MessageBox.Show("Файл не сохранён. Взможно, он занят другой программой. Закройте все программы, использующие выбранный файл и повторите попытку. Если это не помогло, перезапустите Жеребьёвку.", "Ошибка: экспорт файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
        }

        private void deleteTable_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool categoryVerified = false;
            for (; i < Categories.Count; i++)
                if (Categories[i] == chooseCategory.Text)
                {
                    categoryVerified = true;
                    break;
                }
            if (!categoryVerified)
            {
                MessageBox.Show("Выбранная категория не соответствует ни одной из созданных ранее.", "Ошибка: удаление таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Table t in data.tables)
                if (t.forCategory == Categories[i])
                {
                    data.tables.Remove(t);
                    if (showSuccess.Checked) MessageBox.Show("Таблица для данной категории удалена.", "Успех: удаление таблицы", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
        }

        private void openTable_Click(object sender, EventArgs e)
        {

            int i = 0;
            bool categoryVerified = false;
            for (; i < Categories.Count; i++)
                if (Categories[i] == chooseCategory.Text)
                {
                    categoryVerified = true;
                    break;
                }
            if (!categoryVerified)
            {
                MessageBox.Show("Выбранная категория не соответствует ни одной из созданных ранее.", "Ошибка: открытие таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Member member in members)
                if (member.category == Categories[i])
                    if (member.name.Length > mostLongNameLength) mostLongNameLength = member.name.Length;
            //Сброс элементов управления
            Table.Controls.Clear();
            Table thist = new Table();

            foreach (Table t in data.tables)
                if (t.forCategory == Categories[i])
                { thist = new Table(t.forCategory, t.content); break; }
            if (thist.content.Count == 0)
            {
                MessageBox.Show("Таблица для данной категории не найдена.", "Ошибка: открытие таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Сброс списка участников таблицы
            TableM.Clear();
            //Добавляем "нулевой этап"
            TableM.Add(new List<Member>());

            for (int n = 0; n < thist.content[0].Count; n++) //заполнение участников
            {
                //Добавляем участника в "нулевой этап"
                TableM[0].Add(thist.content[0][n]);

                //Добавление нового элемента Tabel, представляющего участника
                Label label = new Label();
                label.Location = new System.Drawing.Point(10, 15 * (n + 1));
                label.BackColor = (n % 2 == 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                label.ForeColor = (n % 2 != 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                label.Text = thist.content[0][n].name;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Size = new System.Drawing.Size(mostLongNameLength * letterSize, 15);
                label.Click += LabelClick;
                label.Name = 0 + "-" + n;
                Table.Controls.Add(label);
            }

            //позиции соседних элементов для расчёта шага
            int pos1 = 0;
            int pos2 = 0;

            //добавляем первый этап
            TableM.Add(new List<Member>());
            for (int bn = 0; bn < Math.Round(thist.content[0].Count / 2.0); bn++)//первый этап
            {
                TableM[TableM.Count - 1].Add(thist.content[1][bn]);
                Label label = new Label();
                label.Location = new System.Drawing.Point(mostLongNameLength * letterSize + 10, 15 + 30 * bn + 30 / 4 * (int)Math.Pow(2, 0));
                if (bn == 0) pos1 = 15 + 30 * bn + 30 / 4 * (int)Math.Pow(2, 0);
                if (bn == 1) pos2 = 15 + 30 * bn + 30 / 4 * (int)Math.Pow(2, 0);
                label.BackColor = (bn % 2 == 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                label.ForeColor = (bn % 2 != 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                label.Size = new System.Drawing.Size(mostLongNameLength * letterSize, 15);
                label.Click += LabelClick;
                label.Name = 1 + "-" + bn;
                label.Text = thist.content[1][bn].name;
                Table.Controls.Add(label);
            }

            int levels = 1;
            for (int left = thist.content[0].Count + (thist.content[0].Count % 2); left > 1; left /= 2)
                levels++;

            for (int an = 2; an < levels; an++)//следующие этапы
            {
                //Добавление следующего этапа
                TableM.Add(new List<Member>());
                int step = pos2 - pos1; //шаг
                int startPos = pos1 + step / 2; //начало отсчёта
                for (int bn = 0; bn < Math.Round(thist.content[0].Count / Math.Pow(2, an)); bn++)
                {
                    Label label = new Label();
                    //TableM[TableM.Count - 1].Add(new Member());
                    TableM[TableM.Count - 1].Add(thist.content[an][bn]);
                    label.Location = new System.Drawing.Point(mostLongNameLength * letterSize * an + 10, startPos + step * bn * 2);//30 + 15 * (int)Math.Pow(2, an) * bn - (int)Math.Round(15.0 * an / 2.0) + 22 * (an-1) //30 * (bn+1) - 7 + 15 * (an-1)
                    if (bn == 0) pos1 = startPos + step * bn * 2;
                    if (bn == 1) pos2 = startPos + step * bn * 2;
                    label.BackColor = (bn % 2 == 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                    label.ForeColor = (bn % 2 != 0) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                    label.Click += LabelClick;
                    label.Size = new System.Drawing.Size(mostLongNameLength * letterSize, 15);
                    label.Name = an + "-" + bn;
                    label.Text = thist.content[an][bn].name;
                    Table.Controls.Add(label);
                }
            }

            //возвращение и настройка ползунков
            VScroll.Maximum = (int)Math.Round(Table.Size.Height / (15.0 * (thist.content[0].Count + 1)));
            HScroll.Maximum = (int)Math.Round(Table.Size.Width / (10.0 + letterSize * mostLongNameLength * (levels + 1)));
            Table.Controls.Add(VScroll);
            Table.Controls.Add(HScroll);
        }

        private void openExcelFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обратите внимание на то, что выбранный вами файл будет открыт для редактирования. Никакие данные из него загружены в программу не будут, однако, они могут быть изменены. Пример: удаление таблицы выбранной категории.",
                "Предупреждение: открытие файла таблиц", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                try
                {
                    package = new ExcelPackage(new FileInfo(openFileDialog1.FileName));
                }
                catch { MessageBox.Show("Ошибка при открытии файла таблиц.", "Ошибка: открытие файла таблиц", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void help_Click(object sender, EventArgs e)
        {
            help help = new help();
            help.Show();
        }
    }
}
