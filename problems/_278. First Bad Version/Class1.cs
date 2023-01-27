namespace _278._First_Bad_Version;

public class VersionControl
{
    public bool IsBadVersion(int version)
        => true;
}

/*//first attempt 10 min
public class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        var left = 1;
        var right = n;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (IsBadVersion(mid))
                right = mid - 1;
            else if (!IsBadVersion(mid))
                left = mid + 1;
        }

        return left;
    }
}*/

//second attempt 3min
public class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        var left = 0;
        var right = n;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (IsBadVersion(mid))
                right = mid - 1;
            else
                left = mid + 1;
        }

        return left;
    }
}