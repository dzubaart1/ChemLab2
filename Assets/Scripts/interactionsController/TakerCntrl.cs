using UnityEngine;

public class TakerCntrl : MonoBehaviour, IColiderInteraction
{
    private SubstanceParams substanceParams;
    private GameObject currentSubstance;

    [SerializeField] private Transform _pointToAttach;
    public void ColissionDetecting(GameObject colider)
    {
        Debug.Log(colider.name);
        if (colider.GetComponent<ContainerCntrl>() is null || colider.GetComponent<ContainerCntrl>().isClosed())
            return;

        substanceParams = colider.GetComponent<ContainerCntrl>().substanceParams;

        currentSubstance = Instantiate(substanceParams.prefab, _pointToAttach.position, Quaternion.identity, _pointToAttach);
        currentSubstance.name = substanceParams.name;
        currentSubstance.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<AnswerCntrl>().InitiateAnswer();
    }

    public void OnCollisionEnter(Collision collision)
    {
        ColissionDetecting(collision.gameObject);
    }

    public void OnTriggerEnter(Collider collision)
    {
        ColissionDetecting(collision.gameObject);
    }

    private void CheckRotation()
    {
        if(currentSubstance is null)
        {
            return;
        }
        float rotX = transform.localEulerAngles.x;
        if (rotX > 0 && rotX < 250)
        {
            currentSubstance.transform.parent = null;
            currentSubstance.gameObject.AddComponent<Rigidbody>();
            currentSubstance.GetComponent<SphereCollider>().enabled = true;
        }
    }

    public void Update()
    {
        CheckRotation();
    }
}
