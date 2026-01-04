using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakFastTasks.EventExercise
{
	internal class AlarmSystem
	{
		public void DisplayAlert(object sender, EventArgs e)
		{
			if (sender is WaterHeater w)
			{
				Console.WriteLine("Target Temperature Reached! Alarm Activated!");

				Console.WriteLine($"current Temperture in Fahrenheit:{w.TempInFahrenheit}");
				Console.WriteLine($"location:{w.location}");
			}
			if(sender is House h)
				Console.WriteLine("Open door on House");

		}
	}
}
