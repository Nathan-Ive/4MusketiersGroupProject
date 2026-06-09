using UnityEngine;

  abstract class FoodInheritance : MonoBehaviour //it's a parent class
{
    [SerializeField] private string _name;
    [SerializeField] private string _desc;
    //props best to use get set 
    protected StatsV1 _getStats = new StatsV1();
    void Start()
    {
        _getStats = FindAnyObjectByType<StatsV1>();
    }
    abstract public void Eating();
    
        //protected means that only the parent and child classes have acces to this
    

    // Update is called once per frame
    public void OnMouseDown()
    {
        //initiate a function here
        Eating();
        Destroy(gameObject);
    }

   
    //a UI that's seprate from the food prefab that gets the component and displays the food name and description.
}
