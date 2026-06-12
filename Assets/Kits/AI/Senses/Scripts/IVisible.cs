using UnityEngine;

public interface IVisible
{
    enum Side 
    {
        Friend,
        Neutral,
        Enenmy
    };
    
    public Side GetSide();
    public Transform GetTransform();
}
