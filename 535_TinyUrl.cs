public class Codec {

    Dictionary<string,int> word2id = new Dictionary<string,int>();
    Dictionary<int, string> id2word = new Dictionary<int, string>();
    
    // Encodes a URL to a shortened URL
    public string encode(string longUrl) 
    {
        var sb = new StringBuilder();
        var wordsb = new StringBuilder();
        var word = string.Empty;
        for(int i = 0; i < longUrl.Length; i++)
        {
            if(Char.IsPunctuation(longUrl[i]))
            {
                word = wordsb.ToString();
                if(!word2id.ContainsKey(word)){
                    var cnt = word2id.Count();
                    word2id.Add(word, cnt);
                    id2word.Add(cnt, word);
                }
                sb.Append(word2id[word]);
                sb.Append(longUrl[i]);
                wordsb.Clear();
            }
            else
            {
                wordsb.Append(longUrl[i]);
            }
        }
        word = wordsb.ToString();
        if(!String.IsNullOrWhiteSpace(word))
        {
            if(!word2id.ContainsKey(word))
            {
                var cnt = word2id.Count();
                word2id.Add(word, cnt);
                id2word.Add(cnt, word);
            }
            sb.Append(word2id[word]);
        }
        
        return sb.ToString();
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        var sb = new StringBuilder();
        var tokensb = new StringBuilder();
        for(int i = 0; i < shortUrl.Length; i++)
        {
            if(Char.IsPunctuation(shortUrl[i]))
            {
                var token = int.Parse(tokensb.ToString());
                var word = id2word[token];
                sb.Append(word).Append(shortUrl[i]);
                tokensb.Clear();
            }
            else
            {
                tokensb.Append(shortUrl[i]);
            }
        }
        
        var ts = tokensb.ToString();
        if(!String.IsNullOrWhiteSpace(ts))
        {
            var token = int.Parse(ts);
            var word = id2word[token];
            sb.Append(word);
        }
        
        return sb.ToString();
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));