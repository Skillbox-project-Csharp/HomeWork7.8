using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7._8
{
    enum NotePole { Id, Titel, Text, Date, ArchiveStatus };
    class Filter
    {
        public SortedSet<NotePole> Filters { get; private set; }
        
        public Filter()
        {
            Filters = new SortedSet<NotePole>();
        }

        public void AddFilter(NotePole pole)
        {
            Filters.Add(pole);
        }

        public void RemoveFilter(NotePole pole)
        {
            Filters.Remove(pole);
        }

        public void SetAllFilters()
        {
            Filters.Add(NotePole.Id);
            Filters.Add(NotePole.Titel);
            Filters.Add(NotePole.Text);
            Filters.Add(NotePole.Date);
            Filters.Add(NotePole.ArchiveStatus);
        }

        public override string ToString()
        {
            string str = String.Empty;
            foreach (var filter in Filters)
                str += filter +";" ;
            return str;
        }
    }
}
