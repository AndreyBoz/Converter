using System;
using System.IO;
using ImageMagick;
internal class Program
{
    private static void Main(string[] args)
    {
        try {
            Console.Write("Enter your directory:(like C:\\Users\\) ");
            string source = Console.ReadLine();
            source = source.Replace("/","//");
            DirectoryInfo directory = new DirectoryInfo(source); 
            foreach(var photo in directory.GetFiles("*.heic")){ 
                directory.CreateSubdirectory(@"jpg");
                using (MagickImage image = new MagickImage(photo.FullName))
                {
                    string ImageFile = photo.Name.Replace(".heic",string.Empty);
                    image.Write(@$"{source}\jpg\{ImageFile}.jpg");
                }
            }
        }catch(Exception ex){
            Console.WriteLine(ex);
            Console.ReadKey();
        }
        

    }
}