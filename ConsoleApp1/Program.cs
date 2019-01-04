using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static int FizzBuzz(int i)
        {

            Console.WriteLine("{0}", i % 6 == 0 ? "Fizz Buzz" : (i % 2 == 0 ? "Fizz" : (i % 3 == 0 ? "Buzz" : i.ToString())));

            Console.ReadKey();
            return(0);
        }
        static int DeepDive(int n)
        {

            n = int.Parse(Console.ReadLine()) + 1;

            Guid[] guidArray = new Guid[n];
            string path = @"C:\Users\Marek\Desktop\INTIVE PATRONAGE\net\";
            for (int i = 1; i < n; i++)
            {
                guidArray[i] = Guid.NewGuid();
                //string path = @"C:\Users\Marek\Desktop\INTIVE PATRONAGE\net\"+guidArray[i];

                try
                {
                    path = @path + guidArray[i];
                    // Try to create the directory.
                    // DirectoryInfo di = Directory.CreateDirectory(path);
                    DirectoryInfo di = new DirectoryInfo(path);
                    di.CreateSubdirectory(@guidArray[i].ToString());
                    // DirectoryInfo di = di.CreateSubdirectory;
                    Console.WriteLine("The directory {0} was created successfully at {1}.", guidArray[i], Directory.GetCreationTime(path));

                    // Delete the directory.
                    //  di.Delete();
                    //  Console.WriteLine("The directory was deleted successfully.");

                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());

                    //  Console.ReadKey();
                }
            }
            return (0);
        }

        static void Main(string[] args)
        {
            int x = 0;
            while (x<4) //(x != 4 && x<4)
            {
                Console.WriteLine("Hello! \nWhat would You like to do? \nPress number \n\n" +
                    "1. FizzBuzz\n" +
                    "2. DeepDive\n" +
                    "3. DrownItDown\n" +
                    "4. Exit\n\n");
                try
                {
                    x = int.Parse(Console.ReadLine());
                    
                }
                catch
                {
                    Console.WriteLine("podaj cyfre 1-4");
                    Console.ReadKey();
                }
              
                switch(x)
                {
                    case 1:
                        Console.WriteLine("Podaj liczbe w przedziale 0-1000\n");

                        try
                        {
                            Console.WriteLine(FizzBuzz(int.Parse(Console.ReadLine())));
                        }
                        catch
                        {
                            Console.WriteLine("podaj liczbe!");
                           // return;
                          //  Console.ReadKey();
                        }
                        break;

                    case 2:
                        Console.WriteLine("Podaj ilosc folderow zagniezdzonych\n");
                        try
                        {
                            Console.WriteLine(DeepDive(int.Parse(Console.ReadLine())));
                        }
                        catch
                        {
                            Console.WriteLine("podaj liczbe!");
                            // return;
                            //  Console.ReadKey();
                        }
                        break;
                        
                }


            }


           // Console.ReadKey();
        }
        
    }
}
