// <copyright file="ParkingDetails.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationModelLayer
{
    using System.ComponentModel.DataAnnotations;

    public class ParkingDetails
    {
        public int ParkingId { get; set; }

        /// <summary>
        /// Gets or sets vehicle Number.
        /// </summary>
        [Required]
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Gets or Sets EntryTime.
        /// </summary>
        [Required]
        public string EntryTime { get; set; }

        /// <summary>
        /// Gets or sets Parking Type.
        /// </summary>
        [Required]
        public int ParkingType { get; set; }

        /// <summary>
        /// Gets or sets Driver Type.
        /// </summary>
        [Required]
        public int DriverType { get; set; }

        /// <summary>
        /// Gets or sets Vehicle Type.
        /// </summary>
        [Required]
        public int VehicleType { get; set; }

        /// <summary>
        /// Gets or Sets ExitTime.
        /// </summary>
        [Required]
        public string ExitTime { get; set; }

        /// <summary>
        /// Gets or sets Slot number.
        /// </summary>
        [Required]
        public int SlotNumber { get; set; }

        /// <summary>
        /// Gets or sets parking charges.
        /// </summary>
        public int ParkingCharge { get; set; }
    }
}
