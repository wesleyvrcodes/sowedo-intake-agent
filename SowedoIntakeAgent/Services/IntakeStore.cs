using SowedoIntakeAgent.Models;

namespace SowedoIntakeAgent.Services;

public class IntakeStore
{
    private readonly List<IntakeResult> _intakes = new();
    private readonly object _lock = new();

    public void Add(IntakeResult result)
    {
        lock (_lock)
        {
            _intakes.Add(result);
        }
    }

    public List<IntakeResult> GetAll()
    {
        lock (_lock)
        {
            return _intakes.OrderByDescending(x => x.OverallLeadScore).ToList();
        }
    }

    public IntakeResult? GetById(Guid id)
    {
        lock (_lock)
        {
            return _intakes.FirstOrDefault(x => x.Id == id);
        }
    }
}
