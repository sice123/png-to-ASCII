using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Media;
using Colorful;
using Console = System.Console;


namespace Artest
{
    #region form
   
    


    #endregion
    class Program
    {
        public static int counting = 0;
        public static string path = @"sd.png";
        public static int PixelI = 40;
        public static int BrightnessMult = 10;
        [STAThread]
        static void Main()
        {
            
            Downloads();
            Console.Title = "Sice2k";
            #region Fullscreen
            IntPtr hConsole = DllImports.GetStdHandle(-11);   // get console handle
            DllImports.COORD xy = new DllImports.COORD(100, 100);
            DllImports.SetConsoleDisplayMode(hConsole, 1, out xy); // set the console to fullscreen
                                                                   
            

            #endregion

            #region Intro
            FigletFont font = FigletFont.Load("chunky.txt");
            Figlet figlet = new Figlet(font);
            Thread.Sleep(1000);
            Colorful.Console.Write(figlet.ToAscii("By"), ColorTranslator.FromHtml("#8AFFEF"));
            Thread.Sleep(1000);
            Colorful.Console.Write(figlet.ToAscii("Sice"), ColorTranslator.FromHtml("#FAD6FF"));
            Thread.Sleep(1000);
            Colorful.Console.Write(figlet.ToAscii("2k"), ColorTranslator.FromHtml("#B8DBFF"));
            Thread.Sleep(2000);
            Console.Clear();
            #endregion

            #region form

            /*Application.EnableVisualStyles();
            Application.Run(new Form());
            Application.Exit();*/

            #endregion

            #region Introduction
            Console.Clear();


            //Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "text" ));
            /*Console.WriteLine("{{Press F11 To Exit Full Screen}}\nHello sir , please enter your path , pixel interval and brihtness multiplier; \nDefult values : pixel interval : 40 , brightness multiplier : 1");
            Console.WriteLine("Example : " + path + "\nEnter your path : ");
            path = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hello sir , please enter your path , pixel interval and brihtness multiplier; \nDefult values : pixel interval : 40 , brightness multiplier : 1");
            Console.WriteLine("Enter your pixel interval : \nExample : 40");
            PixelI = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Hello sir , please enter your path , pixel interval and brihtness multiplier; \nDefult values : pixel interval : 40 , brightness multiplier : 1");
            Console.WriteLine("Enter your brightness multiplier : \nExample : 1");
            BrightnessMult = int.Parse(Console.ReadLine());*/

            ConvertToTextSecond();

            #endregion

            

        }
        static void ConvertToText()
        {
            
            Bitmap bmp = (Bitmap)Image.FromFile(path);
            string WrittenLine = "";
            
            for (int y = 0; y < bmp.Size.Height - (bmp.Size.Height % PixelI); y += PixelI)
            {
                for (int x = 0; x < bmp.Size.Width; x++)
                {
                    if (x % PixelI == 0 || x % PixelI == 1)
                    {
                        //Color pixelColor = bmp.GetPixel(x,y);
                        //Console.ForegroundColor = GetPixelColor(pixelColor.Name);
                        WrittenLine += /*pixelColor.Name +" " ;*/GetSymbol(bmp.GetPixel(x, y).GetBrightness() * BrightnessMult );
                        

                    }

                }
                /*foreach (char c in WrittenLine)
                {
                    Thread.Sleep(10);
                    Console.Write(c);
                }*/
                Console.WriteLine(WrittenLine);
                WrittenLine = "";
                Thread.Sleep(1);
                
                
            }
            
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                SoundPlayer player = new SoundPlayer(@"eSong.wav");
                player.Play();
                Console.ReadKey();

            }
        }
        static void ConvertToTextSecond()
        {
            Thread.Sleep(1000);
            Console.Clear();
            counting++;
            Bitmap bmp = (Bitmap)Image.FromFile(path);
            string WrittenLine = "";
            for (int y = 0; y < bmp.Size.Height - (bmp.Size.Height % PixelI); y += PixelI)
            {
                for (int x = 0; x < bmp.Size.Width; x++)
                {
                    if (x % PixelI == 0 || x % PixelI == 1)
                    {
                        //Color pixelColor = bmp.GetPixel(x,y);
                        //Console.ForegroundColor = GetPixelColor(pixelColor.Name);
                        WrittenLine += /*pixelColor.Name +" " ;*/GetSymbolSecond(bmp.GetPixel(x, y).GetBrightness() * BrightnessMult);


                    }

                }
                /*foreach (char c in WrittenLine)
                {
                    Thread.Sleep(10);
                    Console.Write(c);
                }*/
                Console.Write(WrittenLine);
                WrittenLine = "";
                Thread.Sleep(1);


            }
            Thread.Sleep(1000);
            string xs = " ";
            for (int i = 0; i < 10; i++)
            {
                
                Thread.Sleep(150);
                Console.WriteLine(xs+"xd");
                xs += "  ";
                Console.Clear();
            }
            Console.Clear();
            ConvertToText();
        }      
        static string GetSymbol(double Brightness)
        {
            
            switch (Brightness *1)
            {
                case double n when (n >= 0.9):// 
                    return " ";
                case double n when (n >= 0.7)://.
                    return ".";
                case double n when (n >= 0.5)://'
                    return "'";
                case double n when (n >= 0.4): //-
                    return "-";
                case double n when (n >= 0.3)://+
                    return "+";
                case double n when (n >= 0.2)://d
                    return "d";
                case double n when (n >= 0.1)://N
                    return "N";
                case double n when (n >= 0.05)://$
                    return "$";
                case double n when (n >= 0.05)://#
                    return "#";

                default:
                    return "N";// N
            }
        }
        static string GetSymbolSecond(double Brightness)
        {

            switch (Brightness * 1)
            {
                case double n when (n >= 0.9):// 
                    return "Error";
                case double n when (n >= 0.7)://.
                    return "Error";
                case double n when (n >= 0.5)://'
                    return "Error";
                case double n when (n >= 0.4): //-
                    return "Error";
                case double n when (n >= 0.3)://+
                    return "Error";
                case double n when (n >= 0.2)://d
                    return "Error";
                case double n when (n >= 0.1)://N
                    return "Error";
                case double n when (n >= 0.05)://$
                    return "Error";
                case double n when (n >= 0.05)://#
                    return "Error";

                default:
                    return "Error";// N
            }
        }
        static ConsoleColor GetPixelColor(string color)
        {
            switch (color)
            {
                case string c when (c == "ff0000" || c == "ff0e0407"):
                    return ConsoleColor.Red;
                case string c when (c == "Blue"):
                    return ConsoleColor.Blue;
                case string c when (c == "47704c"):
                    return ConsoleColor.Green;
                case string c when (c == "ffc61212"):
                    return ConsoleColor.Yellow;
                case string c when (c == "ff95c9d9"):  
                    return ConsoleColor.Magenta;
                default:
                    return ConsoleColor.White;
            }
        }

        static void Downloads(int example =0)// example = 0 , picasso = 1 , ;
        {
            /*string folderName = @"C:\Pics\sd.png";
            DirectoryInfo di = Directory.CreateDirectory(folderName);
            DirectoryInfo dInfo = new DirectoryInfo(folderName);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);*/
            using (WebClient b = new WebClient())
            {

                string path;
                path = "https://ucarecdn.com/9c000460-d2ec-49b3-b538-7f6d4c1bc3fa/";
                b.DownloadFile(path, "eSong.wav");
                path = "http://www.figlet.org/fonts/chunky.flf";
                b.DownloadFile(path, "chunky.txt");
                if (example == 0)
                {
                    path = "https://cdn.discordapp.com/attachments/755696101906186300/923625704548102264/sd.png";
                    b.DownloadFile(path , "sd.png");
                }
                else if (example == 1)
                {
                    path = "https://cdn.discordapp.com/attachments/755696101906186300/925643110044811314/pic.png";
                    b.DownloadFile(path, "pic.png");
                }
                else if (example == 3)
                {
                    path = "https://cdn.discordapp.com/attachments/755696101906186300/925643110044811314/pic.png";
                    b.DownloadFile(path, "pic.png");
                }
                
               
            }
            

        }
    }
}
