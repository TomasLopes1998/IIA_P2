using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MetaHeuristic {
	public float mutationProbability;
    public SelectionMethod select;
	public float crossoverProbability;
	public int tournamentSize;
	public bool elitist;
    public int n_elit;

	public override void InitPopulation () {
        population = new List<Individual>();
        // jncor 
        while (population.Count < populationSize)
        {
            GeneticIndividual new_ind = new GeneticIndividual(topology);
            new_ind.Initialize();
            population.Add(new_ind);
        }
       // throw new System.NotImplementedException ();
	}

	//The Step function assumes that the fitness values of all the individuals in the population have been calculated.
	public override void Step() {
        int nIndividualcreated = 0;
        List<Individual> newPopulation = new List<Individual>();
        if (elitist) {
            population.Sort();
            int i = 0;
            for (i = 0; i < n_elit;i++)
            {
                newPopulation.Add(population[i]);
                nIndividualcreated++;
            }
        }
        while (nIndividualcreated < populationSize) {
            Individual n1 = select.selectIndividuals(population, tournamentSize);
            Individual n2 = select.selectIndividuals(population, tournamentSize);
            Individual f1 = n1.Clone();
            Individual f2 = n2.Clone();
            f1.Crossover(f2, crossoverProbability);
            f2.Crossover(f1, crossoverProbability);
            f1.Mutate(mutationProbability);
            f2.Mutate(mutationProbability);
            newPopulation.Add(f1);
            nIndividualcreated++;
            if (nIndividualcreated<populationSize) {
                newPopulation.Add(f2);
            }
        }
        population = newPopulation;
    }

}
