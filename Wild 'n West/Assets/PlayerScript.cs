using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float timer = 0;
    float shootTime = 0.7f;
    enum Action { Shoot, Dodge, Reload };

    Action action = Action.Dodge;
    bool dodgeRight = true;

    // Update is called once per frame
    void Update()
    {
        // Get Inputs
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            action = Action.Dodge;
            dodgeRight=false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            action = Action.Dodge;
            dodgeRight = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            action = Action.Shoot;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            action = Action.Reload;
        }

        // Action Timer
        timer += Time.deltaTime;
        if (timer > shootTime)
        {
            if (action == Action.Shoot)
            {
            }
            if (action == Action.Reload)
            {
            }
            if (action == Action.Dodge)
            {
                if (dodgeRight)
                {
                }
                else
                {
                }
            }
        }
    }
}
