/*
**Developed By : Kyi Saw Win
**Developed Date : 2023-04-19(Wed)
**History : This code is created to participate in C# Coding Challange of Iron Software.
*/

namespace HelloWorld
{
    public class Challenge
    {
 
        // Function to convert mobile numeric
        // keypad sequence into its equivalent
        // string
        static void OldPhonePad(string input)
        {
            
            // Store the mobile keypad mappings
            string[] nums
                = { "",    "&'(",    "ABC",  "DEF", "GHI",
                    "JKL", "MNO", "PQRS", "TUV", "WXYZ" };
    
            char[] str = input.ToCharArray();

            string message = "";
    
            // Traverse the string str
            int i = 0;

            try{
                while (i < str.Length) {

                    // If the current character is space or #,
                    // then continue to the next iteration
                    if (str[i] == ' ' || str[i] == '#') {
                        i++;
                        continue;
                    }

                    if(str[i] == '*' && message.Length > 0 ){
                        message = message.Remove(message.Length-1);
                        i++;
                        continue;
                    }

                    if(str[i] == '0'){
                        message += " ";
                        i++;
                        continue;
                    }
        
                    // Stores the number of continuous clicks
                    int count = 0;
        
                    // Iterate a loop to find the count of same characters
                    while (i + 1 < str.Length
                        && str[i] == str[i + 1]) {
        
                        // 2, 3, 4, 5, 6 and 8 keys will have maximum of 3 letters
                        if (count == 2
                            && ((str[i] >= '2' && str[i] <= '6')
                                || (str[i] == '8')))
                            break;
        
                        // 7 and 9 keys will have maximum of 4 keys
                        else if (count == 3
                                && (str[i] == '7'
                                    || str[i] == '9'))
                            break;
                        count++;
                        i++;
        
                        // Handle the end condition
                        if (i == str.Length)
                            break;
                    }
        
                    // Check if the current pressed key is 7 or 9
                    if (str[i] == '7' || str[i] == '9') {

                        message += (nums[str[i] - 48][count % 4]).ToString();
                    }
        
                    // Else, the key pressed is either 2, 3, 4, 5, 6 or 8
                    else {
                        message += (nums[str[i] - 48][count % 3]).ToString();
                    }
                    i++; 
                }

                Console.WriteLine("My Message to you... " + message);
            }catch(System.IndexOutOfRangeException e){
                Console.WriteLine("Please check your input. Some unauthorized character in old keypad are included.");
            }
        }
    
        // Test Code
        public static void Main(string[] args)
        {
            //Input your message here.
            string myMessage = "7 444 222 55 0633#";
            OldPhonePad(myMessage);
        }
    }
}