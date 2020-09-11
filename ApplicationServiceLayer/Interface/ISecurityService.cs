// <copyright file="ISecurityService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApplicationServiceLayer.Interface
{
    using ApplicationModelLayer;

    public interface ISecurityService
    {
        ParkingDetails ParkVehicle(Parking parking);

        ParkingDetails UnParkVehicle(int slotNumber);
    }
}
