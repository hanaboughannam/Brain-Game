using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class EquationGenerator
{
    static Random ran = new Random();
    static string[] math_operator = { "+", "-", "*", "/" };
    /// <summary>
    /// return random equation via string array based on size
    /// </summary>
    /// <param name="arraysize"></param>
    /// <returns></returns>
    public static string[] generate(int arraysize)
    {
        string[] output = new string[arraysize];
        fetch_equation(ref output, 0);
        fetch_equation(ref output, 4);
        output[8] = fetch_ran_number().ToString();
        output[9] = fetch_ran_number().ToString();

        return output.OrderBy(x => ran.Next()).ToArray();
    }

    private static void fetch_equation(ref string[] output, int starting_index)
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

                if (a < b)
                {
                    int temp = a;
                    a = b;
                    b = temp;
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
                output[i] = a.ToString();
                i++;

                output[i] = "/";
                i++;

                output[i] = b.ToString();
                i++;

                c = a * b;
                output[i] = c.ToString();
                i++;

                break;
        }
    }

    private static string fetch_operator()
    {
        int n = ran.Next(0, math_operator.Length);

        return math_operator[n];
    }

    private static int fetch_ran_number()
    {
        int n = ran.Next(1, 10);

        return n;
    }
}

