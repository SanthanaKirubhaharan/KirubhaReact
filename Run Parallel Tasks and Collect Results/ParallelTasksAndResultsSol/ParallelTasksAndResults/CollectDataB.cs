
namespace ParallelTasksAndResults
{
    internal class CollectDataB : CollectData
    {
        public override async Task<ResultsData> CollectDataAsync()
        {
            await Task.Delay(1000);
            return new ResultsData
            {
                SearchType = "B",
                NumberOfResults = 200
            };
        }
    }
}
