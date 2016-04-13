package ar222da;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileNotFoundException;
import java.io.IOException;

public class Krypto 
{
	public static void main(String[] args)
	{
		// Sträng som ska innehålla hela filinnehållet
		String binaryDataInTextfile = "";
		
		// Gör ett försök att öppna och läsa från fil
		try
		{
			BufferedReader inputStream = new BufferedReader(new FileReader("krypto.txt"));
			// Ta in hela filinnehållet som en enda sträng
			binaryDataInTextfile = inputStream.readLine();
			// Stäng filen
			inputStream.close();
		}
		
		// Hittas inte filen tas detta undantag hand om här
		catch(FileNotFoundException e)
		{
			System.out.println("Filen hittades inte.");
		}
		// Kan inte filen läsas tas detta undantag hand om här
		catch(IOException e)
		{
			System.out.println("Filen kunde inte läsas.");
		}
		
		// Man vet att filen innehåller en följd av binära tal och att 
		// detta ska resultera i en sträng som är uppbyggda av char 
		// som kan uttryckas med ASCII-värden
		// Varje char-tecken motsvarar 8 bitar = 1 byte
		// Därför kan vi dela hela strömmen av binära tal med 8 så får vi antalet bytes
		int numberOfBytes = binaryDataInTextfile.length() / 8;
		
		
		// Start-bit som inleder aktuell byte
		int startBitOfByte;
		// Slut-bit som avslutar aktuell byte
		int endBitOfByte;
		// Motsvarande ASCII-värde för aktuell byte
		int ascIIValue;
				
		
		// Loopa lika många gånger som det finns bytes
		for (int index = 0; index < numberOfBytes; index++)
		{
			// Ta reda på var aktuell byte i den långa binära strängen börjar och slutar
			startBitOfByte = index * 8;
			endBitOfByte = (index * 8) + 8;

			// Den sträng som i binärt format ska innehålla aktuell byte
			String byteInBinaryFormatString = "";
			
			// Nu ska varje binärt tal inom aktuell byte fyllas på i en sträng som representerar en byte 
			for (int indexInner = startBitOfByte; indexInner < endBitOfByte; indexInner++)
			{
				byteInBinaryFormatString += binaryDataInTextfile.charAt(indexInner);
			}
			
			// Nu innehåller byteInBinaryFormatString aktuell byte
			// Denna är nu i binärt format och konverteras här till motsvarande decimaltal
			ascIIValue = Integer.parseInt(byteInBinaryFormatString, 2);
			
			// Decimaltalet är ASCII-värdet för aktuellt tecken
			char c = (char)ascIIValue;
			// Skriv ut motsvarande tecken
			System.out.print(c);
			// Texten byggs alltså upp genom att tecken för tecken byggs på
		}
		
	}
	
	
	

}
