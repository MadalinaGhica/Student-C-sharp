using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Student Student1 = new Student(Guid.NewGuid(),"Ovidiu", "Popescu");
            Student Student2 = new Student(Guid.NewGuid(), "Adrian", "Gavrila");
            Student Student3 = new Student(Guid.NewGuid(), "Daniel", "Ionescu");
            Student Student4 = new Student(Guid.NewGuid(),"Anamaria", "Chitu");

            Dictionary<Guid, Student > Studenti = new Dictionary<Guid, Student >();
            Studenti.Add(Student1.NrIdentificare, Student1);
            Studenti.Add(Student2.NrIdentificare, Student2);
            Studenti.Add(Student3.NrIdentificare, Student3);
            Studenti.Add(Student4.NrIdentificare, Student4);

            Console.WriteLine("Studentii sunt: ");
            foreach (KeyValuePair<Guid, Student> i in Studenti)
            {
                Console.WriteLine(i.Key.ToString() +" "+ i.Value.LastName +"  "+ i.Value.FirstName);
            }

            Student1.YearOfStudy = 3;
            Student1.cursuri.Add("Matematica", 7);
            Student1.cursuri.Add("Fizica", 10);
            Student1.cursuri.Add("Engleza", 10);
            Student1.cursuri.Add("BMSD", 6);
            Student1.cursuri.Add("Electronica" , 8);
            //medie Student1 Popescu Ovidiu este 8,2

            Student2.YearOfStudy = 2;
            Student2.cursuri.Add("ALGAED", 7);
            Student2.cursuri.Add("C++", 5);
            Student2.cursuri.Add("Matematici speciale", 6);
            Student2.cursuri.Add("Mototare electrice", 7);
            Student2.cursuri.Add("Electrotehnica", 5);
            //medie Student1 Gavrila Adrian este 6

            Student3.YearOfStudy = 1;
            Student3.cursuri.Add("Sport", 10);
            Student3.cursuri.Add("Fizica cuantica", 7);
            Student3.cursuri.Add("Engleza", 5);
            Student3.cursuri.Add("Automate programabile", 7);
            Student3.cursuri.Add("Circuite integrate", 6);
            //medie Student1 Ionescu Daniel este 7

            Student4.YearOfStudy = 3;
            Student4.cursuri.Add("Matematica", 10);
            Student4.cursuri.Add("Fizica", 9);
            Student4.cursuri.Add("Engleza", 10);
            Student4.cursuri.Add("BMSD", 9);
            Student4.cursuri.Add("Electronica", 7);
            //medie Student1 Chitu Anamaria este 9

            void medieStudent(Dictionary<Guid, Student> Elevi)
            {
                int max = 0;
                int medie = 0;
                //List<int> medii = new List<int>();
                Dictionary<Student, int> Medii = new Dictionary<Student, int>();
                foreach (KeyValuePair<Guid, Student> copil in Elevi)
                {
                    
                    int sum = 0;
                    foreach (KeyValuePair<string, int> materie in copil.Value.cursuri)
                    {
                        sum = sum + materie.Value;
                        //Console.WriteLine($"Sum este {sum}");
                        
                    }
                    medie = sum / copil.Value.cursuri.Count;
                    Console.WriteLine($"Media lui {copil.Value.FirstName} {copil.Value.LastName} este {medie}");
                    Medii.Add(copil.Value, medie);
                    
                }
         
                max = Medii.Values.Max();
                foreach(KeyValuePair<Student, int> x in Medii)
                {
                    if(x.Value == Medii.Values.Max())
                        Console.WriteLine($"Studentul cu cea mai buna medie este {x.Key.FirstName} {x.Key.LastName} si are media {max}");
                }
                

            }

            void sufixEscu(Dictionary<Guid, Student> tipNume)
            {
                string expr = @".escu";
                foreach(KeyValuePair<Guid, Student> z in tipNume)
                {
                    MatchCollection mc = Regex.Matches(z.Value.LastName, expr);
                    foreach (Match m in mc)
                    {
                        Console.WriteLine($"Studentul {z.Value.LastName} {z.Value.FirstName}");
                    }
                }
                    
            }

            void cursuriStudiate(Dictionary<Guid,Student> cursanti, Guid IDStudent, int anStudiu)
            {
                foreach (KeyValuePair<Guid, Student> x in cursanti)
                {
                    if(x.Key == IDStudent)
                    {
                        Console.WriteLine($"Cursurile pentru anul {anStudiu} sunt:");
                        foreach (KeyValuePair<String, int> r in x.Value.cursuri)
                        {
                            Console.Write($"{r.Key} ");
                        }
                        Console.WriteLine();
                    }
                
                }
            }


            void exportDict(string numeCaleFisier, Dictionary<Guid, Student> dict)
            {
                try
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(numeCaleFisier);
                    //Write a line of text
                    foreach (KeyValuePair<Guid, Student> z in dict)
                    {
                        sw.WriteLine($"{z.Key}, {z.Value.LastName}, {z.Value.FirstName}");
                    }
                    
                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block in writing the text files.");
                }
            }
         

            void importDict(string numeCaleFisier, Dictionary<Guid, Student> dict)
            {
                string line;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(numeCaleFisier);
                    //int contor = 0;
                    //while (sr.ReadLine() != null) { contor++; }

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] inputArray = line.Split(new char[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries);
                        //Console.WriteLine(inputArray[0], inputArray[1], inputArray[2]);
                        dict.Add((new Student(new Guid(inputArray[0]), inputArray[2], inputArray[1])).NrIdentificare, (new Student(new Guid(inputArray[0]), inputArray[2], inputArray[1])));

                    }

                        //close the file
                        sr.Close();
                    //Console.ReadLine();

                    foreach(KeyValuePair < Guid, Student > z in dict)
                    {
                        Console.WriteLine($"{z.Key}, {z.Value.LastName}, {z.Value.FirstName}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block for reading the text file.");
                }

            }


            medieStudent(Studenti);
            Console.WriteLine();

            Console.WriteLine($"Studentii care au in numele de familie grupul 'escu' sunt:");
            sufixEscu(Studenti);
            Console.WriteLine();
            cursuriStudiate(Studenti, Student1.NrIdentificare, Student1.YearOfStudy);
            cursuriStudiate(Studenti, Student2.NrIdentificare, Student2.YearOfStudy);
            cursuriStudiate(Studenti, Student3.NrIdentificare, Student3.YearOfStudy);
            cursuriStudiate(Studenti, Student4.NrIdentificare, Student4.YearOfStudy);
            Console.WriteLine();

            exportDict("/Users/roghic/Documents/Test1.txt", Studenti);

            Console.WriteLine();
            Dictionary<Guid, Student> import = new Dictionary<Guid, Student>();
            importDict("/Users/roghic/Documents/Test1.txt", import);

        }



    }
}