using BLL.Models.PayTypeModel;
using DAL.Entities;
using System;
using System.Linq;


namespace BLL.Interfaces
{
    public interface IPayTypeLogic
    {
        public IQueryable<PayType> GetAllPayType();

        public PayType GetPayTypeById(Guid id);

        public bool CreateNewPayType(PayTypeCreateModel payTypeCreateModel);

        public bool UpdatePayType(PayTypeUpdateMode payTypeUpdateMode);

        public bool DeletePayType(Guid id);
    }
}
