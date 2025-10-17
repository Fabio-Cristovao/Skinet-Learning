using System.Reflection.Metadata;

namespace Core.Entities;

public class ShoppingCart
{
    public required string Id { get; set; }
    public List<CardItem> Items { get; set; } = [];
}
