using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#if DNX451
using System.Data.SqlClient;

namespace WarehouseMonitor.Models
{
    public class DataRepository
        : IDisposable
    {
        #region Fields

        private string connectionString;      

        #endregion

        #region Constructor

        public DataRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion        

        public List<Shipment> GetSEPast()
        {
            List<Shipment> list = new List<Shipment>();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {   
                    connection.Open();
                    SqlCommand com = new SqlCommand("EXECUTE[dbo].[WarehouseMonitor_SE_Past]", connection);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        Shipment item = new Shipment();
                        int ordinal = reader.GetOrdinal("Date");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Date = reader.GetDateTime(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Shipments");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Shipments = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Weight = reader.GetInt32(ordinal);
                        }

                        list.Add(item);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;
        }

        public IEnumerable<ShipmentsOutput> GetSAPast()
        {
            List<ShipmentsOutput> list = new List<ShipmentsOutput>();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("EXECUTE[dbo].[WarehouseMonitor_SA_Past]", connection);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        ShipmentsOutput item = new ShipmentsOutput();
                        int ordinal = reader.GetOrdinal("Date");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Date = reader.GetDateTime(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Shipments");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Shipments = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Weight = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Category_Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.CategoryWeight = reader.GetString(ordinal);
                        }
                        //////////////////////////////////////////////
                        ordinal = reader.GetOrdinal("Department");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                                                       
                            item.Department = reader.GetString(ordinal);
                                
                        }




                        //////////////////////////////////////////////


                        list.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;
        }

        internal IEnumerable<Shipment> GetDeliveryPast()
        {
            List<Shipment> list = new List<Shipment>();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("EXECUTE[dbo].[WarehouseMonitor_Delivery_Past]", connection);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        Shipment item = new Shipment();
                        int ordinal = reader.GetOrdinal("Date");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Date = reader.GetDateTime(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Shipments");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Shipments = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Weight = reader.GetInt32(ordinal);
                        }

                        list.Add(item);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;
        }

        public IEnumerable<ShipmentsOutput> GetSAToday()
        {
            List<ShipmentsOutput> list = new List<ShipmentsOutput>();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("EXECUTE[dbo].[WarehouseMonitor_SA_Today]", connection);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        ShipmentsOutput item = new ShipmentsOutput();
                        int ordinal = reader.GetOrdinal("Date");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Date = reader.GetDateTime(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Shipments");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Shipments = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Weight = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Category_Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.CategoryWeight = reader.GetString(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Department");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {

                            item.Department = reader.GetString(ordinal);

                        }

                        list.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;
        }

        internal IEnumerable<Shipment> GetDeliveryToday()
        {
            List<Shipment> list = new List<Shipment>();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("EXECUTE[dbo].[WarehouseMonitor_Delivery_Today]", connection);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        Shipment item = new Shipment();
                        int ordinal = reader.GetOrdinal("Date");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Date = reader.GetDateTime(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Shipments");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Shipments = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Weight = reader.GetInt32(ordinal);
                        }

                        list.Add(item);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;
        }

        public IEnumerable<Shipment> GetSEToday()
        {
            List<Shipment> list = new List<Shipment>();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("EXECUTE[dbo].[WarehouseMonitor_SE_Today]", connection);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        Shipment item = new Shipment();
                        int ordinal = reader.GetOrdinal("Date");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Date = reader.GetDateTime(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Shipments");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Shipments = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Weight = reader.GetInt32(ordinal);
                        }

                        list.Add(item);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;
        }

        public IEnumerable<Shipment> GetPickupPast()
        {     
            List<Shipment> list = new List<Shipment>();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("EXECUTE[dbo].[WarehouseMonitor_Pickup_Past]", connection);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        Shipment item = new Shipment();
                        int ordinal = reader.GetOrdinal("Date");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Date = reader.GetDateTime(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Shipments");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Shipments = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Weight = reader.GetInt32(ordinal);
                        }

                        list.Add(item);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;
        }

        public IEnumerable<Shipment> GetPickupToday()
        {
            List<Shipment> list = new List<Shipment>();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("EXECUTE[dbo].[WarehouseMonitor_Pickup_Today]", connection);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        Shipment item = new Shipment();
                        int ordinal = reader.GetOrdinal("Date");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Date = reader.GetDateTime(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Shipments");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Shipments = reader.GetInt32(ordinal);
                        }

                        ordinal = reader.GetOrdinal("Weight");
                        if (reader.GetValue(ordinal) != DBNull.Value)
                        {
                            item.Weight = reader.GetInt32(ordinal);
                        }

                        list.Add(item);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;   
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
        }
    }
}
#endif
