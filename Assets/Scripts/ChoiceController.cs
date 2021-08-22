using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceController : MonoBehaviour
{
    public int choiceIndex;
    // Start is called before the first frame update
    public void SetIndex(int index)
    {
        choiceIndex = index;
    }
}
