using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard2 : ItemController
{
    // Start is called before the first frame update
    private void Start() {
        base.Start();
        dialogList = new string[] { "柜子被打开了，一些药物散落在旁边的地面上", "速效救心丸…和还在老家的父亲常备药一样" };
    }
}
