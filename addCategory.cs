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
    public partial class addCategory : Form
    {
        string[] Categories;
        public string newCategory = "";
        public addCategory(string[] categories)
        {
            InitializeComponent();
            Categories = categories;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (categoryText.Text.Replace(" ", "") == "") MessageBox.Show("Название категории не должно быть пустым.", "Ошибка: название категории", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                foreach (string category in Categories)
                    if (categoryText.Text == category) { MessageBox.Show("Названия категорий не должны совпадать.", "Ошибка: название категории", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            newCategory = categoryText.Text;
            Close();
        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            Close();
            newCategory = "";
        }

        private void addCategory_Load(object sender, EventArgs e)
        {
            categoryText.Text = newCategory;
        }
    }
}
