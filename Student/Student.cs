using System;
using System.Collections.Generic;

namespace Student
{
    public class Student
    {
        public Guid NrIdentificare;
        public string FirstName;
        public string LastName;
        public string Adress;
        public int YearOfStudy;
        public Dictionary<string, int> cursuri = new Dictionary<string, int>();
       

        public Student(Guid NrUnic,string Prenume, string Nume)
        {
            NrIdentificare = NrUnic;
            FirstName = Prenume;
            LastName = Nume;
        
        }

    }
}
