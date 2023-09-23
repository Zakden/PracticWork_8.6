using UnityEngine;

public class VectorExample : MonoBehaviour
{
    public float Speed;
    public bool Forward;

    public Vector3[] positions;

    private int target = 0;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[target], Time.deltaTime * Speed);
        transform.LookAt(positions[target]);

        if(transform.position == positions[target])
        {
            if(Forward)
            {
                target++;
                if (target == positions.Length)
                {
                    Forward = false;
                    target--;
                }
            }
            else
            {
                target--;
                if (target < 0)
                {
                    target++;
                    Forward = true;
                }
            }
        }
    }
}
