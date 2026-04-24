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
    public async Task<bool> CriarProfessorAsync(Professor professor)
    {
        await _context.AddAsync(professor);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Professor>> GetAllProfessoresAsync()
    {
        return await _context.Professor.ToListAsync();
    }
    
}

public interface IProfessorRepository
{
    Task<bool> CriarProfessorAsync(Professor Professor);
    Task<List<Professor>> GetAllProfessoresAsync();
}