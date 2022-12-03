using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electronic : MonoBehaviour
{
    public static void sort(List<float> list)
	{
		int len = list.Count/3;
		for(int i = 0; i < len; i++)
			for(int j = 0; j < len-i-1; j++)
				if(list[j*3+2] < list[(j+1)*3+2])
					for(int k = 0; k < 3; k++)
						swap(list, j*3+k, (j+1)*3+k);
		for(int i = 0; i < len; i++)
			for(int j = 0; j < len-i-1; j++)
				if(list[j*3+1] > list[(j+1)*3+1])
					for(int k = 0; k < 3; k++)
						swap(list, j*3+k, (j+1)*3+k);
	}
	public static void swap(List<float> list, int i, int j)
	{
		float temp = list[i];
		list[i] = list[j];
		list[j] = temp;
	}
	public static void seriesMerge(List<float> list, List<Dictionary<List<float>, List<float>>> tb)
	{
		List<int> canMerge = new List<int>();
		int len = list.Count/3;
		float thisE, nextS;
		for(int i = 0; i < len-1; i++)
		{
			thisE = list[i*3+2];
			nextS = list[(i+1)*3+1];
			if(thisE == nextS)
			{
				canMerge.Add(i);
				canMerge.Add((int)thisE);
			}
		}
		Dictionary<float, float> countMap = new Dictionary<float, float>();
		for(int i = 0; i < len; i++)
		{
			for(int j = 1; j <= 2; j++)
				if(!countMap.ContainsKey(list[i*3+j]))
					countMap.Add(list[i*3+j], 1f);
				else
					countMap[list[i*3+j]] = countMap[list[i*3+j]]+1;
		}
		for(int i = 0; i < canMerge.Count/2; i++)
		{
			if (countMap[(float)canMerge[i*2+1]] > 2)
			{
				for (int j = 0; j < 2; j++)
					canMerge.RemoveAt(i*2);
				i--;
			}
		}
		int[] reduced = new int[canMerge.Count/2];
		for(int i = 0; i < canMerge.Count/2; i++)
		{
			reduced[i] = canMerge[i*2];
		}
		canMerge = new List<int>();
		for(int i = 0; i < reduced.Length; i++)	canMerge.Add(reduced[i]);
		int check = 0;
		for(int i = 0; i < canMerge.Count; i++)
			operate_Two_Series(list, canMerge[i]-check++, tb);
	}
	
	public static void operate_Two_Series(List<float> list, int i, List<Dictionary<List<float>, List<float>>> tb)
	{
		float temp = list[i*3]+list[(i+1)*3];
		List<float> end = new List<float>();
		List<float> origin = new List<float>();
		for(int j = 0; j < 6; j++) origin.Add(list[i*3+j]);
		list[i*3] = temp;
		for(int k = 0; k < 3; k++) list.RemoveAt(i*3+2);
		for(int j = 0; j < 3; j++) end.Add(list[i*3+j]);
		for(int j = 0; j < 5; j++)
		{
			if(tb[j].ContainsKey(end)) continue;
			tb[j][end] = origin;
			break;
		}
	}
	public static void parallelMerge(List<float> list, List<Dictionary<List<float>, List<float>>> tb)
	{
		List<int> canParallel = new List<int>();
		int len = list.Count/3;
		float thisS, nextS, thisE, nextE;
		for(int i = 0; i < len-1; i++)
		{
			thisS = list[i*3+1];
			thisE = list[i*3+2];
			nextS = list[(i+1)*3+1];
			nextE = list[(i+1)*3+2];
			if(thisS == nextS && thisE == nextE) canParallel.Add(i);
		}
		int check = 0;
		for(int i = 0; i < canParallel.Count; i++)
		{
			operate_Two_parallel(list, canParallel[i]-check++, tb);
		}
	}
	public static void operate_Two_parallel(List<float> list, int i, List<Dictionary<List<float>,List<float>>> tb)
	{
		float temp = parallel(list[i*3], list[(i+1)*3]);
		List<float> end = new List<float>();
		List<float> origin = new List<float>();
		for(int j = 0; j < 6; j++) origin.Add(list[i*3+j]);
		list[i*3] = temp;
		for(int k = 0; k < 3; k++) list.RemoveAt((i+1)*3);
		for(int j = 0; j < 3; j++) end.Add(list[i*3+j]);
		for(int j = 0; j < 5; j++)
		{
			if(tb[j].ContainsKey(end)) continue;
			tb[j][end] = origin;
			break;
		}
	}
	public static float parallel(float a, float b)
	{
		return a*b/(a+b);
	}
	public static void bridge(List<float> list, List<Dictionary<List<float>, List<float>>> tb)
	{
		int len = list.Count/3;
		if(len < 5) return;
		for(int i = 0; i < len-4; i++)
		{
			bool Out = false;
			List<float> judge = new List<float>();
			Dictionary<float, float> countMap = new Dictionary<float, float>();
			for(int j = i; j < i+5; j++)
			{
				for(int k = 1; k <= 2; k++)
				{
					if(!countMap.ContainsKey(list[j*3+k]))
						countMap.Add(list[j*3+k], 1f);
					else
						countMap[list[j*3+k]] = countMap[list[j*3+k]] + 1;
				}
			}
			float[] assign = {2.0f, 3.0f, 3.0f, 2.0f};
			int count = 0;
			float[] keys = {-1f, -1f,-1f, -1f};
			foreach(float key in countMap.Keys)
			{
				keys[count] = key;
				if(assign[count++] != countMap[key])
				{
					Out = true;
					break;
				}
			}
			if(Out) continue;
			// print("bridge");
			for(int j = i*3; j < i*3+15; j++) judge.Add(list[j]);
			float sum = judge[0]+judge[3]+judge[9];
			float delta1 = judge[0]*judge[3]/sum;
			float delta2 = judge[3]*judge[9]/sum;
			float delta3 = judge[0]*judge[9]/sum;
			float total = delta1 + parallel(delta2 + judge[6], delta3 + judge[12]);
			List<float> end = new List<float>();
			List<float> origin = new List<float>();
			for(int j = 0; j < 15; j++) origin.Add(judge[j]);
			list[i*3] = total;
			list[i*3+2] = list[i*3+14];
			for(int j = i*3+3; j < i*3+15l; j++) list.RemoveAt(i*3+3);
			for(int j = 0; j < 3; j++) end.Add(list[i*3+j]);
			for(int j = 0; j < 5; j++)
			{
				if(tb[j].ContainsKey(end)) continue;
				tb[j][end] = origin;
				break;
			}
			return;
		}
	}
}