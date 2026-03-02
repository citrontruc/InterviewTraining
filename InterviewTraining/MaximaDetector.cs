/*
On a un tableau d'entiers positifs qui représente le cours d'une action dans le temps.
On cherche à acheter au plus bas et vendre au plus haut pour maximiser le gain. Écrire un algo qui retourne le gain maximum.
*/

public static class MaximaDetector
{
    // Sans doute possible de faire une récursion mais très risqué et sans doute beaucoup de cas redondants.
    // Possibilité d'utiliser deux pointeurs mais on possède un risque en cas d'égalité car il faut faire avancer l'une des deux valeurs.
    public static int Detect(List<int> listValues)
    {
        if (listValues.Count < 2)
        {
            return 0;
        }

        int rightPointer = 1;
        int leftPointer = 0;
        int maxVal = Math.Max(listValues[^rightPointer] - listValues[leftPointer], 0);
        while (rightPointer + leftPointer < listValues.Count - 1)
        {
            while (
                (listValues[leftPointer + 1] <= listValues[leftPointer])
                && leftPointer < listValues.Count - 1 - rightPointer
            )
            {
                leftPointer += 1;
            }

            while (
                (listValues[^(rightPointer + 1)] >= listValues[^rightPointer])
                && rightPointer < listValues.Count - 1 - leftPointer
            )
            {
                rightPointer += 1;
            }

            if (listValues[^rightPointer] - listValues[leftPointer] > maxVal)
            {
                maxVal = listValues[^rightPointer] - listValues[leftPointer];
            }

            if (
                listValues[leftPointer] - listValues[leftPointer + 1]
                >= listValues[^(rightPointer + 1)] - listValues[rightPointer]
            )
            {
                leftPointer += 1;
            }
            else
            {
                rightPointer += 1;
            }
        }
        return maxVal;
    }

    public static int CorrectedDetect(List<int> listValues)
    {
        if (listValues.Count < 2)
        {
            return 0;
        }

        int min = listValues.Max();
        int maxDiff = 0;

        foreach (var p in listValues)
        {
            min = Math.Min(min, p);
            maxDiff = Math.Max(maxDiff, p - min);
        }

        return maxDiff;
    }
}
