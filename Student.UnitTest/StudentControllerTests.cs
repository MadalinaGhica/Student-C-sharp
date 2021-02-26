using System;
using NUnit.Framework;
using Student.Model;
using Student.Controller;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using Student.Repository;
using Moq;
using System.Linq;

namespace Student.UnitTest
{
    [TestFixture]
    [TestOf(nameof(StudentController))]
    public class StudentControllerTests
    {
        #region Fields

        private IFixture _fixture;
        private Mock<IStudentRepository> _studentRepositoryMock;

        #endregion

        #region Setup Methods

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _studentRepositoryMock = new Mock<IStudentRepository>();
        }

        #endregion
         [Test]
         public void verifyBestStudent()
        {
            // Arrange
            var student = _fixture.Build<StudentModel>().Create();

            // Act
            _studentRepositoryMock.Setup(x=>x.AddStudent(student));

            _fixture.Inject(_studentRepositoryMock);
            
            var SUT = _fixture.Build<StudentController>().Create();
            var actualValue= SUT.BestStudent();

            //Assert

            _studentRepositoryMock.Verify(x=>x.GetBestStudent(), Times.Once);
            Assert.That(actualValue, Is.EqualTo(SUT.bestStudent));

        }


        [Test]
        public void verifyAddStudent()
        {
            // Arrange
            var student = _fixture.Build<StudentModel>().Create();

            // Act
            _studentRepositoryMock.Setup(x => x.AddStudent(student));

            _fixture.Inject(_studentRepositoryMock);

            // Arrange
            var SUT = _fixture.Build<StudentController>().Create();

            //Assert
            SUT.AddStudent(student);
            _studentRepositoryMock.Verify(x => x.AddStudent(student), Times.Once);
            //Assert.That();


        }

        [Test]
        public void verifyAddStudentException()
        {
            // Arrange
            var student = _fixture.Build<StudentModel>().Create();

            // Act
            _studentRepositoryMock.Setup(x => x.AddStudent(null));

            _fixture.Inject(_studentRepositoryMock);

            // Arrange
            var SUT = _fixture.Build<StudentController>().Create();

            //Assert
            Assert.Throws<Exception>(() => SUT.AddStudent(null));

        }

        [Test]
        public void verifySufixEscu()
        {
            // Arrange
            var student = _fixture.Build<StudentModel>().With(x => x.LastName, "Popescu").Create();


            // Act
            _studentRepositoryMock.Setup(x => x.AddStudent(student));

            _fixture.Inject(_studentRepositoryMock);

            // Arrange
            var SUT = _fixture.Build<StudentController>().Create();

            //Assert
            var actualValue = SUT.SufixEscu();
          
            //Assert.IsNotNull(_studentRepositoryMock);
            _studentRepositoryMock.Verify(x => x.GetNameSufixEscu(), Times.Once);
            Assert.That(actualValue, Is.EqualTo(SUT.studentEscu));


        }

        [Test]
        public void verifyCursuriStudiateAn()
        {
            // Arrange
            var student = _fixture.Build<StudentModel>().Create();
            student.cursuri.Add("mate", 5);
            int anStudiu = student.YearOfStudy;

            // Act
            _studentRepositoryMock.Setup(x => x.AddStudent(student));

            _fixture.Inject(_studentRepositoryMock);

            // Arrange
            var SUT = _fixture.Build<StudentController>().Create();

            //Assert
            SUT.CursuriStudiateAn(anStudiu);

            _studentRepositoryMock.Verify(x => x.GetCursuriStudiateAn(anStudiu), Times.Once);
            //Assert.IsNotNull(_studentRepositoryMock.Object.GetCursuriStudiateAn(anStudiu).Count);

          
        }

        [Test]
        public void verifyAddGrades()
        {
            // Arrange
            var student = _fixture.Build<StudentModel>().Create();

            // Act
            _studentRepositoryMock.Setup(x => x.AddStudent(student));

            _fixture.Inject(_studentRepositoryMock);

            // Arrange
            var SUT = _fixture.Build<StudentController>().Create();

            //Assert
            SUT.AddGrades("mate", 8);
            _studentRepositoryMock.Verify(x => x.AddGrades("mate", 8), Times.Once);


        }


        [Test]
        public void verifyDisplayStudents()
        {
            // Arrange
            var student = _fixture.Build<StudentModel>().Create();

            // Act
            _studentRepositoryMock.Setup(x => x.AddStudent(student));

            _fixture.Inject(_studentRepositoryMock);

            // Arrange
            var SUT = _fixture.Build<StudentController>().Create();

            //Assert
            SUT.DisplayStudents();

            _studentRepositoryMock.Verify(x => x.DisplayStudents(), Times.Once);

            //verificare lista count e cat am adaugat
        }

        

    }
}
