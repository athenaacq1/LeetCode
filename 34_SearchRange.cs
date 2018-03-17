public class Solution {
    public int[] SearchRange(int[] nums, int target) 
    {
        if(nums.Length  == 0)
        {
            return new int[] {-1,-1};
        }
        return GetRange(nums, target, 0, nums.Length-1, false, false);
    }
    
    public int[] GetRange(int[] nums, int target, int startindex, int endindex, bool iamleft, bool iamright)
    {
        if(startindex < 0 || startindex >= nums.Length || endindex >= nums.Length || endindex < 0 || startindex > endindex)
            return new int[] {-1,-1}; 
        int mid = startindex + ((endindex - startindex) / 2);
        Console.WriteLine("s = " + startindex + " e = " + endindex + " m = " + mid);
        if(startindex == endindex)
        {
             if(nums[startindex] == target)
             {
                return new int[] {startindex, startindex};      
             }
             return new int[] {-1, -1};   
        }
            
        if(startindex + 1 == endindex)
        {
            int l = -1;
            int r = -1;
            if(nums[startindex] == target && nums[endindex] == target)
            {
                Console.WriteLine("Rs = " + startindex + "," + endindex);
                return new int[] {startindex, endindex}; 
            }
            else if(nums[startindex] == target)
            {
                l = startindex;
                r = startindex;
            }
            else if(nums[endindex] == target)
            {
                l = endindex;
                r = endindex;
            }
            return new int[] {l, r}; 
        }
        
        
        if(nums[mid] == target)
        {
            if(iamleft)
            {
                var left = GetRange(nums, target, startindex, mid-1, true, false);
                if(left[0] == -1)
                    return new int[] {mid, mid};
                else
                    return left;
            }
            else if(iamright)
            {
                var right = GetRange(nums, target, mid+1, endindex, false, true);
                if(right[1] == -1)
                    return new int[] {mid, mid};
                else
                    return right;
            }
            else
            {
                var left = GetRange(nums, target, startindex, mid-1, true, false);
                Console.WriteLine("left = " + left[0] + "," + left[1]);
                var right = GetRange(nums, target, mid+1, endindex, false, true);
                Console.WriteLine("right = " + right[0] + "," + right[1]);
                int l = -1;
                int r = -1;
                if(left[0] == -1)
                {
                    if(left[1] == -1)
                    {
                        l = mid;    
                    }
                    else
                    {
                        l = left[1];
                    }
                }
                else
                {
                    l = left[0];
                }
                if(right[1] == -1)
                {
                    if(right[0] == -1)
                    {
                        r = mid;    
                    }
                    else
                    {
                        r = right[0];
                    }
                }
                else
                {
                    r = right[1];
                }
                return new int[] {l, r};
            }
        }
        else if(nums[mid] < target)
        {
            return GetRange(nums, target, mid + 1, endindex, iamleft, iamright);
        }
        else
        {
            return GetRange(nums, target, startindex, mid-1, iamleft, iamright);
        }
    }
}