﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Number_guesser
{
    /// <summary>
    /// Logika interakcji dla klasy HighscoreView.xaml
    /// </summary>
    public partial class HighscoreView : UserControl
    {

        public HighscoreView()
        {
            InitializeComponent();
            HighscoreViewModel hVM = new HighscoreViewModel();
            LVsummary.ItemsSource = hVM.highscores;
        }
    }
}
