using FilmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    //Método para adicionar filme
    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperarFilmePorId), 
            new { id = filme.Id }, filme);
    }

    //Método com paginacao para buscar filmes
    [HttpGet]
    public IEnumerable<Filme> RecuperarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    //Método para buscar filme por id especifico 
    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId(int id)
    {

        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        //Validacao de consulta de filme
        if (filme == null) return NotFound();
        return Ok(filme);
     }

}
