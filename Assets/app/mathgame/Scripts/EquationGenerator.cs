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
    /// <summary>
    /// return random equation via string array based on size
    /// </summary>
    /// <param name="arraysize"></param>
    /// <returns></returns>
    public static string[] generate(string[] math_operator, bool allowNegatives, int min, int max, out string[] sampleEquation, bool returnScrambled = true)
    {
        MIN = min;
        MAX = max;
        MATH_OPERATOR = math_operator;

        string[] output = new string[ARRAYSIZE];

        sampleEquation = fetch_equation(ref output, 0, allowNegatives);

        fetch_equation(ref output, 4, allowNegatives);

        output[8] = fetch_ran_number().ToString();
        output[9] = fetch_ran_number().ToString();
        var scrambled = output.OrderBy(x => ran.Next()).ToArray();
        if (returnScrambled == true)
        {
            return scrambled;
        }
        else
            return output;
    }

    private static string[] fetch_equation(ref string[] output, int starting_index, bool allowNegatives)
    {
        int i = starting_index;
        int a, b, c;

        a = fetch_ran_number();
        b = fetch_ran_number();

        switch (fetch_operator())
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

    private static string fetch_operator()
    {
        int n = ran.Next(0, MATH_OPERATOR.Length);

        return MATH_OPERATOR[n];
    }

    private static int fetch_ran_number()
    {
        int n = ran.Next(MIN, MAX);

        return n;
    }
}
