using OtoKiralama.DataAccess.Concretes;
using OtoKiralama.Models;
using System;
using OtoKiralama.Commons.Concretes.Helpers;
using OtoKiralama.Commons.Concretes.Loggers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OtoKiralama.BusinesLogic
{
    public class AracBusiness:IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool InsertCar(Arac entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new AracRepository())
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
        public bool UpdateCar(Arac entity)
        {
           
                bool isSuccess;
            var repo = new AracRepository();
                
                    isSuccess = repo.Update(entity);
                
                return isSuccess;
          
        }

        public List<Arac> SelectAllCar()
            {
                var responseEntities = new List<Arac>();


            var repo = new AracRepository();
                    
                        foreach (var entity in repo.SelectAll())
                        {
                            responseEntities.Add(entity);
                        }
                   
                    return responseEntities;
               
            }
        public bool DeleteCarById(int ID)
        {
            try
            {
                bool isSuccess;
                using (var repo = new AracRepository())
                {
                    isSuccess = repo.DeletedById(ID);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:CustomerBusiness::DeleteCustomer::Error occured.", ex);
            }
        }
        public Arac SelectCarById(int customerId)
        {
            var repo = new AracRepository();
           
             Arac responseEntitiy=new Arac(); 
                
                
                    responseEntitiy = repo.SelectedById(customerId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Customer doesnt exists!");
                
                return responseEntitiy;
            
           
        }

    }
    }

