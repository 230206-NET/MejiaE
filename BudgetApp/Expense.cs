using System;

namespace BudgetApp {
    class Expense {
        public string description { get; set; }
        public decimal amount { get; set; }

        public override string ToString() {
            return $"Description: {description} Amount: ${amount}";
        }

    }

}