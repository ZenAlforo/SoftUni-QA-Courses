using LibraryManagementSystem;

namespace LibraryManagementTest
{
    [TestFixture]
    public class LibraryTests
    {
        [Test]
        public void AddBook_ShouldAddANewBookToTheLibrary()
        {
            // Arrange
            Library library = new Library();

            var newBook = new Book
            {
                Id = 1,
                Title = "Test Book",
                Author = "Me",
                IsCheckedOut = false,
            };

            // Act
            library.AddBook(newBook);

            // Assert
            var allBooks = library.GetAllBooks();

            Assert.That(allBooks.Count, Is.EqualTo(1));

            var singleBook = allBooks.First();
            Assert.That(singleBook.Id, Is.EqualTo(newBook.Id));
            Assert.That(singleBook.Title, Is.EqualTo(newBook.Title));
            Assert.That(singleBook.Author, Is.EqualTo(newBook.Author));
            Assert.That(singleBook.IsCheckedOut, Is.EqualTo(newBook.IsCheckedOut));
        }

        [Test]
        public void CheckOutBook_ShouldReturnFalse_IfBookDoesNotExist()
        {
            // Arrange
            Library library = new Library();

            // Act
            var result = library.CheckOutBook(9);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOutBook_ShouldReturnFalse_IfBookAlreadyCheckedOut()
        {
            // Arrange
            Library library = new Library();
            Book myBook = new Book
            {
                Id = 1,
                Title = "Lord of the Rings",
                Author = "Tolkien",
                IsCheckedOut = true,
            };

            library.AddBook(myBook);

            // Act
            var result = library.CheckOutBook(9);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOutBook_ShouldReturnTrue_IfBookIsNotCheckOutAndExists()
        {
            // Arrange
            Library library = new Library();
            Book myBook = new Book
            {
                Id = 1,
                Title = "Lord of the Rings",
                Author = "Tolkien",
                IsCheckedOut = false,
            };

            library.AddBook(myBook);

            // Act
            var result = library.CheckOutBook(myBook.Id);

            // Assert
            Assert.IsTrue(result);
            var allBooks = library.GetAllBooks();
            var singleBook = allBooks.First();
            Assert.IsTrue(singleBook.IsCheckedOut);
        }

        [Test]
        public void ReturnBook_ShouldReturnFalse_IfBookIsNotCheckedOut()
        {
            // Arrange
            Library library = new Library();
            Book myBook = new Book
            {
                Id = 1,
                Title = "Lord of the Rings",
                Author = "Tolkien",
                IsCheckedOut = false,
            };

            library.AddBook(myBook);

            // Act
            var result = library.ReturnBook(myBook.Id);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnBook_ShouldReturnFalse_IfBookDoesNotExist()
        {
            // Arrange
            Library library = new Library();
            Book myBook = new Book
            {
                Id = 1,
                Title = "Lord of the Rings",
                Author = "Tolkien",
                IsCheckedOut = false,
            };

            library.AddBook(myBook);

            // Act
            var result = library.ReturnBook(3);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnBook_ShouldReturnTrue_IfBookIsCheckedOutAndExists()
        {
            // Arrange
            Library library = new Library();
            Book myBook = new Book
            {
                Id = 1,
                Title = "Lord of the Rings",
                Author = "Tolkien",
                IsCheckedOut = true,
            };

            library.AddBook(myBook);

            // Act
            var result = library.ReturnBook(myBook.Id);

            // Assert
            Assert.IsTrue(result);
            var allBooks = library.GetAllBooks();
            var singleBook = allBooks.First();
            Assert.IsFalse(singleBook.IsCheckedOut);
        }
    }
}