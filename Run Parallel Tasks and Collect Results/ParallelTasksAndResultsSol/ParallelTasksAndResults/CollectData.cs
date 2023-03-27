using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTasksAndResults
{
    internal abstract class CollectData
    {
        public abstract Task<ResultsData> CollectDataAsync();
    }
}
