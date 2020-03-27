using CampingPlatformServer.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampingPlatformServer.Model.DataManager
{
    public class LocationManager : IDataRepository<Location>
    {
        readonly CampingPlatformContext _campingPlatformContext;

        public LocationManager(CampingPlatformContext context)
        {
            _campingPlatformContext = context;
        }

        public IEnumerable<Location> GetAll()
        {
            return _campingPlatformContext.Locations.ToList();
        }

        public Location Get(Guid id)
        {
            return _campingPlatformContext.Locations.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Location entity)
        {
            _campingPlatformContext.Locations.Add(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Update(Location location, Location entity)
        {
            location.Copy(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Delete(Location location)
        {
            _campingPlatformContext.Locations.Remove(location);
            _campingPlatformContext.SaveChanges();
        }
    }
}
