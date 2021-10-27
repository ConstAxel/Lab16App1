using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace Lab16App2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Необходимо разработать программу для получения информации о товаре из json-файла.
            //Десериализовать файл «Products.json» из задачи 1.Определить название самого дорогого товара.
            double max = 0;
            string Name = "";
            string path = @"D:\Users\ConstAxel\Desktop\ДЛЯ ПРИМЕРОВ\Задание 16. Работа с JSON\Lab16App1\Lab16App1\bin\Debug\Products.json";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            Product[] array = JsonSerializer.Deserialize<Product[]>(File.ReadAllText(path));
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Код: {array[i].CodeProduct}\nНаименование: {array[i].NameProduct}\nЦена: {array[i].PriceProduct}");
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                if (array[i].PriceProduct > max)
                {
                    max = array[i].PriceProduct;
                    Name = array[i].NameProduct;
                }
            }
            Console.WriteLine($"\n");
            Console.WriteLine($"Самый дорогой товар - {Name}, цена которого составляет {max:f2}");
            Console.ReadKey();
        }
    }
    class Product
    {
        [JsonPropertyName("Код")]
        public int CodeProduct { get; set; }
        [JsonPropertyName("Наименование")]
        public string NameProduct { get; set; }
        [JsonPropertyName("Цена")]
        public float PriceProduct { get; set; }
    }
}