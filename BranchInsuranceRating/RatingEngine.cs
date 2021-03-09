using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;

namespace BranchInsuranceRating
{
    public class RatingEngine
    {

        public double Rating { get; set; } = 5;

        public void Rate()
        {
            Console.WriteLine("Starting rate.");

            Console.WriteLine("Loading data.");

            string jsonData = File.ReadAllText("data.json");

            var branchResults = JsonConvert.DeserializeObject<List<BranchResult>>(jsonData,
                new StringEnumConverter());

            foreach (var branchResult in branchResults)
            {
                switch (branchResult.PolicyType)
                {
                    case PolicyType.Fire:
                        Console.WriteLine("Rating Fire policy...");
                        Console.WriteLine("Validating policy.");
                        if (!branchResult.PlanACount.HasValue ||
                            !branchResult.PlanBCount.HasValue ||
                            !branchResult.PlanCCount.HasValue)
                        {
                            Console.WriteLine("Plan A and Plan B and Plan C Must Have Value");
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
                        Console.WriteLine("Rating Life policy...");
                        Console.WriteLine("Validating policy.");
                        if (!branchResult.AgeAverage.HasValue)
                        {
                            Console.WriteLine("Age Average Must Have Value.");
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
                        Console.WriteLine("Rating ThirdParty policy...");
                        Console.WriteLine("Validating policy.");
                        if (!branchResult.CarCount.HasValue ||
                            !branchResult.TruckCount.HasValue)
                        {
                            Console.WriteLine("Third Party Policy Must Have Car Count and Truck Count");
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
                        Console.WriteLine("Unknown policy type");
                        break;
                }
            }

            

            Console.WriteLine("Rating completed.");
        }
    }
}
