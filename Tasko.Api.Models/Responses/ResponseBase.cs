using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tasko.Api.Models.Responses
{
  /// <summary>
  /// This class has the global pattern of server responses. All responses inherits of this class.
  /// </summary>
  public abstract class ResponseBase
  {
    private readonly IList<object> _results;

    public bool IsSuccess { get; }

    public string? Message { get; }

    public int Total { get; }

    public IReadOnlyCollection<object>? Results => _results.ToList();

    protected ResponseBase(bool isSuccess, string message)
    {
      IsSuccess = isSuccess;
      Message = message;
      _results = new List<object>();
      Total = _results.Count;
    }

    public void AddResult(object result)
    {
      _results.Add(result);
    }

    public void AddResult(IList<object> results)
    {
      _results.ToList().AddRange(results);
    }

    public override string ToString()
    {
      return JsonSerializer.Serialize(this);
    }
  }
}