/* 
 * Student: Chau Trinh
 * Class: ITSE 1430
 * Lab 5: Event Planner
 * Date: 10 Dec 2018
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventPlanner.Mvc.Models
{
    public class model
    {
        public model()
        {

        }

        public model( ScheduledEvent item)
        {
            //if (item !=null)
            {
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                StartDate = item.StartDate;
                EndDate = item.EndDate;
                IsPublic = item.IsPublic;
            }
        }

        public ScheduledEvent ToDomain()
        {
            return new ScheduledEvent()
            {
                Name = Name,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                IsPublic = IsPublic,
            };
        }

        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
                
        public string Description { get; set; }
        
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public bool IsPublic { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            if (EndDate < StartDate)
                yield return new ValidationResult("End date must be greater than or equal to start date.", new[] { nameof(EndDate) });
        }

    }
}