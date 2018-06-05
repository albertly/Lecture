using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lecture;
using Lecture.Controllers;
using Lecture.DAL;
using Lecture.Models;
using System.Diagnostics;
using System.IO;

namespace Lecture.Tests.Controllers
{
    public  delegate int myfunct(int i);
    [TestClass]
    public class PersonControllerTest
    {
        
       

        [TestMethod]
        public void Index()
        {
            byte[] ba = new byte[844877942];


            for (int i=0; i< 844877942;i ++)
            {
                byte b = Convert.ToByte('1');
                ba[1] = b;
            }
            File.WriteAllBytes(@"C:\test\bigfile.mp4", ba);

            Func<int,int> f = x => x * x;
            Debug.WriteLine(f(2));

            Debug.WriteLine(MyFunct(x => x * x, 3));
            StorageXML myData = new StorageXML();
         
            var  persons = myData.Persons;

            myData.Edit(1, new Person() { FirstName = "A1", LastName = "L2" });
            var temp_persons = persons.Where(x => x.FirstName == "Albert");
            foreach (var p in temp_persons)
                Debug.WriteLine(p.ToString());

            Assert.IsTrue(true);
        }

        private int MyFunct(myfunct f, int x)
        {
            return f(x);
        }
    }
}
