using BowlingApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BowlerController : ControllerBase
{
    private readonly BowlingDbContext _context;

    public BowlerController(BowlingDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<object> Get()
    {
        return _context.Bowlers
            .Include(b => b.Team)
            .Where(b => b.Team != null &&
                        (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
            .Select(b => new
            {
                b.BowlerID,
                BowlerFirstName = b.BowlerFirstName ?? "",
                BowlerMiddleInit = b.BowlerMiddleInit ?? "",
                BowlerLastName = b.BowlerLastName ?? "",
                TeamName = b.Team!.TeamName ?? "",
                BowlerAddress = b.BowlerAddress ?? "",
                BowlerCity = b.BowlerCity ?? "",
                BowlerState = b.BowlerState ?? "",
                BowlerZip = b.BowlerZip ?? "",
                BowlerPhoneNumber = b.BowlerPhoneNumber ?? ""
            })
            .ToList();
    }
}
