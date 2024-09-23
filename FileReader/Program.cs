using System;
using System.IO;
using System.Text.Json;
namespace FileReader
{
    // Описываем наш класс и помечаем его атрибутом для последующей сериализации
    [Serializable]
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Pet(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    
    internal class Program
    {
        static void WriteValues()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(@"C:\Users\ivan.bannikov\source\repos\FileReader\BinaryFile.bin", FileMode.Open)))
                writer.Write($"Файл изменен {DateTime.Now} на компьютере c ОС {Environment.OSVersion}");
        }

        static void ReadValues()
        {
            string StringValue;
            if (File.Exists(@"C:\Users\ivan.bannikov\source\repos\FileReader\BinaryFile.bin"))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(@"C:\Users\ivan.bannikov\source\repos\FileReader\BinaryFile.bin", FileMode.Open)))
                {
                    StringValue = reader.ReadString();
                }

                Console.WriteLine(StringValue);
            }
        }

        static void Main()
        {           
            string AnotherFilePath = @"C:\Users\ivan.bannikov\source\repos\FileReader\BinaryFile.bin";
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

            // Объект для сериализации
            var pet = new Pet("Rex", 2);
            Console.WriteLine("Объект создан");
            // Сериализация
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(pet, options);
            File.WriteAllText("myPets.json", jsonString);
            Console.WriteLine("Объект сериализован");
            // Десериализация
            jsonString = File.ReadAllText("myPets.json");
            var newPet = JsonSerializer.Deserialize<Pet>(jsonString);
            Console.WriteLine("Объект десериализован");
            Console.WriteLine($"Имя: {newPet.Name} --- Возраст: {newPet.Age}");
            Console.ReadLine();                       
        }
    }
}
