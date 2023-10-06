using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecu_DemoFormulaire.Repository
{
    public interface ICreateRepository<TEntity, TId> where TEntity : class where TId : struct
    {
        void Create(TEntity entity);
    }
}
