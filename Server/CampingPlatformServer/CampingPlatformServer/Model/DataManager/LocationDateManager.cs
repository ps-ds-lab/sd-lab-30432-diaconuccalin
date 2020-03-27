using CampingPlatformServer.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampingPlatformServer.Model.DataManager
{
    public class LocationDateManager : IDataRepository<LocationDate>
    {
        readonly CampingPlatformContext _campingPlatformContext;

        public LocationDateManager(CampingPlatformContext context)
        {
            _campingPlatformContext = context;
        }

        public IEnumerable<LocationDate> GetAll()
        {
            return _campingPlatformContext.LocationDates.ToList();
        }

        public LocationDate Get(Guid id)
        {
            return _campingPlatformContext.LocationDates.FirstOrDefault(e => e.Id == id);
        }

        public void Add(LocationDate entity)
        {
            _campingPlatformContext.LocationDates.Add(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Update(LocationDate locationDate, LocationDate entity)
        {
            locationDate.Copy(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Delete(LocationDate locationDate)
        {
            _campingPlatformContext.LocationDates.Remove(locationDate);
            _campingPlatformContext.SaveChanges();
        }
    }
}
