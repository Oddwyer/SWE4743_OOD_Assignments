namespace TeaShoppe.Web.Domain.Common;

/// <summary>
/// Primary sort class to ensure only one sort selection is primary.
/// Note: Both cannot be primary / secondary at the same time.
/// </summary>

public enum PrimarySort
{
    Price,
    Rating
}
