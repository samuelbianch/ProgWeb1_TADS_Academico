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

    public async Task<IActionResult> Index()
    {
        var alunos = await _alunoRepository.GetAllAlunosAsync();
        return View(alunos);
    }

    public IActionResult CriarAluno()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarAlunoAsync(Aluno aluno)
    {
        if(await _alunoRepository.CriarAlunoAsync(aluno))
        {
            TempData["Tipo"] = "success";
            TempData["Mensagem"] = $"Aluno {aluno.Nome} cadastrado com sucesso!";
        } else
        {
            TempData["Tipo"] = "danger";
            TempData["Mensagem"] = $"Aluno {aluno.Nome} não cadastrado!";
        }
        return RedirectToAction("CriarAluno");
    }
}