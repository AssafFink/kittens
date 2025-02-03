using Microsoft.AspNetCore.Mvc;

namespace AssafFinkelshtein;

[ApiController]
public class KittensController : ControllerBase
{
    [HttpGet("api/kittens")]
    public IActionResult GetAllKittens()
    {
        return Ok(Repository.Kittens);
    }

    [HttpGet("api/kittens/{id}")]
    public IActionResult GetOneKitten(int id)
    {
        Kitten? kitten = Repository.Kittens.SingleOrDefault(k => k.ID == id);
        return Ok(kitten);
    }

    [HttpGet("api/kitten-by-name/{name}")]
    public IActionResult GetKittenByName(string name)
    {
        Kitten? kitten = Repository.Kittens.SingleOrDefault(k => k.Name == name);
        return Ok(kitten);
    }
}
