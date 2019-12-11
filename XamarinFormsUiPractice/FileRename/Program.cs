using System;
using System.IO;

namespace FileRename
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFolderPath = "";
            while(true)
            {
                Console.WriteLine("Input Folder Path: ");
                inputFolderPath = Console.ReadLine();
                
                if(Directory.Exists(inputFolderPath))
                {
                    break;
                }
            }

            //ファイルパス一覧取得
            var files = Directory.GetFiles(inputFolderPath);

            for(int i=0;i<files.Length;i++)
            {
                var file = files[i];
                if(Path.GetExtension(file)!=".jpg")
                {
                    continue;
                }

                var newFilePath = Path.Combine(inputFolderPath,$"photo_{i}.jpg");
                File.Move(file, newFilePath);
            }
        }
    }
}
