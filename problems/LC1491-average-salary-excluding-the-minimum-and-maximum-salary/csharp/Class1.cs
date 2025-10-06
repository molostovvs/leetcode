namespace _1491._Average_Salary_Excluding_the_Minimum_and_Maximum_Salary;

public class Solution
{
    public double Average(int[] salary)
    {
        return salary.OrderBy(i => i).Skip(1).SkipLast(1).Average();
    }
}