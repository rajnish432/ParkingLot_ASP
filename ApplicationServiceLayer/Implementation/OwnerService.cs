// <copyright file="OwnerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using System.Collections.Generic;
    using ApplicationModelLayer;
    using ApplicationRepositoryLayer;

    /// <summary>
    /// Service Layer for Owner.
    /// </summary>
    public class OwnerService : IOwnerService
    {
        private readonly IParkingLotRepository parkingLotRepository;

        public OwnerService(IParkingLotRepository parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }

        public List<ParkingDetails> GetAllEmptySlots()
        {
            return this.parkingLotRepository.GetAllEmptySlots();
        }

        public bool DeleteVehicleData(int parkingId)
        {
            return this.parkingLotRepository.DeleteParkingData(parkingId);
        }

        public List<ParkingDetails> GetAllVehiclesData()
        {
            return this.parkingLotRepository.GetAllVehiclesParkedData();
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
