﻿namespace Guestlogix.Services
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}