using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        [JsonPropertyName("CPF")]
        public string CPF { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("DtBirth")]
        public DateTime DtBirth { get; set; }
        [JsonPropertyName("Mail")]
        public string Mail { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [JsonPropertyName("Status")]
        public bool Status { get; set; }
        [JsonPropertyName("Address")]
        public Address Address { get; set; }
    }

    public class UserDTO
    {
        [Required]
        [StringLength(maximumLength: 11, MinimumLength = 11)]
        public string UnformattedCPF { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public DateTime DtBirth { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        [StringLength(maximumLength: 6, MinimumLength = 3)]
        public string Password { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public AddressDTO Address { get; set; }
    }

    public class UserUpdateDTO
    {
        [Required]
        [StringLength(maximumLength: 11, MinimumLength = 11)]
        public string UnformattedCPF { get; set; }
        [Required]
        [StringLength(30)]
        public string NewName { get; set; }
        [Required]
        [StringLength(maximumLength: 6, MinimumLength = 3)]
        public string NewPassword { get; set; }
        public AddressDTO NewAddress { get; set; }
    }

    public class UserOnlyCPFDTO
    {
        [Required]
        [StringLength(maximumLength: 11, MinimumLength = 11)]
        public string UnformattedCPF { get; set; }
    }
}
