/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl 
{
    public int FirstBadVersion(int n) 
    {
         return GetBadVersion(n, 1, n);
    }
    
    public int GetBadVersion(int n, int i, int j)
    {
        if(i < 1 || j > n || i > n || j < 1 || i > j)
            return 0;
        if(i == j)
        {
            return IsBadVersion(i) ? i : 0;
        }
        
        if(i + 1 == j)
        {
            if(IsBadVersion(i))
            {
                return i;
            }
            else if(IsBadVersion(j))
            {
                return j;
            }
            return 0;
        }
        int mid = i + ((j-i)/2);   
        if(IsBadVersion(mid))
        {
            return GetBadVersion(n, i, mid);
        }
        else
        {
            return GetBadVersion(n, mid + 1, j);
        }
    }
}