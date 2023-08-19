using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewTest : MonoBehaviour
{
    public ScrollRect scroll;
    public AnimationCurve ac;
    public Button StartButtonn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            var slotObj = Instantiate(Resources.Load("ScrollViewTestSlot"), scroll.content.transform) as GameObject;
            var slot = slotObj.GetComponent<ScrollViewTestSlot>();
        }
    }


    
}
