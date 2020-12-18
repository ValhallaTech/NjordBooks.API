﻿using System.Collections.Generic;

namespace NjordBooks.API.Models.ViewModels
{
    public class HouseholdDashboardVM
    {
        public IEnumerable<NjordBooksUser> Occupants { get; set; }
        public IEnumerable<BankAccount> Accounts { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
