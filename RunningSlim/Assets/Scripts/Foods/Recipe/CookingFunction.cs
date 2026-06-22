using UnityEngine;

public class CookingFunction : MonoBehaviour
{
    [SerializeField] private GameObject recipeFood;
    private GeneralFoodStash _cookingTime;
    
        public void OnMouseDown()
    {
        if (_cookingTime.CreateFruitBasket(true))
        {
            GameObject recipe = (GameObject)Instantiate(recipeFood, transform.position, transform.rotation);
        }
    }
    


          //make a general script that saves whatever is deleted during cooking gets saved as an int and than viewed if it can be cooked
          /* 
           
           OnMouseEnter: if(inkitchen true) + foodname than delete object
           else { OnMouseEnter.base
           
           
           
           
           
           
           
           */

    
    
    }




