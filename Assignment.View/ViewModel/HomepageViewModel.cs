using System;
using System.Windows.Input;

namespace Assignment.View.ViewModel
{
    public class HomepageViewModel
    {

        public string uname { get; set; }


        private ICommand _logoutclick;
        public ICommand logoutclick
        {
            get
            {
                return _logoutclick ?? (_logoutclick = new CommandHandler(() => logoutaction(), true));
            }
        }

        public void logoutaction()
        {

            Homepage h = new Homepage();
            h.Close();
            MainWindow m = new MainWindow();
            m.Show();

        }





        private ICommand _showtable;
        public ICommand showtable
        {
            get
            {
                return _showtable ?? (_showtable = new CommandHandler(() => shtable(), true));
            }
        }

        public void shtable()
        {



        }



        public class CommandHandler : ICommand
        {
            private Action _action;
            private bool _canExecute;
            public CommandHandler(Action action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action();
            }
        }

    }
}
