using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticIndividual : Individual {


	public GeneticIndividual(int[] topology) : base(topology) {
	}

	public override void Initialize () 
	{
        for (int i = 0; i < totalSize; i++)
        {
            genotype[i] = Random.Range(-1.0f, 1.0f);
        }
    }
		
	public override void Crossover (Individual partner, float probability)
	{
        if (Random.Range(0.0f,1.0f) <= probability) {
            int min = Random.Range(0, totalSize-1);
            int max = Random.Range(0, totalSize-1);
            if (min>max) {
                int temp = min;
                min = max;
                max = temp;
            }
            float[] partnerGenotype = partner.getGenotype();
            for (int i = 0;i<totalSize;i++) {
                if (i>=min && i<=max) {
                    genotype[i] = partnerGenotype[i];
                }
            }

        }
        //throw new System.NotImplementedException();
    }

	public override void Mutate (float probability)
	{
        for (int i = 0; i < totalSize; i++)
        {
            if (Random.Range(0.0f, 1.0f) <= probability)
            {
                genotype[i] = Random.Range(-1.0f, 1.0f);
            }
        }
    }

	public override Individual Clone ()
	{
		GeneticIndividual new_ind = new GeneticIndividual(this.topology);

		genotype.CopyTo (new_ind.genotype, 0);
		new_ind.fitness = this.Fitness;
		new_ind.evaluated = false;

		return new_ind;
	}

}
