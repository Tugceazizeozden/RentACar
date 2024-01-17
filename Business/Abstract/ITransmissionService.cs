using Business.Requests.Transmission;
using Business.Responses.Fuel;
using Entities.Concrete;

namespace Business.Abstract;

public interface ITransmissionService
{
    public AddTransmissionResponse Add(AddTransmissionRequest request);

    public IList<Transmission> GetList();
}
