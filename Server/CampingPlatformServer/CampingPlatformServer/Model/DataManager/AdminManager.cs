using CampingPlatformServer.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampingPlatformServer.Model.DataManager
{
    public class AdminManager : IDataRepository<Admin>
    {
        readonly CampingPlatformContext _campingPlatformContext;

        public AdminManager(CampingPlatformContext context)
        {
            _campingPlatformContext = context;
        }

        public IEnumerable<Admin> GetAll()
        {
            return _campingPlatformContext.Admins.ToList();
        }

        public Admin Get(Guid id)
        {
            return _campingPlatformContext.Admins.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Admin admin)
        {
            _campingPlatformContext.Admins.Add(admin);
            _campingPlatformContext.SaveChanges();
        }

        public void Update(Admin admin, Admin entity)
        {
            admin.Copy(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Delete(Admin admin)
        {
            _campingPlatformContext.Admins.Remove(admin);
            _campingPlatformContext.SaveChanges();
        }
    }
}
