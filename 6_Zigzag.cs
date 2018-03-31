public class Solution {
    public string Convert(string s, int numRows) 
    {
        if(string.IsNullOrWhiteSpace(s))
            return string.Empty;
        if(numRows == 1)
            return s;
        var board = new List<List<char>>();
        int rows = 0;
        int index = 0;
        while(true)
        {
            board.Add(new List<char>());
            if(rows % (numRows-1) == 0)
            {
                for(int i = 0; i < numRows; i++)
                {
                    var c = '\0';
                    if(index < s.Length)
                        c = s[index];
                    board[board.Count() - 1].Add(c);
                    index++;
                }
            }
            else
            {
                for(int i = 0; i < numRows; i++)
                {
                    board[board.Count() - 1].Add('\0');
                }
                board[board.Count() - 1][numRows - 1 - (rows % (numRows-1))] = s[index];
                index++;
            }
            rows++;
            if(index >= s.Length)
                break;
        }
        var sb = new StringBuilder();
        for(int i = 0; i < numRows; i++)
        {
            foreach(var row in board)
            {
                if(row[i] != '\0')
                    sb.Append(row[i]);
            }
        }
        
        return sb.ToString();
    }
}