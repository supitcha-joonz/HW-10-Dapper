

namespace RequestProblem.Models
{
    public class Problems
    {
      public int Id {get; set;}
      public string ProblemName {get; set;}
      public string? Description {get; set;}

      //public Applications? Applications { get; set; }
      public int ApplicationId {get; set;}
    }
}
