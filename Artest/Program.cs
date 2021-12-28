using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Artest
{
    class Program
    {
        public static int counting = 0;
        public static string path = @"C:\Users\user\Downloads\photos\Name.png";
        public static int PixelI = 40;
        public static int BrightnessMult = 1;
        static void Main()
        {
            Console.WriteLine("Hello sir , please enter your path , pixel interval and brihtness multiplier; \nDefult values : pixel interval : 40 , brightness multiplier : 1");
            Console.WriteLine("Enter your path : \nExample : " + path);
            path = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hello sir , please enter your path , pixel interval and brihtness multiplier; \nDefult values : pixel interval : 40 , brightness multiplier : 1");
            Console.WriteLine("Enter your pixel interval : \nExample : 40" );
            PixelI = int.Parse( Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Hello sir , please enter your path , pixel interval and brihtness multiplier; \nDefult values : pixel interval : 40 , brightness multiplier : 1");
            Console.WriteLine("Enter your brightness multiplier : \nExample : 1");
            BrightnessMult = int.Parse(Console.ReadLine());

            ConvertToTextSecond();
            //Example();
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
                        Color pixelColor = bmp.GetPixel(x,y);
                        Console.ForegroundColor = GetPixelColor(pixelColor.Name);
                        WrittenLine += GetSymbol(bmp.GetPixel(x, y).GetBrightness() * BrightnessMult );

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
            Console.ReadLine();
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
                for (int x = 0; x < bmp.Size.Width +10; x++)
                {
                    if (x % PixelI == 0 || x % PixelI == 1)
                    {
                        if (counting == 3)
                        {
                            WrittenLine += "JUST KIDDING ";
                            Console.WriteLine(WrittenLine);
                            Thread.Sleep(1000);
                            Console.Clear();
                            ConvertToText();
                        }
                        WrittenLine += "ERROR ";

                    }

                }
                /*foreach (char c in WrittenLine)
                {
                    Thread.Sleep(10);
                    Console.Write(c);
                }*/
                Console.WriteLine(WrittenLine);
                WrittenLine = " ";
                ConvertToTextSecond();

            }
        }
        

        static string GetSymbol(double Brightness)
        {
            
            switch (Brightness)
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
                    return " ";
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
        static ConsoleColor GetPixelColor(string color)
        {
            switch (color)
            {
                case string c when (c == "Red"):
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.White;
                    break;
            }
        }
        
        static void Example()
        {
            string folderName = @"Downloads\Pictures";
            DirectoryInfo di = Directory.CreateDirectory(folderName);
            DirectoryInfo dInfo = new DirectoryInfo(folderName);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            string dPath = "https://cdn.discordapp.com/attachments/755696101906186300/923625704548102264/sd.png";
            WebClient webClient = new WebClient();
            webClient.DownloadFile(dPath, folderName);

        }
    }
}
