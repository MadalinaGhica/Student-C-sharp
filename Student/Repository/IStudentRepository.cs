using System;
using System.Collections.Generic;
using Student.Model;

namespace Student.Repository
{
    public interface IStudentRepository
    {
        StudentModel GetBestStudent();
        HashSet<StudentModel> GetNameSufixEscu();
        HashSet<string> GetCursuriStudiateAn(int anStudiu);
        void ExportDict(string numeCaleFisier);
        Dictionary<Guid, StudentModel> ImportDict(string numeCaleFisier);
        void AddStudent(StudentModel s);
        void AddGrades(string curs, int nota);
        List<StudentModel> DisplayStudents();
    }
}
