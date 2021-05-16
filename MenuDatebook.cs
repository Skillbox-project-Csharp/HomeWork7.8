using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7._8
{
    class MenuDatebook
    {
        public MenuDatebook()
        {
            Db = new Datebook();
            Filter = new Filter();
            Filter.SetAllFilters();
        }
        public Datebook Db { get; set; }
        public Filter Filter { get; set; }

        /// <summary>
        /// Ввод числа типа инт
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int InsertInt(int min, int max)
        {
            int number;
            int posX = Console.CursorLeft, posY = Console.CursorTop;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                    if (number >= min && number <= max)
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.WriteLine(new StringBuilder().Append(' ', Console.LargestWindowWidth - 1));
                        Console.SetCursorPosition(posX, posY);
                        break;
                    }

                Console.SetCursorPosition(posX, posY);
                Console.WriteLine(new StringBuilder().Append(' ', Console.LargestWindowWidth - 1));
                Console.SetCursorPosition(posX, posY);
            }
            return number;
        }
   
        public void Start()
        {
            StringBuilder textMenu = new StringBuilder();
            textMenu.AppendLine("1.Добавить.");
            textMenu.AppendLine("2.Удалить.");
            textMenu.AppendLine("3.Убрать/достать из архива.");
            textMenu.AppendLine("4.Изменить.");
            textMenu.AppendLine("5.Отсортировать.");
            textMenu.AppendLine("6.Сохранить в файл.");
            textMenu.AppendLine("7.Загрузить из файла.");
            textMenu.AppendLine("8.Загрузить из файла, по диапазону дат.");
            textMenu.AppendLine("9.Настроить фильтр отображения записей.");
            textMenu.AppendLine("10.Выход.");

            bool exit = false;
            while (!exit)
            {
                Db.PrintAll(Filter.Filters.ToArray());
                Console.Write(textMenu);
                switch (InsertInt(1, 10))
                {
                    case 1:
                        AddMenu();
                        break;
                    case 2:
                        RemoveMenu();
                        break;
                    case 3:
                        ChangeArchiveStatMenu();
                        break;
                    case 4:
                        ChangeMenu();
                        break;
                    case 5:
                        SortMenu();
                        break;
                    case 6:
                        FileSaveMenu();
                        break;
                    case 7:
                        FileLoadMenu();
                        break;
                    case 8:
                        LoadNotesByDateRangeMenu();
                        break;
                    case 9:
                        FilterSettingMenu();
                        break;

                    case 10:
                        exit = true;
                        break;
                }

            }
        }
        /// <summary>
        /// Меню добавления заметок
        /// </summary>
        private void AddMenu()
        {
            Console.WriteLine("\t1.Ввести заметку");
            Console.WriteLine("\t2.Сгенерировать заметки");
            Console.WriteLine("\t3.Назад");
            switch (InsertInt(1, 3))
            {
                case 1:
                    Db.EnterNode();
                    break;
                case 2:
                    Console.Write("\t\tКол-во сгенерированных заметок: ");
                    int count = InsertInt(0, 1000);
                    for (int i = 0; i < count; i++)
                        Db.GenerateRandNode();
                    break;
                case 3:
                    break;
            }
            Console.Clear();
        }
        /// <summary>
        /// Выбор поля 
        /// </summary>
        /// <returns></returns>
        private NotePole SelectPoleMenu()
        {
            Console.WriteLine("\t\t1.Id.");
            Console.WriteLine("\t\t2.Titel");
            Console.WriteLine("\t\t3.Text");
            Console.WriteLine("\t\t4.Date");
            Console.WriteLine("\t\t5.ArchiveStatus");
            switch (InsertInt(1, 5))
            {
                case 1:
                    return NotePole.Id;
                case 2:
                    return NotePole.Titel;
                case 3:
                    return NotePole.Text;
                case 4:
                    return NotePole.Date;
                case 5:
                    return NotePole.ArchiveStatus;
            }
            return NotePole.Date;
        }
        private void RemoveMenu()
        {
            Console.WriteLine("\t1.Удалить по номеру заметки.");
            Console.WriteLine("\t2.Удалить по полю.");
            Console.WriteLine("\t3.Удалить по соответсвию любому полю.");
            Console.WriteLine("\t4.Удалить все.");
            Console.WriteLine("\t5.Назад");
            string str;
            switch (InsertInt(1, 5))
            {
                case 1:
                    Console.Write("\t\tНомер заметки: ");
                    int index = InsertInt(1, Db.Notes.Count);
                    Db.RemoveAt(index - 1);
                    break;
                case 2:
                    Console.WriteLine("\t\tПоле: ");
                    NotePole pole = SelectPoleMenu();
                    Console.Write("\t\tЧто ищем: ");
                    str = Console.ReadLine();
                    Db.RemoveAll(str, pole);
                    break;
                case 3:
                    Console.Write("\t\tЧто ищем: ");
                    str = Console.ReadLine();
                    Db.RemoveAll(str);
                    break;
                case 4:
                    Console.WriteLine("\t\tВы уверены ?");
                    Console.WriteLine("\t\t 1.Да");
                    Console.WriteLine("\t\t 2.Нет");
                    int answer = InsertInt(1, 2);
                    if (answer == 1)
                        Db.Notes.Clear();
                    break;
                case 5:
                    break;
            }
            Console.Clear();
        }

        private void ChangeArchiveStatMenu()
        {
            Console.Write("\tНомер заметки: ");
            int count = Db.Notes.Count;
            if (count == 0)
            {
                Console.Clear();
                return;
            }
            int index = InsertInt(1, count);
            Db.ChangeArchiveStat(index - 1);
            Console.Clear();
        }

        private void ChangeMenu()
        {
            Console.WriteLine("\t1.Выбрать заметку для редактирования");
            Console.WriteLine("\t2.Назад");
            switch (InsertInt(1, 2))
            {
                case 1:
                    Console.Write("\t\tНомер заметки: ");
                    int count = Db.Notes.Count;
                    if (count == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    int index = InsertInt(1, count);
                    Console.WriteLine();
                    ChangeNoteMenu(index - 1);
                    break;
                case 2:
                    break;
            }

            Console.Clear();
        }

        private void ChangeNoteMenu(int index)
        {
            bool exit = false;
            string str = String.Empty;
            while (!exit)
            {
                Db.PrintAt(index);
                Console.WriteLine("\t1.Изменить \"Titel\".");
                Console.WriteLine("\t2.Изменить \"Text\".");
                Console.WriteLine("\t3.Завершить изменения");
                
                switch(InsertInt(1,3))
                {
                    case 1:
                        Console.Write("\t\tВведите \"Titel\": ");
                        str = Console.ReadLine();
                        Db.ChangePole(str, index, NotePole.Titel);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Write("\t\tВведите \"Text\": ");
                        str = Console.ReadLine();
                        Db.ChangePole(str, index, NotePole.Text);
                        Console.Clear();
                        break;
                    case 3:
                        Db.ChangePole(DateTime.Now.ToString(), index, NotePole.Date);
                        exit = true;
                        break;
                }
            }
        }

        private void SortMenu()
        {
            Console.WriteLine("\tУпорядочить по полю: ");
            Db.Sort(SelectPoleMenu());
            Console.Clear();
        }

        private void FileSaveMenu()
        {
            Datebook DbVrem = Db;
            Console.WriteLine("\t1.Сохранить файл в папке с программой.");
            Console.WriteLine("\t2.Сохранить файл по указанному пути, со своим названием.");
            Console.WriteLine("\t3.Назад");
            switch (InsertInt(1, 3))
            {
                case 1:
                    DbVrem = Db;
                    FileManagerDatebook.SaveNotes(ref DbVrem, AppContext.BaseDirectory + @"\Datebook.csv");
                    break;
                case 2:
                    
                    Console.Write("\t\tПуть: ");
                    string path = Console.ReadLine();
                    Console.Write("\t\tНазвание: ");
                    string name = Console.ReadLine();
                    FileManagerDatebook.SaveNotes(ref DbVrem, path + @"\" + name);
                    break;
                case 3:
                    break;
            }

            Console.Clear();
        }

        private void FileLoadMenu()
        {
            Datebook DbVrem = Db;
            Console.WriteLine("\t1.Загрузить из файла в папки с программой.");
            Console.WriteLine("\t2.Загрузить из указанного пути и файла.");
            Console.WriteLine("\t3.Назад");
            switch (InsertInt(1, 3))
            {
                case 1:
                    DbVrem = Db;
                    FileManagerDatebook.LoadNotes(ref DbVrem, AppContext.BaseDirectory + @"\Datebook.csv");
                    break;
                case 2:

                    Console.Write("\t\tПуть: ");
                    string path = Console.ReadLine();
                    Console.Write("\t\tНазвание: ");
                    string name = Console.ReadLine();
                    FileManagerDatebook.LoadNotes(ref DbVrem, path + @"\" + name);
                    break;
                case 3:
                    break;
            }

            Console.Clear();
        }

        private void LoadNotesByDateRangeMenu()
        {
            Datebook DbVrem = Db;
            DateTime[] dateRange;
            Console.WriteLine("\t1.Загрузить из файла в папки с программой.");
            Console.WriteLine("\t2.Загрузить из указанного пути и файла.");
            Console.WriteLine("\t3.Назад");
            switch (InsertInt(1, 3))
            {
                case 1:
                    DbVrem = Db;
                    dateRange = DateRangeMenu();

                    FileManagerDatebook.LoadNotesByDateRange(ref DbVrem,
                        dateRange[0],
                        dateRange[1],
                        AppContext.BaseDirectory + @"\Datebook.csv");
                    break;
                case 2:
                    dateRange = DateRangeMenu();
                    Console.Write("\t\tПуть: ");
                    string path = Console.ReadLine();
                    Console.Write("\t\tНазвание: ");
                    string name = Console.ReadLine();

                    FileManagerDatebook.LoadNotesByDateRange(ref DbVrem,
                        dateRange[0],
                        dateRange[1],
                        path + @"\" + name);
                    break;
                case 3:
                    break;
            }
            Console.Clear();
        }

        public DateTime[] DateRangeMenu()
        {
            DateTime[] dateRange = new DateTime[2];
            Console.Write("\t\tВведите начальную дату промежутка: ");
            while (!DateTime.TryParse(Console.ReadLine(), out dateRange[0])) { }
            Console.Write("\t\tВведите конечную дату промежутка: ");
            while (!DateTime.TryParse(Console.ReadLine(), out dateRange[1])) { }
          

            return dateRange;
        }

        private void FilterSettingMenu()
        {
            Console.WriteLine("\t1.Добавить фильтр.");
            Console.WriteLine("\t2.Установить все фильтры.");
            Console.WriteLine("\t3.Удалить фильтр.");
            Console.WriteLine("\t4.Назад");

            switch (InsertInt(1, 4))
            {
                case 1:
                    Filter.AddFilter(SelectPoleMenu());
                    break;
                case 2:
                    Filter.SetAllFilters();
                    break;
                case 3:
                    Filter.RemoveFilter(SelectPoleMenu());
                    break;
                case 4:
                    break;

            }
            Console.Clear();
        }
    }
}
