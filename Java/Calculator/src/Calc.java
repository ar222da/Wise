package Calculator;

public class Calc
	{
		private int op1;
		private int op2;
		private char operation;
		
		public Calc(String op1, String op2, String operation)
		{
			this.op1 = Integer.parseInt(op1);
			this.op1 = Integer.parseInt(op2);
			this.operation = operation.charAt(0);
		}
		
		public int getAnswer()
		{
			int answer = 0;
			switch(operation)
			{
				case '+':
					answer = op1 + op2;
					break;
				
				case '-':
					answer = op1 - op2;
					break;
					
				case '*':
					answer = op1 * op2;
					break;
					
				case '/':
					answer = op1 / op2;
					break;
			
			}
			
			return answer;
		}
		
	}