using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    [SerializeField] List<IVisible> visiblesInSight;
    private float radius = 3f;
    [SerializeField] List<IVisible.Side> attendedSides;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] potentialVisibles = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D c in potentialVisibles)
        {
            IVisible visible = c.GetComponent<IVisible>();
            if ((visible != null) && attendedSides.Contains(visible.GetSide()))
            {
                visiblesInSight.Add(visible);
            }
        }
    }
}
