using Microsoft.AspNetCore.Mvc;
using olxapi.models;

namespace olxapi.Controllers;

[ApiController]
[Route("[controller]")]
public class anuncioController : ControllerBase   
{
    private static List<Anuncio> anuncios = new List<Anuncio>();
    [HttpPost]
    public void AdicionaAnuncio([FromBody] Anuncio anuncio)
    {
        anuncios.Add(anuncio);
        
    }

     [HttpGet]
    public  IEnumerable<Anuncio> RecuperaAnuncios()
    {
        return anuncios;
    }

}
