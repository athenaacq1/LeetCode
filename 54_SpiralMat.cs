public class Solution {
    public IList<int> SpiralOrder(int[,] matrix) 
    {
        var result = new List<int>();
        int N = matrix.GetLength(0) * matrix.GetLength(1);
        
        int starti = 0; 
        int startj = 0;
        int endi = matrix.GetLength(1);
        int endj = 0;
        int rows = 0;
        int cols = 0; 
        bool right = true;
        bool down = true;
        while(result.Count() < N)
        {
            if(starti == endi)
            {
                if(down)
                {
                    for(int j = startj; j < endj; j++)
                    {   
                        result.Add(matrix[j,starti]);
                    }    
                    down = false;
                    startj = endj - 1;
                    endj = endj - 1;
                    starti = starti - 1;
                    endi = cols/2 -1;
                    //Console.WriteLine("c = " + result.Count() + " last = " + result[result.Count() - 1]);
                }
                else
                {
                    for(int j = startj; j > endj; j--)
                    {   
                        result.Add(matrix[j,starti]);
                    }
                    down = true;
                    startj = endj + 1;
                    endj = endj + 1;
                    starti = starti + 1;
                    endi = matrix.GetLength(1) - cols/2 - 1; 
                    //Console.WriteLine("c = " + result.Count() + " last = " + result[result.Count() - 1]);
                }
                cols++;
            }
            else if(startj == endj)
            {
                if(right)
                {
                    for(int i = starti; i < endi; i++)
                    {
                        result.Add(matrix[startj,i]);
                    }
                    starti = endi - 1;
                    endi = endi - 1;
                    startj = startj + 1;
                    endj = matrix.GetLength(0) - rows/2;
                    right = false;
                    //Console.WriteLine("c = " + result.Count() + " last = " + result[result.Count() - 1]);
                }
                else
                {
                    for(int i = starti; i > endi; i--)
                    {
                        result.Add(matrix[startj,i]);
                    }
                    starti = endi + 1;
                    endi = endi + 1;
                    startj = startj - 1;
                    endj = rows/2;
                    right = true;
                    //Console.WriteLine("c = " + result.Count() + " last = " + result[result.Count() - 1]);
                }
                rows++;
            }
            
        }
        
        return result;
    }
}