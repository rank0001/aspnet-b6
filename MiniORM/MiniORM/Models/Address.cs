﻿namespace MiniORM.Models
{
    public class Address: BaseId,IId
    {

        public new int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}