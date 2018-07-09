using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Number_guesser
{
    public class HighscoreViewModel : ObservableObject
    {


        #region Properties

        public ObservableCollection<HighscoreModel> highscores { get; set; }

        #endregion

        #region Constructors

        public HighscoreViewModel()
        {
            ShowDifficultySelectionViewCommand = new DelegateCommand(ShowDifficultySelection);
            ClearHistoryCommand = new DelegateCommand(ClearHighscore);



            highscores = new ObservableCollection<HighscoreModel>();
            ReadFromFile();
        }

        #endregion

        #region Commands

        public DelegateCommand ShowDifficultySelectionViewCommand { get; private set; }
        public DelegateCommand ClearHistoryCommand { get; private set; }

        #endregion

        #region Methods

        public void AddNewHighscore(HighscoreModel highscore)
        {
            highscores.Add(highscore);

            var temp = highscores.OrderByDescending(a => a.PlayedDifficulty).ThenBy(n => n.TryCount);
            highscores = new ObservableCollection<HighscoreModel>(temp);

            SaveToFile(highscore);


        }
        public void ClearHighscore()
        {

            highscores.Clear();

            if (File.Exists("highscores.txt"))
            {
                File.Delete("highscores.txt");
            }
            Application.Current.MainWindow.Content = new HighscoreView();

        }


        public void ShowDifficultySelection()
        {
            Application.Current.MainWindow.Content = new DifficultySelectionView();
            Application.Current.MainWindow.DataContext = new DifficultySelectionViewModel();
        }


        public void ReadFromFile()
        {
            if (File.Exists("highscores.txt"))
            {
                FileStream fs = new FileStream("highscores.txt", FileMode.Open, FileAccess.Read);
                try
                {
                    StreamReader sr = new StreamReader(fs);
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var numbers = line.Split();

                        highscores.Add(new HighscoreModel { PlayedDifficulty = Int32.Parse(numbers[0]), TryCount = Int32.Parse(numbers[1]) });

                    }
                    sr.Close();


                    var temp = highscores.OrderByDescending(a => a.PlayedDifficulty).ThenBy(n => n.TryCount);
                    highscores = new ObservableCollection<HighscoreModel>(temp);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static void SaveToFile(HighscoreModel highscore)
        {
            FileStream fs = new FileStream("highscores.txt",
                FileMode.Append, FileAccess.Write);

            try
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(highscore.PlayedDifficulty + " " + highscore.TryCount);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


        }
        #endregion


    }
}
