public class Solution {
    public string NextClosestTime(string time) 
    {
        var td = time.Split(new char[] {':'});
        int[] digits = new int[4];
        digits[0] = (int)Char.GetNumericValue(td[0][0]);
        digits[1] = (int)Char.GetNumericValue(td[0][1]);
        digits[2] = (int)Char.GetNumericValue(td[1][0]);
        digits[3] = (int)Char.GetNumericValue(td[1][1]);
        
        if(digits[0] == digits[1] && digits[0] == digits[2] && digits[0] == digits[3])
            return time;
        
        TimeSpan mindiff = new TimeSpan(24,60,60);
        var mstr = string.Empty;
        for(int i = 0; i < digits.Length; i++)
        {
            for(int j = 0; j < digits.Length; j++)
            {
                for(int k = 0; k < digits.Length; k++)
                {
                    for(int l = 0; l < digits.Length; l++)
                    {
                        var minstr = "" + digits[k] + "" + digits[l];
                        var min = int.Parse(minstr);
                        //Console.WriteLine("min = " + min);
                        if(min < 60)
                        {
                            var hrstr = "" + digits[i] + ""  + digits[j];
                            var hr = int.Parse(hrstr);
                            //Console.WriteLine("hr = " + hr);
                            if(hr < 24)
                            {
                                var s = hrstr + ":" + minstr;
                                if(s.Equals(time))
                                    continue;
                                var diff = GetDiff(s, time);
                                //Console.WriteLine("str = " + hrstr + ":" + minstr + " diff = " + diff);
                                if(diff.CompareTo(mindiff) < 0)
                                {
                                    mindiff = diff;
                                    mstr = hrstr + ":" + minstr;
                                }
                                    
                            }
                        }
                    }
                }
            }
        }
        
        return mstr;
    }
    
    public TimeSpan GetDiff(string a, string b)
        {
            var atd = a.Split(new char[] {':'});
            var ahr = int.Parse(atd[0]);
            var amin = int.Parse(atd[1]);
            var btd = b.Split(new char[] {':'});
            var bhr = int.Parse(btd[0]);
            var bmin = int.Parse(btd[1]);
            
            var adt = new DateTime(2018, 04, 02, ahr, amin, 0);
            var bdt = new DateTime(2018, 04, 02, bhr, bmin, 0);
            
            var diff = adt.Subtract(bdt);
            if(diff.Hours < 0 || diff.Minutes < 0)
            {
                adt = new DateTime(2018, 04, 03, ahr, amin, 0);
                diff = adt.Subtract(bdt);
            }
            
            return diff;
        }
    
    
}