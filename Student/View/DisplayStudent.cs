using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Student.Model;
using Student.Controller;
using Student.Repository;

namespace Student.View
{
    
    //view
    public class DisplayStudent
    {
        public StudentController Controller{get; set;} = new StudentController(new StudentRepository());

        public DisplayStudent()
        {

             Console.WriteLine("Available commands: \n f1 (Add student and gardes) \n f2 (Display best student)" +
                  "\n f3 (Display students with name containing escu) \n f4 (Display students) \n f5 (Display courses for a specific year of study)"+
                  "\n f6 (Export students) \n f7 (Import students) \n f8 Display student's grades ");

              while (true)
              {
                  Console.WriteLine("Insert command:");
                  ParseCommand(Console.ReadLine());
                  Console.ReadLine();
              }

        }

        public Task ParseCommand(string command)
         {

            switch (command)
            {
                case ("f1"): //Add student
                    Console.WriteLine("Introduceti prenumele studentului:");
                    string prenume = Console.ReadLine().ToString();
                    Console.WriteLine("Introduceti numele studentului:");
                    string nume = Console.ReadLine().ToString();
                    Console.WriteLine("Introduceti adresa studentului:");
                    string adresa = Console.ReadLine().ToString();
                    Console.WriteLine("Introduceti anul de studiu al studentului:");
                    int anStudiu = Convert.ToInt32(Console.ReadLine());
                    Controller.AddStudent(new StudentModel(Guid.NewGuid(), prenume, nume, adresa, anStudiu));
                    
                    Console.WriteLine("Introduceti notele studentului? (Da/ Nu)");
                    string adNota = Console.ReadLine().ToString();
                    while (adNota == ("Da") || adNota == ("da"))
                     {
                         Console.WriteLine($"Introduceti cursul studentului:");
                         string curs = Console.ReadLine().ToString();
                         Console.WriteLine("Introduceti nota studentului:");
                         int nota = Convert.ToInt32(Console.ReadLine());
                         Controller.AddGrades(curs, nota);
                         Console.WriteLine("Introduceti notele studentului? (Da/ Nu)");
                         adNota = Console.ReadLine().ToString();

                     }

                    break;

                 case ("f2"): //Display best student
                    StudentModel bestStudent = Controller.BestStudent();
                     Console.WriteLine($"Studentul cu cea mai buna medie este {bestStudent.FirstName} {bestStudent.LastName}");
                     break;
                 case ("f3"): //Display students with name containing escu
                     HashSet<StudentModel> escu = Controller.SufixEscu();
                     Console.WriteLine($"Studentii care contin 'escu' in numele lor sunt:");
                     foreach (var item in escu)
                     {
                         Console.WriteLine(item.LastName + " " + item.FirstName);
                     }
                     break;
                 case ("f4"): //Display students
                     Console.WriteLine("Studentii sunt:");
                    List<StudentModel> stud = Controller.DisplayStudents();
                    foreach (var item in stud)
                    {
                        Console.WriteLine(item.LastName);
                    }
  
                    break;
                 case ("f5"): //Display courses for a specific year of study
                     Console.WriteLine("Introduceti anul de studiu pentru care vreti sa vedeti cursurile:");
                     int an = Convert.ToInt32(Console.ReadLine());
                     var materii = Controller.CursuriStudiateAn(an);
                     Console.WriteLine($"Cursurile pentru anul {an} sunt:");
                     foreach(var item in materii)
                     {
                         Console.WriteLine(item);
                     }
                     break;
                 case ("f6"): //Export students
                     //Controller.ExportDict("/Users/roghic/Documents/Miele_exercices/Export.txt");
                     Controller.ExportDict("/Users/roghic/Documents/Miele_exercices/Export Json.json");
                    
                     Console.WriteLine("Dictionarul de studenti a fost exportat in fisierul indicat");
                     break;
                 case ("f7"): //Import students
                     //Dictionary<Guid, Student> studentImport = Controller.ImportDict("/Users/roghic/Documents/Miele_exercices/Import.txt");
                     Dictionary<Guid, StudentModel> studentImport = Controller.ImportDict("/Users/roghic/Documents/Miele_exercices/Import Json.json");
                    
                     Console.WriteLine("Dictionarul de studenti a fost importat din fisierul indicat");
                     foreach (KeyValuePair<Guid, StudentModel> z in studentImport)
                     {
                         Console.WriteLine($"{z.Key}, {z.Value.LastName}, {z.Value.FirstName}");
                     }
                     break;
                //case ("f8"): //Display student's grades
                //    foreach (Student item in Controller.DisplayStudents().)
                //    {
                //        Console.WriteLine($"Notele studentului {z.Value.lastName}, {z.Value.firstName} sunt:");

                //        foreach (KeyValuePair<Guid, Student> z in controller.GetHashCode())
                //        {
                //            Console.WriteLine($"{z.Value.cursuri}");
                //        }
                //    }
                //    break;

                default:
                     break;
             }
             return Task.CompletedTask;
         } 

    }
}
