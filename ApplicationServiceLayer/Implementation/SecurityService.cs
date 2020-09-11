// <copyright file="SecurityService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApplicationServiceLayer.Implementation
{
    using ApplicationModelLayer;
    using ApplicationRepositoryLayer;
    using ApplicationServiceLayer.Interface;

    public class SecurityService : ISecurityService
    {
        private readonly IParkingLotRepository parkingLotRepository;

        public SecurityService(IParkingLotRepository parkingLotRepository)
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
