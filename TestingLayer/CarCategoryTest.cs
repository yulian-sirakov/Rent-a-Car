using Bussines_Layer.Models;
using DataLayer.Common;
using DataLayer.ModelsContext;
using NUnit.Framework.Internal;

namespace TestingLayer
{
    [TestFixture]
    public class CarCategoryTest
    {
        private CarCategoryContext context = new CarCategoryContext(SetUpFixture.dbContext);
        private CarCategory category;


        [SetUp]
        public async Task CreateCategory()
        {
            category = new CarCategory(0, "light", "fast");
            await context.CreateAsync(category);
        }

        [TearDown]
        public void DropCategory()
        {
            foreach (var item in SetUpFixture.dbContext.CarCategories)
            {
                SetUpFixture.dbContext.CarCategories.Remove(item);
            }
            SetUpFixture.dbContext.SaveChanges();
        }

        [Test]
        public async Task Create()
        {
            //Arange
            CarCategory carCategory = new CarCategory(0,"Heavy","slow");

            //Act
            int carCategories = SetUpFixture.dbContext.CarCategories.Count();
            await context.CreateAsync(carCategory);
            

            //Assert
            int carCategoriesAfter = SetUpFixture.dbContext.CarCategories.Count();
            Assert.That(carCategories, Is.EqualTo(carCategoriesAfter - 1));
        }

        [Test]
        public async Task Read()
        {

            CarCategory readCategory = await context.ReadAsync(category.Id);


            Assert.That(readCategory, Is.EqualTo(category));
        }

        [Test]
        public async Task ReadAll()
        {

            ICollection<CarCategory> categories = await context.ReadAllAsync();

            Assert.That(categories.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task Update()
        {
            CarCategory carCategoryToChange = await context.ReadAsync(category.Id);

            carCategoryToChange.Description = "slow";

            carCategoryToChange.Name = "Heavy";

            await context.UpdateAsync(carCategoryToChange);

            category = await context.ReadAsync(category.Id);

            Assert.That(carCategoryToChange, Is.EqualTo(category));
        }

        [Test]
        public async Task Delete()
        {
            int categoriesBefore = SetUpFixture.dbContext.CarCategories.Count();

            await context.DeleteAsync(category.Id);

            int countAfter = SetUpFixture.dbContext.CarCategories.Count();

            Assert.That(categoriesBefore, Is.EqualTo(countAfter+1));

        }

    }
}