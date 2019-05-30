using OtoKiralama.Commons.Concretes.Data;
using OtoKiralama.Commons.Concretes.Helpers;
using OtoKiralama.DataAccess.Abstractions;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoKiralama.DataAccess.Concretes
{
    public class KullaniciRepository : IRepository<Kullanici>, IDisposable
    {
        private string _connectionString;
        private SqlConnection con;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;
        public KullaniciRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
            con = new SqlConnection("Data Source =.; Initial Catalog = AracKiralama; Integrated Security = True");

        }
        public bool DeletedById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Kullanici entity)
        {
            throw new NotImplementedException();
        }
        public Kullanici kullaniciKontrol(Kullanici entity)
        {
            _errorCode = 0;
            _rowsAffected = 0;
            bool success;
            Kullanici kullanici = null;

            SqlCommand cmd = new SqlCommand("Select * FROM Kullanici K Where K.Email=@Email and K.Sifre=@Sifre ", con);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Sifre", entity.Sifre);
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var entity1 = new Kullanici();
                        entity1.SirketId = reader.GetInt32(0);
                        entity1.RolId = reader.GetInt32(6);
                        kullanici = entity1;
                    }

                }
            }

            return kullanici;
        }
                public IList<Kullanici> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Kullanici SelectedById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Kullanici entity)
        {
            throw new NotImplementedException();
        }
    }
}
