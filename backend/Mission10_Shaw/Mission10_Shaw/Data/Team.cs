using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Add this for JsonIgnore

namespace Mission10_Shaw.Data
{
    public partial class Team
    {
        [Key]
        public int TeamId { get; set; }

        public string TeamName { get; set; } = null!;

        public int? CaptainId { get; set; }

        // Ignore the Bowlers collection during serialization to prevent the cycle
        [JsonIgnore]
        public virtual ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();
    }
}
