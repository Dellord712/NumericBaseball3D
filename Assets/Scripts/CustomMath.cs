using System.Collections.Generic;

public static class CustomMath
{
    public static int[] Combination(int selectCount, int startNum, int endNum)
    {
        int[] c = new int[selectCount];
        List<int> list = new List<int>();
        for (int i = startNum; i <= endNum; i++) list.Add(i);
        int random;
        for(int i=0;i<selectCount;i++)
        {
            random = UnityEngine.Random.Range(0, list.Count);
            c[i] = list[random];
            list.RemoveAt(random);
        }
        return c;
    }
}
