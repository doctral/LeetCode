public class Test_HashMap{
	public static void main(String[] args){
		MyMap<String, Integer> hash=new MyHashMap<String, Integer>();
		hash.put("Hello",1);
		hash.put("world",2);
		System.out.println(hash);
		hash.remove("world");
		System.out.println(hash);

	}
}