using Microsoft.AspNetCore.Mvc;
using Academico.Models;
using Academico.Repositories;

namespace Academico.Controllers;

public class ProfessorController : Controller
{
    readonly IProfessorRepository _professorRepository;

    public ProfessorController(IProfessorRepository professorRepository)
    {
        _professorRepository = professorRepository;
    }

    public async Task<IActionResult> ProfessoresAsync()
    {
        return View(await _professorRepository.GetAllProfessoresAsync());
    }

    public IActionResult CriarProfessor()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarProfessorAsync(Professor professor)
    {
        if(await _professorRepository.CriarProfessorAsync(professor))
        {
            TempData["Tipo"] = "success";
            TempData["Mensagem"] = $"Professor {professor.Nome} cadastrado com sucesso!";
        } else
        {
            TempData["Tipo"] = "danger";
            TempData["Mensagem"] = $"Professor {professor.Nome} não cadastrado!";
        }
        return RedirectToAction("CriarProfessor");
    }
}