using System;
using System.Collections.Generic;
using System.Diagnostics;
using NLog;

namespace SampleProject
{
    public class LoggingLocationService : ILocationService
    {
        private ILocationService _innerLocationService;
        private ILogger _logger;

        public LoggingLocationService(
            ILocationService locationService,
            ILogger logger)
        {
            _innerLocationService = locationService;
            _logger = logger;
        }
        public List<LocationDto> GetLocations()
        {
            Stopwatch sw = Stopwatch.StartNew();
            List<LocationDto> locations = _innerLocationService.GetLocations();
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            _logger.Warn($"Retrieved location data - Elapsed ms{elapsedMillis}");
            return locations;
        }
    }
}
