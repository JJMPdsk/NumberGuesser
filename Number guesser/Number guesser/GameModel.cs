using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_guesser
{
    public class GameModel : ObservableObject
    {

        #region Fields

        private int _myNumber;
        private int numberToGuess;
        private int _difficulty;
        
        #endregion

        #region Properties

        public int MyNumber
        {
            get { return _myNumber; }
            set
            {
                _myNumber = value;
                OnPropertyChangedEvent("MyNumber");
            }
        }

        public int NumberToGuess
        {
            get { return numberToGuess; }
            set { numberToGuess = value; }
        }

        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;

                Random rnd = new Random();


                switch (_difficulty)
                {
                    case 0: //lemme win
                        numberToGuess = 3;
                        break;
                    case 1: //easy
                        numberToGuess = rnd.Next(0, 10);
                        break;
                    case 2: //normal
                        numberToGuess = rnd.Next(0, 25);
                        break;
                    case 3: //hard
                        numberToGuess = rnd.Next(0, 60);
                        break;
                    case 4: //impossible
                        numberToGuess = rnd.Next(0, 200);
                        break;
                }
            }
        }

        #endregion

        #region Constructors

        public GameModel()
        {
            MyNumber = 3;
        }

        public GameModel(int dif)
        {
            MyNumber = 3;
            Difficulty = dif;
        }

        #endregion

        #region Methods

        public void IncrementMyNumber() => MyNumber++;
        public void DecrementMyNumber()
        {
            if (MyNumber > 0)
                MyNumber--;
        }
        public bool Check()
        {
            if(MyNumber == numberToGuess )
                return true;
            return false;
        }
       
        #endregion
    }
}
