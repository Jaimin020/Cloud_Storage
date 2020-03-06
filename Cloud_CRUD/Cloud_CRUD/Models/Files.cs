﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_CRUD.Models
{
    public class Files
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string extention { get; set; }
        [Required]
        public byte[] data { get; set; }
        
        public User_Details user { get; set; }
    }
}