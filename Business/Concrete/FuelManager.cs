using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class FuelManager : IFuelService
{
    private readonly IFuelDal _FuelDal;
    private readonly FuelBusinessRules _FuelBusinessRules;
    private readonly IMapper _mapper;

    public FuelManager(IFuelDal FuelDal, FuelBusinessRules FuelBusinessRules, IMapper mapper)
    {
        _FuelDal = FuelDal; 
        _FuelBusinessRules = FuelBusinessRules;
        _mapper = mapper;
    }

    public AddTransmissonResponse Add(AddFuelRequest request)
    {
        
        _FuelBusinessRules.CheckIfFuelNameNotExists(request.Name);

        
        

        Fuel FuelToAdd = _mapper.Map<Fuel>(request); 

        _FuelDal.Add(FuelToAdd);

        AddTransmissonResponse response = _mapper.Map<AddTransmissonResponse>(FuelToAdd);
        return response;
    }

    public IList<Fuel> GetList()
    {
        

        IList<Fuel> FuelList = _FuelDal.GetList();
        return FuelList;
    }
}
