using Microsoft.AspNetCore.Mvc;

[AttributeUsage(AttributeTargets.Method)]
public class FileResultContentTypeAttribute : ProducesAttribute
{
    public FileResultContentTypeAttribute(string contentType) : base(contentType)
    {
    }
}