package ar222da;

import java.util.Arrays;
import java.util.Random;

public class Lotto
{
	private int[] row;
	private static Random random = new Random();

	// Konstruktor
	public Lotto()
	{
		// Skapa en array best�ende av 7 platser
		row = new int[7];
		this.draw();
	}

	// Genererar en rad, det vill s�ga fyller den tomma arrayen som initieras i konstruktorn
	public void draw()
	{
		int number = 0;
		// Unikt tal har tilldelats
		boolean uniqueNumberAssigned;
		// Dublett hittad
		boolean foundDuplicate;
		
		// I den tomma arrayen med 7 platser ska varje plats tilldelas ett slumpat heltal mellan 1 och 35
		// Arrayens l�ngd �r lika med antalet platser
		for (int index = 0; index < row.length; index++)
		{
			// Ett unikt slumptal har �nnu inte tilldelats f�r aktuell loop-omg�ng
			uniqueNumberAssigned = false;
			// Inte heller har n�gon dublett hittats
			foundDuplicate = false;
			
			// K�r f�ljande avsnitt tills ett unikt slumptal tilldelats aktuell plats (index) i arrayen
			while (uniqueNumberAssigned == false)
			{
				// Ett slumpat tal genereras, dock �r det inget som s�ger att det �r unikt
				number = 1 + random.nextInt(35);
				
				// D�rf�r m�ste f�rg�ende tilldelade platser i arrayen kontrolleras gentemot detta genererade tal
				// �r det f�rsta loop-omg�ngen s� beh�ver f�ljande avsnitt inte k�ras eftersom
				// det �r f�rsta g�ngen ett tal genererats och d�rmed kan inga dubletter finnas
				if (index > 0)
				{
					// Loopa igenom s� l�ngt som den yttre loopen har kommit
					for (int i = 0; i < index; i++)
					{
						// Finns det genererade talet redan i n�gon av de platser i arrayen som redan har
						// tilldelats ett v�rde
						if (row[i] == number)
						{
							// I s� fall, har dubletts hittats
							// och denna inre loop kan brytas
							foundDuplicate = true;
							break;
						}
						
						else
						{
							foundDuplicate = false;
						}
					
					} // Slut p� inre loop
					
				} // Slut p� avsnitt som k�rs om det inte �r f�rsta loop-omg�ngen
				
				// Har ingen dublett hittats tilldelar vi helt enkelt det nummer som har genererats 
				// f�r denna loopomg�ng med motsvarande plats i arrayen
				// foundDuplicate �r of�r�ndrad om ovan avsnitt inte k�rs, det vill s�ga under f�rsta loop-omg�ngen
				if (foundDuplicate == false)
				{
					// Tilldela det genererade slumptalet
					row[index] = number;
					// Den aktuella array-platsen som avg�rs av index har nutilldelats ett v�rde
					uniqueNumberAssigned = true;
				}
				
			} // om uniqueNumberAssigned nu �r true, s� nu bryts detta avsnitt
			// Annars k�rs hela detta avsnitt p� nytt f�r att generera ett nytt tal
		
			
		} //Aktuell loop-omg�ng �r klar
		
		// Nu har sju unika tal mellan 1 och 35 genererats och varje plats i arrayen har tilldelats ett av dessa	
		// Sortera arrayen i stigande ordning
		Arrays.sort(row);
	}

	// Returnera arrayen som en str�ng
	public String toString()
	{
		// Hela arrayen som en rad
		String completeRow = "";
		
		for (int i = 0; i < row.length; i++)
		{
			// Varje enskilt element i arrayen byggs p� i raden och med formattering s�
			// att varje element tar upp tre platser i utrymme och �r h�gerjusterad
			String element = String.format("%3s", row[i]);
			completeRow += element;
		}
		
		return completeRow;
	}

	// J�mf�r tv� arrayer med varandra
	public boolean equals(Lotto other)
	{
		if (this.row.equals(other.row))
		{
			return true;
		}
		
		else
		{
			return false;
		}
	}

}
