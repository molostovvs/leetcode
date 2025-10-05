namespace _1672._Richest_Customer_Wealth;

public class Solution
{
    public int MaximumWealth(int[][] accounts)
        => accounts.Select(customer => customer.Sum()).Max();
}