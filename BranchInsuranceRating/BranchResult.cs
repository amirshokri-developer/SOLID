namespace BranchInsuranceRating
{
    public class BranchResult
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public PolicyType PolicyType { get; set; }                

        //Third Party
        public int? CarCount { get; set; }

        public int? TruckCount { get; set; }

        
        //Life
        public int? AgeAverage { get; set; }


        //Fire
        public int? PlanACount { get; set; }

        public int? PlanBCount { get; set; }

        public int? PlanCCount { get; set; }
    }
}
