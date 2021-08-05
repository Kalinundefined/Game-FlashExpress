using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Eventhandler : MonoBehaviour {
	public static Dictionary<string, int> eventflags = new Dictionary<string, int>();
	public enum Task {
		none, grandma, child, cake, flower, save
	}
	public static Task curTask = Task.none;
	public static int curStep = 0;
	DialogBoxController dialogBox;
	PhoneController phone;

	private void ShowDialog(string[] _msg) {
		if (!dialogBox)
			Start();
		Debug.Log(dialogBox);
		Debug.Log(_msg);
		dialogBox.setDialog(_msg);
	}

	private void PhoneMsg(string msg, bool isLeft) {
		phone.NewMessage(isLeft, msg);
	}
	private void Start() {
		dialogBox = GameObject.Find("UI/Canvas/DialogBox").GetComponent<DialogBoxController>();
		Debug.Log("dialogbox");
		Debug.Log(dialogBox);
		phone = GameObject.Find("UI/Canvas/Phone").GetComponent<PhoneController>();
	}

	private void PhoneReply(string[] replylist) {

	}
	public void SetEvent(string eventname) {
		Debug.Log("eventname is");
		Debug.Log(eventname);
		Debug.Log("curtask = " + (int)curTask + "curStep" + curStep);
		switch (eventname) {
			case "world": {
					if (curTask == Task.none) {
						curTask = Task.grandma;
						curStep = 1;
						phone.SetInfo("grandma.png", "老奶奶", "午饭", "医院");
						ShowDialog(new string[] { "早上 10点30分", "我是一名普通的闪送员，是这座小城里稀有的职业", "好像有订单了，打开手机看看吧" });
						PhoneMsg("你好，我想要把做的午饭送给在医院的老伴L先生。", true);
						PhoneMsg("我住在城市的东南角，来取一下吧。", true);

					} else if (curTask == Task.cake && curStep == 0) {
						curStep = 1;
						PhoneMsg("您好，今年父亲生日我没法赶回来，但我订了蛋糕。", true);
						PhoneMsg("希望您尽快取到蛋糕送过去。麻烦了。", true);

					} else if (curTask == Task.cake && curStep == 2) {
						curStep = 3;
						phone.SetInfo("boy.png", "年轻人", "玫瑰花", "CBD");
						PhoneMsg("我要一束玫瑰花，越快越好，送来写字楼。", true);
						PhoneMsg("我穿着蓝色外套。黑色裤子，个子中等，会将一只手背在背后。", true);
						PhoneMsg("一定要尽快。悄悄把玫瑰花放在我手上。", true);
						ShowDialog(new string[] { "路边刚好有花店，直接送去办公区吧" });
					}


				}

				break;
			case "grandma": {
					if (curTask == Task.grandma) {
						if (curStep == 1) {
							curStep = 2;
							ShowDialog(new string[] { "（老奶奶拄着拐杖开门，将饭盒递给你）", "年纪大了，腿脚是不太方便喽。拜托你了小伙子！", "我老伴在医院155病房3床，你也顺道帮我看看他情况好不好。", "他这人唉，就想自己扛。" });

						}
					}
				}
				break;
			case "home": {
					if (curTask == Task.cake && curStep == 1) {
						curStep = 2;
						ShowDialog(new string[] { "(敲门)", "(…敲门)", "(看来暂时没有人，给顾客发个消息吧)" });
						PhoneMsg("您放在门口就行。", true);
						PhoneMsg("老爷子喜欢这个点出门遛弯，六点前一定会回来。", true);

					}
					if (curTask == Task.cake && curStep == 4) {
						phone.SetInfo("question.png", "??", "??", "??");
						curStep = 5;
						PhoneMsg("我联系不上父亲了，已经叫了开锁公司，可以请你帮忙看一下情况吗", true);
						ShowDialog(new string[] { "奇怪，已经六点半了，蛋糕怎么还在门口", "几分钟后，开锁公司到了" });
					}

				}
				break;
			case "hospital": {
					switch (curTask) {
						case Task.grandma: {
								curStep = 2;
								ShowDialog(new string[] { "病房入口好像在右边，进去看看吧","(病房里好几个老爷爷，精神不错，正聚在一张床边聊天。)","请问L爷爷是哪位",
										"谢谢小伙子，告诉老太太，我好着呢" , "您客气了","(忙完了，去跑下一单吧)" });
								PhoneMsg("送到了啊，送到了就好，谢谢你啊", true);
								curTask = Task.child;
								phone.SetInfo("child.png", "小孩", "试卷", "CBD");
								curStep = 0;


							}
							break;

					}

				}; break;
			case "school": {
					if (curTask == Task.child) {
						if (curStep == 0) {
							PhoneMsg("叔叔您好，我现在在XX小学教学楼一楼男卫生间", true);
							PhoneMsg("昨天的卷子忘记给爸爸签字了，叔叔可以帮我吗", true);
							PhoneMsg("试卷放在窗台上。", true);
							PhoneMsg("您将试卷拿到XX公司XX楼下找我爸爸XX，一定要在下下节课之前送到这里来。", true);
							curStep = 1;
						} else if (curStep == 2) {
							PhoneMsg("谢谢叔叔！", true);
							curTask = Task.cake;
							phone.SetInfo("uncle.png", "L先生", "蛋糕", "父亲家");
							curStep = 0;
							ShowDialog(new string[] { "任务结束了，看看有没有下一单吧" });
						}
					}
				}
				break;

			case "CBD": {
					if (curTask == Task.child && curStep == 1) {
						ShowDialog(new string[] { "(写字楼下)", "看我这记性，（不好意思地笑笑）。", "签好了，我先回。", "（收过试卷，望着光鲜亮丽的大楼若有所思）" });
						curStep = 2;
					}
					if (curTask == Task.cake && curStep == 0) {
						ShowDialog(new string[] { "取到蛋糕啦" });
						curStep = 1;
					}
					if (curTask == Task.cake && curStep == 3) {
						curStep = 4;
						ShowDialog(new string[] { "【你在人群中一眼看到了和一位女性一起走出来的N先生，因为他先看到了穿着闪送马甲的你，对你眼神示意】", "你将玫瑰放在N先生手中，发现他摊开的手心上还写着“谢谢“两个字。一时间感觉好笑又可爱。", "【远远地，你听不清他们说了什么。男生变出一束花。他们拥抱在一起。周围人群为他们欢呼起哄。】", "【你看着两人喜悦的脸庞，一时间想看看前一单的蛋糕的情况，收到的人，是不是也收到了婉转表达的感情呢，也会这样开心吗】" });

					}

				}
				break;

			_:; break;

		}


	}

}
