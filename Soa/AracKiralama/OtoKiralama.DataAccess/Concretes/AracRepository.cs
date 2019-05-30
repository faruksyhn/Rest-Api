using OtoKiralama.DataAccess.Abstractions;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using OtoKiralama.DataAccess.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtoKiralama.Commons.Concretes.Helpers;
using OtoKiralama.Commons.Concretes.Data;
using OtoKiralama.Commons.Concretes.Loggers ;
using OtoKiralama.DataAccess.Concretes;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Sql;



namespace OtoKiralama.DataAccess.Concretes
{
    public class AracRepository : IRepository<Arac>,IDisposable
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private SqlConnection con;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public AracRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            con = new SqlConnection("Data Source =.; Initial Catalog = AracKiralama; Integrated Security = True");
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }
        public IList<Arac> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Arac> customers = new List<Arac>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[AracAdi], [Model], [EhliyetYasi], [MinYasSiniri], [GunlukSinirKM], [KendiAnlıkKM], [Airbag], [BagajHacmi], [GunlukKiralikFiyat],[dbo].[Sirket].[SirketAdi],[Resim],[KoltukSayisi],[AracId],[RezerveDurumu] ");
                query.Append("FROM [dbo].[Arac] ");
                query.Append("inner join [dbo].[Sirket] ");
                query.Append("ON [dbo].[Arac].[SirketId]=[dbo].[Sirket].[SirketId] ");
                query.Append("WHERE [dbo].[Arac].[RezerveDurumu]=0 ");
                query.Append(" SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [tbl_Customers] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters - None

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int,
                            ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Arac();
                                    entity.AracAdi = reader.GetString(0);
                                    entity.Model = reader.GetString(1);
                                    entity.EhliyetYasi = reader.GetInt32(2);
                                    entity.MinYasSiniri = reader.GetInt32(3);
                                    entity.GunlukSinirKM = reader.GetInt32(4);
                                    entity.KendiAnlikKM = reader.GetInt32(5);
                                    entity.Airbag = reader.GetBoolean(6);
                                    entity.BagajHacmi = reader.GetInt32(7);
                                    entity.GunlukKiralikFiyat = reader.GetDecimal(8);
                                    entity.SirketAdi = reader.GetString(9);
                                    entity.Resim = reader.GetString(10);
                                    entity.KoltukSayisi = reader.GetInt32(11);
                                    entity.AracId = reader.GetInt32(12);
                                    entity.RezerveDurumu = reader.GetBoolean(13);
                                    customers.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Arac] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                return customers;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
            // Return list
          




            }

        public bool DeletedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;
            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[Arac] ");
                query.Append("WHERE ");
                query.Append("[AracId] = @id ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [Arac] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception(
                                "Deleting Error for entity [Arac] reported the Database ErrorCode: " +
                                _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AracRepository::Insert:Error occured.", ex);
            }
        }

        public bool Insert(Arac entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

              

                SqlCommand cmd = new SqlCommand();
               
                cmd = new SqlCommand("insert into Arac(AracAdi,Model,EhliyetYasi,MinYasSiniri,GunlukSinirKM,KendiAnlıkKM,Airbag,BagajHacmi,KoltukSayisi,GunlukKiralikFiyat,SirketId) values(@AracAdi,@Model,@EhliyetYasi,@MinYasSiniri,@GunlukSinirKM,@KendiAnlikKM,@Airbag,@BagajHacmi,@KoltukSayisi,@GunlukKiralikFiyat,@SirketId)", con);
                cmd.Parameters.AddWithValue("@AracAdi", entity.AracAdi);
                cmd.Parameters.AddWithValue("@Model", entity.Model);
                cmd.Parameters.AddWithValue("@EhliyetYasi", entity.EhliyetYasi);
                cmd.Parameters.AddWithValue("@MinYasSiniri", entity.MinYasSiniri);
                cmd.Parameters.AddWithValue("@GunlukSinirKM", entity.GunlukSinirKM);
                cmd.Parameters.AddWithValue("@KendiAnlikKM", entity.KendiAnlikKM);
                cmd.Parameters.AddWithValue("@Airbag", entity.Airbag.ToString());
                cmd.Parameters.AddWithValue("@BagajHacmi", entity.BagajHacmi);
                cmd.Parameters.AddWithValue("@KoltukSayisi", entity.KoltukSayisi);
                cmd.Parameters.AddWithValue("@GunlukKiralikFiyat", entity.GunlukKiralikFiyat);
                cmd.Parameters.AddWithValue("@SirketId", entity.SirketId);
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                int s= cmd.ExecuteNonQuery();
                

                return true;


                //Return the results of query/ies
                
           
           
        }

        
        public Arac SelectedById(int id)
            {

            _errorCode = 0;
            _rowsAffected = 0;

            Arac arac = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[AracAdi], [Model], [EhliyetYasi], [MinYasSiniri], [GunlukSinirKM], [KendiAnlıkKM], [Airbag], [BagajHacmi], [GunlukKiralikFiyat],[dbo].[Sirket].[SirketAdi],[Resim],[KoltukSayisi],[AracId] ");
                query.Append("FROM [dbo].[Arac] ");
                query.Append("inner join [dbo].[Sirket] ");
                query.Append("ON [dbo].[Arac].[SirketId]=[dbo].[Sirket].[SirketId] ");
                query.Append("Where [dbo].[Arac].[AracId]=@AracId ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [tbl_Customers] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@AracId", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Arac();
                                    entity.AracAdi = reader.GetString(0);
                                    entity.Model = reader.GetString(1);
                                    entity.EhliyetYasi = reader.GetInt32(2);
                                    entity.MinYasSiniri = reader.GetInt32(3);
                                    entity.GunlukSinirKM = reader.GetInt32(4);
                                    entity.KendiAnlikKM = reader.GetInt32(5);
                                    entity.Airbag = reader.GetBoolean(6);
                                    entity.BagajHacmi = reader.GetInt32(7);
                                    entity.GunlukKiralikFiyat = reader.GetDecimal(8);
                                    entity.SirketAdi = reader.GetString(9);
                                    entity.Resim = reader.GetString(10);
                                    entity.KoltukSayisi = reader.GetInt32(11);
                                    entity.AracId = reader.GetInt32(12);

                                    arac = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [tbl_Customer] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

              
                return arac;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectById:Error occured.", ex);
            }
        }

            public bool Update(Arac entity)
            {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[Arac] ");
                query.Append(" SET  RezerveDurumu= @RezerveDurumu ");
                query.Append(" WHERE ");
                query.Append(" [AracId] = @AracId ");
                query.Append(" SELECT @intErrorCode = @@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tbl_Customers] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                      
                        DBHelper.AddParameter(dbCommand, "@AracId", CsType.String, ParameterDirection.Input, entity.AracId);
                        DBHelper.AddParameter(dbCommand, "@RezerveDurumu", CsType.String, ParameterDirection.Input, entity.RezerveDurumu);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [tbl_Customer] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::Update:Error occured.", ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool bDisposing)
        {
            // Check the Dispose method called before.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Clean the resources used.
                    _dbProviderFactory = null;
                }

                _bDisposed = true;
            }
        }
    }

}
      


    
