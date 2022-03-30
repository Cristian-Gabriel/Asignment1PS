using BusinessLayer.Contracts;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository showRepository;
        private readonly IShowMapper showMapper;

        public ShowService(IShowRepository showRepository, IShowMapper showMapper)
        {
            this.showRepository = showRepository;
            this.showMapper = showMapper;
        }

        public void ChangeShow(ShowEntity showEntity, int id)
        {
            showRepository.ChangeShow(showEntity, id);
        }

        public void DeleteShow(int id)
        {
            showRepository.RemoveShow(id);
        }

        public bool ExistShow(DateTime Date)
        {
            List<ShowEntity> shows = showRepository.GetAll();
            List<ShowModel> results = new List<ShowModel>();
            shows.ForEach(x => results.Add(showMapper.Map(x)));
            for(int i = 0; i < results.Count; i++)
            {
                if(results[i].Date == Date)
                    return true;
            }
            return false;
        }
        public List<ShowModel> GetShows()
        {
            List<ShowEntity> shows = showRepository.GetAll();
            List<ShowModel> results = new List<ShowModel>();
            shows.ForEach(x => results.Add(showMapper.Map(x)));
            return results;
        }
        public void PostShow(ShowModel showModel)
        {
            var show = showMapper.Map(showModel);
            showRepository.Add(show);
        }
    }
}
