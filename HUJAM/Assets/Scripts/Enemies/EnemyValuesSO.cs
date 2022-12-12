using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/Enemy Values")]
public class EnemyValuesSO : ScriptableObject
{
    public string tag;      // Must be the same as in the Object Pooler!
    public float health;
    public float moveSpeed;
    public float rotationSpeed;
    public float damage;
    public bool isRanged;
    public bool isElite;
    public AudioClip getHitSoundFX;
    public AudioClip getDieSoundFX;
}
