/*
On a un tableau d'entiers positifs qui représente le cours d'une action dans le temps.
On cherche à acheter au plus bas et vendre au plus haut pour maximiser le gain. Écrire un algo qui retourne le gain maximum.
*/

public static class GapDetector
{
    public static int DetectbiggestGapInValues(List<int> listValues)
    {
        if (listValues.Count < 2)
        {
            return 0;
        }
        int minVal = listValues[0];
        int biggestGapInValues = 0;
        for (int i = 1; i < listValues.Count; i++)
        {
            minVal = minVal < listValues[i] ? minVal : listValues[i];
            biggestGapInValues =
                biggestGapInValues > listValues[i] - minVal
                    ? biggestGapInValues
                    : listValues[i] - minVal;
        }
        return biggestGapInValues;
    }
}
