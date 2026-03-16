namespace TeaShoppe.Web.Web.ViewModels;

/// <summary>
/// This ViewModel is part of the standard ASP.NET Core MVC error handling template.
/// It is required by the Shared/Error.cshtml view to display diagnostic information
/// when an unhandled exception occurs in a non-development environment.
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Gets or sets a unique identifier for the current request.
    /// This is used to correlate user error reports with server-side logs.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Returns true if the RequestId is not null or empty, indicating it should be displayed to the user.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
