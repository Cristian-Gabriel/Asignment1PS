using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IShowService
    {
        List<ShowModel> GetShows();
        bool ExistShow(DateTime Date);
        void PostShow(ShowModel showModel);
        void DeleteShow(int id);
        void ChangeShow(ShowEntity showEntity, int id);
    }
}
