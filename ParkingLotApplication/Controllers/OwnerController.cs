// <copyright file="OwnerController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ParkingLotApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using ApplicationModelLayer;
    using ApplicationServiceLayer;
    using Microsoft.AspNetCore.Mvc;
    using ApplicationServiceLayer.Interface;

    /// <summary>
    /// Controller for Owner.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService ownerService;
        private readonly IMSMQService mSMQService;

        public OwnerController(IOwnerService ownerService, IMSMQService mSMQService)
        {
            this.ownerService = ownerService;
            this.mSMQService = mSMQService;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult AddOwnerVehicleToParking([FromBody]Parking parking)
        {
            try
            {
                var result = this.ownerService.ParkVehicle(parking);
                if (result == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
                }

                this.mSMQService.AddToQueue("Vehicle Number " + result.VehicleNumber + " has been Parked at Slot Number " + result.SlotNumber + " at time: " + result.EntryTime);
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("unpark")]
        [HttpPut]
        public ActionResult RemoveOwnerVehicleFromParking(int slotNumber)
        {
            try
            {
                var result = this.ownerService.UnParkVehicle(slotNumber);
                if (result == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
                }

                this.mSMQService.AddToQueue("Vehicle number " + result.VehicleNumber + " is Unparked kindly pay the Charges: " + result.ParkingCharge);
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle UnParked Successfully", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("search/&vehiclenumber={vehicleNumber}")]
        [HttpGet]
        public ActionResult GetParkingDetailsWithVehicleNumber(string vehicleNumber)
        {
            try
            {
                var result = this.ownerService.GetParkingDetails(vehicleNumber);
                if (result == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("search/{parkingId}")]
        [HttpGet]
        public ActionResult GetParkingDetailsWithParkingID(int parkingId)
        {
            try
            {
                var result = this.ownerService.GetDetailsWithParkingID(parkingId);
                if (result == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("search/vehicle/{slotNumber}")]
        [HttpGet]
        public ActionResult GetParkingDetailsWithSlotNumber(int slotNumber)
        {
            try
            {
                var result = this.ownerService.GetDetailsWithSlotNumber(slotNumber);
                if (result == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("delete/{parkingId}")]
        [HttpDelete]
        public ActionResult DeleteParking(int parkingId)
        {
            try
            {
                bool result = this.ownerService.DeleteVehicleData(parkingId);
                if (result == true)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Deleted Successfully"));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("parkingdata")]
        [HttpGet]
        public ActionResult<List<ParkingDetails>> GetParkingData()
        {
            try
            {
                var response = this.ownerService.GetAllVehiclesData();
                if (response == null)
                {
                    this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Fetched Parking Data", response));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("slots")]
        [HttpGet]
        public ActionResult<List<ParkingDetails>> GetEmptySlots()
        {
            try
            {
                var response = this.ownerService.GetAllEmptySlots();
                if (response == null)
                {
                    this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
                }

                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Fetched Empty Slots", response));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }
    }
}
