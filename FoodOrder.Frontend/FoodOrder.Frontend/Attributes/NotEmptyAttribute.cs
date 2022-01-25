using System;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.Frontend.Attributes;

[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false
    )]
public class NotEmptyAttribute : ValidationAttribute
{
    private const string DefaultErrorMessage = "The field must not be empty";
    
    public NotEmptyAttribute(string errorMessage = DefaultErrorMessage) : base(errorMessage)
    {
    }

    public override bool IsValid(object value)
    {
        //NotEmpty doesn't necessarily mean required
        if (value is null)
        {
            return true;
        }

        switch (value)
        {
            case Guid guid:
                return guid != Guid.Empty;
            default:
                return true;
        }
    }
}