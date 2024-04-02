using Api.Data;
using Api.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace Api.Models.Repository
{
    public class ItemsRepository : IbaseRepository<Item, ItemModel>
    {

        private readonly ApplicationDbContext context;
        public ItemsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        //public void Add(Item entity)
        //{
        //    context.items.Add(entity);

        //    context.SaveChanges();
        //}


        public void DeleteById(int id)
        {
            var item = context.items.FirstOrDefault(x => x.Id == id);
            context.items.Remove(item);

            context.SaveChanges();
        }


        public void DeleteByName(string name)
        {
            var item = context.items.FirstOrDefault(x => x.Name == name);
            context.items.Remove(item);

            context.SaveChanges();
        }

        public List<Item> GetAll()
        {
            var Items = context.items.ToList();
            return Items;
        }

        public Item GetById(int id)
        {
            var item = context.items.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return null;

            return item;
        }

        public Item GetByName(string name)
        {
            var item = context.items.FirstOrDefault(x => x.Name == name);
            if (item == null)
                return null;

            return item;
        }

        public void Update(int id, ItemModel entity)
        {
            using var stream = new MemoryStream();
            entity.Image.CopyTo(stream);

            var item = new Item
            {
                Name = entity.Name,
                Image = stream.ToArray() ,
                CategoryId = entity.CategoryId   
            };

            context.items.Update(item);
            context.SaveChanges();
        }

        public Item UpdateWithPatch(JsonPatchDocument<Item> entity, int id)
        {

            var item = context.items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return null;
            }

            entity.ApplyTo(item);
            context.SaveChanges();
            return item;

        }

        void IbaseRepository<Item, ItemModel>.Add(ItemModel entity)
        {
          

            if(entity != null)
            {
                using var str = new MemoryStream();
                entity.Image.CopyTo(str);

                var item = new Item
                {
                    Name = entity.Name,
                    Image = str.ToArray(),
                    CategoryId = entity.CategoryId  
                };

                context.items.Add(item);
                context.SaveChanges();
            }
        }

        Item IbaseRepository<Item, ItemModel>.Update(int id, ItemModel entity)
        {
            var item = context.items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                using var stream = new MemoryStream();
                entity.Image.CopyTo(stream);

                item.Name = entity.Name;
                item.Image = stream.ToArray();
                item.CategoryId = entity.CategoryId;

                //context.items.Update(item);
                context.SaveChanges();

            }



            return item;
        }
    }
}
