using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveManager : MonoBehaviour
{
    public static CardMoveManager _instance = null;
    public static CardMoveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CardMoveManager>() as CardMoveManager;
            }
            return _instance;
        }
    }

    private Vector3 DealerPos;
    private List<Vector3> UsersPosList = new List<Vector3>();

    private List<CardObj> CardObjList = new List<CardObj>();

    public float CardSpeed
    {
        get;
        private set;
    }
    static public float CardSpeedMax = 1f;
    static public float CardSpeedMin = 0.01f;

    public float CardCreateWaitTime
    {
        get;
        private set;
    }
    static public float CardCreateWaitTimeMax = 1f;
    static public float CardCreateWaitTimeMin = 0.1f;

    void Start()
    {
        CardSpeed = CardSpeedMin;
        CardCreateWaitTime = CardCreateWaitTimeMin;
        // 씬이 변경 할때마다 파괴 할예정이기 때문에 굳이 하지 않는다
        //DontDestroyOnLoad(this);
    }
    
    public void CardMoveStart(GameObject dealerObj, List<GameObject> userObjLis)
    {
        UsersPosList.Clear();

        for (int i = 0; i < CardObjList.Count; i++)
        {
            DestroyImmediate(CardObjList[i].gameObject);
        }
        CardObjList.Clear();


        DealerPos = dealerObj.transform.position;
        float createWaitTime = 0;

        for (int i = 0; i < userObjLis.Count; i++)
        {
            if (userObjLis[i].activeSelf)
            {
                UsersPosList.Add(userObjLis[i].transform.position);

                for (int k = 0; k < 2; k++)
                {
                    var slotObj = Instantiate(Resources.Load("CardMoveScene/CardObj"), this.transform) as GameObject;
                    var slot = slotObj.GetComponent<CardObj>();
                    slot.SetData(DealerPos, userObjLis[i].transform.position, createWaitTime + (k*0.1f));
                    CardObjList.Add(slot);
                    slot.gameObject.SetActive(false);
                }

                createWaitTime += CardCreateWaitTime;
            }    
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < CardObjList.Count; i++)
        {
            CardObjList[i].UpdateMove();
        }
    }

    public void SetCardSpeed(float value)
    {
        CardSpeed = value;
    }

    public void SetCreateWaitTime(float value)
    {
        CardCreateWaitTime = value;
    }
}
