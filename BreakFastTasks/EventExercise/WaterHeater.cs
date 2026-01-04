using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BreakFastTasks.EventExercise
{
	internal class WaterHeater
	{
		private double currentTemperature;
		public string location { get; set; }
		public string TempInFahrenheit
		{
			get
			{
				return ((currentTemperature * 9 / 5) + 32).ToString("F2") + " °F";
			}
		}
		public event EventHandler<TempertureEventArgs> OnTemperatureChange;
		public event EventHandler TargetReached;

		public async Task StartBoilerAsync(double temperature)
		{

			while (currentTemperature<temperature)
			{
				await Task.Delay(1500);
				currentTemperature += 0.5;
				OnTemperatureChange?.Invoke(this, new TempertureEventArgs(currentTemperature));
				//if (OnTemperatureChange != null)
				//{
				//	OnTemperatureChange(this, new TempertureEventArgs(currentTemperature));
				//}

			}
			if (TargetReached!=null)
			{
				TargetReached(this, new EventArgs());
			}
		


		}
		public async Task<double> CalculateHeatingCostAsync()
        {
            await Task.Delay(3000);
			Random ran=new Random();
			int num=ran.Next(2,21);
			return num*currentTemperature+(num*currentTemperature*0.18);
        } 
			
		
		}




	
}
