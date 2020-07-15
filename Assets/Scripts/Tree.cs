using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject DropedElement;
    public GameObject DestroyedTree;

    private float health;

    public void ReduceHealth()
    {
        health--;
        if (health <= 0)
        {
            DestroyTree();
        }
    }

    private void DestroyTree()
    {
        int countElement = Random.Range(1, 5);
        var positionElement = transform.position;

        for (int i = 0; i < countElement; i++)
        {
            var dropedElement = Instantiate(DropedElement, new Vector3(positionElement.x,
                                                                       positionElement.y + i,
                                                                       positionElement.z), Quaternion.identity);
            dropedElement.GetComponent<DropedItem>().Explode();
        }

        var colider = GetComponent<Collider2D>();
        var positionDestroyedTreeY = colider.bounds.min.y + 0.5f;
        Instantiate(DestroyedTree, new Vector3(positionElement.x,
                                               positionDestroyedTreeY,
                                               positionElement.z), Quaternion.identity);
        Destroy(gameObject);
    }

    private void Start()
    {
        health = 3;
    }
}