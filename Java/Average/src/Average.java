import java.util.Scanner;

public class Average 
{
	public static void main(String[] args)
	{
		int totalOfPoints = 0;
		int numberOfStudents = 0;
		double average = 0;
		
		Scanner keyboard = new Scanner(System.in);
		System.out.print("Ange total po�ngsumma: ");
		totalOfPoints = keyboard.nextInt();
		System.out.print("Ange antal studenter: ");
		numberOfStudents = keyboard.nextInt();
		
		average = (double) totalOfPoints / numberOfStudents;
		
		System.out.printf("Medelpo�ng: %.1f\n", average);
	}
	

}
