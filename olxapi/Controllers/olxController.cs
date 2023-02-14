using Microsoft.AspNetCore.Mvc;
using olxapi.Models;
using olxapi.Data;
using olxapi.Dtos;
using AutoMapper;

namespace olxapi.Controllers;
[ApiController]
[Route("[controller]")]
public class AdController : ControllerBase   
{

    private OlxContext _context;
    private IMapper _mapper;
    public AdController(OlxContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult addAd(
        [FromBody] CreateAdDto AdDto)
    {
        Console.WriteLine("5454545 ");
        Ad ad = _mapper.Map<Ad>(AdDto);
        _context.Ads.Add(ad);
        _context.SaveChanges();
        Console.WriteLine("asada ");
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