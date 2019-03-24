using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class EquationGenerator
{
    static Random ran = new Random();
    static string[] MATH_OPERATOR;
    static int MIN, MAX;
    static int ARRAYSIZE = 10;

    static bool ALLOW_NUMBER_Triples = false;
    static List<int> usedNumbers = new List<int>();
    /// <summary>
    /// return random equation via string array based on size
    /// </summary>
    /// <param name="arraysize"></param>
    /// <returns></returns>
    public static string[] generate(string[] math_operator, bool allowNegatives, int min, int max, out string[] sampleEquation, bool returnScrambled = true)
    {
        ClearUsedNumberCashe();
        MIN = min;
        MAX = max;
        MATH_OPERATOR = math_operator;

        string[] output = new string[ARRAYSIZE];
        //get 4 elements
        sampleEquation = fetch_equation(ref output, 0, allowNegatives);
        //get 4 elements
        fetch_equation(ref output, 4, allowNegatives);
        //get 2 elements
        output[8] = fetch_ran_number(min,max).ToString();
        output[9] = fetch_ran_number(min,max).ToString();

        var scrambled = output.OrderBy(x => ran.Next()).ToArray();
        if (returnScrambled == true)
        {
            return scrambled;
        }
        else
            return output;
    }

    private static void ClearUsedNumberCashe()
    {
        usedNumbers.Clear();
    }

    private static string[] fetch_equation(ref string[] output, int starting_index, bool allowNegatives)
    {
        int i = starting_index;
        int a, b, c;

        a = fetch_ran_number(MIN,MAX);
        b = fetch_ran_number(MIN,MAX);

        switch (fetch_ran_operator())
        {
            case "+":

                output[i] = a.ToString();
                i++;

                output[i] = "+";
                i++;

                output[i] = b.ToString();
                i++;

                c = a + b;
                output[i] = c.ToString();
                i++;

                break;
            case "-":


                if (!allowNegatives)
                {
                    if (a < b)
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                    }
                }

                output[i] = a.ToString();
                i++;

                output[i] = "-";
                i++;

                output[i] = b.ToString();
                i++;

                c = a - b;
                output[i] = c.ToString();
                i++;

                break;
            case "*":

                output[i] = a.ToString();
                i++;

                output[i] = "*";
                i++;

                output[i] = b.ToString();
                i++;

                c = a * b;
                output[i] = c.ToString();
                i++;

                break;
            case "/":

                c = a * b;

                output[i] = c.ToString();
                i++;

                output[i] = "/";
                i++;

                output[i] = a.ToString();
                i++;

                
                output[i] = b.ToString();
                i++;

                break;
        }

        string[] equation = new string[4];

        for (int j = starting_index; j < equation.Length; j++)
        {
            equation[j] = output[j];
        }

        return equation;
    }

    private static string fetch_ran_operator()
    {
        int n = ran.Next(0, MATH_OPERATOR.Length);

        return MATH_OPERATOR[n];
    }

    private static int fetch_ran_number(int min,int max)
    {
        int n = ran.Next(min, max);
        usedNumbers.Add(n);

        if (FindNumberofOccurences(usedNumbers, n) > 3)
            return fetch_ran_number(min, max);
        else
            return n;
    }
    
    static int FindNumberofOccurences(List<int> arr, int num)
    {
        int count = 0;
        foreach (var item in arr)
        {
            if (item == num)
                count++;
        }
        return count;
    }
}
