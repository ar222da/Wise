/**1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 02
 * 2015-07-09
 * @author AndersRobelius
 * 
 * */

package ar222da;

import java.util.Scanner;

/** Programfl�desklassen
 * 
 * @author AndersRobelius
 *
 */
public class Program 
{
	public static void main(String[] args)
	{
		Scanner scan = new Scanner(System.in);
		
		/** En l�da initieras genom konstruktor som tar emot argument
		 * 
		 */
		Box myBox = new Box(5, 10, 15);
		
		System.out.println("Jag har: ");
		System.out.println(myBox.toString());

		/** Anv�nds f�r att bekr�fta fungerande omvandling fr�n str�ng till heltal. Se nedan.
		 * 
		 */
		boolean widthInputValidFormat = false;
		boolean heightInputValidFormat = false;
		boolean depthInputValidFormat = false;
		
		/** Initierar anv�ndarens l�da med "tom" konstruktor, endast objekt skapas med alla privata f�lt nollst�llda.
		 */
		Box yourBox = new Box();
		
		/** Anv�ndares inmatning av bredd, h�jd och djup med felhantering.
		 * Tre stycken do-while-loopar varav inte bryts f�rr�n respektive konvertering av str�ng till heltal fungerar.
		 * NumberFormatException kastas om konverteringen inte fungerar.
		 * En do-while-loop f�r tilldelning av varje privat i f�lt box-objektet (width, height och depth) via
		 * motsvarande publik egenskap (setWidth, setHeight och setDepth).
		 */
		
		/** (1) Inmatning f�r bredd
		 * 
		 */
		System.out.print("Ange bredd p� din l�da: ");
		
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
				System.out.println("Ett fel har intr�ffat!");
				System.out.print("V�nligen ange ett TAL f�r l�dans bredd: ");
			}
			
		} while (widthInputValidFormat == false);
			

		/** (2) Inmatning f�r h�jd
		 * 
		 */
		System.out.print("Ange h�jd p� din l�da: ");

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
				System.out.println("Ett fel har intr�ffat!");
				System.out.print("V�nligen ange ett TAL f�r l�dans h�jd: ");
			}
			
		} while (heightInputValidFormat == false);
			

		/** (3) Inmatning f�r djup
		 * 
		 */
		System.out.print("Ange djup p� din l�da: ");

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
				System.out.println("Ett fel har intr�ffat!");
				System.out.print("V�nligen ange ett TAL f�r l�dans djup: ");
			}
			
		} while (depthInputValidFormat == false);
		
		
		/** Presentation av anv�ndarens l�da med toString() och anrop av publika metoderna f�r volym- och areaber�kning 
		 * 
		 */
		System.out.println("Du har: ");
		System.out.println(yourBox.toString());
		System.out.format("L�dans volym �r %d volymenheter.\n", yourBox.computeVolume());
		System.out.format("Sammanlagd area av l�dans sidor �r %d areaenheter.\n", yourBox.computeArea());
		
		
		/** J�mf�relse mellan det f�rsta l�dobjektet och anv�ndarens l�dobjekt
		 */
		if (myBox.equals(yourBox))
		{
			System.out.print("Min l�da rymmer lika mycket som din!");
		}
		else
		{
			System.out.print("V�ra l�dor �r inte lika stora!");
		}
		
		scan.close();
		
	}

}
