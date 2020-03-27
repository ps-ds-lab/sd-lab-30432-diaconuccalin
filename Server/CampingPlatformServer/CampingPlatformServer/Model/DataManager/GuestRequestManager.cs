using CampingPlatformServer.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampingPlatformServer.Model.DataManager
{
    public class GuestRequestManager : IDataRepository<GuestRequest>
    {
        readonly CampingPlatformContext _campingPlatformContext;

        public GuestRequestManager(CampingPlatformContext context)
        {
            _campingPlatformContext = context;
        }

        public IEnumerable<GuestRequest> GetAll()
        {
            return _campingPlatformContext.GuestRequests.ToList();
        }

        public GuestRequest Get(Guid id)
        {
            return _campingPlatformContext.GuestRequests.FirstOrDefault(e => e.Id == id);
        }

        public void Add(GuestRequest entity)
        {
            _campingPlatformContext.GuestRequests.Add(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Update(GuestRequest guestRequest, GuestRequest entity)
        {
            guestRequest.Copy(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Delete(GuestRequest guestRequest)
        {
            _campingPlatformContext.GuestRequests.Remove(guestRequest);
            _campingPlatformContext.SaveChanges();
        }
    }
}
