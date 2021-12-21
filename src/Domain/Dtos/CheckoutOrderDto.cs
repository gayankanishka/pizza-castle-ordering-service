namespace PizzaCastle.OrderingService.Domain.Dtos;

public class CheckoutOrderDto
{
    public Guid OrderId { get; set; }
    public DateTime Eta { get; set; }
    public bool Accepted { get; set; }
}