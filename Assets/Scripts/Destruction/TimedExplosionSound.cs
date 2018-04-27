using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Destruction/Timed Explosion Sound")]
public class TimedExplosionSound : MonoBehaviour
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
        //gameObject.SendMessage("Explodeit", null);
        Debug.Log("Kutsuttu DestroyMe - terveiset TimedExplosionSound "  + timeToDestruction);
        gameObject.SendMessage("Playit", null);
        Destroy(gameObject, 4.0f);

		// Bye bye!
	}
}
