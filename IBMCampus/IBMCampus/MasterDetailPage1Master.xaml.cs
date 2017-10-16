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
    public partial class MasterDetailPage1Master : ContentPage
    {
        public ListView ListView;

        public MasterDetailPage1Master()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPage1MasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPage1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPage1MenuItem> MenuItems { get; set; }

            public MasterDetailPage1MasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPage1MenuItem>(new[]
                {
                    new MasterDetailPage1MenuItem { Id = 0, Title = "Mes données", TargetType=typeof(TabbedPageInformationsPerso) },
                    new MasterDetailPage1MenuItem { Id = 1, Title = "Groupes", TargetType=typeof(GroupeTabbedPage)},
                    //new MasterDetailPage1MenuItem { Id = 2, Title = "Tous les groupes", TargetType=typeof(PageTousLesGroupes)},
                    new MasterDetailPage1MenuItem { Id = 3, Title = "Evenements", TargetType=typeof(TabbedPageEvenements)},
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Covoiturage chauffeur", TargetType=typeof(CovoiturageChauffeur)},
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