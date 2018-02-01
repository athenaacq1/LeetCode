public class Solution {
    public int MaxChunksToSorted(int[] arr) 
    {
        if(arr.Length == 0)
        {
            return 0;
        }
        if(arr.Length == 1)
        {
            return 1;
        }
        
        int[] diff = new int[arr.Length];
        for(int i = 0;i<diff.Length;i++)
        {
            diff[i] = arr[i] - i;
        }
        //Console.WriteLine(String.Join(" ", diff));
        bool startGrp = false;
        int grpStart = -1;
        int grpEnd = -1;
        int grpCnt = 0;
        for(int i = 0; i<arr.Length;i++)
        {
            if(!startGrp)
            {
                if(diff[i] == 0)
                {
                    grpCnt++;
                    //Console.WriteLine("Grp++ at 00 "+i);
                }
                else
                {
                    startGrp = true;
                    grpStart = i;
                    grpEnd = i + diff[i];
                    //Console.WriteLine("grpend = "+grpEnd);
                }
            }
            else
            {
                if(diff[i] + i > grpEnd)
                {
                    grpEnd = i + diff[i];
                }
                else if(i == grpEnd)
                {
                    //end grp
                    grpCnt++;
                    startGrp = false;
                    //Console.WriteLine("Grp++ at "+i);
                }
            }
        }
        return grpCnt;
    }
}