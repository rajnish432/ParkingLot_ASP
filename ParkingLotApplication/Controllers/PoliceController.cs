// <copyright file="PoliceController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ParkingLotApplication.Controllers
{
    using System;
    using System.Net;
    using ApplicationModelLayer;
    using ApplicationServiceLayer.Implementation;
    using ApplicationServiceLayer.Interface;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        private readonly IPoliceService policeService;
        private readonly IMSMQService mSMQService;

        public PoliceController(IPoliceService policeService, IMSMQService mSMQService)
        {
            this.policeService = policeService;
            this.mSMQService = mSMQService;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult AddVehicleToParking([FromBody] Parking parking)
        {
            try
            {
                var result = this.policeService.ParkVehicle(parking);
                if (result == null)
                {
                    return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found"));
                }

                this.mSMQService.AddToQueue("Vehicle Number" + result.VehicleNumber + "has been Parked at Slot Number" + result.SlotNumber + "at time:" + result.EntryTime);
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", result));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("unpark")]
        [HttpPut]
        public ActionResult RemoveVehicleFromParking(int slotNumber)
        {
            try
            {
                var result = this.policeService.UnParkVehicle(slotNumber);
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
                var result = this.policeService.GetParkingDetails(vehicleNumber);
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
                var result = this.policeService.GetDetailsWithParkingID(parkingId);
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
                var result = this.policeService.GetDetailsWithSlotNumber(slotNumber);
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
    }
}
