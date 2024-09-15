using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Data.Providers.Concretes
{
    public class ImageProvider : IImageProvider<Image>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Image>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Image entity)
        {
            throw new NotImplementedException();
        }



        Task<DBActionResult<Image>> Providers.IGenericProvider<Image>.Insert(Image entity)
        {
            throw new NotImplementedException();
        }

        Task<DBActionResult<Image>> IGenericProvider<Image>.Update(int id, Image entity)
        {
            throw new NotImplementedException();
        }
    }
}