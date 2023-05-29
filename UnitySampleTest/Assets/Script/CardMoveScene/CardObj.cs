using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObj : MonoBehaviour
{
    public SpriteRenderer Img;

    private Vector3 StartPos;
    private Vector3 EndPos;
    private float WaitTimeSec;
    private float WaitTimeSec_Save;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(Vector3 startPos, Vector3 endPos, int cardIndex, float waitSec)
    {
        this.transform.localPosition = startPos;
        Vector3 e1 = endPos + new Vector3(-0.55f, 0f, -0.1f);
        Vector3 e2 = endPos + new Vector3(0.55f, 0f, -0.1f);

        this.transform.TransformDirection(new Vector3(-0.4f, 0f, -0.1f));
        StartPos = startPos;
        EndPos = cardIndex == 0 ? e1 : e2;
        WaitTimeSec = waitSec;
        WaitTimeSec_Save = 0;
        this.gameObject.SetActive(false);
        
    }

    public void UpdateMove()
    {
        WaitTimeSec_Save += Time.deltaTime;
        if(WaitTimeSec_Save > WaitTimeSec)
        {
            this.gameObject.SetActive(true);
            //transform.position = Vector3.MoveTowards(gameObject.transform.position, EndPos, CardMoveManager.Instance.CardSpeed);
            transform.position = Vector3.Lerp(gameObject.transform.position, EndPos, CardMoveManager.Instance.CardSpeed.NowValue);
        }

        Debug.Log(Vector3.Distance(gameObject.transform.position, EndPos));
        
        if(transform.position == EndPos)
        {
           // this.gameObject.SetActive(false);
        }
        //transform.position = Vector3.Lerp(gameObject.transform.position, EndPos, 0.04f);
    }
}
