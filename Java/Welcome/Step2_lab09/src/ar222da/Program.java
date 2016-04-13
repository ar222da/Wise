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
		
		// Inmatning av bredd, h�jd och koordinater f�r rektangelns �vre v�nstra h�rn
		System.out.print("Ange bredd: ");
		int width = scan.nextInt();
		
		System.out.print("Ange h�jd: ");
		int height = scan.nextInt();
		
		System.out.print("Ange X-koordinat: ");
		int x = scan.nextInt();
		
		System.out.print("Ange Y-koordinat: ");
		int y = scan.nextInt();
		
		// Skapar ett nytt rektangel-objekt med ovan respektive inmatade v�rden som argument
		Rectangle rectangle = new Rectangle(width, height, x, y);
		
		// R�kna ut varje koordinat f�r rektangelns och tilldela nyskapade Point-objekt dessa v�rden
		Point pointUpperLeft = new Point(rectangle.getLocation().getX(), rectangle.getLocation().getY());
		Point pointUnderLeft = new Point(rectangle.getLocation().getX(), rectangle.getLocation().getY() + rectangle.getHeight());
		Point pointUpperRight = new Point(rectangle.getLocation().getX() + width, rectangle.getLocation().getY());
		Point pointUnderRight = new Point(rectangle.getLocation().getX() + width, rectangle.getLocation().getY() + rectangle.getHeight());
		
		// Presentera resultat
		System.out.println("Ber�knad area: " + rectangle.computeArea());
		System.out.println("Ber�knad omkrets: " + rectangle.computeCircumference());
		System.out.println("Koordinat �vre v�nster h�rn (x, y): " + "(" + pointUpperLeft.getX() + ", " + pointUpperLeft.getY() + ")" );
		System.out.println("Koordinat nedre v�nster h�rn (x, y): " + "(" + pointUnderLeft.getX() + ", " + pointUnderLeft.getY() + ")" );
		System.out.println("Koordinat �vre h�ger h�rn (x, y): " + "(" + pointUpperRight.getX() + ", " + pointUpperRight.getY() + ")" );
		System.out.println("Koordinat nedre h�ger h�rn (x, y): " + "(" + pointUnderRight.getX() + ", " + pointUnderRight.getY() + ")" );

		scan.close();
	}

}
