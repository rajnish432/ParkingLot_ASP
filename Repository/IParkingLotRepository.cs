// <copyright file="IParkingLotRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationRepositoryLayer
{
    using System.Collections.Generic;
    using ApplicationModelLayer;

    /// <summary>
    /// Interface for Parking Lot Repository.
    /// </summary>
    public interface IParkingLotRepository
    {
        /// <summary>
        /// Method to add vehicle to Parking.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        ParkingDetails AddVehicleToParking(Parking parking);

        /// <summary>
        /// Method to remove vehicle from Parking.
        /// </summary>
        /// <param name="slotNumber"></param>
        /// <returns></returns>
        ParkingDetails UnParkVehicle(int slotNumber);

        /// <summary>
        /// To find Vehicle using Vehicle Number.
        /// </summary>
        /// <param name="vehicleNumber"></param>
        /// <returns></returns>
        ParkingDetails GetParkingDetails(string vehicleNumber);

        /// <summary>
        /// To find Vehicle using Parking ID.
        /// </summary>
        /// <param name="parkingID"></param>
        /// <returns></returns>
        ParkingDetails GetParkingDetailsWithParkingID(int parkingID);

        /// <summary>
        /// To find Vehicle using Parking ID.
        /// </summary>
        /// <param name="slotNumber"></param>
        /// <returns></returns>
        ParkingDetails GetParkingDetailsWithSlotNumber(int slotNumber);

        /// <summary>
        /// To Delete Parking Data using Parking ID.
        /// </summary>
        /// <param name="parkingID"></param>
        /// <returns></returns>
        bool DeleteParkingData(int parkingID);

        /// <summary>
        /// To Get All Vehicles details in Parking.
        /// </summary>
        /// <returns></returns>
        List<ParkingDetails> GetAllVehiclesParkedData();

        /// <summary>
        /// To Get All Empty Slots.
        /// </summary>
        /// <returns></returns>
        List<ParkingDetails> GetAllEmptySlots();
    }
}
