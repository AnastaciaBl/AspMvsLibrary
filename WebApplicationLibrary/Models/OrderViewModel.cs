using System;
using System.Collections.Generic;

namespace WebApplicationLibrary.Models
{
    public class OrderViewModel
    {
        public int Book_Id { get; set; }
        public string BookTitle { get; set; }
        public int Client_Id { get; set; }
        public string ClientFullName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsCompleted { get; set; }
        public double ActualPenalty { get; set; }
        public List<int> SelectedBookId { get; set; }
        public List<BookViewModel> Books { get; set; }
        public int SelectedClientId { get; set; }
        public List<ClientViewModel> Clients { get; set; }
    }
}