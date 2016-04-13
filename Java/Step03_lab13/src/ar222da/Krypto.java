package ar222da;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileNotFoundException;
import java.io.IOException;

public class Krypto 
{
	public static void main(String[] args)
	{
		// Str�ng som ska inneh�lla hela filinneh�llet
		String binaryDataInTextfile = "";
		
		// G�r ett f�rs�k att �ppna och l�sa fr�n fil
		try
		{
			BufferedReader inputStream = new BufferedReader(new FileReader("krypto.txt"));
			// Ta in hela filinneh�llet som en enda str�ng
			binaryDataInTextfile = inputStream.readLine();
			// St�ng filen
			inputStream.close();
		}
		
		// Hittas inte filen tas detta undantag hand om h�r
		catch(FileNotFoundException e)
		{
			System.out.println("Filen hittades inte.");
		}
		// Kan inte filen l�sas tas detta undantag hand om h�r
		catch(IOException e)
		{
			System.out.println("Filen kunde inte l�sas.");
		}
		
		// Man vet att filen inneh�ller en f�ljd av bin�ra tal och att 
		// detta ska resultera i en str�ng som �r uppbyggda av char 
		// som kan uttryckas med ASCII-v�rden
		// Varje char-tecken motsvarar 8 bitar = 1 byte
		// D�rf�r kan vi dela hela str�mmen av bin�ra tal med 8 s� f�r vi antalet bytes
		int numberOfBytes = binaryDataInTextfile.length() / 8;
		
		
		// Start-bit som inleder aktuell byte
		int startBitOfByte;
		// Slut-bit som avslutar aktuell byte
		int endBitOfByte;
		// Motsvarande ASCII-v�rde f�r aktuell byte
		int ascIIValue;
				
		
		// Loopa lika m�nga g�nger som det finns bytes
		for (int index = 0; index < numberOfBytes; index++)
		{
			// Ta reda p� var aktuell byte i den l�nga bin�ra str�ngen b�rjar och slutar
			startBitOfByte = index * 8;
			endBitOfByte = (index * 8) + 8;

			// Den str�ng som i bin�rt format ska inneh�lla aktuell byte
			String byteInBinaryFormatString = "";
			
			// Nu ska varje bin�rt tal inom aktuell byte fyllas p� i en str�ng som representerar en byte 
			for (int indexInner = startBitOfByte; indexInner < endBitOfByte; indexInner++)
			{
				byteInBinaryFormatString += binaryDataInTextfile.charAt(indexInner);
			}
			
			// Nu inneh�ller byteInBinaryFormatString aktuell byte
			// Denna �r nu i bin�rt format och konverteras h�r till motsvarande decimaltal
			ascIIValue = Integer.parseInt(byteInBinaryFormatString, 2);
			
			// Decimaltalet �r ASCII-v�rdet f�r aktuellt tecken
			char c = (char)ascIIValue;
			// Skriv ut motsvarande tecken
			System.out.print(c);
			// Texten byggs allts� upp genom att tecken f�r tecken byggs p�
		}
		
	}
	
	
	

}
