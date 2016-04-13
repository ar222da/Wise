/**1DV432 Inledande programmering med Java
 * Steg 04 Uppgift 02
 * 2015-07-09
 * @author AndersRobelius
 * 
 * */
package ar222da;

/** Klassen Box som �rver fr�n basklassen Rectangle
 *  
 */
public class Box extends Rectangle
{
	/** Privat variabel som �r unik f�r just Box-klassen
	 * width och height �rvs fr�n basklassen
	 */
	private int depth;
	
	/** Konstruktor som inte tar emot n�gra agrument. Alla privata f�lt nollst�lls n�r objektet skapas.
	 * width och height nollst�lls genom anrop av basklassens konstruktor.
	 * Unika f�ltet depth f�r Box tilldelas noll direkt.
	 */
	public Box()
	{
		super(0,0);
		this.depth = 0;
	}
	
	/** Konstruktor som tar emot argument. 
	 * width och height s�tts genom anrop av basklassens konstruktor.
	 * @param width s�tts genom anrop av basklassens konstruktor.
	 * @param height s�tts genom anrop av basklassens konstruktor.
	 * @param depth �r unik f�r Box och s�tts direkt.
	 */
	public Box(int width, int height, int depth)
	{
		super(width, height);
		this.depth = depth;
	}
	
	/** Volymber�kning
	 * 
	 * @return produkten av bredd, h�jd och djup
	 */
	public int computeVolume()
	{
		return getWidth() * getHeight() * depth;
	}
	
	/** Areaber�kning
	 * height och width �r ju privata i basklassen, och �ven om denna klass �rver d�rifr�n kan de 
	 * enbart n�s via motsvarande publika egenskaper. De kan med andra ord inte n�s med this, som 
	 * man skulle kunna g�ra med depth, �ven om de faktiskt �r ned�rvda klassvariabler och �r en del av denna klass.
	 * @return summan av l�dans alla sidor
	 */
	public int computeArea()
	{
		int parallelSides1 = (getWidth() * getHeight()) * 2;
		int parallelSides2 = (getWidth() * depth) * 2;
		int parallelSides3 = (getHeight() * depth) * 2;
		return parallelSides1 + parallelSides2 + parallelSides3;
	}
	
	/** Publik egenskap f�r depth
	 * 
	 * @return v�rdet f�r privata f�ltet depth
	 */
	public int getDepth()
	{
		return depth;
	}
	
	/** Publik egenskap f�r depth
	 * 
	 * @param depth s�tter v�rdet f�r privata f�ltet depth
	 */
	public void setDepth(int depth)
	{
		this.depth = depth;
	}
	
	/** �verskuggad toString-metod
	 * 
	 */
	@Override
	public String toString() 
	{
		return String.format("En l�da med bredden %d, h�jden %d och djupet %d.", getWidth(), getHeight(), depth);
	}

	/** �verskuggad equals-metod 
	 * @return true om det inmatade objektet uppfyller f�ljande villkor
	 * 1. Att ett objekt faktiskt har skickats med som argument n�r metoden anropas
	 * 2. Att det medskickade objektet som argument vid anrop av metoden �r av den klassen som detta objekt n�r det har initierats
	 * 3. Har samma volym, det vill s�ga att produkten av de privata f�lten �r samma som detta objekts produkt av de privata f�lten
	 * Om n�gon av dessa villkor inte uppfylls returneras false.
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
