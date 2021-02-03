using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class Transaction
    {
        /// <summary>
        /// The amount of the transaction, displayed as long, with 00 final, example 134,30$ will be represented as 13430.
        /// </summary>
        private long amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="amount">
        /// The amount of the transaction, in negative is an outgoing transaction, if positive it's an incoming transaction.
        /// </param>
        /// <param name="description">
        /// The description of the transaction.
        /// </param>
        /// <param name="note">
        /// The note, could be empty.
        /// </param>
        /// <param name="valueDateTime">
        /// The value date time, when the transaction occur.
        /// </param>
        /// <param name="accountingDateTime">
        /// The accounting date time, ex: when the transaction is visible on bank.
        /// </param>
        /// <param name="beneficiary">
        /// The beneficiary of the transaction, if it's an incoming transaction, it means the creditor.
        /// </param>
        /// <param name="parent">
        /// The parent <see cref="Transaction"/>, every transaction could belong to another Transaction.
        /// </param>
        public Transaction(int amount, string description, string note, DateTime valueDateTime, DateTime accountingDateTime, string beneficiary, Transaction parent = null)
        {
            this.Amount = amount;
            this.Description = description;
            this.Note = note;
            this.ValueDateTime = valueDateTime;
            this.AccountingDateTime = accountingDateTime;
            this.Beneficiary = beneficiary;
            this.Parent = parent;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the value date time.
        /// </summary>
        public DateTime ValueDateTime { get; set; }

        /// <summary>
        /// Gets or sets the accounting date time.
        /// </summary>
        public DateTime AccountingDateTime { get; set; }

        /// <summary>
        /// Gets or sets the beneficiary.
        /// </summary>
        public string Beneficiary { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        public Transaction Parent { get; set; }

        /// <summary>
        /// Gets or sets the amount, displayed as long, with 00 final, example 134,30$ will be represented as 13430.
        /// </summary>
        public long Amount
        {
            get => this.amount / 100;
            set => this.amount = value;
        }

        /// <summary>
        /// Generate a random transaction list for GUI testing purpose.
        /// </summary>
        /// <returns>
        /// The <see cref="List{Transaction}"/>.
        /// </returns>
        public static List<Transaction> RndTransactions()
        {
            var rndAct = new List<string>()
                             {
                                 "Payment",
                                 "Refund",
                                 "Deposit",
                                 "Transfer",
                                 "Withdrawal"
                             };
            var rndTip = new List<string>()
                             {
                                 "Supply",
                                 "Customer",
                                 "Raising",
                                 "Abeyance",
                                 "Refill"
                             };
            var rndBen = new List<string>()
                             {
                                 "McDonald's",
                                 "Bar Sport",
                                 "Restaurant FishMan",
                                 "Warehouse",
                                 "Pub beer"
                             };
            var rnd = new Random(213);
            var transactions = new List<Transaction>();
            var rndValueDate = DateTime.Now.AddDays(rnd.Next(0, 255));
            var rndAccountingDate = rnd.Next(0, 6) == 0 ? rndValueDate.AddDays(rnd.Next(3, 5)) : rndValueDate;
            for (var i = 0; i < 3000; i++)
            {
                transactions.Add(
                    new Transaction(
                        rnd.Next(100, 100000),
                        rndAct[rnd.Next(rndAct.Count)] + " " + rndTip[rnd.Next(rndTip.Count)],
                        string.Empty,
                        rndValueDate,
                        rndAccountingDate,
                        rndBen[rnd.Next(rndBen.Count)]));
            }

            return transactions;
        }
    }
}
