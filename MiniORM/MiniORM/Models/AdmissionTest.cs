using System;

namespace MiniORM.Models
{
    public class AdmissionTest:IId
    {

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TestFees { get; set; }
    }
}