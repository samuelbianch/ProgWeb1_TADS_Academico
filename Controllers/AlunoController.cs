using Academico.Models;
using Academico.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers;

public class AlunoController : Controller
{
    readonly IAlunoRepository _alunoRepository;

    public AlunoController(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public IActionResult Index()
    {
        List<Aluno> aluno1 = new List<Aluno>()
        {
            new Aluno()
            {
                Nome = "Arnaldo",
                Cpf = "12345678910",
                Curso = "Tecnologia em Análise e Desenvolvimento de Sistemas",
                Matricula = "20250988890",
                DataNascimento = new DateOnly(1988, 09, 02)    
            },
            new Aluno()
            {
                Nome = "Zé Coméia",
                Cpf = "09876543211",
                Curso = "Tecnologia em Análise e Desenvolvimento de Sistemas",
                Matricula = "20250988899",
                DataNascimento = new DateOnly(2000, 09, 02)
            }
            
        };
        return View(aluno1);
    }

    public IActionResult CriarAluno()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarAlunoAsync(Aluno aluno)
    {
        await _alunoRepository.CriarAlunoAsync(aluno);
        return RedirectToAction("CriarAluno");
    }
}