public class Solution {
    public int Candy(int[] ratings) {
        int[] res=new int[ratings.Length];
        for(int i=0; i<res.Length; i++){
            res[i]=1;
        }
        for(int i=1; i<ratings.Length; i++){
            if(ratings[i]>ratings[i-1]) res[i]=res[i-1]+1;
        }
        for(int i=ratings.Length-2; i>=0; i--){
            if(ratings[i]>ratings[i+1]){
                res[i]=Math.Max(res[i], res[i+1]+1);
            }
        }
        int sum=0;
        for(int i=0; i<res.Length; i++){
            sum+=res[i];
        }
        return sum;
    }
}