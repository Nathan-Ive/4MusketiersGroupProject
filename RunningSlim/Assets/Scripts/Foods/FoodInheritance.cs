using UnityEngine;

public class FoodInheritance : MonoBehaviour //it's a parent class
{
//use protected
    void Start()
    {
        
    }
    public void Eating()
    {

    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        //initiate a function here
        Eating();
        Destroy(gameObject);
    }
}
