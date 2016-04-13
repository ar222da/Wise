import java.util.Scanner;

public class Summan_av_tre_siffror 
{
	public static void main(String[] args)
	{
		int number = 0;
		int digit1 = 0;
		int digit2 = 0;
		int digit3 = 0;
		int sum = 0;
		
		Scanner keyboard = new Scanner(System.in);
		System.out.print("Ange ett tresiffrigt heltal: ");
		number = keyboard.nextInt();
		keyboard.nextLine();
		
		digit1 = number / 100;
		number = number % 100;
		digit2 = number / 10;
		digit3 = number = number % 10;
		
		sum = digit1 + digit2 + digit3;
		
		System.out.print("Summan av siffrorna i heltalet är: " + sum);
	
	
	}

}
