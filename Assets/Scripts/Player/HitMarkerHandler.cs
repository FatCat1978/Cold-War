using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitMarkerHandler : MonoBehaviour
{
    public bool showHit = false;                        //Need to be public for enemies to find.
    public bool showFinish = false;                      
    public int _fixedTimer = 0;
    GameObject HitMarker;
    GameObject FinishMarker;
    Image _finishMarker;
    Image _hitMarker;

    // Start is called before the first frame update
    void Start()
    {
        HitMarker = GameObject.Find("HitMarker");
        FinishMarker = GameObject.Find("FinishMarker");
        _hitMarker = HitMarker.GetComponent<Image>();
        _finishMarker = FinishMarker.GetComponent<Image>();
    }


    private void Update()
    {

        if (showFinish)
        {
            _hitMarker.enabled = false;
            _finishMarker.enabled = true;

            if (_fixedTimer >= 70)
            {
                _fixedTimer = 0;                        //Just for double checking, not required
                _hitMarker.enabled = false;
                _finishMarker.enabled = false;
                showFinish = false;
                showHit = false;
            }
        }
        else if (showHit && !showFinish)
        {
            _hitMarker.enabled = true;

            if (_fixedTimer >= 20)
            {
                _fixedTimer = 0;                        //Just for double checking, not required
                _hitMarker.enabled = false;
                showHit = false;
            }
        }  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (showHit || showFinish)
        {
            print("tick" + _fixedTimer);
            _fixedTimer += 1;
        }
    }
}
