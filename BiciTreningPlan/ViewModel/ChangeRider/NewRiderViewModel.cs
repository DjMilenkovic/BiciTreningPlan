using BiciTreningPlan.Command;
using BiciTreningPlan.Services;
using BiciTreningPlanBLL;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;

namespace BiciTreningPlan.ViewModel.ChangeRider
{

    class NewRiderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Biciklista biciklista;
        public Biciklista Biciklista
        {
            get { return biciklista; }
            set
            {
                biciklista = value;
                RaisePropertyChanged("Biciklista");
            }
        }

        private bool zaposlenje;
        public bool Zaposlenje
        {
            get { return zaposlenje; }
            set
            {
                zaposlenje = value;
                RaisePropertyChanged("Zaposlenje");
            }
        }

        private ObservableCollection<Iskustveni_Nivo> nivoIskustva;
        public ObservableCollection<Iskustveni_Nivo> NivoIskustva
        {
            get { return nivoIskustva; }
            set
            {
                nivoIskustva = value;
                RaisePropertyChanged("NivoIskustva");
            }
        }       
        public ICommand Loaded { get; set; }
        public ICommand Save { get; set; }
        public ICommand Delete { get; set; }
        public ICommand ChoosePhoto { get; set; }

        private IMsgBoxService msgBox;
        public NewRiderViewModel()
        {           
            Loaded = new RelayCommand(Load);
            Save = new RelayCommand(SaveBiciklistu);
            Delete = new RelayCommand(DeleteBiciklistu);
            ChoosePhoto = new RelayCommand(OpenFile);
            msgBox = new MsgBoxService();
        }        

        private void OpenFile(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

                string sFileName = openFileDialog.FileName;
                string newFile = Environment.CurrentDirectory + @"\Resources\Images\" + System.IO.Path.GetFileName(sFileName);

                if (!File.Exists(newFile))
                {
                    try
                    {
                        File.Copy(sFileName, newFile);
                    }
                    catch (DirectoryNotFoundException)
                    {
                        string path = Environment.CurrentDirectory + @"\Resources\Images\";
                        Directory.CreateDirectory(path);
                        File.Copy(sFileName, newFile);
                    }

                    Biciklista.Slika = newFile;
                }                
            }
        }

        private void SaveBiciklistu(object obj)
        {
            if (Biciklista != null)
            {
                if (Biciklista.Ime != "" && Biciklista.Prezime != "" && Biciklista.Datum_Rodjenja != DateTime.Today && Biciklista.Adresa != "" && Biciklista.Grad != "" && Biciklista.Drzava != "")
                {
                    if (Zaposlenje == false)
                    {
                        Biciklista.Zaposlenje = "Ne";
                    }else
                    {
                        Biciklista.Zaposlenje = "Da";
                    }
                    RiderProfile rp = new RiderProfile();
                    rp.insertIntoDAL(Biciklista);
                    msgBox.ShowNotification("Uspešno ste se prijavili");
                    NoviBiciklista();
                }else
                {
                    msgBox.ShowError("Niste popunili sva neophodna polja");   
                }
            }
        }

        private void DeleteBiciklistu(object obj)
        {
            NoviBiciklista();
        }

        private void Load(object obj)
        {
            NoviBiciklista();

            ExperienceLevel expLV = new ExperienceLevel();
            NivoIskustva = new ObservableCollection<Iskustveni_Nivo>(expLV.GetDataFromDAL());
        }
        private void NoviBiciklista()
        {
            Biciklista = new Biciklista
            {
                Slika = "/Resources/defaultPicture.png",
                Datum_Rodjenja = DateTime.Today
            };
            Zaposlenje = false;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}