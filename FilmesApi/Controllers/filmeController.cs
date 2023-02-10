using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using FilmesApi.Data;
using FilmesApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesApi.Controllers;
[ApiController]
[Route("[controller]")]
public class filmeController : ControllerBase   
{

    private FilmeContext _context;
    private IMapper _mapper;
    public filmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult addFilme(
        [FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        // Filme filme = new Filme
        // {
        //     Titulo = filmeDto.Titulo,
        //     Diretor = filmeDto.Diretor,
        //     Duracao = filmeDto.Duracao,
        //     Genero = filmeDto.Genero
        // };
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(porID),
            new { id = filme.Id },
            filme);
        }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, 
        [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => 
            filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public  IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip =0,[FromQuery] int take = 30)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult porID(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        return Ok(filme);
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, 
        JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => 
            filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        // aplica o patch no filmeParaAtualizar
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        // verifica se o patch foi aplicado corretamente
        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }   
}