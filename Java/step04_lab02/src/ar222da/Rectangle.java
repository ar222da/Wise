/**1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 02
 * 2015-07-09
 * @author AndersRobelius
 * 
 * */
package ar222da;

/** Klassen Rectangle */
public class Rectangle 
{
	/** Privata f�lt f�r h�jd och bredd */
	private int height;
	private int width;
	
	/** Konstruktor f�r klassen som anv�nds om man redan fr�n b�rjan vet dess h�jd och bredd.
	 * De privata f�lten h�jd och bredd s�tts via parametrarna.
	 * 
	 * @param width
	 * @param height
	 */
	public Rectangle(int width, int height)
	{
		this.height = height;
		this.width = width;
	}
	
	/** Konstruktor f�r klassen som anv�nds om man �nnu inte vet dess h�jd och bredd. */
	public Rectangle()
	{
		this(0,0);
	}
		
	/** R�knar ut area f�r rektangel
	 * @return Produkten av de privata f�lten h�jd och bredd
	 */
	public int computeArea()
	{
		return height * width;
	}
	
	/** Publik egenskap som returnerar privata f�ltet h�jd
	 * 
	 * @return height
	 */
	public int getHeight()
	{
		return height;
	}
	
	/** Publik egenskap som returnerar privata f�ltet bredd
	 * 
	 * @return width
	 */
	public int getWidth()
	{
		return width;
	}
	
	/** Publik egenskap som s�tter privata f�ltet h�jd
	 * 
	 * @param height
	 */
	public void setHeight(int height)
	{
		this.height = height;
	}
	
	/** Publik egenskap som s�tter privata f�ltet bredd
	 * 
	 * @param width
	 */
	public void setWidth(int width)
	{
		this.width = width;
	}
	
	/** Presenterar resultat av areaber�kning
	 * 
	 */
	@Override
	public String toString() {
		String rectangleString = String.format("En rektangel med bredden %d och h�jden %d.\nArean ber�knas nu till: %d", width, height, this.computeArea());
		System.out.print(rectangleString);
		return super.toString();
	}

}
