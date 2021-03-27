using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "MagneticBeam2")
			Destroy (other.gameObject);
	}
}
