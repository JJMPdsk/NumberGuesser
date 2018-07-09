using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Number_guesser
{
    public class DifficultySelectionViewModel : ObservableObject
    {
        #region Commands

        public DelegateCommand NoDifficultySelectionCommand { get; private set; }
        public DelegateCommand EasyDifficultySelectionCommand { get; private set; }
        public DelegateCommand NormalDifficultySelectionCommand { get; private set; }
        public DelegateCommand HardDifficultySelectionCommand { get; private set; }
        public DelegateCommand ImpossibleDifficultySelectionCommand { get; private set; }
        public DelegateCommand ShowHistoryCommand { get; private set; }

        #endregion

        #region Constructors

        public DifficultySelectionViewModel()
        {
            NoDifficultySelectionCommand = new DelegateCommand(SelectNoDifficulty);
            EasyDifficultySelectionCommand = new DelegateCommand(SelectEasyDifficulty);
            NormalDifficultySelectionCommand = new DelegateCommand(SelectNormalDifficulty);
            HardDifficultySelectionCommand = new DelegateCommand(SelectHardDifficulty);
            ImpossibleDifficultySelectionCommand = new DelegateCommand(SelectImpossibleDifficulty);
            ShowHistoryCommand = new DelegateCommand(ShowHistory);
        }

        #endregion

        #region Methods

        public void SelectNoDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new GameViewModel(0);
        }
        public void SelectEasyDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new GameViewModel(1);
        }
        public void SelectNormalDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new GameViewModel(2);
        }
        public void SelectHardDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new GameViewModel(3);
        }
        public void SelectImpossibleDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new GameViewModel(4);
           // Application.Current.MainWindow.DataContext = new MainViewModel(4);
        }

        public void ShowHistory()
        {
            Application.Current.MainWindow.Content = new HighscoreView();
            Application.Current.MainWindow.DataContext = new HighscoreViewModel();
        }
        
        #endregion

    }
}
