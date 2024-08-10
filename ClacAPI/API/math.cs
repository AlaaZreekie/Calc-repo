using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Expression
    {
                private static Dictionary<string, int> Operations = new Dictionary<string, int>()
                {
                    { "(", 0 }, { ")", 0 },
                    { "+", 1 }, { "-", 1 },
                    { "/", 2 }, { "*", 2 },
                    { "}", 0 }, { "{", 0 }
                };

                public string ExpressionText { get; set; }

                public Queue<string> Postfix_Expression { get; } = new Queue<string>();

                public Expression(string text)
                {
                    ExpressionText = text;
                }
                public Expression()
                {
                    
                }

                private static bool IsOperator(string op)
                {
                    return Operations.ContainsKey(op);
                }

                public static int Precedence(string op)
                {
                    if (!IsOperator(op)) return -1;
                    return Operations[op];
                }
                
                public void inFixToPostFix()
                {
                    string expression = "(" + ExpressionText + ")";

                    int counter = 0;
                    string token;
                    Stack<string> Ops = new Stack<string>();
                    expression.Replace(" ", "");
                    while (counter != expression.Length)
                    {
                        token = Convert.ToString(expression[counter]);
                        if (IsOperator(token))
                        {
                            if (Ops.Count == 0)
                            {
                                Ops.Push(token);
                                Console.WriteLine("Push {0} to an empty stack", token);
                            }
                            else
                            {
                                if (Precedence(token) == 0)
                                {
                                    if(token == ")" && Ops.Count != 0)
                                    {
                                        while(Ops.Peek() != "(" && Ops.Count != 0)
                                        {
                                            Postfix_Expression.Enqueue(Ops.Pop());
                                        }
                                        Ops.Push(token);


                                    }
                                    else{
                                        Console.WriteLine("Push bracket {0}  ", token);
                                        Ops.Push(token);
                                    }
                                }
                                else
                                {
                                    while (Ops.Count > 0 && Precedence(Ops.Peek()) >= Precedence(token))
                                    {
                                        Console.WriteLine(token + "--------------------------------inside op pushing");
                                        Console.WriteLine(Postfix_Expression.Peek() + "-----------------before pushing");
                                        Console.WriteLine(Ops.Peek() + " top of op ");
                                        string val = Ops.Pop();
                                        if (Precedence(val) != 0)
                                        {
                                            Postfix_Expression.Enqueue(val);
                                        }
                                        Console.WriteLine(Postfix_Expression.Peek() + " ----------------after the operation");
                                    }
                                    Ops.Push(token);
                                }

                            }


                            counter++;
                        }
                        else
                        {
                            int i = 1;//internal counter to catch the whole num
                                    // int InternalCounter = 0;
                            string numS = Convert.ToString(expression.Substring(counter, i));
                            //Console.WriteLine(numS);
                            while (counter <= expression.Length - 1)
                            {
                                if (counter + i < expression.Length)
                                {
                                    if (IsOperator(Convert.ToString(expression[counter + i])))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        numS = expression.Substring(counter, 1 + i);
                                        foreach (string s in Postfix_Expression)
                                        {
                                            Console.WriteLine(s + $"------in post fix-----{i}");
                                        }
                                        Console.WriteLine("");
                                        Console.WriteLine(numS + "  ---------------------    " + i);
                                        i++;
                                    }
                                }
                                else { break; }


                            }
                            Postfix_Expression.Enqueue(numS);
                            counter += i;
                        }


                        // if(counter == )
                    }


                    foreach (string s in Ops)
                    {
                        Postfix_Expression.Enqueue(s);
                    }
                    foreach (string s in Postfix_Expression)
                    {
                        Console.WriteLine(s + " inside infix to postfix");
                    }
                    string finalS;
                    int numOfToken = Postfix_Expression.Count();
                    for (int i = 0; i < numOfToken; i++)
                    {
                        finalS = Postfix_Expression.Dequeue();
                        if (IsOperator(finalS))
                        {
                            if (Precedence(finalS) != 0)
                            {
                                Postfix_Expression.Enqueue(finalS);
                            }
                        }
                        else
                        {
                            Postfix_Expression.Enqueue(finalS);
                        }
                    }
                    // Postfix_Expression.Dequeue();
                }
                // public long Evaluate()
                // {
                //     return 0;
                // }
                //postfix to value

                public double Evaluate()//postfix to value
                {
                    inFixToPostFix();
                    double ans = 0;
                    foreach (string s in this.Postfix_Expression)
                    {
                        Console.WriteLine("--------1--------");
                        Console.WriteLine(s + "        ");

                    }
                    int item = Postfix_Expression.Count;
                    Console.WriteLine("Postfix_Expression count =    " + item);
                    Stack<double> value = new Stack<double>();

                    // Postfix_Expression.Insert(0, "(");
                    // Postfix_Expression.Insert(item, ")");
                    double n1 = 0, n2 = 0;
                    double num = 0;

                    for (int i = 0; i < item; i++)
                    {
                        if (Postfix_Expression.Peek() == "+")
                        {
                            n1 = value.Pop();
                            n2 = value.Pop();
                            num = n1 + n2;
                            value.Push(num);
                            Console.WriteLine(value.Peek() + "--------pushing");
                            Postfix_Expression.Dequeue();
                        }
                        else if (Postfix_Expression.Peek() == "-")
                        {
                            n1 = value.Pop();
                            n2 = value.Pop();
                            num = n2 - n1;
                            value.Push(num);
                            Console.WriteLine(value.Peek() + "--------pushing");
                            Postfix_Expression.Dequeue();

                        }
                        else if (Postfix_Expression.Peek() == "*")
                        {
                            n1 = value.Pop();
                            n2 = value.Pop();
                            num = n1 * n2;

                            value.Push(num);
                            Console.WriteLine(value.Peek() + "--------pushing");
                            Postfix_Expression.Dequeue();
                        }
                        else if (Postfix_Expression.Peek() == "/")
                        {
                            n1 = value.Pop();
                            n2 = value.Pop();
                            num = n2 / n1;
                            value.Push(num);
                            Console.WriteLine(value.Peek() + "--------pushing");

                            Postfix_Expression.Dequeue();

                        }
                        else if (Postfix_Expression.Peek() == ")" || Postfix_Expression.Peek() == "(")
                        {
                            Postfix_Expression.Dequeue();
                        }
                        else
                        {
                            value.Push(Convert.ToDouble(Postfix_Expression.Dequeue()));
                            Console.WriteLine("this is the top of the stakc  now " + value.Peek());
                        }
                    }
                    Console.WriteLine(value.Peek() + "top of the stack ---------- end");
                    ans = value.Peek();
                    return ans;
                }
        }
}