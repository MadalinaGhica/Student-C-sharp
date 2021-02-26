using System;
using System.Collections.Generic;
using Student.Model;
using Student.Repository;

namespace Student.Controller
{
    public class StudentController
    {
        private readonly IStudentRepository _repositoryService;

        public StudentModel bestStudent { get; set; }
        public HashSet<StudentModel> studentEscu { get; set; }
        public HashSet<string> cursuriAn { get; set; }
        public List<StudentModel> afisareStudent { get; set; }


        public StudentController(IStudentRepository repositoryService)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
        }


        public void AddStudent(StudentModel s)
        {
            try
            {
                    _repositoryService.AddStudent(s);
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - No student: " + e.Message);

            }
            
        }


        public StudentModel BestStudent()
        {
            try
            {
                if (_repositoryService.GetBestStudent() != null)
                {
                    bestStudent = _repositoryService.GetBestStudent();
                    
                }

            }catch (Exception e)
            {
                Console.WriteLine("No students or grades to calculate the best grades: " + e.Message);
            }

            return bestStudent;

        }


        public HashSet<StudentModel> SufixEscu()
        {
            
            return studentEscu = _repositoryService.GetNameSufixEscu();
        }


        public HashSet<string> CursuriStudiateAn(int anStudiu)
        {
            try
            {
                if (_repositoryService.GetCursuriStudiateAn(anStudiu) != null)
                {
                    cursuriAn = _repositoryService.GetCursuriStudiateAn(anStudiu);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No year of study entered " + e.Message);
            }
            return cursuriAn;

        }


        public void ExportDict(string numeCaleFisier)
        {
            _repositoryService.ExportDict(numeCaleFisier);
        }


        public Dictionary<Guid, StudentModel> ImportDict(string numeCaleFisier)
        {
            return _repositoryService.ImportDict(numeCaleFisier);
        }

        public void AddGrades(string curs, int nota)
        {
            _repositoryService.AddGrades(curs, nota);
        }

        public List<StudentModel> DisplayStudents()
        {
           return afisareStudent = _repositoryService.DisplayStudents();
        }


    }

}

