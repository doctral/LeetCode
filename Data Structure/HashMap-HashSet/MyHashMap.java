import java.util.*;
public class MyHashMap<K,V> implements MyMap<K,V> {
	private static int DEFAULT_INITIAL_CAPACITY=4;
	private static int MAXIMUM_CAPACITY=1<<30; // 2^30
	private int capacity;
	private static float DEFAULT_MAX_LOAD_FACTOR=0.75f; // appending f to make a float number
	private float loadFactorThreshold;
	private int size=0;
	LinkedList<MyMap.Entry<K,V>>[] table; // an array of LinkedList<Entry<K,V>>
    //no-arg constructor
	public MyHashMap(){
		this.capacity=DEFAULT_INITIAL_CAPACITY;
		this.loadFactorThreshold=DEFAULT_MAX_LOAD_FACTOR;
		table=new LinkedList[this.capacity];
	}
	// one-arg constructor
	public MyHashMap(int cap){
		if(cap>MAXIMUM_CAPACITY){
			this.capacity=MAXIMUM_CAPACITY;
		}
		else{
			this.capacity=trimToPowerOf2(cap);
		}
		this.loadFactorThreshold=DEFAULT_MAX_LOAD_FACTOR;
		table=new LinkedList[this.capacity];
	}
	// two-arg constructor
	public MyHashMap(int cap, float loadfactor){
		if(cap>MAXIMUM_CAPACITY){
			this.capacity=MAXIMUM_CAPACITY;
		}
		else{
			this.capacity=trimToPowerOf2(cap);
		}
		this.loadFactorThreshold=loadfactor;

		table=new LinkedList[this.capacity];
	}
    // make sure the capacity of hashtable is a power of 2
	private int trimToPowerOf2(int cap){
		int capa=1;
		while(capa<cap){
			capa=capa<<1;      //capa*=2 
		}
		return capa;
	}
	// clear all entries
	public void clear(){
		this.size=0;
		removeEntries();
	}
	private void removeEntries(){
		for(int i=0; i<capacity; i++){
			if(table[i]!=null){
				table[i].clear(); // LinkedList method clear()
			}
		}
	}
    // make sure the hashing is evenly distributed
	private static int supplementalHash(int h){
		h ^= (h>>>20) ^ (h>>>12);
		return h^(h>>>7)^(h>>>4);
	}
	// hash function
	private int hash(int hashCode){
		return supplementalHash(hashCode) & (capacity-1); // hashcode % N
	}

	public V get(K key){
		// In java, every class provides a hashCode() method, which 
		// returns a 32-bit int hashcode value
		int bucketIndex=hash(key.hashCode());
		if(table[bucketIndex]!=null){
			LinkedList<Entry<K,V>> bucket=table[bucketIndex];
			for(Entry<K,V> entry: bucket){
				if(entry.getKey().equals(key)){
					return entry.getValue();
				}
			}
		}
		return null;
	}
    // add or update an entry
	public V put(K key, V value){
		// if the key is already in the hashmap, then find the entry 
		//and update the value
		if(get(key) !=null){
			int bucketIndex=hash(key.hashCode());
			LinkedList<Entry<K,V>> bucket=table[bucketIndex];
			for(Entry entry: bucket){
				if(entry.getKey().equals(key)){
					V oldvalue=(V)(entry.getValue());
					entry.value=value;
					return oldvalue;
				}
			}
		}
		// check the loader factor
		if(size>=capacity*loadFactorThreshold){
			if(size==MAXIMUM_CAPACITY){
				throw new RuntimeException("Exceeding MAXIMUM CAPACITY");
			}
			else{
				rehash();
			}
		}

		int bucketIndex=hash(key.hashCode());
		// if the bucket is not created, then create it
		if(table[bucketIndex]==null){
			table[bucketIndex]=new LinkedList<Entry<K,V>>();
		}
		table[bucketIndex].add(new MyMap.Entry<K,V>(key, value));
		size++;
		return value;

	}
	//double the capacity and copy the existing entries
	// to the new hash table
	private void rehash(){
		Set<Entry<K,V>> set=entrySet();  // get the entries set
		capacity=capacity<<1;     // double the capacity
		table=new LinkedList[capacity];
		size=0;
		for(Entry<K,V> entry:set){
			// update size after each put operation
			put(entry.getKey(), entry.getValue());
		}
	}
    // return all entries in the hash table
	public Set<Entry<K,V>> entrySet(){
		Set<Entry<K,V>> set=new HashSet<>();
		for(int i=0; i<capacity; i++){
			if(table[i]!=null){
				// copy the linkedlist
				LinkedList<Entry<K,V>> bucket=table[i];
				for(Entry<K,V> entry: bucket){
					set.add(entry);
				}
			}
		}
		return set;
	}
    // return all keys in the hash table
	public Set<K> keySet(){
		Set<K> set=new HashSet<>();
		for(int i=0; i<capacity; i++){
			if(table[i]!=null){
				LinkedList<Entry<K,V>> bucket=table[i];
				for(Entry<K,V> entry: bucket){
					set.add(entry.getKey());
				}
			}
		}
		return set;
	}
    // return all values in the hash table 
	public Set<V> values(){
		Set<V> set=new HashSet<>();
		for(int i=0; i<capacity; i++){
			if(table[i]!=null){
				LinkedList<Entry<K,V>> bucket=table[i];
				for(Entry<K,V> entry: bucket){
					set.add(entry.getValue());
				}
			}
		}
		return set;
	}

	public boolean containsKey(K key){
		if(get(key)!=null){
			return true;
		}
		else{
			return false;
		} 

	}
    // go through all entries to find the value
	public boolean containsValue(V value){
		for(int i=0; i<capacity; i++){
			if(table[i]!=null){
				LinkedList<Entry<K,V>> bucket=table[i];
				for(Entry<K,V> entry: bucket){
					if(entry.getValue().equals(value)){
						return true;
					}
				}
			}
		}
		return false; 
	}

	public void remove(K key){
		int bucketIndex=hash(key.hashCode());
		if(table[bucketIndex]!=null){
			LinkedList<Entry<K,V>> bucket=table[bucketIndex];
			for(Entry<K,V> entry: bucket){
				if(entry.getKey().equals(key)){
					bucket.remove(entry); // LinkedList method remove
					break;
				}
			}
		}
		// otherwise, do nothing
	}

	public boolean isEmpty(){
		return size==0;
	}

	public int size(){
		return size;
	}

	public String toString(){
		StringBuilder sb=new StringBuilder("[");
		for(int i=0; i<capacity; i++){
			if(table[i]!=null && table[i].size()>0){
				for(Entry<K,V> entry: table[i]){
					sb.append(entry);
				}
			}
		}
		sb.append("]");
		return sb.toString();
	}
}