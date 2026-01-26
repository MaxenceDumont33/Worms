using System;
using UnityEngine;

public class MergePower : MonoBehaviour
{
   private bool nearOfAllyBear = false;
   private GameObject bear;
   private GameObject bearNear;
   public bool mergeHasBeenUsed = false;

   private void OnEnable()
   {
      bear = Versus.Instance.currentBear;
   }
   private void Start()
   {
      InputManager.instance.onKeyFPressStarted += Merge;
   }

   private void OnDestroy()
   {
      InputManager.instance.onKeyFPressStarted -= Merge;
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (!enabled) return;
      if (collision.gameObject.layer == LayerMask.NameToLayer("Player") )
      {
         bearNear = collision.gameObject;
         if (bearNear.GetComponent<Bear>().team == bear.GetComponent<Bear>().team)
         {
            bearNear = collision.gameObject;
            nearOfAllyBear = true;
         }
      }
   }

   private void OnCollisionExit(Collision other)
   {
      if (!enabled) return;
      if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
      {
         if (bearNear != null && bearNear.GetComponent<Bear>().team == bear.GetComponent<Bear>().team)
         {
            bearNear = null;
         }
      }
   }

   private void Merge()
   {
      if (mergeHasBeenUsed == false)
      {
         if (nearOfAllyBear && bearNear != null && bearNear.GetComponent<Bear>().team == bear.GetComponent<Bear>().team)
         {
            bear.GetComponent<Bear>().hp += bearNear.GetComponent<Bear>().hp;
            bear.GetComponent<Bear>().ChangeSize();
            Destroy(bearNear);
            bearNear = null;
            nearOfAllyBear = false;
            mergeHasBeenUsed = true;
            Versus.Instance.QueueRefresh();
         }
      }
   }
}
