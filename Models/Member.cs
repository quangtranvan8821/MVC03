using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MVC03.Models;

public class Member
{
    [Required(ErrorMessage = "Please enter your name.")]
    [Key]
    public string? MemberName { get; set; }
    [Required(ErrorMessage = "Please enter your birth day.")]

    [Range(1900, 2023)]
    [DataType(DataType.Text)]
    public int YearOfBirth { get; set; }
    [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter a valid email address Ex: emailName@domain")]

    [Required(ErrorMessage = "Please enter your email.")]

    public string? Email { get; set; }
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number")]
    [Required(ErrorMessage = "Please enter your phone number.")]

    public string? Phone { get; set; }
    [Required(ErrorMessage = "Please enter your gender.")]

    public string? Gender { get; set; }

    [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]

    public string? MemberPassword { get; set; }

}