using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    SpawnLv1, SpawnLv2, SpawnLv3
}

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
}
