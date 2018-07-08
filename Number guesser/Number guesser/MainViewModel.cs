using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_guesser
{
    public class MainViewModel
    {
        public DifficultySelectionViewModel difficultyViewModel { get; private set; }
        public GameViewModel gameViewModel { get; private set; }


        public MainViewModel()
        {
            difficultyViewModel = new DifficultySelectionViewModel();
            gameViewModel = new GameViewModel();
        }


        public MainViewModel(int dif)
        {
            difficultyViewModel = new DifficultySelectionViewModel();
            gameViewModel = new GameViewModel(dif);
        }


    }
}
