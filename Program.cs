using System;

namespace Online_Grocery_Store
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool valid, run = true;
            string input;
            string[] splitInput;
            Int32 amount = 0;

            //while you want to keep entering orders
            //while loop ends when end is entered into console
            while (run == true)
            {
                valid = true; //set input to valid by default
                Console.Write("Place new order: ");
                input = Console.ReadLine();

                //user enters "end" to end their order
                if (input == "end")
                {
                    break;
                }

                //split the input string into amount and product
                splitInput = input.Split(" ");
                
                //try to determine order amount. If unable to, prompt the user to re-enter
                try{
                    Int32.Parse(splitInput[0]);
                } catch (FormatException){
                    Console.WriteLine("Enter valid amount or 'end' to finish order");
                    valid = false;
                }

                //if the amount is valid then save it
                if(valid){
                    amount = Int32.Parse(splitInput[0]);
                }

                //if the amount is not valid then skip the other checks and start the loop again
                if(!valid){

                }else if(splitInput.Length != 2){
                    //check the order has no more than amount and product code
                    Console.WriteLine("Enter valid order or 'end' to finish order");
                }else if (splitInput[1] == "SH3" )
                {
                    //if product is ham then run SH3() to calculate quantities
                    SH3(amount);
                }else if (splitInput[1] == "YT2")
                {
                    //if product is yoghurt then run YT2() to calculate quantities
                    YT2(amount);
                }else if (splitInput[1] == "TR")
                {
                    //if product is toilet rolls then run TR() to calculate quantities
                    TR(amount);
                }else
                {
                    //if the product code was not one of the three listed, then try again
                    Console.WriteLine("Enter valid product or 'end' to finish order");
                }
            }
        }

        static void SH3(Int32 ham){
            Double total = 0;
            Double five = 0;
            Double three = 0;
            Int32 count = ham;
            //calculate the optimal number of packs for the amount
            while (count > 0)
            {
                if(count == 4){
                    //unable to get exactly 4 hams so get 5 instead
                    five+=1;
                    total+=4.49;
                    count=0;
                }else if(count % 5 == 0){
                    five+=1;
                    total+=4.49;
                    count-=5;
                }else{
                    three+=1;
                    total+=2.99;
                    count-=3;
                }
            }
            //write output totals to the console
            Console.WriteLine("{0} SH3 ${1}", ham, total);
            if(five > 0){
                Console.WriteLine("  {0} x 5 $4.49", five);
            }
            if(three > 0){
                Console.WriteLine("  {0} x 3 $2.99", three);
            }    
        }

        static void YT2(Int32 yoghurt){
            Double total = 0;
            Double fifteen = 0;
            Double ten = 0;
            Double four = 0;
            Int32 count = yoghurt;
            //calculate the optimal number of packs for the amount
            while (count > 0)
            {
                if(count == 5){
                    //unable to get exactly 5 so get 2 x 4 instead
                    four+=2;
                    total+=9.9;
                    count=0;
                }else if(count == 9 || count == 13 || count == 21){
                    //unable to get 9, 13 or 21 exactly
                    //it is cheaper to get 1 ten and the rest 4's until you have
                        //at least the amount ordered
                    ten+=1;
                    total+=9.95;
                    count-=10;
                }else if(count % 5 == 0){
                    if(count % 15 ==0){
                        fifteen+=1;
                        total+=13.95;
                        count-=15;
                    }else{
                        ten+=1;
                        total+=9.95;
                        count-=10;
                    }
                }else{
                    four+=1;
                    total+=4.95;
                    count-=4;
                }
            }
            //write output totals to the console
            Console.WriteLine("{0} YT2 ${1}", yoghurt, total);
            if(fifteen > 0){
                Console.WriteLine("  {0} x 15 $4.49", fifteen);
            }
            if(ten > 0){
                Console.WriteLine("  {0} x 10 $9.95", ten);
            }
            if(four > 0){
                Console.WriteLine("  {0} x 4 $2.99", four);
            }     
        }

        static void TR(Int32 rolls){
            Double total = 0;
            Double nine = 0;
            Double five = 0;
            Double three = 0;
            Int32 count = rolls;
            //calculate the optimal number of packs for the amount
            while (count > 0)
            {
                if(count == 4){
                    //unable to get exactly 4 so get 5 instead
                    //it is cheaper to get 5 than 2 x 3
                    five+=1;
                    total+=4.45;
                    count=0;
                }else if(count % 9 == 0){
                    nine+=1;
                    total+=7.99;
                    count-=9;
                }else if(count % 5 == 0){
                    five+=1;
                    total+=4.45;
                    count-=5;
                }else{
                    three+=1;
                    total+=2.95;
                    count-=3;
                }
            }
            //write output totals to the console
            Console.WriteLine("{0} TR ${1}", rolls, total);
            if(nine > 0){
                Console.WriteLine("  {0} x 9 $7.99", nine);
            }
            if(five > 0){
                Console.WriteLine("  {0} x 5 $4.45", five);
            }
            if(three > 0){
                Console.WriteLine("  {0} x 3 $2.95", three);
            }     
        }
    }
}
