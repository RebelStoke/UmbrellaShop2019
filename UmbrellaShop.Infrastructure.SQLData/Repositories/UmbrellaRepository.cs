using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;
using UmbrellaShop.Infrastructure.SQLData;

namespace UmbrellaShop.Infrastructure.SQLData.Repositories
{
    public class UmbrellaRepository : IUmbrellaRepository
    {
        UmbrellaShopContext context;
        public UmbrellaRepository(UmbrellaShopContext ctx) {
           context = ctx;
        }
        public Umbrella Create(Umbrella Umbrella)
        {
           context.Umbrellas.Add(Umbrella);
           context.SaveChanges();
           return Umbrella;
        }

        public Umbrella Delete(int id)
        {
            var Umbrella = ReadByID(id);
            context.Remove(Umbrella);
            context.SaveChanges();
            return Umbrella;
        }

        public Umbrella ReadByID(int id)
        {
            return context.Umbrellas.Find(id);
        }

        public IEnumerable<Umbrella> ReadUmbrellas(Filter filter)
        {
            if (filter != null)
            {

                var list = context.Umbrellas
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
                return list;

            }
            else
                return context.Umbrellas;
        }

        public Umbrella Update(int id, Umbrella Umbrella)
        {
            if (Delete(id) != null) {
                Umbrella.Id = id;
                return Create(Umbrella);
            }
            return null;
        }
    }
}
