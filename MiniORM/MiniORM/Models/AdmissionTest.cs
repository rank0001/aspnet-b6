using System;

namespace MiniORM.Models
{
    public class AdmissionTest: BaseId, IId
    {

        public new int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TestFees { get; set; }
    }
}