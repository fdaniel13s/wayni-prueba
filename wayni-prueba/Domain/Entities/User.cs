using System.ComponentModel.DataAnnotations;

namespace wayni_prueba.Domain.Entities;

public class User
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string DNI { get; set; }
}