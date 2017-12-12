using System;
using System.Linq;

namespace CDStore
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new CDStoreDbContext();
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Write("\n\nEnter 1 to add an Artist \n2 to List Artists \n3 Find artist\n4 Find CD\n5 Add a Song\n6 Add a new CD\n9 to Quit : ");
                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        AddArtist(context);
                        break;
                    case '2':
                        ListArtists(context);
                        break;
                    case '3':
                        FindArtist(context);
                        break;
                    case '4':
                        FindCDByTitle(context);
                        break;
                    case '5':
                        AddSong(context);
                        break;
                    case '6':
                        AddCD(context);
                        break;
                    case '9':
                        keepGoing = false;
                        break;
                }
            }
        }

        private static void FindArtist(CDStoreDbContext context)
        {
            Console.WriteLine("Enter Artist's name: ");
            var name = Console.ReadLine();
            var artist = context.Artists.FirstOrDefault(a => a.Name.Contains(name));
            foreach (Song s in artist.Songs)
            {
                Console.WriteLine(s.Title + " " + s.MusicType);
            }

            Console.WriteLine("Artist: " + artist.Name);
        }

        private static void ListArtists(CDStoreDbContext context)
        {
            foreach (Artist a in context.Artists)
            {
                Console.WriteLine(a.Name + " " + a.ArtistId);
            }
            Console.WriteLine();
        }

        private static void AddArtist(CDStoreDbContext context)
        {
            Console.Write("Enter name of new Artist: ");
            string name = Console.ReadLine();
            Artist a = new Artist() { Name = name };
            Console.WriteLine("Saving ...");
            context.Artists.Add(a);
            context.SaveChanges();
        }

        private static void FindCDByTitle(CDStoreDbContext context)
        {
            Console.WriteLine("Enter the name of the song title: ");
            string title = Console.ReadLine();
            CD cd = context.CDs.FirstOrDefault(a => a.Title.Contains(title));
            foreach (Song s in cd.Songs)
            {
                Console.WriteLine(s.Title + " " + s.Artist.Name);
            }

        }
        private static void AddSong(CDStoreDbContext context)
        {
            Console.WriteLine("Enter name of new song: ");
            string name = Console.ReadLine();
            Song a = new Song() { Title = name };
            Console.WriteLine("Saving ...");
            context.Songs.Add(a);
            context.SaveChanges();
        }
        private static void AddCD(CDStoreDbContext context)
        {
            Console.WriteLine("Enter name of new CD: ");
            string name = Console.ReadLine();
            CD cd = new CD() { Title = name, Published = DateTime.Today };
            Console.WriteLine("Saving ...");
            Console.WriteLine("Adding songs to your CD");
            context.CDs.Add(cd);
            context.SaveChanges();
            Console.WriteLine("Enter the name of a song that you wish to add: ");
            string title = Console.ReadLine();
            Song song1 = context.Songs.FirstOrDefault(a => a.Title.Contains(title));
            cd.Songs.Add(song1);
            context.SaveChanges();
        }
    }
}