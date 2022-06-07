using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellParentToThrow : MonoBehaviour
{
    // Start is called before the first frame update
void ShittyMandatoryMethod()//fuck u unity
	{
		Enemy_AI enemy_AI = GetComponentInParent<Enemy_AI>();
		enemy_AI.ThrowSnowball();
	}
}
