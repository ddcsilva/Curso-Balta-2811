namespace Blog.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Slug { get; set; }
    
    public IList<Post> Posts { get; set; }
}