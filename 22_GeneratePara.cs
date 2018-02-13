public class Solution {
    public IList<string> GenerateParenthesis(int n) 
    {
        List<PartialGen> result = new List<PartialGen>{ new PartialGen("", 0, 0) };
        for(int i = 0; i<2*n;i++)
        {
            var newlist = new List<PartialGen>();
            foreach(var item in result)
            {
                if(item.op > item.cp)
                {
                    if(item.op <= n)
                    {
                        var i1 = new PartialGen(item.val + "(", item.op + 1, item.cp);
                        newlist.Add(i1);
                    }
                    var i2 = new PartialGen(item.val + ")", item.op, item.cp + 1);
                    newlist.Add(i2);
                }
                else if(item.op == item.cp)
                {
                    var i1 = new PartialGen(item.val + "(", item.op + 1, item.cp);
                    newlist.Add(i1);
                }
            }
            result = newlist;
        }
        
        return result.Where(x => x.op == x.cp).Select(x => x.val).ToList();
    }
    
    public class PartialGen
    {
        public string val = string.Empty;
        public int op = 0;
        public int cp = 0;
        public PartialGen(string v, int o, int c)
        {
            val = v;
            op = o;
            cp = c;
        }
    }
}