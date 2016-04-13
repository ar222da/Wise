package ar222da;

public class Message2 
{
	public static void main(String[] args)
	{
		MultiDisplay multiDisplay = new MultiDisplay();
		multiDisplay.statement = "I have a dream.";
		multiDisplay.numberOfTimesToDisplay = 10;
		multiDisplay.display();
		multiDisplay.display("Make love, not war.", 5);
	}

}

class MultiDisplay
{
public static String statement;
public static int numberOfTimesToDisplay;
public static String Fest;

public  void  display(){
int i;

for( i=1; i<=numberOfTimesToDisplay; i++){
 
  System.out.printf(" "+ statement+" ");
 
 }
     
 }

public  void  display(String statement , int number){



 numberOfTimesToDisplay = number;
   this.statement = statement;
   this.display();
  
     
 }
 
 
}
