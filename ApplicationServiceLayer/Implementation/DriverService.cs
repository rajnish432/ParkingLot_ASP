// <copyright file="DriverService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer.Implementation
{
    using ApplicationModelLayer;
    using ApplicationRepositoryLayer;
    using ApplicationServiceLayer.Interface;

    /// <summary>
    /// Service class of Driver.
    /// </summary>
    public class DriverService : IDriverService
    {
        private readonly IParkingLotRepository parkingLotRepository;

        public DriverService(IParkingLotRepository parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }

        public ParkingDetails ParkVehicle(Parking parking)
        {
            return this.parkingLotRepository.AddVehicleToParking(parking);
        }

        public ParkingDetails UnParkVehicle(int slotNumber)
        {
            ParkingDetails parkingDetails = this.parkingLotRepository.UnParkVehicle(slotNumber);
            return parkingDetails;
        }
    }
}
