using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string TestimonialName { get; set; }
        public string TestimonialDescription { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonilImageUrl { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
