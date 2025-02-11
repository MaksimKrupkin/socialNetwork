namespace api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

public class RegisterModel
{
    [Required]
    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Username может содержать только буквы и цифры.")]
    [JsonPropertyName("userName")] // Использовать camelCase для JSON
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    [JsonPropertyName("password")]
    public string Password { get; set; }
}