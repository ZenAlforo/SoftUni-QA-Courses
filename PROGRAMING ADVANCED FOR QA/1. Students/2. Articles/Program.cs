namespace _2._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleData = Console.ReadLine().Split(", ");
            int rotations = int.Parse(Console.ReadLine());
            (string title, string content, string author) = (articleData[0], articleData[1], articleData[2]);

            Article currentArticle = new Article(title, content, author);

            for (int i = 0; i < rotations; i++)
            {
                string[] newArticleData = Console.ReadLine().Split(": ");
                string whatToDo = newArticleData[0];
                if (whatToDo == "Edit")
                {
                    string newContent = newArticleData[1];
                    currentArticle.Edit(newContent);
                } else if (whatToDo == "ChangeAuthor")
                {
                    string newAuthor = newArticleData[1];
                    currentArticle.ChangeAuthor(newAuthor);

                }
                else if (whatToDo == "Rename")
                {
                    string newTitle = newArticleData[1];
                    currentArticle.Rename(newTitle);

                }
            }

            Console.WriteLine($"{currentArticle.Title} - {currentArticle.Content}: {currentArticle.Author}");
        }
    }
}
