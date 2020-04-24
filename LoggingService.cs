using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace SampleProject
{
    public class LocationService : ILocationService
    {
        private RestClient _apiClient;
        private string _apiKey;
        public LocationService(String apiKey)
        {
            _apiKey = apiKey;
            _apiClient = new RestClient("http://api.companycarlocations.org");
        }

        public List<LocationDto> GetLocations()
        {
            var request = new RestRequest("data/2.5/location");
            request.AddParameter("appid", _apiKey);
            var response = _apiClient.Get(request);
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<LocationDto>>(response.Content);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}