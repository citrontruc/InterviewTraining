public class FindSubStringInString
{
    public static IList<int> FindSubstring(string s, string[] words)
    {
        List<int> result = new();
        Dictionary<string, int> wordCount = new();
        Dictionary<string, int> slidingWordWindow = new();
        int numWords = words.Length;
        int wordLen = words[0].Length;

        foreach (string word in words)
        {
            if (!wordCount.ContainsKey(word))
            {
                wordCount[word] = 0;
                slidingWordWindow[word] = 0;
            }
            wordCount[word]++;
        }

        int leftPointer = 0;
        int interNumWords = 0;
        while (leftPointer + wordLen * (interNumWords + 1) <= s.Length)
        {
            bool resetVar = false;
            string currentWord = s[
                (leftPointer + interNumWords * wordLen)..(
                    leftPointer + (interNumWords + 1) * wordLen
                )
            ];
            if (
                slidingWordWindow.ContainsKey(currentWord)
                && (slidingWordWindow[currentWord] + 1 <= wordCount[currentWord])
            )
            {
                slidingWordWindow[currentWord]++;
                interNumWords++;
            }
            else
            {
                resetVar = true;
            }

            if (interNumWords == numWords)
            {
                result.Add(leftPointer);
                resetVar = true;
            }

            if (resetVar)
            {
                leftPointer++;
                while (
                    leftPointer + wordLen < s.Length
                    && !slidingWordWindow.ContainsKey(s[leftPointer..(leftPointer + wordLen)])
                )
                {
                    leftPointer++;
                }

                interNumWords = 0;
                foreach (var key in slidingWordWindow.Keys.ToList())
                {
                    slidingWordWindow[key] = 0;
                }
            }
        }
        return result;
    }

    public static IList<int> FindSubstringOptimal(string s, string[] words)
    {
        List<int> result = new();
        int numWords = words.Length;
        int wordLen = words[0].Length;
        int totalLen = numWords * wordLen;
        if (s.Length < totalLen)
            return result;

        Dictionary<string, int> wordCount = new();
        foreach (string word in words)
        {
            wordCount[word] = wordCount.GetValueOrDefault(word) + 1;
        }

        for (int i = 0; i < wordLen; i++)
        {
            int leftPointer = i;
            int rightPointer = i;
            int interNumWords = 0;
            Dictionary<string, int> slidingWordWindow = new();

            while (rightPointer + wordLen <= s.Length)
            {
                string currentWord = s.Substring(rightPointer, wordLen);
                rightPointer += wordLen;

                if (wordCount.ContainsKey(currentWord))
                {
                    slidingWordWindow[currentWord] =
                        slidingWordWindow.GetValueOrDefault(currentWord) + 1;
                    interNumWords++;

                    while (slidingWordWindow[currentWord] > wordCount[currentWord])
                    {
                        string leftWord = s.Substring(leftPointer, wordLen);
                        slidingWordWindow[leftWord]--;
                        interNumWords--;
                        leftPointer += wordLen;
                    }

                    if (interNumWords == numWords)
                        result.Add(leftPointer);
                }
                else
                {
                    slidingWordWindow.Clear();
                    interNumWords = 0;
                    leftPointer = rightPointer;
                }
            }
        }
        return result;
    }
}
