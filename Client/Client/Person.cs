using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Person
    {
        public string Name { get; }
        public Person(string name1)
        {
            Name = name1;
        }
    }
}
