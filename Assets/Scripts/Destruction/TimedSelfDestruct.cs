using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Destruction/Timed Self-Destruct")]
public class TimedSelfDestruct : MonoBehaviour
{
    public MouseClickBomb mcb;

	// After this time, the object will be destroyed
	public float timeToDestruction;


	void Start ()
	{
        mcb = new MouseClickBomb();
        Invoke("DestroyMe", timeToDestruction);
	}


	// This function will destroy this object :(
	void DestroyMe()
	{
        mcb.buttonPressed = true;
        Destroy(gameObject);

		// Bye bye!
	}
}
