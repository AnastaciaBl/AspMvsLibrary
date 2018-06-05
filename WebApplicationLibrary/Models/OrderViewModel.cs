using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationLibrary.Models
{
    public class OrderViewModel
    {
        public int Book_Id { get; set; }
        [Display(Name = "Book`s Title")]
        public string BookTitle { get; set; }
        public int Client_Id { get; set; }
        [Display(Name = "Client`s Full Name")]
        public string ClientFullName { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
        [Display(Name = "Is Completed")]
        public bool IsCompleted { get; set; }
        [Display(Name = "Penalty")]
        public double ActualPenalty { get; set; }
        public List<int> SelectedBookId { get; set; }
        public List<BookViewModel> Books { get; set; }
        public int SelectedClientId { get; set; }
        public List<ClientViewModel> Clients { get; set; }
    }
}