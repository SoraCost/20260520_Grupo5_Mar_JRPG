using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 public static int score;
 TextMeshProUGUI text;

 void Awake()
    {
        text=GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text=$" Score - {score}";
    }
}
