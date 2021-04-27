using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.NewLine
{
    public interface INewLine
    {
		int id { get; set; }

		string date_observation { get; set; }

		int delays { get; set; }

		string trip_headsign { get; set; }

		string stop_name { get; set; }

		int lineNumber { get; set; }

		string vehiculeType { get; set; }

		double precip1Hour { get; set; }
		double precip24Hour { get; set; }
		double precip6Hour { get; set; }
		double relativeHumidity { get; set; }
		double snow1Hour { get; set; }
		double snow24Hour { get; set; }
		double snow6Hour { get; set; }
		double temperature { get; set; }
		double temperatureDewPo { get; set; }
		double temperatureFeelsLike { get; set; }
		double temperatureMax24Hour { get; set; }
		double temperatureMin24Hour { get; set; }
		double uvIndex { get; set; }
		double visibility { get; set; }
		double windSpeed { get; set; }
		int prediction { get; set; }
	}
}
