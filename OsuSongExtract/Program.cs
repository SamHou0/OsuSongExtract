using System.IO;
namespace OsuSongExtract
{
    internal class Program
    {
        public readonly static string SongsDir =
            Environment.GetFolderPath
            (Environment.SpecialFolder.LocalApplicationData) + "\\osu!\\Songs";
        static void Main(string[] args)
        {
            Console.WriteLine
                ("Please enter the path you want to extract to. If the song exists, they will be replaced.");
            string path = Console.ReadLine();
            string[] directories = Directory.GetDirectories(SongsDir);
            List<string> fileList = new List<string>();
            foreach (string dir in directories)
            {
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".mp3")
                    {
                        string number = Path.GetFileName(dir).Split(" ")[0];
                        string fileName = Path.GetFileName(dir).Remove(0, number.Length + 1);
                        File.Copy(file, path + "\\" + fileName + ".mp3", true);
                        Console.WriteLine(file);
                    }
                }
            }
            Console.WriteLine("Completed! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
