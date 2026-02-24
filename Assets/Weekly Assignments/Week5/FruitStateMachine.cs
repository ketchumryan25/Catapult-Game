using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class FruitStateMachine : MonoBehaviour
{
    FruitBaseState currentState;
    public FruitGrowState GrowState = new FruitGrowState();
    public FruitShrinkState ShrinkState = new FruitShrinkState();
    public FruitInitializeState InitializeState = new FruitInitializeState();
    [HideInInspector] public float start;
    [HideInInspector] public Vector3 startSize;
    [HideInInspector] public Vector3 currentSize;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Sprite selectedSprite;
    [SerializeField] public ParticleSystem particles;
    [SerializeField] public Image targetImage;
    [SerializeField] public string spriteAtlasName;
    [SerializeField] public string fruitName;
    [SerializeField] public float startFruitSize;
    [SerializeField] public float maxFruitSize;
    [SerializeField] public float minFruitSize;
    [SerializeField] public float growFruitScalar;

    // Start is called before the first frame update
    void Start()
    {
        currentState = InitializeState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(FruitBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }
}
