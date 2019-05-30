using OtoKiralama.Commons.Concretes.Helpers;
using OtoKiralama.Commons.Concretes.Loggers;
using OtoKiralama.DataAccess.Concretes;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoKiralama.BusinesLogic
{
    public class RezervasyonBusiness:IDisposable
    {
        private bool _bDisposed;
        public bool InsertRezerv(Rezervasyon.RezervasyonViewModel entity)
        {
                bool isSuccess;
                var repo = new RezervasyonRepository();
                
                    isSuccess = repo.Insert(entity);
               
                return isSuccess;
           
           
        }
        public bool UpdateCar(Rezervasyon entity)
        {
            
                bool isSuccess;
            var repo = new RezervasyonRepository();
                
                    isSuccess = repo.Update(entity);
                
                return isSuccess;
            
          
        }

        public List<Rezervasyon.RezervasyonViewModel> SelectAllCar(int sirketId,bool kabul)
        {
            var responseEntities = new List<Rezervasyon.RezervasyonViewModel>();
            var repo = new RezervasyonRepository();


               
                    foreach (var entity in repo.SelectAll(sirketId,kabul))
                    {
                        responseEntities.Add(entity);
                    }
             return responseEntities;

        }
        public int günlükKm()
        {
            var rezervasyonRepository = new RezervasyonRepository();
            int günlükKm = rezervasyonRepository.günlükKm();
            return günlükKm;
        }
        public decimal Kazanc()
        {
            var rezervasyonRepository = new RezervasyonRepository();
            decimal kazanc = rezervasyonRepository.Kazanç();
            return kazanc;
        }
        public int kiralanan()
        {
            var rezervasyonRepository = new RezervasyonRepository();
            int kiralanan = rezervasyonRepository.OrtalamaKiralananArac();
            return kiralanan;
        }
        public bool DeleteCarById(int ID)
        {
            
                bool isSuccess;
            var repo = new RezervasyonRepository();
             
                    isSuccess = repo.DeletedById(ID);
             
                return isSuccess;
            
           
        }
        public Arac SelectCarById(int customerId)
        {
            try
            {
                Arac responseEntitiy;
                using (var repo = new AracRepository())
                {
                    responseEntitiy = repo.SelectedById(customerId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Customer doesnt exists!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:CustomerBusiness::SelectCustomerById::Error occured.", ex);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
