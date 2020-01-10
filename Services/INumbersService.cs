using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluestoneApi.Services
{
    public interface INumbersService
    {
        List<int> ExtractNumbers(string numbers);
        List<int> SortNumbers(List<int> numbers);
        List<int> FilterNumbers(List<int> numbers);
    }
}
