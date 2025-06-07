using UnityEngine;

public class Layer
{
    int numNodesIn, numNodesOut;
    double[,] weights;
    double[] biases;

    public Layer(int numNodesIn, int numNodesOut)
    {
        this.numNodesIn = numNodesIn;
        this.numNodesOut = numNodesOut;

        weights = new double[numNodesIn, numNodesOut];
        biases = new double[numNodesOut];
    }

    public double[] CalculateOutputs(double[] inputs)
    {
        double[] weightedInputs = new double[numNodesOut];

        for (int nodeOut = 0; nodeOut < numNodesOut; nodeOut++)
        {
            double weightedInput = biases[nodeOut];

            for (int nodeIn = 0; nodeIn < numNodesIn; nodeIn++)
            {
                weightedInput += inputs[nodeIn] * weights[nodeIn, nodeOut];
            }

            weightedInputs[nodeOut] = ActivationFunction(weightedInput);
        }

        return weightedInputs;
    }

    double ActivationFunction(double weightedInput)
    {
        return weightedInput;
    }
}

public class NeuralNetwork
{
    
}
