using JobNetCore6.Core.Models;
using JobNetCore6.Entities;
using JobNetCore6.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace TestProject1
{
    [TestClass]
    public class CategoryRepositoryTests
    {
        private readonly Mock<ICategoryRepository> _mockRepository;

        public CategoryRepositoryTests()
        {
            _mockRepository = new Mock<ICategoryRepository>();
        }

        [TestMethod]
        public async Task GetAllCategorysAsync_ReturnsCorrectNumberOfBooks()
        {
            // Arrange
            var books = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 3, Name = "Category 2" },
                new Category { Id = 4, Name = "Category 3" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(books);

            // Act
            var result = await _mockRepository.Object.GetAllAsync();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, result.Count());
        }
        [TestMethod]
        public async Task GetCategoryByIdAsync_ReturnsCorrectBook()
        {
            // Arrange
            var categoryId = 1;
            var category = new Category { Id = categoryId, Name = "Family" };
            _mockRepository.Setup(repo => repo.GetByIdAsync(categoryId)).ReturnsAsync(category);

            // Act
            var result = await _mockRepository.Object.GetByIdAsync(categoryId);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(categoryId, result.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(category.Name, result.Name);

        }

        [TestMethod]
        public async Task AddCategoryAsync_ReturnsAddedCategory()
        {
            // Arrange
            var bookToAdd = new Category { Id = 13, Name = "Family" };
            _mockRepository.Setup(repo => repo.AddAsync(bookToAdd)).Returns(Task.FromResult(new Category { Id = 13, Name = "Family" }));

            // Act
            var result = await _mockRepository.Object.AddAsync(bookToAdd);
            // Assert

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(bookToAdd.Id, result.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(bookToAdd.Name, result.Name);
        }

        [TestMethod]
        public async Task DeleteCategoryAsync_DeletesExistingCategory()
        {
            // Arrange
            var categoryId = 1;
            _mockRepository.Setup(repo => repo.DeleteAsync(categoryId)).Returns(Task.CompletedTask);

            // Act
            await _mockRepository.Object.DeleteAsync(categoryId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(categoryId), Times.Once);
        }
        [TestMethod]
        public async Task UpdateCategoryAsync_UpdatesExistingCategory()
        {
            // Arrange
            var bookToUpdate = new Category { Id = 1, Name = "HIHI" };
            _mockRepository.Setup(repo => repo.UpdateAsync(bookToUpdate)).Returns(Task.CompletedTask);

            // Act
            await _mockRepository.Object.UpdateAsync(bookToUpdate);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(bookToUpdate), Times.Once);
        }
    }
}
