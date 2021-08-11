using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    private Animation anim;

    public void Awake()
    {
        anim = GetComponent<Animation>();
    }


    private void OnTriggerEnter(Collider other)
    {

        anim.Play("Play");
    }
}
