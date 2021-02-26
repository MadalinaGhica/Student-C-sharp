using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using Student.Model;
using Student.View;

namespace Student.Main
{
    class Program
    {
        static void Main(string[] args)
        {

            //DisplayStudent d = new DisplayStudent();


            //Student Student1 = new Student(Guid.NewGuid(),"Ovidiu", "Popescu", "A", 3);
            //Student Student2 = new Student(Guid.NewGuid(), "Adrian", "Gavrila", "B", 2);
            //Student Student3 = new Student(Guid.NewGuid(), "Daniel", "Ionescu", "C", 1);
            //Student Student4 = new Student(Guid.NewGuid(),"Anamaria", "Chitu", "D", 3);

            //Dictionary<Guid, Student > Studenti = new Dictionary<Guid, Student >();
            //Studenti.Add(Student1.NrIdentificare, Student1);
            //Studenti.Add(Student2.NrIdentificare, Student2);
            //Studenti.Add(Student3.NrIdentificare, Student3);
            //Studenti.Add(Student4.NrIdentificare, Student4);

            //Console.WriteLine("Studentii sunt: ");
            //foreach (KeyValuePair<Guid, Student> i in Studenti)
            //{
            //    Console.WriteLine(i.Key.ToString() +" "+ i.Value.LastName +"  "+ i.Value.FirstName);
            //}


            //Student1.cursuri.Add("Matematica", 7);
            //Student1.cursuri.Add("Fizica", 10);
            //Student1.cursuri.Add("Engleza", 10);
            //Student1.cursuri.Add("BMSD", 6);
            //Student1.cursuri.Add("Electronica" , 8);
            ////medie Student1 Popescu Ovidiu este 8,2

            //Student2.cursuri.Add("ALGAED", 7);
            //Student2.cursuri.Add("C++", 5);
            //Student2.cursuri.Add("Matematici speciale", 6);
            //Student2.cursuri.Add("Mototare electrice", 7);
            //Student2.cursuri.Add("Electrotehnica", 5);
            ////medie Student1 Gavrila Adrian este 6

            //Student3.cursuri.Add("Sport", 10);
            //Student3.cursuri.Add("Fizica cuantica", 7);
            //Student3.cursuri.Add("Engleza", 5);
            //Student3.cursuri.Add("Automate programabile", 7);
            //Student3.cursuri.Add("Circuite integrate", 6);
            ////medie Student1 Ionescu Daniel este 7

            //Student4.cursuri.Add("Matematica", 10);
            //Student4.cursuri.Add("Fizica", 9);
            //Student4.cursuri.Add("Engleza", 10);
            //Student4.cursuri.Add("BMSD", 9);
            //Student4.cursuri.Add("Electronica", 7);
            ////medie Student1 Chitu Anamaria este 9


            //medieStudent(Studenti);
            //Console.WriteLine();

            //Console.WriteLine($"Studentii care au in numele de familie grupul 'escu' sunt:");
            //sufixEscu(Studenti);
            //Console.WriteLine();
            //cursuriStudiate(Studenti, Student1.NrIdentificare, Student1.YearOfStudy);
            //cursuriStudiate(Studenti, Student2.NrIdentificare, Student2.YearOfStudy);
            //cursuriStudiate(Studenti, Student3.NrIdentificare, Student3.YearOfStudy);
            //cursuriStudiate(Studenti, Student4.NrIdentificare, Student4.YearOfStudy);
            //Console.WriteLine();

            //exportDict("/Users/roghic/Documents/Test1.txt", Studenti);

            ////exportDict("/Users/roghic/Documents/Miele_exercices/JsonFile.txt", Studenti);

            //Console.WriteLine();
            //Dictionary<Guid, Student> import = new Dictionary<Guid, Student>();
            //importDict("/Users/roghic/Documents/Test1.txt", import);

            ////Dictionary<Guid, Student> JsonImport = new Dictionary<Guid, Student>();
            ////importDict("/Users/roghic/Documents/Miele_exercices/JsonFile.txt", JsonImport);
            ///

            //StudentModel Student1 = new StudentModel(Guid.NewGuid(), "Ovidiu", "Popescu", "A", 3);
            //StudentModel Student2 = new StudentModel(Guid.NewGuid(), "Adrian", "Gavrila", "B", 2);
            //StudentModel Student3 = new StudentModel(Guid.NewGuid(), "Daniel", "Ionescu", "C", 1);
            //StudentModel Student4 = new StudentModel(Guid.NewGuid(), "Anamaria", "Chitu", "D", 3);

            //Dictionary<Guid, StudentModel> Studenti = new Dictionary<Guid, StudentModel>();
            //Studenti.Add(Student1.nrIdentificare, Student1);
            //Studenti.Add(Student2.nrIdentificare, Student2);
            //Studenti.Add(Student3.nrIdentificare, Student3);
            //Studenti.Add(Student4.nrIdentificare, Student4);

            //void Export(string numeCaleFisier)
            //{
            //    try
            //    {
            //        string json = JsonConvert.SerializeObject(Studenti.ToArray(),Formatting.Indented);
            //        File.WriteAllText(numeCaleFisier, json);
            //    }

            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Exception: " + e.Message);
            //    }
            //}


                  //try
                  //{
                  //    response = await _currencyLayerApi.GetLiveData(access_key: Access_Key);
                  //    body = await response.Content.ReadAsStringAsync();

                  //    var data = JsonConvert.DeserializeObject<CurrencyLayerDto>(body);
                  //    foreach (var q in data.Quotes)
                  //    {
                  //        allQuotes.Add(new QuotesModel(quoteName: q.Key, quoteValue: q.Value));
                  //    }
                  //}
                  //catch (Exception ex)
                  //{
                  //    throw new Exception(ex.Message, ex);
                  //}


               //Dictionary<Guid, StudentModel> Import(string numeCaleFisier)
               // {
               //   Dictionary<Guid, StudentModel> studentiImportati = new Dictionary<Guid, StudentModel>();
               //   try
               //      {
               //         StreamReader input = new StreamReader(numeCaleFisier);
               //         string jo = input.ReadToEnd();
               //         var data = JsonConvert.DeserializeObject<ImportJsonDto>(jo);
               //         foreach (var d in data.Student)
               //           {

               //              studentiImportati.Add(key: d.Key,value: new StudentModel(NrUnic: d.Key, Prenume: d.Value.FirstName,Nume: d.Value.LastName,adresa: d.Value.Adress,anStudiu: d.Value.YearOfStudy));
                   
               //           }

               //       }
               //    catch (Exception e)
               //      {
               //          Console.WriteLine("Exception: " + e.Message);
               //      }

               //    return studentiImportati;

               //  }

               // // Export("/Users/roghic/Documents/Miele_exercices/Export Json.json");
               //   Import("/Users/roghic/Documents/Miele_exercices/Import Json.json");
          }
    }
}