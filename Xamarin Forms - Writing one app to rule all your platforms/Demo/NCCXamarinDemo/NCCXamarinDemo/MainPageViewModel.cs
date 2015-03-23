using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NCCXamarinDemo
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public Random RandomNumberMachine { get; set; }
		public string ResultMessage { get; set; }


		public string CurrentValue
		{
			get { return LastValue.ToString(); }
		}
		public string CurrentScore
		{
			get { return string.Format("{0} of {1} correct", CorrectGuesses, TotalGuesses); }
		}


		private Scores Scores { get; set; }

		public int CorrectGuesses
		{
			get { return Scores.CorrectGuesses; }
			set { Scores.CorrectGuesses = value; }
		}

		public int TotalGuesses
		{
			get { return Scores.TotalGuesses; }
			set { Scores.TotalGuesses = value; }
		}

		public int LastValue
		{
			get { return Scores.LastValue; }
			set { Scores.LastValue = value; }
		}


		public MainPageViewModel()
		{
			RandomNumberMachine = new Random();
			var ds = DependencyService.Get<IDataService>();
			Scores = Newtonsoft.Json.JsonConvert.DeserializeObject<Scores>(ds.GetScoreData());

		}

		private Command guessHighCommand;
		public ICommand GuessHighCommand
		{
			get
			{
				return guessHighCommand ??
				(guessHighCommand = new Command(ExecuteGuessHigh));
			}
		}

		private void ExecuteGuessHigh()
		{
			var nextNumber = GetNextNumber(); //RandomNumberMachine.Next(0, 10);
			var success = LastValue < nextNumber;
			ShowResult(nextNumber, success);
		}

		private Command guessLowCommand;
		public ICommand GuessLowCommand
		{
			get
			{
				return guessLowCommand ??
				(guessLowCommand = new Command(ExecuteGuessLow));
			}
		}

		private void ExecuteGuessLow()
		{
			var nextNumber = GetNextNumber(); //RandomNumberMachine.Next(0, 10);
			var success = LastValue > nextNumber;
			ShowResult(nextNumber, success);
		}

		private int GetNextNumber()
		{
			var nextNumber = LastValue;
			while (nextNumber == LastValue)
			{
				nextNumber = RandomNumberMachine.Next(0, 10);
			}
			return nextNumber;
		}

		public void ShowResult(int nextNumber, bool success)
		{
			CorrectGuesses += success ? 1 : 0;
			TotalGuesses++;
			Scores.LastValue = nextNumber;

			var ds = DependencyService.Get<IDataService>();
			ds.SetScoreData(Newtonsoft.Json.JsonConvert.SerializeObject(Scores));

			ResultMessage = success ? "You Guessed Correct!" : "Wrong Answer!";
			PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
		}
	}

}
