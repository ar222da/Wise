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
	
	// Konstruktorn som genererar ett slumptal mellan 0 och 100 och tilldelar privata egenskapen secretNumber detta v�rde
	public SecretNumber()
	{
		secretNumber = (int) (Math.random() * 101);
	}
	
	// Kontrollfunktionen som returnerar true eller false beroende p� hur v�rdet ligger till i f�rh�llande till secretNumber
	public boolean makeGuess(int number)
	{
		// Anropas den h�r funktionen har man gjort en gissning och d�rmed �kat antalet gjorda gissningar med 1
		guesses += 1;
		
		// Om gissningen �r fel
		if (number != secretNumber)
		{
			// Om gissningen �r f�r l�g
			if (number < secretNumber)
			{
				System.out.print(number + " �r f�r l�gt. ");
			}
			// eller om gissningen �r f�r h�g
			else if (number > secretNumber)
			{
				System.out.print(number + " �r f�r h�gt. ");
			}
			// Skriv ut hur m�nga gissningar man har kvar (max antal gissningar minus antal gissningar gjoda
			System.out.println("Du har " + (MAX_NUMBER_OF_GUESSES - guesses) + " gissningar kvar." );
			// Returnera false eftersom gissningen var fel
			return false;
		}
		// Om gissningen �r r�tt returnera true
		else
		{
			System.out.println("R�TT GISSAT. Du klarade det p� " + guesses + " gissningar.");
			return true;
		}
	}
	
	// Publik egenskap f�r att h�mta ut antal gissningar gjorda
	public int getGuesses()
	{
		return guesses;
	}

}


