using UnityEngine;

public class levelUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public int level = 1;

    public int currentExperience = 0;
    public int experienceNeeded = 100;

   
    public int attack = 10;

    public void GainExperience(int amount)
    {
        currentExperience += amount;

        while (currentExperience >= experienceNeeded)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentExperience -= experienceNeeded;

        level++;

        experienceNeeded = Mathf.RoundToInt(experienceNeeded * 1.5f);

       
        attack += 5;

        Debug.Log("You reached level " + level + "!");
    }
}
