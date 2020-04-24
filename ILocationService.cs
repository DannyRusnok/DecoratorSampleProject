using System.Collections.Generic;

namespace SampleProject
{
    public interface ILocationService
    {
        List<LocationDto> GetLocations();
    }
}