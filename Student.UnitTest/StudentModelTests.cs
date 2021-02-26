using System;
using System.Collections.Generic;
using NUnit.Framework;
using Student.Model;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;

namespace Student.UnitTest
{
    [TestFixture]
    [TestOf(nameof(StudentModel))]
    public class StudentModelTests
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

        #region Test Methods

        [Test]
        public void ReadonlyPropertiesShouldHaveConstructorParameterAssignedValues()
       {

            // Arrange
            var verificareModel = new ConstructorInitializedMemberAssertion(_fixture);

            // Act / Assert
            verificareModel.Verify(typeof(StudentModel));
        }

        #endregion
    }
}