namespace _1779._Find_Nearest_Point_That_Has_the_Same_X_or_Y_Coordinate;

public class Solution
{
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        (int distance, int index) currentNearestPoint = (int.MaxValue, -1);
        for (var i = 0; i < points.Length; i++)
        {
            var x1 = points[i][0];
            var y1 = points[i][1];
            if (x1 == x || y1 == y)
            {
                var distance = Math.Abs(x1 - x) + Math.Abs(y1 - y);
                if (distance < currentNearestPoint.distance)
                    currentNearestPoint = (distance, i);
            }
        }

        return currentNearestPoint.index;
    }
}