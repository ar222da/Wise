/* 1DV432 - Inledande programmering med Java */
/* ar222da - Anders Robelius */
/* Steg 2 uppgift 7 */
/* 2015-06-20 */

package ar222da;

public class Step2_lab07 
{
	public static final String MYSTERIOUS_MESSAGE = "Vcpeexb01Ud1ypc1}hrzpeb?";
	
	public static void main(String[] args)
	{
		// Ett Crypto-objekt instansieras med heltalet 113 som argument
		// Crypto-objektets nyckel tilldelas detta värde i och med dess konstruktors utformning
		Crypto crypto = new Crypto(113);
		
		// Strängen A@F bearbetas av algoritmen i funktionen crypt i Crypto-objektet.
		// Denna funktion returnerar en sträng som förvandlas till ett heltal i och med att
		// vi vill ha ut nyckeln som ett heltal
		int key = Integer.parseInt(crypto.crypt("A@F"));
		
		// När Crypto-objektet skapas kan den enbart ta emot heltal för att sätta nyckeln.
		// Här skapas ett nytt Crypto-objekt med en ny nyckel som vi hämtade ut genom en
		// dekryptering med hjälp av förgående Crypto-objekts crypt-funktion.
		Crypto crypto2 = new Crypto(key);
		
		// Med det nya Crypto-objektets nyckel och crypt-funktion matar vi in den namngivna konstanten
		String mysterious_message = crypto2.crypt(MYSTERIOUS_MESSAGE);
		
		// Strängen presenteras och resultatet blir "Grattis! Du har lyckats!
		System.out.print(mysterious_message);
		
		// Det fungerar även att kryptera tillbaka den resulterade strängen med samma algoritm
		// så att den får samma värde som den hade från början som namngiven konstant. Därav behövs bara 
		// en funktion för kryptering och dekryptering i klassen.
		//String m2 = crypto2.crypt("Grattis! Du har lyckats.");
		//System.out.print(m2);
	}
}

// Deklaration av klassen Crypto
class Crypto
{
	// Privata egenskapen key som ska innehålla värdet i form av heltal av det blivande objektets nyckel.
	private int key;
	
	// Konstruktorn. Ett heltal som argument och som sätter nyckelns värde när det blivande objektets skapas.
	public Crypto(int key)
	{
		this.key = key;
	}
	
	// Krypterings- och dekrypteringsalgoritmen.
	public String crypt(String str)
	{
		// En tom sträng skapas först.
		String crypted = "";
		
		// Loopa igenom den inmatade strängen str, det vill säga loopa lika många gånger som antalet tecken
		// i den inmatade strängen.
		for (int i = 0; i < str.length(); i++)
		{
			// Den aktuella bokstaven i den inmatade strängen som bestäms av det aktuella loop-indexet.
			char ch = str.charAt(i);
			// Den tomma strängen fylls på med resultatet av att göra en XOR-operation mellan objektets nyckel
			// och den aktuella bokstaven i den inmatade strängen. Strängen byggs alltså upp bokstav för bokstav.
			crypted += (char) (ch ^ this.key);
		}
		
		// Den resulterande strängen av algoritmen som returneras.
		return crypted;
	}
}
