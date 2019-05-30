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
    public class SirketRepository : IRepository<Sirket>, IDisposable
    {
        private string _connectionString;
        private SqlConnection con;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public SirketRepository()
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
                query.Append("FROM [dbo].[Sirket] ");
                query.Append("WHERE ");
                query.Append("[SirketId] = @id ");
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
                                "Deleting Error for entity [Sirket] reported the Database ErrorCode: " +
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

        public bool Insert(Sirket entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;



            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("insert into Sirket(SirketAdi,Sehir,Adres,AracSayisi,SirketPuani) values(@SirketAdi,@Sehir,@Adres,@AracSayisi,@SirketPuani)", con);
            cmd.Parameters.AddWithValue("@SirketAdi", entity.SirketAdi);
            cmd.Parameters.AddWithValue("@Sehir", entity.Sehir);
            cmd.Parameters.AddWithValue("@Adres", entity.Adres);
            cmd.Parameters.AddWithValue("@AracSayisi", entity.AracSayisi);
            cmd.Parameters.AddWithValue("@SirketPuani", entity.SirketPuani);
  
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            int s = cmd.ExecuteNonQuery();


            return true;


        }

        public IList<Sirket> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Sirket> sirket = new List<Sirket>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[SirketAdi], [Sehir], [Adres], [AracSayisi], [SirketPuani] ");
                query.Append("FROM [dbo].[Sirket] ");
              
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
                                    var entity = new Sirket();
                                    entity.SirketAdi = reader.GetString(0);
                                    entity.Sehir = reader.GetString(1);
                                    entity.Adres = reader.GetString(2);
                                    entity.AracSayisi = reader.GetInt32(3);
                                    entity.SirketPuani = reader.GetInt32(4);
                                    

                                    sirket.Add(entity);
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
                return sirket;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
            // Return list


        }

        public Sirket SelectedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Sirket sirket = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[SirketAdi], [Sehir], [Adres], [AracSayisi], [SirketPuani] ");
                query.Append("FROM [dbo].[Sirket] ");

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
                                    var entity = new Sirket();
                                 
                                    entity.SirketAdi = reader.GetString(0);
                                    entity.Sehir = reader.GetString(1);
                                    entity.Adres = reader.GetString(2);
                                    entity.AracSayisi = reader.GetInt32(3);
                                    entity.SirketPuani = reader.GetInt32(4);


                                    sirket = entity ;


                                    
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


                return sirket;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomersRepository::SelectById:Error occured.", ex);
            }
        }

        public bool Update(Sirket entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[Sirket] ");
                query.Append(" SET [SirketAdi] = @SirketAdi, [Sehir] = @Sehir, [Adres] =  @Adres, [AracSayisi] = @AracSayisi, [SirketPuani] = @SirketPuani ");
                query.Append(" WHERE ");
                query.Append(" [SirketId] = @SirketId ");
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

                        DBHelper.AddParameter(dbCommand, "@SirketAdi", CsType.String, ParameterDirection.Input, entity.SirketAdi);

                        DBHelper.AddParameter(dbCommand, "@Sehir", CsType.String, ParameterDirection.Input, entity.Sehir);
                        DBHelper.AddParameter(dbCommand, "@Adres", CsType.String, ParameterDirection.Input, entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@AracSayisi", CsType.String, ParameterDirection.Input, entity.AracSayisi);
                        DBHelper.AddParameter(dbCommand, "@SirketPuani", CsType.Decimal, ParameterDirection.Input, entity.SirketPuani);
       
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
    }
}
