using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Student.Model
{
    public class ImportJsonDto
    {
       
        [JsonProperty("key")]
        public Guid Key { get; set; } = default;

        [JsonProperty("student")]
        public Dictionary<Guid, StudentModel> Student { get; set; } = default;

        [JsonProperty("NrIdentificare")]
        public Guid nrIdentificare { get; set; } = default;

         [JsonProperty("FirstName")]
         public string firstName { get; set; } = default;

         [JsonProperty("LastName")]
         public string lastName { get; set; } = default;

         [JsonProperty("adress")]
         public string adress { get; set; } = default;

         [JsonProperty("yearOfStudy")]
         public int yearOfStudy { get; set; } = default;
    
    }
}
