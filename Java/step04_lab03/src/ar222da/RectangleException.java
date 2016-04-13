package ar222da;
/** 
 * 1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 03
 * 2015-07-09
 * @author AndersRobelius
 *
 */

/** Klassen RectangleException �rver fr�n RuntimeException
 */
@SuppressWarnings("serial")
public class RectangleException extends RuntimeException
{
	/** Konstruktor som s�tter ett allm�nt felmeddelande, om ett RectangleException-objekt skulle skapas utan
	 * ett meddelande.
	 * 
	 */
	public RectangleException()
	{
		super("Ett fel intr�ffade vid ber�kning av rektangels area.");
	}
	
	/** Konstruktor som tar emot ett anpassat meddelande d� ett RectangleException-objekt skapas.
	 * 
	 * @param message �r det anpassade meddelandet som en str�ng.
	 */
	public RectangleException(String message)
	{
		super(message);
	}

}
