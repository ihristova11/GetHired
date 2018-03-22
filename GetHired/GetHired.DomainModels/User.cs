﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;
using GetHired.DomainModels.Enums;

namespace GetHired.DomainModels
{
    public class User : IIdentifiable<int>, IModificationHistory
    {
        public User()
        {
            this.FavouriteJobOffers = new HashSet<JobOffer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Column(TypeName = "VARCHAR")]
        public string Username { get; set; }

        [MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string PasswordSalt { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public Role Role { get; set; }

        public ICollection<JobOffer> FavouriteJobOffers { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
