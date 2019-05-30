using OtoKiralama.Commons.Concretes.Data;
using OtoKiralama.Commons.Concretes.Helpers;
using OtoKiralama.Commons.Concretes.Loggers;
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
    public class RezervasyonRepository : IRepository<Rezervasyon>,IDisposable
    {
        private string _connectionString;
        private SqlConnection con;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;
        public RezervasyonRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            con = new SqlConnection("Data Source =.; Initial Catalog = AracKiralama; Integrated Security = True");
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }
        public bool DeletedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;
            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[Rezervasyon] ");
                query.Append("WHERE ");
                query.Append("[KiralikId] = @id ");
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Rezervasyon.RezervasyonViewModel entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;



            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("insert into Rezervasyon(AracId,MusteriAdSoyad,EhliyetYasi,Email,Alis_Tarihi,Veris_Tarihi,VerilisKm,AlinanUcret,Iade,KabulDurumu) values(@AracId,@MusteriAdSoyad,@EhliyetYasi,@Email,@Alis_Tarihi,@Veris_Tarihi,@VerilisKm,@AlinanUcret,@Iade,@KabulDurumu)", con);
            cmd.Parameters.AddWithValue("@AracId", entity.AracId);
            cmd.Parameters.AddWithValue("@MusteriAdSoyad", entity.MusteriAdSoyad);
            cmd.Parameters.AddWithValue("@EhliyetYasi", entity.EhliyetYasi);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Alis_Tarihi", entity.Alis_Tarihi);
            cmd.Parameters.AddWithValue("@Veris_Tarihi", entity.Veris_Tarihi);
            cmd.Parameters.AddWithValue("@VerilisKm", entity.VerilisKm);
            cmd.Parameters.AddWithValue("@AlinanUcret", entity.AlinanUcret);
            cmd.Parameters.AddWithValue("@Iade", entity.Iade);
            cmd.Parameters.AddWithValue("@KabulDurumu", entity.KabulDurumu);

            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            int s = cmd.ExecuteNonQuery();


            return true;

        }

        public bool Insert(Rezervasyon entity)
        {
            throw new NotImplementedException();
        }

        public IList<Rezervasyon.RezervasyonViewModel> SelectAll(int sirketId,bool kabul)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Rezervasyon.RezervasyonViewModel> rezerv = new List<Rezervasyon.RezervasyonViewModel>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("R.[KiralikId],R.[AracId],R.[MusteriAdSoyad],R.[Email],R.[EhliyetYasi],A.[AracAdi],A.[Model],R.[Alis_Tarihi],R.[Veris_Tarihi],R.[VerilisKm],R.[AlinanUcret],R.[Iade],R.[KabulDurumu] ");
                query.Append("FROM [dbo].[Rezervasyon] R ");
                query.Append("inner join [dbo].[Arac] A ");
                query.Append("ON R.[AracID]=A.[AracId] ");
                query.Append("inner join [dbo].[Sirket] S ");
                query.Append("ON A.[SirketId]=S.[SirketId] ");
         
                query.Append("Where S.SirketId=@SirketId and R.KabulDurumu=@KabulDurumu ");
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

                        //Input Parameters - None
                        DBHelper.AddParameter(dbCommand, "@SirketId", CsType.Int, ParameterDirection.Input, sirketId);
                        DBHelper.AddParameter(dbCommand, "@KabulDurumu", CsType.Int, ParameterDirection.Input, kabul);

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
                                    var entity = new Rezervasyon.RezervasyonViewModel();
                                    entity.KiralikId = reader.GetInt32(0);
                                    entity.AracId = reader.GetInt32(1);
                                    entity.MusteriAdSoyad = reader.GetString(2);
                                    entity.Email = reader.GetString(3);
                                    entity.EhliyetYasi = reader.GetInt32(4);
                                    entity.AracAdi = reader.GetString(5);
                                    entity.Model = reader.GetString(6);
                                    
                                    entity.Alis_Tarihi = reader.GetDateTime(7);
                                    entity.Veris_Tarihi = reader.GetDateTime(8);
                                    entity.VerilisKm = reader.GetInt32(9);
                                    entity.AlinanUcret = reader.GetDecimal(10);
                                    entity.Iade = reader.GetBoolean(11);
                                    entity.KabulDurumu = reader.GetBoolean(12);

                                    rezerv.Add(entity);
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
                return rezerv;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
            // Return list



        }

        public Rezervasyon.RezervasyonViewModel SelectedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Rezervasyon.RezervasyonViewModel rezerv = new Rezervasyon.RezervasyonViewModel();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("A.[AracAdi],A.[Model], M.[Adi],M.[Soyadi],R.[Alis_Tarihi],R.[Veris_Tarihi],R.[VerilisKm],R.[AlinanUcret],R.[Iade],R.[KabulDurumu] ");
                query.Append("FROM [dbo].[Rezervasyon] R ");
                query.Append("inner join [dbo].[Arac] A ");
                query.Append("ON R.[AracID]=A.[AracId] ");
                query.Append("inner join [dbo].[Musteri] M ");
                query.Append("ON R.[MusteriId]=M.[MusteriId] ");
                query.Append("where R.MusteriId=@MusteriId");
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

                        //Input Parameters - None
                        DBHelper.AddParameter(dbCommand, "@MusteriId", CsType.String, ParameterDirection.Input,id);

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
                                    var entity = new Rezervasyon.RezervasyonViewModel();
                                    entity.AracAdi = reader.GetString(0);
                                    entity.Model = reader.GetString(1);
                                  
                                    entity.Alis_Tarihi = reader.GetDateTime(4);
                                    entity.Veris_Tarihi = reader.GetDateTime(5);
                                    entity.VerilisKm = reader.GetInt32(6);
                                    entity.AlinanUcret = reader.GetDecimal(7);
                                    entity.Iade = reader.GetBoolean(8);
                                    entity.KabulDurumu = reader.GetBoolean(9);

                                    rezerv=entity;
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
                return rezerv;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
            // Return list
        }
        public Rezervasyon.RezervasyonViewModel SelectedByİd(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Rezervasyon.RezervasyonViewModel rezerv = new Rezervasyon.RezervasyonViewModel();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("R.[KiralikId],A.[AracAdi],A.[Model], M.[Adi],M.[Soyadi],R.[Alis_Tarihi],R.[Veris_Tarihi],R.[VerilisKm],R.[AlinanUcret],R.[Iade],R.[KabulDurumu] ");
                query.Append("FROM [dbo].[Rezervasyon] R ");
                query.Append("inner join [dbo].[Arac] A ");
                query.Append("ON R.[AracID]=A.[AracId] ");
                query.Append("inner join [dbo].[Musteri] M ");
                query.Append("ON R.[MusteriId]=M.[MusteriId] ");
                query.Append("where R.MusteriId=@MusteriId");
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

                        //Input Parameters - None
                        DBHelper.AddParameter(dbCommand, "@MusteriId", CsType.String, ParameterDirection.Input, id);

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
                                    var entity = new Rezervasyon.RezervasyonViewModel();
                                    entity.AracAdi = reader.GetString(0);
                                    entity.Model = reader.GetString(1);
                                 
                                    entity.Alis_Tarihi = reader.GetDateTime(4);
                                    entity.Veris_Tarihi = reader.GetDateTime(5);
                                    entity.VerilisKm = reader.GetInt32(6);
                                    entity.AlinanUcret = reader.GetDecimal(7);
                                    entity.Iade = reader.GetBoolean(8);
                                    entity.KabulDurumu = reader.GetBoolean(9);

                                    rezerv = entity;
                                }
                            }

                        }

                        
                    }
                }
                return rezerv;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
        }
        public int OrtalamaKiralananArac()
        {
            _rowsAffected = 0;
            _errorCode = 0;
            int kiralanan = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("exec ortalamaGünlükKiralanan");
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
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    kiralanan = reader.GetInt32(0);

                                }

                            }


                        }
                       
                    }
                }

                return kiralanan;

            }

            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
        }
        public decimal Kazanç()
        {
            _rowsAffected = 0;
            _errorCode = 0;
            decimal kazanc = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("exec Kazanç ");
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
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    kazanc = reader.GetDecimal(0);

                                }

                            }


                        }
                      
                    }
                }

                return kazanc;

            }

            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
        }

        public int günlükKm()
        {
            _rowsAffected = 0;
            _errorCode = 0;
            int günlükKm1 = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("exec günlükKm");
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
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    günlükKm1 = reader.GetInt32(0);

                                }

                            }


                        }
                       
                    }
                }

                        return günlükKm1;

                    }

            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
        }
            public bool Update(Rezervasyon entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[Rezervasyon] ");
                query.Append(" SET [KabulDurumu] = @KabulDurumu,[Iade]=@Iade");
                query.Append(" WHERE ");
                query.Append(" [KiralikId] = @KiralikId ");
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

                        DBHelper.AddParameter(dbCommand, "@KiralikId", CsType.String, ParameterDirection.Input, entity.KiralikId);
                        DBHelper.AddParameter(dbCommand, "@Iade", CsType.String, ParameterDirection.Input, entity.Iade);
                        DBHelper.AddParameter(dbCommand, "@KabulDurumu", CsType.String, ParameterDirection.Input, entity.KabulDurumu);


                    
                       
  
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

        IList<Rezervasyon> IRepository<Rezervasyon>.SelectAll()
        {
            throw new NotImplementedException();
        }

        Rezervasyon IRepository<Rezervasyon>.SelectedById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
