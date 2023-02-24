namespace Blog.Models;

public class Tag
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Slug { get; set; }

    public List<Post> Posts { get; set; }
}