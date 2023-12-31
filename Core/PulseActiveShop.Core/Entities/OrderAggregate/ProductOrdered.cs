namespace PulseActiveShop.Core.Entities;

/// <summary>
/// Represents a snapshot of the item that was ordered. If catalog item details change, details of
/// the item that was part of a completed order should not change.
/// </summary>
public record ProductOrdered(int ProductId, string ProductName, string PictureUri);