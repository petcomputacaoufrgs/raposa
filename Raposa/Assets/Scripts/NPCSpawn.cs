using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    public GameObject[] Client; // Array of clients
    public float SpawnTime = 1f; // Time between spawns
    public Vector2[] SpawnArea; // Array of spawn area
    private float timer = 0f; // Timer
    private GameObject Clients; // Parent of the clients
    private GameObject[] ClientPrefabs; // Array of client prefabs

    void Start()
    {
        Clients = GameObject.Find("Clients"); // Find the parent of the clients
        ClientPrefabs = Resources.LoadAll<GameObject>("Clients"); // Load all the client prefabs
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
            Client[i] = Instantiate(ClientPrefabs[Random.Range(0, ClientPrefabs.Length)], Clients.transform); // Spawn a random client
            Client[i].transform.position = SpawnArea[i]; // Set the position of the client
            Debug.Log("Spawned NPC in position " + i); // Log the spawn
        }
    }
}

