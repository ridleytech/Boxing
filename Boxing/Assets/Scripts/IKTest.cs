using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTest : MonoBehaviour
{

    public Animator anim;
    public Transform targetObject;
    public float weight = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnAnimatorIK () {
        print("On IK");
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
        anim.SetIKPosition(AvatarIKGoal.RightHand, targetObject.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
