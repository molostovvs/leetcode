/*// with array [O(n), O(n)]
public class ParkingSystem
{
    private int[] _parking = new int[4];

    public ParkingSystem(int big, int medium, int small)
    {
        _parking[1] = big;
        _parking[2] = medium;
        _parking[3] = small;
    }

    public bool AddCar(int carType)
    {
        if (_parking[carType] > 0)
        {
            _parking[carType]--;
            return true;
        }

        return false;
    }
}*/

// [O(n), O(1)]
public class ParkingSystem
{
    private int _bigSpace;
    private int _mediumSpace;
    private int _smallSpace;

    public ParkingSystem(int big, int medium, int small)
    {
        _bigSpace = big;
        _mediumSpace = medium;
        _smallSpace = small;
    }

    public bool AddCar(int carType)
    {
        if (carType == 1 && _bigSpace > 0)
        {
            _bigSpace--;
            return true;
        }

        if (carType == 2 && _mediumSpace > 0)
        {
            _mediumSpace--;
            return true;
        }

        if (carType == 3 && _smallSpace > 0)
        {
            _smallSpace--;
            return true;
        }

        return false;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */