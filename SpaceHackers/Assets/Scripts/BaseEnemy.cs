using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour
{
    string enemyName;
    public string EnemyName
    {
        get { return enemyName; }
        set { enemyName = value; }
    }

    int level; //Current level of the enemy
    public int Level
    {
        get { return level; }
        set { level += value; }
    }

    int experience; //Experience received from the enemy
    public int Experience
    {
        get { return experience; }
        set { experience = value; }
    }
}
