using Academico.Models;
using Microsoft.EntityFrameworkCore;

namespace Academico.Repositories;

public class AlunoRepository : IAlunoRepository
{
    readonly AcademicoContext _context;

    public AlunoRepository(AcademicoContext context)
    {
        _context = context;
    }

    public async Task<bool> CriarAlunoAsync(Aluno aluno)
    {
        aluno.Matricula = $"{DateTime.Now.Year}{_context.Aluno.CountAsync().Result}{new Random().Next(0, 99)}";
        await _context.AddAsync(aluno);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Aluno>> GetAllAlunosAsync()
    {
        return await _context.Aluno.ToListAsync();
    }
}

public interface IAlunoRepository
{
    Task<bool> CriarAlunoAsync(Aluno aluno);
    Task<List<Aluno>> GetAllAlunosAsync();
}