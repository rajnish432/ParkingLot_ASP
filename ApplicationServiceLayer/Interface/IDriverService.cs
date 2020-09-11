// <copyright file="IDriverService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApplicationServiceLayer.Interface
{
    using ApplicationModelLayer;

    public interface IDriverService
    {
        ParkingDetails ParkVehicle(Parking parking);

        ParkingDetails UnParkVehicle(int slotNumber);
    }
}
