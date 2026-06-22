using UnityEngine;

public class GeneralFoodStash : MonoBehaviour
{
    private int appleStash;
    private int pearStash;
    //make more for the diffrent kinds of ingredient items
    //and make a function for each to increase the stash


    public void AddApple()
    {
        appleStash++;
    }
    public void AddPear()
    {
        pearStash++;
    }

    public bool CreateFruitBasket(bool bakeIt)
    {
        if(appleStash >= 2 & pearStash >= 1)
        {
            bakeIt = true;
        }
        else
        {
            bakeIt = false;
        }
        return bakeIt;
    }
}
