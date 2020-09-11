using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_7___CRUD__AsyncDelegates_
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? GroupId { get; set; }

        public override string ToString()
        {
            return $"{Id}\t\t{Name}\t\t{Surname}\t\t{GroupId}";
        }
    }
}
