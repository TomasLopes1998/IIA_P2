using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectByTorneio : SelectionMethod
{
    public override Individual selectIndividuals(List<Individual> oldpop, int num)
    {
        Individual individualToReturn;
        List<Individual> individualsToEval = new List<Individual>();
        int i = 0, index = 0;
        float best =0;
        while (i < num) {
            index = Random.Range(0, oldpop.Count-1);
            individualsToEval.Add(oldpop[index]);
            i++;
        }
        individualToReturn = individualsToEval[0];
        for (i=0;i<num;i++) {
            if (individualsToEval[i].Fitness>best) {
                best = individualsToEval[i].Fitness;
                individualToReturn = individualsToEval[i];
            }
        }
        if (individualToReturn == null) {
            Debug.Log("Why?");
        }
        return individualToReturn;
    }
}
