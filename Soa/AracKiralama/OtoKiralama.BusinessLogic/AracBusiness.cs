using System;
using System.Collections.Generic;
using System.Text;
using OtoKiralama.


namespace OtoKiralama.BusinessLogic
{
    public class AracBusiness
    {
        public bool InsertCar(Arac entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new CustomersRepository())
                {
                    isSuccess = repo.Insert(entity);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:CustomerBusiness::InsertCustomer::Error occured.", ex);
            }
        }
    }
}
