﻿using System.Runtime.Serialization;

namespace Gunz.Lobby.Domain.Contracts.Security
{
    [DataContract]
    public class ApiTokenRequest
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
