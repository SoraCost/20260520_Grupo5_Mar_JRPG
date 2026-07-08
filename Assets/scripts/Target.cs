using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Target : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Score.score+=1;
    }
}
