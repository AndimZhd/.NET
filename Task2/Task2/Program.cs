using System;
using System.IO;
using System.Security.Cryptography;


namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            string directory = "C:/2courseProgramming/Itra/.NET/Task2/Files";
            if (Directory.Exists(directory))
            {

                var dir = new DirectoryInfo(directory);
                FileInfo[] files = dir.GetFiles();
                using ( SHA256 mySHA256 = SHA256.Create())
                {
                    foreach (FileInfo fInfo in files)
                    {
                        using (FileStream fileStream = fInfo.Open(FileMode.Open))
                        {
                            try
                            {
                                // Create a fileStream for the file.
                                // Be sure it's positioned to the beginning of the stream.
                                fileStream.Position = 0;
                                // Compute the hash of the fileStream.
                                byte[] hashValue = mySHA256.ComputeHash(fileStream);
                                // Write the name and hash value of the file to the console.
                                //Console.Write($"{fInfo.Name}: ");
                                PrintByteArray(hashValue);
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine($"I/O Exception: {e.Message}");
                            }
                            catch (UnauthorizedAccessException e)
                            {
                                Console.WriteLine($"Access Exception: {e.Message}");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The directory specified could not be found.");
            }
        }

        // Display the byte array in a readable format.
        public static void PrintByteArray(byte[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]:X2}");
                if ((i % 4) == 3) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }  
}