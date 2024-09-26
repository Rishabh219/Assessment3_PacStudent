using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animatorController;

    [SerializeField]
    private GameObject player;
    private Tween activeTween;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AddPlayerTween();
        if (activeTween != null)
        {
            checkDirection(); 

           
            float time = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float timeFraction = time * time * time;

           
            float dist = Vector3.Distance(activeTween.Target.position, activeTween.FinalPosition);

            if (dist > 0.1f)
            {
                activeTween.Target.transform.position = Vector3.Lerp(activeTween.InitialPosition, activeTween.FinalPosition, timeFraction);
            }
            if (dist < 0.1f)
            {         
                activeTween.Target.position = activeTween.FinalPosition;
                activeTween = null;
            }

        }

        pos = player.transform.position; 
    }

    public void AddPlayerTween()
    {
        if (activeTween == null)
        {
            if (pos.x == 6 && pos.y == -1) 
            {
                activeTween = new Tween(player.transform, player.transform.position, new Vector3(6.0f, -5.0f, 0.0f), Time.time, 1.5f);
            }

            if (pos.x == 6 && pos.y == -5) 
            {
                activeTween = new Tween(player.transform, player.transform.position, new Vector3(1.0f, -5.0f, 0.0f), Time.time, 1.5f);
            }

            if (pos.x == 1 && pos.y == -5) 
            {
                activeTween = new Tween(player.transform, player.transform.position, new Vector3(1.0f, -1.0f, 0.0f), Time.time, 1.5f);
            }

            if (pos.x == 1 && pos.y == -1) 
            {
                activeTween = new Tween(player.transform, player.transform.position, new Vector3(6.0f, -1.0f, 0.0f), Time.time, 1.5f);
            }
        }
    }

    public void checkDirection()
    {
        if (pos.y > activeTween.FinalPosition.y) 
        {
            animatorController.SetInteger("Move", 3);
        }

        if (pos.x > activeTween.FinalPosition.x) 
        {
            animatorController.SetInteger("Move", 0);
            activeTween.Target.transform.localScale = new Vector3(-2.2f, 2.2f, 0);
        }

        if (pos.y < activeTween.FinalPosition.y)
        {
            animatorController.SetInteger("Move", 1);
            activeTween.Target.transform.localScale = new Vector3(2.2f, 2.2f, 0);
        }

        if (pos.x < activeTween.FinalPosition.x) 
        {
            animatorController.SetInteger("Move", 2);
        }
    }

}

