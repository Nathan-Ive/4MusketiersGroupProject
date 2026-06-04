using UnityEngine;

public class FoodInheritance : MonoBehaviour //it's a parent class
{
    [SerializeField] private string _name;
    [SerializeField] private string _desc;
    //props best to use get set 
    void Start()
    {
        
    }
    protected void Eating()
    {
        //protected means that only the parent and child classes have acces to this
    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        //initiate a function here
        Eating();
        Destroy(gameObject);
    }
   
    //a UI that's seprate from the food prefab that gets the component and displays the food name and description.
}
