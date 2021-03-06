﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cinema;


namespace AppliWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<SalleBis> leComplexe = new List<SalleBis>();
         

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            init_list();
            rempli_list();

        }

        private void init_list() { 
            leComplexe.Add(new SalleBis("non stop","nonstop.jpg",250,8.9));
            leComplexe.Add(new SalleBis("de toutes nos forces", "deToutesNosForces.jpg", 200, 6.9));
            leComplexe.Add(new SalleBis("captain america", "deToutesNosForces.jpg", 200, 6.9));
        }
        private void rempli_list() {

            foreach (SalleBis uneSalle in leComplexe) {
                cbLesFilms.Items.Add(uneSalle.getNom());
            }
        }
    }
}
