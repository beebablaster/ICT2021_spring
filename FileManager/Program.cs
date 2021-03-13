using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace FileManager
{
    class Layer
    {
        public FileInfo f
        {
            get;
            set;
        }
        public DirectoryInfo dir
        {
            get;
            set;
        }
        public int pos
        {
            get;
            set;
        }
        public List<FileSystemInfo> content
        {
            get;
            set;
        }

        public Layer(DirectoryInfo dir, int pos)
        {
            this.dir = dir;
            this.pos = pos;
            this.content = new List<FileSystemInfo>();


            content.AddRange(this.dir.GetDirectories());
            content.AddRange(this.dir.GetFiles());
        }

        public Layer(FileInfo f, int pos)
        {
            this.f = f;
            this.pos = pos;
        }

        public void PrintInfo()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            int cnt = 0;
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (cnt == pos)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine(d.Name);
                cnt++;
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            foreach (FileInfo f in dir.GetFiles())
            {
                if (cnt == pos)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine(f.Name);
                cnt++;
            }
        }

        public FileSystemInfo GetCurrentObject()
        {
            return content[pos];
        }



        public void SetNewPosition(int d)
        {
            if (d > 0)
            {
                pos++;
            }
            else
            {
                pos--;
            }
            if (pos >= content.Count)
            {
                pos = 0;
            }
            else if (pos < 0)
            {
                pos = content.Count - 1;
            }
        }

        public void ReadFileContent(FileInfo fi)
        {

            using (StreamReader sr = fi.OpenText())
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public long GetDirectorySize(DirectoryInfo d)
        {
            FileInfo[] fi = d.GetFiles();

            long size = 0;
            foreach (FileInfo f in fi)
            {
                size += f.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += GetDirectorySize(di);
            }

            return size;
        }

        public long GetFileSize(FileInfo fi)
        {
            return fi.Length;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            FileManager();
        }

        private static void FileManager()
        {

            Stack<Layer> history = new Stack<Layer>();
            history.Push(new Layer(new DirectoryInfo(@"C:\ict"), 0));

            bool escape = false;
            bool fileOpened = false;

            while (!escape)
            {
                Console.Clear();

                if (!(history.Peek().GetCurrentObject().GetType() == typeof(FileInfo)))
                {
             
                        history.Peek().PrintInfo();
                        Console.WriteLine("The size of this directory is " + history.Peek().GetDirectorySize(history.Peek().GetCurrentObject() as DirectoryInfo) + " bytes");
                    
                }
                else 
                {
                    history.Peek().PrintInfo();
                    Console.WriteLine("The size of this file is " + history.Peek().GetFileSize(history.Peek().GetCurrentObject() as FileInfo) + " bytes");
                }

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        if (history.Peek().GetCurrentObject().GetType() == typeof(DirectoryInfo))
                        {
                            history.Push(new Layer(history.Peek().GetCurrentObject() as DirectoryInfo, 0));
                        }
                        else 
                        {
                            FileInfo fi = history.Peek().GetCurrentObject() as FileInfo;
                            using (StreamReader sr = fi.OpenText())
                            {
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        history.Peek().SetNewPosition(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SetNewPosition(1);
                        break;
                    case ConsoleKey.Escape:
                        history.Pop();
                        break;
                }
            }
        }

        
    }
}
