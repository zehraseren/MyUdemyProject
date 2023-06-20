using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDAL _subscribeDAL;

        public SubscribeManager(ISubscribeDAL subscribeDAL)
        {
            _subscribeDAL = subscribeDAL;
        }

        public void TDelete(Subscribe t)
        {
            _subscribeDAL.Delete(t);
        }

        public Subscribe TGetByID(int id)
        {
            return _subscribeDAL.GetByID(id);
        }

        public List<Subscribe> TGetList()
        {
            return _subscribeDAL.GetList();
        }

        public void TInsert(Subscribe t)
        {
            _subscribeDAL.Insert(t);
        }

        public void TUpdate(Subscribe t)
        {
            _subscribeDAL.Update(t);
        }
    }
}
