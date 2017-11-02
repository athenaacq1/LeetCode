public class Solution {
    public int HammingDistance(int x, int y) 
    {
        int cnt = 0;
        while(x > 0 || y > 0)
        {
            if((x & 1) != (y & 1))
            {
                cnt++;
            }
            x = x >> 1;
            y = y >> 1;
        }
        return cnt;
    }
}
