using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;
    public float startForce = 15f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blade")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, Quaternion.LookRotation(direction));
            Destroy(gameObject);
            Destroy(slicedFruit, 3f);
        }
    }
}
