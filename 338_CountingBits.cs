public class Solution {
    public int[] CountBits(int n) 
    {
        if(n == 0)
		    return new int[] {0};
	    if (n == 1)
		    return new int[] {0,1};
	
	int[] result = new int[n+1];
	int limit = 1;
	int ptr = 0;
	result[0] = 0;
	result[1] = 1;
	for(int i=2;i<=n;i++)
	{
		if(ptr == limit + 1)
		{ 
			ptr = 0;
			limit = i-1;
		}

		result[i] = 1 + result[ptr];
		ptr++;	
		
	}
        return result;
    }
}