using CampingPlatformServer.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampingPlatformServer.Model.DataManager
{
    public class LocationImageManager : IDataRepository<LocationImage>
    {
        readonly CampingPlatformContext _campingPlatformContext;

        public LocationImageManager(CampingPlatformContext context)
        {
            _campingPlatformContext = context;
        }

        public IEnumerable<LocationImage> GetAll()
        {
            return _campingPlatformContext.LocationImages.ToList();
        }

        public LocationImage Get(Guid id)
        {
            return _campingPlatformContext.LocationImages.FirstOrDefault(e => e.Id == id);
        }

        public void Add(LocationImage entity)
        {
            _campingPlatformContext.LocationImages.Add(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Update(LocationImage locationImage, LocationImage entity)
        {
            locationImage.Copy(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Delete(LocationImage locationImage)
        {
            _campingPlatformContext.LocationImages.Remove(locationImage);
            _campingPlatformContext.SaveChanges();
        }
    }
}
