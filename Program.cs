using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7._8
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuDatebook menu = new MenuDatebook();

            /*foreach (var date in menu.DateRangeMenu())
                Console.WriteLine(date);*/
            menu.Start();

            /*            Datebook datebook = new Datebook();
                        Filter filter = new Filter();
                        filter.SetAllFilters();
                        Console.WriteLine(filter.ToString());
                        for (int i = 0; i < 3; i++)
                        {
                            datebook.EnterNode();
                        }
                        FileManagerDatebook.LoadNotesByDateRange(ref datebook, new DateTime(2021, 04, 16), DateTime.Now, AppContext.BaseDirectory + @"\Datebook.csv");

                        datebook.PrintAll(filter.Filters.ToArray());


                        FileManagerDatebook.SaveNotes(ref datebook, AppContext.BaseDirectory + @"\Datebook.csv");
                        Console.WriteLine("|||||||||||||||||||||||||||||||");

                        foreach (var element in datebook.Notes)
                        {
                            Console.WriteLine(element.ToString(NotePole.Titel, NotePole.Text, NotePole.Date));

                        }
                        FileManagerDatebook.SaveNotes(ref datebook, AppContext.BaseDirectory + @"\Datebook.txt");*/
            Console.ReadKey();
        }
    }
}
