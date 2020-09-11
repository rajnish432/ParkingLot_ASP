// <copyright file="IPoliceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer.Interface
{
    using ApplicationModelLayer;

    public interface IPoliceService
    {
        ParkingDetails ParkVehicle(Parking parking);

        ParkingDetails UnParkVehicle(int slotNumber);

        ParkingDetails GetParkingDetails(string vehicleNumber);

        ParkingDetails GetDetailsWithParkingID(int parkingId);

        ParkingDetails GetDetailsWithSlotNumber(int slotNumber);
    }
}
