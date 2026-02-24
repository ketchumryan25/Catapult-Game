using UnityEngine;
using UnityEngine.U2D;

public class FruitInitializeState : FruitBaseState
{
    
    public override void EnterState(FruitStateMachine fruit)
    {
        Debug.Log($"{fruit.fruitName} entered the Intialize Enter State");

        fruit.start = fruit.startFruitSize;
        fruit.startSize = new Vector3(fruit.start, fruit.start, fruit.start);
        fruit.transform.localScale = fruit.startSize;

        string spriteName = $"{fruit.fruitName}";    
        SpriteAtlas spriteAtlas = Resources.Load<SpriteAtlas>(fruit.spriteAtlasName);
        fruit.selectedSprite = spriteAtlas.GetSprite(spriteName);
        fruit.spriteRenderer = fruit.GetComponent<SpriteRenderer>();
        if (fruit.spriteRenderer != null)
        {
            if (fruit.selectedSprite != null)
            {
                fruit.spriteRenderer.sprite = fruit.selectedSprite;
            }
            else
            {
                Debug.LogWarning($"Sprite with name {spriteName} not found");
            }
        }
        else
        {
            Debug.LogWarning($"No SpriteRenderer component found on {spriteName} object");
        }
    }
    
    public override void UpdateState(FruitStateMachine fruit)
    {
        Debug.Log($"{fruit.fruitName} is in the Initialize Update State");
        float max = fruit.maxFruitSize;
        fruit.currentSize = fruit.transform.localScale;
        bool isInitialized = false;
        
        if (fruit.currentSize == fruit.startSize && fruit.spriteRenderer.sprite == fruit.selectedSprite)
        {
            isInitialized = true;
        }
        if (isInitialized)
        {
            Debug.Log($"{fruit.fruitName} has Initialized");

            if (fruit.currentSize.x < max)
            {
                fruit.SwitchState(fruit.GrowState);
            }
            if (fruit.currentSize.x > max)
            {
                fruit.SwitchState(fruit.ShrinkState);
            }
        }
    }
    
    public override void ExitState(FruitStateMachine fruit)
    {
        Debug.Log($"{fruit.fruitName} Exited Fruit Initialize State");
        if (fruit.particles != null)
        {
            var mainModule = fruit.particles.main;
            mainModule.startColor = Color.green;
            fruit.particles.Play();
        }
    }

}
