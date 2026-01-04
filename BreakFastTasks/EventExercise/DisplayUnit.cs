using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakFastTasks.EventExercise
{
	internal class DisplayUnit
	{

		public void DisplayTemp(object sender, TempertureEventArgs e)
		{
			Console.WriteLine($"Temp:{e.temperature} at {e.eventTime}");
			if (sender is WaterHeater w)
			{
				Console.WriteLine($"location:{w.location}");
			}
		}
	}
}
