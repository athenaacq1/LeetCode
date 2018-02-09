public class Solution {
    public int[] AsteroidCollision(int[] asteroids) 
    {
        if(asteroids == null)
            return new int[0];
        if(asteroids.Length == 0)
            return new int[0];
        if(asteroids.Length == 1)
            return asteroids;
        
        bool[] dead = new bool[asteroids.Length];
        Divide(asteroids, dead, 0, asteroids.Length-1);
        
        List<int> left = new List<int>();
        for(int i = 0; i<asteroids.Length;i++)
        {
            if(!dead[i])
                left.Add(asteroids[i]);
        }
        return left.ToArray();
    }
    
    public void Divide(int[] asteroids, bool[] dead, int start, int end)
    {
        if(start == end)
        {
            ; //all done
        }
        
        else if(start + 1 == end)
        {
            Merge(asteroids, dead, start, start, end);
        }
        else
        {
            int mid = start + ((end - start) / 2);
        Divide(asteroids, dead, start, mid);
        Divide(asteroids, dead, mid+1, end);
        Merge(asteroids, dead, start, mid, end);        
        }
    }
    
    public void Merge(int[] asteroids, bool[] dead, int start, int mid, int end)
    {
        /*if(mid == 6)
        {
            Console.WriteLine("start = " + start + " end = " + end);
            Console.WriteLine(String.Join(" ", asteroids));
            Console.WriteLine(String.Join(" ", dead.Select(x => (x == true? "t" : "f"))));
        }*/
        int leftindex = mid;
        int rightindex = mid+1;
        while(leftindex >= start && rightindex <= end) 
        {
            if(dead[leftindex])
            {
                leftindex --;
            }
            else if(dead[rightindex])
            {
                rightindex++;
            }
            else 
            {
                if(asteroids[leftindex] > 0 && asteroids[rightindex] < 0) // collision
                {
                    if(asteroids[leftindex] == -asteroids[rightindex])
                    {
                
                        dead[leftindex] = true;
                        dead[rightindex] = true;
                        leftindex--;
                        rightindex++;
                    }
                    else if(asteroids[leftindex] < -asteroids[rightindex])
                    {
                        dead[leftindex] = true;
                        leftindex--;
                    }
                    else
                    {
                    
                        dead[rightindex] = true;
                        rightindex++;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        
    }
}