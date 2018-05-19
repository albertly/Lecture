using Lecture.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Lecture.DAL
{
    public class StorageXML : IStorage
    {
        private const string Path = "c:\\5\\1.xml";
        public List<Person> Persons { get; set; }

        public StorageXML()
        {
            Persons = new List<Person>() {
                new Person() { ID = 1, FirstName = "Albert", LastName = "Lyubarsky", BithDate = new DateTime(1971, 3, 12) },
                new Person() { ID = 2, FirstName = "Rafi", LastName = "Shlizenger", BithDate = new DateTime(1962, 10,10)  }
            };

            Persons = Deserialize();
        }        
       
        public void Add(Person p)
        {
            p.ID = Persons.Max(x => x.ID) + 1;
            Persons.Add(p);
            Serialize();
        }

        public Person Get(int id)
        {
            return Persons[Persons.FindIndex(x => x.ID == id)];
        }

        public void Edit(int id, Person p)
        {
            Persons[Persons.FindIndex(x => x.ID == id)] = p;
            Serialize();
        }

        private List<Person> Deserialize(string a_fileName = Path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Person>));

            TextReader reader = new StreamReader(a_fileName);

            object obj = deserializer.Deserialize(reader);

            reader.Close();

            return (List<Person>)obj;
        }

        private void Serialize(string a_fileName = Path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

            using (var stream = File.OpenWrite(a_fileName))
            {
                serializer.Serialize(stream, Persons);
            }
        }
    }
}