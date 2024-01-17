using Business.Abstract;
using Business.Concrete;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelsController : ControllerBase
{
    private readonly IFuelService _FuelService; 

    public FuelsController()
    {
        _FuelService = FuelServiceRegistration.FuelService;
    }

    

    [HttpGet]  
    public ICollection<Fuel> GetList()
    {
        IList<Fuel> FuelList = _FuelService.GetList();
        return FuelList; 
    }

    [HttpPost] 
    public ActionResult<AddTransmissonResponse> Add(AddFuelRequest request)
    {
        AddTransmissonResponse response = _FuelService.Add(request);

        return CreatedAtAction(nameof(GetList), response); 
    }
}
