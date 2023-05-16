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
    public class BrandWindowViewModel: ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Manufacturer= value.Manufacturer,
                        Owner = value.Owner,
                        SuggestedSportId = value.SuggestedSportId
                    };
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public BrandWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:2286/", "brand", "hub");
                CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Name = SelectedBrand.Name,
                        SuggestedSportId= SelectedBrand.SuggestedSportId,
                        Manufacturer= SelectedBrand.Manufacturer,
                        Owner= SelectedBrand.Owner,
                        
                    });
                });

                UpdateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Update(SelectedBrand);

                });

                DeleteBrandCommand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.Id);
                },
                () =>
                {
                    return SelectedBrand != null;
                });
                SelectedBrand = new Brand();
            }

        }
    }
}
