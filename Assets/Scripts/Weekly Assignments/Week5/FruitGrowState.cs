using UnityEngine;

public class FruitGrowState : FruitBaseState
{
    public override void EnterState(FruitStateMachine fruit)
    {
        Debug.Log($"{fruit.fruitName} entered the Grow Enter State");
        if (fruit.targetImage != null)
        {
            fruit.targetImage.color = Color.blue;
        }
    }
    
    public override void UpdateState(FruitStateMachine fruit)
    {
        Debug.Log($"{fruit.fruitName} is in the Grow Update State");
        float scalar = fruit.growFruitScalar;
        float max = fruit.maxFruitSize;
        Vector3 scalarSize = new Vector3(scalar, scalar, scalar);

        if (fruit.transform.localScale.x < max)
        {
            Debug.Log($"{fruit.fruitName} is Growing");
            fruit.transform.localScale += scalarSize * Time.deltaTime;
        } 
        else
        {
            fruit.SwitchState(fruit.ShrinkState);            
        }
    }
    
    public override void ExitState(FruitStateMachine fruit)
    {
        Debug.Log($"{fruit.fruitName} Exited Fruit Grow State");
        if (fruit.particles != null)
        {
            var mainModule = fruit.particles.main;
            mainModule.startColor = Color.blue;
            fruit.particles.Play();
        }
    }

}
