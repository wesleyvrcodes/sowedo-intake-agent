namespace SowedoIntakeAgent.Models;

public class ChatMessage
{
    public string Role { get; set; } = "user";
    public string Content { get; set; } = "";
    public DateTime Timestamp { get; set; } = DateTime.Now;
}

public class IntakeSummary
{
    public string CompanyName { get; set; } = "";
    public string ContactName { get; set; } = "";
    public string ContactEmail { get; set; } = "";
    public string ContactPhone { get; set; } = "";
    public string Industry { get; set; } = "";
    public string CompanySize { get; set; } = "";
    public string ProblemAnalysis { get; set; } = "";
    public string RecommendedSolution { get; set; } = "";
    public string Complexity { get; set; } = ""; // simpel/gemiddeld/complex
    public int FeasibilityScore { get; set; }
    public int ImpactScore { get; set; }
    public int UrgencyScore { get; set; }
    public int OverallLeadScore { get; set; }
    public string NextSteps { get; set; } = "";
    public string Budget { get; set; } = "";
}

public class IntakeResult
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CompanyName { get; set; } = "";
    public string ContactName { get; set; } = "";
    public string ContactEmail { get; set; } = "";
    public string ContactPhone { get; set; } = "";
    public string Industry { get; set; } = "";
    public string CompanySize { get; set; } = "";
    public string Budget { get; set; } = "";
    public string ProblemAnalysis { get; set; } = "";
    public string RecommendedSolution { get; set; } = "";
    public string Complexity { get; set; } = "";
    public int FeasibilityScore { get; set; }
    public int ImpactScore { get; set; }
    public int UrgencyScore { get; set; }
    public int OverallLeadScore { get; set; }
    public string NextSteps { get; set; } = "";
    public DateTime CompletedAt { get; set; } = DateTime.Now;
    public List<ChatMessage> Transcript { get; set; } = new();

    public string LeadStatus => OverallLeadScore >= 7 ? "Hot" : OverallLeadScore >= 4 ? "Warm" : "Cold";

    public static IntakeResult FromSummary(IntakeSummary summary, List<ChatMessage> transcript)
    {
        return new IntakeResult
        {
            CompanyName = summary.CompanyName,
            ContactName = summary.ContactName,
            ContactEmail = summary.ContactEmail,
            ContactPhone = summary.ContactPhone,
            Industry = summary.Industry,
            CompanySize = summary.CompanySize,
            Budget = summary.Budget,
            ProblemAnalysis = summary.ProblemAnalysis,
            RecommendedSolution = summary.RecommendedSolution,
            Complexity = summary.Complexity,
            FeasibilityScore = summary.FeasibilityScore,
            ImpactScore = summary.ImpactScore,
            UrgencyScore = summary.UrgencyScore,
            OverallLeadScore = summary.OverallLeadScore,
            NextSteps = summary.NextSteps,
            Transcript = transcript.ToList()
        };
    }
}
