// <copyright file="PoliceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer.Implementation
{
    using ApplicationModelLayer;
    using ApplicationRepositoryLayer;
    using ApplicationServiceLayer.Interface;

    public class PoliceService : IPoliceService
    {
        private readonly IParkingLotRepository parkingLotRepository;

        public PoliceService(IParkingLotRepository parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }

        public ParkingDetails GetDetailsWithParkingID(int parkingId)
        {
            return this.parkingLotRepository.GetParkingDetailsWithParkingID(parkingId);
        }

        public ParkingDetails GetDetailsWithSlotNumber(int slotNumber)
        {
            return this.parkingLotRepository.GetParkingDetailsWithSlotNumber(slotNumber);
        }

        public ParkingDetails GetParkingDetails(string vehicleNumber)
        {
            return this.parkingLotRepository.GetParkingDetails(vehicleNumber);
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
