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
		// Crypto-objektets nyckel tilldelas detta v�rde i och med dess konstruktors utformning
		Crypto crypto = new Crypto(113);
		
		// Str�ngen A@F bearbetas av algoritmen i funktionen crypt i Crypto-objektet.
		// Denna funktion returnerar en str�ng som f�rvandlas till ett heltal i och med att
		// vi vill ha ut nyckeln som ett heltal
		int key = Integer.parseInt(crypto.crypt("A@F"));
		
		// N�r Crypto-objektet skapas kan den enbart ta emot heltal f�r att s�tta nyckeln.
		// H�r skapas ett nytt Crypto-objekt med en ny nyckel som vi h�mtade ut genom en
		// dekryptering med hj�lp av f�rg�ende Crypto-objekts crypt-funktion.
		Crypto crypto2 = new Crypto(key);
		
		// Med det nya Crypto-objektets nyckel och crypt-funktion matar vi in den namngivna konstanten
		String mysterious_message = crypto2.crypt(MYSTERIOUS_MESSAGE);
		
		// Str�ngen presenteras och resultatet blir "Grattis! Du har lyckats!
		System.out.print(mysterious_message);
		
		// Det fungerar �ven att kryptera tillbaka den resulterade str�ngen med samma algoritm
		// s� att den f�r samma v�rde som den hade fr�n b�rjan som namngiven konstant. D�rav beh�vs bara 
		// en funktion f�r kryptering och dekryptering i klassen.
		//String m2 = crypto2.crypt("Grattis! Du har lyckats.");
		//System.out.print(m2);
	}
}

// Deklaration av klassen Crypto
class Crypto
{
	// Privata egenskapen key som ska inneh�lla v�rdet i form av heltal av det blivande objektets nyckel.
	private int key;
	
	// Konstruktorn. Ett heltal som argument och som s�tter nyckelns v�rde n�r det blivande objektets skapas.
	public Crypto(int key)
	{
		this.key = key;
	}
	
	// Krypterings- och dekrypteringsalgoritmen.
	public String crypt(String str)
	{
		// En tom str�ng skapas f�rst.
		String crypted = "";
		
		// Loopa igenom den inmatade str�ngen str, det vill s�ga loopa lika m�nga g�nger som antalet tecken
		// i den inmatade str�ngen.
		for (int i = 0; i < str.length(); i++)
		{
			// Den aktuella bokstaven i den inmatade str�ngen som best�ms av det aktuella loop-indexet.
			char ch = str.charAt(i);
			// Den tomma str�ngen fylls p� med resultatet av att g�ra en XOR-operation mellan objektets nyckel
			// och den aktuella bokstaven i den inmatade str�ngen. Str�ngen byggs allts� upp bokstav f�r bokstav.
			crypted += (char) (ch ^ this.key);
		}
		
		// Den resulterande str�ngen av algoritmen som returneras.
		return crypted;
	}
}
