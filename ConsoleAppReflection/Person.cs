using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppReflection
{
    public class Person
    {
        [RenameAttribute("Code")]
        public int Id { get; set; }
        [RenameAttribute("Name")]
        public string Name { get; set; }
        [RenameAttribute("Surname")]
        public string Surname { get; set; }

        public string Address { get; set; }


    }
}
