using CampingPlatformServer.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampingPlatformServer.Model.DataManager
{
    public class HostManager : IDataRepository<Host>
    {
        readonly CampingPlatformContext _campingPlatformContext;

        public HostManager(CampingPlatformContext context)
        {
            _campingPlatformContext = context;
        }

        public IEnumerable<Host> GetAll()
        {
            return _campingPlatformContext.Hosts.ToList();
        }

        public Host Get(Guid id)
        {
            return _campingPlatformContext.Hosts.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Host entity)
        {
            _campingPlatformContext.Hosts.Add(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Update(Host host, Host entity)
        {
            host.Copy(entity);
            _campingPlatformContext.SaveChanges();
        }

        public void Delete(Host host)
        {
            _campingPlatformContext.Hosts.Remove(host);
            _campingPlatformContext.SaveChanges();
        }
    }
}
