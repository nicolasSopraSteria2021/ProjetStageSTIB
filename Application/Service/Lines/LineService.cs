using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Lines
{
    public class LineService : ILineService
    {
        //declaration du repository
        private readonly ILineRepository _LineRepository;

        //constructeur permettant d'initialiser le repositories
        public LineService(ILineRepository lineRepository)
        {
            _LineRepository = lineRepository;

        }

        public DtoDetailsWeather getDetailsFromDate(string vehiculeType,string value)
        {
            return _LineRepository.getDetailsFromDate(vehiculeType,value);
        }


      
        ///<param name="lineNumber">attribut de type int : permet d'identifier le numéro de ligne </param> 
        /// <param name="vehiculeType">attribut de type string, exemple Bus</param> 
        /// <param name="monthNumber">attribut de type string, exemple Feb 2021</param> 
        /// <returns>retourne une liste de DtoDelayByHourBarChart </returns> 
       public IEnumerable<DtoDelayByHourBarChart> GetDelayByHourBarChart(int lineNumber, string vehiculeType, string monthNumber)
        {
            return _LineRepository.getDelayByHourBarChart(lineNumber,vehiculeType,monthNumber);
        }

        public IEnumerable<DtoLineForChart> getLineForCharts(string vehiculeType, string value)
        {
            return _LineRepository.GetLineForChart(vehiculeType, value);
        }

        public IEnumerable<string> GetMonthFromDb()
        {
            return _LineRepository.GetMonthFromDb();
        }

        public IEnumerable<int> getNumberLineByCategory(string vehiculeType)
        {
            return _LineRepository.GetNumberOfLine(vehiculeType);
        }

        public IEnumerable<int> GetYearsFromDb()
        {
            return _LineRepository.GetYearsFromDb();
        }

        // recupere le nombre de retard de chaque vehicule par l'intermediaire du repository
        public int GetCountBusTrackingVehicule(string dateObser)
        {
            return _LineRepository.GetCountDelayBus(dateObser);
        }

       

        public int GetCountTramTrackingVehicule(string dateObser)
        {
            return _LineRepository.GetCountDelayTram(dateObser);
        }
        // recupere le temps de retard de chaque vehicule par l'intermediaire du repository

        // recupere le nombre de non retard de chaque vehicule par l'intermediaire du repository
        public int GetCountBusNotDelay(string dateObser)
        {
            return _LineRepository.GetCountNotDelayBus(dateObser);
        }

        public int GetCountTramNotDelay(string dateObser)
        {
            return _LineRepository.GetCountNotDelayTram(dateObser);
        }

  
        public IEnumerable<DtoSpecificTableDateObservation> GetDayByMonth(string vehiculeType, int value, string monthValue)
        {
            return _LineRepository.GetDayByMonth(vehiculeType, value, monthValue);
        }


        //renvoie le nombre de retard ainsi que la date en fonction du numero definissant le type de vehicule
        public IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(string vehiculeType, string value)
        {
            return _LineRepository.GetInfoForTable(vehiculeType, value);
        }
        //renvoie toutes les infos nécessaires a propos de la ligne la plus en retards
        public DtoQueryMostDelay GetInfoForMostDelay(string vehiculeType, string value)
        {
            return _LineRepository.GetInfoForMostDelay(vehiculeType, value);
        }
    }
}
