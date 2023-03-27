
using ParallelTasksAndResults;

List<Task<ResultsData>> tasks = new List<Task<ResultsData>>();

tasks.Add(new CollectDataA().CollectDataAsync());
tasks.Add(new CollectDataB().CollectDataAsync());

ResultsData[] results = await Task.WhenAll(tasks);

foreach (ResultsData result in results)
{
    Console.WriteLine($"Search Type: {result.SearchType}, Number of Results: {result.NumberOfResults}");
}

