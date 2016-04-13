import java.util.Scanner;

public class Heltalspalindrom 
{
	public static void main(String[] args)
	{
		int number = 0;
		int numberBeforeOperations = 0;
		boolean correctInput = false;
		int digit1 = 0;
		int digit2 = 0;
		int digit3 = 0;
		int digit4 = 0;
		int digit5 = 0;
		
		Scanner keyboard = new Scanner(System.in);
		do
		{
			System.out.print("Mata in ett tal med fem siffror: ");
			number = keyboard.nextInt();
			keyboard.nextLine();
			
			if (number >= 10000 && number <= 99999)
			{
				correctInput = true;
			}
			
			else
			{
				System.out.println("Talet du matade in är inte ett heltal med fem siffror.");
				correctInput = false;
			}
			
		} while (correctInput == false);
		
		numberBeforeOperations = number;
		
		digit1 = number / 10000;
		number = number % 10000;
		digit2 = number / 1000;
		number = number % 1000;
		digit3 = number / 100;
		number = number % 100;
		digit4 = number / 10;
		digit5 = number = number % 10;
		
		if (digit1 == digit5 && digit2 == digit4)
		{
			System.out.printf("Talet %d är ett palindrom.", numberBeforeOperations);
		}
		
		else
		{
			System.out.printf("Talet %d är inte ett palindrom.", numberBeforeOperations);
		}

	}

}
