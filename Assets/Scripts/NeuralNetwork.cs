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
        float x = (float)weightedInput;
        return 1 / (1 + Mathf.Exp(-x));
    }
}

public class NeuralNetwork
{
    public Layer[] layers;

    public NeuralNetwork(params int[] layerSizes)
    {
        layers = new Layer[layerSizes.Length - 1];
        for (int i = 0;  i < layerSizes.Length; i++)
        {
            layers[i] = new Layer(layerSizes[i], layerSizes[i + 1]);
        }
    }

    public double[] CalculateOutputs(double[] inputs)
    {
        foreach (var layer in layers)
        {
            inputs = layer.CalculateOutputs(inputs);
        }
        return inputs;
    }

    int Classify(double[] inputs)
    {
        double[] outputs = CalculateOutputs(inputs);
        return IndexOfMaxValue(outputs);
    }

    int IndexOfMaxValue(double[] value)
    {
        int maxIndex = 0;
        double maxValue = 0;

        for (int i = 0; i < value.Length; i++)
        {
            if (value[i] > maxValue)
            {
                maxValue = value[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }
}
