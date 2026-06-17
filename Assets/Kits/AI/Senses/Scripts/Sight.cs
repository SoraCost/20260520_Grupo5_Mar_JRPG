using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] List<IVisible.Side> attendedSides;

    public List<IVisible> visiblesInSight = new();

    // Update is called once per frame
    void Update()
    {
        visiblesInSight.Clear();
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
