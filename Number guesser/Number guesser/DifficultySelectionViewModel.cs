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

        public DelegateCommand NoDifficultySelectionCommand { get; private set; }
        public DelegateCommand EasyDifficultySelectionCommand { get; private set; }
        public DelegateCommand NormalDifficultySelectionCommand { get; private set; }
        public DelegateCommand HardDifficultySelectionCommand { get; private set; }
        public DelegateCommand ImpossibleDifficultySelectionCommand { get; private set; }
        public DifficultySelectionViewModel()
        {
            NoDifficultySelectionCommand = new DelegateCommand(SelectNoDifficulty);
            EasyDifficultySelectionCommand = new DelegateCommand(SelectEasyDifficulty);
            NormalDifficultySelectionCommand = new DelegateCommand(SelectNormalDifficulty);
            HardDifficultySelectionCommand = new DelegateCommand(SelectHardDifficulty);
            ImpossibleDifficultySelectionCommand = new DelegateCommand(SelectImpossibleDifficulty);
        }

        public void SelectNoDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new MainViewModel(0);
        }
        public void SelectEasyDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new MainViewModel(1);
        }
        public void SelectNormalDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new MainViewModel(2);
        }
        public void SelectHardDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new MainViewModel(3);
        }
        public void SelectImpossibleDifficulty()
        {
            Application.Current.MainWindow.Content = new GameView();
            Application.Current.MainWindow.DataContext = new MainViewModel(4);
        }

    }
}
