using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingColor : MonoBehaviour
{
	private GameObject HatRef;
	private GameObject JacketRef;
	private GameObject GlovesRef;

	public Color JacketColour;
	public Color GlovesColour;
	public Color HatColour;

	// Start is called before the first frame update
	void Start()
	{
		ChangeColours();	
	}

	void ChangeColours()
    {
		JacketRef = transform.Find("WINTER_JACKET").gameObject;
		GlovesRef = transform.Find("GLOVES").gameObject;
		HatRef = transform.Find("WINTER_HAT").gameObject;

		JacketRef.transform.GetComponent<Renderer>().material.color = JacketColour;
		GlovesRef.transform.GetComponent<Renderer>().material.color = GlovesColour;
		HatRef.transform.GetComponent<Renderer>().material.color = HatColour;
	}

    private void OnValidate()
    {
		ChangeColours();
    }

    // Update is called once per frame
    void Update()
	{
		
	}
}
