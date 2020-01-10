using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickupDropoffService.Models;

namespace PickupDropoffService
{
    public static class MyExtensions
    {
        public static string GetAllAddresses(this List<CarLocation> carLocations)
        {
            string result = $"{carLocations[0].Address},{carLocations[0].City}";

            foreach (var carLocation in carLocations)
            {
                if (result != $"{carLocation.Address},{carLocation.City}")
                {
                    result += $"|{carLocation.Address},{carLocation.City}";
                }
            }

            return result;
        }
    }
}
