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
		// Skapa en array bestående av 7 platser
		row = new int[7];
		this.draw();
	}

	// Genererar en rad, det vill säga fyller den tomma arrayen som initieras i konstruktorn
	public void draw()
	{
		int number = 0;
		// Unikt tal har tilldelats
		boolean uniqueNumberAssigned;
		// Dublett hittad
		boolean foundDuplicate;
		
		// I den tomma arrayen med 7 platser ska varje plats tilldelas ett slumpat heltal mellan 1 och 35
		// Arrayens längd är lika med antalet platser
		for (int index = 0; index < row.length; index++)
		{
			// Ett unikt slumptal har ännu inte tilldelats för aktuell loop-omgång
			uniqueNumberAssigned = false;
			// Inte heller har någon dublett hittats
			foundDuplicate = false;
			
			// Kör följande avsnitt tills ett unikt slumptal tilldelats aktuell plats (index) i arrayen
			while (uniqueNumberAssigned == false)
			{
				// Ett slumpat tal genereras, dock är det inget som säger att det är unikt
				number = 1 + random.nextInt(35);
				
				// Därför måste förgående tilldelade platser i arrayen kontrolleras gentemot detta genererade tal
				// Är det första loop-omgången så behöver följande avsnitt inte köras eftersom
				// det är första gången ett tal genererats och därmed kan inga dubletter finnas
				if (index > 0)
				{
					// Loopa igenom så långt som den yttre loopen har kommit
					for (int i = 0; i < index; i++)
					{
						// Finns det genererade talet redan i någon av de platser i arrayen som redan har
						// tilldelats ett värde
						if (row[i] == number)
						{
							// I så fall, har dubletts hittats
							// och denna inre loop kan brytas
							foundDuplicate = true;
							break;
						}
						
						else
						{
							foundDuplicate = false;
						}
					
					} // Slut på inre loop
					
				} // Slut på avsnitt som körs om det inte är första loop-omgången
				
				// Har ingen dublett hittats tilldelar vi helt enkelt det nummer som har genererats 
				// för denna loopomgång med motsvarande plats i arrayen
				// foundDuplicate är oförändrad om ovan avsnitt inte körs, det vill säga under första loop-omgången
				if (foundDuplicate == false)
				{
					// Tilldela det genererade slumptalet
					row[index] = number;
					// Den aktuella array-platsen som avgörs av index har nutilldelats ett värde
					uniqueNumberAssigned = true;
				}
				
			} // om uniqueNumberAssigned nu är true, så nu bryts detta avsnitt
			// Annars körs hela detta avsnitt på nytt för att generera ett nytt tal
		
			
		} //Aktuell loop-omgång är klar
		
		// Nu har sju unika tal mellan 1 och 35 genererats och varje plats i arrayen har tilldelats ett av dessa	
		// Sortera arrayen i stigande ordning
		Arrays.sort(row);
	}

	// Returnera arrayen som en sträng
	public String toString()
	{
		// Hela arrayen som en rad
		String completeRow = "";
		
		for (int i = 0; i < row.length; i++)
		{
			// Varje enskilt element i arrayen byggs på i raden och med formattering så
			// att varje element tar upp tre platser i utrymme och är högerjusterad
			String element = String.format("%3s", row[i]);
			completeRow += element;
		}
		
		return completeRow;
	}

	// Jämför två arrayer med varandra
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
