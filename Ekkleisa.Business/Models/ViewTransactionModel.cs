﻿namespace Ekkleisa.Business.Models
{
    public class ViewTransactionModel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public string Receipt { get; set; }        
        public string Type { get; set; }

        public SimpleViewMemberModel Responsable { get; set; }
    }
}
