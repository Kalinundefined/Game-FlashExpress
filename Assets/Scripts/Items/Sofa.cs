using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : ItemController {
	private void Start() {
		base.Start();
		dialogList = new string[] { "一张柔软的沙发，窝在上面看电视一定很舒服吧。", "订单要超时了，忙完再说吧。" };
	}
	// Start is called before the first frame update
}
