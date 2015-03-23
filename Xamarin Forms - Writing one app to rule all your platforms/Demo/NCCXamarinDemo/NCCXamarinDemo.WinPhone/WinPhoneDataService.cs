using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCCXamarinDemo.WinPhone;
using Xamarin.Forms;

[assembly: Dependency(typeof(WinPhoneDataService))]

namespace NCCXamarinDemo.WinPhone
{

	class WinPhoneDataService : IDataService
	{
		readonly string scoreFilePath;

		public WinPhoneDataService()
		{
			scoreFilePath = "ScoreData";
		}
		public string GetScoreData()
		{
			if (System.IO.File.Exists(scoreFilePath))
			{
				using (var tr = System.IO.File.OpenText(scoreFilePath))
				{
					return tr.ReadToEnd();
				}
			}

			return "{}";
		}

		public void SetScoreData(string data)
		{
			using (var tw = System.IO.File.CreateText(scoreFilePath))
			{
				tw.Write(data);
			}
		}
	}

}
