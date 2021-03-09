using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace BranchInsuranceRating
{
    public class JsonBranchResultSerializer
    {
        public List<BranchResult> GetBranchResultFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<List<BranchResult>>(jsonString, new StringEnumConverter());
        }
    }
}
