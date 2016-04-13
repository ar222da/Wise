import java.util.Scanner;

public class SecondLargestNumber 
{
	public static void main(String[] args)
	{
		int largestValue = 0;
		int secondLargestValue = 0;
		int input = 0;
		
		Scanner keyboard = new Scanner(System.in);
		
		for (int i = 0; i < 10; i++)
		{
			System.out.print("Ange ett tal: ");
			input = keyboard.nextInt();
			
			if (input > largestValue)
			{
				secondLargestValue = largestValue;
				largestValue = input;
			}
			
			else if (input > secondLargestValue)
			{
				secondLargestValue = input;
			}
			
		}
		
		System.out.print("Det näst största talet är: " + secondLargestValue);
	}

}
