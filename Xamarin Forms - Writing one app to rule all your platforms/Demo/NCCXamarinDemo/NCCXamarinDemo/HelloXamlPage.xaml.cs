using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NCCXamarinDemo
{
	public partial class HelloXamlPage : ContentPage
	{
		public HelloXamlPage()
		{
			InitializeComponent();
		}

		private void ViewMessageClicked(object sender, EventArgs e)
		{
			message.Text = "Hello <Conference> Developers (with XAML)!";
		}
	}
}
