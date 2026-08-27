using Microsoft.AspNetCore.Mvc;
using CounterpartyRegistry.Models;

namespace CounterpartyRegistry.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CounterpartiesController : ControllerBase
{
    private static List<Counterparty> counterparties = new()
    {
        new Counterparty
        {
            Id = 1,
            Name = "ООО Ромашка",
            Inn = "7701234567",
            Kpp = "770201001",
            Ogrn = "1234567890123",
            LegalAddress = "г. Москва, ул. Ленина, д. 1",
            Phone = "+7 900 123-45-67",
            Email = "info@romashka.ru",
            ContactPerson = "Иванов Иван",
            Status = "Активен"
        },

        new Counterparty
        {
            Id = 2,
            Name = "АО Техно",
            Inn = "7707654321",
            Kpp = "770201001",
            Ogrn = "1234567890124",
            LegalAddress = "г. Москва, ул. Гагарина, д. 10",
            Phone = "+7 900 765-43-21",
            Email = "info@techno.ru",
            ContactPerson = "Петров Петр",
            Status = "Активен"
        }
    };

    // GET: api/counterparties
    [HttpGet]
    public ActionResult<List<Counterparty>> GetAll()
    {
        return Ok(counterparties);
    }

    // GET: api/counterparties/1
    [HttpGet("{id}")]
    public ActionResult<Counterparty> GetById(int id)
    {
        var counterparty = counterparties.FirstOrDefault(x => x.Id == id);

        if (counterparty == null)
            return NotFound();

        return Ok(counterparty);
    }

    // POST: api/counterparties
    [HttpPost]
    public ActionResult<Counterparty> Create(Counterparty counterparty)
    {
        counterparty.Id = counterparties.Count == 0
            ? 1
            : counterparties.Max(x => x.Id) + 1;

        counterparties.Add(counterparty);

        return CreatedAtAction(
            nameof(GetById),
            new { id = counterparty.Id },
            counterparty);
    }

    // PUT: api/counterparties/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Counterparty updatedCounterparty)
    {
        var counterparty = counterparties.FirstOrDefault(x => x.Id == id);

        if (counterparty == null)
            return NotFound();

        counterparty.Name = updatedCounterparty.Name;
        counterparty.Inn = updatedCounterparty.Inn;
        counterparty.Kpp = updatedCounterparty.Kpp;
        counterparty.Ogrn = updatedCounterparty.Ogrn;
        counterparty.LegalAddress = updatedCounterparty.LegalAddress;
        counterparty.Phone = updatedCounterparty.Phone;
        counterparty.Email = updatedCounterparty.Email;
        counterparty.ContactPerson = updatedCounterparty.ContactPerson;
        counterparty.Status = updatedCounterparty.Status;

        return NoContent();
    }

    // DELETE: api/counterparties/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var counterparty = counterparties.FirstOrDefault(x => x.Id == id);

        if (counterparty == null)
            return NotFound();

        counterparties.Remove(counterparty);

        return NoContent();
    }
}