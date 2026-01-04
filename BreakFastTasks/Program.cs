using BreakFastTasks.EventExercise;
using CoreCollectionsAsync;
namespace BreakFastTasks

{


    internal class Program
    {
        static async Task Main(string[] args)
        {
            //SimpleBreakfast.MakeBreakfastDemo_1();
             await  SimpleBreakfast.MakeBreakFastDemo2();
			List<WaterHeater> heaters = new List<WaterHeater>();
			WaterHeater heater1 = new WaterHeater { location = "Kitchen" };
			WaterHeater heater2 = new WaterHeater { location = "Bathroom" };
			WaterHeater heater3 = new WaterHeater { location = "Living Room" };
			heaters.Add(heater1);
			heaters.Add(heater2);
			heaters.Add(heater3);
			heater1.OnTemperatureChange += new EventHandler<TempertureEventArgs>(new DisplayUnit().DisplayTemp);
			heater2.OnTemperatureChange += new EventHandler<TempertureEventArgs>(new DisplayUnit().DisplayTemp);
			heater3.OnTemperatureChange += new EventHandler<TempertureEventArgs>(new DisplayUnit().DisplayTemp);
			heater1.TargetReached += new AlarmSystem().DisplayAlert;
			heater2.TargetReached += new AlarmSystem().DisplayAlert;
			heater3.TargetReached += new AlarmSystem().DisplayAlert;
			heater1.StartBoilerAsync(5.0);
			heater2.StartBoilerAsync(10.0);
			heater3.StartBoilerAsync(15.0);
			var onefinished=Task.WhenAny(heater1.CalculateHeatingCostAsync(), heater2.CalculateHeatingCostAsync(), heater3.CalculateHeatingCostAsync());
			await onefinished;
			var Allfinished=Task.WhenAll(heater1.CalculateHeatingCostAsync(), heater2.CalculateHeatingCostAsync(), heater3.CalculateHeatingCostAsync());
			await onefinished;
		}
    }
}