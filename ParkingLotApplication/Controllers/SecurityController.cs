// <copyright file="SecurityController.cs" company="PlaceholderCompany">
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
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService securityService;
        private readonly IMSMQService mSMQService;

        public SecurityController(ISecurityService securityService, IMSMQService mSMQService)
        {
            this.securityService = securityService;
            this.mSMQService = mSMQService;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult AddVehicleToParking([FromBody] Parking parking)
        {
            try
            {
                var result = this.securityService.ParkVehicle(parking);
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
        public ActionResult RemoveVehicleFromParking(int slotNumber)
        {
            try
            {
                var result = this.securityService.UnParkVehicle(slotNumber);
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
    }
}
