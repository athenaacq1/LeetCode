public class Solution {
    public void NextPermutation(int[] nums) 
    {
        if(nums == null || nums.Length == 0 || nums.Length == 1)
        {
            return;
        }
        var l = nums.Length;
        var curr = nums[l-1];
        var startIndex = 0;
        for(int i = l-2;i>=0;i--)
        {
            if(curr > nums[i])
            {
                var next = nums[i];
                bool sf = false;
                int sfl = -1;
                if(i+2<l) //curr = nums[i+1]
                {
                    Console.WriteLine("h1");
                    var s = int.MaxValue;
                    if(i+2 == l-1)
                    {
                        if(nums[i+2] > next)
                        {
                            s = nums[i+2];
                            sf = true;
                            sfl = i+2;    
                        }
                    }
                    else
                    {
                        for(int j = i+2;j<l;j++)
                        {
                            if(nums[j] > next && nums[j] <= s)
                            {
                                s = nums[j];
                                sf = true;
                                sfl = j;
                            }
                        }
                    }
                    
                    if(sf)
                    {
                        nums[i] = s;
                        nums[sfl] = next;
                        startIndex = i+1;
                    }
                }
                if(!sf)
                {
                    Console.WriteLine("h2");
                    nums[i] = curr;
                    nums[i+1] = next;
                    startIndex = i+1;
                    if(i+2<l)
                    {
                        var s = nums[i+1];
                        for(int j=i+2;j<l;j++)
                        {
                            if(nums[j] > s)
                            {
                                nums[j-1] = nums[j];
                            }
                            else
                            {
                                nums[j-1] = s;
                                break;
                            }
                        }
                    }
                }
                break;
            }
            else
            {
                curr = nums[i];
            }
        }
        var la = l-startIndex;
        Console.WriteLine(String.Join("-", nums));
        for(int i=0;i<la/2;i++)
        {
                curr = nums[startIndex+i];
                nums[startIndex+i] = nums[l-i-1];
                nums[l-i-1] = curr;
        }
    }
}