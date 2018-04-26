using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Creation/Object Creator")]
//[RequireComponent(typeof(BoxCollider2D))]
public class ObjectCreator : MonoBehaviour
{
	//[Header("Object creation")]

	// The object to spawn
	// WARNING: take if from the Project panel, NOT the Scene/Hierarchy!
	public GameObject prefabToSpawn;
    private Vector2 positionv2;
    bool b = false;

    //[Header("Other options")]

    // Configure the spawning pattern
    //public float spawnInterval = 1;

    //private BoxCollider2D boxCollider2D;

    void Start ()
	{
        //boxCollider2D = GetComponent<BoxCollider2D>();
        //Debug.Log("Rutiini käynnistetty ");
        //StartCoroutine(CreateObjects());
	}

    public void GetObject(Vector3Int position)
    {

        positionv2 =  (Vector3) position;
        //Vector2 v2 = (Vector3) position;
        b = true;
        StartCoroutine(CreateObjects());
        //Debug.Log("b = true ");
    }
	
	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator CreateObjects ()
  //public System.Collections.Generic.IEnumerable<GameObject> CreateNewObject()

    {
        //Vector2 positionv2 = (Vector2) position;
        // Create some random numbers
        //float randomX = Random.Range (-boxCollider2D.size.x, boxCollider2D.size.x) *.5f;
        //float randomY = Random.Range (-boxCollider2D.size.y, boxCollider2D.size.y) *.5f;

        // Generate the new object
        if (b)
        {
            GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
            //newObject.transform.position = new Vector2(randomX + this.transform.position.x, randomY + this.transform.position.y);
            newObject.transform.position = positionv2; // new Vector2
            b = false;
            //Debug.Log("Tasoluotu");
            // Wait for some time before spawning another object
            //yield return new WaitForSeconds(spawnInterval);
            yield return newObject;
        }
        
	}
}
