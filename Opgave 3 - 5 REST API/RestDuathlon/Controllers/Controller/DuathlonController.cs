using Microsoft.AspNetCore.Mvc;
using RestDuathlon.Controllers.Manager;
using RestDuathlon.Controllers.Models;

namespace RestDuathlon.Controllers.Controller;

[Route("api/[controller]")]
[ApiController]

public class DuathlonController : Microsoft.AspNetCore.Mvc.Controller
{
    private DuathlonManager _manager = new DuathlonManager(); 
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public ActionResult<IEnumerable<DuathlonManager>> GetAll([FromQuery] string? name, [FromQuery] int? ageGroup,
        [FromQuery] int? bike, [FromQuery] int? run)
    {

        IEnumerable<DuathlonData> duathlon = _manager.GetAll(name, ageGroup, bike, run);
        if (duathlon.Count() <= 0)
        {
            return NotFound();
        }
        else
        {
            return Ok(duathlon);
        }
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{bib}")]
    public ActionResult GetByBib(int bib)
    {
        DuathlonData duathlon = _manager.GetByBib(bib);
        if (duathlon == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(duathlon);
        }
        
        
    }
    
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public DuathlonData Add([FromBody] DuathlonData newDuathlon)
    {
        return _manager.Add(newDuathlon);
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{bib}")]
    public DuathlonData Delete(int bib)
    {
        DuathlonData testSite = _manager.GetByBib(bib);
        return _manager.Delete(bib);
    }
    
    [HttpPut("{bib}")]
    public DuathlonData Put(int bib, [FromBody] DuathlonData value)
    {
        return _manager.Update(bib, value);
    }

}