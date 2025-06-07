using UnityEngine;

public class GameManager : MonoBehaviour
{
    public NeuralNetwork brain;

    private void Start()
    {
        brain = new NeuralNetwork(2, 3, 2);
    }
}
