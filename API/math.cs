using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Expression
            {
                public string exp;
                public Queue<string> postExp = new Queue<string>();
                public Expression(string text)
                {
                    exp = text;
                }
                // public  Expression Parse()
                // {
                    

                //     return new Expression();
                // }
                public static bool IsOperatoe(string op){
                    if( op == "+" || op == "-" || op == "/" || op == "*" || op == ")" || op == "(")
                    {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                public static int Priority(string op)
                {
                    int value;
                    if(op == "(" || op == ")"){value = 0;return value;}
                    else if(op == "+" || op == "-"){value = 1;return value;}
                    else if(op == "/" || op == "*"){value = 2;return value;}
                    return -1;
                }
                public void inFixToPostFix()
                {
                        string nexp = "(" + this.exp + ")";
                        
                        int counter = 0;
                        string subV;
                        Stack<string> Op = new Stack<string>();
                        while(counter != nexp.Length)
                        {
                            subV =Convert.ToString( nexp[counter]);
                            Console.WriteLine(IsOperatoe(subV) + "         "+subV +  "         ------------=======================");
                            if(IsOperatoe(subV)) {
                                
                                if(Op.Count == 0) {
                                    Op.Push(subV);
                                    Console.WriteLine("pusshing into oper --------------" + subV);
                                    
                                }
                                else{
                                    if(Priority(subV) == 0)
                                    {
                                        Console.WriteLine("pusshing blabkabba");
                                        Op.Push(subV);
                                    }
                                    else{
                                        while(Priority(Op.Peek()) >= Priority(subV) )
                                        {
                                            if(Op.Count != 0) {
                                                Console.WriteLine(subV + "inside op pushin");
                                                Console.WriteLine(postExp.Peek() + "before pushing");
                                                Console.WriteLine(Op.Peek() + " top of op ");
                                            string val = Op.Pop();
                                            if(Priority(val) != 0)
                                            {
                                                postExp.Enqueue(val);
                                            }                                       
                                            

                                            Console.WriteLine(postExp.Peek() + " after the operation");

                                            }
                                            
                                            
                                            Console.WriteLine(Op.Peek() + "-------------------------end of iteration");
                                            
                                            
                                        }Op.Push(subV);
                                    }
                                
                                }
                                
                            
                                counter++;
                            } else{
                                int i = 1;//internal counter to catch the whole num
                                // int InternalCounter = 0;
                                string numS = Convert.ToString(nexp.Substring(counter,i));
                                //Console.WriteLine(numS);
                                while( counter <= nexp.Length - 1)
                                {
                                    if( counter + i < nexp.Length )
                                    {
                                        if (IsOperatoe(Convert.ToString(nexp[counter + i])))
                                            {

                                                break;
                                            }
                                        else
                                        {
                                            numS = nexp.Substring(counter , 1 + i);
                                            foreach(string s in postExp){
                                                Console.WriteLine(s + $"------in post fix-----{i}");
                                            }
                                            Console.WriteLine("");
                                            Console.WriteLine(numS + "  ---------------------    " + i);
                                            i++;
                                        }
                                    }else {break;}

                                
                                }
                            postExp.Enqueue(numS);
                                counter += i;
                            }


                            // if(counter == )
                        }

                    
                    foreach(string s in Op)
                    {
                        postExp.Enqueue(s);
                    }
                    foreach(string s in postExp){
                        Console.WriteLine(s + " inside infix to postfix");
                    }
                    string finalS;
                    for(int i = 0;i < postExp.Count();i++)
                    {
                        finalS = postExp.Dequeue();
                        if(IsOperatoe(finalS))
                        {
                            if(Priority(finalS) != 0){
                                postExp.Enqueue(finalS);
                            }
                        }else{
                            postExp.Enqueue(finalS);
                        }
                    }postExp.Dequeue();
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
                    foreach(string s in this.postExp)
                    {
                        Console.WriteLine("--------1--------");
                        Console.Write(s+"        ");

                    }
                    int item = postExp.Count ;
                    Console.WriteLine("postexp count =    " + item);
                    Stack<double> value = new Stack<double>();
                    
                    // postExp.Insert(0, "(");
                    // postExp.Insert(item, ")");
                    double n1 = 0,n2 = 0;
                    for(int i= 0; i < item ; i++)
                    {
                        // if(postExp[i] == "("){
                        //     oper.Push(postExp[i]);
                        // }
                        if(postExp.Peek() == "+"){
                            n1 = value.Pop();
                            n2 = value.Pop();
                            value.Push(n1 + n2);
                            postExp.Dequeue();
                        }
                        else if(postExp.Peek()== "-"){
                            n1 = value.Pop();
                            n2 = value.Pop();
                            value.Push(n2 - n1);
                            postExp.Dequeue();

                        }
                        else if(postExp.Peek() == "*"){
                            n1 = value.Pop();
                            n2 = value.Pop();
                            value.Push(n1 * n2);
                            postExp.Dequeue();
                        }
                        else if(postExp.Peek() == "/"){
                            n1 = value.Pop();
                            n2 = value.Pop();
                            value.Push(n2 / n1);
                            postExp.Dequeue();

                        }else if(postExp.Peek() == ")" ||postExp.Peek() == "(")
                        {
                            postExp.Dequeue();
                        }
                        else{
                            value.Push(Convert.ToDouble(postExp.Dequeue()));
                            Console.WriteLine("this is the top of the stakc" + value.Peek());
                        }
                    }
                    Console.WriteLine(value.Peek() + "top of the stack ---------- end");
                    ans = value.Peek();
                    return ans;
                }
            }
}