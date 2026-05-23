using Microsoft.AspNetCore.Http;

namespace UrbanX.Shared.Security;

/// <summary>
/// Extension methods for extracting authentication information from <see cref="HttpContext"/>.
/// Replaces the duplicated claim-extraction pattern found across services.
/// </summary>
public static class HttpContextAuthExtensions
{
    /// <summary>
    /// Gets the authenticated user's ID from the "sub" claim.
    /// Returns <c>null</c> if the claim is missing or not a valid GUID.
    /// </summary>
    public static Guid? GetAuthenticatedUserId(this HttpContext httpContext)
    {
        var sub = httpContext.User.FindFirst(ClaimConstants.Sub)?.Value;
        if (Guid.TryParse(sub, out var userId))
        {
            return userId;
        }
        return null;
    }

    /// <summary>
    /// Verifies that the authenticated user's "sub" claim matches the given <paramref name="expectedUserId"/>.
    /// Returns <c>true</c> if the caller is the expected user or has the admin role.
    /// </summary>
    public static bool IsAuthorizedForUser(this HttpContext httpContext, Guid expectedUserId)
    {
        if (httpContext.User.HasClaim(ClaimConstants.Role, ClaimConstants.AdminRole))
        {
            return true;
        }

        var callerId = httpContext.GetAuthenticatedUserId();
        return callerId.HasValue && callerId.Value == expectedUserId;
    }
}
