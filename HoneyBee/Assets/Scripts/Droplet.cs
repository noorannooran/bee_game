using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Nooran El-Sherif 100695733
 * Droplet
 * Last Modified By: Nooran El-Sherif 
 * Date Last Modified: October 20, 2017
 * Description: Disappears the animation of the droplet
 * 
 * Revision History:
 * October 20, 2017:
 * Droplet class created, destroyMe method
 * -------------------
 * Header Added
 */

public class Droplet : MonoBehaviour {

	//make droplet disappear
	public void DestroyMe(){
		Destroy (gameObject);
	}
}
