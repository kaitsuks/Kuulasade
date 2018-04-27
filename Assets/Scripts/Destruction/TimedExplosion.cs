using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Destruction/Timed Self-Destruct")]
public class TimedExplosion : MonoBehaviour
{
    

	// After this time, the object will be destroyed
	public float timeToDestruction;


	void Start ()
	{
        
        Invoke("DestroyMe", timeToDestruction);
	}


	// This function will destroy this object :(
	void DestroyMe()
	{
        gameObject.SendMessage("Explodeit", null);
        Debug.Log("Tässä kohtaa on ongelma - terveiset TimedSelfDestruct "  + timeToDestruction);
        //gameObject.SendMessage("Playit", null);
        Destroy(gameObject);

		// Bye bye!
	}
}
