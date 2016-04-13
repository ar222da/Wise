/**1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 02
 * 2015-07-09
 * @author AndersRobelius
 * 
 * */

package ar222da;

import java.util.Scanner;

/** Programflödesklassen
 * 
 * @author AndersRobelius
 *
 */
public class Program 
{
	public static void main(String[] args)
	{
		Scanner scan = new Scanner(System.in);
		
		/** En låda initieras genom konstruktor som tar emot argument
		 * 
		 */
		Box myBox = new Box(5, 10, 15);
		
		System.out.println("Jag har: ");
		System.out.println(myBox.toString());

		/** Används för att bekräfta fungerande omvandling från sträng till heltal. Se nedan.
		 * 
		 */
		boolean widthInputValidFormat = false;
		boolean heightInputValidFormat = false;
		boolean depthInputValidFormat = false;
		
		/** Initierar användarens låda med "tom" konstruktor, endast objekt skapas med alla privata fält nollställda.
		 */
		Box yourBox = new Box();
		
		/** Användares inmatning av bredd, höjd och djup med felhantering.
		 * Tre stycken do-while-loopar varav inte bryts förrän respektive konvertering av sträng till heltal fungerar.
		 * NumberFormatException kastas om konverteringen inte fungerar.
		 * En do-while-loop för tilldelning av varje privat i fält box-objektet (width, height och depth) via
		 * motsvarande publik egenskap (setWidth, setHeight och setDepth).
		 */
		
		/** (1) Inmatning för bredd
		 * 
		 */
		System.out.print("Ange bredd på din låda: ");
		
		do
		{
			String width = scan.nextLine();
			
			try
			{
				yourBox.setWidth(Integer.parseInt(width));
				widthInputValidFormat = true;
			}
			catch (NumberFormatException e)
			{
				System.out.println("Ett fel har inträffat!");
				System.out.print("Vänligen ange ett TAL för lådans bredd: ");
			}
			
		} while (widthInputValidFormat == false);
			

		/** (2) Inmatning för höjd
		 * 
		 */
		System.out.print("Ange höjd på din låda: ");

		do
		{
			String height = scan.nextLine();
			
			try
			{
				yourBox.setHeight(Integer.parseInt(height));
				heightInputValidFormat = true;
			}
			catch (NumberFormatException e)
			{
				System.out.println("Ett fel har inträffat!");
				System.out.print("Vänligen ange ett TAL för lådans höjd: ");
			}
			
		} while (heightInputValidFormat == false);
			

		/** (3) Inmatning för djup
		 * 
		 */
		System.out.print("Ange djup på din låda: ");

		do
		{
			String depth = scan.nextLine();
			
			try
			{
				yourBox.setDepth(Integer.parseInt(depth));
				depthInputValidFormat = true;
			}
			catch (NumberFormatException e)
			{
				System.out.println("Ett fel har inträffat!");
				System.out.print("Vänligen ange ett TAL för lådans djup: ");
			}
			
		} while (depthInputValidFormat == false);
		
		
		/** Presentation av användarens låda med toString() och anrop av publika metoderna för volym- och areaberäkning 
		 * 
		 */
		System.out.println("Du har: ");
		System.out.println(yourBox.toString());
		System.out.format("Lådans volym är %d volymenheter.\n", yourBox.computeVolume());
		System.out.format("Sammanlagd area av lådans sidor är %d areaenheter.\n", yourBox.computeArea());
		
		
		/** Jämförelse mellan det första lådobjektet och användarens lådobjekt
		 */
		if (myBox.equals(yourBox))
		{
			System.out.print("Min låda rymmer lika mycket som din!");
		}
		else
		{
			System.out.print("Våra lådor är inte lika stora!");
		}
		
		scan.close();
		
	}

}
