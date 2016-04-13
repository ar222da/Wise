package ar222da;
/** 
 * 1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 03
 * 2015-07-09
 * @author AndersRobelius
 *
 */
import java.util.Scanner;

/** Programklassen d�r sj�lva programfl�det �r implementerat.
 */
public class Program 
{
	
	public static void main(String[] args)
	{
		Scanner scan = new Scanner(System.in);

		/** Ett RectangleEx-objekt skapas och dess privata f�lt blir nollst�llda.
		 * 
		 */
		RectangleEx rectangle = new RectangleEx();

		/** Denna loop bryts inte f�rr�n de privata f�lten f�r RectangleEx har blivit satta, det vill s�ga inte
		 * �r nollst�llda vilka de blir i och med den konstruktorn som anv�ndes ovan.
		 * I och med try-catch-blocken kan inte heller dessa s�ttas om undantag kastas av n�gon av de
		 * i RectangleEx-klassen implementerade kontrollerna.
		 */
		do
		{
			try
			{
				/** Har det privata f�ltet width redan satts och d�rmed passerat kotroll beh�ver inte detta matas in p� nytt.
				 * 
				 */
				if (rectangle.getWidth() == 0)
				{
					System.out.print("Ange bredd p� rektangel: ");
					String width = scan.nextLine();
					rectangle.setWidth(width);
				}
				
				/** Samma som ovan fast f�r det privata f�ltet height.
				 * 
				 */
				if (rectangle.getHeight() == 0)
				{
					System.out.print("Ange h�jd p� rektangel: ");
					String height = scan.nextLine();
					rectangle.setHeight(height);
				}
			}
			
			/** Har ett RectangleException-undantag kastats i och med f�rs�ken att s�tta de privata f�lten med
			 * ovan inmatad data som argument tas dessa hand om i detta catch-block. Ett felmeddelande som har satts
			 * i RectangleEx-klassen presenteras och loopen forts�tter en omg�ng till.
			 */
			catch (RectangleException ex)
			{
				System.out.println(ex.getMessage());
			}
			/** Om undantaget som har kastats inte har identifierats som ett RectangleException och d�rmed inte
			 * f�ngats upp av ovan catch-block, utan �r ett mer allm�nt undantag f�ngas det upp av f�ljande catch-block.
			 * Loopen forts�tter en omg�ng till.
			 */
			catch (Exception e)
			{
				System.out.println("Ett ov�ntat fel intr�ffade.");
			}
			
			/** Har de privata f�lten f�r RectangleEx-objektet satts och d�rmed passerat validering beh�vs ingen mer
			 * indata fr�n anv�ndare och denna denna loop slutar.
			 */
			
		} while (rectangle.getWidth() == 0 || rectangle.getHeight() == 0);
		
		/** Presentera areaber�kningen av RectangleEx-objektet.
		 * 
		 */
		System.out.println(rectangle.toString());
		
		scan.close();
	}

}
