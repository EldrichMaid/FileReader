namespace FileReader
{
    internal class Program
    {
        static void WriteValues()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("BinaryFile.bin", FileMode.Open)))
                writer.Write($"Файл изменен {DateTime.Now} на компьютере c ОС {Environment.OSVersion}");
        }

        static void ReadValues()
        {
            string StringValue;
            if (File.Exists("BinaryFile.bin"))
            {
                using (BinaryReader reader = new BinaryReader(File.Open("BinaryFile.bin", FileMode.Open)))
                {
                    StringValue = reader.ReadString();
                }

                Console.WriteLine(StringValue);
            }
        }


        static void Main()
        {           
            string AnotherFilePath = @"C:\Users\ivan.bannikov\Desktop\BinaryFile.bin";
            if (File.Exists(AnotherFilePath))
            {
                string ResultingValue;
                using (BinaryReader reader = new BinaryReader(File.Open(AnotherFilePath, FileMode.Open)))
                {
                    ResultingValue = reader.ReadString();
                }
                Console.WriteLine("Из файла считано:");
                Console.WriteLine(ResultingValue);
            } 
            WriteValues();
            ReadValues();
        }
    }
}
