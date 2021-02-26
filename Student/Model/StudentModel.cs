using System;
using System.Collections.Generic;


namespace Student.Model
{
    //Model
    public class StudentModel
    {
        public Guid NrIdentificare { get;}
        public string FirstName { get;}
        public string LastName { get; set; }
        public string Adress { get;}
        public int YearOfStudy { get;}

        public Dictionary<string, int> cursuri = new Dictionary<string, int>();

        public StudentModel(Guid nrUnic, string prenume, string nume, string adresa, int anStudiu)
        {
            NrIdentificare = nrUnic;
            FirstName = prenume;
            LastName = nume;
            Adress = adresa;
            YearOfStudy = anStudiu;

        }


    }

}
