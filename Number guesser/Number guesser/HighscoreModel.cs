using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_guesser
{
    public class HighscoreModel
    {
        #region Fields

        private int _tryCount;
        private int _playedDifficulty;

        #endregion

        #region Properties

        public int TryCount
        {
            get { return _tryCount; }
            set { _tryCount = value; }
        }

        public int PlayedDifficulty
        {
            get { return _playedDifficulty; }
            set { _playedDifficulty = value; }
        }

        #endregion


    }
}
