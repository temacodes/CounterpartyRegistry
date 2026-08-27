using System.ComponentModel.DataAnnotations;

namespace CounterpartyRegistry.Models;

public class Counterparty
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Inn { get; set; } = "";

    public string Kpp { get; set; } = "";

    public string Ogrn { get; set; } = "";

    public string LegalAddress { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Email { get; set; } = "";

    public string ContactPerson { get; set; } = "";

    public string Status { get; set; } = "Активен";
}