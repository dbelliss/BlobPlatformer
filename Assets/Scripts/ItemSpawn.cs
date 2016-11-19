using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour {
    private Animator animate;
    public GameObject[] items;
    private bool spawned = false;
    public bool randomItems;
    public int maxItems;
    public int specificItem;
    private Transform itemSpawn;

    // Use this for initialization
    void Start()
    {
        animate = GetComponent<Animator>();
        itemSpawn = transform.FindChild("ItemSpawn").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (spawned == false && animate.GetBool("OpenRegular"))
        {
            if (randomItems)
                maxItems = Random.Range(1, maxItems+1);
            StartCoroutine(spawnItems(0.5f));
            spawned = true;
        }
    }

    IEnumerator spawnItems(float waitTime)
    {
        for (int i = 0; i < maxItems; i++)
        {
            int randomItem = Random.Range(0, items.Length);
            if (specificItem >= 0)
                randomItem = specificItem;
            GameObject item = Instantiate(items[randomItem], itemSpawn.position, Quaternion.identity) as GameObject;
            Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
            float randomDirection = Random.Range(-0.5f, 0.5f);
            Vector3 itemDirection = new Vector3(randomDirection, 1, 0).normalized;
            itemRb.AddForce(itemDirection * 30);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
