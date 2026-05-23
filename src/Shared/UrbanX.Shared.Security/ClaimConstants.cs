namespace UrbanX.Shared.Security;

/// <summary>
/// Well-known claim type names used across UrbanX services.
/// Centralises magic strings to avoid typos and simplify refactoring.
/// </summary>
public static class ClaimConstants
{
    /// <summary>Subject identifier (user ID).</summary>
    public const string Sub = "sub";

    /// <summary>Role claim used in JWT tokens.</summary>
    public const string Role = "role";

    /// <summary>Role value for customers.</summary>
    public const string CustomerRole = "customer";

    /// <summary>Role value for merchants.</summary>
    public const string MerchantRole = "merchant";

    /// <summary>Role value for administrators.</summary>
    public const string AdminRole = "admin";
}
