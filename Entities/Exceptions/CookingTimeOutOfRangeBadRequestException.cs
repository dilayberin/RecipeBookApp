namespace Entities.Exceptions
{
    public class CookingTimeOutOfRangeBadRequestException :BadRequestException
    {
        public CookingTimeOutOfRangeBadRequestException()
            : base("Yemek sürelerini çok uzun tutmamaya dikkat edelim..")
        {

        }

    }

}