using System.Data.Entity.Validation;
using BankingSite.Models;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    public class RepositoryTests
    {  
        [Test]
        public void ShouldPopulateIdOnCreateLoanApplication()
        {
            var sut = new Repository();

            var applicationToSave = new LoanApplication
            {
                FirstName = "Gentry",
                LastName = "Smith",
                Age = 33,
                AnnualIncome = 12345.67m
            };

            sut.Create(applicationToSave);

            Assert.That(applicationToSave.ID, Is.Not.EqualTo(0));
        }


        [Test]
        public void ShouldRetrieveCreatedApplication()
        {
            var sut = new Repository();

            var applicationToSave = new LoanApplication
            {
                FirstName = "Gentry",
                LastName = "Smith",
                Age = 33,
                AnnualIncome = 12345.67m
            };

            sut.Create(applicationToSave);            

            var retrievedApplication = sut.Find(applicationToSave.ID);

            Assert.That(retrievedApplication.FirstName, Is.EqualTo(applicationToSave.FirstName));
            Assert.That(retrievedApplication.LastName, Is.EqualTo(applicationToSave.LastName));
            Assert.That(retrievedApplication.Age, Is.EqualTo(applicationToSave.Age));
            Assert.That(retrievedApplication.AnnualIncome, Is.EqualTo(applicationToSave.AnnualIncome));
        }


        [Test]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ShouldNotCreateEmptyLoanApplication()
        {
            var sut = new Repository();

            var applicationToSave = new LoanApplication();

            sut.Create(applicationToSave);
        }

        [Test]
        public void ShouldReturnNullWhenIdNotExists()
        {
            var sut = new Repository();

            Assert.That(sut.Find(999999), Is.Null);
        }
    }
}
