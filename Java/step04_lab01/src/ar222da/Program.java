/**1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 01
 * 2015-07-09
 * @author AndersRobelius
 * 
 * */
package ar222da;

import java.util.Scanner;


public class Program 
{
	public static void main(String[] args)
	{
		Scanner scan = new Scanner(System.in);
		
		/** Dessa anv�nds f�r att veta om inmatad str�ng kan omvandlas till heltal eller inte
		 * 
		 */
		boolean widthInputValidFormat = false;
		boolean heightInputValidFormat = false;
		
		/** Initierar ett objekt av klassen Rectangle
		 * 
		 */
		Rectangle rectangle = new Rectangle();
		
		System.out.print ("Ange rektangelns bredd: ");
		
		/** F�ljande loop k�rs s� l�nge inmatad data f�r rektangelns bredd inte �r korrekt.
		 * Matas en str�ng in som inte kan omvandlas till ett heltal kastas ett undantag
		 * och catch-blocket k�rs. D�r presenteras felmeddelande. Kan str�ngen omvandlas
		 * till ett heltal bryts loopen i och med att hela try blocket "g�r igenom"
		 * och widthInputValidFormat s�tts till true.
		 */
		do
		{
			String width = scan.next();
			
			try
			{
				rectangle.setWidth(Integer.parseInt(width));
				widthInputValidFormat = true;
			}
			
			catch (NumberFormatException e)
			{
				System.out.println("Ett fel har intr�ffat!");
				System.out.print("V�nligen ange ett tal f�r rektangelns bredd: ");
			}
		
		} while (widthInputValidFormat == false);
		
		System.out.print("Ange rektangelns h�jd: ");
		
		/** Samma som g�ller f�r ovan loop g�ller h�r fast f�r rektangelns h�jd
		 * 
		 */
		do
		{
			String height = scan.next();
			
			try
			{
				rectangle.setHeight(Integer.parseInt(height));
				heightInputValidFormat = true;
			}
			
			catch (NumberFormatException e)
			{
				System.out.println("Ett fel har intr�ffat!");
				System.out.print("V�nligen ange ett tal f�r rektangelns h�jd: ");
			}
		
		} while (heightInputValidFormat == false);
		
		/** Presentera area-ber�kningens resultat
		 * 
		 */
		System.out.print(rectangle.toString());
		scan.close();
	}

}
