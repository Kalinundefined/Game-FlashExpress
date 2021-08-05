using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    private int state = 0;
    private int curUpState = 1;
    public float[] upDistance = new float[3] { 0f, 100f, 200f };
    public GameObject arrow;
    private Vector2 offsetMinInit, offsetMaxInit;
    private RectTransform rectTransform;
    public GameObject chatPanel, infoPanel;
    private Vector3 localScaleInit;
    public float firstMessagePositionX, firstMessagePositionY;
    private float curHeight;
    public float[] messageHeight = new float[2] { 0f, 0f };
    public Text personName, itemName, placeName;
    public GameObject avatar;
    public Canvas UICanvas;
    private bool first;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        offsetMaxInit = rectTransform.offsetMax;
        offsetMinInit = rectTransform.offsetMin;
        localScaleInit = arrow.transform.localScale;
        curHeight = firstMessagePositionY;
        first = true;
        chatPanel.SetActive(false);

        /*SetInfo("granny.png", "小孩", "数学试卷", "办公楼");

        NewMessage(false, "哈哈哈哈哈啊哈哈哈哈啊哈哈哈哈");
        NewMessage(true, "哈哈");
        NewMessage(false, "哈哈");
        NewMessage(true, "哈哈哈哈");
        NewMessage(true, "哈哈哈哈哈哈哈哈哈哈啊哈");*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewMessage(bool isLeft, string text)
    {
        Debug.Log(curHeight);
        string prefabName = (isLeft ? "Left" : "Right") + "Message" + (text.Length > 12 ? "2" : "1");
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/" + prefabName);
        if (prefabObj == null) Debug.Log("null");
        GameObject message = Instantiate(prefabObj/*, firstMessagePosition, Quaternion.identity*/) as GameObject;
        message.transform.SetParent(chatPanel.transform);
        message.transform.localScale = new Vector3(1, 1, 1);
        message.transform.Find("Text").GetComponent<Text>().text = text;
        if (first)
        {
            first = false;
            if (text.Length > 12) curHeight += -10;
        }
        message.GetComponent<RectTransform>().anchoredPosition = new Vector2(firstMessagePositionX, curHeight);
        curHeight += messageHeight[text.Length > 12 ? 1 : 0];
        Debug.Log(curHeight);
    }

    public void SetInfo(string avatarSrc, string person, string item, string place)
    {
        personName.text = person;
        itemName.text = item;
        placeName.text = place;
        Texture2D _tex2 = new Texture2D(256, 256);
        byte[] bytes = File.ReadAllBytes(Application.dataPath + "/Textures/Avatar/" + avatarSrc);
        _tex2.LoadImage(bytes);
        avatar.GetComponent<Image>().sprite = Sprite.Create(_tex2, new Rect(0, 0, _tex2.width, _tex2.height), new Vector2(0.5f, 0.5f));
    }

    public void Clear()
    {

    }

    private void Move(int index)
    {
        state = index;
        rectTransform.offsetMin = offsetMinInit + new Vector2(0, upDistance[state]);
        rectTransform.offsetMax = offsetMaxInit + new Vector2(0, upDistance[state]);
        arrow.transform.localScale = Vector3.Scale(new Vector3(1, index == 0 ? 1 : -1, 1), localScaleInit);
    }

    public void ToFromChat(int index)
    {
        Debug.Log(index);
        curUpState = index;
        Move(curUpState);
        chatPanel.SetActive(index == 2);
        infoPanel.SetActive(index == 1);
    }

    public void clickArrow()
    {
        if (state == 0) Move(curUpState);
        else Move(0);
        //arrow.transform.localScale = Vector3.Scale(new Vector3(1, -1, 1), arrow.transform.localScale);
    }

}
