namespace Entities.RequestFeatures
{
    public class MealParameters :RequestParameters//FİLTRELEME
    {
        public uint MinCookingTime { get; set; }
        public uint MaxCookingTime { get; set; } = 1000;
        public bool ValidCookingTimeRange => MaxCookingTime>MinCookingTime ;

        public String? SearchTerm { get; set; }

    }
}
