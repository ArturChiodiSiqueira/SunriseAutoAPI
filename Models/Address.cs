﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        [Required]
        [MaxLength(9)]
        [JsonPropertyName("ZipCode")]
        public string ZipCode { get; set; }

        [MaxLength(100)]
        [JsonPropertyName("Street")]
        public string Street { get; set; }

        [Required]
        [JsonPropertyName("Number")]
        public int Number { get; set; }

        [MaxLength(10)]
        [JsonPropertyName("Complement")]
        public string Complement { get; set; }

        [MaxLength(30)]
        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("State")]
        public string State { get; set; }
    }

    public class AddressDTOViaCep
    {
        [Required]
        [MaxLength(9)]
        [JsonPropertyName("cep")]
        public string ZipCode { get; set; }

        [MaxLength(100)]
        [JsonPropertyName("logradouro")]
        public string Street { get; set; }

        [Required]
        public int Number { get; set; }

        [MaxLength(10)]
        public string Complement { get; set; }

        [MaxLength(30)]
        [JsonPropertyName("localidade")]
        public string City { get; set; }

        [JsonPropertyName("uf")]
        public string State { get; set; }
    }

    public class AddressDTO
    {
        [Required]
        [MaxLength(9)]
        public string ZipCode { get; set; }

        [Required]
        public int Number { get; set; }
        [MaxLength(10)]
        public string Complement { get; set; } = "";
    }
}