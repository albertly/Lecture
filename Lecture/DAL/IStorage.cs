using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lecture.Models;

namespace Lecture.DAL
{
    public interface IStorage
    {
        List<Person> Persons { get; set; }

        void Add(Person p);
        void Edit(int ID, Person p);
        Person Get(int ID);
    }
}