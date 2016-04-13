/* 1DV432 - Inledande programmering med Java */
/* ar222da - Anders Robelius */
/* Steg 2 uppgift 9 */
/* 2015-06-21 */
package ar222da;

import java.util.Scanner;

public class Program 
{
	public static void main(String[] args)
	{
		Scanner scan = new Scanner(System.in);
		
		// Inmatning av bredd, höjd och koordinater för rektangelns övre vänstra hörn
		System.out.print("Ange bredd: ");
		int width = scan.nextInt();
		
		System.out.print("Ange höjd: ");
		int height = scan.nextInt();
		
		System.out.print("Ange X-koordinat: ");
		int x = scan.nextInt();
		
		System.out.print("Ange Y-koordinat: ");
		int y = scan.nextInt();
		
		// Skapar ett nytt rektangel-objekt med ovan respektive inmatade värden som argument
		Rectangle rectangle = new Rectangle(width, height, x, y);
		
		// Räkna ut varje koordinat för rektangelns och tilldela nyskapade Point-objekt dessa värden
		Point pointUpperLeft = new Point(rectangle.getLocation().getX(), rectangle.getLocation().getY());
		Point pointUnderLeft = new Point(rectangle.getLocation().getX(), rectangle.getLocation().getY() + rectangle.getHeight());
		Point pointUpperRight = new Point(rectangle.getLocation().getX() + width, rectangle.getLocation().getY());
		Point pointUnderRight = new Point(rectangle.getLocation().getX() + width, rectangle.getLocation().getY() + rectangle.getHeight());
		
		// Presentera resultat
		System.out.println("Beräknad area: " + rectangle.computeArea());
		System.out.println("Beräknad omkrets: " + rectangle.computeCircumference());
		System.out.println("Koordinat övre vänster hörn (x, y): " + "(" + pointUpperLeft.getX() + ", " + pointUpperLeft.getY() + ")" );
		System.out.println("Koordinat nedre vänster hörn (x, y): " + "(" + pointUnderLeft.getX() + ", " + pointUnderLeft.getY() + ")" );
		System.out.println("Koordinat övre höger hörn (x, y): " + "(" + pointUpperRight.getX() + ", " + pointUpperRight.getY() + ")" );
		System.out.println("Koordinat nedre höger hörn (x, y): " + "(" + pointUnderRight.getX() + ", " + pointUnderRight.getY() + ")" );

		scan.close();
	}

}
