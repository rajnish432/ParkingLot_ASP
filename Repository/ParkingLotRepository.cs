// <copyright file="ParkingLotRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationRepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using ApplicationModelLayer;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Parking Lot Repository.
    /// </summary>
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;

        public ParkingLotRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetSection("ConnectionStrings").GetSection("ParkingLotDBConnection").Value;
            this.connection = new SqlConnection(this.connectionString);
        }

        /// <summary>
        /// To Add vehicle to Parking.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        public ParkingDetails AddVehicleToParking(Parking parking)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spPark", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VehicleNumber", parking.VehicleNumber);
                    cmd.Parameters.AddWithValue("@ParkingType", parking.ParkingType);
                    cmd.Parameters.AddWithValue("@DriverType", parking.DriverType);
                    cmd.Parameters.AddWithValue("@VehicleType", parking.VehicleType);

                    this.connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return this.GetParkingDetails(parking.VehicleNumber);
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public ParkingDetails UnParkVehicle(int slotNumber)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spUnpark", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SlotNumber", slotNumber);
                    this.connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return this.GetParkingDetailsWithSlotNumber(slotNumber);
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public ParkingDetails GetParkingDetails(string vehicleNumber)
        {
            try
            {
                ParkingDetails parkingDetails = new ParkingDetails();
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spSearchVehicleNumber", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VehicleNumber", vehicleNumber);
                    this.connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            parkingDetails.ParkingId = Convert.ToInt32(dataReader["PARKING_ID"]);
                            parkingDetails.VehicleNumber = dataReader["VEHICLE_NUMBER"].ToString();
                            parkingDetails.EntryTime = dataReader["ENTRY_TIME"].ToString();
                            parkingDetails.ParkingType = Convert.ToInt32(dataReader["PARKING_TYPE"]);
                            parkingDetails.DriverType = Convert.ToInt32(dataReader["DRIVER_TYPE"]);
                            parkingDetails.VehicleType = Convert.ToInt32(dataReader["VEHICLE_TYPE"]);
                            parkingDetails.ExitTime = dataReader["EXIT_TIME"].ToString();
                            parkingDetails.SlotNumber = Convert.ToInt32(dataReader["SLOT_NUMBER"]);
                        }

                        this.connection.Close();
                        return parkingDetails;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public ParkingDetails GetParkingDetailsWithParkingID(int parkingID)
        {
            try
            {
                ParkingDetails parkingDetails = new ParkingDetails();
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spSearchParkingID", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ParkingId", parkingID);
                    this.connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            parkingDetails.ParkingId = Convert.ToInt32(dataReader["PARKING_ID"]);
                            parkingDetails.VehicleNumber = dataReader["VEHICLE_NUMBER"].ToString();
                            parkingDetails.EntryTime = dataReader["ENTRY_TIME"].ToString();
                            parkingDetails.ParkingType = Convert.ToInt32(dataReader["PARKING_TYPE"]);
                            parkingDetails.DriverType = Convert.ToInt32(dataReader["DRIVER_TYPE"]);
                            parkingDetails.VehicleType = Convert.ToInt32(dataReader["VEHICLE_TYPE"]);
                            parkingDetails.ExitTime = dataReader["EXIT_TIME"].ToString();
                            parkingDetails.SlotNumber = Convert.ToInt32(dataReader["SLOT_NUMBER"]);
                            parkingDetails.ParkingCharge = Convert.ToInt32(dataReader["CHARGE"]);
                        }

                        this.connection.Close();
                        return parkingDetails;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public ParkingDetails GetParkingDetailsWithSlotNumber(int slotNumber)
        {
            try
            {
                ParkingDetails parkingDetails = new ParkingDetails();
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spSearchSlotID", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SlotNumber", slotNumber);
                    this.connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            parkingDetails.ParkingId = Convert.ToInt32(dataReader["PARKING_ID"]);
                            parkingDetails.VehicleNumber = dataReader["VEHICLE_NUMBER"].ToString();
                            parkingDetails.EntryTime = dataReader["ENTRY_TIME"].ToString();
                            parkingDetails.ParkingType = Convert.ToInt32(dataReader["PARKING_TYPE"]);
                            parkingDetails.DriverType = Convert.ToInt32(dataReader["DRIVER_TYPE"]);
                            parkingDetails.VehicleType = Convert.ToInt32(dataReader["VEHICLE_TYPE"]);
                            parkingDetails.ExitTime = dataReader["EXIT_TIME"].ToString();
                            parkingDetails.SlotNumber = Convert.ToInt32(dataReader["SLOT_NUMBER"]);
                            parkingDetails.ParkingCharge = Convert.ToInt32(dataReader["CHARGE"]);
                        }

                        this.connection.Close();
                        return parkingDetails;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool DeleteParkingData(int parkingID)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteParkingData", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ParkingId", parkingID);

                    this.connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public List<ParkingDetails> GetAllVehiclesParkedData()
        {
            try
            {
                List<ParkingDetails> listParkingData = new List<ParkingDetails>();
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spGetAllParkingData", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ParkingDetails parkingDetails = new ParkingDetails();
                            parkingDetails.ParkingId = Convert.ToInt32(dataReader["PARKING_ID"]);
                            parkingDetails.VehicleNumber = dataReader["VEHICLE_NUMBER"].ToString();
                            parkingDetails.EntryTime = dataReader["ENTRY_TIME"].ToString();
                            parkingDetails.ParkingType = Convert.ToInt32(dataReader["PARKING_TYPE"]);
                            parkingDetails.DriverType = Convert.ToInt32(dataReader["DRIVER_TYPE"]);
                            parkingDetails.VehicleType = Convert.ToInt32(dataReader["VEHICLE_TYPE"]);
                            parkingDetails.ExitTime = dataReader["EXIT_TIME"].ToString();
                            parkingDetails.SlotNumber = Convert.ToInt32(dataReader["SLOT_NUMBER"]);
                            listParkingData.Add(parkingDetails);
                        }

                        this.connection.Close();
                        return listParkingData;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public List<ParkingDetails> GetAllEmptySlots()
        {
            try
            {
                List<ParkingDetails> listEmptySlots = new List<ParkingDetails>();
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spGetEmptySLots", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader datarReader = cmd.ExecuteReader();
                    if (datarReader.HasRows)
                    {
                        while (datarReader.Read())
                        {
                            ParkingDetails parkingDetails = new ParkingDetails();
                            parkingDetails.SlotNumber = Convert.ToInt32(datarReader["SLOT_NUMBER"]);
                            listEmptySlots.Add(parkingDetails);
                        }

                        this.connection.Close();
                        return listEmptySlots;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
