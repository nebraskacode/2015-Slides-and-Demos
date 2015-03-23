using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MovieFanatic.Web.Models
{
    public class MovieDetailViewModel
    {
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Overview { get; set; }
        [Required(ErrorMessage = "Required")]
        public int StatusId { get; set; }
        public IEnumerable<SelectListItem> Statuses { get; set; }
    }
}