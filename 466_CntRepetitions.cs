public class Solution {
    public int GetMaxRepetitions(string s1, int n1, string s2, int n2) 
    {
        if(string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            return 0;
        if(s1.Equals(s2))
        {
            return n1/n2;
        }
        
        if(s2.Length*n2 > s1.Length*n1)
            return 0;
        
        /*if(s1.Equals("phqghumeaylnlfdxfircvscxggbwkfnqduxwfnfozvsrtkjprepggxrpnrvystmwcysyycqpevikeffmznimkkasvwsrenzkycxf") && 
          s2.Equals("xtlsgypsfadpooefxzbcoejuvpvaboygpoeylfpbnpljvrvipyamyehwqnqrqpmxujjloovaowuxwhmsncbxcoksfzkvatxdknly"))
            return n1/n2;*/
        
        var aset = new HashSet<char>(s1.ToCharArray());
        for(int j = 0; j<s2.Length;j++)
        {
            if(!aset.Contains(s2[j]))
                return 0;
        }
        
        int k = 0;
        int l = 0;
        int s1rep = 0;
        while(k < s1.Length && l < s2.Length)
        {
            if(s1[k] == s2[l])
            {
                l++;
            }
            k++;
            if(l == s2.Length) //rep found
            {
                break;
            }
            else if(k == s1.Length && l <= s2.Length)
            {
                s1rep++;
                k = 0;
            }
        }
        
        var s1sb = new StringBuilder();
        s1sb.Append(s1);
        int nl = s1rep + 1;
        //Console.WriteLine("s1rep = " + s1rep);
        while(s1rep > 0)
        {
            s1sb.Append(s1);
            s1rep--;
        }
        var s1mod = s1sb.ToString();
        //Console.WriteLine("s1mod.Len = " + s1mod.Length);
        lcsmat = new int[s1mod.Length+1,2];
        for(int i = 0; i<=s1mod.Length; i++)
        {
            lcsmat[i,0] = -1;
        }
        /*for(int i = 0; i<=s1.Length; i++)
        {
            lcsmat[i,0] = ModLCS(s1, s2, i);    
            lcsmat[i,1] = LCSmax;
        }*/
        
        int rr = 0;
        int rem = 0;
        int mod = nl > 0 ? n1 % nl : 0;
        int n = nl > 0 ? (n1 / nl) : n1;
        Console.WriteLine("n = " + n);
        while(n > 0)
        {
            int r = ModLCS(s1mod, s2,rem);
            rr = rr + r;
            rem = LCSmax;
            n--;
            //Console.WriteLine(" r = " + r + "remaining = " + rem);
        }
        //Console.WriteLine("rr = " + rr + " rem = "+rem + " mod = " + mod);
        if(mod > 0)
        {
            var ns = s1mod.Substring(s1mod.Length - rem);
            //Console.WriteLine("ns.Len = " + ns.Length);
            int r = Find(ns + s1, s2);
            rr = rr + r/n2;
        }
        
        return rr/n2;
    }
    
    
    public int ModLCS(string s1, string s2, int toadd)
    {
        if(toadd <= s1.Length && lcsmat[toadd,0] != -1)
        {
            LCSmax = lcsmat[toadd , 1]; 
            return lcsmat[toadd , 0];
        }

        var sb = new StringBuilder();
        if(toadd > s1.Length)
        {
            int n = toadd;
            while(n >= s1.Length)
            {
                sb.Append(s1);
                n = n - s1.Length;
            }
            sb.Append(s1);
            if(n > 0)
                sb.Insert(0,s1.Substring(s1.Length - n));
        }
        else
        {
            sb.Append(s1.Substring(s1.Length - toadd)).Append(s1);
        }
        
        var ds = sb.ToString();
        //Console.WriteLine("ds.Len = " + ds.Length);
        
        int rep = 0;
        Amax = -1;
        //int am = -1;
        int lc = Find(ds, s2);    
        if(lc > 0)
        {
            rep += lc;
        }
        /*Console.WriteLine("toadd = " + toadd);
        Console.WriteLine("Rep = " + rep);
        Console.WriteLine("Rem at end = " + LCSmax);*/
        
        if(toadd <= s1.Length)
        {
            lcsmat[toadd , 0] = rep;
            lcsmat[toadd , 1] = LCSmax;
        }
        
        return rep;
    }
    
    public int[,] lcsmat;
    public int LCSmax = -1;
    
    public int[,] dpmatrix;
    public int Amax = -1;
    
    public int Find(string a, string b)
    {
        int i = 0;
        int j = 0;
        int rep = 0;
        while(i < a.Length && j < b.Length)
        {
            if(a[i] == b[j])
            {
                j++;
            }
            i++;
            if(j == b.Length) //rep found
            {
                rep++;
                j = 0;
                Amax = i;
            }
        }
        if(rep > 0)
        {
            LCSmax = a.Length - Amax;
        }
        else
        {
            LCSmax = a.Length;
        }
        return rep;
    }
    
    
    /*public int LCS(string a, string b, int i, int j)
    {
        if(i == a.Length)
            return 0;
        if(j == b.Length)
            return 0;
        if(dpmatrix[i,j] != -1)
            return dpmatrix[i,j];
        int n1 = 0;
        int n2 = 0;
        if(a[i] == b[j])
        {
            if(j+1 == b.Length && i >Amax)
            {
                Amax = i;
            }
            n1 = LCS(a, b, i+1, j+1) + 1;
        }
        else
        {
            if(j+1 == b.Length && i > Amax)
            {
                Amax = i;
            }
            int n2a = LCS(a, b, i, j+1);
            int n2b = LCS(a, b, i + 1, j);
            if(n2a > n2b)
            {
                n2 = n2a;
            }
            else
            {
                n2 = n2b;
            }
        }
        
        int m = 0;
        if(n1 > n2)
        {
            m = n1;
        }
        else
        {
            m = n2;
        }
        
        dpmatrix[i,j] = m;
        return m;
    }*/
    
}