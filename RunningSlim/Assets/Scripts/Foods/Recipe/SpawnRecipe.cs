using UnityEngine;

public class SpawnRecipe : MonoBehaviour
{
    [SerializeField] private GameObject recipes;
    private CurrentRoomHandler _inKitchen;
    private void Start()
    {
        _inKitchen = FindAnyObjectByType<CurrentRoomHandler>();
        GameObject recipe = (GameObject)Instantiate(recipes, transform.position, transform.rotation);

    }
}
