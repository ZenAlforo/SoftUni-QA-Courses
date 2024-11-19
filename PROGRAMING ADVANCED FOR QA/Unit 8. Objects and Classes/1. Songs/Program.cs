using System.Runtime.InteropServices;

namespace _1._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Song> songList = new List<Song>();

            int countOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfSongs; i++)
            {
                string[] songInfo = Console.ReadLine().Split('_');
                string songTypeList = songInfo[0];
                string songName = songInfo[1];
                string songDuration = songInfo[2];

                Song currentSong = new Song(songTypeList, songName, songDuration);
                songList.Add(currentSong);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songList)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }

    class Song 
    {

        public Song(string typelist, string title, string duration)
        {
            TypeList = typelist;
            Name = title;
            Time = duration;
        }

        public string TypeList { get; set; }
        public string Name { get; set;}
        public string Time {  get; set;}

    }

}


