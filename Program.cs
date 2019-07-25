using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingelTon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SingleTonClass.Instance.GetHashCode());
            SingleTonClass instance1 = SingleTonClass.Instance;
            Console.WriteLine(instance1.GetHashCode());

            //serialize
            using (Stream stream = File.Open("SerializedFile.txt", FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, instance1);
            }

            using (Stream stream = File.Open("SerializedFile.txt", FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                SingleTonClass instance2 = (SingleTonClass)bformatter.Deserialize(stream);
                Console.WriteLine(instance2.GetHashCode());
            }
                       
            Console.Read();
        }
    }
}
