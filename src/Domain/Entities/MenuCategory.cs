using System.ComponentModel.DataAnnotations;
using PizzaCastle.OrderingService.Domain.Common;

namespace PizzaCastle.OrderingService.Domain.Entities;

public class MenuCategory : AuditableEntity
{
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
}