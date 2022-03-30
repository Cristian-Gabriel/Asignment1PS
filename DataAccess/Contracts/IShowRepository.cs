using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IShowRepository
    {
        List<ShowEntity> GetAll();
        void Add(ShowEntity show);
        void RemoveShow(int id);
        void ChangeShow(ShowEntity showEntity, int id);
    }
}
