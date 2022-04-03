using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestAlias = System.String;

namespace Gusev_ITMO_WPF_Lab6
{
    enum rainfallEnum : int
    {
        sunny = 0,
        cloudy = 1,
        rain = 2,
        snow = 3
    }
     class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        
        private string directionOfTheWind;

        public string DirectionOfTheWind;

        private int windSpeed;

        public int WindSpeed;

        private rainfallEnum rainfall;

        public rainfallEnum Rainfall;

        public int Temperature
        {
            get { return (int) GetValue(TemperatureProperty);}
            set { SetValue(TemperatureProperty, value); }
        }

        public WeatherControl(int temperature, string directionOfTheWind, int windSpeed, rainfallEnum rainfall)
        {
            this.Temperature = temperature;
            this.DirectionOfTheWind = directionOfTheWind;
            this.WindSpeed = windSpeed;
            this.Rainfall = rainfall;
        }


        static WeatherControl()
        {
        TemperatureProperty = DependencyProperty.Register(
            "Temperature",
            // nameof(Temperature), //с версии C# 6.0 
            typeof(int),
            typeof(WeatherControl),
            new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.AffectsMeasure |
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
                
        }

        private static bool ValidateTemperature(object value)
        {
 	        int t = (int) value;  
            if(t>=-50 && t<50)
            {
                return true;
            }
            else
            {
            return false;
            }
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
 	        int t = (int) baseValue;
            if(t>=-50)
            {
                return t;
            }
            else
            {
                return 0;
            }
        }
    }
}
