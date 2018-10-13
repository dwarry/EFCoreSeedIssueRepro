using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedIssueRepro
{
    public class SomeRootEntity
    {
        public SomeRootEntity()
        {
            // Comment out this line to get the program to work. 
            UpdateDetails = new UpdateDetails();
        }

        public Guid Id { get; set; }

        [Required][StringLength(32)]
        public string Name { get; set; }

        public UpdateDetails UpdateDetails { get; set; } 
    }


    public class UpdateDetails
    {
        [Required]
        [StringLength(32)]
        public string LastUpdatedBy { get; set; } = "";

        public DateTime LastUpdatedAt { get; set; } = DateTime.MinValue;
    }

    
}
