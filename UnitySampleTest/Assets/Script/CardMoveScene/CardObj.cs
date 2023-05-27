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

    public void SetData(Vector3 startPos, Vector3 endPos, float waitSec)
    {
        StartPos = startPos;
        EndPos = endPos;
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
            transform.position = Vector3.Lerp(gameObject.transform.position, EndPos, CardMoveManager.Instance.CardSpeed);
        }
        
        if(transform.position == EndPos)
        {
            this.gameObject.SetActive(false);
        }
        //transform.position = Vector3.Lerp(gameObject.transform.position, EndPos, 0.04f);
    }
}
