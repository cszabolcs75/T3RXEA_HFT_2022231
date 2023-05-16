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
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace GUIFeladat.WpfClient
{
    public class ShoeWindowViewModel : ObservableRecipient
    {

        public RestCollection<Shoe> Shoes { get; set; }

        private Shoe selectedShoe;

        public Shoe SelectedShoe
        {
            get { return selectedShoe; }
            set
            {
                if (value != null)
                {
                    selectedShoe = new Shoe()
                    {
                        Id = value.Id,
                        BrandId = value.BrandId,
                        SportId = value.SportId,
                        Prize = value.Prize,
                        Name = value.Name,
                    };
                    OnPropertyChanged();
                    (DeleteShoeCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateShoeCommand { get; set; }
        public ICommand DeleteShoeCommand { get; set; }
        public ICommand UpdateShoeCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public ShoeWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Shoes = new RestCollection<Shoe>("http://localhost:2286/", "shoe", "hub");
                CreateShoeCommand = new RelayCommand(() =>
                {
                    Shoes.Add(new Shoe()
                    {
                        Name = SelectedShoe.Name,
                        BrandId = SelectedShoe.BrandId,
                        SportId= SelectedShoe.SportId,
                        Prize= SelectedShoe.Prize
                    });
                });

                UpdateShoeCommand = new RelayCommand(() =>
                {
                    Shoes.Update(SelectedShoe);

                });

                DeleteShoeCommand = new RelayCommand(() =>
                {
                    Shoes.Delete(SelectedShoe.Id);
                },
                () =>
                {
                    return SelectedShoe != null;
                });
                SelectedShoe = new Shoe();
            }

        }
    }
}
