package ar222da;
/** 
 * 1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 03
 * 2015-07-09
 * @author AndersRobelius
 *
 */

/** Klassen RectangleEx ärver från Rectangle
 */
public class RectangleEx extends Rectangle
{
	/** Konstruktor som inte tar emot några argument. Basklassens motsvarande konstruktor anropas 
	 * som skapar ett rektangelobjekt med alla privata fält nollställda.
	 * 
	 */
	public RectangleEx()
	{
		super();
	}
	
	/** Konstruktor som överskuggar basklassen konstruktor i och med att den har exakt samma
	 * namn och parametrar, men är annorlunda implementerad. 
	 * @param width förväntas vara int och denna konstruktor anropas enbart då parametrarna är int. Skulle parametrarna vara
	 * strängar anropas i stället konstruktorn nedan.   
	 * I denna konstruktor kontrolleras så att width inte är negativt eller noll. 
	 * Passerar indatat denna kontroll i denna konstruktor anropas denna klass
	 * publika egenskap för sättning av privata fältet width. 
	 * @param height Samma som ovan fast för parametern height.
	 * @throws RectangleException Faller ovan nämnda kontroller av indata kastas 
	 * ett undantag av den av RuntimeException ärvda klassen
	 * RectangleException. Ett meddelande som är anpassat för just för denna kontroll skickas med som parameter.
	 * Programmet som anropar konstruktorn förväntas att vidare ta hand om detta kastade undantag.
	 */
	public RectangleEx(int width, int height) throws RectangleException
	{
		if (width <= 0)
		{
			throw new RectangleException("Bredd måste vara ett positivt heltal.");
		}
		
		if (height <= 0)
		{
			throw new RectangleException("Höjd måste vara ett positivt heltal.");
		}
		
		setWidth(width);
		setHeight(height);
	}
	
	/** Konstruktor som är unik för denna ärvda klass (derived class) i och med att parametrarna är strängar i stället för int.
	 * Om strängarna kan omvandlas till heltal anropas de publika egenskaperna i denna "derived class" för sättning av 
	 * de motsvarande privata fälten. Där sker vidare kontroll huruvida de konverterade heltalen är positiva eller inte.
	 * @param width Sträng som provas om den är möjlig att konvertera till ett heltal. 
	 * @param height Sträng som provas om den är möjligt att konvertera till ett heltal.
	 * @throws RectangleException Om det inte är möjligt att konvertera någon av ovan nämnda strängar till ett heltal
	 * kastas ett NumberFormatException-undantag och fångas upp av respektive catch-block. Där kastas ett RectangleException 
	 * med ett för just detta fel anpassat meddelande vidare till det anropade programmet som förväntas ta hand om det.
	 */
	public RectangleEx(String width, String height) throws RectangleException
	{
		try
		{
			setWidth(Integer.parseInt(width));
		}
		catch (NumberFormatException ex)
		{
			throw new RectangleException("Vänligen ange ett heltal för bredd.");
		}
		try
		{
			setHeight(Integer.parseInt(height));
		}
		catch (NumberFormatException ex)
		{
			throw new RectangleException("Vänligen ange ett heltal för höjd.");
		}
	}
	
	/** Överskuggad publik egenskap för sättning av det privata fältet width (som är ärvt från basklassen).
	 * @width är ett heltal och går kontrollen huruvida det är positivt genom, så anropas basklassens motsvarande
	 * publika egenskap med heltalet som argument, som i sin tur sätter det privata fältet width.
	 */
	public void setWidth(int width) throws RectangleException
	{
		if (width <= 0)
		{
			throw new RectangleException("Bredd måste vara ett positivt heltal.");
		}
		
		super.setWidth(width);
	}
	
	/** Unik publik egenskap för denna "derived class" som tar emot en sträng och med denna konverterade parameter
	 * anropar den publika egenskapen setWidth i denna klass som tar emot heltal. 
	 * 
	 * @param width är en sträng och kontroll sker så att strängen kan omvandlas till heltal.
	 * Fungerar inte detta kastas ett NumberFormatException som fångas upp av catch-blocket.
	 * I catch-blocket fångas detta undantag upp och här kastas i stället ett RectangleException-undantag.
	 * @throws RectangleException med ett anpassat meddelande som meddelar att just konverteringen av strängen 
	 * inte kunde omvandlas till ett heltal, som skickas vidare till det anropade programmet som förväntas ta hand om det.
	 */
	public void setWidth(String width) throws RectangleException
	{
		try
		{
			setWidth(Integer.parseInt(width));
		}
		catch (NumberFormatException ex)
		{
			throw new RectangleException("Vänligen ange ett heltal för bredd.");
		}
		
	}
	
	/** Samma som den första av två förgående publika egenskaper, fast för height
	 * Överskuggad av motsvarande publik egenskap för basklassen.
	 */
	public void setHeight(int height) throws RectangleException
	{
		if (height <= 0)
		{
			throw new RectangleException("Höjd måste vara ett positivt heltal.");
		}
		
		super.setHeight(height);
	}
	
	/** Samma som den andra av två förgående publika egenskaper, fast för height.
	 * Unik för denna "dervied class".
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
			throw new RectangleException("Vänligen ange ett heltal för höjd.");
		}
		
	}

}
