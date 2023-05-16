using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using T3RXEA_HFT_2022231.Models;

namespace GUIFeladat.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ICommand OpenBrandCommand { get; set; }
        public ICommand OpenShoeCommand { get; set; }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                OpenBrandCommand = new RelayCommand(() =>
                {
                    BrandWindow brandWindow = new BrandWindow();
                    brandWindow.ShowDialog();
                });

                OpenShoeCommand = new RelayCommand(() =>
                {
                    ShoeWindow shoeWindow = new ShoeWindow();
                    shoeWindow.ShowDialog();
                });
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}

