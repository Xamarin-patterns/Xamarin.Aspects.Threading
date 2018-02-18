using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Aspects.Threading;
using Xamarin.Forms;

namespace App10
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		    Test();
		}
	    [ShowLoader]
        [BackgroundThread]
	    public async Task Test()
	    {
	        await Task.Delay(10000);
	       await SetText();
	    }
        [ForegroundThread]
	    private async Task SetText()
	    {
	        Label1.Text = "hello world";
	    }
	}
}
