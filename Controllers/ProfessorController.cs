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

    public IActionResult CriarProfessor()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarProfessorAsync(Professor professor)
    {
        await _professorRepository.CriarProfessorAsync(professor);
        return RedirectToAction("CriarProfessor");
    }
}