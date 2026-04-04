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
    public async Task CriarAlunoAsync(Aluno aluno)
    {
        aluno.Matricula = $"2026001{new Random().Next(0, 99)}";
        await _context.AddAsync(aluno);
        await _context.SaveChangesAsync();
    }
    
}

public interface IAlunoRepository
{
    Task CriarAlunoAsync(Aluno aluno);
}