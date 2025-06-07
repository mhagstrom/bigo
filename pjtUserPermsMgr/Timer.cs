using System.Diagnostics;

namespace pjtUserPermsMgr;
public class OperationTimer : IDisposable
{
    private readonly string _operationName;
    private readonly int _operationItems;
    private readonly Stopwatch _stopwatch;
    private readonly string _logFilePath;
    private static readonly object _lockObject = new object();

    public OperationTimer(string operationName, int operationItems)
    {
        _operationName = operationName;
        _operationItems = operationItems;
        _stopwatch = Stopwatch.StartNew();
        _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "operation_timings.log");
    }

    public void Dispose()
    {
        _stopwatch.Stop();
        var elapsed = _stopwatch.Elapsed;
        var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - {_operationName} with {_operationItems} items took {elapsed.TotalMilliseconds:F2}ms";
        
        lock (_lockObject)
        {
            File.AppendAllLines(_logFilePath, new[] { logMessage });
        }
    }
}