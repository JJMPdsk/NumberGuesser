using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Number_guesser
{
    public class HighscoreViewModel : ObservableObject
    {
        #region Properties

        public static ObservableCollection<HighscoreModel> highscores = new ObservableCollection<HighscoreModel>();

        #endregion

        #region Constructors

        public HighscoreViewModel()
        {
            ShowDifficultySelectionViewCommand = new DelegateCommand(ShowDifficultySelection);
            ClearHistoryCommand = new DelegateCommand(ClearHighscore);
        }
       
        #endregion

        #region Commands

        public DelegateCommand ShowDifficultySelectionViewCommand { get; private set; }
        public DelegateCommand ClearHistoryCommand { get; private set; }
        
        #endregion

        #region Methods

        public static void AddNewHighscore(HighscoreModel highscore)
        {
            highscores.Add(highscore);

            var temp = highscores.OrderByDescending(a => a.PlayedDifficulty).ThenBy(n => n.TryCount);

            highscores = new ObservableCollection<HighscoreModel>(temp);
        }
        public static void ClearHighscore()
        {
            highscores.Clear();
        }


        public void ShowDifficultySelection()
        {
            Application.Current.MainWindow.Content = new DifficultySelectionView();
        }
        #endregion


    }
}
