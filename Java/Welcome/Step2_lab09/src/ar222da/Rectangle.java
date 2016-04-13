package ar222da;

// Klassen Rectangle
public class Rectangle 
{
	// Privata egenskaper
	private int width;
	private int height;
	private Point centerPoint = new Point();
	
	// Konstruktor som kan anropas om man ännu inte vet höjd, bredd och koordinater
	// Minnesutrymme skapas åt ett objekt, men alla privata fält tilldelas värdet 0
	public Rectangle()
	{
		this(0, 0, 0, 0);
	}
	
	// Detta är den konstruktor som anropas av ovanstående konstruktor om den används
	// Denna tar emot argumenten bred, höjd och koordinater för rektangels över vänstra hörn
	public Rectangle(int width, int height, int x, int y)
	{
		this.width = width;
		this.height = height;
		// Uträkning av centrumpunkt X
		centerPoint.setX(x + (width / 2));
		// Uträkning av centrumpunkt Y
		centerPoint.setY(y + (height / 2));
	}
	
	// Publika egenskaper för att hämta och ändra de privata egenskaperna height och width utanför objektet
	public int getHeight()
	{
		return height;
	}
	
	public void setHeight(int value)
	{
		this.height = value;
	}
	
	public int getWidth()
	{
		return width;
	}
	
	public void setWidth(int value)
	{
		this.width = value;
	}
	
	public Point getLocation()
	{
		// Utifrån centrumpunkten räkna ut koordinaterna för övre vänstra hörn
		int x = centerPoint.getX() - (width / 2);
		int y = centerPoint.getY() - (height / 2);
		Point p = new Point(x, y);
		return p;
	}
	
	public int computeArea()
	{
		// Räkna ut area och returnera
		return height * width;
	}
	
	public int computeCircumference()
	{
		// Räkna ut omkrets och returnera
		return (height * 2) + (width * 2);
	}
	
	// Publika egenskaper för privata egenskapen centerPoint
	public Point getCenterPoint()
	{
		return centerPoint;
	}
	
	public void setCenterPoint(Point centerPoint)
	{
		this.centerPoint = centerPoint;
	}

}
