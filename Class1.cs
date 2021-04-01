using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Жеребьёвка
{
    /// <summary>
    /// Класс участника соревнований
    /// </summary>
    public class Member
    {
        public string name { get; set; }
        public string club { get; set; }
        public string category { get; set; }
    }

    /// <summary>
    /// Класс турнирной таблицы
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Содержание таблицы
        /// </summary>
        public List<List<Member>> content { get; set; }
        /// <summary>
        /// Название категории, для которой построена таблица
        /// </summary>
        public string forCategory { get; set; }

        public Table()
        {
            content = new List<List<Member>>();
        }

        public Table(string category, List<List<Member>> tableContent)
        {
            forCategory = category;
            content = tableContent;
        }
    }

    /// <summary>
    /// Объединение всех данных Жеребьёвки
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Список сохранённых участников
        /// </summary>
        public List<Member> members { get; set; }
        /// <summary>
        /// Список сохранённых категорий
        /// </summary>
        public List<string> categories { get; set; }
        /// <summary>
        /// Список сохранённых таблиц
        /// </summary>
        public List<Table> tables { get; set; }

        public Data()
        {
            members = new List<Member>();
            categories = new List<string>();
            tables = new List<Table>();
        }
    }

    /// <summary>
    /// Объединение всех данных Жеребьёвки для сохранения
    /// </summary>
    public class SaveData
    {
        /// <summary>
        /// Список сохранённых участников
        /// </summary>
        public Member[] members { get; set; }
        /// <summary>
        /// Список сохранённых категорий
        /// </summary>
        public string[] categories { get; set; }
        /// <summary>
        /// Список сохранённых таблиц
        /// </summary>
        public Table[] tables { get; set; }

        public SaveData(Data toSave)
        {
            members = toSave.members.ToArray();
            categories = toSave.categories.ToArray();
            tables = toSave.tables.ToArray();
        }
        public SaveData() { }
    }
}
