using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using T3RXEA_HFT_2022231.Models;

namespace GUIFeladat.WpfClient
{
    public class SportWindowViewModel: ObservableRecipient
    {
        public RestCollection<Sport> Sports { get; set; }

        private Sport selectedSport;

        public Sport SelectedSport
        {
            get { return selectedSport; }
            set
            {
                if (value != null)
                {
                    selectedSport = new Sport()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Description = value.Description,
                        IsOlimpic = value.IsOlimpic,
                        Inventor = value.Inventor
                    };
                    OnPropertyChanged();
                    (DeleteSportCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateSportCommand { get; set; }
        public ICommand DeleteSportCommand { get; set; }
        public ICommand UpdateSportCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public SportWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Sports = new RestCollection<Sport>("http://localhost:2286/", "sport", "hub");
                CreateSportCommand = new RelayCommand(() =>
                {
                    Sports.Add(new Sport()
                    {
                        Name = SelectedSport.Name,
                        Description =SelectedSport.Description,
                        IsOlimpic = SelectedSport.IsOlimpic,
                        Inventor =SelectedSport.Inventor
                        
                        
                    });
                });

                UpdateSportCommand = new RelayCommand(() =>
                {
                    Sports.Update(SelectedSport);

                });

                DeleteSportCommand = new RelayCommand(() =>
                {
                    Sports.Delete(selectedSport.Id);
                },
                () =>
                {
                    return SelectedSport != null;
                });
                SelectedSport = new Sport();
            }

        }
    }
}

