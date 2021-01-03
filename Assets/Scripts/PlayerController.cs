using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    float input_x = 0;
    float input_y = 0;
    public float speed = 2.5f;
    bool walking = false;

    // Start is called before the first frame update
    void Start()
    {
        walking = false;
    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        walking = (input_x != 0 || input_y != 0);

        if (walking)
        {
            var move = new Vector3(input_x, input_y, 0).normalized;
            transform.position += move * speed * Time.deltaTime;
            playerAnimator.SetFloat("inputX", input_x);
            playerAnimator.SetFloat("inputY", input_y);
        }

        playerAnimator.SetBool("walking", walking);

        if (Input.GetButtonDown("Fire1"))
            playerAnimator.SetTrigger("attack");
    }
}