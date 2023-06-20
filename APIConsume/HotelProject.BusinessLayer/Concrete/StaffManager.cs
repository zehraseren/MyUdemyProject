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
    public class StaffManager : IStaffService
    {
        private readonly IStaffDAL _staffDAL;

        public StaffManager(IStaffDAL staffDAL)
        {
            _staffDAL = staffDAL;
        }

        public void TDelete(Staff t)
        {
            _staffDAL.Delete(t);
        }

        public Staff TGetByID(int id)
        {
            return _staffDAL.GetByID(id);
        }

        public List<Staff> TGetList()
        {
            return _staffDAL.GetList();
        }

        public void TInsert(Staff t)
        {
            _staffDAL.Insert(t);
        }

        public void TUpdate(Staff t)
        {
            _staffDAL.Update(t);
        }
    }
}
