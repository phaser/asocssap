import std.stdio;
import core.stdc.stdio;
import std.conv;
import std.algorithm;

void printmat(int[][] mat)
{
	for (int i = 0; i < mat.length; i++)
	for (int j = 0; j < mat[i].length; j++)
	{
		write(to!string(mat[i][j]) ~ " ");
		if (j == mat[i].length - 1)
			writeln();
	}
}

int getpow5(int num)
{
	if (num == 0)
		return 0;
	int count = 0;
	int n = num;
	while ((n % 5) == 0)
	{
		count++;
		n /= 5;
	}
	return count;
}

int getpow2(int num)
{
	if (num == 0)
		return 0;
	int count = 0;
	int n = num;
	while ((n & 1) == 0)
	{
		count++;
		n >>= 1;
	}
	return count;
}

int main(string[] argv)
{
	int n;
	scanf("%d", &n);
	int[][] mat; mat.length = n;
	bool hasZero = false;
	int zx = -1;
	int zy = -1;
	for (int i = 0; i < n; i++)
	{
		mat[i].length = n;
		for (int j = 0; j < n; j++)
		{
			scanf("%d", &mat[i][j]);
			if (mat[i][j] == 0)
			{
				hasZero = true;
				zx = i;
				zy = j;
			}
		}
	}	
	//printmat(mat);

	int[][] num5; num5.length = n;
	num5[0].length = n;
	num5[0][0] = getpow5(mat[0][0]);
	for (int j = 1; j < n; j++)
	{
		num5[0][j] = getpow5(mat[0][j]);
		num5[0][j] += num5[0][j-1]; 
	}	

	for (int i = 1; i < n; i++)
	{
		num5[i].length = n;
		num5[i][0] = getpow5(mat[i][0]);
		num5[i][0] += num5[i-1][0];
		for (int j = 1; j < n; j++)
		{
			num5[i][j] = getpow5(mat[i][j]);	
			num5[i][j] += min(num5[i-1][j], num5[i][j-1]);
		}
	}
	//printmat(num5);

	int[][] num2; num2.length = n;
	num2[0].length = n;
	num2[0][0] = getpow2(mat[0][0]);
	for (int j = 1; j < n; j++)
	{
		num2[0][j] = getpow2(mat[0][j]);
		num2[0][j] += num2[0][j-1]; 
	}	

	for (int i = 1; i < n; i++)
	{
		num2[i].length = n;
		num2[i][0] = getpow2(mat[i][0]);
		num2[i][0] += num2[i-1][0];
		for (int j = 1; j < n; j++)
		{
			num2[i][j] = getpow2(mat[i][j]);	
			num2[i][j] += min(num2[i-1][j], num2[i][j-1]);
		}
	}
	//printmat(num2);
	//writeln();

	int[][] sol = (num2[n-1][n-1] < num5[n-1][n-1] ? num2 : num5);
	if (hasZero && sol[n-1][n-1] >= 1)
	{
		writeln("1");
		for (int i = 0; i < zx; i++)
		{
			write("D");
		}
		for (int i = 0; i < zy; i++)
		{
			write("R");
		}
		for (int i = zx; i < (n-1); i++)
		{
			write("D");
		}
		for (int i = zy; i < (n-1); i++)
		{
			write("R");
		}
		writeln();
	} else {			
		int cx = n - 1;
		int cy = n - 1;
		int st = 2*(n-1);
		char[] trail = new char[st];
		for (int i = 0; i < st; i++)
		{
			if (cx == 0 && cy != 0)
			{
				trail[st - i - 1] = 'R';
				cy--;
			} else
			if (cx != 0 && cy == 0)
			{
				trail[st - i - 1] = 'D';
				cx--;
			} else {
				int t = sol[cx-1][cy];
				int l = sol[cx][cy-1];
				if (t < l)
				{
					trail[st - i - 1] = 'D';
					cx--;
				} else {
					trail[st - i - 1] = 'R';
					cy--;
				}			
			}
		}				
		writeln(sol[n-1][n-1]);
		writeln(trail);
	}
	return 0;
}