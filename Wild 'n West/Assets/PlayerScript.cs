using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public enum Action { None, Shoot, Dodge, Reload }

    public float roundTime = 3f;
    private float timer;
    private bool roundActive = false;

    public Action playerAction = Action.None;
    private bool dodgeRight = true;

    public EnemyScript enemy;

    private Coroutine roundCoroutine;

    void Start()
    {
        StartNewRound();
    }

    void Update()
    {
        if (roundActive)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerAction = Action.Dodge;
                dodgeRight = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerAction = Action.Dodge;
                dodgeRight = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerAction = Action.Shoot;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerAction = Action.Reload;
            }
        }
    }

    void StartNewRound()
    {
        // Stop any old coroutine
        if (roundCoroutine != null)
        {
            StopCoroutine(roundCoroutine);
        }

        playerAction = Action.None;
        enemy.PickRandomAction();
        timer = roundTime;
        roundActive = true;

        roundCoroutine = StartCoroutine(RoundLoop());
    }

    IEnumerator RoundLoop()
    {
        // Countdown
        while (timer > 0f)
        {
            Debug.Log(Mathf.Ceil(timer));
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        roundActive = false;
        ResolveRound();
    }

    void ResolveRound()
    {
        EnemyScript.Action enemyAction = enemy.CurrentAction;

        if (enemyAction == EnemyScript.Action.Shoot)
        {
            if (playerAction == Action.Shoot || playerAction == Action.Reload)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Lose Scene");
                return;
            }
        }

        if (playerAction == Action.Shoot)
        {
            if (enemyAction == EnemyScript.Action.Shoot || enemyAction == EnemyScript.Action.Reload)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Win Scene");
                return;
            }
        }

        // Tie case
        //If nothing above happens, it is a tie cause no one dies!!!
        Debug.Log("It was a Tie!");
    }
}
