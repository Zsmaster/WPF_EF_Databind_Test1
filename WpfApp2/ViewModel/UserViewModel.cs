using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Data;

namespace WpfApp2.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private myPCWebShopEntities entities = new myPCWebShopEntities();
        private User _user = new User();

        public string UserNameNotify
        {
            get 
            {
                return _user.UserName;
            }

            set 
            {
                _user.UserName = value;
                OnPropertyChanged("UserNameNotify");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddUser()
        {
            _user.Id = "1";
            _user.Registrated = DateTime.Now;
            _user.LastLogin = DateTime.Now;
            _user.EmailConfirmed = true;
            _user.PhoneNumberConfirmed = true;
            _user.TwoFactorEnabled = false;
            _user.LockoutEnabled = false;
            _user.AccessFailedCount = 0;
            entities.User.Add(_user);
            entities.SaveChanges();
        }
    }
}
