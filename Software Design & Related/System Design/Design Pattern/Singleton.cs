public sealed class Singleton{
    private static volatile Singleton instance;
    private static object obj=new object();
    private Singleton(){}
    public static Singleton Instance{
        get{
            if(instance==null){
                lock(obj){
                    if(instance==null){
                        instance=new Singleton();
                    }
                }
            }
            return instance;
        }
    }
}