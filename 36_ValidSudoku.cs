public class Solution {
    public bool IsValidSudoku(char[,] board) 
    {
        for(int i= 0; i<9;i++)
        {
            var set = new HashSet<int>();
            for(int j = 0;j<9;j++)
            {
                if(board[i,j] == '.')
                    continue;
                var v = (int)Char.GetNumericValue(board[i,j]);
                if(set.Contains(v))
                    return false;
                else
                    set.Add(v);
            }
            set.Clear();
            for(int j = 0;j<9;j++)
            {
                if(board[j,i] == '.')
                    continue;
                var v = (int)Char.GetNumericValue(board[j,i]);
                if(set.Contains(v))
                    return false;
                else
                    set.Add(v);
            }
        }
        
        
        for(int i= 0; i<9;i = i+3)
        {
            for(int j = 0;j<9;j = j+3)
            {
                var set = new HashSet<int>();
                for(int k= 0; k<3;k++)
                {
                    for(int l = 0;l<3;l++)
                    {
                        if(board[i+k,j+l] == '.')
                            continue;
                        var v = (int)Char.GetNumericValue(board[i+k,j+l]);
                        if(set.Contains(v))
                            return false;
                        else
                            set.Add(v);
                    }
                }
            }
        }
        
        return true;
        
    }
}