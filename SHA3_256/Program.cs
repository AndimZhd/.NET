using System;
using System.IO;
using System.Security.Cryptography;


namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> hashCodes = new List<string>();
            string directory = "C:/2courseProgramming/Itra/.NET/Task2/Files";
            if (Directory.Exists(directory))
            {
                var dir = new DirectoryInfo(directory);
                FileInfo[] files = dir.GetFiles();

                using (var sha = SHA3.Net.Sha3.Sha3256())
                {
                    List<byte> connectedHash = new List<byte>();
                    String result = "";
                    String bigHashCode = "";
                    // Compute and print the hash values for each file in directory.
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
                                byte[] hashValue = sha.ComputeHash(fileStream);
                                result += ToString(hashValue);
                                hashCodes.Add(ToString(hashValue));
                                connectedHash = connectedHash.Concat(new List<byte>(hashValue)).ToList();
                                //byte[] hashValue = mySHA256.ComputeHash(fileStream);
                                //PrintByteArray(hashValue);
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
                    hashCodes.Sort();
                    foreach(var hsh in hashCodes) {
                        bigHashCode += hsh;
                    }
                    String str = new String("a3057041@gmail.com");
                    bigHashCode += str;
                    result += str;
                    //System.Console.WriteLine(str);
                    List<byte> bebra = new List<byte>();
                    for(int i = 0; i<str.Length; i++) {
                        bebra.Add((byte)str[i]);
                        //System.Console.WriteLine(bebra[i]);
                    }
                    //PrintByteArray(bebra.ToArray());
                    byte[] res = connectedHash.Concat(bebra).ToArray();
                    byte[] hash = sha.ComputeHash(res);
                    //System.Console.WriteLine(connectedHash);
                    //System.Console.WriteLine(res);
                    bebra.Clear();
                    for(int i = 0; i<result.Length; i++) {
                        bebra.Add((byte)result[i]);
                        //System.Console.WriteLine(bebra[i]);
                    }
                    var x = (byte)'a';

                    //System.Console.WriteLine(x);
                    //System.Console.WriteLine($"{x:X2}");
                    //PrintByteArray(res);
                    //System.Console.WriteLine(bigHashCode);
                    //PrintByteArray(System.Text.Encoding.Default.GetBytes(bigHashCode));
                    //System.Console.WriteLine(result);
                    //PrintByteArray(bebra.ToArray());
                    //System.Console.WriteLine();
                    var hash2 = sha.ComputeHash(bebra.ToArray());

                    PrintByteArray(sha.ComputeHash(System.Text.Encoding.Default.GetBytes(bigHashCode)));
                    //PrintByteArray(hash);
                    //PrintByteArray(hash2);
                }
            }
            else
            {
                Console.WriteLine("The directory specified could not be found.");
            }
        }
        public static void PrintByteArray(byte[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]:X2}".ToLower());
            }
            Console.WriteLine();
        }

        public static String ToString(byte[] array)
        {
            String result = new String("");
            for (int i = 0; i < array.Length; i++)
            {
                result += $"{array[i]:X2}".ToLower();
            }
            return result;
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

    }  
}