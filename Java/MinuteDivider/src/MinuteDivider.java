public class MinuteDivider 
{
	public static final int MINUTES_PER_DAY = 24 * 60;
	public static final int MINUTES_PER_HOUR = 60;
	
	public static void main(String[] args)
	{
		int minutes = 123456;
		int hours = 0;
		int days = 0;
		int remainingMinutes = 0;
		
		remainingMinutes = minutes;
		days = remainingMinutes / MINUTES_PER_DAY;
		remainingMinutes = remainingMinutes % MINUTES_PER_DAY;
		hours = remainingMinutes / MINUTES_PER_HOUR;
		remainingMinutes = remainingMinutes % MINUTES_PER_HOUR;
		
		System.out.printf
		("%d minuter blir %d dagar, %d timmar och %d minuter", minutes, days, hours, remainingMinutes);
	}

}
