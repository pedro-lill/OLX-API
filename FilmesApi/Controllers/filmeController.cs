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
    /// <summary> 
    /// Create a new filme to the database
    /// </summary>
    /// <param name="filmeDto"> object with the fields needed to create the movie </param>
    /// <returns> The newly created filme </returns>
    /// <returns> IActionResult </returns>
    /// <response code="201"> the filme was created </response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult addFilme(
        [FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmesPorID),
            new { id = filme.Id },
            filme);
        }


    /// <summary>
    /// Update a filme in the database
    /// </summary>
    /// <param name="id"> id of the filme to be updated </param>
    /// <param name="filmeDto"> object with the fields to be updated </param>
    /// <returns> IActionResult </returns>
    /// <response code="204"> the filme was updated </response>
    /// <response code="404"> the filme was not found </response>
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


    /// <summary>
    /// get a filme in the database
    /// </summary>
    

    [HttpGet]
    public  IEnumerable<ReadFilmeDto> RecuperaFilmes(
        [FromQuery]int skip =0,[FromQuery] int take = 30)
    {
        return _mapper.Map<List<ReadFilmeDto>>(
            _context.Filmes.Skip(skip).Take(take));
    }


    /// <summary>
    /// Get a filme by id
    /// </summary>
    /// <param name="id"> id of the filme to be retrieved </param>
    /// <returns> IActionResult </returns>
    /// <response code="200"> the filme was retrieved </response>
    /// <response code="404"> the filme was not found </response>

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmesPorID(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }


    /// <summary>
    /// Update a filme in the database
    /// </summary>
    /// <param name="id"> id of the filme to be updated </param>
    /// <param name="patch"> object with the fields to be updated </param>
    /// <returns> IActionResult </returns>
    /// <response code="204"> the filme was updated </response>
    /// <response code="404"> the filme was not found </response>
    /// <response code="422"> the patch was not applied </response>

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
            return ValidationProblem(ModelState);
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }   


    /// <summary>
    /// Delete a filme in the database
    /// </summary>
    /// <param name="id"> id of the filme to be deleted </param>
    /// <returns> IActionResult </returns>
    /// <response code="204"> the filme was deleted </response>
    /// <response code="404"> the filme was not found </response>


    [HttpDelete("{id}")]

    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => 
            filme.Id == id);
        if (filme == null) 
            return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }



}