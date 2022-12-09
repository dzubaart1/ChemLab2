using UnityEngine;

public interface IColiderInteraction
{
    public void ColissionDetecting(GameObject colider);
    public abstract void OnCollisionEnter(Collision collision);
    public abstract void OnTriggerEnter(Collider collision);
}
