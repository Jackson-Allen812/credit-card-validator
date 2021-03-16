using System;

namespace CreditCardValidator {
    class Program {
        static void Main(string[] args) {

            bool is_invalid_number = true;

            //Input for 16-digit number
            Console.Write("Enter a 16-digit credit card number: ");
            char[] num_string = Console.ReadLine().ToCharArray();


            // Validate 16-digit number
            while(is_invalid_number) {

                if(num_string.Length != 16) { 
                    Console.Write("Invalid Number, please enter a 16-digit number: "); 
                    num_string = Console.ReadLine().ToCharArray();
                } else {
                    is_invalid_number = false;
                }

            }
            
            // Array to hold the new ints
            int[] num_array = new int[16];
            
            // Convert char array into int array
            for(int i = 0; i < num_string.Length; i++) { num_array[i] = (int)Char.GetNumericValue(num_string[i]); }

            // Loop for number validation
            for(int i = 0; i < num_array.Length - 1; i++) {
            
                // Check if this is every second digit
                if(i % 2 != 0) {    
                
                    num_array[i] *= 2;

                    // If the digit is greater than 9, add it's two digits together
                    if(num_array[i] > 9) {

                        int container, sum = 0;

                        while(num_array[i] > 0) {
                        
                            container = num_array[i] % 10;
                            sum = sum + container;
                            num_array[i] = num_array[i] / 10;

                        }
                        num_array[i] = sum;
                    }
                }

            }

            int sum_of_num = 0;


            // Add all digits together
            for(int i = 0; i < num_array.Length - 1; i++) { sum_of_num += num_array[i]; }

            // Add the check digit, if it is a multiple of 10, it is a valid card number
            if((sum_of_num + num_array[15]) % 10 == 0) {
                Console.WriteLine("Valid Credit Card Number.");
            } else {
                Console.WriteLine("Invalid Credit Card Number.");
            }

        }
    }
}
