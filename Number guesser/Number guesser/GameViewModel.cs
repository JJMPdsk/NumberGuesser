using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Number_guesser
{
    public class GameViewModel : ObservableObject
    {
        #region Fields

        private Brush _checkedIfGuessed;
        private string _resultOfCheck;
        private string _tooHighOrTooLow;
        private Visibility _continueButt;
        private int _checkCounter;

        #endregion

        #region Properties

        public GameModel gameModel { get; set; }
        public HighscoreViewModel highscoreVM { get; set; }
        public Brush CheckedIfGuessed
        {
            get { return _checkedIfGuessed; }
            set
            {
                _checkedIfGuessed = value;
                OnPropertyChangedEvent("CheckedIfGuessed");
            }
        }
        public string ResultOfCheck
        {
            get { return _resultOfCheck; }
            set
            {
                _resultOfCheck = value;
                OnPropertyChangedEvent("ResultOfCheck");
            }
        }
        public string TooHighOrTooLow
        {
            get { return _tooHighOrTooLow; }
            set
            {
                _tooHighOrTooLow = value;
                OnPropertyChangedEvent("TooHighOrTooLow");
            }
        }

        public Visibility ContinueButt
        {
            get { return _continueButt; }
            set
            {
                _continueButt = value;
                OnPropertyChangedEvent("ContinueButt");
            }
        }
        public int CheckCounter
        {
            get { return _checkCounter; }
            set
            {
                _checkCounter = value;
                OnPropertyChangedEvent("CheckCounter");
            }
        }

        #endregion

        #region Commands

        public DelegateCommand IncrementCommand { get; private set; }
        public DelegateCommand DecrementCommand { get; private set; }
        public DelegateCommand CheckCommand { get; private set; }
        public DelegateCommand ContinueCommand { get; private set; }

        #endregion

        #region Constructors

        public GameViewModel()
        {
            gameModel = new GameModel();

            IncrementCommand = new DelegateCommand(gameModel.IncrementMyNumber);
            DecrementCommand = new DelegateCommand(gameModel.DecrementMyNumber);
            CheckCommand = new DelegateCommand(Check);
            ContinueCommand = new DelegateCommand(Continue);
            ContinueButt = Visibility.Collapsed;
            CheckCounter = 0;
            highscoreVM = new HighscoreViewModel();

        }

        public GameViewModel(int dif) : this()
        {
            gameModel = new GameModel(dif);

            IncrementCommand = new DelegateCommand(gameModel.IncrementMyNumber);
            DecrementCommand = new DelegateCommand(gameModel.DecrementMyNumber);
            CheckCommand = new DelegateCommand(Check);
            ContinueCommand = new DelegateCommand(Continue);
            ContinueButt = Visibility.Collapsed;
            CheckCounter = 0;
            highscoreVM = new HighscoreViewModel();

        }

        #endregion

        #region Methods

        public void Check()
        {
            CheckCounter++;

            if (gameModel.Check())
            {
                CheckedIfGuessed = Brushes.Green;
                ResultOfCheck = "You guessed it!";
                TooHighOrTooLow = " ";
                ContinueButt = Visibility.Visible;
                highscoreVM.AddNewHighscore(new HighscoreModel { TryCount = CheckCounter, PlayedDifficulty = gameModel.Difficulty });
            }
            else
            {
                CheckedIfGuessed = Brushes.Red;
                ResultOfCheck = "Wrong!";
                if (gameModel.MyNumber > gameModel.NumberToGuess)
                    TooHighOrTooLow = "Your guess is too high!";
                else TooHighOrTooLow = "Your guess is too low!";
                ContinueButt = Visibility.Collapsed;
            }


        }
        public void Continue()
        {
            ContinueButt = Visibility.Collapsed;
            Application.Current.MainWindow.Content = new DifficultySelectionView();
            Application.Current.MainWindow.DataContext = new DifficultySelectionViewModel();

        }

        #endregion


    }
}
