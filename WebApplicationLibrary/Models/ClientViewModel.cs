﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.BLL.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System;

namespace WebApplicationLibrary.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<OrderViewModel> Orders { get; set; }

        public ClientViewModel()
        {
            Orders = new List<OrderViewModel>();
        }
    }
}