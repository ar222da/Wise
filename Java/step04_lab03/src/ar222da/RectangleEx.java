package ar222da;
/** 
 * 1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 03
 * 2015-07-09
 * @author AndersRobelius
 *
 */

/** Klassen RectangleEx �rver fr�n Rectangle
 */
public class RectangleEx extends Rectangle
{
	/** Konstruktor som inte tar emot n�gra argument. Basklassens motsvarande konstruktor anropas 
	 * som skapar ett rektangelobjekt med alla privata f�lt nollst�llda.
	 * 
	 */
	public RectangleEx()
	{
		super();
	}
	
	/** Konstruktor som �verskuggar basklassen konstruktor i och med att den har exakt samma
	 * namn och parametrar, men �r annorlunda implementerad. 
	 * @param width f�rv�ntas vara int och denna konstruktor anropas enbart d� parametrarna �r int. Skulle parametrarna vara
	 * str�ngar anropas i st�llet konstruktorn nedan.   
	 * I denna konstruktor kontrolleras s� att width inte �r negativt eller noll. 
	 * Passerar indatat denna kontroll i denna konstruktor anropas denna klass
	 * publika egenskap f�r s�ttning av privata f�ltet width. 
	 * @param height Samma som ovan fast f�r parametern height.
	 * @throws RectangleException Faller ovan n�mnda kontroller av indata kastas 
	 * ett undantag av den av RuntimeException �rvda klassen
	 * RectangleException. Ett meddelande som �r anpassat f�r just f�r denna kontroll skickas med som parameter.
	 * Programmet som anropar konstruktorn f�rv�ntas att vidare ta hand om detta kastade undantag.
	 */
	public RectangleEx(int width, int height) throws RectangleException
	{
		if (width <= 0)
		{
			throw new RectangleException("Bredd m�ste vara ett positivt heltal.");
		}
		
		if (height <= 0)
		{
			throw new RectangleException("H�jd m�ste vara ett positivt heltal.");
		}
		
		setWidth(width);
		setHeight(height);
	}
	
	/** Konstruktor som �r unik f�r denna �rvda klass (derived class) i och med att parametrarna �r str�ngar i st�llet f�r int.
	 * Om str�ngarna kan omvandlas till heltal anropas de publika egenskaperna i denna "derived class" f�r s�ttning av 
	 * de motsvarande privata f�lten. D�r sker vidare kontroll huruvida de konverterade heltalen �r positiva eller inte.
	 * @param width Str�ng som provas om den �r m�jlig att konvertera till ett heltal. 
	 * @param height Str�ng som provas om den �r m�jligt att konvertera till ett heltal.
	 * @throws RectangleException Om det inte �r m�jligt att konvertera n�gon av ovan n�mnda str�ngar till ett heltal
	 * kastas ett NumberFormatException-undantag och f�ngas upp av respektive catch-block. D�r kastas ett RectangleException 
	 * med ett f�r just detta fel anpassat meddelande vidare till det anropade programmet som f�rv�ntas ta hand om det.
	 */
	public RectangleEx(String width, String height) throws RectangleException
	{
		try
		{
			setWidth(Integer.parseInt(width));
		}
		catch (NumberFormatException ex)
		{
			throw new RectangleException("V�nligen ange ett heltal f�r bredd.");
		}
		try
		{
			setHeight(Integer.parseInt(height));
		}
		catch (NumberFormatException ex)
		{
			throw new RectangleException("V�nligen ange ett heltal f�r h�jd.");
		}
	}
	
	/** �verskuggad publik egenskap f�r s�ttning av det privata f�ltet width (som �r �rvt fr�n basklassen).
	 * @width �r ett heltal och g�r kontrollen huruvida det �r positivt genom, s� anropas basklassens motsvarande
	 * publika egenskap med heltalet som argument, som i sin tur s�tter det privata f�ltet width.
	 */
	public void setWidth(int width) throws RectangleException
	{
		if (width <= 0)
		{
			throw new RectangleException("Bredd m�ste vara ett positivt heltal.");
		}
		
		super.setWidth(width);
	}
	
	/** Unik publik egenskap f�r denna "derived class" som tar emot en str�ng och med denna konverterade parameter
	 * anropar den publika egenskapen setWidth i denna klass som tar emot heltal. 
	 * 
	 * @param width �r en str�ng och kontroll sker s� att str�ngen kan omvandlas till heltal.
	 * Fungerar inte detta kastas ett NumberFormatException som f�ngas upp av catch-blocket.
	 * I catch-blocket f�ngas detta undantag upp och h�r kastas i st�llet ett RectangleException-undantag.
	 * @throws RectangleException med ett anpassat meddelande som meddelar att just konverteringen av str�ngen 
	 * inte kunde omvandlas till ett heltal, som skickas vidare till det anropade programmet som f�rv�ntas ta hand om det.
	 */
	public void setWidth(String width) throws RectangleException
	{
		try
		{
			setWidth(Integer.parseInt(width));
		}
		catch (NumberFormatException ex)
		{
			throw new RectangleException("V�nligen ange ett heltal f�r bredd.");
		}
		
	}
	
	/** Samma som den f�rsta av tv� f�rg�ende publika egenskaper, fast f�r height
	 * �verskuggad av motsvarande publik egenskap f�r basklassen.
	 */
	public void setHeight(int height) throws RectangleException
	{
		if (height <= 0)
		{
			throw new RectangleException("H�jd m�ste vara ett positivt heltal.");
		}
		
		super.setHeight(height);
	}
	
	/** Samma som den andra av tv� f�rg�ende publika egenskaper, fast f�r height.
	 * Unik f�r denna "dervied class".
	 * @param height se ovan
	 * @throws RectangleException se ovan
	 */
	public void setHeight(String height) throws RectangleException
	{
		try
		{
			setHeight(Integer.parseInt(height));
		}
		catch (NumberFormatException ex)
		{
			throw new RectangleException("V�nligen ange ett heltal f�r h�jd.");
		}
		
	}

}
