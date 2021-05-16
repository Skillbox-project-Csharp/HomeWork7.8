using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7._8
{

    class Datebook
    {
        public List<Note> Notes { get; set; }
        private readonly Random rand = new Random();
        public Datebook()
        {
            Notes = new List<Note>();
        }
        /// <summary>
        /// Вывести все заметки, в нужной последовательности полей
        /// </summary>
        /// <param name="poles">Поля заметки</param>
        public void PrintAll(params NotePole[] poles)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            int count = 1;

            string patern = "{0,13}: {1}";
            string[] headerArr = { "Id", "Titel", "Text", "Date", "ArchiveStatus" };

            foreach (var note in Notes)
            {
                if (!note.ArchiveStatus)
                {
                    Console.WriteLine($"Заметка {count}:");

                    StringBuilder outNoteData = new StringBuilder();
                    string[] strs = note.ToString().Split(';');

                    foreach (var e in poles)
                    {
                        outNoteData.AppendFormat(patern, headerArr[(int)e], strs[(int)e]);
                        outNoteData.AppendLine();

                    }
                    Console.WriteLine(outNoteData);
                }
                count++;
            }
            Console.ResetColor();
        }
        public void PrintAt(int index)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;

            string patern = "{0,13}: {1}";
            string[] headerArr = { "Id", "Titel", "Text", "Date", "ArchiveStatus" };
            Note note = Notes[index];

            Console.WriteLine($"Заметка {index + 1}:");

            StringBuilder outNoteData = new StringBuilder();
            string[] strs = note.ToString().Split(';');

            for(int i = 0; i < 5;i++)
            {
                outNoteData.AppendFormat(patern, headerArr[i], strs[i]);
                outNoteData.AppendLine();

            }
            Console.WriteLine(outNoteData);
            Console.ResetColor();
        }
        /// <summary>
        /// Добавить заметку в ежедневник
        /// </summary>
        /// <param name="note"></param>
        public void Add(Note note)
        {
            Notes.Add(note);
        }
        /// <summary>
        /// Ввод новой заметки
        /// </summary>
        public void EnterNode()
        {
            Console.WriteLine($"Запись {Notes.Count + 1}:");
            Console.Write(" Заголовок: ");
            string titel = Console.ReadLine();
            Console.Write(" Текст: ");
            string text = Console.ReadLine();
            Add(new Note(titel, text));
        }
        /// <summary>
        /// Генерация рандомной заметки
        /// </summary>
        public void GenerateRandNode()
        {
            Add(new Note(GenerateRandString(20), GenerateRandString(255)));
        }
        /// <summary>
        /// Сортировка заметок по полю
        /// </summary>
        /// <param name="pole"></param>
        public void Sort(NotePole pole)
        {
            switch (pole)
            {
                case NotePole.Id:
                    Notes.Sort((o1, o2) => o1.Id.CompareTo(o2.Id));
                    break;
                case NotePole.Titel:
                    Notes.Sort((o1, o2) => o1.Titel.CompareTo(o2.Titel));
                    break;
                case NotePole.Text:
                    Notes.Sort((o1, o2) => o1.Text.CompareTo(o2.Text));
                    break;
                case NotePole.Date:
                    Notes.Sort((o1, o2) => o1.Date.CompareTo(o2.Date));
                    break;
                case NotePole.ArchiveStatus:
                    Notes.Sort((o1, o2) => o1.ArchiveStatus.CompareTo(o2.ArchiveStatus));
                    break;
            }
        }
        /// <summary>
        /// Генератор рандомного текста
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private string GenerateRandString(int size)
        {

            string str = String.Empty;
            for (int i = 0; i < size; i++)
            {
                char symbol = (char)rand.Next(61, 91);
                str += symbol;
            }

            return str;
        }
        /// <summary>
        /// Удаление по индексу элемента
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Notes.Count)
                Notes.RemoveAt(index);
        }
        /// <summary>
        /// Удалить элементы по полю
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pole"></param>
        public void RemoveAll(string str, NotePole pole)
        {
            switch (pole)
            {
                case NotePole.Id:
                    Guid guid;
                    if (Guid.TryParse(str, out guid))
                        Notes.RemoveAll(o => o.Id == guid);
                    break;
                case NotePole.Titel:
                    Notes.RemoveAll(o => o.Titel == str);
                    break;
                case NotePole.Text:
                    Notes.RemoveAll(o => o.Text == str);
                    break;
                case NotePole.Date:
                    DateTime date;
                    if (DateTime.TryParse(str, out date))
                        Notes.RemoveAll(o => o.Date == date);
                    break;
                case NotePole.ArchiveStatus:
                    bool archiveStatus;
                    if (bool.TryParse(str, out archiveStatus))
                        Notes.RemoveAll(o => o.ArchiveStatus == archiveStatus);
                    break;
            }
        }
        /// <summary>
        /// Удалить элементы с соотвествующим ID
        /// </summary>
        /// <param name="id"></param>
        public void RemoveAll(Guid id)
        {
            Notes.RemoveAll(o => o.Id == id);
        }
        /// <summary>
        /// Удалить элементы с соотвествующей датой
        /// </summary>
        /// <param name="date"></param>
        public void RemoveAll(DateTime date)
        {
            Notes.RemoveAll(o => o.Date == date);
        }
        /// <summary>
        /// Удалить элементы с соотвествующим статусом
        /// </summary>
        /// <param name="archiveStatus"></param>
        public void RemoveAll(bool archiveStatus)
        {
            Notes.RemoveAll(o => o.ArchiveStatus == archiveStatus);
        }
        /// <summary>
        /// Удалить элементы соответсвующие задоной строке
        /// </summary>
        /// <param name="str"></param>
        public void RemoveAll(string str)
        {
            DateTime RemovDate;
            if (DateTime.TryParse(str, out RemovDate))
                Notes.RemoveAll(o => o.Date.ToString() == RemovDate.ToString());//Почему

            Guid guid;
            if (Guid.TryParse(str, out guid))
                Notes.RemoveAll(o => o.Id == guid);

            Notes.RemoveAll(o => o.Titel == str);

            Notes.RemoveAll(o => o.Text == str);

            bool archiveStatus;
            if (bool.TryParse(str, out archiveStatus))
                Notes.RemoveAll(o => o.ArchiveStatus == archiveStatus);
        }
        /// <summary>
        /// Изменить поле в заметке
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        /// <param name="pole"></param>
        public void ChangePole(string str, int index, NotePole pole)
        {
            Note noteVrem;
            if (index >= 0 && index < Notes.Count)
                switch (pole)
                {
                    case NotePole.Id:
                        Guid guid;
                        if (Guid.TryParse(str, out guid))
                        {
                            noteVrem = Notes[index];
                            noteVrem.Id = guid;
                            Notes[index] = noteVrem;
                        }
                        break;
                    case NotePole.Titel:
                        noteVrem = Notes[index];
                        noteVrem.Titel = str;
                        Notes[index] = noteVrem;
                        break;
                    case NotePole.Text:
                        noteVrem = Notes[index];
                        noteVrem.Text = str;
                        Notes[index] = noteVrem;
                        break;
                    case NotePole.Date:
                        DateTime date;
                        if (DateTime.TryParse(str, out date))
                        {
                            noteVrem = Notes[index];
                            noteVrem.Date = date;
                            Notes[index] = noteVrem;
                        }
                        break;
                    case NotePole.ArchiveStatus:
                        bool archiveStatus;
                        if (bool.TryParse(str, out archiveStatus))
                        {
                            noteVrem = Notes[index];
                            noteVrem.ArchiveStatus = archiveStatus;
                            Notes[index] = noteVrem;
                        }
                        break;
                }
        }
        /// <summary>
        /// Изменить статус заметке о нахождения в архиве
        /// </summary>
        /// <param name="indexNote"></param>
        public void ChangeArchiveStat(int indexNote)
        {
            if (indexNote >= 0 && indexNote < Notes.Count)
            {
                Note note = Notes[indexNote];
                note.ArchiveStatus = !note.ArchiveStatus;
                Notes[indexNote] = note;
            }

        }


    }
}
