// <copyright file="IOwnerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using System.Collections.Generic;
    using ApplicationModelLayer;

    /// <summary>
    /// Interface for Owner service.
    /// </summary>
    public interface IOwnerService
    {
        ParkingDetails ParkVehicle(Parking parking);

        ParkingDetails UnParkVehicle(int slotNumber);

        ParkingDetails GetParkingDetails(string vehicleNumber);

        ParkingDetails GetDetailsWithParkingID(int parkingId);

        ParkingDetails GetDetailsWithSlotNumber(int slotNumber);

        bool DeleteVehicleData(int parkingId);

        List<ParkingDetails> GetAllVehiclesData();

        List<ParkingDetails> GetAllEmptySlots();
    }
}
