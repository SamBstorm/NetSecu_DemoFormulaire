using NetSecu_DemoFormulaire.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecu_DemoFormulaire.Repository
{
    public interface ICRUDRepository<TEntity, TId> : 
        IGetRepository<TEntity, TId>,
        IGetAllRepository<TEntity, TId>,
        ICreateRepository<TEntity, TId>,
        IUpdateRepository<TEntity, TId>,
        IDeleteRepository<TEntity, TId>
        where TEntity : class 
        where TId : struct
    {
    }
}
