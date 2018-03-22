﻿using System;
using System.Collections.Generic;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Town : IIdentifiable<int>, IModificationHistory
    {
        private ICollection<Address> addresses;

        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }

        public DateTime DataModified { get; set; }
        public DateTime DataCreated { get; set; }
    }
}
