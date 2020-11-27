using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DB", menuName = "Enemies/EnemiesDB")]
public class EnemyDatabase : ScriptableObject
{
    public List<Enemy> enemies = new List<Enemy>();
}
