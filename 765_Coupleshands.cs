public class Solution {
    public int MinSwapsCouples(int[] row) 
    {
        if(row == null || row.Length == 0)
            return 0;
        var dpmat = new int[row.Length/2];     
        for(int i = 0; i < row.Length/2; i++)
        {
            dpmat[i] = -1;
        }
        var loc = new Dictionary<int,int>();
        for(int i = 0; i < row.Length; i++)
        {
            loc.Add(row[i],i);
        }
        return Swap(row, 0, loc, dpmat);
    }
    
    public int Swap(int[] row, int i, Dictionary<int,int> dict, int[] dpmat)
    {
        if(i+2 > row.Length)
            return 0;
        
        if(dpmat[i/2] != -1)
            return dpmat[i/2];
        
        var v1 = int.MaxValue;
        var v2 = int.MaxValue;
        
        if( (row[i] %2 == 1 && row[i+1] == row[i] - 1) 
           || (row[i] %2 == 0 && row[i+1] == row[i] + 1))
        {
            v1 = Swap(row, i+2, dict, dpmat);
        }
        else
        {
            var nr = (int[]) row.Clone();
            var cand = -1;
            if(row[i] % 2 == 0)
            {
                cand = row[i] + 1;
            }
            else
            {
                cand = row[i] - 1;
            }
            var l = dict[cand];
            var tmp = nr[i+1];
            nr[i+1] = nr[l];
            nr[l] = tmp;
            dict[cand] = i+1;
            dict[tmp] = l;
            v2 = 1 + Swap(nr, i+2, dict, dpmat);
        }
        
        dpmat[i/2] = v1 < v2 ? v1 : v2;
        return dpmat[i/2];
    }
}