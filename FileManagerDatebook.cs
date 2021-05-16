using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork7._8
{
    class FileManagerDatebook
    {
        /// <summary>
        /// Загрузка из файла заметок в ежедневник
        /// </summary>
        /// <param name="Db">Ежедневник</param>
        /// <param name="path">Путь загрузки+название</param>
        public static void LoadNotes(ref Datebook Db, string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] strs = sr.ReadLine().Split(';');
                        if (strs.Length == 5)
                        {
                            Guid id = Guid.NewGuid();
                            if (Guid.TryParse(strs[0], out id)) { }

                            DateTime date = DateTime.Now;
                            if (DateTime.TryParse(strs[3], out date)) { }

                            bool archiveStatus = false;
                            if (bool.TryParse(strs[4], out archiveStatus)) { }
                            Note note = new Note(id, strs[1], strs[2], date, archiveStatus);
                            Db.Add(note);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл \"{path}\" не найден");
                Console.ResetColor();
            }
            catch (DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Неверная директория \"{path}\"");
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Загрузка из файла заметок в ежедневник, по диапазону дат
        /// </summary>
        /// <param name="Db"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="path"></param>
        public static void LoadNotesByDateRange(ref Datebook Db, DateTime beginDate, DateTime endDate, string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] strs = sr.ReadLine().Split(';');
                        if (strs.Length == 5)
                        {
                            DateTime date = DateTime.Now;
                            if (DateTime.TryParse(strs[3], out date)) { }

                            if (date >= beginDate && date <= endDate)
                            {
                                Guid id = Guid.NewGuid();
                                if (Guid.TryParse(strs[0], out id)) { }

                                bool archiveStatus = false;
                                if (bool.TryParse(strs[4], out archiveStatus)) { }

                                Note note = new Note(id, strs[1], strs[2], date, archiveStatus);
                                Db.Add(note);
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл \"{path}\" не найден");
                Console.ResetColor();
            }
            catch (DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Неверная директория \"{path}\"");
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Сохранить записи ежедневника на диск
        /// </summary>
        /// <param name="Db">Ежедневник</param>
        /// <param name="path">Путь сохранения+название</param>
        public static void SaveNotes(ref Datebook Db, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {

                    foreach (var e in Db.Notes)
                    {
                        sw.WriteLine(e);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл \"{path}\" не найден");
                Console.ResetColor();
            }
            catch (DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Неверная директория \"{path}\"");
                Console.ResetColor();
            }

        }
    }
}
