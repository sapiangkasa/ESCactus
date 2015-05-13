using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {
	[SerializeField]
	GameObject pooledObject; // the object to be pooled (should be a prefab)
	
	[SerializeField]
	int pooledAmount; // sets the number of copies of the object in this pool
	
	List<GameObject> pooledObjectList; // stores the actual pool of objects
	
	void Start () {
		// on start, make the pool of objects
		pooledObjectList = new List<GameObject>(); // create a new list to act as the pool
		// add a copy of the object, repeat this until we have the desired pooled amount
		for(int i = 0; i < pooledAmount; i++) {
			GameObject objectToBePooled = (GameObject)Instantiate(pooledObject); // create a new copy of the object
			objectToBePooled.SetActive(false); // set it to not active, so it does nothing and doesn't interfere with the world
			pooledObjectList.Add(objectToBePooled); // add it to the pool
		}
	}
	
	// use this to retrieve an inactive object copy from the pool
	// note that objects may be set to do something upon becoming active, don't set it to active here and let the caller handle that!
	public GameObject GetPooledObject() {
		// check each object in the pool till we find an inactive one
		for(int i = 0; i< pooledAmount; i++) {
			// has the current object being iterated been destroyed somehow?
			if(pooledObjectList[i] == null) {
				// Yes, we must recreate the object again
				GameObject poolObjectToUse = (GameObject)Instantiate(pooledObject); // create a new copy of the object
				poolObjectToUse.SetActive(false); // set it to not active, so it does nothing and doesn't interfere with the world
				pooledObjectList[i] = poolObjectToUse; // set it as the object we're going to retrieve
				return pooledObjectList[i]; // send this object to the caller
			}
			// is the current object being iterated inactive in the hierarchy?
			if(!pooledObjectList[i].activeInHierarchy) {
				// Yes! Use this one
				return pooledObjectList[i]; // send this object to the caller
			}    
		}
		
		return null;
	}
	
}