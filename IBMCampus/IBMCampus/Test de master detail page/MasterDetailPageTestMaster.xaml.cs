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

namespace IBMCampus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageTestMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageTestMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageTestMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageTestMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageTestMenuItem> MenuItems { get; set; }

            public MasterDetailPageTestMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageTestMenuItem>(new[]
                {
                    new MasterDetailPageTestMenuItem { Id = 0, Title = "Mon profil" },
                    new MasterDetailPageTestMenuItem { Id = 1, Title = "Mes groupes" },
                    new MasterDetailPageTestMenuItem { Id = 2, Title = "Mes évènements" },
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

        private void GoToPage(object sender, SelectedItemChangedEventArgs e)
        {
            var infoPage = e.SelectedItem as MasterDetailPageTestMenuItem;

            switch (infoPage.Id)
            {
                case 0:
                    infoPage.TargetType = typeof(PageProfilUtilisateur);
                    break;
                case 1:
                    infoPage.TargetType = typeof(PageTousLesGroupes);
                    break;
                default:
                    break;
            }
        }
    }
}