// <copyright file="ResponseEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationModelLayer
{
    using System.Net;

    public class ResponseEntity
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public ResponseEntity(HttpStatusCode httpStatusCode, string message, object data)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Message = message;
            this.Data = data;
        }

        public ResponseEntity(HttpStatusCode httpStatusCode, string message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Message = message;
        }
    }
}
