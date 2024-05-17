using System;
using Google.Protobuf;

namespace ProtocolBuffers {
    public class Program
    {
        private static void Main(string[] args)
        {
            //Object to be serialized
            var person = new Person
            {
                Name = "John Doe",
                Id = 1234,
                Email = "JohnDoe@gmail.com"
            };
            //nested object
            person.Phones.Add(new Person.Types.PhoneNumber
            {
                Number = "123-456-7890",
                Type = Person.Types.PhoneType.Home
            });

            //Serialize the object
            byte[] data = person.ToByteArray();

            //Deserialize the object
            Person deserializedPerson = Person.Parser.ParseFrom(data);
            
            Console.WriteLine($"Name: {deserializedPerson.Name}");
            Console.WriteLine($"ID: {deserializedPerson.Id}");
            Console.WriteLine($"Email: {deserializedPerson.Email}");

            for (int i = 0; i < deserializedPerson.Phones.Count; i++)
            {
                Console.WriteLine("Phones:");
                var phone = deserializedPerson.Phones[i];
                Console.WriteLine($"Phone Number {i}: {phone.Number}");
                Console.WriteLine($"Phone Type {i}: {phone.Type}");
            }
        }
    }


}
