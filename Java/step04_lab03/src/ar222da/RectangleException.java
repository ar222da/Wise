package ar222da;
/** 
 * 1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 03
 * 2015-07-09
 * @author AndersRobelius
 *
 */

/** Klassen RectangleException ärver från RuntimeException
 */
@SuppressWarnings("serial")
public class RectangleException extends RuntimeException
{
	/** Konstruktor som sätter ett allmänt felmeddelande, om ett RectangleException-objekt skulle skapas utan
	 * ett meddelande.
	 * 
	 */
	public RectangleException()
	{
		super("Ett fel inträffade vid beräkning av rektangels area.");
	}
	
	/** Konstruktor som tar emot ett anpassat meddelande då ett RectangleException-objekt skapas.
	 * 
	 * @param message är det anpassade meddelandet som en sträng.
	 */
	public RectangleException(String message)
	{
		super(message);
	}

}
