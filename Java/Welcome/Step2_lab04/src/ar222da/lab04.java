/* 1DV432 - Inledande programmering med Java */
/* ar222da - Anders Robelius */
/* Steg 2 uppgift 9 */
/* 2015-06-21 */

package ar222da;

import java.util.Scanner;

public class lab04 
{
	public static void main(String[] args)
	{
		SecretNumber secretNumber = new SecretNumber();
		Scanner in = new Scanner(System.in);
		
		System.out.println("Gissa ett tal mellan 0-100: ");
		
		for (int i = 0; i < SecretNumber.MAX_NUMBER_OF_GUESSES; ++i)
		{
			if (secretNumber.makeGuess(in.nextInt()))
			{
				break;
			}
		}
	 
		in.close();
	 }
}
	
class SecretNumber
{
	// Publik namngiven konstant
	public static int MAX_NUMBER_OF_GUESSES = 7;
	
	// Privata egenskaper: hemliga numret och antal gissningar gjorda
	private int secretNumber;
	private int guesses = 0;
	
	// Konstruktorn som genererar ett slumptal mellan 0 och 100 och tilldelar privata egenskapen secretNumber detta värde
	public SecretNumber()
	{
		secretNumber = (int) (Math.random() * 101);
	}
	
	// Kontrollfunktionen som returnerar true eller false beroende på hur värdet ligger till i förhållande till secretNumber
	public boolean makeGuess(int number)
	{
		// Anropas den här funktionen har man gjort en gissning och därmed ökat antalet gjorda gissningar med 1
		guesses += 1;
		
		// Om gissningen är fel
		if (number != secretNumber)
		{
			// Om gissningen är för låg
			if (number < secretNumber)
			{
				System.out.print(number + " är för lågt. ");
			}
			// eller om gissningen är för hög
			else if (number > secretNumber)
			{
				System.out.print(number + " är för högt. ");
			}
			// Skriv ut hur många gissningar man har kvar (max antal gissningar minus antal gissningar gjoda
			System.out.println("Du har " + (MAX_NUMBER_OF_GUESSES - guesses) + " gissningar kvar." );
			// Returnera false eftersom gissningen var fel
			return false;
		}
		// Om gissningen är rätt returnera true
		else
		{
			System.out.println("RÄTT GISSAT. Du klarade det på " + guesses + " gissningar.");
			return true;
		}
	}
	
	// Publik egenskap för att hämta ut antal gissningar gjorda
	public int getGuesses()
	{
		return guesses;
	}

}


