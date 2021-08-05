using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : ItemController {
	private void Start() {
		base.Start();
		dialogList = new string[] { "好久没有睡饱过了，真想好好睡一觉。", "订单要超时了，忙完再说吧。" };
	}
}
