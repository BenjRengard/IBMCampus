using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFormCreationEvent : ContentPage
    {
        Repository repo = App.Current.BindingContext as Repository;

        ObservableCollection<GroupeModel> _groupes = new ObservableCollection<GroupeModel>();

        GroupeModel _groupeSelection = null;

        private bool EnregistrerClique = false;


        public PageFormCreationEvent()
        {
            InitializeComponent();
            EnregistrerClique = false;

        }

        public PageFormCreationEvent(GroupeModel groupe)
        {
            InitializeComponent();
            EnregistrerClique = false;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            EnregistrerClique = true;
            int nbParticip;

            var result = int.TryParse(NombreParticipantsMax.Text, out nbParticip);

            if (!result || nbParticip <= 0)
            {
                await DisplayAlert("Nombre de participants", "Le nombre de participant entré est incorrect", "OK");
            }
            else
            {
                if (_groupeSelection == null)
                {
                    await DisplayAlert("Groupe a choisir", "Vous devez choisir un groupe dans la liste pour finaliser la création", "OK");

                }
                else
                {


                    EvenementsModel nouvelEvent = new EvenementsModel()
                    {
                        DebutEvenement = DateFin.Date,
                        FinEvenement = DateFin.Date,
                        NomEvenement = NomNouvelEvent.Text,
                        IdGroupe = _groupeSelection.IdGroupe,
                        NombreParticipantsMax = nbParticip,
                        IsRecurentHebdo = Switch.IsToggled,
                        VilleEvent = Ville.Text,
                        CodePostalEvent = CodePostal.Text,
                        NomVoieEvent = NomVoie.Text,
                        NumeroVoieEvent = NumeroVoie.Text,
                        TypeVoieEvent = TypeVoie.Text,
                        Participants = new ObservableCollection<UtilisateurModel>() { repo.User }

                    };

                    var newEvent = await repo.CreerNouvelEvenement(nouvelEvent);
                    if (repo.MessageErreur != null || newEvent == null)
                    {
                        await DisplayAlert("Problème!", repo.MessageErreur, "OK");
                    }
                    else
                    {

                        await repo.InscriptionEvent(repo.User.IdUtilisateur, newEvent.IdGroupe, newEvent.IdEvenement);


                        if (repo.MessageErreur != null)
                        {
                            await DisplayAlert("Problème!", repo.MessageErreur, "OK");
                        }
                        else
                        {
                            await DisplayAlert("Enregistrement", "L'evenement a bien été créé. Vous y êtes inscrit.", "OK");
                            await Navigation.PopAsync();
                            EnregistrerClique = false;
                        }

                    }

                }

            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var groupeName = DropDownGroupe.Items[DropDownGroupe.SelectedIndex];

            _groupeSelection = new GroupeModel();
            _groupeSelection = _groupes.FirstOrDefault(gp => gp.NomGroupe == groupeName);
        }

        protected override async void OnAppearing()
        {
            _groupes = await repo.RecupererGroupesUser(repo.User.IdUtilisateur.ToString());
            if (_groupes == null || _groupes.Count <= 0)
            {
                await DisplayAlert("Problème", "Problème lors de la récupération des sports. Veuillez ressayer", "OK");
            }
            foreach (var groupe in _groupes)
            {
                DropDownGroupe.Items.Add(groupe.NomGroupe);
            }
            base.OnAppearing();
        }
    }
}