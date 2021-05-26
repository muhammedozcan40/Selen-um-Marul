﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace migros.Models
{
    public class Markets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public string Path { get; set; }
        public string Address { get; set; }
        public int Source { get; set; }
        public string ShopPHPID { get; set; }
        public bool ShopPHPState { get; set; }
    }
}
