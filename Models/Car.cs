namespace gregslistFinal.Models
{
  public class Car
  {
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int? Year { get; set; }
    public int? Price { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public string Color { get; set; }
  }
}