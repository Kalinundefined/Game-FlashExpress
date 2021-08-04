using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    private int isUp = -1;
    public float upDistance = 80f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState()
    {
        isUp = -isUp;
        transform.Translate(0, isUp * upDistance, 0);
    }

}
