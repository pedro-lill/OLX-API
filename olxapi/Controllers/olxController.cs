using Microsoft.AspNetCore.Mvc;
using olxapi.Models;
using olxapi.Data;
using olxapi.Dtos;
using AutoMapper;

namespace FilmesApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AdController : ControllerBase   
{

    private AdContext _context;
    private IMapper _mapper;
    public AdController(AdContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult addAd(
        [FromBody] CreateAdDto AdDto)
    {
        Ad ad = _mapper.Map<Ad>(adDto);
        // Filme filme = new Filme
        // {
        //     Titulo = filmeDto.Titulo,
        //     Diretor = filmeDto.Diretor,
        //     Duracao = filmeDto.Duracao,
        //     Genero = filmeDto.Genero
        // };
        _context.Ads.Add(ad);
        _context.SaveChanges();
        return CreatedAtAction(nameof(porID),
            new { id = ad.Id },
            ad);
        }

    [HttpPut("{id}")]
    public IActionResult AtualizaAd(int id, 
        [FromBody] UpdateAdDto adDto)
    {
        var ad = _context.Ads.FirstOrDefault(ad => 
            ad.Id == id);
        if (ad == null)
        {
            return NotFound();
        }
        _mapper.Map(adDto, ad);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public  IEnumerable<Ad> RecuperaAds([FromQuery]int skip =0,[FromQuery] int take = 30)
    {
        return _context.Ads.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult porID(int id)
    {
        var ad = _context.Ads.FirstOrDefault(ad => ad.Id == id);
        if (ad == null)
        {
            return NotFound();
        }
        return Ok(ad);
    }


}