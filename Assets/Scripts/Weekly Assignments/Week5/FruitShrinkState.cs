using UnityEngine;

public class FruitShrinkState : FruitBaseState
{
    public override void EnterState(FruitStateMachine fruit)
    {
        Debug.Log($"{fruit.fruitName} entered the Shrink Enter State");
        if (fruit.targetImage != null)
        {
            fruit.targetImage.color = Color.red;
        }
    }
    
    public override void UpdateState(FruitStateMachine fruit)
    {
        Debug.Log($"{fruit.fruitName} is in the Shrink Update State");
        float scalar = fruit.growFruitScalar;
        float min = fruit.minFruitSize;
        Vector3 scalarSize = new Vector3(scalar, scalar, scalar);

        if (fruit.transform.localScale.x > min)
        {
            Debug.Log($"{fruit.fruitName} is Shrinking");
            fruit.transform.localScale -= scalarSize * Time.deltaTime;
        } 
        else
        {
            fruit.SwitchState(fruit.GrowState);            
        }
    }
    
    public override void ExitState(FruitStateMachine fruit)
    {
        Debug.Log($"{fruit.fruitName} Exited Fruit Shrink State");
        if (fruit.particles != null)
        {
            var mainModule = fruit.particles.main;
            mainModule.startColor = Color.red;
            fruit.particles.Play();
        }
    }

}
