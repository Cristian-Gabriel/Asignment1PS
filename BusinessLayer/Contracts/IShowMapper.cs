using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IShowMapper
    {
        public ShowModel Map(ShowEntity showEntity);
        public ShowEntity Map(ShowModel showModel);
    }
}
