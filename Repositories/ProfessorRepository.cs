using Academico.Models;
using Microsoft.EntityFrameworkCore;

namespace Academico.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    readonly AcademicoContext _context;

    public ProfessorRepository(AcademicoContext context)
    {
        _context = context;
    }
    public async Task CriarProfessorAsync(Professor professor)
    {
        await _context.AddAsync(professor);
        await _context.SaveChangesAsync();
    }
    
}

public interface IProfessorRepository
{
    Task CriarProfessorAsync(Professor Professor);
}