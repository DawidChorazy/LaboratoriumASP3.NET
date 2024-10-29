using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApp.Models;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumvalue)
    {
        return enumvalue.GetType()
            .GetMember(enumvalue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            .GetName();
    }
}