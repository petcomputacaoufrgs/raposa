using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    public GameObject[] Client; // Array of clients
    public float SpawnTime = 1f; // Time between spawns
    public Vector2[] SpawnArea; // Array of spawn area
    private float timer = 0f; // Timer
    private GameObject Clients; // Parent of the clients
    private GameObject[] ClientSprites; // Array of client sprites
    private GameObject[] ClientOrders; // Array of client orders

    void Start()
    {
        Clients = GameObject.Find("Clients"); // Find the parent of the clients
        ClientSprites = Resources.LoadAll<GameObject>("Cafeteria/Clients"); // Load all the client prefabs
        ClientOrders = Resources.LoadAll<GameObject>("Cafeteria/Orders"); // Load all the order prefabs
    }

    void Update()
    {
        timer += Time.deltaTime; // Add time to the timer
        if (timer > SpawnTime) // If the timer is greater than the spawn time
        {
            timer = 0f; // Reset the timer
            SpawnState(Random.Range(0, Client.Length)); // Spawn a random client
        }
    }
    void SpawnState(int i)
    {
        if (Client[i] == null) // If the client is null
        {
            Client[i] = MakeRandomNPC(); // Spawn a random client
            Client[i].transform.position = SpawnArea[i]; // Set the position of the client
            Debug.Log("Spawned NPC in position " + i); // Log the spawn
        }
    }
    GameObject MakeRandomNPC()
    {
        GameObject NPC = Instantiate(ClientSprites[Random.Range(0, ClientSprites.Length)], Clients.transform); // Spawn a random client
        Component[] Orders = ClientOrders[Random.Range(0, ClientOrders.Length)].GetComponents<Component>();

        foreach (Component Order in Orders)
        {
            if (Order.GetType() != typeof(Transform))
            {
                CopyComponent<Component>(Order, NPC);
            }
        }

        return NPC;
    }

    T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }
}

