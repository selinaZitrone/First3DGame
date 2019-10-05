using UnityEngine;


public class OnTouchLose : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.GetComponent<SpaceShip_Movement>())
        {
            EventManager.TriggerEvent("death");
        }
    }
  
}
