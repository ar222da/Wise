// Inledande programmering med Java - 1DV432
// Anders Robelius - ar222da
// 2015-06-20

package ar222da;

import java.util.Scanner;
	
public class Calculator 
{
	public static void main(String[] args)
	{
		Scanner keyboard = new Scanner(System.in);
		System.out.print("Ange f�rsta talet: ");
		String firstOp = keyboard.next();
		
		System.out.print("Operator (+, -, *, /): ");
		String op = keyboard.next();
		
		System.out.print("Ange andra talet: ");
		String secondOp = keyboard.next();
		
		Calc calc = new Calc(firstOp, secondOp, op);
		int answer = calc.getAnswer();

		String result = String.format("%s %s %s = %d", firstOp, op, secondOp, answer);
		
		System.out.println(result);
		keyboard.close();
	}
	
}
	
	

