
namespace BranchInsuranceRating
{
    public class RatingEngine
    {

        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        public FileBranchResultSource BranchResultSource { get; set; } = new FileBranchResultSource();


        public JsonBranchResultSerializer BranchResultSerializer { get; set; } = new JsonBranchResultSerializer();

        public double Rating { get; set; } = 5;

        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading data.");

            string jsonData = BranchResultSource.GetBranchResultFromSource();

            var branchResults = BranchResultSerializer.GetBranchResultFromJsonString(jsonData);

            foreach (var branchResult in branchResults)
            {
                switch (branchResult.PolicyType)
                {
                    case PolicyType.Fire:
                        Logger.Log("Rating Fire policy...");
                        Logger.Log("Validating policy.");
                        if (!branchResult.PlanACount.HasValue ||
                            !branchResult.PlanBCount.HasValue ||
                            !branchResult.PlanCCount.HasValue)
                        {
                            Logger.Log("Plan A and Plan B and Plan C Must Have Value");
                            return;
                        }
                        if (branchResult.PlanACount.Value > 5)
                        {
                            Rating += (Rating * 0.2);
                        }

                        if (branchResult.PlanBCount.Value > 4)
                        {
                            Rating += (Rating * 0.4);
                        }

                        if (branchResult.PlanCCount.Value > 3)
                        {
                            Rating += (Rating * 0.6);
                        }

                        break;

                    case PolicyType.Life:
                        Logger.Log("Rating Life policy...");
                        Logger.Log("Validating policy.");
                        if (!branchResult.AgeAverage.HasValue)
                        {
                            Logger.Log("Age Average Must Have Value.");
                            return;
                        }


                        if (branchResult.AgeAverage >= 1 && branchResult.AgeAverage < 20)
                        {
                            Rating += (Rating * 0.6);
                        }
                        else if (branchResult.AgeAverage >= 20 && branchResult.AgeAverage < 30)
                        {
                            Rating += (Rating * 0.4);
                        }
                        else
                        {
                            Rating += (Rating * 0.2);
                        }
                        break;

                    case PolicyType.ThirdParty:
                        Logger.Log("Rating ThirdParty policy...");
                        Logger.Log("Validating policy.");
                        if (!branchResult.CarCount.HasValue ||
                            !branchResult.TruckCount.HasValue)
                        {
                            Logger.Log("Third Party Policy Must Have Car Count and Truck Count");
                            return;
                        }
                        if (branchResult.CarCount.Value > 5)
                        {
                            Rating += (Rating * 0.2);
                        }

                        if (branchResult.TruckCount.Value > 3)
                        {
                            Rating += (Rating * 0.4);
                        }
                        break;

                    default:
                        Logger.Log("Unknown policy type");
                        break;
                }
            }

            

            Logger.Log("Rating completed.");
        }
    }
}
