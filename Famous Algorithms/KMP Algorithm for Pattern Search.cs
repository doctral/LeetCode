// Given a text t and a pattern p, find all occurrences of p in t. 
// https://www.geeksforgeeks.org/kmp-algorithm-for-pattern-searching/
// Find an O(n) algorithm

public class Solution
{

    public IList<int> KMPSearch(string t, string p){
        IList<int> res=new List<int>();
        if(t.Length<p.Length) return res;

        int[] lps=new int[p.Length];
        ComputeLongestPrefixSuffix(p, lps);

        int tIndex=0, pIndex=0;

        while(tIndex<t.Length){
            if(t[tIndex]==p[pIndex]){
                tIndex++;
                pIndex++;
                
                if(pIndex==p.Length){
                    res.Add(tIndex-pIndex);
                    pIndex=lps[pIndex-1];
                }
            }
            else{
                if(pIndex!=0){
                    pIndex=lps[pIndex-1];
                }
                else{
                    tIndex++;
                }
            }
            
        }

        return res;
    }

    private void ComputeLongestPrefixSuffix(string p, int[] lps)
    {
        int len=0, i=1;
        lps[0]=0; 
        while(i<p.Length)
        {
            if(p[i]==p[len])
            {
                len++;
                lps[i]=len;
                i++;
            }
            else{
                if(len!=0){
                    len=lps[len-1];
                }
                else{
                    lps[i]=len;
                    i++;
                }
            }
        }
    }

}
