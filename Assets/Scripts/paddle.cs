using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{   //config parameters
    [SerializeField] float min=1f, max=15f;
    int ScreenWithInUnits = 16;

    float ValueOfY;

  
    //cached reference
    ball Ball;
    // Update is called once per frame
    private void Start()
    {
        Ball= FindObjectOfType<ball>();

        ValueOfY = transform.position.y;


    }
    void Update()
    {
        GetPositionX();
    }

    void GetPositionX()
    {
        
        if (GameSession.instance.AutoPlay == false)
        {
            float mousePosInUnits = Input.mousePosition.x / Screen.width * ScreenWithInUnits;   //???
            Vector2 paddlePos = new Vector2(mousePosInUnits, ValueOfY);
            paddlePos.x = Mathf.Clamp(paddlePos.x, min, max);
            transform.position = paddlePos;
        }
        else
        {
            transform.position = new Vector2(Ball.transform.position.x, ValueOfY);
        }
    }
}
