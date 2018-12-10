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
            if (item !=null)
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
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "{StartDate}", "", ErrorMessage = "End date must be greater or equal start date")]
       
        //[Range(typeof(DateTime), StartDate.Date, DateTime.MaxValue, ErrorMessage = "End date must be greater or equal start date")]
        public DateTime EndDate { get; set; }

        
        public bool IsPublic { get; set; }
    }
}