using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App1.ViewModel
{
    class MainViewModel : MainViewModelBase
    {
        private bool _isAddBtnEnabled;
        public ObservableCollection<Transaction> TransactionList { get; set; }

        public MainViewModel()
        {
            TransactionList = new ObservableCollection<Transaction>();
            IsAddBtnEnabled = true;
            Transaction.RndTransactions().ForEach(e =>
            {
                TransactionList.Add(e);
            });
        }

        public bool IsAddBtnEnabled
        {
            get => _isAddBtnEnabled;
            set
            {
                _isAddBtnEnabled = value;
                OnPropertyChanged(nameof(IsAddBtnEnabled));
            }
        }

        // public ICommand AddTransaction()
        // {
        //     NewTransactionPage page = new NewTransactionPage();
        //     
        // }
    }
}
