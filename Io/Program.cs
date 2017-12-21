using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Io
{
    class Program
    {
        static void Main(string[] args)
        {
            /*FileStream-работа с байтами
             * Stream Reader/StreamWriter-работают с текстом
             * BinaryReader/Writer - работают с файлами .bin
             *
             * */

            string text = "jeka lox";
            byte[] source =Encoding.UTF8.GetBytes(text);

            using (FileStream stream = new FileStream(@"C:\directory\data.txt", FileMode.OpenOrCreate))
            {
                stream.Write(source, 0, source.Length);
            }
            // byte[] receiver = File.ReadAllBytes(@"C:\directory\data.txt");
            using (FileStream stream = File.OpenRead(@"C:\directory\data.txt"))
            {
                byte[] receivedData = new byte[stream.Length];
                stream.Read(receivedData, 0, receivedData.Length);
                string recieveText = Encoding.UTF8.GetString(receivedData);
               

            }

            using (StreamWriter writer = new StreamWriter(File.Open(@"C:\directory\data.txt",FileMode.Append)))
            {
                string sendText = "LEEEEEXA";
                writer.WriteLine(sendText);
            }


            using (StreamReader reader = new StreamReader(File.Open(@"C:\directory\data.txt", FileMode.OpenOrCreate)))
            {
                string sendText;
               sendText =reader.ReadToEnd();
                Console.WriteLine(sendText);
            }

            using(BinaryWriter writer=new BinaryWriter(new FileStream(@"C:\directory\data1.bin", FileMode.OpenOrCreate)))
            {
                var person = new { Name = "Вася", Age = 27, Sex = true };
                writer.Write(person.Name);
                writer.Write(person.Age);
                writer.Write(person.Sex);
            }

            using (BinaryReader reader = new BinaryReader(new FileStream(@"C:\directory\data1.bin", FileMode.OpenOrCreate)))
            {
                string name;
                name = reader.ReadString();
                int age = reader.ReadInt32();
                bool sex = reader.ReadBoolean();


                var person = new { Name = name, Age = age, Sex = sex };
                Console.WriteLine(person.Name + "  " + person.Age);
            }

                Console.ReadLine();
            
        //   var drives= DriveInfo.GetDrives();
        //   for(int i = 0; i < drives.Length; i++)
        //    {
        //        Console.WriteLine(drives[i].Name);

        //    }
        //    Console.ReadLine();

        //    Directory.CreateDirectory(@"C:\directory");
        //    //DirectoryInfo info = new DirectoryInfo(@"C:\directory");
        //    if (Directory.Exists(@"C:\directory"))
        //    {
        //        File.Create(@"C:\directory\File_Name.jekalox");

        //        FileInfo fileInfo = new FileInfo(@"C:\directory\File_Name.jekalox");
                
        //    }

        }
    }
}
