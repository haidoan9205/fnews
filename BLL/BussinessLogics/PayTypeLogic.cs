using BLL.Interfaces;
using BLL.Models.PayTypeModel;
using DAL.Entities;
using DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BussinessLogics
{
    public class PayTypeLogic : IPayTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public PayTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateNewPayType(PayTypeCreateModel payTypeCreateModel)
        {
            bool check = false;
            if(payTypeCreateModel != null)
            {
                PayType payType = new PayType
                {
                    PayTypeId = Guid.NewGuid(),
                    PayTypeName = payTypeCreateModel.PayTypeName,
                    CreatedDate = DateTime.Now,
                    Status = true
                };
                _unitOfWork.GetRepository<PayType>().Insert(payType);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public bool DeletePayType(Guid id)
        {
            bool check = false;
            PayType payType = _unitOfWork.GetRepository<PayType>().FindById(id);
            if(payType != null)
            {
                payType.Status = false;
                _unitOfWork.GetRepository<PayType>().Update(payType);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public IQueryable<PayType> GetAllPayType()
        {
            return _unitOfWork.GetRepository<PayType>().GetAll();
        }

        public PayType GetPayTypeById(Guid id)
        {
            PayType payType = _unitOfWork.GetRepository<PayType>().FindById(id);
            return payType;
        }

        public bool UpdatePayType(PayTypeUpdateMode payTypeUpdateMode)
        {
            bool check = false;
            if(payTypeUpdateMode != null)
            {
                PayType payType = _unitOfWork.GetRepository<PayType>().FindById(payTypeUpdateMode.id);
                if(payType != null)
                {
                    payType.PayTypeName = payTypeUpdateMode.PayTypeName;
                    _unitOfWork.GetRepository<PayType>().Update(payType);
                    _unitOfWork.Commit();
                    check = true;
                }
            }
            return check;
            
        }
    }
}
