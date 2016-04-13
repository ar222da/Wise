package ar222da;

// Klassen Rectangle
public class Rectangle 
{
	// Privata egenskaper
	private int width;
	private int height;
	private Point centerPoint = new Point();
	
	// Konstruktor som kan anropas om man �nnu inte vet h�jd, bredd och koordinater
	// Minnesutrymme skapas �t ett objekt, men alla privata f�lt tilldelas v�rdet 0
	public Rectangle()
	{
		this(0, 0, 0, 0);
	}
	
	// Detta �r den konstruktor som anropas av ovanst�ende konstruktor om den anv�nds
	// Denna tar emot argumenten bred, h�jd och koordinater f�r rektangels �ver v�nstra h�rn
	public Rectangle(int width, int height, int x, int y)
	{
		this.width = width;
		this.height = height;
		// Utr�kning av centrumpunkt X
		centerPoint.setX(x + (width / 2));
		// Utr�kning av centrumpunkt Y
		centerPoint.setY(y + (height / 2));
	}
	
	// Publika egenskaper f�r att h�mta och �ndra de privata egenskaperna height och width utanf�r objektet
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
		// Utifr�n centrumpunkten r�kna ut koordinaterna f�r �vre v�nstra h�rn
		int x = centerPoint.getX() - (width / 2);
		int y = centerPoint.getY() - (height / 2);
		Point p = new Point(x, y);
		return p;
	}
	
	public int computeArea()
	{
		// R�kna ut area och returnera
		return height * width;
	}
	
	public int computeCircumference()
	{
		// R�kna ut omkrets och returnera
		return (height * 2) + (width * 2);
	}
	
	// Publika egenskaper f�r privata egenskapen centerPoint
	public Point getCenterPoint()
	{
		return centerPoint;
	}
	
	public void setCenterPoint(Point centerPoint)
	{
		this.centerPoint = centerPoint;
	}

}
