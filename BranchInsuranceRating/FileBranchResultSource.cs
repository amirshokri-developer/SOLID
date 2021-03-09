using System.IO;

namespace BranchInsuranceRating
{
    public class FileBranchResultSource
    {
        public string GetBranchResultFromSource()
        {
            return File.ReadAllText("data.json");
            
        }
    }
}
