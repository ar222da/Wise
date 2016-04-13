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
		
		/** Dessa används för att veta om inmatad sträng kan omvandlas till heltal eller inte
		 * 
		 */
		boolean widthInputValidFormat = false;
		boolean heightInputValidFormat = false;
		
		/** Initierar ett objekt av klassen Rectangle
		 * 
		 */
		Rectangle rectangle = new Rectangle();
		
		System.out.print ("Ange rektangelns bredd: ");
		
		/** Följande loop körs så länge inmatad data för rektangelns bredd inte är korrekt.
		 * Matas en sträng in som inte kan omvandlas till ett heltal kastas ett undantag
		 * och catch-blocket körs. Där presenteras felmeddelande. Kan strängen omvandlas
		 * till ett heltal bryts loopen i och med att hela try blocket "går igenom"
		 * och widthInputValidFormat sätts till true.
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
				System.out.println("Ett fel har inträffat!");
				System.out.print("Vänligen ange ett tal för rektangelns bredd: ");
			}
		
		} while (widthInputValidFormat == false);
		
		System.out.print("Ange rektangelns höjd: ");
		
		/** Samma som gäller för ovan loop gäller här fast för rektangelns höjd
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
				System.out.println("Ett fel har inträffat!");
				System.out.print("Vänligen ange ett tal för rektangelns höjd: ");
			}
		
		} while (heightInputValidFormat == false);
		
		/** Presentera area-beräkningens resultat
		 * 
		 */
		System.out.print(rectangle.toString());
		scan.close();
	}

}
