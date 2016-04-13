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
	/** Privata fält för höjd och bredd */
	private int height;
	private int width;
	
	/** Konstruktor för klassen som används om man redan från början vet dess höjd och bredd.
	 * De privata fälten höjd och bredd sätts via parametrarna.
	 * 
	 * @param width
	 * @param height
	 */
	public Rectangle(int width, int height)
	{
		this.height = height;
		this.width = width;
	}
	
	/** Konstruktor för klassen som används om man ännu inte vet dess höjd och bredd. */
	public Rectangle()
	{
		this(0,0);
	}
		
	/** Räknar ut area för rektangel
	 * @return Produkten av de privata fälten höjd och bredd
	 */
	public int computeArea()
	{
		return height * width;
	}
	
	/** Publik egenskap som returnerar privata fältet höjd
	 * 
	 * @return height
	 */
	public int getHeight()
	{
		return height;
	}
	
	/** Publik egenskap som returnerar privata fältet bredd
	 * 
	 * @return width
	 */
	public int getWidth()
	{
		return width;
	}
	
	/** Publik egenskap som sätter privata fältet höjd
	 * 
	 * @param height
	 */
	public void setHeight(int height)
	{
		this.height = height;
	}
	
	/** Publik egenskap som sätter privata fältet bredd
	 * 
	 * @param width
	 */
	public void setWidth(int width)
	{
		this.width = width;
	}
	
	/** Presenterar resultat av areaberäkning
	 * 
	 */
	@Override
	public String toString() {
		String rectangleString = String.format("En rektangel med bredden %d och höjden %d.\nArean beräknas nu till: %d", width, height, this.computeArea());
		System.out.print(rectangleString);
		return super.toString();
	}

}
