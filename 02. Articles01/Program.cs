string[] articleinfo = Console.ReadLine().Split(", ").ToArray();
int n = int.Parse(Console.ReadLine());

string title = articleinfo[0];
string content = articleinfo[1];
string author = articleinfo[2];

Article article = new Article(title, content, author); 

for (int i = 1; i <= n; i++)
{
    string[] cmdArg = Console.ReadLine().Split(": ").ToArray();
    string command = cmdArg[0];
    string newInfo = cmdArg[1];

    if (command == "Edit")
    {
        article.Edit(newInfo);
    }
    else if (command == "ChangeAuthor")
    {
        article.ChangeAuthor(newInfo);
    }
    else if (command == "Rename")
    {
        article.Rename(newInfo);
    }

}

Console.WriteLine(article.ToString());

class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public void Edit(string newContent)
    {
        Content = newContent;    
    }
    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }
    public void Rename(string newTitle)
    {
        Title = newTitle;
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}