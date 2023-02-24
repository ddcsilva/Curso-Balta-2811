namespace Blog.Models;

public class Post
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataUltimaModificacao { get; set; }
    public Categoria Categoria { get; set; }
    public Usuario Autor { get; set; }

    public List<Tag> Tags { get; set; }
}