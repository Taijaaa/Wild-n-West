using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum Action { None, Shoot, Dodge, Reload }
    public Action CurrentAction { get; private set; } = Action.None;

    public void PickRandomAction()
    {
        int rand = Random.Range(1, 4);
        CurrentAction = (Action)rand;
    }
}
