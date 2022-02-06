using CleanMOQasine.API.Models.Inputs;

namespace CleanMOQasine.API.Models.Outputs
{
    public class UserOutputModel : UserInputModel
    {
        public double? Rank { get; set; }
        public List<int>? OrderIds { get; set; }
    }
}
