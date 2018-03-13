public class Trie {

    private TrieNode root = new TrieNode('R');
    
    /** Initialize your data structure here. */
    public Trie() {
        
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        var curr = root;
        //Console.WriteLine("i = " + word);
        foreach(var c in word)
        {
            curr = curr.AddBranchIfAbsent(c);
        }
        curr.isEnd = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        var curr = root;
        //Console.WriteLine("s = " + word);
        for(int i = 0; i <word.Length; i++)
        {
            if(!curr.HasBranch(word[i]))
            {
                return false;
            }
            //Console.WriteLine("sn = " + word[i]);
            curr = curr.GetBranch(word[i]);
        }
        if(!curr.isEnd) // no word end
        {
            //Console.WriteLine("sn = " + curr.NodeVal);
            return false;
        }
        return true;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) 
    {
        //Console.WriteLine("p = " + prefix);
        var curr = root;
        for(int i = 0; i <prefix.Length; i++)
        {
            if(!curr.HasBranch(prefix[i]))
            {
                return false;
            }
            curr = curr.GetBranch(prefix[i]);
        }
        return true;
    }
    
    public class TrieNode
    {
        private char nodeval;
        public char NodeVal
        {
            get { return nodeval; }
        }
        
        private Dictionary<char, TrieNode> branches = new Dictionary<char, TrieNode>();
        
        public bool isEnd = false;
        
        public TrieNode(char val)
        {
            nodeval = val;
        }
        
        public bool HasAnyBranches()
        {
            return branches.Count() > 0;
        }
        
        public TrieNode AddBranchIfAbsent(char bval)
        {
            if(!branches.ContainsKey(bval))
            {
                branches.Add(bval, new TrieNode(bval));    
            }
            return branches[bval];
        }
        
        public TrieNode GetBranch(char b)
        {
            if(branches.ContainsKey(b))
            {
                return branches[b];    
            }
            return null;
        }
        
        public bool HasBranch(char b)
        {
            return branches.ContainsKey(b);
        }
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */