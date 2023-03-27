
namespace ParallelTasksAndResults
{
    internal class CollectDataA : CollectData
    {
        public override async Task<ResultsData> CollectDataAsync()
        {
            await Task.Delay(1000);
            return new ResultsData
            {
                SearchType = "A",
                NumberOfResults = 100
            };
        }
    }
}
