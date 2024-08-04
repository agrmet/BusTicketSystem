using BusTicketSystem.Models;
using BusTicketSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BusTicketSystem.Services;

public class TicketService(TicketSystemContext context)
{
    TicketSystemContext _context = context;
}