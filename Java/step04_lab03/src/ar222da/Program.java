package ar222da;
/** 
 * 1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 03
 * 2015-07-09
 * @author AndersRobelius
 *
 */
import java.util.Scanner;

/** Programklassen där själva programflödet är implementerat.
 */
public class Program 
{
	
	public static void main(String[] args)
	{
		Scanner scan = new Scanner(System.in);

		/** Ett RectangleEx-objekt skapas och dess privata fält blir nollställda.
		 * 
		 */
		RectangleEx rectangle = new RectangleEx();

		/** Denna loop bryts inte förrän de privata fälten för RectangleEx har blivit satta, det vill säga inte
		 * är nollställda vilka de blir i och med den konstruktorn som användes ovan.
		 * I och med try-catch-blocken kan inte heller dessa sättas om undantag kastas av någon av de
		 * i RectangleEx-klassen implementerade kontrollerna.
		 */
		do
		{
			try
			{
				/** Har det privata fältet width redan satts och därmed passerat kotroll behöver inte detta matas in på nytt.
				 * 
				 */
				if (rectangle.getWidth() == 0)
				{
					System.out.print("Ange bredd på rektangel: ");
					String width = scan.nextLine();
					rectangle.setWidth(width);
				}
				
				/** Samma som ovan fast för det privata fältet height.
				 * 
				 */
				if (rectangle.getHeight() == 0)
				{
					System.out.print("Ange höjd på rektangel: ");
					String height = scan.nextLine();
					rectangle.setHeight(height);
				}
			}
			
			/** Har ett RectangleException-undantag kastats i och med försöken att sätta de privata fälten med
			 * ovan inmatad data som argument tas dessa hand om i detta catch-block. Ett felmeddelande som har satts
			 * i RectangleEx-klassen presenteras och loopen fortsätter en omgång till.
			 */
			catch (RectangleException ex)
			{
				System.out.println(ex.getMessage());
			}
			/** Om undantaget som har kastats inte har identifierats som ett RectangleException och därmed inte
			 * fångats upp av ovan catch-block, utan är ett mer allmänt undantag fångas det upp av följande catch-block.
			 * Loopen fortsätter en omgång till.
			 */
			catch (Exception e)
			{
				System.out.println("Ett oväntat fel inträffade.");
			}
			
			/** Har de privata fälten för RectangleEx-objektet satts och därmed passerat validering behövs ingen mer
			 * indata från användare och denna denna loop slutar.
			 */
			
		} while (rectangle.getWidth() == 0 || rectangle.getHeight() == 0);
		
		/** Presentera areaberäkningen av RectangleEx-objektet.
		 * 
		 */
		System.out.println(rectangle.toString());
		
		scan.close();
	}

}
