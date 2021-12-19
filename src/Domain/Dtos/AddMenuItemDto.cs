namespace PizzaCastle.OrderingService.Domain.Dtos;

public class AddMenuItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
    public string Ingrediants { get; set; }
}