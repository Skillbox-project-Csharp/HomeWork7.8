using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7._8
{
    struct Note
    {
        public Note(Guid id, string titel, string text, DateTime date, bool archiveStatus)
        {
            this.Id = id;
            this.Titel = titel;
            this.Text = text;
            this.Date = date;
            this.ArchiveStatus = archiveStatus;
        }
        public Note(string titel, string text) :
            this(Guid.NewGuid(), titel, text, DateTime.Now, false)
        { }
        public Note(string titel, string text, DateTime date) : this(titel, text)
        {
            Date = date;
        }

        public Note(string titel, string text, bool archiveStatus) : this(titel, text)
        {
            ArchiveStatus = archiveStatus;
        }

        /// <summary>
        /// Уникальный ID записи
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок записи
        /// </summary>
        public string Titel { get; set;}
        /// <summary>
        /// Текст записи
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Статус помещения в архив
        /// </summary>
        public bool ArchiveStatus { get; set; }

        public override string ToString()
        {

            return $"{Id};{Titel};{Text};{Date};{ArchiveStatus}";
        }


    }
}
