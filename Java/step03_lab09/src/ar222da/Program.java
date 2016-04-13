package ar222da;

public class Program
{
	public static void main(String[] args)
	{
		// Skapar en array (kupong) med 10 Lotto-objekt (lottorader).
		Lotto[] coupon = new Lotto[10];

		// R�knare f�r antal klara lottorader.
		int index = 0;

		// Slumpar lottoraderna 0 till 9, d.v.s. 10 rader totalt.
		while (index < coupon.length)
		{

			// Skapar en ny lottorad.
			Lotto lotto = new Lotto();

			// Finns lottoraden bland dem som slumpats fram tidigare?
			int i = 0;
			while (i < index)
			{
				// Om lottoraden redan finns...
				if (coupon[i].equals(lotto))
				{
					// ...dra en ny och...
					lotto.draw();
					// ...b�rja om j�mf�relsen fr�n b�rjan...
					i = 0;
				}
				
				else
				{
					// ...annars �ka i f�r att kontrollera mot n�sta rad.
					++i;
				}
			}
			// Raden �r unik - spara den och �ka r�knaren f�r lottoraderna med
			// ett.

			coupon[index++] = lotto;
		}
		
		// Skriver ut lottoraderna.
		for (int i = 0; i < coupon.length; ++i)
		{
			System.out.println(coupon[i]);
		}
	
	}
}

