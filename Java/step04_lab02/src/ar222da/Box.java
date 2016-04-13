/**1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 02
 * 2015-07-09
 * @author AndersRobelius
 * 
 * */
package ar222da;

/** Klassen Box som ärver från basklassen Rectangle
 *  
 */
public class Box extends Rectangle
{
	/** Privat variabel som är unik för just Box-klassen
	 * width och height ärvs från basklassen
	 */
	private int depth;
	
	/** Konstruktor som inte tar emot några agrument. Alla privata fält nollställs när objektet skapas.
	 * width och height nollställs genom anrop av basklassens konstruktor.
	 * Unika fältet depth för Box tilldelas noll direkt.
	 */
	public Box()
	{
		super(0,0);
		this.depth = 0;
	}
	
	/** Konstruktor som tar emot argument. 
	 * width och height sätts genom anrop av basklassens konstruktor.
	 * @param width sätts genom anrop av basklassens konstruktor.
	 * @param height sätts genom anrop av basklassens konstruktor.
	 * @param depth är unik för Box och sätts direkt.
	 */
	public Box(int width, int height, int depth)
	{
		super(width, height);
		this.depth = depth;
	}
	
	/** Volymberäkning
	 * 
	 * @return produkten av bredd, höjd och djup
	 */
	public int computeVolume()
	{
		return getWidth() * getHeight() * depth;
	}
	
	/** Areaberäkning
	 * height och width är ju privata i basklassen, och även om denna klass ärver därifrån kan de 
	 * enbart nås via motsvarande publika egenskaper. De kan med andra ord inte nås med this, som 
	 * man skulle kunna göra med depth, även om de faktiskt är nedärvda klassvariabler och är en del av denna klass.
	 * @return summan av lådans alla sidor
	 */
	public int computeArea()
	{
		int parallelSides1 = (getWidth() * getHeight()) * 2;
		int parallelSides2 = (getWidth() * depth) * 2;
		int parallelSides3 = (getHeight() * depth) * 2;
		return parallelSides1 + parallelSides2 + parallelSides3;
	}
	
	/** Publik egenskap för depth
	 * 
	 * @return värdet för privata fältet depth
	 */
	public int getDepth()
	{
		return depth;
	}
	
	/** Publik egenskap för depth
	 * 
	 * @param depth sätter värdet för privata fältet depth
	 */
	public void setDepth(int depth)
	{
		this.depth = depth;
	}
	
	/** Överskuggad toString-metod
	 * 
	 */
	@Override
	public String toString() 
	{
		return String.format("En låda med bredden %d, höjden %d och djupet %d.", getWidth(), getHeight(), depth);
	}

	/** Överskuggad equals-metod 
	 * @return true om det inmatade objektet uppfyller följande villkor
	 * 1. Att ett objekt faktiskt har skickats med som argument när metoden anropas
	 * 2. Att det medskickade objektet som argument vid anrop av metoden är av den klassen som detta objekt när det har initierats
	 * 3. Har samma volym, det vill säga att produkten av de privata fälten är samma som detta objekts produkt av de privata fälten
	 * Om någon av dessa villkor inte uppfylls returneras false.
	 */
	@Override
	public boolean equals(Object otherObject) 
	{
		if (otherObject == null)
		{
			return false;
		}
		else if (getClass() != otherObject.getClass())
		{
			return false;
		}
		else
		{
			Box otherBox = (Box)otherObject;
			if (computeVolume() == otherBox.computeVolume())
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
	
	
	
	

}
