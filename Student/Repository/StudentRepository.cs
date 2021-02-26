using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;
using Student.Model;

namespace Student.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Dictionary<Guid, StudentModel> studenti;

        public StudentRepository()
        {
           studenti = new Dictionary<Guid, StudentModel>();
        }

        public void AddStudent(StudentModel s1)
        {
            if (s1 != null){
                studenti.Add(s1.NrIdentificare, s1);
            }
            else
            {
                throw new Exception("No students to add");
            }
            
        }

        public StudentModel GetBestStudent()
        {
            int max = 0;
            int medie = 0;
            StudentModel s1 = null;
            Dictionary<StudentModel, int> medii = new Dictionary<StudentModel, int>();
            foreach (KeyValuePair<Guid, StudentModel> copil in studenti)
            {
                int sum = 0;
                foreach (KeyValuePair<string, int> materie in copil.Value.cursuri)
                {
                    sum = sum + materie.Value;

                }
                medie = sum / copil.Value.cursuri.Count;

                medii.Add(copil.Value, medie);
            }

            max = medii.Values.Max();
            foreach (KeyValuePair<StudentModel, int> x in medii)
            {
                if (x.Value == medii.Values.Max())
                {
                    s1 = x.Key;
                }
            }
            return s1;
        }

        public HashSet<StudentModel> GetNameSufixEscu()
        {
            HashSet<StudentModel> sirStudent = new HashSet<StudentModel>();

            foreach (KeyValuePair<Guid, StudentModel> z in studenti)
            {

                if (z.Value.LastName.Contains("escu"))
                {
                    sirStudent.Add(z.Value);
                }

            }
            return sirStudent;
        }

        public HashSet<string> GetCursuriStudiateAn(int anStudiu)
        {
            HashSet<string> materii = new HashSet<string>();
            foreach (KeyValuePair<Guid, StudentModel> x in studenti)
            {
                if (x.Value.YearOfStudy == anStudiu)
                {
                    foreach (KeyValuePair<String, int> r in x.Value.cursuri)
                    {
                        materii.Add(r.Key);
                    }
                }

            }
            return materii;
        }

        public void ExportDict(string numeCaleFisier)
        {
            try
            {
                string json = JsonConvert.SerializeObject(studenti.ToArray(), (Newtonsoft.Json.Formatting)Formatting.Indented);
                File.WriteAllText(numeCaleFisier, json);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public Dictionary<Guid, StudentModel> ImportDict(string numeCaleFisier)
        {
            //string line;
            Dictionary<Guid, StudentModel> studentiImportati= new Dictionary<Guid, StudentModel>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                //StreamReader sr = new StreamReader(numeCaleFisier);
                //string jsonString = sr.ReadToEnd();
                //string Json = System.IO.File.ReadAllText(file);
                //JavaScriptSerializer ser = new JavaScriptSerializer();
                //var personlist = ser.Deserialize<List<Person>>(Json);

                //string jsonString = File.ReadAllText(numeCaleFisier);
                //var obj = JsonSerializer.Deserialize<string>(jsonString);
                //while (jsonString != null)
                //{
                //    string[] inputArray = jsonString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //    //Console.WriteLine(inputArray[0], inputArray[1], inputArray[2]);
                //    studentiImportati.Add(Guid.Parse(inputArray[0]), new Student(Guid.Parse(inputArray[0]), inputArray[2], inputArray[1], inputArray[3], Int32.Parse(inputArray[4])));

                //}


                //while ((line = sr.ReadLine()) != null)
                //{
                //    string[] inputArray = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //    studentiImportati.Add(Guid.Parse(inputArray[0]), new Student(Guid.Parse(inputArray[0]), inputArray[2], inputArray[1], inputArray[3], Int32.Parse(inputArray[4])));

                //}

                ////close the file
                //sr.Close();
                //Console.ReadLine();

                //string readResult = string.Empty;
                //StreamReader sr = new StreamReader(numeCaleFisier);

                //using (sr)
                //{
                //    var json = r.ReadToEnd();
                //    var jobj = JsonConverter.
                //    readResult = jobj.ToString();
                //    foreach (var item in studenti)
                //    {
                //        string[] inputArray = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //        studentiImportati.Add(Guid.Parse(inputArray[0]), new Student(Guid.Parse(inputArray[0]), inputArray[2], inputArray[1], inputArray[3], Int32.Parse(inputArray[4])));
                //    }

                //}


                

                //using (StreamReader file = File.OpenText(numeCaleFisier))
                //{
                //    using (JsonReaderOptions rd = new JsonReaderOptions(numeCaleFisier))
                //    {
                //        JsonSerializer.Deserialize(rd);
                //        FileValue dict = JsonConvert.DeserializeObject<FileValue>(jsonObj.ToString());
                //        //xreturn dict;
                //    }
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return studentiImportati;

        }

         public void AddGrades(string curs, int nota)
        {
            studenti.LastOrDefault().Value.cursuri.Add(curs, nota);
        }
        public List<StudentModel> DisplayStudents()
        {
            List<StudentModel> lista = new List<StudentModel>();
            foreach (var item in studenti)
            {
                lista.Add(item.Value);
            }
            return lista;

        }

    }
}
