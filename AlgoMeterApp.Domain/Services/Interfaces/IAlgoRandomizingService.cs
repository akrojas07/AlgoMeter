using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMeterApp.Domain.Services.Interfaces
{
    public interface IAlgoRandomizingService
    {
        Task RandomizeQuestion();
        Task GetRandomizedQuestion();
    }
}
