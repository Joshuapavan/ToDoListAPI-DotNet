using System;

namespace ToDoListAPI.Exceptions;

public class ApiException(int statusCode, String message, String? details)
{
    public int statusCode { get; set; } = statusCode;
    public String message { get; set; } = message;
    public String? details { get; set; } = details;

}