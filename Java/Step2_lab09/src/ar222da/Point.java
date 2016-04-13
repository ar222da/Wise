package ar222da;

// Klassen Point
public class Point 
{
	// Privata egenskaper X och Y
	private int x;
	private int y;
	
	// Konstruktor tilldelar de privata värdena X och Y genom argument
	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
		
	}
	
	// Instansierar ett Point-objekt med noll som X och Y-värden
	public Point()
	{
		this(0,0);
	}
	
	// Publika egenskaper för att hämta och ändra de privata egenskaperna
	public int getX()
	{
		return x;
	}
	
	public int getY()
	{
		return y;
	}
	
	public void setX(int x)
	{
		this.x = x;
	}
	
	public void setY(int y)
	{
		this.y = y;
	}
	
	
	

}
