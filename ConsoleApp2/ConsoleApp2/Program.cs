using System;
using System.IO;


namespace ZadanieNET

{
    /// <summary>
    /// This program can:
    /// 1. Print message if input integer is divideable by 2 (Fizz) or 3 (Buzz) or both (FizzBuzz)
    /// 2. Create nests subdirectories on PC
    /// 3. Create files on any nest level in subdirectories 
    /// </summary>
    class Program
    {
        /// <summary>
        /// This method returns message if input number can be divided by 2 (Fizz) or 3 (Buzz) or both (FizzBuzz)
        /// </summary>
        /// <param name="i">This is input integer</param>
        /// <returns>Answer</returns>
        //This method returns message if input number can be divided by 2 (Fizz) or 3 (Buzz) or both (FizzBuzz)
        static string FizzBuzz(int i)
        {
            //string g;
            if (i >= 0 & i < 1001) //Checking range 
            {
                string g = i % 6 == 0 ? "Fizz Buzz" : (i % 2 == 0 ? "Fizz" : (i % 3 == 0 ? "Buzz" : i.ToString())); //logic
                return (g);  //return result
            }
            else
                return ("Numbers out of range. Please input number in range 0-1000\n");
        }

        /// <summary>
        /// This method is used to creating nest subdirectories
        /// </summary>
        /// <param name="n">
        /// Integer number
        /// </param>
        /// <returns></returns>
        //This method is used to creating nest subdirectories
        static string DeepDive(int n)
        {
            Guid[] guidArray = new Guid[n];
            string path = "C" + Path.VolumeSeparatorChar + Path.DirectorySeparatorChar + "net"; //Multiplatform notation of localization C:\net
            for (int i = 0; i < n; i++)
            {
                try
                {
                    guidArray[i] = Guid.NewGuid(); //creating unique element (GUID) in array

                    DirectoryInfo di = new DirectoryInfo(path);
                    di.CreateSubdirectory(guidArray[i].ToString()); // Try to create the directory.
                    Console.WriteLine("The directory {0} \nwas created successfully at {1}.\n", guidArray[i], Directory.GetCreationTime(path));
                    path = Path.Combine(path, guidArray[i].ToString()); //combine path and subdir to one path for new iteration
                }

                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());

                }
            }
            return null;
        }
        /// <summary>
        /// This method can create files on any nest level in subdirectories
        /// </summary>
        /// <param name="n">integer</param>
        /// <returns></returns>
        // This method can create files on any nest level in subdirectories 
        // Accept only integer number as input 
        static string DrownItDown(int n)
        {
            string path = "C" + Path.VolumeSeparatorChar + Path.DirectorySeparatorChar + "net";// Multiplatform notation of localization C:\net
            string pathStat = path;
            string fullpath = path;


            {
                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        pathStat = fullpath;
                     
                        DirectoryInfo di = new DirectoryInfo(fullpath);  // checking active dir
                        DirectoryInfo[] diArr = di.GetDirectories();     // getting list of subdirs
                        foreach (DirectoryInfo dri in diArr)             
                                                          
                       fullpath = Path.Combine(fullpath, dri.Name.Substring(0));// creating path to subdir 
                     
                        if (fullpath == pathStat)                        // checking it is possible to get to declared level
                        {
                            Console.WriteLine("Directories structure tree is to small for that nesting level.\n" +
                                "You can use application DeepDive for create structures\n\n");
                            return null;                                 // if not then exit and return to Main 
                        }

                    }
 
                    //
                    // Creating file
                    //

                    string filename = "plik";                             // set file name
                    string filepath = Path.Combine(fullpath, filename);   // set file full path

                    // If file exsist already, you can choose to overwrite them or not
                    if (File.Exists(filepath))
                    {
                        Console.WriteLine("File already exists! Press y to overwrite or anything else to quit to menu");
                        string check = Console.ReadLine();
                        if (check == "y")                                   //checking user choise
                        {
                            using (FileStream fs = File.Create(filepath)) ;  // overwriting
                            Console.WriteLine("File overwrited");
                            return null;
                        }
                        else
                            return null;
                    }
                    //creating new file if the file not exist
                    else if (!File.Exists(filepath))
                    {
                        using (FileStream fs = File.Create(filepath)) ;      // filestream provides access to write/read in destiny location
                        Console.WriteLine("File created at: {0}", filepath);
                    }
                }

                //if some error - print that exception
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
            }
            return null;
        }

        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"></param>

        // Main function //
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! \nWhat would You like to do? \n");
            int x = 0;

            /* This is main loop.
             * User can choose subprogram here.
             * Until user dont press 4 or >4 this will be work forever */
            while (x < 4)
            {
                Console.WriteLine("\nPress number and confirm enter\n" +
                    "1. FizzBuzz\n" +
                    "2. DeepDive\n" +
                    "3. DrownItDown\n" +
                    "4. Exit\n\n");
                try     //exception handling, checking integer input
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch   //print error info if user pressed not a number
                {
                    Console.WriteLine("Type number 1-4");
                    Console.ReadKey();
                }


                // selection from 1-4 with error handling if input is incorrect
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Type number 0-1000\n");

                        try
                        {
                            Console.WriteLine(FizzBuzz(int.Parse(Console.ReadLine())));
                        }
                        catch
                        {
                            Console.WriteLine("Must be a number. Back to menu\n\n");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Type a number of directories \n");

                        try
                        {
                            Console.WriteLine(DeepDive(int.Parse(Console.ReadLine())));
                        }
                        catch
                        {
                            Console.WriteLine("Must be a number. Back to menu\n\n");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Type a subdirectory level to create a file\n");

                        try
                        {
                            Console.WriteLine(DrownItDown(int.Parse(Console.ReadLine())));
                        }

                        catch
                        {
                            Console.WriteLine("Must be a number. Back to menu\n\n");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exit\n");

                        break;
                }
            }
        }
    }
}
