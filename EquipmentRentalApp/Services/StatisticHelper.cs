namespace EquipmentRentalApp.Services;

public static class StatisticsHelper
{
    public static double CalculateAverage(int[] values)
    {
        if (values == null || values.Length == 0)
            return 0;

        return values.Average();
    }
}