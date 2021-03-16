using Microsoft.AspNetCore.JsonPatch;
using SecondLife.Model.Entities;
using SecondLife.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SecondLife.Services.Services
{
    public class AnnonceService : IAnnonceService
    {
        private IAnnonceRepository _repo;

        public AnnonceService(IAnnonceRepository repo)
        {
            _repo = repo;
        }

        public List<Annonce> List(Expression<Func<Annonce, bool>> condition)
        {
            return _repo.All(condition);
        }

        public Annonce Get(int id)
        {
            return _repo.Get(id);
        }

        public Annonce Add(Annonce annonce)
        {
            if (String.IsNullOrEmpty(annonce.Title))
            {
                return null;
            }

            if (_repo.Exists(annonce))
            {
                return null;
            }

            return _repo.Add(annonce);
        }

        public Annonce Patch(int id, JsonPatchDocument<Annonce> document)
        {
            var updatedObject = Get(id);
            document.ApplyTo(updatedObject);
            _repo.Update(updatedObject);
            return updatedObject;
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public Annonce Get(in int id)
        {
            return _repo.Get(id);
        }
    }
}
