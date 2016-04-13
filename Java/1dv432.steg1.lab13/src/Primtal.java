public class Primtal 
{

	public static void main (String[] args)
	{
		boolean isPrime = true;
		
		System.out.println("Primtalen mellan 1 och 100 är:");
		
		for (int number = 3; number < 100; number++)
		{
			for (int divisor = 2; divisor < number; divisor++)
			{
				if ((divisor != number) && (number % divisor == 0))
				{
					isPrime = false;
					break;
				}
			}
			
			if (isPrime)
			{
				System.out.print(" " + number + " ");
			}
			
			isPrime = true;
		}
		
	}

}
