using System;
using System.Security.Claims;

namespace ToDoListAPI.Extensions;

public static class ClaimsPrincipleExtension
{
    public static string GetUserName(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Name)?.Value ?? throw new Exception("Cannot get username from token.\n please try logging in again");
    }

    public static string GetUserId(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new Exception("Cannot get Id from token.\n please try logging in again");
    }

}
