using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Жеребьёвка
{
    public partial class AddMember : Form
    {
        string[] Categories;
        public bool success = false;
        public Member newMemberData = new Member();
        Member[] members;

        public AddMember(string[] categories, Member[] members)
        {
            InitializeComponent();
            Categories = categories;
            this.members = members;
            ToolTip t = new ToolTip();
            t.SetToolTip(categoryChoose, "Категория, созданная на главном окне");
            ToolTip t2 = new ToolTip();
            t2.SetToolTip(clubText, "Название организации (школа/город/область/страна), к которой принадлежит участник");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameText.Text != "")
            {
                foreach (Member member in members)
                    if (nameText.Text == member.name && nameText.Text != newMemberData.name) { MessageBox.Show("Имена участников не должны совпадать.", "Ошибка: имя участника", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            else MessageBox.Show("Имя участника не должно быть пустым.", "Ошибка: имя участника", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (clubText.Text != "") newMemberData.club = clubText.Text;
            else MessageBox.Show("Название организации не должно быть пустым.", "Ошибка: название организации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            bool categoryVerified = false;
            if (categoryChoose.Text == "") MessageBox.Show("Категория не выбрана.", "Ошибка: категория", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                foreach (string category in Categories)
                    if (category == categoryChoose.Text) { categoryVerified = true; newMemberData.category = categoryChoose.Text; break; }
                if (!categoryVerified) MessageBox.Show("Выбранная категория не соответствует ни одной из созданных ранее.", "Ошибка: категория", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                if (nameText.Text != "" && clubText.Text != "" && categoryVerified) { newMemberData.name = nameText.Text; success = true; Close(); }
        }

        private void AddMember_Load(object sender, EventArgs e)
        {
            nameText.Text = newMemberData.name;
            clubText.Text = newMemberData.club;
            categoryChoose.Text = newMemberData.category;
            categoryChoose.Items.AddRange(Categories);
        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            success = false;
            Close();
        }
    }
}
