
public class ArrayAverageCalculator
{
    public float CalculateAverage(float[] numbers)
    {
       float sum = 0;
       int count = numbers.Length;

       for (int i = 0; i < count; i++)
       {
           sum += numbers[i];
       }

       return sum / count;
    }
    
}