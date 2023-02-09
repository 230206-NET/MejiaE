using System;

namespace BudgetApp {
    public class Expense {
        public string description { get; set; }
        public double amount { get; set; }

        public override string ToString() {
            return $"Description: {description} Amount: ${amount}";
        }

    }

}