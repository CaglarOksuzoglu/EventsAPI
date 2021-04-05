using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventsDB
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
