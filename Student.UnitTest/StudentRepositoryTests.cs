using System;
using System.Collections.Generic;
using NUnit.Framework;
using Student.Model;
using Student.Repository;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;

namespace Student.UnitTest
{
    [TestFixture]
    [TestOf(nameof(StudentRepository))]
    public class StudentRepositoryTests
    {
        #region Fields

        private IFixture _fixture;

        #endregion

        #region Setup Methods

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
        }

        #endregion

        [Test]
        public void ShouldAddAStudentToTheDictionary()
       {

            // Arrange
            var SUT = new StudentRepository();
            StudentModel Student1 = new StudentModel(Guid.NewGuid(), "Ovidiu", "Popescu", "A", 3);

            //var student = _fixture.Build<StudentModel>().With(x=>x.firstName,"Ovidiu").Create();
            var student = _fixture.Build<StudentModel>().Create();

            // Act 
            SUT.AddStudent(student);

            // Assert
            Assert.That(SUT.studenti.Count, Is.EqualTo(1));
        }


        [Test]
        public void ShouldReturnBestStudentFromDictionary()
        {

            // Arrange
            var SUT = new StudentRepository();

            var student1 = _fixture.Build<StudentModel>().Create();
            var student2 = _fixture.Build<StudentModel>().Create();
            student1.cursuri.Add("MATE", 9);
            student1.cursuri.Add("ROM", 7);
            student2.cursuri.Add("MATE", 5);
            student2.cursuri.Add("ROM", 9);

            // Act
            SUT.AddStudent(student1);
            SUT.AddStudent(student2);
            var student = SUT.GetBestStudent();

            // Assert
            Assert.That(student.NrIdentificare, Is.EqualTo(student1.NrIdentificare));
        }

        [Test]
        public void ShouldReturnStudentsWithSufixEscu ()
        {

            // Arrange
            var SUT = new StudentRepository();
            var student = _fixture.Build<StudentModel>().With(x => x.LastName, "Popescu").Create();

            // Act
            SUT.AddStudent(student);
            var stundetnEscu = SUT.GetNameSufixEscu();

            // Assert
            Assert.IsTrue(stundetnEscu.Contains(student));
        }

        [Test]
        public void ShouldReturnCursuriStudiateAn()
        {

            // Arrange
            var SUT = new StudentRepository();
            var student = _fixture.Build<StudentModel>().Create();
            StudentModel Student1 = new StudentModel(Guid.NewGuid(), "Daniel", "Ionescu", "C", 1);
            StudentModel Student2 = new StudentModel(Guid.NewGuid(), "Anamaria", "Chitu", "D", 3);
            Student1.cursuri.Add("Engleza", 10);
            Student1.cursuri.Add("BMSD", 6);
            Student1.cursuri.Add("Electronica" , 8);
    

            Student2.cursuri.Add("ALGAED", 7);
            Student2.cursuri.Add("C++", 5);
            Student2.cursuri.Add("Matematici speciale", 6);
            //student.cursuri.Add("rom", 5);
            //student.cursuri.Add("mate", 7);
            //student.cursuri.Add("electrica", 9);
            int anStudiu = 1;

            // Act
            SUT.AddStudent(Student1);
            SUT.AddStudent(Student2);
            var materii = SUT.GetCursuriStudiateAn(anStudiu);

            // Assert
            Assert.IsTrue(materii.Contains("Engleza"));
        }

        [Test]
        public void ShouldVerifyAddGrades()
        {

            // Arrange
            var SUT = new StudentRepository();
            var student = _fixture.Build<StudentModel>().Create();

            // Act
            SUT.AddStudent(student);
            SUT.AddGrades("mate", 8);

            // Assert
            Assert.IsTrue(student.cursuri.ContainsKey("mate"));
            Assert.IsTrue(student.cursuri.ContainsValue(8));

        }


        [Test]
        public void ShouldVerifyDisplayStudents()
        {

            // Arrange
            var SUT = new StudentRepository();
            var student = _fixture.Build<StudentModel>().Create();

            // Act
            SUT.AddStudent(student);
            SUT.DisplayStudents();

            // Assert
            Assert.That(SUT.DisplayStudents().Count, Is.EqualTo(1));
        }

    }
}