using InvoPassport.Model.Models;

namespace InvoPassport.Models.Models
{
    public  class Result
    {
        public Guid Id { get; set; }
        public DateTime? Test_Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? CorrectAnswer { get; set; }
        public int? TotalQuestion { get; set; }
        public bool? CurrentState { get; set; }
        public Guid? UserId { get; set; }
        public Users? User { get; set; }
        public List<ResultAnswer>? ResultAnswer { get; set; }
    }
}
