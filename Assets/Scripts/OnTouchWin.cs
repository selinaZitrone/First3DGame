using UnityEngine;
public class OnTouchWin : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.GetComponent<SpaceShip_Movement>())
        {
            EventManager.TriggerEvent("won");
        }
    }

}
