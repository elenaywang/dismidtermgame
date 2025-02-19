using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// add this script to the Platformer Player game object

public class PlayerAnimator : MonoBehaviour
{
    public enum AnimationState {
        Idle,
        Walk,
        Jump
    }

    public float animationFPS = 7; 
    public Sprite[] idleAnim;
    public Sprite[] walkAnim; 
    public Sprite[] jumpAnim;

    private Rigidbody2D rb2d;
    private PlayerPlatformerController controller;
    private SpriteRenderer sr;

    private float frameTimer = 0;
    private int frameIndex = 0;
    private AnimationState state = AnimationState.Idle;
    private Dictionary<AnimationState, Sprite[]> animationAtlas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animationAtlas = new Dictionary<AnimationState, Sprite[]>();
        animationAtlas.Add(AnimationState.Idle, idleAnim);
        animationAtlas.Add(AnimationState.Walk, walkAnim);
        animationAtlas.Add(AnimationState.Jump, jumpAnim);

        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerPlatformerController>();
    }


    // Update is called once per frame
    void Update()
    {
        AnimationState newState = GetAnimationState();
        if (state != newState) {
            TransitionToState(newState);
        }

        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0.0f) {
            frameTimer = 1 / animationFPS;
            Sprite[] anim = animationAtlas[state];
            frameIndex %= anim.Length;
            sr.sprite = anim[frameIndex];
            frameIndex++;
        }

        if (rb2d.linearVelocity.x < -0.01f) {
            sr.flipX = true;
        }

        if (rb2d.linearVelocity.x > 0.01f) {
            sr.flipX = false;
        }
    }


    void TransitionToState(AnimationState newState) {
        frameTimer = 0.0f;
        frameIndex = 0;
        state = newState;
    }

    AnimationState GetAnimationState() {
        if (!controller.grounded) {
            return AnimationState.Jump;
        }
        if (Mathf.Abs(rb2d.linearVelocity.x) > 0.1f) {
            return AnimationState.Walk;
        }
        return AnimationState.Idle;
    }
}
