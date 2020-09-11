// <copyright file="IMSMQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer.Interface
{
    using Experimental.System.Messaging;

    public interface IMSMQService
    {
        /// <summary>
        /// Add message to MSMQ.
        /// </summary>
        /// <param name="message"></param>
        void AddToQueue(string message);

        /// <summary>
        /// Fetch Message from MSMQ.
        /// </summary>
        /// <param name="sender"></param>
        void ReceiveFromQueue(object sender, ReceiveCompletedEventArgs e);
    }
}
