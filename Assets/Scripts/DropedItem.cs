using UnityEngine;

public class DropedItem : MonoBehaviour
{
    public void Explode()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-100f, 100f), Random.Range(0, 100f)));
    }
}