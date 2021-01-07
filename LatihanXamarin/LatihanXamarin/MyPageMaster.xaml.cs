using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LatihanXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPageMaster : ContentPage
    {
        public ListView ListView;

        public MyPageMaster()
        {
            InitializeComponent();

            BindingContext = new MyPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MyPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyPageMasterMenuItem> MenuItems { get; set; }

            public MyPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MyPageMasterMenuItem>(new[]
                {
                    new MyPageMasterMenuItem { Id = 0, Title = "Main Page", 
                        TargetType = typeof(MainPage),ImageIcon="add.png" },
                    new MyPageMasterMenuItem { Id = 2, Title = "Show Employee",
                        TargetType=typeof(ShowEmployee),ImageIcon="add.png"},
                    new MyPageMasterMenuItem { Id = 3, Title = "Geolocation",
                        TargetType=typeof(ContohGeolocation),ImageIcon="add.png"},
                    new MyPageMasterMenuItem { Id = 4, Title = "List Image",
                        TargetType=typeof(ListImageCell),ImageIcon="add.png"},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}