using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
    //عشان لما الرصاصة تعدى الحدود دى تختفى متفضلش ماشية الى مالا نهاية وتتحط فى السين
    private void OnTriggerExit(Collider other)  //when the other collider leaves boundary's trigger volume
    {
        Destroy(other.gameObject);  //كده محددتش مين الى يتدر كده اى حد هيعدى الحاجز هيتدمر ومفيش حد هيعدى غير الرصاصة
    }
 
}
