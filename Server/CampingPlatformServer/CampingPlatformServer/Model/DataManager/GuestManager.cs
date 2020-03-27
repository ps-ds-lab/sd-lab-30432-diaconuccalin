using CampingPlatformServer.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampingPlatformServer.Model.DataManager
{
    public class GuestManager : IDataRepository<Guest>
    {
        readonly CampingPlatformContext _campingPlatformContext;

        public GuestManager(CampingPlatformContext context)
        {
            _campingPlatformContext = context;
        }

        public IEnumerable<Guest> GetAll()
        {
            return _campingPlatformContext.Guests.ToList();
        }

        public Guest Get(Guid id)
        {
            return _campingPlatformContext.Guests.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Guest entity)
        {
            _campingPlatformContext.Guests.Add(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Update(Guest guest, Guest entity)
        {
            guest.Copy(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Delete(Guest guest)
        {
            _campingPlatformContext.Guests.Remove(guest);
            _campingPlatformContext.SaveChanges();
        }
    }
}
